using ForensicStudio.Core.Main.Lookup;
using ForensicStudio.DataAccess.Model.Core;
using ForensicStudio.Service.Core.Crud;
using Microsoft.EntityFrameworkCore;

namespace ForensicStudio.Service.Windows.WindowsLookup;

public class WindowsLookupDataService : IVulnerabilityLookupDataService, IVulnerabilitySourceLookupDataService
{
    private readonly ICrudService<DbModel> _crudService;

    public WindowsLookupDataService(ICrudService<DbModel> crudService)
    {
        _crudService = crudService;
    }

    public async Task<IEnumerable<LookupItem>> GetVulnerabilityLookupAsync()
    {
        return await _crudService.GetQueryable<DataAccess.Model.Windows.Vulnerability>().AsNoTracking()
            .Select(vulnerability => new LookupItem
            {
                Id = vulnerability.Id,
                DisplayMember = vulnerability.CveId
            }).ToListAsync();
    }

    public async Task<IEnumerable<LookupItem>> GetVulnerabilitySourceLookupAsync()
    {
        return await _crudService.GetQueryable<DataAccess.Model.Windows.VulnerabilitySource>().AsNoTracking()
            .Select(vulnerabilitySource => new LookupItem
            {
                Id = vulnerabilitySource.Id,
                DisplayMember = vulnerabilitySource.Name
            }).ToListAsync();
    }

    public void Dispose()
    {
        _crudService?.Dispose();
    }
}