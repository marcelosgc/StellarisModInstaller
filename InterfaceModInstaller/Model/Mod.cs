namespace InterfaceModInstaller.Model;

public class Mod
{
    public int Id { get; set; }
    public string Name { get; set; }
    public string Code { get; set; }
    public bool IsActive { get; set; }
    public DateTime? InstallationDate { get; set; }
    public DateTime? ModificationDate { get; set; }
}