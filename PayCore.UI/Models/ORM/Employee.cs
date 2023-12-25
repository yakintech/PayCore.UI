namespace PayCore.UI.Models.ORM
{
    public class Employee : BaseEntity
    {
        //name, surname, address, city
        public string Name { get; set; }
        public string Surname { get; set; }
        public string Address { get; set;}
        public string City { get; set;}
     
    }
}
