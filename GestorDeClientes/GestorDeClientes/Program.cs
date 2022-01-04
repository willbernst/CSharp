using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.Serialization.Formatters.Binary;
using System.Text;
using System.Threading.Tasks;

namespace GestorDeClientes
{
    internal class Program
    {
        [System.Serializable]
        struct Cliente
        {
            public string nome;
            public string email;
            public string cpf;
        }

        static List<Cliente> clientes = new List<Cliente>();
        enum Menu { Listar = 1, Adicionar, Remover, Sair }

        static void Main(string[] args)
        {
            LerDadosPersistidos();
            bool escolheuSair = false;
            while (!escolheuSair)
            {
                Console.WriteLine("Sistema de Clientes - Bem Vindo!!");
                Console.WriteLine("1-Listar Clientes\n2-Adiconar Cliente\n3-Remover Cliente\n4-Sair");

                int tc = int.Parse(Console.ReadLine());
                Menu opcaoSelecionada = (Menu)tc;

                switch (opcaoSelecionada)
                {
                    case Menu.Listar:
                        ListarClientes();
                        break;
                    case Menu.Adicionar:
                        AdicionarCliente();
                        break;
                    case Menu.Remover:
                        RemoverCliente();
                        break;
                    case Menu.Sair:
                        escolheuSair = true;
                        break;
                }
                Console.Clear();
            } 
        }

        static void AdicionarCliente()
        {
            Cliente cliente = new Cliente();
            Console.WriteLine("Cadastro de Cliente: ");
            Console.WriteLine("Nome do Cliente: ");
            cliente.nome = Console.ReadLine();
            Console.WriteLine("Email do Cliente: ");
            cliente.email = Console.ReadLine();
            Console.WriteLine("CPF do Cliente: ");
            cliente.cpf = Console.ReadLine();

            clientes.Add(cliente);
            PersistirDados();


            Console.WriteLine("CADASTRO CONCLUIDO, PRESSIONE ENTER PARA RETORNAR AO MENU!");
            Console.ReadLine();
        }

        static void RemoverCliente()
        {
            ListarClientesParaRemocao();
            Console.WriteLine("Digite o ID do cliente que deseja remover: ");
            int id = int.Parse(Console.ReadLine());
            if(id >= 0 && id < clientes.Count)
            {
                clientes.RemoveAt(id);
                PersistirDados();
            }
            else
            {
                Console.WriteLine("Verifique o id digitado e tente novamente!");
                Console.ReadLine();
            }
        }

        static void ListarClientes()
        {
            if(clientes.Count > 0)
            {
                Console.WriteLine("Lista de Clientes: ");
                int id = 0 ;
                foreach (Cliente cliente in clientes)
                {
                    Console.WriteLine($"ID: {id}");
                    Console.WriteLine($"Nome: {cliente.nome}");
                    Console.WriteLine($"Email: {cliente.email}");
                    Console.WriteLine($"CPF: {cliente.cpf}");
                    id++;
                    Console.WriteLine("-------------------------------------------");
                }
            }
            else
            {
                Console.WriteLine("Não há clientes cadastrados na base de dados! ");
            }

            Console.WriteLine("--- LISTAGEM FINALIZADA, PRESSIONE ENTER PARA RETORNAR AO MENU! ---");
            Console.ReadLine();
        }

        //Criada outra função para listagem de remoção, ja que nao precisamos de validação para listagem, nem informar o cliente do PRESS ENTER para retornar ao menu
        static void ListarClientesParaRemocao()
        {
            Console.WriteLine("Lista de Clientes: ");
            int id = 0;
            foreach (Cliente cliente in clientes)
            {
                Console.WriteLine($"ID: {id}");
                Console.WriteLine($"Nome: {cliente.nome}");
                Console.WriteLine($"Email: {cliente.email}");
                Console.WriteLine($"CPF: {cliente.cpf}");
                id++;
                Console.WriteLine("-------------------------------------------");
            }
        }

        static void PersistirDados()
        {
            FileStream stream = new FileStream("clientes.dat", FileMode.OpenOrCreate);
            BinaryFormatter decodificador = new BinaryFormatter();

            decodificador.Serialize(stream, clientes);

            stream.Close();
        }

        static void LerDadosPersistidos()
        {
            FileStream stream = new FileStream("clientes.dat", FileMode.OpenOrCreate);
            try
            {
                BinaryFormatter decodificador = new BinaryFormatter();

                clientes = (List<Cliente>)decodificador.Deserialize(stream);

                if(clientes == null)
                {
                    clientes = new List<Cliente>();
                }
            }
            catch (Exception exception)
            {
                Console.WriteLine(exception.Message);
                clientes = new List<Cliente>();
            }
            stream.Close();
        }
    }
}
