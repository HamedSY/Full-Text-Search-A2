namespace FullTextSearchA2.Services;

public interface IPrinter
{
    public void PrintFoundDocuments(HashSet<string> foundDocsNames);
}