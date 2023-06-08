namespace OnlineShopWebApp.Services
{
    public class InMemoryCustomerProfile : ICustomerProfile
    {
        public InMemoryCustomerProfile()
        {
        }


        public InMemoryCustomerProfile(string name, string lastName, int id, string email, string address, string phone, ICustomerProfile customerProfile)
        {
            FirstName = name;
            LastName = lastName;
            Id = id;
            Email = email;
            Address = address;
            Phone = phone;
        
        }

        public string FirstName { get; set; }
        public string LastName { get; set; }
        public int Id { get; set; }
        public string Email { get; set; }
        public string Address { get; set; }
        public string Phone { get; set; }
    }
}
