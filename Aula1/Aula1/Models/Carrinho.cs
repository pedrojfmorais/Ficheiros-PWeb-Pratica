namespace Aula1.Models
{
    public class Carrinho
    {
        public List<CarrinhoItem> items { get; set; } = new List<CarrinhoItem>();
        public void AddItem(CarrinhoItem curso, int qtd)
        {

            if (items.Contains(curso))
            {
                foreach (var item in items)
                {
                    if (item == curso)
                    {
                        item.Quantidade = qtd;
                    }
                }
            }
            else
            {
                items.Add(curso);
            }
        }
        public void RemoveItem(CarrinhoItem curso)
        {
            items.Remove(curso);
        }
        public decimal Total()
        {
            decimal total = 0;

            foreach (var item in items)
                total += item.PrecoUnit * item.Quantidade;

            return total;
        }
        public void Clear() => items.Clear();
    }
}
