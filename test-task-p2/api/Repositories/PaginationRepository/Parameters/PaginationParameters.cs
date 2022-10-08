namespace api.Repositories.PaginationRepository.Parameters
{
    public class PaginationParameters
    {
        private const int MAX_ROWS_PER_PAGE = 50;

        private int pageNumber;
        private int pageSize;
        public int PageNumber
        {
            get { return pageNumber; }
            set
            {
                if (value < 1)
                {
                    pageNumber = 1;
                }
                else
                {
                    pageNumber = value;
                }
            }
        }
        public int PageSize
        {
            get
            {
                return pageSize;
            }
            set
            {
                if (value > MAX_ROWS_PER_PAGE)
                {
                    pageSize = MAX_ROWS_PER_PAGE;
                }
                else
                {
                    pageSize = value;
                }
            }
        }
    }
}
