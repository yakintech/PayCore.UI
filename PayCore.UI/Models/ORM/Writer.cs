namespace PayCore.UI.Models.ORM
{
    public class Writer : BaseEntity
    {
        public string Name { get; set; }
        public string Surname { get; set; }

        public DateTime BirthDate { get; set; }
    }
}
