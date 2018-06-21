namespace Sermon_Core.Model.Sermon
{
    public interface ISermonFragment
    {
        string GetFromDatabase(int count, string language = "EN");
    }
}