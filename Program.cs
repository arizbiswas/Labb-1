using System;

class Program
{
    static void Main()
    {
        // ======= Välkomstmeddelande =======
        Console.WriteLine("*********************************");
        Console.WriteLine(" Välkommen till FlightTime Calculator!");
        Console.WriteLine(" Här kan du beräkna ankomsttiden för din flygning.");
        Console.WriteLine("*********************************");

        // ======= Deklaration av variabler =======
        // Flygtid i timmar och minuter
        int flightHours = 7;
        int flightMinutes = 25;

        // Tidskillnad mellan New York och Stockholm i timmar
        int timeDifference = 6;

        // Avgångstid från New York (timme och minut)
        int nyDepartureHour = 10;
        int nyDepartureMinute = 10;

        // Avgångstid från Stockholm (timme och minut)
        int stockholmDepartureHour = 14;
        int stockholmDepartureMinute = 3;

        // ======= While-loop som fortsätter tills användaren väljer att avsluta =======
        bool isRunning = true; // Kontrollerar om programmet ska fortsätta

        while (isRunning)
        {
            // ======= Visa meny och be användaren göra ett val =======
            Console.WriteLine();
            Console.WriteLine("*********************************");
            Console.WriteLine(" Välj en flygning eller avsluta programmet:");
            Console.WriteLine(" 1. New York -> Stockholm");
            Console.WriteLine(" 2. Stockholm -> New York");
            Console.WriteLine(" 3. Avsluta programmet");
            Console.Write(" Ditt val: ");

            // Läser in användarens val
            string? userInput = Console.ReadLine();
            Console.WriteLine("*********************************");

            // Variabler för att lagra ankomsttid
            int arrivalHour, arrivalMinute;

            // ======= Hantering av användarens val =======
            if (userInput == "1")
            {
                // ======= Beräkning för flygning från New York till Stockholm =======
                arrivalHour = nyDepartureHour + flightHours + timeDifference;
                arrivalMinute = nyDepartureMinute + flightMinutes;

                // Justera tid om minuter överstiger 60
                if (arrivalMinute >= 60)
                {
                    arrivalHour += 1;
                    arrivalMinute -= 60;
                }

                // Se till att timmar inte överstiger 24 (24-timmarsformat)
                // Modulo-operatorn (%) används för att tiden ska "rulla runt" om den blir 24 eller mer
                arrivalHour %= 24;

                // Skriv ut resultat
                Console.WriteLine(" Flyginformation:");
                Console.WriteLine(" Avgång: 10:10 (New York)");
                Console.WriteLine($" Ankomst: {arrivalHour.ToString("00")}:{arrivalMinute.ToString("00")} (Stockholm)");
            }
            else if (userInput == "2")
            {
                // ======= Beräkning för flygning från Stockholm till New York =======
                arrivalHour = stockholmDepartureHour + flightHours - timeDifference;
                arrivalMinute = stockholmDepartureMinute + flightMinutes;

                // Justera tid om minuter överstiger 60
                if (arrivalMinute >= 60)
                {
                    arrivalHour += 1;
                    arrivalMinute -= 60;
                }

                // Hantera negativ tid och se till att timmar är inom 0-23
                arrivalHour = (arrivalHour + 24) % 24;

                // Skriv ut resultat
                Console.WriteLine(" Flyginformation:");
                Console.WriteLine(" Avgång: 14:03 (Stockholm)");
                Console.WriteLine($" Ankomst: {arrivalHour.ToString("00")}:{arrivalMinute.ToString("00")} (New York)");
            }
            else if (userInput == "3")
            {
                // ======= Användaren har valt att avsluta programmet =======
                Console.WriteLine(" Du har valt att avsluta programmet. Tack för att du använde FlightTime Calculator!");
                isRunning = false; // Avslutar loopen
            }
            else
            {
                // ======= Ogiltigt val =======
                Console.WriteLine(" Ogiltigt val! Vänligen välj alternativ 1, 2 eller 3.");
            }
        }

        // ======= Avslutningsmeddelande =======
        Console.WriteLine("*********************************");
        Console.WriteLine(" Programmet är nu avslutat.");
    }
}
