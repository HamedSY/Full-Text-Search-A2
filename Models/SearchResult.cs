using FullTextSearchA2.Services;

namespace FullTextSearchA2.Models;

public class SearchResult
{
    public HashSet<string> NecessaryWordsDocsNumbers { set; get; }
    public HashSet<string> AtLeastOneDocsNumbers { set; get; }
    public HashSet<string> MustNotBeDocsNumbers { set; get; }

    public SearchResult(HashSet<string> documentNames)
    {
        NecessaryWordsDocsNumbers = new HashSet<string>(documentNames);
        AtLeastOneDocsNumbers = new HashSet<string>();
        MustNotBeDocsNumbers = new HashSet<string>();
    }
}