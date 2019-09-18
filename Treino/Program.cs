using System;
using System.Collections.Generic;
using System.IO;

//Código para praticar

namespace Treino
{
    class Program
    {
        static string endereco = @"C:\Users\Lucas Gabriel\Documents\C#\Funcionário\Teste.txt";
        static List<Trabalho> empregado = new List<Trabalho>();
        static void Main(string[] args)
        {
            Menu();
        }
        public static void Menu()
        {
            do
            {
                Console.Clear();
                Console.ForegroundColor = ConsoleColor.Yellow;
                DateTime agora = DateTime.Now;
                Console.WriteLine("                                                          último acesso: {0}",agora);
                Console.ResetColor();
                Console.BackgroundColor = ConsoleColor.White;
                Console.ForegroundColor = ConsoleColor.Blue;
                Console.WriteLine("--------------Menu Funcionário--------------\n");
                Console.ResetColor();
                Console.WriteLine("Selecione uma das opções abaixo:");
                Console.WriteLine("....................................");
                Console.WriteLine("\n(1) - Cadastrar");
                Console.WriteLine("(2) - Alterar");
                Console.WriteLine("(3) - Apagar");
                Console.WriteLine("(4) - Consultar");
                Console.WriteLine("(5) - Salário");
                Console.WriteLine("(6) - Abrir arquivo salvo");
                Console.WriteLine("(7) - Salvar");
                Console.WriteLine("(8) - Ver todos os funcionários\n");
                Console.WriteLine("....................................\n");
                try
                {
                    int escolha = int.Parse(Console.ReadLine());
                    switch (escolha)
                    {
                        case 1:
                            Cadastro();
                            break;
                        case 2:
                            Alterar();
                            break;
                        case 3:
                            Remover();
                            break;
                        case 4:
                            Consultar();
                            break;
                        case 5:
                            Aumento();
                            break;
                        case 6:
                            AbrirArquivo();
                            break;
                        case 7:
                            Salvar();
                            break;
                        case 8:
                            Exibir();
                            break;
                        default:
                            Console.ForegroundColor = ConsoleColor.Red;
                            Console.WriteLine("\nEssa opção não existe! \n");
                            Console.ResetColor();
                            break;
                    }
                }
                catch
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine("\nInforme apenas números! \n");
                    Console.ResetColor();
                }
                Console.WriteLine("Deseja continuar no programa? Digite: S p/ sim \n");
            } while (Console.ReadLine().ToUpper() == "S") ; 
        }
        public static void Cadastro()
        {
            try
            {
                Console.Clear();
                Console.Write("Informe a quantidade de empregados a serem cadastrados: ");
                int n = int.Parse(Console.ReadLine());
                for (int i = 1; i <= n; i++)
                {
                    Console.Clear();
                    Console.Write("\n\n" + i + "º Empregado\n");
                    Console.Write("\nInforme o ID do funcionário: ");
                    int id = int.Parse(Console.ReadLine());
                    Console.Write("Informe o nome: ");
                    string nome = Console.ReadLine();
                    while(nome.Length <= 1)
                    {
                        Console.Clear();
                        Console.ForegroundColor = ConsoleColor.Red;
                        Console.WriteLine("Informe um nome válido, com no mínimo 2 letras!\n");
                        Console.ResetColor();
                        Console.Write("Informe o nome: ");
                        nome = Console.ReadLine();
                    }
                    Console.Write("Informe o salário: ");
                    double salario = double.Parse(Console.ReadLine());
                    DateTime horario = DateTime.Now;
                    empregado.Add(new Trabalho(id, nome, salario, horario));
                }
            }
            catch
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("\nInsira as informações corretamente! \n\n");
                Console.ResetColor();
                Console.ReadKey();
                Console.Clear();
                Cadastro();
            }
        }
        public static void Alterar()
        {
            Console.Clear();
            if (empregado.Count > 0)
            {
                Console.WriteLine("Digite o numero para edição: ");
                int contador = 0;
                foreach (Trabalho usuario in empregado)
                {
                    contador++;
                    Console.WriteLine("{0} - {1}", contador, usuario);
                }
                int num = int.Parse(Console.ReadLine());
                if (num >= 0)
                {
                    Console.WriteLine("Informe os dados para alteração");
                    Console.WriteLine("Informe o ID do funcionário: ");
                    empregado[num - 1].Id = int.Parse(Console.ReadLine());
                    Console.WriteLine("Informe o nome: ");
                    empregado[num - 1].Nome = Console.ReadLine();
                    Console.WriteLine("Informe o salário: ");
                    empregado[num - 1].Salario = double.Parse(Console.ReadLine());
                    empregado[num -  1].Tempo = DateTime.Now;
                    Console.ForegroundColor = ConsoleColor.Green;
                    Console.WriteLine("\nAlteração feita com sucesso! \n");
                    Console.ResetColor();
                }
                else
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine("Informe um número existente! \n");
                    Console.ResetColor();
                    Console.ReadKey();
                    Console.Clear();
                    Alterar();
                }
            }
            else
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("Não há pessoas cadastradas! \n");
                Console.ResetColor();
            }
        }
        static void Remover()
        {
            Console.Clear();
            if (empregado.Count > 0)
            {
                Console.WriteLine("Digite o número para Exclusão\n");
                int contador = 0;
                foreach (Trabalho usuario in empregado)
                {
                    contador++;
                    Console.WriteLine("{0} - {1}", contador, usuario);
                }
                int num = int.Parse(Console.ReadLine());
                empregado.Remove(empregado[num - 1]);
                Console.WriteLine("\nExclusão feita com sucesso! \n");
            }
            else
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("\nNão há pessoas cadastradas! \n");
                Console.ResetColor();
            }
        }
        public static void Consultar()
        {
            Console.Clear();
            Console.Write("Informe o nome do funcionário a ser encontrado: ");
            string nome = Console.ReadLine();
            bool encontrado = false;
            foreach (Trabalho usuario in empregado)
            {
                if (usuario.Nome.ToLower().Contains(nome.ToLower()))
                {
                    Console.WriteLine(usuario);
                    encontrado = true;
                }
            }
            if (!encontrado)
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("\nPessoa não encontrada! \n");
                Console.ResetColor();
            }
        }
        public static void Aumento()
        {
            Console.Clear();
            if (empregado.Count > 0)
            {
                Console.WriteLine("Digite o numero para edição: ");
                int contador = 0;
                foreach (Trabalho usuario in empregado)
                {
                    contador++;
                    Console.WriteLine("{0} - {1}", contador, usuario);
                }
                int num = int.Parse(Console.ReadLine());
                if (num >= 0 && num < empregado.Count)
                {
                    Console.WriteLine("Informe o novo salário: ");
                    empregado[num - 1].Salario = double.Parse(Console.ReadLine());
                    Console.ForegroundColor = ConsoleColor.Green;
                    Console.WriteLine("\nAlteração feita com sucesso! \n");
                    Console.ResetColor();
                }
                else
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine("Não há nenhum cadastro referente a esse número! ");
                    Console.ResetColor();
                }
            }
            else
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("\nNão há pessoas cadastradas! \n");
                Console.ResetColor();
            }
        }
        public static void AbrirArquivo()
        {
            string[] linhas = File.ReadAllLines(endereco);
            foreach (string linha in linhas)
            {
                string[] parte = linha.Split(" - ");
                int id = int.Parse(parte[0]);
                string nome = parte[1];
                double salario = double.Parse(parte[2]);
                DateTime horario = DateTime.Parse(parte[3]);

                empregado.Add(new Trabalho(id, nome, salario, horario));
            }
        }
        public static void Salvar()
        {
            StreamWriter sw = new StreamWriter(endereco);
            foreach(Trabalho trabalho in empregado)
            {
                sw.WriteLine("{0} - {1} - {2} - {3}", trabalho.Id,trabalho.Nome, trabalho.Salario, trabalho.Tempo);
            }
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine("Arquivo salvo com sucesso! \n");
            Console.ResetColor();
            sw.Close();
        }
        public static void Exibir()
        {
            Console.Clear();
            if (empregado.Count > 0)
            {
                empregado.Sort((p1, p2) => p1.Nome.ToUpper().CompareTo(p2.Nome.ToUpper()));
                foreach (Trabalho obj in empregado)
                {
                    Console.ForegroundColor = ConsoleColor.Green;
                    Console.WriteLine(obj);
                }
                Console.WriteLine("\nTotal de cadastros: {0}\n", empregado.Count);
                Console.ResetColor();
            }
            else
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("\nNão há pessoas cadastradas! \n");
                Console.ResetColor();
            }
        }
    }
}