namespace ProiectRelevance.Classes;

public class ArticolInventar
{
    public float Greutate { get; set; }
    public float Volum { get; set; }

    public ArticolInventar(float greutate, float volum)
    {
        Greutate = greutate;
        Volum = volum;
    }
}