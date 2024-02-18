namespace TestApp
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.Write("Укажите путь до файла: ");
            string PATH = Console.ReadLine();
            //string PATH = "textfile.txt";

            string RESULTPATH = "result.txt";
            string text = File.ReadAllText(PATH);

            Console.WriteLine($"Текст получен из {PATH}");

            Dictionary<string, int> words = new Dictionary<string, int>();
            char[] wordSeparations = { ' ', '.', ',', ';', ':', '!', '?', '-', '—', '(', ')', '[', ']', '\'', '\"', '\n', '\r'};

            string[] splitText = text.Split(wordSeparations, StringSplitOptions.RemoveEmptyEntries);

            foreach (string word in splitText)
            {
                string clean = word.ToLower();

                if (words.ContainsKey(clean)) { words[clean]++; }
                else { words.Add(clean, 1); }
            }

            var sortedWords = words.OrderByDescending(_ => _.Value);
            
            using (StreamWriter writer = new StreamWriter(RESULTPATH)) 
            {
                foreach (var word in sortedWords)
                {
                    writer.WriteLine($"{word.Key} : {word.Value}");
                    //Console.WriteLine($"{word.Key} : {word.Value}");
                }
            }

            Console.WriteLine($"Готово. Результат записан в {RESULTPATH} \n \nНажмите любую клавишу для выхода." );
            Console.ReadKey();
        }
    }
}
