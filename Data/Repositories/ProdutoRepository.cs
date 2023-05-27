using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using _2023_05_24_AP2.Domain.Entities;
using _2023_05_24_AP2.Domain.Interfaces;

namespace _2023_05_24_AP2.Data.Repositories
{
    public class ProdutoRepository : IProdutoRepository
    {
        private readonly DataContext context;
        public ProdutoRepository(DataContext context)
        {
            this.context = context;
        }

        public Produto GetById(int entityId)
        {
            return context.Produtos.SingleOrDefault(x => x.Id == entityId);
        }

        public IList<Produto> GetAll()
        {
            return context.Produtos.ToList();
        }

        public void Save(Produto entity)
        {
            context.Add(entity);
            context.SaveChanges();
        }

        public bool Delete(int entityId)
        {
            var produto = GetById(entityId);
            context.Remove(produto);
            context.SaveChanges();
            return true;
        }

        public void Update(Produto entity)
        {
            context.Produtos.Update(entity);
            context.SaveChanges();
        }
    }
}