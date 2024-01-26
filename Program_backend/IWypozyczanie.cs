using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Projekt
{
    internal interface IWypozyczanie
    {
        public void WypozyczSamochod(Wypozyczenie wypo);

        public void OddanieSamochodu(Wypozyczenie wypo,bool CzySprawny);
    }
}
