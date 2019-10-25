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
            string URLString = path;
            //Call Request with GET Method
            XmlTextReader reader = new XmlTextReader(URLString);

            while (reader.Read())
            {
                //Check if element contain this attribute
                if (reader.GetAttribute("code") != null)
                {
                    //MessageBox.Show(reader.GetAttribute("code") + reader.GetAttribute("desc") + reader.GetAttribute("rate"));
                    //Get the attributes of elements
                    string code = reader.GetAttribute("code");
                    string desc = reader.GetAttribute("desc");
                    string rate = reader.GetAttribute("rate").ToString();

                    //Create new instance object
                    Kurser kurser = new Kurser(code,desc,double.Parse(rate));
                    //Add the new instance of object to the Collection/List of Object
                    kursers.Add(kurser);
                }

            }
            return kursers;

        }
    }
}
