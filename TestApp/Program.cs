namespace TestApp
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Введите текст" );
            string? text = Console.ReadLine();


            Dictionary<string, int> words = new Dictionary<string, int>();
            char[] wordSeparations = { ' ', '.', ',', ';', ':', '!', '?', '-', '—', '\'', '\"' };

            string[] splitText = text.Split(wordSeparations, StringSplitOptions.RemoveEmptyEntries);

            foreach (string word in splitText)
            {
                string clean = word.ToLower();

                if (words.ContainsKey(clean)) { words[clean]++; }
                else { words.Add(clean, 1); }
            }

            var sorted_words = words.OrderByDescending(word => word.Value);

            Console.WriteLine("Уникальные слова:");
            foreach (var word in sorted_words)
            {
                Console.WriteLine($"{word.Key} : {word.Value}");
            }


        }
    }
}
