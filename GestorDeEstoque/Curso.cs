using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GestorDeEstoque
{
    [System.Serializable]
    internal class Curso : Produto, IEstoque
    {
        public string autor;
        private int vagas;

        public Curso(string nome , float preco, string autor)
        {
            this.nome = nome;
            this.preco = preco;
            this.autor = autor;
        }
        public void Exibir()
        {
            Console.WriteLine($"Nome: {nome}");
            Console.WriteLine($"Autor do Curso: {autor}");
            Console.WriteLine($"Preco: {preco}");
            Console.WriteLine($"Vagas Restantes: {vagas}");
            Console.WriteLine("------------------------------------------");
        }

        public void RegistrarEntrada()
        {
            Console.WriteLine($"Registrar entrada no estoque do curso: {nome}");
            Console.WriteLine("Quantidade a Qtd. de vagas que você quer registrar entrada: ");
            int entrada = int.Parse(Console.ReadLine());
            vagas += entrada;
            Console.WriteLine("Entrada Registrada");
            Console.ReadLine();
        }

        public void RegistrarSaida()
        {
            Console.WriteLine($"Registrar venda no estoque do curso: {nome}");
            Console.WriteLine("Quantidade a Qtd. de vagas que você quer registrar baixa: ");
            int entrada = int.Parse(Console.ReadLine());
            vagas -= entrada;
            Console.WriteLine("Baixa Registrada");
            Console.ReadLine();
        }
    }
}
