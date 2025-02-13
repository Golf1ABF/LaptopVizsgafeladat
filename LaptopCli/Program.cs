namespace LaptopCli
{
    internal class Program
    {
        static void Main(string[] args)
        {
            List<Laptop> list = new List<Laptop>();
            var sr = new StreamReader("../../../src/laptops.txt");
            _ = sr.ReadLine();

            while (!sr.EndOfStream)
            {
                list.Add(new Laptop(sr.ReadLine()));
            }

            Console.WriteLine("5.Feladat");
            foreach (var item in list)
            {
                Console.WriteLine(item.ToString() + $"| {Math.Round(item.Price * 4.12, 0)} HUF");
            }

            Console.WriteLine("6. Feladat");
            var intelProcSSD = list
                .Where(x => x.CPU.ToLower().Contains("i7") && x.Storage.ToLower().Contains("ssd"))
                .ToList();
            for (int i = 0; i < intelProcSSD.Count; i++)
            {
                Console.WriteLine($"[{i+1}] {intelProcSSD[i]}");
            }

            var avgPriceForPrevious = intelProcSSD.Average(x => x.Price);
            Console.WriteLine($"Átlag áruk: {avgPriceForPrevious} INR");

            Console.WriteLine("7. Feladat cheap.txt fájlba írva");

            var twentyCheapest = list
                .Where(x => x.Category.CategoryName == "Gaming")
                .OrderBy(x => x.Price)
                .Take(20)
                .ToList();

            var sw = new StreamWriter("../../../src/cheap.txt");
            foreach (var item in twentyCheapest)
            {
                sw.WriteLine($"{item.Manufacturer.ManufacturerName}, {item.Model} " +
                    $"\n {item.CPU} " +
                    $"\n {item.Storage} " +
                    $"\n {item.Screen}");
            }
            sw.Close();
        }
    }
}
