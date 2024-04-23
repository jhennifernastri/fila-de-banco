using System;
using System.Collections.Generic;
using System.Linq;


namespace ProvaQuestao3
{
    internal class Program
    {
        static void Main(string[] args)
        {


            Console.WriteLine("");
            const int COMUM = 1, PRIORITARIO = 2, ATENDIMENTO = 3, ENCERRAMENTO = 4, IMPRIMIR = 5, OPCAOINVALIDA = int.MinValue;

            Console.WriteLine("--Bem vindo ao programa Gerenciador de senhas--\n");

            Queue<int> filaComum = new Queue<int>();
            Queue<int> filaPrioritaria = new Queue<int>();
            int opcao;

            do
            {
                Console.WriteLine($"{COMUM}- Imprimir senha comum");
                Console.WriteLine($"{PRIORITARIO}- Imprimir senha prioritaria");
                Console.WriteLine($"{ATENDIMENTO}- Chamar o nome do cliente");
                Console.WriteLine($"{ENCERRAMENTO}- Sair do programa");
                Console.WriteLine($"{IMPRIMIR}- Visualização da fila\n");

                Console.Write("Informe uma opção do menu:");
                opcao = int.Parse(Console.ReadLine());

                switch (opcao)
                {
                    case COMUM:
                        Console.WriteLine("Por favor, retire sua senha:");
                        Console.WriteLine("\nATENDIMENTO COMUM:");
                        filaComum.Enqueue(filaComum.Count + 1);
                        Console.WriteLine(filaComum.Count + "C");
                        Console.WriteLine("\nCliente adicionado com sucesso!");
                        break;
                    case PRIORITARIO:
                        Console.WriteLine("Por favor, retire sua senha:");
                        Console.WriteLine("\nATENDIMENTO PRIORITÁRIO:");
                        filaPrioritaria.Enqueue(filaPrioritaria.Count + 1);
                        Console.WriteLine(filaPrioritaria.Count + "P");
                        Console.WriteLine("\nCliente adicionado com sucesso!");
                        break;
                    case ATENDIMENTO:
                        if (filaPrioritaria.Count > 0)
                        {
                            Console.WriteLine("ATENDIMENTO PRIORITÁRIO:");
                            Console.WriteLine($"Próximo cliente: {filaPrioritaria.Dequeue()}" + "P");
                        }
                        else
                        {
                            if (filaComum.Count > 0)
                            {
                                Console.WriteLine("ATENDIMENTO COMUM:");
                                Console.WriteLine($"Próximo cliente: {filaComum.Dequeue()}" + "C");
                            }
                            else
                                Console.WriteLine("Fila Vazia");
                        }
                        break;
                    case ENCERRAMENTO:
                        if (filaPrioritaria.Count == 0 && filaComum.Count == 0)
                            Console.WriteLine("Saindo do programa");
                        else
                        {
                            Console.WriteLine("Programa não pode ser encerrado, pois existem clientes na fila");
                            opcao = OPCAOINVALIDA;
                        }
                        break;
                    case IMPRIMIR:
                        if (filaPrioritaria.Count > 0)
                        {
                            Console.WriteLine("ATENDIMENTO PRIORITÁRIO:");
                            foreach (var senha in filaPrioritaria)
                            {
                                Console.WriteLine($"--{senha + "P"}");
                            }
                        }
                        if (filaComum.Count > 0)
                        {
                            Console.WriteLine("ATENDIMENTO COMUM:");
                            foreach (var senha1 in filaComum)
                            {
                                Console.WriteLine($"--{senha1 + "C"}");
                            }
                        }
                        else
                            Console.WriteLine("Não há clientes na fila.");
                        break;
                    default:
                        Console.WriteLine("Opção inválida");
                        break;
                }

                Console.WriteLine("Pressione ENTER para continuar");
                Console.ReadLine();
                Console.Clear();

            } while (opcao != ENCERRAMENTO);

            Console.WriteLine("Banco Fechou... Pressione ENTER para encerrar");
            Console.ReadLine();


        }
    }
}
