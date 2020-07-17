using System.Collections.Generic;
using DrinksUI.Data.Models;
using DrinksUI.Dtos;

namespace DrinksUI.Data
{
    public class MockDataBuilder
    {
        public List<IngredientModel> Ingredients { get; set; }
        public List<DrinkModel> Drinks { get; set; }

        public MockDataBuilder()
        {
            Ingredients = new List<IngredientModel>(){
                new IngredientModel(){Type = "Vodka", AddieType = AddieType.PushDosed, Unit = Unit.CL}, //1
                new IngredientModel(){Type = "Gin", AddieType = AddieType.PushDosed, Unit = Unit.CL}, // 2
                new IngredientModel(){Type = "Rum", AddieType = AddieType.PushDosed, Unit = Unit.CL}, // 3
                new IngredientModel(){Type = "Tequila", AddieType = AddieType.PushDosed, Unit = Unit.CL}, // 4
                new IngredientModel(){Type = "Cola", AddieType = AddieType.Poured, Unit = Unit.CL}, // 5
                new IngredientModel(){Type = "Club soda", AddieType = AddieType.Poured, Unit = Unit.CL},  //6
                new IngredientModel(){Type = "Apple juice", AddieType = AddieType.Poured, Unit = Unit.CL}, // 7
                new IngredientModel(){Type = "Orange juice", AddieType = AddieType.Poured, Unit = Unit.CL}, // 8 
                new IngredientModel(){Type = "Salt", AddieType = AddieType.Extra, Unit = Unit.Pinches}, // 9
                new IngredientModel(){Type = "Lemon Slice", AddieType = AddieType.Extra, Unit = Unit.Pcs} // 10
            };

            Drinks = new List<DrinkModel>
            {
                new DrinkModel()
                {
                    Name = "screwDriver",
                    Description = "Sigh view am high neat half to what. Sent late held than set why wife our. If an blessing building steepest. Agreement distrusts mrs six affection satisfied. Day blushes visitor end company old prevent chapter. Consider declared out expenses her concerns. No at indulgence conviction particular boisterous discretion. Direct enough off others say eldest may she. Possible all ignorant supplied get settling marriage recurred. ",
                    Addies = new List<AddieModel>()
                    {
                        new AddieModel() {Ingredient = Ingredients[0], Amount = 2},
                        new AddieModel() {Ingredient = Ingredients[7], Amount = 14}
                    }
                },
                new DrinkModel()
                {
                    Name = "Rum n coke",
                    Description = "She exposed painted fifteen are noisier mistake led waiting. Surprise not wandered speedily husbands although yet end. Are court tiled cease young built fat one man taken. We highest ye friends is exposed equally in. Ignorant had too strictly followed. Astonished as assistance or unreserved oh pianoforte ye. Five with seen put need tore add neat. Bringing it is he returned received raptures.",
                    Addies = new List<AddieModel>()
                    {
                        new AddieModel() {Ingredient = Ingredients[2], Amount = 2},
                        new AddieModel() {Ingredient = Ingredients[4], Amount = 14}
                    }
                },
                new DrinkModel()
                {
                    Name = "Død",
                    Description = "Agreed joy vanity regret met may ladies oppose who. Mile fail as left as hard eyes. Meet made call in mean four year it to. Prospect so branched wondered sensible of up. For gay consisted resolving pronounce sportsman saw discovery not. Northward or household as conveying we earnestly believing. No in up contrasted discretion inhabiting excellence. Entreaties we collecting unpleasant at everything conviction.",
                    Addies = new List<AddieModel>()
                    {
                        new AddieModel() {Ingredient = Ingredients[3], Amount = 2},
                        new AddieModel() {Ingredient = Ingredients[8], Amount = 1},
                        new AddieModel() {Ingredient = Ingredients[9], Amount = 1},
                    }
                }
            };
        }

        public void SubmitThatShit(DrinkContext dbContext)
        {
            dbContext.AddRange(Ingredients);
            dbContext.SaveChanges();
            dbContext.AddRange(Drinks);
            dbContext.SaveChanges();
        }

    }
}