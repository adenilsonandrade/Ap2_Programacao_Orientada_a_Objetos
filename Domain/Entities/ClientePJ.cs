using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace _2023_05_24_AP2.Domain.Entities
{
    public class ClientePJ : Cliente
    {
        public string CNPJ { get; set; }

        public ClientePJ() { }

        public ClientePJ(string Nome, string CNPJ, string Email, string Telefone, string Endereco) : base(Nome, Email, Telefone, Endereco)
        {
            this.CNPJ = CNPJ;
        }
    }
}