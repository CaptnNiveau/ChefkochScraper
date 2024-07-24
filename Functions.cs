namespace ChefkochScraper;

public class Functions
{

    /// <summary>
    /// Testfunktion, Werte für orderBy durchprobiert und deren Outputs mit dem Output ohne Parameter vergleich.
    /// </summary>
    /// 

    private static List<string> scrapedUserIds;
    private static List<string> unscrapedUserIds;
    private static List<string> scrapedRecipeIds;
    private static List<string> unscrapedRecipeIds;
    private static ChefkochContext appDb;
    bool scrapeRecipes;


    public static async void testOrderBy()
    {
        CkApiRecipeRequest ckApi = new();

        int[] test = [];
        string baseline = await ckApi.Request();
        Console.WriteLine($"Starting test");

        for (int i = 0; i < 100; i++)
        {
            ckApi.ClearParameters();
            if (await ckApi.AddCustomParameters([$"OrderBy={i}"]).Request() != baseline)
            {
                test.Append(i);
                Console.WriteLine($"Found {i}");
            }
            else
            {
                Console.WriteLine($"Tried {i}");
            }
            ckApi.Printout();
        }

        System.Console.WriteLine(test);
    }

    public async Task testrun()
    {
        FastBot bots = new();
        await bots.Startup();
    }


}