using System;
using System.Collections.Generic;
using System.Text;

namespace TaskOrganizer
{

    class TaskManager
    {
        //CREO un contenitore che conterrà tutti gli eventi inseriti
        internal Dictionary<int, Task> _tasks = new Dictionary<int, Task>();

        //CREA nuovo TASK
        public Task AddTask(string descrizione, DateTime dataEvento, string importanza)
        {
            Task t = new Task(descrizione, dataEvento, importanza);
            _tasks.Add(t.ID, t);
            return t;
        }

        //Visualizza i Task salvati
        public string VisualizeTasks()
        {
            string s = "";
            foreach (Task t in _tasks.Values)
            {
                string eventoSalvato = ($"Task with description: {t.Description}, on {t.Date_Task} has importance: {t.Importance}");
                s += eventoSalvato + '\n';
            }
            return s;
        }

        //Controllo esistenza ID
        public bool Exist(int id)
        {
            return _tasks.ContainsKey(id);
        }

        //Cancella il task con quello specifico ID
        public void EraseTask(int id)
        {
            _tasks.Remove(id);
        }

        //Filtraggio per importance: ricevo un INT
        //TODO: MANCA FILTRO da finire di implementare
       
        public string Filtro(string filtro) { 
            string s = "";
            foreach (Task t in _tasks.Values)
            {
                if (//importanzanel Dic == "Basso")
                    {
                    //concateno a s tutti i valori validi
                }
                else if (//importanzanel Dic == "Medio")
                    {
                    //concateno a s tutti i valori validi
                }
                else if (//importanzanel Dic == "Alto")
                    {
                    //concateno a s tutti i valori validi
                }
                else {
                    //concateno a s tutti i valori validi
                    //altra opzione, richiamo VisualizzaTasks
                }
                return s;
            }
        }

        public string ControlloFiltro(int filter)
        {
            string filtro = "";
            if (filter == 1)
            {
                filtro = "Basso";
            }
            else if (filter == 2)
            {
                filtro = "Medio";
            }
            else if (filter == 3)
            {
                filtro = "Alto";
            }
            return filtro;
        }
           



    }
}
