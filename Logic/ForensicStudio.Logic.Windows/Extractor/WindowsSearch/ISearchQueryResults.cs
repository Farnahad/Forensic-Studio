using System.Runtime.InteropServices;

namespace ForensicStudio.Logic.Windows.Extractor.WindowsSearch;

[ComImport]
[Guid("AB310581-AC80-11D1-8DF3-00C04FB6EF6D")]
[InterfaceType(ComInterfaceType.InterfaceIsIUnknown)]
// FORENSIC
interface ISearchQueryResults
{
    uint GetCount();
    ISearchResult GetResult(uint dwIndex);
    void Next(uint cResults);
}