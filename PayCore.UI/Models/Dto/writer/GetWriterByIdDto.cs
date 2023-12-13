namespace PayCore.UI.Models.Dto
{
    public class GetWriterByIdDto
    {
        public int Id { get; set; }

        public string Name { get; set; } = string.Empty;
        public string Surname { get; set; } = string.Empty;

        public DateTime BirthDate { get; set; }

        public DateTime AddDate { get; set; }
        public DateTime UpdateDate { get; set; }
    }
}
