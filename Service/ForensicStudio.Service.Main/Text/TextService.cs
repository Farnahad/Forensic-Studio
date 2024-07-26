namespace ForensicStudio.Service.Main.Text;

public class TextService : ITextService
{
    public string GetEditTitle(string modelName, string modelProperty)
    {
        return string.IsNullOrWhiteSpace(modelProperty) ?
            "ویرایش " + modelName : "ویرایش " + modelName + " - " + modelProperty;
    }

    public string GetAddTitle(string modelName)
    {
        return modelName + " جدید";
    }

    public string GetListTitle(string modelName)
    {
        return "لیست " + modelName;
    }

    public void Dispose()
    {
    }
}