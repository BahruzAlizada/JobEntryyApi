using Nest;

namespace JobEntryy.Application.Abstracts
{
    public interface IElasticSearchService<T> where T : class
    {
        Task IndexDocumentAsync(T document, string indexName);
        Task IndexBulkAsync(IEnumerable<T> documents, string indexName);
        Task<List<T>> SearchAsync(string indexName, Func<SearchDescriptor<T>, ISearchRequest> searchQuery);
        Task DeleteDocumentAsync(string indexName, Guid id);
    }
}
