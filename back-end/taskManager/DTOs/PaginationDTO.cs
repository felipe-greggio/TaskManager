namespace task_manager.DTOs
{
    public class PaginationDTO<T>
    {
        public int Count { get; set; }
        public int PageSize { get; set; }
        public int PageNumber { get; set; }
        public IEnumerable<T> Data { get; set; }

        public PaginationDTO(int count, int pageSize, int pageNumber, IEnumerable<T> data) 
        {
            Count = count;
            PageSize = pageSize;
            PageNumber = pageNumber;
            Data = data;
        }
    }
}
