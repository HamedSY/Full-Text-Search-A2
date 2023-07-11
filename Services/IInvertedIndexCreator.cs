using FullTextSearchA2.Models;

namespace FullTextSearchA2.Services;

public interface IInvertedIndexCreator
{
    public Dictionary<string, HashSet<string>> CreateInvertedIndex(List<Document> documents);
    public HashSet<string> CreateListOfDocNames(List<Document> documents);
}