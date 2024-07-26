namespace ForensicStudio.Logic.Main.Cli;

// FORENSIC
public class Switch : Parameter<bool>
{
    public Switch(string name) : base(name)
    {
    }

    public Switch(string name, string alternativeName)
        : base(name, alternativeName)
    {
    }

    public virtual Switch SetUsage(string usage)
    {
        Usage = usage;

        return this;
    }

    public virtual Switch SetDescription(string description)
    {
        Usage = description;

        return this;
    }
}