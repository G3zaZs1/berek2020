using System.Linq;
using System.Text;

namespace berek2020
{
    internal class Program
    {
        static void Main(string[] args)
        {
            /*Bérek 2020

Ebben a feladatban egy cég dolgozóinak 2020-as adatai1 állnak rendelkezésünkre, melyekkel programozási feladatokat kell megoldania.

A feladat megoldása során vegye figyelembe a következőket:
- A képernyőre írást igényló' részfeladatok eredményének megjelenítése előtt írja a képernyőre a feladat sorszámát (például:3. feladat:)!
- Az egyes feladatokban a kiírásokat a minta szerint készítse el!
- Az ékezetmentes azonosítók és kiírások is elfogadottak.
- Az azonosítókat kis- és nagybetűkkel is kezdheti.
- A program megírásakor az állományban lévő adatok helyes szerkezetét nem kell ellenőriznie, feltételezheti, hogy a rendelkezésre álló adatok a leírtaknak megfelelnek.
- Megoldását úgy készítse el, hogy az azonos szerkezetú, de tetszőleges bemeneti adatok mellett is helyes eredményt adjon! 
A berek2020.txt UTF-8 kódolású forrásállomány soraiban egy-egy dolgozó adatait tároltuk a következő

sorrendben: •neve, például: Beri Dániel •neme: nő vagy férfi •a részleg, ahol dolgozik, például: beszerzés •a belépés éve, például: 1979 •a dolgozó bére (fizetése), például: 222 943 Az állomány első sora a mezőneveket tartalmazza, az adatokat pontosvesszővel választottuk el:
Név;Neme;Részleg;Belépés;Bér
Beri Dániel;férfi;beszerzés;1979;222943
Csavar Pista;férfi;pénzügy;1995;234074

-1. Készítsen grafikus vagy konzolalkalmazást (projektet) a következő feladatok megoldásához, amelynek
            projektjét berek2020 néven mentse el!

2. Olvassa be a berek2020.txt állomány sorait és tárolja az adatokat egy olyan összetett adatszerkezetben,
            amely használatával a további feladatok megoldhatók! Ügyeljen arra, hogy az állomány első sora
            az adatok fejlécét tartalmazza!
*/

            const string File = $"..\\..\\..\\src\\berek2020.txt";
            List<Beres> ber = [];

            using StreamReader sr = new(File, encoding:Encoding.UTF8);
            
            sr.ReadLine();
            
            while (!sr.EndOfStream)
            {
                ber.Add(new(sr.ReadLine()));
            }

            sr.Close();


            //3. Határozza meg és írja ki a képernyőre, hogy hány dolgozó adatai találhatók a forrásállományban!

            var f3 = ber.Count();

            Console.WriteLine($"A forrásállományban {f3}.db dolgozó adatai találhatók.");


            //4. Határozza meg és írja ki a képernyőre a 2020-as átlagbéreket! Az eredményt ezer forintban,
                        //egy tizedesjegyre kerekítve jelenítse meg!

            var f4 = ber.Average(b => b.Ber) /1000;

            Console.WriteLine($"A 2020-as átlagbérek: {f4:F1} forint");

            //5. Kérje be egy részleg nevét a felhasználótól a minta szerint!

            Console.Write("Írd be egy részleg nevét: ");
            string input = Console.ReadLine();

            var f5 = ber
                .Where(b => b.Reszleg.Equals(input, StringComparison.OrdinalIgnoreCase)) 
                .ToList();



            ////6. Az előző feladatban megadott részlegen keresse meg és írja ki a legnagyobb bérrel (fizetéssel)
            //rendelkező dolgozó adatait! Ha a megadott részleg nem létezik a cégnél, akkor a
            //„A megadott részleg nem létezik a cégnél!” feliratot jelenítse meg! Feltételezheti,
            //hogy nem alakult ki „holtverseny” egy-egy részlegen dolgozók fizetése között!

            if (f5.Any())
            {
                var max = ber.Where(b => b.Reszleg.Equals(input, StringComparison.OrdinalIgnoreCase))
                    .OrderBy(b => b.Ber)
                    .FirstOrDefault();

                if (max != null)
                {
                    Console.WriteLine("Legmagasabb bérrel rendelkező dolgozó adatai:");
                    Console.WriteLine($"Név:\t\t{max.Nev}\nNem:\t\t{max.Nem}\nRészleg:\t{max.Reszleg}\nBelépés:\t{max.Belep}\nBér\t\t{max.Ber}");
                }
            }
            else
            {
                Console.WriteLine("A megadott részleg nem létezik a cégnél!");
            }


            //7. Készítsen statisztikát az egyes részlegeken dolgozók számáról! A részlegek kiírásának sorrendje tetszőleges!

            var f7 = ber.GroupBy(b => b.Reszleg)
                .Select(group => new
                { 
                    Reszleg = group.Key,
                    Nev = group.Count() 
                });

            Console.WriteLine($"Az egyes részlegeken dolgozók száma: ");

            Console.WriteLine("Reszleg:\t\tDolgozók száma");
            foreach (var item in ber)
            {
                Console.WriteLine($"{item.Reszleg}\t\t{ber.Count}");
            }


            //~50 perc

        }
    }
}
