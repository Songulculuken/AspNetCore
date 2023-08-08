using System.Collections.Generic;

namespace AspNetCore.Models
{
    public static class CustomerContext
    {
        public static List<Customer> Customers = new()
        {
            new Customer() { FirstName="Songül", LastName="ÇULUKEN" , Age=25},
            new Customer() { FirstName="Sinem", LastName="OĞRAŞ", Age=26}
        };
    }
}
