namespace ChefkochScraper;

public static class ModelConverter{
    public static RecipeDbModel ConvertRecipe(RecipeJsonModel jsonModel){
        return new RecipeDbModel();
    }
}