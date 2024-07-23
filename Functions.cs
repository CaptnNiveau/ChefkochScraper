namespace ChefkochScraper;

public static class Functions{

    /// <summary>
    /// Testfunktion, Werte für orderBy durchprobiert und deren Outputs mit dem Output ohne Parameter vergleich.
    /// </summary>
    public static async void testOrderBy(){
        CkApiRecipeRequest ckApi = new();
        
        int[] test = [];
        string baseline = await ckApi.Request();
        Console.WriteLine($"Starting test");

        for (int i = 0; i < 100; i++){
            ckApi.ClearParameters();
            if (await ckApi.AddCustomParameters([$"OrderBy={i}"]).Request() != baseline){
                test.Append(i);
                Console.WriteLine($"Found {i}");
            } else {
                Console.WriteLine($"Tried {i}");
            }
            ckApi.Printout();
        }

        System.Console.WriteLine(test);
    }

    public static async void testrun(){
        CkApiRecipeRequest ckApi = new("820481186558221");
        string input = await ckApi.Request();

        RecipeModel test = JsonParser.ReadJson(input);

        ChefkochContext appDb = new ChefkochContext();
        appDb.Add(test);
        appDb.SaveChanges();

        var owner = appDb.Recipes
            .First()
            .owner;

        Console.Write(owner.username);
    }
}