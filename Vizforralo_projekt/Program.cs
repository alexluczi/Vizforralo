using System.Net.NetworkInformation;

namespace Vizforralo_projekt;

class Program
{
    static bool status = false;
    static short temperature;

    static void user_temperature()
    {
        Console.WriteLine("\n+-----------------------------------+");
        Console.WriteLine("|Kérem adja meg a víz hőfokát: ");
        Console.WriteLine("+-----------------------------------+");

        Console.SetCursorPosition(("|Kérem adja meg a víz hőfokát: ".Length), 4);
        temperature = 0;
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
    }

    static void always_on()
    {
        Console.Clear();

        //Console.SetCursorPosition((Console.WindowWidth - "Vizforraló".Length) / 2, Console.CursorTop);
        //Console.WriteLine("Vizforraló\n");

        if (status)
        {
            Console.SetCursorPosition((Console.WindowWidth - "Állapot: ON".Length) / 2, Console.CursorTop);
            Console.Write("Állapot: ");
            Console.BackgroundColor = ConsoleColor.Green;
            Console.ForegroundColor = ConsoleColor.White;
            Console.WriteLine("ON");
        }
        else
        {
            Console.SetCursorPosition((Console.WindowWidth - "Állapot: OFF".Length) / 2, 0);
            Console.Write("Állapot: ");
            Console.BackgroundColor = ConsoleColor.Red;
            Console.ForegroundColor = ConsoleColor.White;
            Console.WriteLine("OFF");
        }

        Console.ResetColor();

        Console.SetCursorPosition((Console.WindowWidth - $"Hőmérséklet: {temperature}°C".Length) / 2, Console.CursorTop);
        Console.WriteLine($"Hőmérséklet: {temperature}°C");

    }

    static void Main(string[] args)
    {
        var vizforralo = "Vizforraló";
        var welcome = "Üdvözlünk a vizforraló alkalmazásban!";

        Console.SetCursorPosition((Console.WindowWidth - vizforralo.Length) / 2, Console.CursorTop);
        Console.WriteLine(vizforralo);

        Console.SetCursorPosition((Console.WindowWidth - welcome.Length) / 2, Console.CursorTop);
        Console.WriteLine(welcome);

        user_temperature();
        always_on();

        Console.WriteLine("Nyomjon egy enter-t a bekapcsoláshoz.");

        turn_on:

            var start = Console.ReadKey();

            switch (start.Key)
            {
                case ConsoleKey.Enter:
                    status = true;
                    always_on();
                    break;
                default:
                    Console.WriteLine("\nKérem a megfelelő billentyűket használja!");
                    goto turn_on;
            }
    }
}

