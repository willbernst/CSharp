using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GestorDeEstoque
{
    [System.Serializable]
    internal class ProdutoFisico : Produto, IEstoque
    {
        public float frete;
        private int estoque;

        public ProdutoFisico(string nome, float preco, float frete)
        {
            this.nome = nome;
            this.preco = preco;
            this.frete = frete;
        }
        public void Exibir()
        {
            Console.WriteLine($"Nome: {nome}");
            Console.WriteLine($"Frete: {frete}");
            Console.WriteLine($"Preco: {preco}");
            Console.WriteLine($"Quantidade em estoque: {estoque}");
            Console.WriteLine("------------------------------------------");
        }

        public void RegistrarEntrada()
        {
            Console.WriteLine($"Registrar entrada no estoque do produto: {nome}");
            Console.WriteLine("Quantidade a Qtd. que você quer dar entrada: ");
            int entrada = int.Parse(Console.ReadLine());
            estoque += entrada;
            Console.WriteLine("Entrada Registrada");
            Console.ReadLine();
        }

        public void RegistrarSaida()
        {
            Console.WriteLine($"Registrar saida no estoque do produto: {nome}");
            Console.WriteLine("Quantidade a Qtd. que você quer dar baixa: ");
            int entrada = int.Parse(Console.ReadLine());
            estoque -= entrada;
            Console.WriteLine("Saida Registrada");
            Console.ReadLine();
        }
    }
}
