using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using _2023_05_24_AP2.Domain.Interfaces;

namespace _2023_05_24_AP2.Domain.Entities
{
    public class Produto
    {
        public int Id { get; set; }
        public string Nome { get; set; }
        public double Preco { get; set; }
        public int Estoque { get; set; }
        public Produto() { }

        public Produto(string Nome, double Preco)
        {
            this.Nome = Nome;
            this.Preco = Preco;
        }

        public Produto(string Nome, double Preco, int Estoque)
        {
            this.Nome = Nome;
            this.Preco = Preco;
            this.Estoque = Estoque;
        }
    }
}