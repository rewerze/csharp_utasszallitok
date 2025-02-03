using System.Text;
using utasszallitok;

const string PATH = "C:\\Users\\suhajda.zsolt\\Desktop\\UTASSZALLITOK";
string[] KATEGORIAK =
["Alacsony sebességű", "Szubszonikus", "Transzszonikus", "Szuperszonikus"];


using StreamReader sr = new($"{PATH}\\utasszallitok.txt", Encoding.UTF8);
string fejlec = sr.ReadLine();

List<Utasszallto> utasszallitok = [];

while (!sr.EndOfStream) utasszallitok.Add(new(sr.ReadLine()));

Console.WriteLine($"4.feladat: adatsorok szama: {utasszallitok.Count}");

var f5 = utasszallitok.Count(u => u.Tipus.StartsWith("Boeing"));
Console.WriteLine($"5.feladat: Boeing típusok száma: {f5}");

var f6 = utasszallitok.MaxBy(u => u.Utas.Max);
Console.WriteLine($"6.feladat: A legtöbb utast szállító repülőgép típius:\n{f6}");

var f7 = KATEGORIAK.Except(
    utasszallitok.Select(u => u.Sebessegkategoria.Kategorianev)
                 .Distinct());

Console.WriteLine($"7.feladat:");
if (!f7.Any()) Console.WriteLine($"Minden sebességkategóriából van repülőgép típus.");
else Console.WriteLine($"\t{string.Join('-', f7)}");

using StreamWriter sw = new StreamWriter($"{PATH}\\utasszallitok_new.txt", false, Encoding.UTF8);
Console.WriteLine(fejlec);
foreach (var r in utasszallitok)
{
    sw.WriteLine(
        $"{r.Tipus};" +
        $"{r.Ev};{r.Utas.Max};" +
        $"{r.Szemelyzet.Max};" +
        $"{r.Utazosebesseg};" +
        $"{Math.Round(r.Felszallotomeg / 1000f):0};" +
        $"{Math.Round(r.Fesztav * 3.2808f):0}");
}