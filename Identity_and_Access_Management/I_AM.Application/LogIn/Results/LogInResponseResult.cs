namespace I_AM.Application.LogIn.Results;

#pragma warning disable CS8618

public class LogInResponseResult
{
    public Guid IdUser { get; set; }
    public string NamesUser { get; set; }
    public string LastNamesUser { get; set; }
    public string EmailUser { get; set; }
    public bool IsActiveUser { get; set; }
    public decimal CodeRol { get; set; }
    public string NameRol { get; set; }
    public string DescriptionRol { get; set; }
    public string NameModule { get; set; }
    public string DescriptionModule { get; set; }
    public string IconModule { get; set; }
    public string NameSubmodule { get; set; }
    public string DescriptionSubmodule { get; set; }
    public string RouterLinkSubmodule { get; set; }
    public string IconSubmodule { get; set; }
}