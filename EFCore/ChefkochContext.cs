using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;

namespace ChefkochScraper;

public class ChefkochContext : DbContext
{
    public DbSet<UserModel> Users { get; set; }
    public DbSet<RecipeDbModel> Recipes { get; set; }
    public DbSet<FullTagModel> FullTags { get; set; }
    public DbSet<IngredientDbModel> Ingredients{ get; set; }
    public DbSet<IngredientGroupDbModel> IngredientGroups { get; set; }
    public DbSet<IngredientUsedDbModel> IngredientsUsed { get; set; }
    public string DbPath { get; }

    public ChefkochContext(){
        string baseDirectory = AppDomain.CurrentDomain.BaseDirectory.Replace("\\bin\\Debug\\net8.0", "");
        this.DbPath = baseDirectory + "chefkoch.db";
    }

    // The following configures EF to create a Sqlite database file in the
    // special "local" folder for your platform.
    protected override void OnConfiguring(DbContextOptionsBuilder options)
        => options.UseSqlite($"Data Source={DbPath}");
}