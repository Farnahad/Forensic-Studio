using System.Runtime.InteropServices;

namespace ForensicStudio.Logic.Windows.Extractor.WindowsSearch;

[ComImport]
[Guid("10F62C64-7E16-4312-9170-2387B3087A48")]
[InterfaceType(ComInterfaceType.InterfaceIsIUnknown)]
// FORENSIC
interface ISearchQueryHelper
{
    void QuerySelectAndSort([MarshalAs(UnmanagedType.LPWStr)] string pQuery,
        [MarshalAs(UnmanagedType.Interface)] object pColumns,
        [MarshalAs(UnmanagedType.Interface)] object pSort,
        [MarshalAs(UnmanagedType.Interface)] object pMaxResults);
    ISearchQueryResults GetQueryResults(uint dwMaxResults);
}