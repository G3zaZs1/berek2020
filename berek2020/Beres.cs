using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace berek2020
{
    internal class Beres
    {
        public string Nev { get; set; }
        public bool Nem{ get; set; }
        public string Reszleg { get; set; }
        public int Belep { get; set; }
        public int Ber { get; set; }

        public Beres(string sor)
        {
            var v = sor.Split(';');
            Nev = v[0];
            Nem = v[1] == "férfi";
            Reszleg = v[2];
            Belep = int.Parse(v[3]);
            Ber = int.Parse(v[4]);
        }
        public override string ToString()
        {
            return $"{Nev},{(Nem ? "férfi" : "nő")},{Reszleg},{Belep},{Ber}";
        }
    }
}
