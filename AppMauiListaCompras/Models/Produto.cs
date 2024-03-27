using SQLite;

namespace AppMauiListaCompras.Models
{
    public class Produto
    {
        [AutoIncrement, PrimaryKey]
        public int Id { get; set; }
        public string Descricao { get; set; }
        public double Quantidade { get; set; }
        public double Preco { get; set; }
        public double Total { get; set; }
    }
}
