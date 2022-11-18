namespace Dentist.Application.Common.Models
{
    public class PagedRequest
    {
        public PagedRequest()
        {
            RequestFilters = new RequestFilters();
        }

        public int PageIndex { get; set; }

        public int PageSize { get; set; }

        public string ColumnNameForSorting { get; set; }

        public string SortDirection { get; set; }

        public RequestFilters RequestFilters { get; set; }
        //public PagedRequest()
        //{
        //    RequestFilters = new RequestFilters();
        //}
        //const int MAX_PAGE_SIZE = 50;

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
        //        {
        //            _page = value;
        //        }
        //        else
        //        {
        //            throw new Exception("Page can`t be less than 0");
        //        }
        //    }
        //}

        //private int _pageSize = 5;
        //public int PageSize 
        //{
        //    get
        //    {
        //        return _pageSize;
        //    }
        //    set
        //    {
        //        _pageSize = (value > MAX_PAGE_SIZE)? MAX_PAGE_SIZE : value;
        //    }
        //}

        //public string ColumnNameForSorting { get; set; }

        //public string SortDirection { get; set; }

        //public RequestFilters RequestFilters { get; set; }
    }
}
