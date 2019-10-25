using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ValutaOmregner
{
    class RealtimeUpdate
    {

        public double ValutaOmregner(double valuta, double Gammelkurs, double nykurs)
        {
            //Omregn kursen til fælles valuta som er danske kroner.
            double danskValuta = valuta * (Gammelkurs / 100);
            // Omregn danske kroner til ny kurs
            double nyValuta = danskValuta / (nykurs / 100);

            return nyValuta;
        }
    }
}
