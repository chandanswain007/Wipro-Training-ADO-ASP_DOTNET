namespace MVCPattern.Models
{
    public class User
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public int Age { get; set; }

        public Address UserAddress { get; set; }
    }
}