using ForensicStudio.Core.Main.Method;

namespace ForensicStudio.Logic.Windows.Extractor.WindowsSearch;

// FORENSIC
public class WindowsSearchExtractor
{
    public MethodResult<List<Model.WindowsSearch>> GetWindowsSearches()
    {
        var windowsSearches = new List<Model.WindowsSearch>();

        try
        {
            //var searchManager = new CSearchManager();

            //ISearchCatalogManager catalogManager = searchManager.GetCatalog("SystemIndex");
            //var catalogManager2 = (ISearchCatalogManager2)catalogManager;

            //var queryString = "SELECT System.ItemName, System.ItemPathDisplay FROM SystemIndex WHERE System.DateCreated > '2022-01-01'";
            //ISearchQueryHelper queryHelper = catalogManager2.GetQueryHelper();
            //queryHelper.QuerySelectAndSort(queryString, null, null, null);

            //var queryResults = queryHelper.GetQueryResults(0);

            //while (queryResults.GetCount() > 0)
            //{
            //    for (uint i = 0; i < queryResults.GetCount(); i++)
            //    {
            //        var newWindowsSearch = new Model.WindowsSearch();

            //        var result = queryResults.GetResult(i);

            //        newWindowsSearch.ItemName = result.GetValue("System.ItemName");
            //        newWindowsSearch.ItemPathDisplay = result.GetValue("System.ItemPathDisplay");

            //        windowsSearches.Add(newWindowsSearch);
            //    }

            //    queryResults.Next(1);
            //}
        }
        catch (Exception exception)
        {
            return new MethodResult<List<Model.WindowsSearch>>(exception);
        }

        return new MethodResult<List<Model.WindowsSearch>>(windowsSearches);
    }
}