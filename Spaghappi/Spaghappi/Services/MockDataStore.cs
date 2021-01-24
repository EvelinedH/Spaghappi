using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Spaghappi.Models;

namespace Spaghappi.Services
{
    class MockDataStore : IDataStore
    {
        public List<Ingredient> IngredientList { get ; set; }

        public MockDataStore()
        {
            IngredientList = new List<Ingredient>();

            IngredientList.Add(new Ingredient() { ProductName = "Pasta", Barcode = "5400141043495", Quantity = 4 });
            IngredientList.Add(new Ingredient() { ProductName = "Saus", Barcode = "5412723300285", Quantity = 4 });
            IngredientList.Add(new Ingredient() { ProductName = "Erwtjes", Barcode = "4001724819905", Quantity = 2 });
            IngredientList.Add(new Ingredient() { ProductName = "Champignons", Barcode = "5400141277920", Quantity = 3 });
        }

        public List<Ingredient> GetAllIngredient()
        {
            return IngredientList;
        }

        public Task<List<Ingredient>> GetAllIngredientAsync()
        {
            return Task.FromResult(IngredientList);
        }

        public void UpdateIngredient(Ingredient ingredient)
        {
            
        }

        public Task RestoreAsync()
        {
            return null;
        }

        public void AddIngredient(Ingredient ingredient)
        {
            IngredientList.Add(ingredient);
        }

        public void DeleteIngredient(Ingredient ingredient)
        {
            IngredientList.Remove(ingredient);
        }
    }
}
