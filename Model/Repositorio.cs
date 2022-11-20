using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SQLite;

namespace Projeto_Agenda.Model
{
    public class Repositorio
    {
        SQLiteConnection conexao;  
        
        public Repositorio ()
        {
            string caminho = Path.Join(FileSystem.AppDataDirectory, "banco.db");

            conexao = new(caminho);
            //conexao.Execute("CREATE TABLE IF NOT EXISTS lista (item TEXT)");
            conexao.CreateTable<ItemLista>();
        }

        public IEnumerable<ItemLista> GetItems()
        {
            return conexao.Table<ItemLista>();
        }

        public int Inserir(ItemLista item)
        {
            try
            {
                return conexao.Insert(item);
            }
            catch
            {
                return 0;
            }

        }

        public void Delete(ItemLista item)
        {
            conexao.Delete(item);
        }
    }

}
