﻿/**
 * Recipe.cs
 * Class representing a recipe object
 * Authors: CIS560 Project Team 1
 */

using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CIS560_RecipeManager;

namespace CIS560_RecipeManager.RecipeManager
{
    public class Recipe : IComparable<Recipe>
    {
        public int Id { get; }

        public string Name { get; set; }

        public string Description { get; set; }

        public RecipeCategory Category { get; set; }

        public IDictionary<Ingredient, int> MeasuredIngredients { get; private set; }

        public int NumberMakeable
        {
            get
            {
                return _query.NumberMakeable(this);
            }
        }

        private IQuery _query;

        public int PriceInCents
        {
            get
            {
                int sum = 0;
                foreach (var kvp in MeasuredIngredients)
                {
                    sum += (kvp.Key.PriceInCents * kvp.Value);
                }
                return sum;
            }
        }

        public string FormattedPrice
        {
            get
            {
                return "$" + (PriceInCents / 100.0).ToString("0.##");
            }
        }

        public int? Rating { get; set; }

        public Recipe(
            int id, 
            string name,
            string description,
            RecipeCategory category,
            IDictionary<Ingredient, int> measuredIngredients,
            IQuery query,
            int? rating = null)
        {
            Id = id;
            Name = name;
            Description = description;
            Category = category;
            MeasuredIngredients = measuredIngredients;
            if (rating != null) Rating = rating;
            _query = query;
        }

        public override string ToString()
        {
            return $"Recipe(id: {Id}, name: {Name}, description: {Description}, measuredIngredients: {MeasuredIngredients})";
        }

        public int CompareTo(Recipe other)
        {
            return string.Compare(Category.Name, other.Category.Name);
        }
    }
}
