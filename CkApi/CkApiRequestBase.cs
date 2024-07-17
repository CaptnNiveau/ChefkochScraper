public abstract class CkApiRequestBase{
    protected string ApiUrl { get; set;} = "https://api.chefkoch.de/v2";
    protected string? Id { get; set;}
    protected string? Subpage { get; set;}
    protected List<string> Parameters { get; set; } = [];
    
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
                tryAgain = false;
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

        if (this.Id != null) {
            requestUrl += this.Id + this.Subpage;
        }

        //could add validation, but unneccessary parameters dont do anything, so idk
        if (this.Parameters.Count != 0){
            requestUrl += "?";
            foreach (var item in this.Parameters){
                requestUrl += "&" + item;
            }
        }

        return requestUrl;
    }

    public CkApiRequestBase Limit(int limit){
        this.Parameters.Add("limit=" + limit);
        return this;
    }

    public CkApiRequestBase Offset(int offset){
        this.Parameters.Add("offset=" + offset);
        return this;
    }

    public CkApiRequestBase OrderByRating(){
        this.Parameters.Add("orderBy=3");
        return this;
    }

    public CkApiRequestBase OrderByNewest(){
        this.Parameters.Add("orderBy=6");
        return this;
    }

    public CkApiRequestBase OrderAscending(){
        this.Parameters.Add("order=1");
        return this;
    }

    public CkApiRequestBase AddCustomParameters(string[] args){
        foreach (var item in args){
            this.Parameters.Add(item);
        }
        return this;
    }

    public CkApiRequestBase ClearParameters(){
        this.Parameters.Clear();
        return this;
    }

    public void Printout(){
        System.Console.WriteLine(this.constructRequestUrl());
    }
}