namespace FullTextSearch
{
    public class Document
    {
        public int Number { get; set; }
        public string Content { get; set; }

        public Document(int number, string content) {
            Number = number;
            Content = content;
        }
    }
    
    public class Program
    {
        private static readonly char[] delimeterChars = new char[] {' ', ',', '=', '-', '|', '>', '<', '(', ')', '?', '!', '.', '@', '/', '_', '\\', ':', '\"', '*'};

        public static HashSet<int> CreateInvertedIndex(Dictionary<string, HashSet<int>> invertedIndex)
        {
            HashSet<int> documentsNumber = new();
            foreach (string file in Directory.EnumerateFiles("EnglishData"))
            {
                var upperedFileText = File.ReadAllText(file).ToUpper();
                Document document = new Document(int.Parse(Path.GetFileName(file)), upperedFileText);
                documentsNumber.Add(document.Number);
                var splitedDocument = upperedFileText.Split(delimeterChars);
                    foreach (var word in splitedDocument)
                    {
                        if (!invertedIndex.ContainsKey(word))
                            invertedIndex[word] = new HashSet<int>();
                        else
                            invertedIndex[word].Add(document.Number);
                    }
            }
            return documentsNumber;
        }

        public static HashSet<int> FindWord(List<string> input, Dictionary<string, HashSet<int>> invertedIndex, HashSet<int> documentsNumber)
        {
            HashSet<int> necessaryWordsDocsNumbers = new(documentsNumber);
            HashSet<int> atLeastOneDocsNumbers = new();
            HashSet<int> mustNotBeDocsNumbers = new();
            foreach(string word in input)
            {
                // At least one of these words should be in the documents
                if(word.StartsWith("+"))
                    atLeastOneDocsNumbers.UnionWith(invertedIndex[word[1..]]);

                // These words must not be in the document
                else if (word.StartsWith("-"))
                    mustNotBeDocsNumbers.UnionWith(invertedIndex[word[1..]]);
 
                // These words should be in the documents
                else
                    necessaryWordsDocsNumbers.IntersectWith(invertedIndex[word]);
            }
            
            var foundDocsNumbers = new HashSet<int>(necessaryWordsDocsNumbers);
            if(atLeastOneDocsNumbers.Any())
                foundDocsNumbers.IntersectWith(atLeastOneDocsNumbers);
            foundDocsNumbers.ExceptWith(mustNotBeDocsNumbers);
            return foundDocsNumbers;
        }
        
        public static void Main(string[] args)
        {
            var invertedIndex = new Dictionary<string, HashSet<int>>();
            
            var documentsNumber = CreateInvertedIndex(invertedIndex);
            
            var input = Console.ReadLine().ToUpper().Split(' ').ToList();

            var foundDocsNumbers = FindWord(input, invertedIndex, documentsNumber);

            foreach(var num in foundDocsNumbers)
                Console.WriteLine(num);
        }
    }
}