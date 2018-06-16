using Microsoft.Extensions.DependencyInjection;
using Raven.Client.Documents.Session;
using Sermon_Twitter;

namespace Sermon_Core.DataAccess
{
    public class Documents
    {
        private IDocumentStoreHolder _documentStore = IoC.Services.GetService<IDocumentStoreHolder>();
        
        public void StoreKeys( string consumerKey, string consumerKeySecret, string accessToken, string accessTokenSecret)
        {
            var store = _documentStore.Store;
            using (var session = store.OpenSession(new SessionOptions() {Database = "twitterkeys"}))
            {
                session.Store(new ApiKeys(consumerKey, consumerKeySecret, accessToken, accessTokenSecret), "keys");
                session.SaveChanges();
            }
        }

        public ApiKeys GetKeys()
        {
            var store = _documentStore.Store;
            using (var session = store.OpenSession(new SessionOptions() { Database = "twitterkeys" }))
            {
                var keys = session.Load<ApiKeys>("keys");
                return keys;
            }
        }
    }
}