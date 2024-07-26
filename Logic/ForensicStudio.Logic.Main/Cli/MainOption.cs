namespace ForensicStudio.Logic.Main.Cli;

// FORENSIC
public class MainOption : Parameter<string>
{
    public MainOption(string description) : base(null, description)
    {
    }

    public virtual MainOption SetUsage(string usage)
    {
        Usage = usage;

        return this;
    }

    public virtual MainOption SetDescription(string description)
    {
        Usage = description;

        return this;
    }
}