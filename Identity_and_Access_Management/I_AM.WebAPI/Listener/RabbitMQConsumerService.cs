using I_AM.Application.TokenUse_r.DTOs;
using MediatR;
using Newtonsoft.Json;
using RabbitMQ.Client;
using RabbitMQ.Client.Events;
using System.Text;
using Constants = I_AM.WebAPI.Commons.Constants.Listener.RabbitMQConsumerService;

namespace I_AM.WebAPI.Listener;

#pragma warning disable CS8600
#pragma warning disable CS8604
#pragma warning disable CS8601
#pragma warning disable CS8602

internal class RabbitMQConsumerService(IConfiguration configuration,
    IServiceProvider serviceProvider) : BackgroundService
{
    private IConnection? _connection;
    private IChannel? _channel;
    private readonly IConfiguration _configuration = configuration;
    private readonly IServiceProvider _serviceProvider = serviceProvider;

    protected override async Task ExecuteAsync(CancellationToken stoppingToken)
    {
        string serverRabbitMQ = _configuration[Constants.SERVER_RABBIT_MQ];
        int portRabbitMQ = int.Parse(_configuration[Constants.PORT_RABBIT_MQ]);
        string userName = _configuration[Constants.USER];
        string password = _configuration[Constants.PASSWORD];
        string queueTokenUser = _configuration[Constants.QUEUE_TOKEN_USER];

        var factory = new ConnectionFactory
        {
            HostName = serverRabbitMQ,
            Port = portRabbitMQ,
            UserName = userName,
            Password = password,
            RequestedHeartbeat = TimeSpan.FromSeconds(60)
        };
        _connection = await factory.CreateConnectionAsync();
        _channel = await _connection.CreateChannelAsync();

        await ListenQueue(queueTokenUser, ProcessCreateTokenUser);

        await Task.Delay(Timeout.Infinite, stoppingToken);
    }

    private async Task ListenQueue(string queueName, Func<string, Task> processMessage)
    {
        await _channel.QueueDeclareAsync(queue: queueName, durable: false, 
            exclusive: false, autoDelete: false, arguments: null);

        var consumer = new AsyncEventingBasicConsumer(_channel);
        consumer.ReceivedAsync += async (model, ea) =>
        {
            var message = Encoding.UTF8.GetString(ea.Body.ToArray());
            await processMessage(message);
        };

        await _channel.BasicConsumeAsync(queueName, autoAck: true, consumer: consumer);
    }

    private async Task ProcessCreateTokenUser(string message)
    {
        using var scope = _serviceProvider.CreateScope();
        var mediator = scope.ServiceProvider.GetRequiredService<IMediator>();

        CreateTokenUserRequestDTO request = 
            JsonConvert.DeserializeObject<CreateTokenUserRequestDTO>(message);
        await mediator.Send<CreateTokenUserRequestDTO>(request);
        await Task.Yield();
    }
}