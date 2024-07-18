using System;

namespace ChefkochScraper
{
    class Program
    {
        public static async Task Main(string[] args)
        {
            CkApiRequest ckApi = new();
            System.Console.Write(await ckApi.Request("https://api.chefkoch.de/v2/recipes?offset=1&limit=100"));
        }
    }
}
