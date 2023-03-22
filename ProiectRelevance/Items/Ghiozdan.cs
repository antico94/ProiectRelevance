namespace ProiectRelevance.Items;

public class Ghiozdan
{
    public int NumarArticoleMaxim { get; }
    public float GreutateMaxima { get; }
    public float VolumMaxim { get; }
    private List<ArticolInventar> Continut { get; set; }
    public int NumarArticoleExistente { get; private set; }
    public float GreutateCurenta { get; private set; }
    public float VolumCurent { get; private set; }

    public Ghiozdan(int numarArticoleMaxim, float greutateMaxima, float volumMaxim)
    {
        NumarArticoleMaxim = numarArticoleMaxim;
        GreutateMaxima = greutateMaxima;
        VolumMaxim = volumMaxim;
        NumarArticoleExistente = 0;
        GreutateCurenta = 0f;
        VolumCurent = 0f;
        Continut = new List<ArticolInventar>();
    }

    public bool Adauga(ArticolInventar articol)
    {
        if (NumarArticoleExistente + 1 > NumarArticoleMaxim) return false;
        if (GreutateCurenta + articol.Greutate > GreutateMaxima) return false;
        if (VolumCurent + articol.Volum > VolumMaxim) return false;

        Console.Clear();
        Console.WriteLine($"Adaugat {articol.GetType().Name}");
        Console.ReadKey();

        NumarArticoleExistente += 1;
        GreutateCurenta += articol.Greutate;
        VolumCurent += articol.Volum;
        Continut.Add(articol);

        return true;
    }


    public void VerificaArticole()
    {
        Console.WriteLine($"Numarul curent de articole este: {NumarArticoleExistente}/{NumarArticoleMaxim}");
    }

    public void VerificaGreutate()
    {
        Console.WriteLine($"Greutatea curenta este: {GreutateCurenta}/{GreutateMaxima}");
    }

    public void VerificaVolum()
    {
        Console.WriteLine($"Volumul curent este: {VolumCurent}/{VolumMaxim}");
    }

    public void VerificaContinut()
    {
        Console.WriteLine("Continutul ghiozdanului:");
        var counts = new Dictionary<Type, int>();

        foreach (ArticolInventar articol in Continut)
        {
            if (counts.ContainsKey(articol.GetType()))
            {
                counts[articol.GetType()]++;
            }
            else
            {
                counts.Add(articol.GetType(), 1);
            }
        }

        foreach (var count in counts)
        {
            Console.WriteLine($"- {count.Key.Name}: {count.Value}");
        }
    }
}