using System;
using System.Collections.Generic;
using System.Linq;
using System.Xml;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace ValutaOmregner
{

    class KursAPI
    {

        public List<Kurser> GetProductAsync(string path)
        {
            List<Kurser> kursers = new List<Kurser>();
            String URLString = path;
            XmlTextReader reader = new XmlTextReader(URLString);

            while (reader.Read())
            {
                if (reader.GetAttribute("code") != null)
                {
                    //MessageBox.Show(reader.GetAttribute("code") + reader.GetAttribute("desc") + reader.GetAttribute("rate"));

                    string one = reader.GetAttribute("code");
                    string two = reader.GetAttribute("desc");
                    string three = reader.GetAttribute("rate").ToString();
                    Kurser kurser = new Kurser(one,two,double.Parse(three));
                    kursers.Add(kurser);
                }

            }
            return kursers;

        }
    }
}
