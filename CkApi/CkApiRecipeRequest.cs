namespace ChefkochScraper;

public class CkApiRecipeRequest: CkApiRequestBase{
    public CkApiRecipeRequest(string? id){
        if (id!=null) {this.RequestUrl += $"/recipes/{id}";}
        else {this.RequestUrl += "/recipes?";}
    }

    //TODO: add validation
    public CkApiRecipeRequest GetComments(){
        this.RequestUrl += "/comments?";
        return this;
    }

    public CkApiRecipeRequest GetImages(){
        this.RequestUrl += "/images?";
        return this;
    }
}