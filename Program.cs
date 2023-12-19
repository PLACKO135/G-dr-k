List<int> melyseg_lista = new();

using(StreamReader r = new("melyseg.txt"))
{
    while (!r.EndOfStream) {
        melyseg_lista.Add(int.Parse(r.ReadLine()));
    }
}

//1

Console.WriteLine($"1. feladat\n A fájl adatainak száma: {melyseg_lista.Count}");

//2

Console.Write("2. feladat\n Adjon meg egy távolságértéket! ");
int megadott_tav = int.Parse(Console.ReadLine());
Console.WriteLine($"Ezen a megadott_taven a felszín {melyseg_lista[megadott_tav - 1]} méter mélyen van.");

//3

int érintetlen = melyseg_lista.Count(mért => mért == 0);
Console.WriteLine($"3. feladat\n Az érintetlen terület aránya {100.0 * érintetlen / melyseg_lista.Count:0.00}%.");

//4

List<string> sor1 = new List<string>();
List<List<string>> sorok = new List<List<string>>();

using (StreamWriter kimenet = new StreamWriter("godrok.txt"))
{
    int előző = 0;


    foreach (int érték in melyseg_lista)
    {
        if (érték > 0)
        {
            sor1.Add(érték.ToString());
        }

        if (érték == 0 && előző > 0)
        {
            sorok.Add(new List<string>(sor1));
            sor1.Clear();
        }

        előző = érték;
    }

    foreach (List<string> sor1Lista in sorok)
    {
        kimenet.WriteLine(string.Join(" ", sor1Lista));
    }
}

//5

Console.WriteLine($"5. feladat\n A gödrök száma: {sorok.Count}");

//6

Console.WriteLine("6. feladat");
if (melyseg_lista[megadott_tav - 1] > 0)
{
    Console.WriteLine("a)");
    int pozicio = megadott_tav - 1;
    while (melyseg_lista[pozicio] > 0)
    {
        pozicio--;
    }
    int kezdo = pozicio + 2;
    pozicio = megadott_tav;
    while (melyseg_lista[pozicio] > 0)
    {
        pozicio++;
    }
    int záró = pozicio;
    Console.WriteLine($"A gödör kezdete: {kezdo} méter, a gödör vége: {záró} méter.");

    Console.WriteLine("b)");
    int mélypont = 0;
    pozicio = kezdo;
    while (melyseg_lista[pozicio] >= melyseg_lista[pozicio - 1] && pozicio <= záró)
    {
        pozicio++;
    }
    while (melyseg_lista[pozicio] <= melyseg_lista[pozicio - 1] && pozicio <= záró)
    {
        pozicio++;
    }
    if (pozicio > záró)
    {
        Console.WriteLine("Folyamatosan mélyül.");
    }
    else
    {
        Console.WriteLine("Nem mélyül folyamatosan.");
    }

    Console.WriteLine("c)");
    Console.WriteLine($"A legnagyobb mélysége {melyseg_lista.GetRange(kezdo - 1, záró - kezdo + 1).Max()} méter.");

    Console.WriteLine("d)");
    double térfogat = 10 * melyseg_lista.GetRange(kezdo - 1, záró - kezdo + 1).Sum();
    Console.WriteLine($"A térfogata {térfogat} m^3.");

    Console.WriteLine("e)");
    double biztonságos = térfogat - 10 * (záró - kezdo + 1);
    Console.WriteLine($"A vízmennyiség {biztonságos} m^3.");
}
else
{
    Console.WriteLine("Az megadott helyen nincs gödör.");
}