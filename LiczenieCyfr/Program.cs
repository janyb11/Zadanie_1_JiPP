using System;

class Program
{
    static string[] ones = {
        "", "one", "two", "three", "four", "five", "six", "seven", "eight", "nine"
    };
    // to pole przypisuję słowa do liczb od 1 do 9, bez słowa dla 0 i wpisuję je do szeregu (array) do dalszego użytku
    static string[] teens = {
        "ten", "eleven", "twelve", "thirteen", "fourteen", "fifteen", "sixteen",
        "seventeen", "eighteen", "nineteen"
    };
    // to pole wpisuje słowa do liczb w szyku od 10 do 19, tutaj wartość zerowa może być przypisana ponieważ jest to 10, to będzie również służyć do liczb powyżej 100 jak np 'two hundred and nineteen'
    static string[] tens = {
        "", "", "twenty", "thirty", "forty", "fifty", "sixty", "seventy", "eighty", "ninety"
    };
    // ten szyk wpisuje korespondujące słowa do danych dziesiątek, pierwsze dwa pola są pominięte ponieważ są one opisane w poprzednich szykach, czyli 1-9 i 10-19
    static string ConvertNumberToWords(int number)
    {
        if (number < 10)
            return ones[number];
        //1 do 9 zwraca po prostu to co jest wpisane w arrayu 'ones'
        if (number < 20)
            return teens[number - 10];
        //podobnie od 10-19 zwraca to co jest w arrayu 'teens'
        if (number < 100)
            return tens[number / 10] + " " + ones[number % 10];
        //sprawdzana liczba jest dzielona przez 10, i wartość jest zwracana z arrayu tens[], czyli np. w przypadku 21/10=2, druga pozycja w tens to 'twenty', dalej ta sama liczba jest
        //ponownie dzielona przez 10, lecz tym razem pozostałość (czyli w 21/10=2 i 1/10 czyli reszta to 1) jest wyciągana z arrayu ones[] aby utworzyć np. 'twenty' i 'one'  
        if (number < 1000 && number % 100 != 0)
            return ones[number / 100] + " hundred and " + ConvertNumberToWords(number % 100);
        if (number < 1000 && number % 100 == 0)
            return ones[number / 100] + " hundred";
        //te dwa ify służą do identyfikowania liczb od 100-999, drugi if służy do oddzielania równych 'hundreds' aby nie generowały się wyniki jak np. 'two hundred and' tylko 'two hundred'
        if (number == 1000)
            return "one thousand";
        return "";
    }

    static int CountLetters(string text)
    {
        int count = 0;
        foreach (char c in text)
        {
            if (Char.IsLetter(c))
                count++;
            //wbudowana metoda C# Char.IsLetter pomaga w upewnianiu się że liczone znaki są literami a nie spacjami
        }
        return count;
    }

    static void Main()
    {
        int totalLetters = 0;
        for (int n = 1; n <= 1000; n++)
        {
            string word = ConvertNumberToWords(n);
            Console.WriteLine(word);
            int letters = CountLetters(word);
            totalLetters += letters;
        }
        //for loop sprawdza każdą liczbę od 1 do 1000 przy użyciu zmiennej 'n'. ConvertNumberToWords używa n i zwraca daną cyfrę w formie słownej do zmiennej 'word',
        //która jest potem używana w CountLetters aby zamienić tą cyfrę w słowach na liczbę i wprowadzić ją do zmiennej 'letters', która jest dodawana do finalnej sumy liter.
        Console.WriteLine(totalLetters);
    }
}
