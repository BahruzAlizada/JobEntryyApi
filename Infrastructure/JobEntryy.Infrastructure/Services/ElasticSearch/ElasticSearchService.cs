using JobEntryy.Application.Abstracts;
using Nest;

namespace JobEntryy.Infrastructure.Services
{
    public class ElasticSearchService<T> : IElasticSearchService<T> where T : class
    {
        private readonly IElasticClient client;
        public ElasticSearchService(IElasticClient client)
        {
            this.client = client;
        }



        public async Task DeleteDocumentAsync(string indexName, Guid id)
        {
            await client.DeleteAsync<T>(id, d => d.Index(indexName));
        }

        public async Task IndexBulkAsync(IEnumerable<T> documents, string indexName)
        {
            await client.IndexManyAsync(documents, indexName);
        }

        public async Task IndexDocumentAsync(T document, string indexName)
        {
            await client.IndexDocumentAsync(document);
        }

        public async Task<List<T>> SearchAsync(string indexName, Func<SearchDescriptor<T>, ISearchRequest> searchQuery)
        {
            var response = await client.SearchAsync<T>(searchQuery);
            return response.Documents.ToList();
        }
    }
}
