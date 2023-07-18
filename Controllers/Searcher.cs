using FullTextSearchA2.Models;
using FullTextSearchA2.Services;

namespace FullTextSearchA2.Controllers;

public class Searcher : ISearcher
{
    public SearchResult SearchResult { set; get; }
    public HashSet<string> DocumentNames { set; get; }

    private void HandleEachInput(string word, Dictionary<string, HashSet<string>> invertedIndex,
        SearchResult searchResult)
    {
        // At least one of these words should be in the documents
        if (word.StartsWith("+"))
            searchResult.AtLeastOneDocsNumbers.UnionWith(invertedIndex[word[1..]]);

        // These words must not be in the document
        else if (word.StartsWith("-"))
            searchResult.MustNotBeDocsNumbers.UnionWith(invertedIndex[word[1..]]);

        // These words should be in the documents
        else
            searchResult.NecessaryWordsDocsNumbers.IntersectWith(invertedIndex[word]);
    }

    private HashSet<string> CalculateFoundDocsNumbers(SearchResult searchResult)
    {
        var foundDocsNumbers = new HashSet<string>(searchResult.NecessaryWordsDocsNumbers);
        if (searchResult.AtLeastOneDocsNumbers.Any())
            foundDocsNumbers.IntersectWith(searchResult.AtLeastOneDocsNumbers);
        foundDocsNumbers.ExceptWith(searchResult.MustNotBeDocsNumbers);
        return foundDocsNumbers;
    }

    public HashSet<string> FindWord(List<string> input, Dictionary<string, HashSet<string>> invertedIndex)
    {
        foreach (var word in input)
            HandleEachInput(word, invertedIndex, SearchResult);

        return CalculateFoundDocsNumbers(SearchResult);
    }
}