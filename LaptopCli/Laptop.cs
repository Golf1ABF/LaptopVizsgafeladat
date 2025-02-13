using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LaptopCli
{
    internal class Laptop
    {
        public Category Category{ get; set; }
        public string CPU { get; set; }
        public Manufacturer Manufacturer { get; set; }
        public string Model { get; set; }
        public string OS { get; set; }
        public double Price { get; set; }
        public string Ram { get; set; }
        public string Screen { get; set; }
        public string Storage { get; set; }

        public Laptop(string sor)
        {
            string[] s = sor.Split(";");
            this.Category = new Category(int.Parse(s[0]), s[1]);
            this.CPU = s[2];
            this.Manufacturer = new Manufacturer(int.Parse(s[3]), s[4]);
            this.Model = s[5];
            this.OS = s[6];
            this.Price = double.Parse(s[7]);
            this.Ram = s[8];
            this.Screen = s[9];
            this.Storage = s[10];
        }

        public override string ToString()
        {
            return $"{Category.CategoryName} | {Model} ({CPU}) | {OS}";
        }

    }
}
