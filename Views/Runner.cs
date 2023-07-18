using FullTextSearchA2.Models;
using FullTextSearchA2.Services;

namespace FullTextSearchA2.Views;

public class Runner : IRunner
{
    private IDataReader _dataReader;
    private IInvertedIndexCreator _invertedIndexCreator;
    private ISearcher _searcher;
    private IPrinter _printer;

    public Runner(IDataReader dataReader, IInvertedIndexCreator invertedIndexCreator, ISearcher searcher, IPrinter printer)
    {
        _dataReader = dataReader;
        _invertedIndexCreator = invertedIndexCreator;
        _searcher = searcher;
        _printer = printer;
    }

    public void Run()
    {
        var documents = _dataReader.ReadData();
        var invertedIndex = _invertedIndexCreator.CreateInvertedIndex(documents);
        var documentNames = _invertedIndexCreator.CreateListOfDocNames(documents);
        _searcher.DocumentNames = documentNames;
        _searcher.SearchResult = new SearchResult(documentNames);
        var input = Console.ReadLine()?.ToUpper().Split(' ').ToList();
        var foundDocsNumbers = _searcher.FindWord(input, invertedIndex);
        _printer.PrintFoundDocuments(foundDocsNumbers);
    }
}