using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CA200402
{
    class Versenyzo
    {
        public string Nev { get; set; }
        public bool Ferfi { get; set; }
        public string Egyesulet { get; set; }
        public int[] Pontok { get; set; }

        public int OsszPont
        {
            get
            {
                int op = 0;

                int[] rt = Pontok
                    .OrderByDescending(x => x)
                    .ToArray();

                if (rt[6] != 0) op += 10;
                if (rt[7] != 0) op += 10;

                for (int i = 0; i < rt.Length - 2; i++)
                    op += rt[i];

                return op;
            }
        }
        public Versenyzo(string s)
        {
            var t = s.Split(';');

            Nev = t[0];
            Ferfi = t[1] == "Felnott ferfi";
            Egyesulet = t[2];
            Pontok = new int[8];
            for (int i = 3; i < t.Length; i++)
                Pontok[i - 3] = int.Parse(t[i]);
        }
    }
}
