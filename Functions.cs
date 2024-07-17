namespace ChefkochScraper;

public class Functions{

    /// <summary>
    /// Testfunktion, Werte für orderBy durchprobiert und deren Outputs mit dem Output ohne Parameter vergleich.
    /// </summary>
    public async void testOrderBy(){
        CkApiRecipeRequest ckApi = new(null);
        
        int[] test = [];
        string baseline = await ckApi.Request(null);
        Console.WriteLine($"Starting test");

        for (int i = 0; i < 100; i++){
            ckApi.ClearParameters();
            if (await ckApi.AddCustomParameters([$"OrderBy={i}"]).Request(null) != baseline){
                test.Append(i);
                Console.WriteLine($"Found {i}");
            } else {
                Console.WriteLine($"Tried {i}");
            }
            ckApi.Printout();
        }

        System.Console.WriteLine(test);
    }
}