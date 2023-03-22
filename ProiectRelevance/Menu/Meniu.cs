using ProiectRelevance.Items;

namespace ProiectRelevance.Menu;

public class Meniu
{
    public TipDeMeniu TipMeniu { get; set; }
    public Ghiozdan GhiozdanCurent { get; set; }

    public Meniu(Ghiozdan ghiozdan)
    {
        GhiozdanCurent = ghiozdan;
        TipMeniu = TipDeMeniu.Principal;
    }

    public static void ShowMenu()
    {
        //Add / Check MaxWeight / Check MaxItems / Check MaxVolume / Check Current Contents
        Console.Clear();
        Console.WriteLine("Meniu Principal");
        Console.WriteLine("1. Adauga un articol nou");
        Console.WriteLine("2. Verifica capacitate");
        Console.WriteLine("3. Verifica greutate");
        Console.WriteLine("4. Verifica volum");
        Console.WriteLine("5. Verifica continut");
        Console.WriteLine("0. Iesire");
    }

    public static void ShowItemsMenu()
    {
        Console.WriteLine("Alegeti un articol");
        Console.WriteLine("1. Sageata - Greutate: 0.1; Volum: 0.05");
        Console.WriteLine("2. Arc - Greutate: 1; Volum:  4");
        Console.WriteLine("3. Franghie - Greutate: 1; Volum:  1.5");
        Console.WriteLine("4. Apa - Greutate: 2; Volum:  3");
        Console.WriteLine("5. Portie de mancare - Greutate: 1; volum 0.5");
        Console.WriteLine("6. Sabie - Greutate: 5; Volum:  3\n");
        Console.WriteLine("0. Inapoi");
    }


    public void HandleMainMenu(int userOption)
    {
        switch (userOption)
        {
            case 1:
                TipMeniu = TipDeMeniu.Articole;
                break;

            case 2:
                TipMeniu = TipDeMeniu.Capacitate;
                break;

            case 3:
                TipMeniu = TipDeMeniu.Greutate;
                break;
            case 4:
                TipMeniu = TipDeMeniu.Volum;
                break;
            case 5:
                TipMeniu = TipDeMeniu.Continut;
                break;

            case 0:
                Environment.Exit(0);
                break;


            default:
                Utils.GetValidIntegerFromUser("Alegeti un item:");
                break;
        }
    }


    public void HandleItemsMenu(int userOption)
    {
        var actionAllowed = true;
        switch (userOption)
        {
            case 1:
                actionAllowed = GhiozdanCurent.Adauga(new Sageata());
                break;

            case 2:
                actionAllowed = GhiozdanCurent.Adauga(new Arc());
                break;

            case 3:
                actionAllowed = GhiozdanCurent.Adauga(new Franghie());
                break;

            case 4:
                actionAllowed = GhiozdanCurent.Adauga(new Apa());
                break;

            case 5:
                actionAllowed = GhiozdanCurent.Adauga(new Mancare());
                break;

            case 6:
                actionAllowed = GhiozdanCurent.Adauga(new Sabie());
                break;

            case 0:
                Console.Clear();
                TipMeniu = TipDeMeniu.Principal;
                break;

            default:
                Utils.GetValidIntegerFromUser("Alegeti o optiune valida: ");
                break;
        }

        if (!actionAllowed)
        {
            Console.WriteLine("Ghiozdanul este plin.");
            Console.ReadKey();
        }
    }


    public void Interactioneaza()
    {
        while (true)
        {
            if (TipMeniu == TipDeMeniu.Principal)
            {
                ShowMenu();
                var userInput = Utils.GetValidIntegerFromUser("Selecteaza o optiune: ");
                HandleMainMenu(userInput);
            }

            else if (TipMeniu == TipDeMeniu.Articole)
            {
                Console.Clear();
                ShowItemsMenu();
                var userInput = Utils.GetValidIntegerFromUser("Selecteaza o optiune: ");
                HandleItemsMenu(userInput);
            }
            else if (TipMeniu == TipDeMeniu.Capacitate)
            {
                Console.Clear();
                GhiozdanCurent.VerificaArticole();
                Console.ReadKey();
                TipMeniu = TipDeMeniu.Principal;
            }
            else if (TipMeniu == TipDeMeniu.Greutate)
            {
                Console.Clear();

                GhiozdanCurent.VerificaGreutate();
                Console.ReadKey();
                TipMeniu = TipDeMeniu.Principal;
            }
            else if (TipMeniu == TipDeMeniu.Volum)
            {
                Console.Clear();
                GhiozdanCurent.VerificaVolum();
                Console.ReadKey();
                TipMeniu = TipDeMeniu.Principal;
            }
            else if (TipMeniu == TipDeMeniu.Continut)
            {
                Console.Clear();
                GhiozdanCurent.VerificaContinut();
                Console.ReadKey();
                TipMeniu = TipDeMeniu.Principal;
            }
        }
    }
}