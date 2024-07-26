namespace CodeGenerator.Main;

static class Program
{
    [STAThread]
    static void Main()
    {
        var files = Directory.EnumerateFiles(
            "C:\\Users\\Farnahad\\Desktop\\Desktop Development", "*", SearchOption.AllDirectories);
        foreach (var fileName in files.Where(item => item.Contains("(I)")))
        {
            File.Delete(fileName);
        }

        Application.EnableVisualStyles();
        Application.SetCompatibleTextRenderingDefault(false);
        Application.Run(new MainForm());
    }
}