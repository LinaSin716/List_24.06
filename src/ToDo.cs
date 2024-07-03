using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace List_24._06.src
{
    public class ToDo
    {
        public string Title { get; set; }
        public DateTime Date { get; set; }
        public string Description { get; set; }

        public ToDo() { }
        public ToDo(string title, DateTime date, string description) 
        { 
            Title = title;
            Date = date;
            Description = description;
        }
    }
}
