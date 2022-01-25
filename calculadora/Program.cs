using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Calculadora
{
    internal class Program
    {
        enum Menu { Somar = 1, Subtrair, Dividir, Multiplicar, Potencia, Raiz, Sair }
        static void Main(string[] args)
        {
            bool escolheusair = false;
            while (!escolheusair)
            {
                Console.WriteLine("Calculadora em C#!! Selecione uma das opções a baixo: ");
                Console.WriteLine("1-Soma \n2-Subtracao \n3-Divisão \n4-Multiplicacao \n5-Potenciacao \n6-Raiz Quadrada \n7-Sair");

                Menu opcao = (Menu)int.Parse(Console.ReadLine()); //salvar o valor digitado, atribuir a var fazendo cast pra menu

                switch (opcao)
                {
                    case Menu.Somar:
                        Somar();
                        break;
                    case Menu.Subtrair:
                        Subtrair();
                        break;
                    case Menu.Dividir:
                        Dividir();
                        break;
                    case Menu.Multiplicar:
                        Multiplicar();
                        break;
                    case Menu.Potencia:
                        Potencia();
                        break;
                    case Menu.Raiz:
                        Raiz();
                        break;
                    case Menu.Sair:
                        escolheusair = true;
                        break;
                }
                Console.Clear();
            }
        }

        static void Somar()
        {
            Console.WriteLine("Soma de dois numeros!");
            Console.WriteLine("Digite o primeiro numero: ");
            int a = int.Parse(Console.ReadLine());
            Console.WriteLine("Digite o segundo numero: ");
            int b = int.Parse(Console.ReadLine());
            int resultado = a + b;
            Console.WriteLine($"A soma dos dois valores informados é: {resultado}");

            Console.WriteLine("Pressione enteder para retornar ao menu!");
            Console.ReadLine();
        }

        static void Subtrair()
        {
            Console.WriteLine("Subtração de dois numeros!");
            Console.WriteLine("Digite o primeiro numero: ");
            int a = int.Parse(Console.ReadLine());
            Console.WriteLine("Digite o segundo numero: ");
            int b = int.Parse(Console.ReadLine());
            int resultado = a - b;
            Console.WriteLine($"A subtração dos dois valores informados é: {resultado}");

            Console.WriteLine("Pressione enteder para retornar ao menu!");
            Console.ReadLine();
        }

        static void Dividir()
        {
            Console.WriteLine("Divisão de dois numeros!");
            Console.WriteLine("Digite o primeiro numero: ");
            int a = int.Parse(Console.ReadLine());
            Console.WriteLine("Digite o segundo numero: ");
            int b = int.Parse(Console.ReadLine());
            float resultado = (float)a / (float)b;
            Console.WriteLine($"A divisão dos dois valores informados é: {resultado}");

            Console.WriteLine("Pressione enteder para retornar ao menu!");
            Console.ReadLine();
        }

        static void Multiplicar()
        {
            Console.WriteLine("Multiplicação de dois numeros!");
            Console.WriteLine("Digite o primeiro numero: ");
            int a = int.Parse(Console.ReadLine());
            Console.WriteLine("Digite o segundo numero: ");
            int b = int.Parse(Console.ReadLine());
            int resultado = a * b;
            Console.WriteLine($"A multiplicação dos dois valores informados é: {resultado}");

            Console.WriteLine("Pressione enteder para retornar ao menu!");
            Console.ReadLine();
        }

        static void Potencia()
        {
            Console.WriteLine("Potência de dois numeros!");
            Console.WriteLine("Digite a base: ");
            int basenumerica = int.Parse(Console.ReadLine());
            Console.WriteLine("Digite o expoente: ");
            int expoente = int.Parse(Console.ReadLine());
            int resultado = (int)Math.Pow(basenumerica, expoente);
            Console.WriteLine($"A multiplicação dos dois valores informados é: {resultado}");

            Console.WriteLine("Pressione enteder para retornar ao menu!");
            Console.ReadLine();
        }

        static void Raiz()
        {
            Console.WriteLine("Raiz Quadrada de um numero!");
            Console.WriteLine("Digite o numero: ");
            int a = int.Parse(Console.ReadLine());
            double resultado = Math.Sqrt(a);
            Console.WriteLine($"A raiz quadrada do numero informado ({a}) é: {resultado}");

            Console.WriteLine("Pressione enteder para retornar ao menu!");
            Console.ReadLine();
        }
    }
}
