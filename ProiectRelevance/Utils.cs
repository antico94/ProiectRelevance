namespace ProiectRelevance;

public static class Utils
{
    public static bool CheckValidInteger(string input)
    {
        int number;
        bool isInteger = int.TryParse(input, out number);
        return isInteger;
    }
    
    public static bool CheckValidFloat(string input)
    {
        float number;
        bool isFloat = float.TryParse(input, out number);
        return isFloat;
    }

    public static int GetValidIntegerFromUser(string message)
    {
        int number = 0;
        bool isValidInteger = false;

        do
        {
            Console.Write(message);
            string input = Console.ReadLine();
            isValidInteger = CheckValidInteger(input);

            if (isValidInteger)
            {
                number = int.Parse(input);
            }
            else
            {
                Console.WriteLine("Inputul este invalid, te rugam sa introduceti in input tip integer.");
            }
        } while (!isValidInteger);

        return number;
    }


    public static float GetValidFloatFromUser(string message)
    {
        float number = 0.0f;
        bool isValidFloat = false;

        do
        {
            Console.Write(message);
            string input = Console.ReadLine();
            isValidFloat = CheckValidFloat(input);

            if (isValidFloat)
            {
                number = float.Parse(input);
            }
            else
            {
                Console.WriteLine("Inputul este invalid, te rugam sa introduceti in input tip float.");
            }
        } while (!isValidFloat);

        return number;
    }
    

}