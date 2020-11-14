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
        private Address()
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
        public static Address Examples()
        {
            Random random = new Random();
            string file = "address.json";
            string numberHouse = GenerateNumberHouse();
            string zipCode = GenerateZipCode();
            using (StreamReader sr = new StreamReader(file, Encoding.Default))
            {
                string json = sr.ReadToEnd();
                var dictionary = JsonSerializer.Deserialize<Dictionary<string, List<string>>>(json);
                string town = dictionary["town"][random.Next(0, dictionary["town"].Count)];
                string street = dictionary["street"][random.Next(0, dictionary["street"].Count)];
                Address address = new Address(street, zipCode, numberHouse, town);
                return address;
            }
        }
        private static string GenerateNumberHouse()
        {
            Random random = new Random();
            string numberHouse = "";
            int type = random.Next(1, 3);
            switch (type)
            {
                case 1:
                    numberHouse = random.Next(1, 99).ToString();
                    break;
                case 2:
                    char sign = (char)(random.Next(65, 69));
                    numberHouse = random.Next(1, 99).ToString() + sign;
                    break;
                case 3:
                    numberHouse = random.Next(1, 10) + "/" + random.Next(1, 20);
                    break;
            }
            return numberHouse;
        }
        private static string GenerateZipCode()
        {
            Random random = new Random();
            string zipCode = random.Next(00, 99).ToString() + "-" + random.Next(000, 999).ToString();
            return zipCode;
        }
    }
}