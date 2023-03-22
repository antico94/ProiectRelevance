namespace ProiectRelevance.Classes;

public class Ghiozdan
{
    public int NumarArticoleMaxim { get; }
    public float GreutateMaxima { get;}
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
        if (VolumMaxim + articol.Volum > VolumMaxim) return false;

        NumarArticoleExistente += 1;
        GreutateCurenta += articol.Greutate;
        VolumCurent += articol.Volum;
        Continut.Add(articol);

        return true;
    }
}