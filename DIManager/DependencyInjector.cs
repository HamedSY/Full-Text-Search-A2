using FullTextSearchA2.Controllers;
using FullTextSearchA2.Models;
using FullTextSearchA2.Services;
using FullTextSearchA2.Views;
using Microsoft.Extensions.DependencyInjection;

namespace FullTextSearchA2.DIManager;

public static class DependencyInjector
{
    public static void SearchingService(this IServiceCollection serviceCollection)
    {
        serviceCollection.AddSingleton<IDataReader, DataReader>();
        serviceCollection.AddSingleton<IInvertedIndexCreator, InvertedIndexCreator>();
        serviceCollection.AddSingleton<IPrinter, Printer>();
        serviceCollection.AddSingleton<ISearcher, Searcher>();
        serviceCollection.AddSingleton<IRunner, Runner>();
    }
}