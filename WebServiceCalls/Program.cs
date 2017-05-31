using System;
using System.Threading.Tasks;

namespace WebServiceCalls
{
    public class Program
    {
        public static void Main(string[] args) => Execute().GetAwaiter().GetResult();

        private static async Task Execute()
        {
            var checker = new WebsiteChecker();

            await checker.CallWebsite();

            Console.WriteLine("done");

            Console.ReadLine();
        }
    }
}
