using FullTextSearchA2.Models;

namespace FullTextSearchA2.Services;

public interface ISearcher
{
    public HashSet<string> FindWord(List<string> input, Dictionary<string, HashSet<string>> invertedIndex);
    public SearchResult SearchResult { set; get; }
    public HashSet<string> DocumentNames { set; get; }
}