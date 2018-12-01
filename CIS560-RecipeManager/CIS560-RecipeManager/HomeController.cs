﻿using CIS560_RecipeManager.PantryManager;
using CIS560_RecipeManager.RecipeManager;
using CIS560_RecipeManager.Repository;
using CIS560_RecipeManager.ShoppingListManager;

using System;
using System.Windows.Forms;

namespace CIS560_RecipeManager
{
    public class HomeController
    {
        private RecipeController _recipeController;
        private PantryController _pantryController;
        private ShoppingListController _shoppingListController;

        private Action _launchRecipeManager;
        private Action _launchPantryManager;
        private Action _launchShoppingListManager;

        private RecipeInventory _recipeInventory;
        private ShoppingListInventory _shoppingInventory;
        private MyPantry _pantry;

        private IQuery _query;

        public HomeController()
        {
            
            _query = new Query();
            DataGenerator.DataGenerator.GenerateAndInsertData(_query, 20, 10, 50);

            _recipeInventory = new RecipeInventory(_query);
            _shoppingInventory = new ShoppingListInventory(_query);
            _pantry = new MyPantry(_query);

            _recipeController = new RecipeController(_recipeInventory, _pantry);
            _pantryController = new PantryController(_pantry);
            _shoppingListController = new ShoppingListController(_shoppingInventory, _pantry, _recipeInventory);

            _launchRecipeManager = _recipeController.LaunchRecipeForm;
            _launchPantryManager = _pantryController.LaunchPantryForm;
            _launchShoppingListManager = _shoppingListController.LaunchShoppingListForm;
        }


        public void LaunchHomeForm()
        {
            Application.Run(new uiHome(
                _launchRecipeManager,
                _launchPantryManager,
                _launchShoppingListManager));
        }
    }
}
