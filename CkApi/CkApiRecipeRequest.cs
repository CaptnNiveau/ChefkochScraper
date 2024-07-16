namespace ChefkochScraper;

public class CkApiRecipeRequest: CkApiRequestBase{
    public CkApiRecipeRequest(string? id){
        this.ApiUrl += "/recipes";
        this.Id = id;
    }

    public CkApiRecipeRequest GetComments(){
        this.Subpage = "/comments";
        return this;
    }

    public CkApiRecipeRequest GetImages(){
        this.Subpage = "/images";
        return this;
    }
}