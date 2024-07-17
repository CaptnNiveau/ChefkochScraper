using System;

namespace ChefkochScraper{
    class Program{
        public static async Task Main(string[] args){
            CkApiRecipeRequest ckApi = new(null);
            
            ckApi
                .Offset(0)
                .Limit(3)
                .Printout();
            System.Console.Write(await ckApi.Request(null));
        }
    }
}
