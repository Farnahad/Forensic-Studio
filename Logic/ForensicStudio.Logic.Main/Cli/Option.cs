namespace ForensicStudio.Logic.Main.Cli;

// FORENSIC
public class Option : Parameter<string>
{
    public ParameterSeparator ParameterSeparator { get; set; }

    public Option(string name) : base(name)
    {
        ParameterSeparator = ParameterSeparator.Space;
    }

    public Option(string name, ParameterSeparator parameterSeparator) : this(name)
    {
        ParameterSeparator = parameterSeparator;
    }

    public Option(string name, string alternativeName)
        : base(name, alternativeName)
    {
        ParameterSeparator = ParameterSeparator.Space;
    }

    public Option(string name, string alternativeName, ParameterSeparator parameterSeparator)
        : this(name, alternativeName)
    {
        ParameterSeparator = parameterSeparator;
    }

    public virtual Option SetUsage(string usage)
    {
        Usage = usage;

        return this;
    }

    public virtual Option SetDescription(string description)
    {
        Usage = description;

        return this;
    }
}