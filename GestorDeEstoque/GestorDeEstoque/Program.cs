using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;

namespace GestorDeEstoque
{
    internal class Program
    {
        static List<IEstoque> produtos = new List<IEstoque>();
        enum Menu { Listar = 1, AdicionarProduto, RemoverProduto, RegistrarEntrada, RegistrarSaida, Sair }
        static void Main(string[] args)
        {
            CarregarDados();
            bool escolheuSair = false;

            while(escolheuSair == false)
            {
                Console.WriteLine("Sistema de Estoque!");
                Console.WriteLine("1-Listar Produtos\n2-Adicionar Produto\n3-Remover Produto\n4-Registrar Entrada de Produto\n5-Registrar Saida de Produto\n6-Sair");
                string tc = Console.ReadLine();
                int convInt = int.Parse(tc);

                if(convInt > 0 && convInt < 7)
                {
                    Menu escolha = (Menu)convInt;
                    switch (escolha)
                    {
                        case Menu.Listar:
                            ListarDados();
                            break;
                        case Menu.AdicionarProduto:
                            CadastrarProduto();
                            break;
                        case Menu.RemoverProduto:
                            RemoverProduto();
                            break;
                        case Menu.RegistrarEntrada:
                            RegistrarEntrada();
                            break;
                        case Menu.RegistrarSaida:
                            RegistrarSaida();
                            break;
                        case Menu.Sair:
                            escolheuSair = true;
                            break;
                    }
                }
                else
                {
                    escolheuSair = true;
                }
                Console.Clear();
            }
        }

        static void PersistirDados()
        {
            FileStream stream = new FileStream("produtos.dat", FileMode.OpenOrCreate);
            BinaryFormatter decodificador = new BinaryFormatter();

            decodificador.Serialize(stream, produtos);

            stream.Close();
        }

        static void CarregarDados()
        {
            FileStream stream = new FileStream("produtos.dat", FileMode.OpenOrCreate);
            BinaryFormatter decodificador = new BinaryFormatter();

            try
            {
                produtos = (List<IEstoque>)decodificador.Deserialize(stream);
                if(produtos == null)
                {
                    produtos = new List<IEstoque>();
                }
            }
            catch(Exception ex)
            {   
                Console.WriteLine(ex.Message);
                produtos = new List<IEstoque>();
            }
            stream.Close();
        }

        static void ListarDados()
        {
            Console.WriteLine("Lista de Produtos");
            int id = 0;
            foreach(IEstoque produto in produtos)
            {
                Console.WriteLine("ID: " + id);
                produto.Exibir();
                id++;
            }
            Console.ReadLine();
        }

        static void RemoverProduto()
        {
            ListarDados();
            Console.WriteLine("Digite o ID do elemento que você quer remover: ");
            int id = int.Parse(Console.ReadLine());
            if(id >= 0 && id < produtos.Count)
            {
                produtos.RemoveAt(id);
                PersistirDados();
            }
        }

        static void RegistrarEntrada()
        {
            ListarDados();
            Console.WriteLine("Digite o ID do elemento que você quer registrar entrada: ");
            int id = int.Parse(Console.ReadLine());
            if (id >= 0 && id < produtos.Count)
            {
                produtos[id].RegistrarEntrada();
                PersistirDados();
            }
        }

        static void RegistrarSaida()
        {
            ListarDados();
            Console.WriteLine("Digite o ID do elemento que você quer registrar baixa/venda : ");
            int id = int.Parse(Console.ReadLine());
            if (id >= 0 && id < produtos.Count)
            {
                produtos[id].RegistrarSaida();
                PersistirDados();
            }
        }

        static void CadastrarProduto()
        {
            Console.WriteLine("Cadastro de Produto");
            Console.WriteLine("1-Produto Fisico\n2-Ebook\n3-Curso");
            string tc = Console.ReadLine();
            int convInt = int.Parse(tc);

            switch (convInt)
            {
                case 1:
                    CadastrarProdFisico();
                    break;
                case 2:
                    CadastrarEbook();
                    break;
                case 3:
                    CadastrarCurso();
                    break;
            }
        }

        static void CadastrarProdFisico()
        {
            Console.WriteLine("Cadastro de Produto Fisico");
            Console.WriteLine("Nome d Produto: ");
            string nome = Console.ReadLine();
            Console.WriteLine("Preço: ");
            float preco = float.Parse(Console.ReadLine());
            Console.WriteLine("Frete: ");
            float frete = float.Parse(Console.ReadLine());

            ProdutoFisico prodFisico = new ProdutoFisico(nome, preco, frete);
            produtos.Add(prodFisico);
            PersistirDados();
        }

        static void CadastrarEbook()
        {
            Console.WriteLine("Cadastro de Ebook");
            Console.WriteLine("Nome do Ebook: ");
            string nome = Console.ReadLine();
            Console.WriteLine("Preço: ");
            float preco = float.Parse(Console.ReadLine());
            Console.WriteLine("Autor: ");
            string autor = Console.ReadLine();

            Ebook ebook = new Ebook(nome, preco, autor);
            produtos.Add(ebook);
            PersistirDados();
        }

        static void CadastrarCurso()
        {
            Console.WriteLine("Cadastro de  Curso");
            Console.WriteLine("Nome do Curso: ");
            string nome = Console.ReadLine();
            Console.WriteLine("Preço: ");
            float preco = float.Parse(Console.ReadLine());
            Console.WriteLine("Autor: ");
            string autor = Console.ReadLine();

            Curso curso = new Curso(nome, preco, autor);
            produtos.Add(curso);
            PersistirDados();
        }
    }
}
