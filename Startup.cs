using System;
using Microsoft.EntityFrameworkCore;

namespace ChefkochScraper{
    class Program{
        public static async Task Main(string[] args){
            CkApiUserRequest ckApi = new("592547d097443354dd8cc30086b470cc");

            var test = await ckApi.GetRecipeIds();

            Console.Write(test);
        }
    }
}
