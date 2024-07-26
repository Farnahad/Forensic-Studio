using ForensicStudio.Core.Main.Method;
using ForensicStudio.Logic.Windows.Model;

namespace ForensicStudio.Logic.Windows.Extractor;

// FORENSIC
public class HibernateExtractor
{
    public MethodResult<Hibernate> GetHibernate()
    {
        var hibernateFilePath = @"C:\hiberfil.sys";

        return GetHibernate(hibernateFilePath);
    }

    public MethodResult<Hibernate> GetHibernate(string hibernateFilePath)
    {
        var hibernate = new Hibernate();

        try
        {
            if (File.Exists(hibernateFilePath))
            {
                var hibernateFileData = File.ReadAllBytes(hibernateFilePath);

                hibernate.FileSize = hibernateFileData.Length;
            }
            else
                return new MethodResult<Hibernate>("hiberfil.sys file not found.");
        }
        catch (Exception exception)
        {
            return new MethodResult<Hibernate>(exception);
        }

        return new MethodResult<Hibernate>(hibernate);
    }
}