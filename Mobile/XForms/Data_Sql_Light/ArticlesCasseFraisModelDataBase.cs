using SQLite;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace XForms.Data_Sql_Light
{
    public class ArticlesCasseFraisModelDataBase
    {
        static SQLiteAsyncConnection Database;

        public static readonly AsyncLazy<ArticlesCasseFraisModelDataBase> Instance = new AsyncLazy<ArticlesCasseFraisModelDataBase>(async () =>
        {
            var instance = new ArticlesCasseFraisModelDataBase();
            CreateTableResult result = await Database.CreateTableAsync<Models.ArticlesCasseFraisModel>();
            return instance;
        });

        public ArticlesCasseFraisModelDataBase()
        {
            Database = new SQLiteAsyncConnection(Constants.DatabasePath, Constants.Flags);
        }

        public Task<int> SaveCassFraisProduct(Models.ArticlesCasseFraisModel item)
        {
            return Database.InsertAsync(item);
        }

        public void DeleteCassFraisProducts()
        {
            Database.QueryAsync<Models.ArticlesCasseFraisModel>("DELETE FROM [ArticlesCasseFraisModel]");
        }

        public async Task<List<Models.ArticlesCasseFraisModel>> GetAllCassFraisProducts()
        {
            return await Database.QueryAsync<Models.ArticlesCasseFraisModel>("SELECT * FROM [ArticlesCasseFraisModel]");
        }
    }
}
