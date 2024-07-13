namespace ChefkochScraper;

public class CkApiUserRequest: CkApiRequestBase{
    public CkApiUserRequest(string? id){
        if (id!=null) {this.RequestUrl += $"/users/{id}";}
        else {this.RequestUrl += "/users?";}
    }

    //TODO: add validation
    public CkApiUserRequest GetProfile(){
        this.RequestUrl += "/profile";
        return this;
    }
}