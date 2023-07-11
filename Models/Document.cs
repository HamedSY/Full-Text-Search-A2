namespace FullTextSearchA2.Models;

public class Document
{
    public string Name { get; set; }
    public string Content { get; set; }

    public Document(string name, string content) {
        Name = name;
        Content = content;
    }
}