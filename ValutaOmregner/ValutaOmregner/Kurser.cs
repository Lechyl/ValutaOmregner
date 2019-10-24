using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ValutaOmregner
{
    class Kurser
    {

        private string code { get; set; }
        private string desc { get; set; }
        private double rate { get; set; }

        public Kurser(string code, string desc, double rate = 0)
        {
            this.code = code;
            this.desc = desc;
            this.rate = rate;

        }

        public string getCode()
        {
            return this.code.ToString();
        }
        public string getDesc()
        {
            return this.desc.ToString();
        }
        public double getRate()
        {
            return this.rate;
        }

    }
}
