using FullTextSearchA2.Services;

namespace FullTextSearchA2.Views;

public class Printer : IPrinter
{
    public void PrintFoundDocuments(HashSet<string> foundDocsNames)
    {
        foreach(var num in foundDocsNames)
            Console.WriteLine(num);
    }
}