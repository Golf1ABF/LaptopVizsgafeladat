using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LaptopCli
{
    public class Manufacturer
    {
        public int ManufacturerCode { get; set; }
        public string ManufacturerName { get; set; }

        public Manufacturer(int manufacturerCode, string manufacturerName)
        {
            ManufacturerCode = manufacturerCode;
            ManufacturerName = manufacturerName;
        }
    }
}
