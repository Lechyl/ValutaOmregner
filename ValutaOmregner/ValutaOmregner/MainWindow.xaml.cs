using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.Text.RegularExpressions;

namespace ValutaOmregner
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>

    public class ComboData
    {
        public string Text { get; set; }
        public double Value { get; set; }
    }
    public partial class MainWindow : Window
    {
        List<Kurser> Kurser;
        public MainWindow()
        {
            InitializeComponent();

            PopulateComboboxes();
        }
        public void PopulateComboboxes()
        {
            KursAPI kurs = new KursAPI();
            Kurser = kurs.GetProductAsync("http://www.nationalbanken.dk/_vti_bin/DN/DataService.svc/CurrencyRatesXML?lang=da");

            List<ComboData> items = new List<ComboData>();
            //this.Combobox1.SelectedValuePath = "Key";
            //this.Combobox1.DisplayMemberPath = "Value";
            foreach (var item in Kurser)
            {
                //MessageBox.Show(item.getDesc());
                // this.Combobox1.Items.Add(new KeyValuePair<string, int>("0", 0));

                items.Add(new ComboData { Text = item.getDesc() , Value = item.getRate() });
            }

            //Populate combobox 1
            Combobox1.DisplayMemberPath = "Text";
            Combobox1.SelectedValuePath = "Value";
            Combobox1.ItemsSource = items;
            Combobox1.SelectedIndex = 0;

            //Populate combobox 2
            Combobox2.DisplayMemberPath = "Text";
            Combobox2.SelectedValuePath = "Value";
            Combobox2.ItemsSource = items;
            Combobox2.SelectedIndex = 1;

        }
        private void Textbox1_TextChanged(object sender, TextChangedEventArgs e)
        {
            RealtimeUpdate realtimeUpdate = new RealtimeUpdate();
            //realtimeUpdate.ValutaOmregner(Convert.ToInt16(Textbox1.Text),Convert.ToInt16(Combobox1.SelectedItem), Convert.ToInt16(Combobox2.SelectedItem));

        }

        private void Textbox1_TextChanged_1(object sender, TextChangedEventArgs e)
        {
            RealtimeUpdate realtimeUpdate = new RealtimeUpdate();
            //realtimeUpdate.ValutaOmregner(Convert.ToInt16(Textbox2.Text),Convert.ToInt16(Combobox2.SelectedItem), Convert.ToInt16(Combobox1.SelectedItem));
        }




        private void NumberValidationTextBox(object sender, TextCompositionEventArgs e)
    {
        Regex regex = new Regex("[^0-9]+");
        e.Handled = regex.IsMatch(e.Text);
    }
}
}
