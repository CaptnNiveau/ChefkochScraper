namespace ChefkochScraper;

/// <summary>
/// Klasse für Nutzer-Anfragen.
/// </summary>
public class CkApiUserRequest: CkApiRequestBase{
    public CkApiUserRequest(string? id){
        this.ApiUrl += "/users";
        this.Id = id;
    }

    public CkApiUserRequest GetProfile(){
        this.Subpage = "/profile";
        return this;
    }
}