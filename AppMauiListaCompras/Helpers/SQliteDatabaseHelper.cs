using AppMauiListaCompras.Models;
using SQLite;

namespace AppMauiListaCompras.Helpers
{
    public class SQliteDatabaseHelper
    {
        readonly SQLiteAsyncConnection _conn;

        public SQliteDatabaseHelper(string path)
        {
            _conn = new SQLiteAsyncConnection(path);
            _conn.CreateTableAsync<Produto>().Wait();
        }

        public Task<int> Insert(Produto p)
        {
            return _conn.InsertAsync(p);
        }

        public Task<List<Produto>> Update(Produto p)
        {
            string sql = "Update Produto SET Descricao=?," +
                         "Preco=? Quatidade=? WHERE id=?";

            return _conn.QueryAsync<Produto>(sql, p.Descricao, p.Preco, p.Quantidade, p.Id);

        }

        public Task<List<Produto>> GetAll()
        {
            return _conn.Table<Produto>().ToListAsync();
        }

        public Task<List<Produto>> Search (string q)
        {
            string sql = "SELECT * FROM Produto WHERE" +
                "descricao LIKE '%" + q + "%'";

            return _conn.QueryAsync<Produto>(sql);
        }


        public Task<int> Delete(int id)
        {
            return _conn.Table<Produto>().DeleteAsync(i => i.Id == id);
        }


    }
}
