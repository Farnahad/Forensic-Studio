using System.Text;
using ForensicStudio.Logic.Main.Cli;

namespace ForensicStudio.Logic.Tool.WinPmem;

// FORENSIC
public class WinPmem : Command
{
    public MainOption OutputPath { get; set; }
    public Switch l { get; set; }
    public Switch u { get; set; }
    public Option d { get; set; }
    public Switch h { get; set; }
    public Switch w { get; set; }
    public Switch _0 { get; set; }
    public Switch _1 { get; set; }
    public Switch _2 { get; set; }

    public WinPmem(string name) : base(name, "Version 2.0.1 Oct 13 2020")
    {
        OutputPath = new MainOption("output path");
        l = new Switch("-l").SetDescription("Load the driver and exit.");
        u = new Switch("-u", "Unload the driver and exit.");
        d = new Option("-d", "-d [filename]")
            .SetDescription("Extract driver to this file (Default use random name).");
        h = new Switch("-h").SetDescription("Display this help.");
        w = new Switch("-w").SetDescription("Turn on write mode.");
        _0 = new Switch("-0").SetDescription("Use MmMapIoSpace method.");
        _1 = new Switch("-1")
            .SetDescription(@"Use \\Device\PhysicalMemory method (Default for 32bit OS).");
        _2 = new Switch("-2")
            .SetDescription("Use PTE remapping (AMD64 only - Default for 64bit OS).");
    }

    protected override void SetDescription(StringBuilder stringBuilder)
    {
        stringBuilder.AppendLine("Winpmem - A memory imager for windows.");
        stringBuilder.AppendLine("Copyright Michael Cohen (scudette@gmail.com) 2012-2014.");
        stringBuilder.AppendLine("NOTE: an output filename of - will write the image to STDOUT.");

        base.SetDescription(stringBuilder);
    }

    protected override void SetUsage(StringBuilder stringBuilder)
    {
        stringBuilder.AppendLine("winpmem_mini_x64_rc2.exe [option] [output path]");

        base.SetUsage(stringBuilder);
    }

    protected override void SetExamples(StringBuilder stringBuilder)
    {
        stringBuilder.AppendLine("winpmem_mini_x64_rc2.exe physmem.raw");
        stringBuilder.AppendLine("Writes an image to physmem.raw");

        base.SetExamples(stringBuilder);
    }
}