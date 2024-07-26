using System.Runtime.InteropServices;

namespace ForensicStudio.Logic.Windows.Extractor.WindowsSearch;

[ComImport]
[Guid("BCFC5AED-255E-11DA-8BB0-00123FCE74F1")]
[InterfaceType(ComInterfaceType.InterfaceIsIUnknown)]
// FORENSIC
interface ISearchCatalogManager2 : ISearchCatalogManager
{
}