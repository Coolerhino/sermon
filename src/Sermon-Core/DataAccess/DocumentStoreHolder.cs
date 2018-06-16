using System;
using Raven.Client.Documents;

namespace Sermon_Core.DataAccess
{
    public class DocumentStoreHolder : IDocumentStoreHolder
    {
        private Lazy<IDocumentStore> store = new Lazy<IDocumentStore>(CreateStore);

        public IDocumentStore Store => store.Value;

        private static IDocumentStore CreateStore()
        {
            IDocumentStore store = new DocumentStore()
            {
                Urls = new[] { "http://localhost:8080" },
                Database = "Northwind"
            }.Initialize();

            return store;
        }
    }
}