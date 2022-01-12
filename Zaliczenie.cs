using System;
using System.IO;
using System.Text;
namespace Calculator.ConsoleApp
{
    class Program// tworzymy klasę
    {
        static void Main(string[] args) // zaczynamy wprowadzanie zmiennych
        {
            Console.WriteLine("Witaj w aplikacji KALKULATOR!"); // wyświetlenie nazwy programu
            StreamWriter sw = new StreamWriter("wynik.txt", true, Encoding.UTF8); // ścieżka do utworzenia pliku tekstowego

            while (true)// tworzenie pętli
            {

                try
                {
                    Console.WriteLine("Daniel Gajewski 1 rok informatyka"); // komunikat z imieniem i nazwiskiem.
                    Console.WriteLine("Podaj proszę 1 liczbę:"); // pierwsza zmienna
                    var number1 = GetInput();

                    Console.WriteLine("Jaką operację chcesz wykonać? Możliwe operacje to: '+', '-', '*', '/'."); // wybór danego działania.
                    var operation = Console.ReadLine();

                    Console.WriteLine("Podaj proszę 2 liczbę:");// druga zmienna
                    var number2 = GetInput();

                    var result = Calculate(number1, number2, operation); // wynik działania.

                    Console.WriteLine($"Wynik Twojego działania to: {Math.Round(result, 2)}.\n"); // wyświetlanie wyniku działanie
                    sw.WriteLine($"Wynik Twojego działania to: {Math.Round(result, 2)}.\n");// plik tekstowy będzie zawierał zawartośc naszego komunikatu o wyniku działania.
                    sw.Close();// zamknięcie pliku teskstowego.
                    
                    
                }
                catch (Exception ex)
                {
                    //logowanie do pliku
                    Console.WriteLine(ex.Message);
                    
                }
            }
        }

        private static double GetInput()
        {
            if (!double.TryParse(Console.ReadLine(), out double input)) // wprowadzanie warunku w przypadku wprowadzenie zmiennej, która nie jest liczbą.
                throw new Exception("Podana wartość nie jest liczbą.\n");// komunikat po wprowadzeniu niewłaściwej zmiennej.

            return input;

        }

        private static double Calculate(double number1, double number2, string operation) // wgląd na działanie.
        {
            switch (operation) // tworzymy switch case do naszych operacji na liczbach.
            {
                case "+":
                    return number1 + number2;// dodawanie
                case "-":
                    return number1 - number2;// odejmowanie
                case "*":
                    return number1 * number2;// mnożenie
                case "/":
                    return number1 / number2;// dzielenie.
                default:
                    throw new Exception("Wybrałeś złą operację!\n");// komunikat po wprowadzeniu złej operacji.

            }
        }
    }
}