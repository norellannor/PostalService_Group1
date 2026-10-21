using System;
using System.Collections.Generic;
using System.Text;

namespace PostalService
{
    public class Customer
    {
        public string Name { get; set; }
        public string Email { get; set; } = string.Empty;
        public string PhoneNumber { get; set; }
        
        public Address Address { get; set; }


        public Customer(string name, string email, string phoneNumber, Address address)
        {
            Name = name;
            Email = email;
            PhoneNumber = phoneNumber;
            Address = address;

        }
        
    }
}
