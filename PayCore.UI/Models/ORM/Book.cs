namespace PayCore.UI.Models.ORM
{
    public class Book : BaseEntity
    {
        public string Title { get; set; } = string.Empty;
        public string Description { get; set; } = string.Empty;
    }
}
