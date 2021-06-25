namespace Web.Bussiness.Models.CommonModels
{
    public class PaginationModel
    {
        public int NumberOfRowsPerPage { get; set; }
        public int CurrentPage { get; set; }
        public int CalculatedSkip() => CurrentPage == 1 ? 0 : NumberOfRowsPerPage * CurrentPage;
    }
}