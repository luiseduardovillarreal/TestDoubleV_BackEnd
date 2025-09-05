namespace I_AM.Application.Commons;

#pragma warning disable CS8618

public class ResultQuerie<T>
{
    public List<string> Columns { get; set; }
    public List<T> Data { get; set; }
}

public sealed class DTOQuerie<T>
{
    public bool State { get; set; }
    public ResultQuerie<T> Result { get; set; }
}