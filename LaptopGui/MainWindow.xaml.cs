using System.IO;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using LaptopCli;

namespace LaptopGui
{
    public partial class MainWindow : Window
    {
        List<Laptop> list;
        int counter = 0;
        public MainWindow()
        {
            InitializeComponent();
            list = new List<Laptop>();
            var sr = new StreamReader("../../../src/laptops.txt");
            _ = sr.ReadLine();

            while (!sr.EndOfStream)
            {
                list.Add(new Laptop(sr.ReadLine()));
            }

            konfigLbx.SelectedIndex = 0;

            gyartoLbl.Content = $"VÁLASSZON {list.GroupBy(x => x.Manufacturer.ManufacturerCode).Count()} GYÁRTÓ {list.Count()} LAPTOPJA KÖZÜL!";

            var i = 1;

            foreach (var item in list)
            {
                konfigLbx.Items.Add($"{i}. {item.ToString()}");
                i++;
            }
        }

        private void konfigLbx_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            laptopDetails(list[konfigLbx.SelectedIndex]);
            counter++;
        }

        private void laptopDetails(Laptop laptop)
        {
            List<string> l = new List<string>
            {
                $"Kategória\n\t{laptop.Category.CategoryName}\n" +
                $"Képátló\n\t{laptop.Screen.Split("-")[0]}\n" +
                $"Felbontás\n\t{laptop.Screen.Split("-")[1]}\n" +
                $"Processzor\n\t{laptop.CPU}\n" +
                $"RAM\n\t{laptop.Ram} GB\n" +
                $"Háttértár(ak)\n\t{laptop.Storage}" +
                $"\nOperációs rendszer\n\t{laptop.OS}" +
                $"\nÁr\n\t{laptop.Price* 4.12} Ft"
            };
            kilepesBtn.IsEnabled = true;
            adatLbx.ItemsSource = l;
        }

        private void kilepesBtn_Click(object sender, RoutedEventArgs e)
        {
            if (MessageBox.Show($"Ön {counter} termékünket tekinette meg. Visszavárjuk!", "", MessageBoxButton.OK) == MessageBoxResult.OK)
                Environment.Exit(0);
        }
    }
}