using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace Karikas_E_tavirat_2021._05._10
{
    class Program
    {
        struct Adat
        {
            public string varos;
            public string ido;
            public string szel;
            public int homerseklet;
        }
        static void Main(string[] args)
        {
            Adat[] adatok = new Adat[500];//Példányosítás

            //1.feladat
            StreamReader olvas = new StreamReader(@"C:\Users\Rendszergazda\Desktop\K_eszter_prog_erettsegi\2020-majus\tavirathu13.txt");
            int n = 0;
            while (!olvas.EndOfStream)
            {
                string sor = olvas.ReadLine();
                string[] db = sor.Split();
                adatok[n].varos = db[0];
                adatok[n].ido = db[1];
                adatok[n].szel = db[2];
                adatok[n].homerseklet = int.Parse(db[3]);
                n++;
            }
            olvas.Close();
            Console.WriteLine("1.feladat: Beolvasás kész!");

            //2.feladat
            Console.WriteLine("2. feladat");
            Console.Write("Adja meg egy település kódját! Település: ");
            string varos = Console.ReadLine();
            for (int i = n-1;i>=0;i--)
            {
                if (varos == adatok[i].varos)
                {
                    Console.WriteLine($"Az utolsó mérési adat a megadott településről {adatok[i].ido.Substring(0,2)}:{adatok[i].ido.Substring(2,2)}-kor érkezett.");
                    break;
                }
            }

            //3.feladat
            int max = int.MinValue;
            int index1 = -1;
            for (int i = 0;i<n;i++)
            {
                if (max < adatok[i].homerseklet)
                {
                    max = adatok[i].homerseklet;
                    index1 = i;
                }
            }
            int min = int.MaxValue;
            int index2 = -1;
            for (int i = 0; i < n; i++)
            {
                if (min > adatok[i].homerseklet)
                {
                    min = adatok[i].homerseklet;
                    index2 = i;
                }
            }

            Console.WriteLine("3.feladat");
            Console.WriteLine($"A legalacsonyabb hőmérséklet: {adatok[index2].varos} {adatok[index2].ido.Substring(0, 2)}:{adatok[index2].ido.Substring(2, 2)} {min} fok.");
            Console.WriteLine($"A legmagasabb hőmérséklet: {adatok[index1].varos} {adatok[index1].ido.Substring(0, 2)}:{adatok[index1].ido.Substring(2, 2)} {max} fok.");

            //4.feladat
            bool volt = true;
            for (int i = 0;i<n;i++)
            {
                if (adatok[i].szel == "00000")
                {
                    Console.WriteLine($"{adatok[i].varos} {adatok[i].varos} {adatok[i].ido.Substring(0, 2)}:{adatok[i].ido.Substring(2, 2)}");
                    volt = false;
                }
            }
            if (volt)
            {
                Console.WriteLine("Nem volt szélcsend a mérések idején");
            }
            Console.ReadKey();
        }
    }
}
