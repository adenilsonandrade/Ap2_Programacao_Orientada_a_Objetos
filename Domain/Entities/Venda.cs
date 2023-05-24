using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Collections;
using _2023_05_24_AP2.Domain.Interfaces;

namespace _2023_05_24_AP2.Domain.Entities
{
    public class Venda
    {
        public int Id { get; set; }
        public Cliente Cliente { get; set; }
        public List<ProdutoVenda> Produtos { get; set; }
        public DateTime Data { get; set; }
        public double Total { get; set; }

        public Venda() { }

        public Venda(Cliente cliente)
        {
            Cliente = cliente;
            Produtos = new List<ProdutoVenda>();
        }

        public void AdicionarProduto(Produto produto, int quantidade)
        {
            if (produto.Estoque >= quantidade)
            {
                var produtoVenda = new ProdutoVenda(produto, quantidade);
                Produtos.Add(produtoVenda);
                produto.Estoque -= quantidade;
            }
            else
            {
                throw new Exception("Estoque insuficiente para adicionar o produto à venda.");
            }
        }

        public void EfetuarVenda()
        {
            CalcularTotal();
        }

        private void CalcularTotal()
        {
            Total = Produtos.Sum(produtoVenda => produtoVenda.Produto.Preco * produtoVenda.Quantidade);
        }
    }
}