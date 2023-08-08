using System.Collections.Generic;

namespace AspNetCore.Models
{
    public static class CustomerContext
    {
        public static List<Customer> Customers = new()
        {
            new Customer() {Id=1, FirstName="Songül", LastName="ÇULUKEN" , Age=25},
            new Customer() {Id=2, FirstName="Sinem", LastName="OĞRAŞ", Age=26}
        };
    }
}
