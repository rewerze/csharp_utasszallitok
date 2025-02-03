namespace utasszallitok;

class Utasszallto
{
    public string Tipus { get; set; }
    public int Ev { get; set; }
    public (int? Min, int Max) Utas { get; set; }
    private string UtasStr {  get; set; }
    public (int? Min, int Max) Szemelyzet { get; set; }
    public string SzemStr { get; set; }
    public int Utazosebesseg {  get; set; }
    public int Felszallotomeg {  get; set; }
    public float Fesztav {  get; set; }
    public Sebessegkategoria Sebessegkategoria { get; set; }

    public Utasszallto(string sor)
    {
        var t = sor.Split(';');
        Tipus = t[0];
        Ev = int.Parse(t[1]);

        Utas = KKonvert(t[2]);
        UtasStr = t[2];
        Szemelyzet = KKonvert(t[3]);
        SzemStr = t[3];

        Utazosebesseg = int.Parse(t[4]);
        Felszallotomeg = int.Parse(t[5]);
        Fesztav = float.Parse(t[6]);
        Sebessegkategoria = new(Utazosebesseg);

    }

    private static (int?, int) KKonvert(string str)
    {
        if (str.Contains('-'))
        {
            var t = str.Split('-');
            return (int.Parse(t[0]), int.Parse(t[1]));
        }
        else return (null, int.Parse(str));
    }

    public override string ToString() =>
        $"\tTípus: {Tipus}\n" +
        $"\tElső felszállás: {Ev}\n" +
        $"\tUtasok száma: {UtasStr}\n" +
        $"\tSzemelyzet: {SzemStr} fő\n" +
        $"\tUtazósebesség: {Utazosebesseg} km/h";

}