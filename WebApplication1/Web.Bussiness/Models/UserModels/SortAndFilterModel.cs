using Web.Bussiness.Enums;
using Web.DAL.Enums;

namespace Web.Bussiness.Models.UserModels
{
    public class SortAndFilterModel
    {
        public SortingTerms SortingTerm { get; set; }
        public SortOptions SortingDirection { get; set; }
        public FilteringTerms FilteringTerm { get; set; }
        public Genres Genre { get; set; }
        public Ratings Rating { get; set; }
    }
}