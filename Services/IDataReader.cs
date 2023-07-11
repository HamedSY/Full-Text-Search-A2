using FullTextSearchA2.Models;

namespace FullTextSearchA2.Services;

public interface IDataReader
{
    public List<Document> ReadData();
}