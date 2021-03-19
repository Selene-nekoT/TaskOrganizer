using System;
using System.IO;

namespace TaskOrganizer
{

    class Program
    {
        //Registro del TaskManager nel Main
        static private TaskManager _tasks = new TaskManager();

        static void Main(string[] args)
        {
            Console.WriteLine("WELCOME TO TASK ORGANIZER");
            Console.WriteLine("Choose an option");

            do
            {
                Console.WriteLine("\n1.Add new Task");
                Console.WriteLine("2.Visualize all Tasks");
                Console.WriteLine("3.Erase a single Task");
                Console.WriteLine("4.Filter Tasks for importance");

                Console.WriteLine("0.Exit");

                switch (Console.ReadKey().KeyChar)
                {
                    case '1':
                        AddTask();
                        break;
                    case '2':
                        VisualizeTasks();
                        break;
                    case '3':
                        EraseTask();
                        break;
                    case '4':
                        FilterTasks();
                        break;
                    case '5':
                        SaveTasks();
                    break;
                    case '0':
                        return;
                    default:
                        Console.WriteLine("Invalid option");
                        break;
                }
            } while (true);
            

        }

     

        //AGGIUNTA di un TASK nuovo
        private static void AddTask()
        {
            Console.WriteLine("\nDescription of the Task: ");  //DESCRIZIONE
            string descrizione = Console.ReadLine();


            DateTime dataEvento;                               //DATA EVENTO
            do {
                do {                                              
                    Console.WriteLine("\nChoose a valid date for the Task: ");
                } while (!DateTime.TryParse(Console.ReadLine(), out dataEvento));

            } while(dataEvento<DateTime.Today);      //Controllo validità data
        
            //TODO: riuscire ad eliminare i secondi dalla data

            Console.WriteLine("\nImportance of the Task (1:Low,2:Medium,3:High): ");  //DESCRIZIONE
            string importanza="";
            switch (Console.ReadKey().KeyChar)
            {
                case '1':
                    importanza="Basso";
                    break;
                case '2':
                    importanza = "Medio";
                    break;
                case '3':
                    importanza = "Alto";
                    break;
                default:
                    Console.WriteLine("Invalid option");
                    break;
            }

            //Creo un nuovo task
            Task t = _tasks.AddTask(descrizione, dataEvento, importanza);

        }

        //VISUALIZZO tutti gli eventi
        private static void VisualizeTasks()
            {
                Console.WriteLine("\nThe Tasks that you saved: ");
                Console.WriteLine(_tasks.VisualizeTasks());
            }

        //ELIMINARE un Task inserito
        private static void EraseTask()
        {
            //Prima controllo se è valido il valore inserito, poi se esiste. if TRUE lo elimino
            int id;
            do
            {
                Console.WriteLine("\nChoose the task you want to cancel: ");
            } while (!int.TryParse(Console.ReadLine(), out id));


            if (_tasks.Exist(id))
            {
                _tasks.EraseTask(id);
                Console.WriteLine("Task erased successfully");
            }
            else
            {
                Console.WriteLine("Task not found");
            }
          
        }

        //FILTRO per IMPORTANZA
        private static void FilterTasks()
        {
            //Controllo validità valore
            int filter;
            do
            {
                Console.WriteLine("\nChoose the level of importance you want to filter by (1:Low,2:Medium,3:High, 4:All): ");
            } while (!int.TryParse(Console.ReadLine(), out filter));


            Console.WriteLine($"Tasks filtered by importance: {filter} :");
            Console.WriteLine(Filtro(filter));

        }

        //SALVA FILE: si è scelto di non sovrascrivere i task ma di accodarli 
        private static void SaveTasks()
        {
            const string fileName = "tasks.txt";
            using (StreamWriter sw = new StreamWriter(fileName,true)) 
            { 
                sw.WriteLine(_tasks.VisualizeTasks());
                sw.Close();
            }
        }



    }
}
