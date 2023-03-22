using ProiectRelevance.Items;

namespace ProiectRelevance.Menu
{
    public class Meniu
    {
        private TipDeMeniu TipMeniu { get; set; }
        private Ghiozdan GhiozdanCurent { get; }

        public Meniu(Ghiozdan ghiozdan)
        {
            GhiozdanCurent = ghiozdan;
            TipMeniu = TipDeMeniu.Principal;
        }

        private static void ShowMenu()
        {
            Console.Clear();
            Console.WriteLine("Meniu Principal");
            Console.WriteLine($"{1}. Adauga un articol nou");
            Console.WriteLine($"{2}. Verifica capacitate");
            Console.WriteLine($"{3}. Verifica greutate");
            Console.WriteLine($"{4}. Verifica volum");
            Console.WriteLine($"{5}. Verifica continut");
            Console.WriteLine($"{0}. Iesire");
        }

        private static void ShowItemsMenu()
        {
            Console.WriteLine("Alegeti un articol");
            Console.WriteLine($"{1}. Sageata - Greutate: 0.1; Volum: 0.05");
            Console.WriteLine($"{2}. Arc - Greutate: 1; Volum:  4");
            Console.WriteLine($"{3}. Franghie - Greutate: 1; Volum:  1.5");
            Console.WriteLine($"{4}. Apa - Greutate: 2; Volum:  3");
            Console.WriteLine($"{5}. Portie de mancare - Greutate: 1; volum 0.5");
            Console.WriteLine($"{6}. Sabie - Greutate: 5; Volum:  3\n");
            Console.WriteLine($"{0}. Inapoi");
        }

        public void HandleMainMenu(int userOption)
        {
            Dictionary<int, Action> mainMenuActions = new Dictionary<int, Action>
            {
                { 1, () =>
                {
                    TipMeniu = TipDeMeniu.Articole;
                    Console.Clear();
                } },
                { 2, () => TipMeniu = TipDeMeniu.Capacitate },
                { 3, () => TipMeniu = TipDeMeniu.Greutate },
                { 4, () => TipMeniu = TipDeMeniu.Volum },
                { 5, () => TipMeniu = TipDeMeniu.Continut },
                { 0, () => Environment.Exit(0) }
            };

            while (!mainMenuActions.ContainsKey(userOption))
            {
                userOption = Utils.GetValidIntegerFromUser("Alegeti o optiune valida: ");
            }

            mainMenuActions[userOption]();
        }


        private void HandleItemsMenu(int userOption)
        {
            try
            {
                if (userOption == 0)
                {
                    TipMeniu = TipDeMeniu.Principal;
                    return;
                }

                bool isAdded = GhiozdanCurent.Adauga(CreateItem(userOption));
                Console.Clear();

                if (isAdded)
                {
                    Console.ForegroundColor = ConsoleColor.Green;
                    Console.WriteLine("Articol adaugat cu succes.");
                    Console.ResetColor();
                }
                else
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine("Articolul nu a putut fi introdus.");
                    Console.ResetColor();
                }
            }
            catch (ArgumentException ex)
            {
                Console.Clear();
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine(ex.Message);
                Console.WriteLine("Va rugam sa introduceti o optiune valida.");
                Console.ResetColor();
            }
        }




        private ArticolInventar CreateItem(int userOption)
        {
            switch (userOption)
            {
                case 1:
                    return new Sageata();

                case 2:
                    return new Arc();

                case 3:
                    return new Franghie();

                case 4:
                    return new Apa();

                case 5:
                    return new Mancare();

                case 6:
                    return new Sabie();

                default:
                    throw new ArgumentException("Optiunea introdusa nu exista.");
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
                    ShowItemsMenu();
                    var userInput = Utils.GetValidIntegerFromUser("Selecteaza o optiune: ");
                    HandleItemsMenu(userInput);
                }
                else if (TipMeniu == TipDeMeniu.Capacitate)
                {
                    Console.Clear();
                    GhiozdanCurent.VerificaArticole();
                    Utils.AwaitUserInput();
                    TipMeniu = TipDeMeniu.Principal;
                }
                else if (TipMeniu == TipDeMeniu.Greutate)
                {
                    Console.Clear();
                    GhiozdanCurent.VerificaGreutate();
                    Utils.AwaitUserInput();
                    TipMeniu = TipDeMeniu.Principal;
                }
                else if (TipMeniu == TipDeMeniu.Volum)
                {
                    Console.Clear();
                    GhiozdanCurent.VerificaVolum();
                    Utils.AwaitUserInput();
                    TipMeniu = TipDeMeniu.Principal;
                }
                else if (TipMeniu == TipDeMeniu.Continut)
                {
                    Console.Clear();
                    GhiozdanCurent.VerificaContinut();
                    Utils.AwaitUserInput();
                    TipMeniu = TipDeMeniu.Principal;
                }
            }
        }
    }
}
