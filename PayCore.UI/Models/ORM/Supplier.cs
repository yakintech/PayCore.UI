namespace PayCore.UI.Models.ORM
{
    public class Supplier : BaseEntity
    {
        public string CompanyName { get; set; } = "";
        public string ContactName { get; set; } = "";
        public string ContactTitle { get; set; } = "";
        public string Address { get; set; } = "";

        public string Country { get; set; } = "";


    }
}
