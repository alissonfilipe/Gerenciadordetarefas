using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace TreinandoBasico
{
     class ManipuladorDeTarefas
    {
        static int Tamanho { get; set; }
        static int indice { get; set; }

        static List<Tarefa> Tarefas = new List<Tarefa>();

        public void Menu()
        {
            Console.WriteLine("---------------------Menu-----------------------");
            Console.WriteLine("para ADICIONAR nova TAREFA digite 1");
            Console.WriteLine("para VISUALIZAR AS TAREFAS digite 2");
            Console.WriteLine("para ATUALIZAR uma tarefa digite 3");
            Console.WriteLine("para REMOVER uma tarefa digite 4");
            Console.WriteLine("------------------------------------------------");

        }
        public void Interacao()
        {
            int IntResposta;
            while (true)
            {
                Menu();
                string resposta = Console.ReadLine();
                if (int.TryParse(resposta, out IntResposta)){
                    if(IntResposta == 1)
                    {
                        Console.Write("Digite o título da tarefa:   ");
                        string tarefaTitulo = Console.ReadLine();
                        Console.Write("\nDigite a Descrição da tarefa:  ");
                        string descricaoTarefa = Console.ReadLine();
                        
                        DateTime datadevencimento;
                       
                        while (true)
                        {
                            Console.Write("\nDigite a data de vencimento da tarefa:  ");
                            string string_data_de_vencimento = Console.ReadLine();
                            if (DateTime.TryParse(string_data_de_vencimento, out datadevencimento))
                            {
                                break;
                            }else
                            {
                                Console.WriteLine("Digite uma data, tente novamente!");
                            }
                        }
                        Tarefa minhaTarefa = AdicionarNovaTarefa(tarefaTitulo, descricaoTarefa, datadevencimento);
                        Tarefas.Add(minhaTarefa);
                        
                    }
                    else if (IntResposta == 2)
                    {
                        VisualizarAsTarefas();
                    }
                    else if (IntResposta == 3)
                    {
                        AtualizarTarefa();
                    }
                    else if (IntResposta == 4)
                    {
                        ExcluirTarefa();
                    }
                    else
                    {
                        Console.WriteLine("Não temos essa opção, tente novamente!");
                    }

                }else
                {
                    Console.WriteLine("Resposta inválida, digite apenas os números das opções");
                }

                Console.WriteLine("Deseja continuar fazendo oprações??");
                Console.WriteLine("digite sim para continuar ");
                Console.WriteLine("se quiser finalizar digite qualquer palavra");
                string opResposta = Console.ReadLine();
                if (opResposta != "sim")
                {
                    Console.Clear();
                    break;
                }
                Console.Clear();
            }
            
            
            
        }

        static Tarefa AdicionarNovaTarefa(string titulo, string descricao, DateTime datadevencimento)
        {

            Tarefa tarefaAuxiliar = new Tarefa();
            
            tarefaAuxiliar.Titulo = titulo;
            tarefaAuxiliar.Descricao = descricao;
            tarefaAuxiliar.DataVencimento = datadevencimento;
            
            return tarefaAuxiliar;
        }

        static void VisualizarAsTarefas()
        {

            if (Tarefas.Count == 0)
            {
                Console.WriteLine("Não tem nenhuma tarefa, crie uma ou mais para visualizar!!!");
            }
            else
            {
                Console.WriteLine("Lista de Tarefas:");
                for (int i = 0; i < Tarefas.Count; i++)
                {
                    Console.WriteLine($"Título: {Tarefas[i].Titulo}");
                    Console.WriteLine($"Descrição: {Tarefas[i].Descricao}");
                    Console.WriteLine($"Data de Vencimento: {Tarefas[i].DataVencimento}");
                    Console.WriteLine("----------------------------------");
                    
                }
            }
            
        }

        static void ExcluirTarefa()
        {
            if (Tarefas.Count == 0)
            {
                
                Console.WriteLine("Não tem nehuma tarefa para ser removida!");
            }else
            {
                bool TarefaEncontrada = false;
                Console.WriteLine("DIGITE o TÍTULO da tarefa que você quer remover");
                string tarefaRemover = Console.ReadLine();
                for (int i = 0; i < Tarefas.Count; i++)
                {
                    if (Tarefas[i].Titulo == tarefaRemover)
                    {
                        TarefaEncontrada = true;
                        Console.WriteLine($"\nTAREFA {Tarefas[i].Titulo} REMOVIDA!!!! \n ");
                        Tarefas.RemoveAt(i);
                        break;
                    }
                }
                if (TarefaEncontrada == false)
                {
                    Console.WriteLine("A tarefa não foi encontrada \n TENTE NOVAMENTE E DIGITE CORRETAMENTE!!!!");
                }
            }
        }

        static void AtualizarTarefa()
        {
            bool tarefaModificada = false;
            Console.WriteLine("DIGITE O TÍTULO DA TAREFA QUE DESEJA ATUALIZAR");
            string tituloDaTarefa = Console.ReadLine();
            for (int i =0; i < Tarefas.Count; i++)
            {
                
                if (tituloDaTarefa == Tarefas[i].Titulo)
                {
                    
                    Console.WriteLine("Digite o novo Título");
                    string novoTitulo = Console.ReadLine();
                    Console.WriteLine("Digite a nova descrição");
                    string novaDescricao = Console.ReadLine();
                    Console.WriteLine("Digite a nova data de vencimento");
                    DateTime Novadatadevencimento;
                    Tarefas[i].Titulo = novoTitulo;
                    Tarefas[i].Descricao = novaDescricao;

                    while (true)
                    {

                        Console.Write("\nDigite a data de vencimento da tarefa:  ");
                        string string_data_de_vencimento = Console.ReadLine();
                        if (DateTime.TryParse(string_data_de_vencimento, out Novadatadevencimento))
                        {
                            Tarefas[i].DataVencimento = Novadatadevencimento;
                            tarefaModificada = true;
                            break;
                        }
                        else
                        {
                            Console.WriteLine("Digite uma data, tente novamente!");
                        }
                    }
                    


                }
                if (tarefaModificada == true)
                {
                    Console.WriteLine("Tarefa modificada com sucesso!");
                    break;
                }
            }
            if (tarefaModificada == false)
            {
                Console.WriteLine("A tarefa não foi encontrada! \ntente novamente");
            }
        }

    }
}
 