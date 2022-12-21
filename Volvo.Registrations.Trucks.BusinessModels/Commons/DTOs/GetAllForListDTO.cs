namespace Volvo.Registrations.Trucks.BusinessModels.Commons.DTOs
{
    public abstract class GetAllForListDTO
    {
        public struct Requirement
        {
            public string Filter { get; set; }
            public SortConfiguration Sort { get; set; }
            public PaginationConfiguration Pagination { get; set; }
            public HashSet<Guid> IdsToIgnore { get; set; }
        }

        public struct Result<TIViewGetAllForList>
        {
            public IEnumerable<TIViewGetAllForList> Data { get; private set; }
            public int TotalCount { get; private set; }

            public Result(IEnumerable<TIViewGetAllForList> data, int totalCount)
            {
                Data = data;
                TotalCount = totalCount;
            }
        }

        public struct SortConfiguration
        {
            public string ColumnName { get; set; }
            public string Direction { get; set; }
        }

        public struct PaginationConfiguration
        {
            public int SkipCount { get; set; }
            public int PageSize { get; set; }
        }
    }
}
