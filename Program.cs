using System;

namespace DesafioModulo1
{
    internal class Program
    {
        static string[] Tarefas = new string[10];
        static bool[] Concluidas = new bool[10];
        static int QuantidadeTarefas = 0;
        static void Main(string[] args)
        {
            int Opcao = 0;
            do
            {
                Console.Clear();
                Console.WriteLine("1 - Adicionar nova tarefa");
                Console.WriteLine("2 - Listar todas as tarefas");
                Console.WriteLine("3 - Marcar tarefa como concluída");
                Console.WriteLine("4 - Sair");
                if (int.TryParse(Console.ReadLine(), out Opcao))
                {
                    Console.WriteLine();
                    switch (Opcao)
                    {
                        case 1:
                            AdicionarTarefa();
                            break;
                        case 2:
                            ListarTarefas();
                            break;
                        case 3:
                            MarcarComoConcluida();
                            break;
                        case 4:
                            Console.WriteLine("Saindo do sistema... Até logo!");
                            break;
                        default:
                            Console.WriteLine("Opção inválida! Pressione ENTER para tentar novamente.");
                            Console.ReadLine();
                            break;
                    }
                }
                else
                {
                    Console.WriteLine("\nPor favor, digite um número válido! Pressione ENTER para continuar.");
                    Console.ReadLine();
                }
            } while (Opcao != 4);
        }
        static void AdicionarTarefa()
        {
            if (QuantidadeTarefas >= 10)
            {
                Console.WriteLine("Limite de tarefas atingido! Não é possível adicionar mais.");
            }
            else
            {
                Console.Write("Digite o título da tarefa: ");
                string Titulo = Console.ReadLine();
                if (Titulo != "")
                {
                    Tarefas[QuantidadeTarefas] = Titulo;
                    Concluidas[QuantidadeTarefas] = false;
                    QuantidadeTarefas++;
                    Console.WriteLine("Tarefa adicionada com sucesso!");
                }
                else
                {
                    Console.WriteLine("O título da tarefa não pode ser vazio.");
                }
            }
            Pausar();
        }
        static void ListarTarefas()
        {
            if (QuantidadeTarefas == 0)
            {
                Console.WriteLine("Nenhuma tarefa cadastrada até o momento.");
            }
            else
            {
                Console.WriteLine("--- LISTA DE TAREFAS ---");
                for (int i = 0; i < QuantidadeTarefas; i++)
                {
                    string Status = Concluidas[i] ? "[Concluída]" : "[Pendente]";

                    Console.WriteLine($"{i + 1}. {Tarefas[i]} {Status}");
                }
            }
            Pausar();
        }
        static void MarcarComoConcluida()
        {
            if (QuantidadeTarefas == 0)
            {
                Console.WriteLine("Nenhuma tarefa cadastrada para concluir.");
            }
            else
            {
                Console.WriteLine("--- CONCLUIR TAREFA ---");
                for (int i = 0; i < QuantidadeTarefas; i++)
                {
                    string status = Concluidas[i] ? "[Concluída]" : "[Pendente]";
                    Console.WriteLine($"{i + 1}. {Tarefas[i]} {status}");
                }
                Console.Write("\nDigite o número da tarefa que deseja marcar como concluída: ");
                if (int.TryParse(Console.ReadLine(), out int NumeroTarefa))
                {
                    int Indice = NumeroTarefa - 1;
                    if (Indice >= 0 && Indice < QuantidadeTarefas)
                    {
                        Concluidas[Indice] = true;
                        Console.WriteLine($"A tarefa \"{Tarefas[Indice]}\" foi marcada como concluída!");
                    }
                    else
                    {
                        Console.WriteLine("Número de tarefa inválido.");
                    }
                }
                else
                {
                    Console.WriteLine("Entrada inválida.");
                }
            }
            Pausar();
        }
        static void Pausar()
        {
            Console.WriteLine("\nPressione ENTER para voltar ao menu...");
            Console.ReadLine();
        }
    }
}