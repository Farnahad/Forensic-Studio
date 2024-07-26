namespace ForensicStudio.Logic.Main.Cli;

// FORENSIC
public abstract class Parameter<T>
{
    public string Name { get; set; }
    public string AlternativeName { get; set; }
    public string Usage { get; set; }
    public string Description { get; set; }
    public T Value { get; set; }

    protected Parameter(string name)
    {
        Name = name;
    }

    protected Parameter(string name, string alternativeName) : this(name)
    {
        AlternativeName = alternativeName;
    }
}