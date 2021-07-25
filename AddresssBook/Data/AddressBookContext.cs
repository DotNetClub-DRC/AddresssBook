using Microsoft.EntityFrameworkCore;

namespace AddresssBook.Data
{
    public class AddressBookContext : DbContext
    {
        public AddressBookContext(DbContextOptions<AddressBookContext> options) : base(options)
        {

        }
    }
}
