namespace ProiectRelevance.Classes;

public class Ghiozdan
{
    public int NumarArticoleMaxim { get; set; }
    public float GreutateMaxima { get; set; }
    public float VolumMaxim { get; set; }
    public List<ArticolInventar> Continut { get; set; }
    public int NumarArticoleExistente { get; set; }
    public float GreutateCurenta { get; set; }
    public float VolumCurent { get; set; }

    public Ghiozdan(int numarArticoleMaxim, float greutateMaxima, float volumMaxim)
    {
        NumarArticoleMaxim = numarArticoleMaxim;
        GreutateMaxima = GreutateMaxima;
        VolumMaxim = VolumMaxim;
        NumarArticoleExistente = 0;
        GreutateCurenta = 0f;
        VolumCurent = 0f;
        Continut = new List<ArticolInventar>();
    }
    
    
}