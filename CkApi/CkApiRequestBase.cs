public abstract class CkApiRequestBase{
    public string RequestUrl { get; set;} = "https://api.chefkoch.de/v2";

    public async Task<string> Request(string? url){
        url = url ?? this.RequestUrl;

        HttpClient client = new();
        //TODO: add connection validation
        HttpResponseMessage response = await client.GetAsync(url);
        //response.EnsureSuccessStatusCode();
        string responseBody = await response.Content.ReadAsStringAsync();

        return responseBody;
    }

    public CkApiRequestBase Limit(int limit){
        this.RequestUrl += "&limit=" + limit;
        return this;
    }

    public CkApiRequestBase Offset(int offset){
        this.RequestUrl += "&offset=" + offset;
        return this;
    }

    public void Printout(){
        System.Console.WriteLine(this.RequestUrl);
    }
}