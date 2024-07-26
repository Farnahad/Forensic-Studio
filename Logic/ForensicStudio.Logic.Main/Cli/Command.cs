using System.Text;

// ReSharper disable VirtualMemberCallInConstructor
namespace ForensicStudio.Logic.Main.Cli;

public class Command
{
    public string Name { get; set; }
    public string Version { get; set; }
    public string Description { get; set; }
    public string Usage { get; set; }
    public string Examples { get; set; }

    public Command(string name)
    {
        Name = name;

        SetDescription(new StringBuilder());
        SetUsage(new StringBuilder());
        SetExamples(new StringBuilder());
    }

    public Command(string name, string version) : this(name)
    {
        Version = version;
    }

    public Command(string name, string version, string description) : this(name, version)
    {
        Description = description;
    }

    protected virtual void SetDescription(StringBuilder stringBuilder)
    {
        var description = stringBuilder.ToString();

        if (string.IsNullOrWhiteSpace(description) == false)
            Description = description;
    }

    protected virtual void SetUsage(StringBuilder stringBuilder)
    {
        var usage = stringBuilder.ToString();

        if (string.IsNullOrWhiteSpace(usage) == false)
            Usage = usage;
    }

    protected virtual void SetExamples(StringBuilder stringBuilder)
    {
        var examples = stringBuilder.ToString();

        if (string.IsNullOrWhiteSpace(examples) == false)
            Examples = examples;
    }
}