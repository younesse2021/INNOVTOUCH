using Shared.Models.IN;
using SQLite;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace XForms.Data_Sql_Light
{
    public class InventaireItemDatabase
    {
        static SQLiteAsyncConnection Database;

        public static readonly AsyncLazy<InventaireItemDatabase> Instance = new AsyncLazy<InventaireItemDatabase>(async () =>
        {
            var instance = new InventaireItemDatabase();
             CreateTableResult result = await Database.CreateTableAsync<ListeArticlesInventaireModelSqlLight>();
            return instance;
        });

        public InventaireItemDatabase()
        {
            Database = new SQLiteAsyncConnection(Constants.DatabasePath, Constants.Flags);
        }

        public Task<int> SaveItemAsync(ListeArticlesInventaireModelSqlLight item)
        {
            return Database.InsertAsync(item);
        }

        public void DeleteAllProduit()
        {
            Database.QueryAsync<ListeArticlesInventaireModelSqlLight>("DELETE FROM [ListeArticlesInventaireModelSqlLight]");
        }

        public async Task<List<ListeArticlesInventaireModelSqlLight>> GetAllInv()
        {
            return await Database.QueryAsync<ListeArticlesInventaireModelSqlLight>("SELECT * FROM [ListeArticlesInventaireModelSqlLight]");
        }

        public Task<ListeArticlesInventaireModelSqlLight> GetInVByCode(string id)
        {
            var Res = Database.Table<ListeArticlesInventaireModelSqlLight>().Where(i => i.barcode == id).FirstOrDefaultAsync();
            return Res;
        }
    }
}
