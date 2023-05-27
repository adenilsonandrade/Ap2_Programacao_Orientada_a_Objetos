using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using _2023_05_24_AP2.Domain.Entities;
using _2023_05_24_AP2.Domain.Interfaces;

namespace _2023_05_24_AP2.Data.Repositories
{
    public class ClienteRepository : IClienteRepository
    {
        private readonly DataContext context;
        public ClienteRepository(DataContext context)
        {
            this.context = context;
        }

        public Cliente GetById(int entityId)
        {
            return context.Clientes.SingleOrDefault(x => x.Id == entityId);
        }

        public IList<Cliente> GetAll()
        {
            return context.Clientes.ToList();
        }

        public void Save(Cliente entity)
        {
            context.Add(entity);
            context.SaveChanges();
        }

        public bool Delete(int entityId)
        {
            var cliente = GetById(entityId);
            context.Remove(cliente);
            context.SaveChanges();
            return true;
        }

        public void Update(Cliente entity)
        {
            context.Clientes.Update(entity);
            context.SaveChanges();
        }
    }
}