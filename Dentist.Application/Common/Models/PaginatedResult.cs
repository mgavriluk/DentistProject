namespace Dentist.Application.Common.Models
{
    public class PaginatedResult<T> where T : class 
    {
        public int PageIndex { get; set; }
        public int PageSize { get; set; }
        public int Total { get; set; }
        public IList<T> Items { get; set; }
        //private int _page = 1;
        //public int Page
        //{
        //    get
        //    {
        //        return _page;
        //    }
        //    set
        //    {
        //        if (value >= 1)
        //            _page = value;
        //        else
        //            throw new Exception("Page can`t be less than 0");
        //    }
        //}
        //public int PageSize { get; set; }
        //public int Total { get; set; }
        //public IList<T> Items { get; set; }
    }
}
