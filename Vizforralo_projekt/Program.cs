using System.Net.NetworkInformation;

namespace Vizforralo_projekt;

class Program
{
    static bool status = false; //A "status" az állapotát jelzi, ha false ki van kapcsolva, ha true, akkor meg be
    static short temperature;

    static void user_temperature() //Bekéri a hőfokot a felhasználótól
    {
        Console.WriteLine("\n+-----------------------------------+");
        Console.WriteLine("|Kérem adja meg a víz hőfokát: ");
        Console.WriteLine("+-----------------------------------+");

        while (true)
        {
            try
            {
                Console.SetCursorPosition(("|Kérem adja meg a víz hőfokát: ".Length), 4);

                temperature = Convert.ToInt16(Console.ReadLine());

                if (temperature >= 100)
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine("\n\nHibás értéktípus!");
                    Console.ResetColor();
                    Console.SetCursorPosition(("|Kérem adja meg a víz hőfokát: ".Length), 4);
                    Console.Write(new String(' ', Console.BufferHeight));
                    continue;
                }
            }
            catch (Exception)
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("\n\nHibás értéktípus!");
                Console.ResetColor();
                Console.SetCursorPosition(("|Kérem adja meg a víz hőfokát: ".Length), 4);
                Console.Write(new String(' ', Console.BufferHeight));
                continue;
            }

            break;
        }
    }

    static void always_on() //Mindig látszó felső szöveg (Állapot és Hőfok)
    {
        Console.Clear();

        //Console.SetCursorPosition((Console.WindowWidth - "Vizforraló".Length) / 2, Console.CursorTop);
        //Console.WriteLine("Vizforraló\n");

        if (status) //Ha ki van kapcsolva, akkor:
        {
            Console.SetCursorPosition((Console.WindowWidth - "Állapot: ON".Length) / 2, Console.CursorTop);
            Console.Write("Állapot: ");
            Console.BackgroundColor = ConsoleColor.Green;
            Console.ForegroundColor = ConsoleColor.White;
            Console.WriteLine("ON");
            Console.ResetColor();
        }
        else //Ha nincs kikapcsolva, akkor:
        {
            Console.SetCursorPosition((Console.WindowWidth - "Állapot: OFF".Length) / 2, Console.CursorTop);
            Console.Write("Állapot: ");
            Console.BackgroundColor = ConsoleColor.Red;
            Console.ForegroundColor = ConsoleColor.White;
            Console.WriteLine("OFF");
            Console.ResetColor();
        }

        Console.SetCursorPosition((Console.WindowWidth - $"Hőmérséklet: {temperature}°C".Length) / 2, Console.CursorTop);
        Console.WriteLine($"Hőmérséklet: {temperature}°C");
    }

    static void heating() //Melegítés
    {
        while (true)
        {
            always_on();

            if (temperature < 100)
            {
                temperature += 1;
            }
            else
            {
                status = false;
                always_on();
                break;
            }

            Thread.Sleep(4000); //4 másodperc várakozási idő
        }
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

        while (true)
        {
            var start = Console.ReadKey();

            switch (start.Key)
            {
                case ConsoleKey.Enter:
                    status = true;
                    heating();
                    break;
                default:
                    Console.WriteLine("\nKérem a megfelelő billentyűket használja!");
                    continue;
            }

            break;
        }
    }
}

