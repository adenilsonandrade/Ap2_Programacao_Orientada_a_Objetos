using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using _2023_05_24_AP2.Domain.Entities;
using _2023_05_24_AP2.Domain.Interfaces;

namespace _2023_05_24_AP2.Data.Repositories
{
    public class VendaRepository : IVendaRepository
    {
        private readonly DataContext context;
        public VendaRepository(DataContext context)
        {
            this.context = context;
        }

        public Venda GetById(int entityId)
        {
            return context.Vendas.SingleOrDefault(x => x.Id == entityId);
        }

        public IList<Venda> GetAll()
        {
            return context.Vendas.ToList();
        }

        public void Save(Venda entity)
        {
            context.Add(entity);
            context.SaveChanges();
        }

        public bool Delete(int entityId)
        {
            var venda = GetById(entityId);
            context.Remove(venda);
            context.SaveChanges();
            return true;
        }

        public void Update(Venda entity)
        {
            context.Vendas.Update(entity);
            context.SaveChanges();
        }
    }
}