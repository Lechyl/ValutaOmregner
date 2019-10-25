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
            //Instanciate object
            KursAPI kurs = new KursAPI();
            //input GET method path to request data
            Kurser = kurs.GetProductAsync("http://www.nationalbanken.dk/_vti_bin/DN/DataService.svc/CurrencyRatesXML?lang=da");

            List<ComboData> items = new List<ComboData>();
            //this.Combobox1.SelectedValuePath = "Key";
            //this.Combobox1.DisplayMemberPath = "Value";
            foreach (var item in Kurser)
            {
                //MessageBox.Show(item.getDesc());
                // this.Combobox1.Items.Add(new KeyValuePair<string, int>("0", 0));

                items.Add(new ComboData { Text = item.getDesc(), Value = item.getRate() });
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
            if (this.IsLoaded)
            {
                //   MessageBox.Show(Textbox1.Text +" "+ Combobox1.SelectedValue);
                changedStateForValuta(1);

            }


        }

        private void Textbox1_TextChanged_1(object sender, TextChangedEventArgs e)
        {
            if (this.IsLoaded)
            {
                //   MessageBox.Show(Textbox1.Text +" "+ Combobox1.SelectedValue);
                changedStateForValuta(2);
            }
        }


        private void NumberValidationTextBox(object sender, TextCompositionEventArgs e)
        {
            Regex regex = new Regex("[^0-9]+");
            e.Handled = regex.IsMatch(e.Text);

        }

        private void Combobox1_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (this.IsLoaded)
            {
                changedStateForValuta(1);

            }
        }

        private void Combobox2_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (this.IsLoaded)
            {
                changedStateForValuta(2);

            }

        }

        private void changedStateForValuta(int i)
        {
            if(i == 1)
            {
 
                double nyValuta = 0;
                if (Textbox1.Text != "")
                {
                    RealtimeUpdate realtimeUpdate = new RealtimeUpdate();

                    nyValuta = realtimeUpdate.ValutaOmregner(Convert.ToDouble(Textbox1.Text), Convert.ToDouble(Combobox1.SelectedValue), Convert.ToDouble(Combobox2.SelectedValue));

                }

                Textbox2.TextChanged -= Textbox1_TextChanged_1;

                Textbox2.Text = nyValuta.ToString();

                Textbox2.TextChanged += Textbox1_TextChanged_1;

            }
            else if (i == 2)
            {

                double nyValuta = 0;
                if (Textbox2.Text != "")
                {
                    RealtimeUpdate realtimeUpdate = new RealtimeUpdate();

                    nyValuta = realtimeUpdate.ValutaOmregner(Convert.ToDouble(Textbox2.Text), Convert.ToDouble(Combobox2.SelectedValue), Convert.ToDouble(Combobox1.SelectedValue));

                }
                Textbox1.TextChanged -= Textbox1_TextChanged;

                Textbox1.Text = nyValuta.ToString();
                Textbox1.TextChanged += Textbox1_TextChanged;


            }
            else
            {
                MessageBox.Show("ERROR 403");
            }
        }
    }
}
