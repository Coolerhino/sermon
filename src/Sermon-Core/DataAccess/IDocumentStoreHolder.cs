using Raven.Client.Documents;

namespace Sermon_Core.DataAccess
{
    public interface IDocumentStoreHolder
    {
        IDocumentStore Store { get; }
    }
}