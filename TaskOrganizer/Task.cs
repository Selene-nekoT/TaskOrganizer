using System;
using System.Collections.Generic;

namespace TaskOrganizer
{

    class Task
    {

        //inserisco un id da associare ad ogni Task
        internal static int _ID;
        public int ID { get; }
        public string Description { get;}
        public DateTime Date_Task { get;}
        public string Importance { get; }

        public Task(string descrizione, DateTime dataEvento, string importanza)
        {
            Description = descrizione;
            Date_Task = dataEvento;
            Importance= importanza;
            ID = ++_ID;
        }



    }
}
