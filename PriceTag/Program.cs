using PriceTag.Entities;
using System;
using System.Globalization;
using System.Collections.Generic;

namespace PriceTag
{
    class Program
    {
        static void Main(string[] args)
        {
            //Receber a quantidade de produtos
            Console.Write("Entre com a quantidade de produtos: ");
            int quantidadeProdutos = int.Parse(Console.ReadLine());

            //Criar lista de produtos
            List<Product> produtos = new List<Product>();

            //Receber os dados dos produtos
            for (int posicao = 0; posicao < quantidadeProdutos; posicao =posicao + 1)
            {
                //Receber os dados do produto
                Console.WriteLine($"Dados do {posicao + 1} produto: ");
                Console.Write("Novo, usado ou importado (n/u/i): ");
                char statusProduto = char.Parse(Console.ReadLine());
                Console.Write("Nome: ");
                string nome = Console.ReadLine();
                Console.Write("Preço: ");
                double preco = double.Parse(Console.ReadLine(), CultureInfo.InvariantCulture);

                //Adicionar na lista de acordo com o tipo
                if(statusProduto == 'i')
                {
                    //receber custo da importacao
                    Console.Write("Custo da importação: ");
                    double custoImportacao = double.Parse(Console.ReadLine(), CultureInfo.InvariantCulture);

                    //Adicionar na lista
                    produtos.Add(new ImportedProduct(nome, preco, custoImportacao));
                }

                else if(statusProduto == 'u')
                {
                    //receber data da facribacao
                    Console.Write("Data de fabricação (DD/MM/YYYY): ");

                    //Adicionar a lista
                    DateTime dataFabricacao = DateTime.Parse(Console.ReadLine());
                    produtos.Add(new UsedProduct(nome, preco, dataFabricacao));
                }

                else
                {
                    produtos.Add(new Product(nome, preco));
                }
            }

            //Mostrar os precos
            Console.WriteLine();
            Console.WriteLine("Preço dos produtos: ");
            foreach(Product obj in produtos)
            {
                Console.WriteLine(obj.PriceTag());
            }
        }
    }
}
