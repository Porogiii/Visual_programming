using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace hw_11.Struct
{
    public class User
    {
        [DisplayAttribute] public int id { get; set; }
        [DisplayAttribute] public string name { get; set; }
        [DisplayAttribute] public string username { get; set; }
        [DisplayAttribute] public string email { get; set; }
         public Address address { get; set; }
        [DisplayAttribute] public string phone { get; set; }
        [DisplayAttribute] public string website { get; set; }
        [DisplayAttribute] public Company company { get; set; }
    }
    public class Address
    {
        [DisplayAttribute] public string street { get; set; }
        [DisplayAttribute] public string suite { get; set; }
        [DisplayAttribute] public string city { get; set; }
        [DisplayAttribute] public string zipcode { get; set; }
    }
    
    public class Company
    {
        [DisplayAttribute] public string name { get; set; }
        [DisplayAttribute] public string catchPhrase { get; set; }
        [DisplayAttribute] public string bs { get; set; }
    }
}
