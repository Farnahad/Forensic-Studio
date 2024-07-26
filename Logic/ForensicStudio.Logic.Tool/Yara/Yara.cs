using System.Text;
using ForensicStudio.Logic.Main.Cli;

namespace ForensicStudio.Logic.Tool.Yara;

// FORENSIC
public class Yara : Command
{
    public Option AtomQualityTable { get; set; }
    public Switch C { get; set; }
    public Switch c { get; set; }
    public Switch E { get; set; }
    public Option d { get; set; }
    public Switch q { get; set; }
    public Switch FailOnWarnings { get; set; }
    public Switch f { get; set; }
    public Switch h { get; set; }
    public Option i { get; set; }
    public Option MaxProcessMemoryChunk { get; set; }
    public Option l { get; set; }
    public Option MaxStringsPerRule { get; set; }
    public Option x { get; set; }
    public Switch n { get; set; }
    public Switch N { get; set; }
    public Switch w { get; set; }
    public Switch m { get; set; }
    public Switch D { get; set; }
    public Switch M { get; set; }
    public Switch e { get; set; }
    public Switch S { get; set; }
    public Switch s { get; set; }
    public Switch L { get; set; }
    public Switch X { get; set; }
    public Switch g { get; set; }
    public Switch r { get; set; }
    public Switch ScanList { get; set; }
    public Option z { get; set; }
    public Option k { get; set; }
    public Option t { get; set; }
    public Option p { get; set; }
    public Option a { get; set; }
    public Switch v { get; set; }

    public Yara(string name) : base(name, "4.4.0")
    {
        AtomQualityTable = new Option("--atom-quality-table")
            .SetDescription("path to a file with the atom quality table");
        C = new Switch("-C", "--compiled-rules").SetDescription("load compiled rules");
        c = new Switch("-c", "--count").SetDescription("print only number of matches");
        E = new Switch("-E", "--strict-escape")
            .SetDescription("warn on unknown escape sequences");
        d = new Option("-d", "--define", ParameterSeparator.Equals)
            .SetDescription("define external variable");
        q = new Switch("-q", "--disable-console-logs")
            .SetDescription("disable printing console log messages");
        FailOnWarnings = new Switch("--fail-on-warnings").SetDescription("fail on warnings");
        f = new Switch("-f", "--fast-scan").SetDescription("fast matching mode");
        h = new Switch("-h", "--help").SetDescription("show this help and exit");
        i = new Option("-i", "--identifier", ParameterSeparator.Equals)
            .SetDescription("print only rules named IDENTIFIER");
        MaxProcessMemoryChunk = new Option("--max-process-memory-chunk", ParameterSeparator.Equals)
            .SetDescription("set maximum chunk size while reading process memory (default=1073741824)");
        l = new Option("-l", "--max-rules", ParameterSeparator.Equals)
            .SetDescription("abort scanning after matching a NUMBER of rules");
        MaxStringsPerRule = new Option("--max-strings-per-rule", ParameterSeparator.Equals)
            .SetDescription("set maximum number of strings per rule (default=10000)");
        x = new Option("-x", "--module-data=MODULE", ParameterSeparator.Equals)
            .SetDescription("pass FILE's content as extra data to MODULE");
        n = new Switch("-n", "--negate").SetDescription("print only not satisfied rules (negate)");
        N = new Switch("-N", "--no-follow-symlinks")
            .SetDescription("do not follow symlinks when scanning");
        w = new Switch("-w", "--no-warnings").SetDescription("disable warnings");
        m = new Switch("-m", "--print-meta").SetDescription("print metadata");
        D = new Switch("-D", "--print-module-data").SetDescription("print module data");
        M = new Switch("-M", "--module-names").SetDescription("show module names");
        e = new Switch("-e", "--print-namespace").SetDescription("print rules' namespace");
        S = new Switch("-S", "--print-stats").SetDescription("print rules' statistics");
        s = new Switch("-s", "--print-strings").SetDescription("print matching strings");
        L = new Switch("-L", "--print-string-length")
            .SetDescription("print length of matched strings");
        X = new Switch("-X", "--print-xor-key")
            .SetDescription("print xor key and plaintext of matched strings");
        g = new Switch("-g", "--print-tags").SetDescription("print tags");
        r = new Switch("-r", "--recursive").SetDescription("recursively search directories");
        ScanList = new Switch("--scan-list").SetDescription("scan files listed in FILE, one per line");
        z = new Option("-z", "--skip-larger", ParameterSeparator.Equals)
            .SetDescription("skip files larger than the given size when scanning a directory");
        k = new Option("-k", "--stack-size")
            .SetDescription("set maximum stack size (default=16384)");
        t = new Option("-t", "--tag").SetDescription("print only rules tagged as TAG");
        p = new Option("-p", "--threads")
            .SetDescription("use the specified NUMBER of threads to scan a directory");
        a = new Option("-a", "--timeout")
            .SetDescription("abort scanning after the given number of SECONDS");
        v = new Switch("-v", "--version").SetDescription("show version information");
    }

    protected override void SetDescription(StringBuilder stringBuilder)
    {
        stringBuilder.AppendLine("YARA 4.4.0, the pattern matching swiss army knife.");
        stringBuilder.AppendLine("Send bug reports and suggestions to: vmalvarez@virustotal.com.");

        base.SetDescription(stringBuilder);
    }

    protected override void SetUsage(StringBuilder stringBuilder)
    {
        stringBuilder.AppendLine("Usage: yara [OPTION]... [namespace:]RULES_FILE... FILE | DIR | PID");

        base.SetUsage(stringBuilder);
    }
}