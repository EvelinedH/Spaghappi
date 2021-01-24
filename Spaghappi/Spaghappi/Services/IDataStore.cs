using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Spaghappi.Models;

namespace Spaghappi.Services
{
    public interface IDataStore
    {
        List<Ingredient> IngredientList { get; set; }
        List<Ingredient> GetAllIngredient();
        Task<List<Ingredient>> GetAllIngredientAsync();
        void UpdateIngredient(Ingredient ingredient);
        void AddIngredient(Ingredient ingredient);
        void DeleteIngredient(Ingredient ingredient);
        Task RestoreAsync();
    }
}
