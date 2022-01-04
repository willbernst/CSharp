using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GestorDeEstoque
{
    [System.Serializable]
    internal class Ebook : Produto, IEstoque
    {
        public string autor;
        private int vendas;

        public Ebook(string nome, float preco, string autor)
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
            Console.WriteLine($"Numero de Vendas: {vendas}");
            Console.WriteLine("------------------------------------------");
        }

        public void RegistrarEntrada()
        {
            Console.WriteLine("Não é possivel dar entrada no estoque de um E-Book, pois se trata de um produto digital");
            Console.ReadLine();
        }

        public void RegistrarSaida()
        {
            Console.WriteLine($"Registrar venda do Ebook: {nome}");
            Console.WriteLine("Quantidade a Qtd. de vagas que você quer registrar a venda: ");
            int entrada = int.Parse(Console.ReadLine());
            vendas += entrada;
            Console.WriteLine("Venda Registrada");
            Console.ReadLine();
        }

    }
}
