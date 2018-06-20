﻿using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.Extensions.DependencyInjection;
using Raven.Client.Documents.Linq;
using Raven.Client.Documents.Session;
using Sermon_Core.Model;
using Sermon_Twitter;

namespace Sermon_Core.DataAccess
{
    public class Documents
    {
        private IDocumentStoreHolder _documentStore = IoC.Services.GetService<IDocumentStoreHolder>();

        public void StoreKeys(string consumerKey, string consumerKeySecret, string accessToken, string accessTokenSecret)
        {
            var store = _documentStore.Store;
            using (var session = store.OpenSession(new SessionOptions() { Database = "twitterkeys" }))
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
        public void StorePopeName(string language, string twitterId)
        {
            var store = _documentStore.Store;
            using (var session = store.OpenSession(new SessionOptions() { Database = "pope" }))
            {
                session.Store(new PopeInternationalName()
                {
                    Language = language,
                    TwitterId = twitterId
                }, language);
                session.SaveChanges();
            }
        }
        public PopeInternationalName GetPopeName(string language)
        {
            var store = _documentStore.Store;
            using (var session = store.OpenSession(new SessionOptions() { Database = "pope" }))
            {
                var popeId = session.Load<PopeInternationalName>(language);
                return popeId;
            }
        }

        public void StoreSermonFragment<T>(IEnumerable<string> fragments, string language)
        {
            var store = _documentStore.Store;
            using (var session = store.OpenSession(new SessionOptions() { Database = "sentences" }))
            {
                foreach (var fragment in fragments)
                {
                    var idPath = $"language/{typeof(T).Name.ToLower()}/";
                    session.Store(fragment, idPath);
                }
            }
        }
        public List<T> GetSermonFragment<T>(int count = 1)
        {
            var store = _documentStore.Store;
            using (var session = store.OpenSession(new SessionOptions() { Database = "sentences" }))
            {
                var idPath = $"language/{typeof(T).Name.ToLower()}/";
                var sentences = session.Query<T>(idPath)
                    .Customize(x => x.RandomOrdering())
                    .Take(count)
                    .ToList();
                //var sentencess = session
                //    .Advanced
                //    .DocumentQuery<T>(idPath)
                //    .RandomOrdering()
                //    .Take(count)
                //    .ToList();
                return sentences;
            }
        }
    }
}