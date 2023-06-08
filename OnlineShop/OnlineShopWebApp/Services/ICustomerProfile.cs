namespace OnlineShopWebApp.Services
{
    public interface ICustomerProfile
    {
        string Address { get; set; }

        string Email { get; set; }

        int Id { get; set; }

        string FirstName { get; set; }

        string Phone { get; set; }

        string LastName { get; set; }
    }
}