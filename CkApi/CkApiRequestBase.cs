public abstract class CkApiRequestBase{
    protected string ApiUrl { get; set;} = "https://api.chefkoch.de/v2";
    protected string? Id { get; set;}
    protected string? Subpage { get; set;}
    protected string[] Parameters { get; set; } = [];
    
    public async Task<string> Request(string? url){
        url = url ?? this.constructRequestUrl();

        HttpClient client = new();
        string responseBody = string.Empty;
        bool tryAgain = true;

        while(tryAgain){
            try {
                HttpResponseMessage response = await client.GetAsync(url);
                response.EnsureSuccessStatusCode();
                responseBody = await response.Content.ReadAsStringAsync();
            } catch (Exception e) {
                if (e.Message.Contains("Der angegebene Host ist unbekannt")) {
                    System.Console.WriteLine("Internet connection seems to be faulty. Trying again in 10 seconds.");
                    Thread.Sleep(10000);
                } else {
                    tryAgain = false;
                }
            }
        }

        return responseBody;
    }

    private string constructRequestUrl(){
        string requestUrl = this.ApiUrl;

        if (this.Id != string.Empty) {
            requestUrl += this.Id + this.Subpage;
        }

        //could add validation, but unneccessary parameters dont do anything, so idk
        if (this.Parameters.Length != 0){
            requestUrl += "?";
            foreach (var item in this.Parameters){
                requestUrl += "&" + item;
            }
        }

        return requestUrl;
    }

    public CkApiRequestBase Limit(int limit){
        this.Parameters.Append("limit=" + limit);
        return this;
    }

    public CkApiRequestBase Offset(int offset){
        this.Parameters.Append("offset=" + offset);
        return this;
    }

    public void Printout(){
        System.Console.WriteLine(this.constructRequestUrl());
    }
}