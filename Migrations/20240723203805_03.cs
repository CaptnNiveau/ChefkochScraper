using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ChefkochScraper.Migrations
{
    /// <inheritdoc />
    public partial class _03 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Ingredients_IngredientGroups_IngredientGroupLocalId",
                table: "Ingredients");

            migrationBuilder.DropForeignKey(
                name: "FK_Recipes_Nutrition_nutritionLocalId",
                table: "Recipes");

            migrationBuilder.DropForeignKey(
                name: "FK_Recipes_Rating_ratingLocalId",
                table: "Recipes");

            migrationBuilder.DropTable(
                name: "Nutrition");

            migrationBuilder.DropTable(
                name: "Rating");

            migrationBuilder.DropIndex(
                name: "IX_Recipes_nutritionLocalId",
                table: "Recipes");

            migrationBuilder.DropIndex(
                name: "IX_Ingredients_IngredientGroupLocalId",
                table: "Ingredients");

            migrationBuilder.DropColumn(
                name: "nutritionLocalId",
                table: "Recipes");

            migrationBuilder.DropColumn(
                name: "IngredientGroupLocalId",
                table: "Ingredients");

            migrationBuilder.DropColumn(
                name: "amount",
                table: "Ingredients");

            migrationBuilder.DropColumn(
                name: "previewImageUrlTemplate",
                table: "Ingredients");

            migrationBuilder.DropColumn(
                name: "unit",
                table: "Ingredients");

            migrationBuilder.DropColumn(
                name: "unitId",
                table: "Ingredients");

            migrationBuilder.DropColumn(
                name: "usageInfo",
                table: "Ingredients");

            migrationBuilder.RenameColumn(
                name: "ratingLocalId",
                table: "Recipes",
                newName: "previewImageCreditsLocalId");

            migrationBuilder.RenameIndex(
                name: "IX_Recipes_ratingLocalId",
                table: "Recipes",
                newName: "IX_Recipes_previewImageCreditsLocalId");

            migrationBuilder.AddColumn<double>(
                name: "carbohydrateContent",
                table: "Recipes",
                type: "REAL",
                nullable: true);

            migrationBuilder.AddColumn<double>(
                name: "fatContent",
                table: "Recipes",
                type: "REAL",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "numVotes",
                table: "Recipes",
                type: "INTEGER",
                nullable: true);

            migrationBuilder.AddColumn<double>(
                name: "proteinContent",
                table: "Recipes",
                type: "REAL",
                nullable: true);

            migrationBuilder.AddColumn<double>(
                name: "rating",
                table: "Recipes",
                type: "REAL",
                nullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "id",
                table: "Ingredients",
                type: "TEXT",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "TEXT",
                oldNullable: true);

            migrationBuilder.AddColumn<Guid>(
                name: "RecipeDbModelLocalId",
                table: "IngredientGroups",
                type: "TEXT",
                nullable: true);

            migrationBuilder.AddColumn<Guid>(
                name: "LocalId",
                table: "FullTags",
                type: "TEXT",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.AddColumn<DateTime>(
                name: "LocalCreatedAt",
                table: "FullTags",
                type: "TEXT",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<DateTime>(
                name: "LocalModifiedAt",
                table: "FullTags",
                type: "TEXT",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<Guid>(
                name: "RecipeDbModelLocalId",
                table: "FullTags",
                type: "TEXT",
                nullable: true);

            migrationBuilder.AddPrimaryKey(
                name: "PK_FullTags",
                table: "FullTags",
                column: "LocalId");

            migrationBuilder.CreateTable(
                name: "IngredientsUsed",
                columns: table => new
                {
                    LocalId = table.Column<Guid>(type: "TEXT", nullable: false),
                    ingredientLocalId = table.Column<Guid>(type: "TEXT", nullable: false),
                    unit = table.Column<string>(type: "TEXT", nullable: true),
                    unitId = table.Column<string>(type: "TEXT", nullable: true),
                    amount = table.Column<double>(type: "REAL", nullable: true),
                    usageInfo = table.Column<string>(type: "TEXT", nullable: true),
                    previewImageUrlTemplate = table.Column<string>(type: "TEXT", nullable: true),
                    IngredientGroupDbModelLocalId = table.Column<Guid>(type: "TEXT", nullable: true),
                    LocalCreatedAt = table.Column<DateTime>(type: "TEXT", nullable: false),
                    LocalModifiedAt = table.Column<DateTime>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_IngredientsUsed", x => x.LocalId);
                    table.ForeignKey(
                        name: "FK_IngredientsUsed_IngredientGroups_IngredientGroupDbModelLocalId",
                        column: x => x.IngredientGroupDbModelLocalId,
                        principalTable: "IngredientGroups",
                        principalColumn: "LocalId");
                    table.ForeignKey(
                        name: "FK_IngredientsUsed_Ingredients_ingredientLocalId",
                        column: x => x.ingredientLocalId,
                        principalTable: "Ingredients",
                        principalColumn: "LocalId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_IngredientGroups_RecipeDbModelLocalId",
                table: "IngredientGroups",
                column: "RecipeDbModelLocalId");

            migrationBuilder.CreateIndex(
                name: "IX_FullTags_RecipeDbModelLocalId",
                table: "FullTags",
                column: "RecipeDbModelLocalId");

            migrationBuilder.CreateIndex(
                name: "IX_IngredientsUsed_IngredientGroupDbModelLocalId",
                table: "IngredientsUsed",
                column: "IngredientGroupDbModelLocalId");

            migrationBuilder.CreateIndex(
                name: "IX_IngredientsUsed_ingredientLocalId",
                table: "IngredientsUsed",
                column: "ingredientLocalId");

            migrationBuilder.AddForeignKey(
                name: "FK_FullTags_Recipes_RecipeDbModelLocalId",
                table: "FullTags",
                column: "RecipeDbModelLocalId",
                principalTable: "Recipes",
                principalColumn: "LocalId");

            migrationBuilder.AddForeignKey(
                name: "FK_IngredientGroups_Recipes_RecipeDbModelLocalId",
                table: "IngredientGroups",
                column: "RecipeDbModelLocalId",
                principalTable: "Recipes",
                principalColumn: "LocalId");

            migrationBuilder.AddForeignKey(
                name: "FK_Recipes_Users_previewImageCreditsLocalId",
                table: "Recipes",
                column: "previewImageCreditsLocalId",
                principalTable: "Users",
                principalColumn: "LocalId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_FullTags_Recipes_RecipeDbModelLocalId",
                table: "FullTags");

            migrationBuilder.DropForeignKey(
                name: "FK_IngredientGroups_Recipes_RecipeDbModelLocalId",
                table: "IngredientGroups");

            migrationBuilder.DropForeignKey(
                name: "FK_Recipes_Users_previewImageCreditsLocalId",
                table: "Recipes");

            migrationBuilder.DropTable(
                name: "IngredientsUsed");

            migrationBuilder.DropIndex(
                name: "IX_IngredientGroups_RecipeDbModelLocalId",
                table: "IngredientGroups");

            migrationBuilder.DropPrimaryKey(
                name: "PK_FullTags",
                table: "FullTags");

            migrationBuilder.DropIndex(
                name: "IX_FullTags_RecipeDbModelLocalId",
                table: "FullTags");

            migrationBuilder.DropColumn(
                name: "carbohydrateContent",
                table: "Recipes");

            migrationBuilder.DropColumn(
                name: "fatContent",
                table: "Recipes");

            migrationBuilder.DropColumn(
                name: "numVotes",
                table: "Recipes");

            migrationBuilder.DropColumn(
                name: "proteinContent",
                table: "Recipes");

            migrationBuilder.DropColumn(
                name: "rating",
                table: "Recipes");

            migrationBuilder.DropColumn(
                name: "RecipeDbModelLocalId",
                table: "IngredientGroups");

            migrationBuilder.DropColumn(
                name: "LocalId",
                table: "FullTags");

            migrationBuilder.DropColumn(
                name: "LocalCreatedAt",
                table: "FullTags");

            migrationBuilder.DropColumn(
                name: "LocalModifiedAt",
                table: "FullTags");

            migrationBuilder.DropColumn(
                name: "RecipeDbModelLocalId",
                table: "FullTags");

            migrationBuilder.RenameColumn(
                name: "previewImageCreditsLocalId",
                table: "Recipes",
                newName: "ratingLocalId");

            migrationBuilder.RenameIndex(
                name: "IX_Recipes_previewImageCreditsLocalId",
                table: "Recipes",
                newName: "IX_Recipes_ratingLocalId");

            migrationBuilder.AddColumn<Guid>(
                name: "nutritionLocalId",
                table: "Recipes",
                type: "TEXT",
                nullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "id",
                table: "Ingredients",
                type: "TEXT",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "TEXT");

            migrationBuilder.AddColumn<Guid>(
                name: "IngredientGroupLocalId",
                table: "Ingredients",
                type: "TEXT",
                nullable: true);

            migrationBuilder.AddColumn<double>(
                name: "amount",
                table: "Ingredients",
                type: "REAL",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "previewImageUrlTemplate",
                table: "Ingredients",
                type: "TEXT",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "unit",
                table: "Ingredients",
                type: "TEXT",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "unitId",
                table: "Ingredients",
                type: "TEXT",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "usageInfo",
                table: "Ingredients",
                type: "TEXT",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "Nutrition",
                columns: table => new
                {
                    LocalId = table.Column<Guid>(type: "TEXT", nullable: false),
                    LocalCreatedAt = table.Column<DateTime>(type: "TEXT", nullable: false),
                    LocalModifiedAt = table.Column<DateTime>(type: "TEXT", nullable: false),
                    carbohydrateContent = table.Column<double>(type: "REAL", nullable: true),
                    fatContent = table.Column<double>(type: "REAL", nullable: true),
                    kCalories = table.Column<int>(type: "INTEGER", nullable: true),
                    proteinContent = table.Column<double>(type: "REAL", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Nutrition", x => x.LocalId);
                });

            migrationBuilder.CreateTable(
                name: "Rating",
                columns: table => new
                {
                    LocalId = table.Column<Guid>(type: "TEXT", nullable: false),
                    LocalCreatedAt = table.Column<DateTime>(type: "TEXT", nullable: false),
                    LocalModifiedAt = table.Column<DateTime>(type: "TEXT", nullable: false),
                    numVotes = table.Column<int>(type: "INTEGER", nullable: true),
                    rating = table.Column<double>(type: "REAL", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Rating", x => x.LocalId);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Recipes_nutritionLocalId",
                table: "Recipes",
                column: "nutritionLocalId");

            migrationBuilder.CreateIndex(
                name: "IX_Ingredients_IngredientGroupLocalId",
                table: "Ingredients",
                column: "IngredientGroupLocalId");

            migrationBuilder.AddForeignKey(
                name: "FK_Ingredients_IngredientGroups_IngredientGroupLocalId",
                table: "Ingredients",
                column: "IngredientGroupLocalId",
                principalTable: "IngredientGroups",
                principalColumn: "LocalId");

            migrationBuilder.AddForeignKey(
                name: "FK_Recipes_Nutrition_nutritionLocalId",
                table: "Recipes",
                column: "nutritionLocalId",
                principalTable: "Nutrition",
                principalColumn: "LocalId");

            migrationBuilder.AddForeignKey(
                name: "FK_Recipes_Rating_ratingLocalId",
                table: "Recipes",
                column: "ratingLocalId",
                principalTable: "Rating",
                principalColumn: "LocalId");
        }
    }
}
