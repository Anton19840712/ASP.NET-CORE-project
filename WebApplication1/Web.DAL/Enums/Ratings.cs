using System.ComponentModel;

namespace Web.DAL.Enums
{
    public enum Ratings
    {
        [Description("General Audiences")] G = 1,
        [Description("Parental Guidance Suggested")] Pg = 2 ,
        [Description("Parents Strongly Cautioned")] Pg13 = 3,
        [Description("Restricted")] R = 4,
        [Description("Adults Only")] Nc17 = 5
    }
}