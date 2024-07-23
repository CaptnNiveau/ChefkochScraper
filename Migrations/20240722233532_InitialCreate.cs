using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ChefkochScraper.Migrations
{
    /// <inheritdoc />
    public partial class InitialCreate : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "FullTags",
                columns: table => new
                {
                    id = table.Column<int>(type: "INTEGER", nullable: false),
                    name = table.Column<string>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                });

            migrationBuilder.CreateTable(
                name: "IngredientGroups",
                columns: table => new
                {
                    LocalId = table.Column<Guid>(type: "TEXT", nullable: false),
                    header = table.Column<string>(type: "TEXT", nullable: false),
                    LocalCreatedAt = table.Column<DateTime>(type: "TEXT", nullable: false),
                    LocalModifiedAt = table.Column<DateTime>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_IngredientGroups", x => x.LocalId);
                });

            migrationBuilder.CreateTable(
                name: "Nutrition",
                columns: table => new
                {
                    LocalId = table.Column<Guid>(type: "TEXT", nullable: false),
                    kCalories = table.Column<int>(type: "INTEGER", nullable: false),
                    carbohydrateContent = table.Column<double>(type: "REAL", nullable: false),
                    proteinContent = table.Column<double>(type: "REAL", nullable: false),
                    fatContent = table.Column<double>(type: "REAL", nullable: false),
                    LocalCreatedAt = table.Column<DateTime>(type: "TEXT", nullable: false),
                    LocalModifiedAt = table.Column<DateTime>(type: "TEXT", nullable: false)
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
                    rating = table.Column<double>(type: "REAL", nullable: false),
                    numVotes = table.Column<int>(type: "INTEGER", nullable: false),
                    LocalCreatedAt = table.Column<DateTime>(type: "TEXT", nullable: false),
                    LocalModifiedAt = table.Column<DateTime>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Rating", x => x.LocalId);
                });

            migrationBuilder.CreateTable(
                name: "Users",
                columns: table => new
                {
                    LocalId = table.Column<Guid>(type: "TEXT", nullable: false),
                    id = table.Column<string>(type: "TEXT", nullable: false),
                    username = table.Column<string>(type: "TEXT", nullable: false),
                    rank = table.Column<int>(type: "INTEGER", nullable: false),
                    role = table.Column<string>(type: "TEXT", nullable: false),
                    hasAvatar = table.Column<bool>(type: "INTEGER", nullable: false),
                    hasPaid = table.Column<bool>(type: "INTEGER", nullable: false),
                    deleted = table.Column<bool>(type: "INTEGER", nullable: false),
                    avatarImageUrlTemplate = table.Column<string>(type: "TEXT", nullable: false),
                    isVerified = table.Column<bool>(type: "INTEGER", nullable: false),
                    displayName = table.Column<string>(type: "TEXT", nullable: false),
                    LocalCreatedAt = table.Column<DateTime>(type: "TEXT", nullable: false),
                    LocalModifiedAt = table.Column<DateTime>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Users", x => x.LocalId);
                });

            migrationBuilder.CreateTable(
                name: "Ingredients",
                columns: table => new
                {
                    LocalId = table.Column<Guid>(type: "TEXT", nullable: false),
                    id = table.Column<string>(type: "TEXT", nullable: false),
                    name = table.Column<string>(type: "TEXT", nullable: false),
                    unit = table.Column<string>(type: "TEXT", nullable: false),
                    unitId = table.Column<string>(type: "TEXT", nullable: false),
                    amount = table.Column<double>(type: "REAL", nullable: false),
                    isBasic = table.Column<bool>(type: "INTEGER", nullable: false),
                    usageInfo = table.Column<string>(type: "TEXT", nullable: false),
                    url = table.Column<string>(type: "TEXT", nullable: false),
                    foodId = table.Column<string>(type: "TEXT", nullable: false),
                    productGroup = table.Column<string>(type: "TEXT", nullable: false),
                    blsKey = table.Column<string>(type: "TEXT", nullable: false),
                    previewImageUrlTemplate = table.Column<string>(type: "TEXT", nullable: false),
                    IngredientGroupLocalId = table.Column<Guid>(type: "TEXT", nullable: true),
                    LocalCreatedAt = table.Column<DateTime>(type: "TEXT", nullable: false),
                    LocalModifiedAt = table.Column<DateTime>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Ingredients", x => x.LocalId);
                    table.ForeignKey(
                        name: "FK_Ingredients_IngredientGroups_IngredientGroupLocalId",
                        column: x => x.IngredientGroupLocalId,
                        principalTable: "IngredientGroups",
                        principalColumn: "LocalId");
                });

            migrationBuilder.CreateTable(
                name: "Recipes",
                columns: table => new
                {
                    LocalId = table.Column<Guid>(type: "TEXT", nullable: false),
                    id = table.Column<string>(type: "TEXT", nullable: false),
                    type = table.Column<int>(type: "INTEGER", nullable: false),
                    title = table.Column<string>(type: "TEXT", nullable: false),
                    subtitle = table.Column<string>(type: "TEXT", nullable: false),
                    ownerLocalId = table.Column<Guid>(type: "TEXT", nullable: false),
                    ratingLocalId = table.Column<Guid>(type: "TEXT", nullable: false),
                    difficulty = table.Column<int>(type: "INTEGER", nullable: false),
                    hasImage = table.Column<bool>(type: "INTEGER", nullable: false),
                    hasVideo = table.Column<bool>(type: "INTEGER", nullable: false),
                    previewImageId = table.Column<string>(type: "TEXT", nullable: false),
                    previewImageOwnerLocalId = table.Column<Guid>(type: "TEXT", nullable: false),
                    preparationTime = table.Column<int>(type: "INTEGER", nullable: false),
                    isSubmitted = table.Column<bool>(type: "INTEGER", nullable: false),
                    isRejected = table.Column<bool>(type: "INTEGER", nullable: false),
                    createdAt = table.Column<DateTime>(type: "TEXT", nullable: false),
                    imageCount = table.Column<int>(type: "INTEGER", nullable: false),
                    editorLocalId = table.Column<Guid>(type: "TEXT", nullable: false),
                    submissionDate = table.Column<DateTime>(type: "TEXT", nullable: false),
                    isPremium = table.Column<bool>(type: "INTEGER", nullable: false),
                    status = table.Column<int>(type: "INTEGER", nullable: false),
                    slug = table.Column<string>(type: "TEXT", nullable: false),
                    previewImageUrlTemplate = table.Column<string>(type: "TEXT", nullable: false),
                    isPlus = table.Column<bool>(type: "INTEGER", nullable: false),
                    additionalDescription = table.Column<string>(type: "TEXT", nullable: false),
                    servings = table.Column<int>(type: "INTEGER", nullable: false),
                    kCalories = table.Column<int>(type: "INTEGER", nullable: false),
                    nutritionLocalId = table.Column<Guid>(type: "TEXT", nullable: false),
                    instructions = table.Column<string>(type: "TEXT", nullable: false),
                    miscellaneousText = table.Column<string>(type: "TEXT", nullable: false),
                    ingredientsText = table.Column<string>(type: "TEXT", nullable: false),
                    tags = table.Column<string>(type: "TEXT", nullable: false),
                    viewCount = table.Column<int>(type: "INTEGER", nullable: false),
                    cookingTime = table.Column<int>(type: "INTEGER", nullable: false),
                    restingTime = table.Column<int>(type: "INTEGER", nullable: false),
                    totalTime = table.Column<int>(type: "INTEGER", nullable: false),
                    categoryIds = table.Column<string>(type: "TEXT", nullable: false),
                    recipeVideoId = table.Column<string>(type: "TEXT", nullable: false),
                    isIndexable = table.Column<bool>(type: "INTEGER", nullable: false),
                    affiliateContent = table.Column<string>(type: "TEXT", nullable: false),
                    metaTitle = table.Column<string>(type: "TEXT", nullable: false),
                    metaDescription = table.Column<string>(type: "TEXT", nullable: false),
                    siteUrl = table.Column<string>(type: "TEXT", nullable: false),
                    LocalCreatedAt = table.Column<DateTime>(type: "TEXT", nullable: false),
                    LocalModifiedAt = table.Column<DateTime>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Recipes", x => x.LocalId);
                    table.ForeignKey(
                        name: "FK_Recipes_Nutrition_nutritionLocalId",
                        column: x => x.nutritionLocalId,
                        principalTable: "Nutrition",
                        principalColumn: "LocalId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Recipes_Rating_ratingLocalId",
                        column: x => x.ratingLocalId,
                        principalTable: "Rating",
                        principalColumn: "LocalId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Recipes_Users_editorLocalId",
                        column: x => x.editorLocalId,
                        principalTable: "Users",
                        principalColumn: "LocalId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Recipes_Users_ownerLocalId",
                        column: x => x.ownerLocalId,
                        principalTable: "Users",
                        principalColumn: "LocalId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Recipes_Users_previewImageOwnerLocalId",
                        column: x => x.previewImageOwnerLocalId,
                        principalTable: "Users",
                        principalColumn: "LocalId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Ingredients_IngredientGroupLocalId",
                table: "Ingredients",
                column: "IngredientGroupLocalId");

            migrationBuilder.CreateIndex(
                name: "IX_Recipes_editorLocalId",
                table: "Recipes",
                column: "editorLocalId");

            migrationBuilder.CreateIndex(
                name: "IX_Recipes_nutritionLocalId",
                table: "Recipes",
                column: "nutritionLocalId");

            migrationBuilder.CreateIndex(
                name: "IX_Recipes_ownerLocalId",
                table: "Recipes",
                column: "ownerLocalId");

            migrationBuilder.CreateIndex(
                name: "IX_Recipes_previewImageOwnerLocalId",
                table: "Recipes",
                column: "previewImageOwnerLocalId");

            migrationBuilder.CreateIndex(
                name: "IX_Recipes_ratingLocalId",
                table: "Recipes",
                column: "ratingLocalId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "FullTags");

            migrationBuilder.DropTable(
                name: "Ingredients");

            migrationBuilder.DropTable(
                name: "Recipes");

            migrationBuilder.DropTable(
                name: "IngredientGroups");

            migrationBuilder.DropTable(
                name: "Nutrition");

            migrationBuilder.DropTable(
                name: "Rating");

            migrationBuilder.DropTable(
                name: "Users");
        }
    }
}
