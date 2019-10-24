using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ValutaOmregner
{
    class RealtimeUpdate
    {

        public int ValutaOmregner(int valuta, int Gammelkurs,int nykurs)
        {
            //Omregn kursen til fælles valuta som er danske kroner.
            int danskValuta = valuta * (Gammelkurs / 100);
            // Omregn danske kroner til ny kurs
            int nyValuta = danskValuta * (nykurs / 100);

            return nyValuta;
        }
    }
}
