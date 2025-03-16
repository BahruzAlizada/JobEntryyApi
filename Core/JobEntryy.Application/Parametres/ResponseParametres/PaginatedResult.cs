

namespace JobEntryy.Application.Parametres.ResponseParametres
{
    public class PaginatedResult<T>
    {
        public List<T> Items { get; } // Hal-hazırda səhifələnmiş obyektlər
        public int TotalCount { get; } // Ümumi obyekt sayı (bütün səhifələr üzrə)
        public int PageNumber { get; } // Hazırkı səhifə nömrəsi
        public int PageSize { get; } // Bir səhifədəki obyekt sayı
        public int TotalPages => (int)Math.Ceiling((double)TotalCount / PageSize); // Ümumi səhifə sayı

        public PaginatedResult(List<T> items, int totalCount, int pageNumber, int pageSize)
        {
            Items = items;
            TotalCount = totalCount;
            PageNumber = pageNumber;
            PageSize = pageSize;
        }

    }
}
