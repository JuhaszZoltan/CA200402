using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CA200402
{
    class Program
    {
        static List<Versenyzo> versenyzok;
        static void Main(string[] args)
        {
            F02();
            F03();
            F04();
            F06();
            F07();
            F08();

            Console.ReadKey();
        }

        private static void F08()
        {
            Console.WriteLine("F8:");
            versenyzok
                .GroupBy(x => x.Egyesulet)
                .Where(x => x.Count() > 2 && x.Key != "n.a.")
                .ToList()
                .ForEach(x => Console.WriteLine($"\t{x.Key}: {x.Count()}"));

        }

        private static void F07()
        {
            var sw = new StreamWriter(@"..\..\Res\ff.txt");

            versenyzok
                .Where(x => x.Ferfi)
                .ToList()
                .ForEach(x => sw.WriteLine($"{x.Nev};{x.OsszPont}"));
            sw.Close();
                
        }

        private static void F06()
        {
            var w = versenyzok
                .Where(x => !x.Ferfi)
                .OrderByDescending(x => x.OsszPont)
                .First();

            Console.WriteLine($"F6: {w.Nev} - {w.Egyesulet} - {w.OsszPont}");

        }

        private static void F04()
        {
            var c = versenyzok.Count(v => !v.Ferfi);
            Console.WriteLine("F4: {0:0.00}%", c / (float)versenyzok.Count * 100);
        }

        private static void F03()
        {
            Console.WriteLine($"F3: {versenyzok.Count}");
        }

        private static void F02()
        {
            versenyzok = new List<Versenyzo>();
            var sr = new StreamReader(@"..\..\Res\fob2016.txt", Encoding.UTF8);
            while (!sr.EndOfStream)
            {
                versenyzok.Add(new Versenyzo(sr.ReadLine()));
            }
            sr.Close();
        }
    }
}
