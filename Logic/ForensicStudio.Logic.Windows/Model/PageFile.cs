namespace ForensicStudio.Logic.Windows.Model;

// FORENSIC
public class PageFile
{
    public string Name { get; set; }
    public string CurrentUsage { get; set; }
    public string PeakUsage { get; set; }
    public string AllocatedBaseSize { get; set; }
    public string CurrentBaseSize { get; set; }
    public string Caption { get; set; }
    public string Description { get; set; }
    public string InstallDate { get; set; }
    public string Status { get; set; }
}