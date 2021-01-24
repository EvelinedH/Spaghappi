using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Spaghappi.Models;
using Xamarin.Forms;

namespace Spaghappi.Services
{
    class SQLiteDataStore : IDataStore
    {
        public List<Ingredient> IngredientList { get; set ; }
        public ISQLiteDatabase _db = DependencyService.Get<ISQLiteDatabase>();
        
        public SQLiteDataStore()
        {
            _db.SQLiteDatabase.CreateTableAsync<Ingredient>().Wait();
        }

        public List<Ingredient> GetAllIngredient()
        {
            return IngredientList;
        }

        public Task<List<Ingredient>> GetAllIngredientAsync()
        {
            return _db.SQLiteDatabase.Table<Ingredient>().ToListAsync();
        }

        public void UpdateIngredient(Ingredient ingredient)
        {
            //_db.SQLiteDatabase.UpdateAsync(ingredient).wait;
            var _ingredient = ingredient;
            _db.SQLiteDatabase.ExecuteAsync(
                "UPDATE Ingredient SET Quantity=" +_ingredient.Quantity + 
                " WHERE Barcode= '" + _ingredient.Barcode + "'").Wait();
        }

        async public Task RestoreAsync()
        {
            await _db.SQLiteDatabase.ExecuteAsync("DELETE FROM Ingredient");
            await _db.SQLiteDatabase.InsertAsync(new Ingredient() { ProductName = "Pasta", Barcode = "5400141043495", Quantity = 4 });
            await _db.SQLiteDatabase.InsertAsync(new Ingredient() { ProductName = "Saus", Barcode = "5412723300285", Quantity = 4 });
            await _db.SQLiteDatabase.InsertAsync(new Ingredient() { ProductName = "Erwtjes", Barcode = "4001724819905", Quantity = 2 });
            await _db.SQLiteDatabase.InsertAsync(new Ingredient() { ProductName = "Champignons", Barcode = "5400141277920", Quantity = 3 });
        }

         public void AddIngredient(Ingredient ingredient)
        {
            _db.SQLiteDatabase.InsertAsync(ingredient).Wait();
            /*  var _ingredient = ingredient;
              String query = "INSERT INTO Ingredient (ProductName, Barcode, Quantity) " +
                  "VALUES ('" + _ingredient.ProductName + "', '" + _ingredient.Barcode + "', 1)";
              _db.SQLiteDatabase.ExecuteAsync(query).wait(); */
        }

        public void DeleteIngredient(Ingredient ingredient)
        {
            var _ingredient = ingredient;
            _db.SQLiteDatabase.ExecuteAsync("DELETE FROM Ingredient WHERE Barcode = '" + _ingredient.Barcode + "'").Wait();
            //_db.SQLiteDatabase.DeleteAsync(ingredient).wait();
        }
    }
}
