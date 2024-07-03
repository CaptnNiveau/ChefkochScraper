public class CkApiRequest{
    public string RequestUrl { get; set;} = "https://api.chefkoch.de/v2/";
 
    public async Task<string> Request(string url){
        HttpClient client = new();
        HttpResponseMessage response = await client.GetAsync(url);
        //response.EnsureSuccessStatusCode();
        string responseBody = await response.Content.ReadAsStringAsync();

        return responseBody;
    }
}