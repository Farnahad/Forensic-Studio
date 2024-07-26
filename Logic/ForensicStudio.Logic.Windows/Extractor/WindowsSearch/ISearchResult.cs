using ForensicStudio.Core.Main.Mvvm;
using System.Runtime.InteropServices;

namespace ForensicStudio.Logic.Windows.Extractor.WindowsSearch;

[ComImport]
[Guid("0000000B-0000-0000-C000-000000000046")]
[InterfaceType(ComInterfaceType.InterfaceIsIUnknown)]
// FORENSIC
public interface ISearchResult : IService
{
    [return: MarshalAs(UnmanagedType.LPWStr)]
    string GetValue([MarshalAs(UnmanagedType.LPWStr)] string pszName);
}