using System;
using System.Collections.Generic;

class Program
{
    static List<Produto> inventario = new List<Produto>();

    static void Main(string[] args)
    {
        bool continuar = true;

        while (continuar)
        {
            Console.WriteLine("=== Sistema de Gerenciamento de Produtos ===");
            Console.WriteLine("1. Adicionar Produto");
            Console.WriteLine("2. Remover Produto pelo ID");
            Console.WriteLine("3. Editar Nome do Produto pelo ID");
            Console.WriteLine("4. Visualizar Todos os Produtos");
            Console.WriteLine("5. Sair");
            Console.Write("Escolha uma opção: ");

            string opcao = Console.ReadLine();

            switch (opcao)
            {
                case "1":
                    AdicionarProduto();
                    break;
                case "2":
                    RemoverProduto();
                    break;
                case "3":
                    EditarNomeProduto();
                    break;
                case "4":
                    VisualizarProdutos();
                    break;
                case "5":
                    continuar = false;
                    break;
                default:
                    Console.WriteLine("Opção inválida. Tente novamente.");
                    break;
            }

            Console.WriteLine();
        }
    }

    static void AdicionarProduto()
    {
        Console.Write("Informe o nome do produto: ");
        string nome = Console.ReadLine();

        Produto produto = new Produto
        {
            Id = inventario.Count + 1,
            Nome = nome
        };

        inventario.Add(produto);
        Console.WriteLine("Produto adicionado com sucesso!");
    }

    static void RemoverProduto()
    {
        Console.Write("Informe o ID do produto que deseja remover: ");
        if (int.TryParse(Console.ReadLine(), out int id))
        {
            Produto produto = inventario.Find(p => p.Id == id);
            if (produto != null)
            {
                inventario.Remove(produto);
                Console.WriteLine("Produto removido com sucesso!");
            }
            else
            {
                Console.WriteLine("Produto não encontrado.");
            }
        }
        else
        {
            Console.WriteLine("ID inválido. Tente novamente.");
        }
    }

    static void EditarNomeProduto()
    {
        Console.Write("Informe o ID do produto que deseja editar: ");
        if (int.TryParse(Console.ReadLine(), out int id))
        {
            Produto produto = inventario.Find(p => p.Id == id);
            if (produto != null)
            {
                Console.Write("Novo nome do produto: ");
                string novoNome = Console.ReadLine();
                produto.Nome = novoNome;
                Console.WriteLine("Nome do produto editado com sucesso!");
            }
            else
            {
                Console.WriteLine("Produto não encontrado.");
            }
        }
        else
        {
            Console.WriteLine("ID inválido. Tente novamente.");
        }
    }

    static void VisualizarProdutos()
    {
        Console.WriteLine("Lista de Produtos:");
        foreach (Produto produto in inventario)
        {
            Console.WriteLine($"ID: {produto.Id}, Nome: {produto.Nome}");
        }
    }
}

class Produto
{
    public int Id { get; set; }
    public string Nome { get; set; }
}
