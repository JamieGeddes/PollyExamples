namespace WebServiceCalls
{
    using Polly;
    using System;
    using System.Net.Http;
    using System.Threading.Tasks;

    public class WebsiteChecker
    {
        public async Task CallWebsite()
        {
            var policy = Policy.Handle<HttpRequestException>().RetryAsync(3);

            try
            {
                await policy.ExecuteAsync(CheckWebsite);
            }
            catch(HttpRequestException)
            {
                Console.WriteLine("Exceeded maximum number of retries, operation failed");
            }
        }

        private async Task CheckWebsite()
        { 
            Console.WriteLine("calling unreachable site...");

            using (var client = new HttpClient())
            {
                const string uri = "https://unreachable.example.com";

                var response = await client.GetAsync(uri);

                Console.WriteLine($"response: {response.StatusCode}");
            }
        }
    }
}
