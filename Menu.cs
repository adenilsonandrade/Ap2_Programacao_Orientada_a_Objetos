using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using _2023_05_24_AP2.Domain.Entities;
using _2023_05_24_AP2.Domain.Interfaces;
using _2023_05_24_AP2.Data.Repositories;

namespace _2023_05_24_AP2.Domain.Entities
{
    public class Menu
    {
        private static ClienteRepository clienteRepository;
        private static ProdutoRepository produtoRepository;
        private static VendaRepository vendaRepository;

        public static void Exibir()
        {
            clienteRepository = new ClienteRepository(new DataContext());
            produtoRepository = new ProdutoRepository(new DataContext());
            vendaRepository = new VendaRepository(new DataContext());

            while (true)
            {
                Console.WriteLine("-----Menu-----:");
                Console.WriteLine("1 - Clientes");
                Console.WriteLine("2 - Produtos");
                Console.WriteLine("3 - Vendas");
                Console.WriteLine("4 - Sair");

                string opcaoMenu = Console.ReadLine();

                switch (opcaoMenu)
                {
                    case "1":
                        Console.WriteLine("Selecione uma opção:");
                        Console.WriteLine("1 - Listar clientes");
                        Console.WriteLine("2 - Lista cliente por Id");
                        Console.WriteLine("3 - Adicionar cliente");
                        Console.WriteLine("4 - Atualizar cliente");
                        Console.WriteLine("5 - Remover cliente");
                        Console.WriteLine("6 - Sair");

                        string opcaoCliente = Console.ReadLine();

                        switch (opcaoCliente)
                        {
                            case "1":
                                ListarClientes();
                                break;
                            case "2":
                                ListarClientePorId();
                                break;
                            case "3":
                                AdicionarCliente();
                                break;
                            case "4":
                                AtualizarCliente();
                                break;
                            case "5":
                                RemoverCliente();
                                break;
                            case "6":
                                return;
                            default:
                                Console.WriteLine("Opção inválida. Por favor, selecione novamente.");
                                break;
                        }

                        static void ListarClientes()
                        {
                            var clientes = clienteRepository.GetAll();
                            Console.WriteLine("Clientes:");
                            foreach (var cliente in clientes)
                            {
                                Console.WriteLine($"ID: {cliente.Id}, Nome: {cliente.Nome}, Email: {cliente.Email}, Telefone: {cliente.Telefone}, Endereço: {cliente.Endereco}");
                            }
                        }

                        static void ListarClientePorId()
                        {
                            Console.WriteLine("Digite o ID do cliente que deseja Listar:");
                            int idCliente = int.Parse(Console.ReadLine());
                            var cliente = clienteRepository.GetById(idCliente);
                            Console.WriteLine($"ID: {cliente.Id}, Nome: {cliente.Nome}, Email: {cliente.Email}, Telefone: {cliente.Telefone}, Endereço: {cliente.Endereco}");
                        }

                        static void AdicionarCliente()
                        {
                            Console.WriteLine("Digite o nome do cliente:");
                            string Nome = Console.ReadLine();

                            Console.WriteLine("Digite o email do cliente:");
                            string Email = Console.ReadLine();

                            Console.WriteLine("Digite o telefone do cliente:");
                            string Telefone = Console.ReadLine();

                            Console.WriteLine("Digite o endereço do cliente:");
                            string Endereco = Console.ReadLine();

                            var novoCliente = new Cliente
                            {
                                Nome = Nome,
                                Email = Email,
                                Telefone = Telefone,
                                Endereco = Endereco
                            };

                            clienteRepository.Save(novoCliente);

                            Console.WriteLine("Cliente adicionado com sucesso!");
                        }

                        static void AtualizarCliente()
                        {
                            Console.WriteLine("Digite o ID do cliente que deseja atualizar:");
                            int idCliente = int.Parse(Console.ReadLine());

                            var cliente = clienteRepository.GetById(idCliente);
                            if (cliente != null)
                            {
                                Console.WriteLine("Digite o novo nome do cliente:");
                                string novoNome = Console.ReadLine();

                                Console.WriteLine("Digite o novo email do cliente:");
                                string novoEmail = Console.ReadLine();

                                Console.WriteLine("Digite o novo telefone do cliente:");
                                string novoTelefone = Console.ReadLine();

                                Console.WriteLine("Digite o novo endereço do cliente:");
                                string novoEndereco = Console.ReadLine();

                                cliente.Nome = novoNome;
                                cliente.Email = novoEmail;
                                cliente.Telefone = novoTelefone;
                                cliente.Endereco = novoEndereco;

                                clienteRepository.Update(cliente);

                                Console.WriteLine("Cliente atualizado com sucesso!");
                            }
                            else
                            {
                                Console.WriteLine("Cliente não encontrado.");
                            }
                        }

                        static void RemoverCliente()
                        {
                            Console.WriteLine("Digite o ID do cliente que deseja remover:");
                            int idCliente = int.Parse(Console.ReadLine());

                            bool removido = clienteRepository.Delete(idCliente);
                            if (removido)
                            {
                                Console.WriteLine("Cliente removido com sucesso!");
                            }
                            else
                            {
                                Console.WriteLine("Cliente não encontrado.");
                            }
                        }
                        break;

                    case "2":
                        Console.WriteLine("Selecione uma opção:");
                        Console.WriteLine("1 - Listar produtos");
                        Console.WriteLine("2 - Lista produto por Id");
                        Console.WriteLine("3 - Adicionar produto");
                        Console.WriteLine("4 - Atualizar produto");
                        Console.WriteLine("5 - Atualizar estoque");
                        Console.WriteLine("6 - Remover produto");
                        Console.WriteLine("7 - Sair");

                        string opcaoProduto = Console.ReadLine();

                        switch (opcaoProduto)
                        {
                            case "1":
                                ListarProdutos();
                                break;
                            case "2":
                                ListarProdutoPorId();
                                break;
                            case "3":
                                AdicionarProduto();
                                break;
                            case "4":
                                AtualizarProduto();
                                break;
                            case "5":
                                AtualizarEstoqueProduto();
                                break;
                            case "6":
                                RemoverProduto();
                                break;
                            case "7":
                                return;
                            default:
                                Console.WriteLine("Opção inválida. Por favor, selecione novamente.");
                                break;
                        }

                        static void ListarProdutos()
                        {
                            var produtos = produtoRepository.GetAll();
                            Console.WriteLine("Produtos:");
                            foreach (var produto in produtos)
                            {
                                Console.WriteLine($"ID: {produto.Id}, Nome: {produto.Nome}, Preço: R$ {produto.Preco},00, Estoque: {produto.Estoque}");
                            }
                        }

                        static void ListarProdutoPorId()
                        {
                            Console.WriteLine("Digite o ID do produto que deseja Listar:");
                            int idProduto = int.Parse(Console.ReadLine());
                            var produto = produtoRepository.GetById(idProduto);
                            Console.WriteLine($"ID: {produto.Id}, Nome: {produto.Nome}, Preço: R$ {produto.Preco},00, Estoque: {produto.Estoque}");
                        }

                        static void AdicionarProduto()
                        {
                            Console.WriteLine("Digite o nome do produto:");
                            string nome = Console.ReadLine();

                            Console.WriteLine("Digite o preço do produto:");
                            double preco = double.Parse(Console.ReadLine());

                            var novoProduto = new Produto
                            {
                                Nome = nome,
                                Preco = preco
                            };

                            produtoRepository.Save(novoProduto);

                            Console.WriteLine("Produto adicionado com sucesso!");
                        }

                        static void AtualizarProduto()
                        {
                            Console.WriteLine("Digite o ID do produto que deseja atualizar:");
                            int idProduto = int.Parse(Console.ReadLine());

                            var produto = produtoRepository.GetById(idProduto);
                            if (produto != null)
                            {
                                Console.WriteLine($"Digite o novo nome para o produto {produto.Nome}:");
                                string novoNome = Console.ReadLine();

                                Console.WriteLine($"Digite o novo preço para o produto {produto.Nome}, R$ {produto.Preco},00 :");
                                double novoPreco = double.Parse(Console.ReadLine());

                                produto.Nome = novoNome;
                                produto.Preco = novoPreco;

                                produtoRepository.Update(produto);

                                Console.WriteLine("Produto atualizado com sucesso!");
                            }
                            else
                            {
                                Console.WriteLine("Produto não encontrado.");
                            }
                        }

                        static void AtualizarEstoqueProduto()
                        {
                            Console.WriteLine("Digite o ID do produto que deseja atualizar Estoque:");
                            int idProduto = int.Parse(Console.ReadLine());

                            var produto = produtoRepository.GetById(idProduto);
                            if (produto != null)
                            {
                                Console.Write($"Produto: {produto.Nome}, Estoque atual: {produto.Estoque} itens.\nDigite o novo estoque:");
                                int novoEstoque = int.Parse(Console.ReadLine());

                                produto.Estoque = novoEstoque;

                                produtoRepository.Update(produto);

                                Console.WriteLine("Estoque atualizado com sucesso!");
                            }
                            else
                            {
                                Console.WriteLine("Produto não encontrado.");
                            }
                        }

                        static void RemoverProduto()
                        {
                            Console.WriteLine("Digite o ID do produto que deseja remover:");
                            int idProduto = int.Parse(Console.ReadLine());

                            bool removido = produtoRepository.Delete(idProduto);
                            if (removido)
                            {
                                Console.WriteLine("Produto removido com sucesso!");
                            }
                            else
                            {
                                Console.WriteLine("Produto não encontrado.");
                            }
                        }
                        break;
                    case "3":
                        Console.WriteLine("Selecione uma opção:");
                        Console.WriteLine("1 - Listar vendas");
                        Console.WriteLine("2 - Adicionar venda");
                        Console.WriteLine("3 - Sair");

                        string opcao = Console.ReadLine();

                        switch (opcao)
                        {
                            case "1":
                                ListarVendas();
                                break;
                            case "2":
                                AdicionarVenda();
                                break;
                            case "3":
                                return;
                            default:
                                Console.WriteLine("Opção inválida. Por favor, selecione novamente.");
                                break;
                        }

                        static void ListarVendas()
                        {
                            var vendas = vendaRepository.GetAll();
                            Console.WriteLine("Vendas:");
                            foreach (var venda in vendas)
                            {
                                Console.WriteLine($"Venda ID: {venda.Id}, Cliente: {venda.ClienteId}, Total: {venda.Total}, Data Hora: {venda.Data} ");
                            }
                        }

                        static void AdicionarVenda()
                        {
                            Console.Write("Digite o Id do Cliente: ");
                            int clienteId = int.Parse(Console.ReadLine());
                            Cliente cliente = clienteRepository.GetById(clienteId);
                            Venda venda = new Venda(cliente);

                            while (true)
                            {
                                try
                                {
                                    Console.Write("Digite o Id do Produto: ");
                                    int produtoId = int.Parse(Console.ReadLine());
                                    Produto produto = produtoRepository.GetById(produtoId);

                                    Console.Write("Digite a quantidade: ");
                                    int quantidade = int.Parse(Console.ReadLine());
                                    venda.AdicionarProduto(produto, quantidade);
                                }
                                catch (Exception ex)
                                {
                                    Console.WriteLine("Erro ao adicionar produto: " + ex.Message);
                                }

                                Console.Write("Deseja adicionar mais produtos? (S/N): ");
                                string opcao = Console.ReadLine();
                                if (opcao.ToUpper() != "S")
                                {
                                    break;
                                }
                            }
                            venda.EfetuarVenda();
                            vendaRepository.Save(venda);

                            Console.WriteLine($"Venda Id: {venda.Id}, Cliente: {venda.ClienteId}, Total: {venda.Total}");
                        }
                        break;
                    case "4":
                        return;
                    default:
                        Console.WriteLine("Opção inválida. Por favor, selecione novamente.");
                        break;
                }
            }
        }
    }
}