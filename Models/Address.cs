using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Web;

namespace BudzetDomowy.Models
{
    public class Address
    {
        private string street;
        private string zipCode;
        private string number;
        private string town;
        public string Street { get => this.street; }
        public string ZipCode { get => this.zipCode; }
        public string Number { get => this.number; }
        public string Town { get => this.town; }
        public Address()
        {
            this.street = string.Empty;
            this.zipCode = string.Empty;
            this.number = string.Empty;
            this.town = string.Empty;
        }
        public Address(string street, string zipCode, string number, string town) : this()
        {
            this.street = street;
            this.zipCode = zipCode;
            this.number = number;
            this.town = town;
        }
        public void ChangeAddress(Address address)
        {
            this.street = address.street;
            this.street = address.zipCode;
            this.street = address.number;
            this.street = address.town;
        }
        //public static Address Examples()
        //{
        //    string file = AppDomain.CurrentDomain.BaseDirectory + @"/App_Data/" + "address.json";
        //    string numberHouse = GenerateNumberHouse();
        //    string zipCode = GenerateZipCode();
        //    using (StreamReader sr = new StreamReader(file, Encoding.Default))
        //    {
        //        string json = sr.ReadToEnd();
        //        var dictionary = JsonSerializer.Deserialize<Dictionary<string, List<string>>>(json);
        //        string town = dictionary["town"][DateGenerate.random.Next(0, dictionary["town"].Count)];
        //        string street = dictionary["street"][DateGenerate.random.Next(0, dictionary["street"].Count)];
        //        Address address = new Address(street, zipCode, numberHouse, town);
        //        return address;
        //    }
        //}
        //private static string GenerateNumberHouse()
        //{
        //    string numberHouse = "";
        //    int type = DateGenerate.random.Next(1, 3);
        //    switch (type)
        //    {
        //        case 1:
        //            numberHouse = DateGenerate.random.Next(1, 99).ToString();
        //            break;
        //        case 2:
        //            char sign = (char)(DateGenerate.random.Next(65, 69));
        //            numberHouse = DateGenerate.random.Next(1, 99).ToString() + sign;
        //            break;
        //        case 3:
        //            numberHouse = DateGenerate.random.Next(1, 10) + "/" + DateGenerate.random.Next(1, 20);
        //            break;
        //    }
        //    return numberHouse;
        //}
        //private static string GenerateZipCode()
        //{
        //    string zipCode = DateGenerate.random.Next(00, 99).ToString() + "-" + DateGenerate.random.Next(000, 999).ToString();
        //    return zipCode;
        //}
    }
}