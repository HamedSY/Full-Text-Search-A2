using FullTextSearchA2.Models;
using FullTextSearchA2.Services;

namespace FullTextSearchA2.Controllers;

public class DataReader : IDataReader
{
    public List<Document> ReadData()
    {
        // Read data from the folder "EnglishData" as a list of Documents
        var documents = Directory.EnumerateFiles("EnglishData")
            .Select(doc => new Document(Path.GetFileName(doc), File.ReadAllText(doc).ToUpper()))
            .ToList();

        return documents;
    }
}