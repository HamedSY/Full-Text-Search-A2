using FullTextSearchA2.DIManager;
using FullTextSearchA2.Services;
using Microsoft.Extensions.DependencyInjection;

namespace FullTextSearchA2
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var serviceCollection = new ServiceCollection();
            serviceCollection.SearchingService();
            var provider = serviceCollection.BuildServiceProvider();
            var runner = provider.GetRequiredService<IRunner>();
            runner.Run();
        }
    }
}