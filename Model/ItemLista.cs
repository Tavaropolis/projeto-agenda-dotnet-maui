using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SQLite;

namespace Projeto_Agenda.Model
{
    public class ItemLista
    {
        [PrimaryKey, AutoIncrement]
        public int Id { get; set; }
        [Unique]
        public string Item { get; set; }
        public DateTime Horario { get; set; }
    }
}
