using System;
using System.Collections.Generic;
using System.Text;

namespace PostalService.Models
{
    public class Customer
    {
        public string Name { get; set; }
        public string Email { get; set; }
        public string PhoneNumber { get; set; }

        public Address Address { get; private set; }


        public Customer(string name, Address address, string phoneNumber, string email = "")
        {
            Name = name;
            Email = email;
            PhoneNumber = phoneNumber;
            Address = address;

        }


        public override string ToString()
        {
            string text = Name;
            if (!string.IsNullOrEmpty(Email)) text += $", {Email}";
            if (!string.IsNullOrEmpty(PhoneNumber)) text += $", {PhoneNumber}";
            return text;
        }

    }
}
