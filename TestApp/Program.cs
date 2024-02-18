namespace TestApp
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string PATH = "textfile.txt";
            string RESULTPATH = "result.txt";
            string text = File.ReadAllText(PATH);


            Dictionary<string, int> words = new Dictionary<string, int>();
            char[] wordSeparations = { ' ', '.', ',', ';', ':', '!', '?', '-', '—', '(', ')', '[', ']', '\'', '\"', '\n'};

            string[] splitText = text.Split(wordSeparations, StringSplitOptions.RemoveEmptyEntries);

            foreach (string word in splitText)
            {
                string clean = word.ToLower();

                if (words.ContainsKey(clean)) { words[clean]++; }
                else { words.Add(clean, 1); }
            }

            var sortedWords = words.OrderByDescending(word => word.Value);

            using (StreamWriter writer = new StreamWriter(RESULTPATH)) 
            {
                foreach (var word in sortedWords)
                {
                    writer.WriteLine($"{word.Key} : {word.Value}");
                }
            }

            Console.WriteLine("Готово");
        }
    }
}
