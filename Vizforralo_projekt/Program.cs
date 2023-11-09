namespace Vizforralo_projekt;

class Program
{
    static void Main(string[] args)
    {
        var vizforralo = "Vizforraló";
        var welcome = "Üdvözlünk a vizforraló alkalmazásban!";

        Console.SetCursorPosition((Console.WindowWidth - vizforralo.Length) / 2, Console.CursorTop);
        Console.WriteLine(vizforralo);

        Console.SetCursorPosition((Console.WindowWidth - welcome.Length) / 2, Console.CursorTop);
        Console.WriteLine(welcome);

        Console.WriteLine("\n+-----------------------------------+");
        Console.WriteLine("|Kérem adja meg a víz hőfokát: ");
        Console.WriteLine("+-----------------------------------+");

        Console.SetCursorPosition(("|Kérem adja meg a víz hőfokát: ".Length), 4);
        short temperature = 0;
        while (true)
        {
            try
            {
                Console.SetCursorPosition(("|Kérem adja meg a víz hőfokát: ".Length), 4);
                temperature = Convert.ToInt16(Console.ReadLine());
                if (temperature > 100)
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine("\nHibás értéktípus!");
                    Console.ResetColor();
                    continue;
                }
            }
            catch (Exception)
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("\nHibás értéktípus!");
                Console.ResetColor();
                Console.SetCursorPosition(("|Kérem adja meg a víz hőfokát: ".Length), 4);
                continue;
            }

            break;
        }

        Console.Clear();

        Console.SetCursorPosition((Console.WindowWidth - $"Hőmérséklet: {temperature}°C".Length) / 2, Console.CursorTop);

        Console.WriteLine($"Hőmérséklet: {temperature}°C");

        Console.WriteLine("Nyomjon egy enter-t a bekapcsoláshoz.");

    turn_on:
        var start = Console.ReadKey();

        switch (start.Key)
        {
            case ConsoleKey.Enter:
                Console.WriteLine("OK");
                break;
            default:
                Console.WriteLine("\nKérem a megfelelő billentyűket használja!");
                goto turn_on;
        }
    }
}

