using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Agenda_Contatos
{
    public class Contato
    {
        public string Nome { get; set; } // prop tab tab
        public string Email { get; set; }
        public string Fone { get; set; }

        public Contato(string nome = "", string email = "", string fone = "")
        { 
            this.Nome = nome;
            this.Email = email;
            this.Fone = fone;
        }

        public override string ToString()
        {
            return string.Format("{0};{1};{2}", this.Nome, this.Email, this.Fone);
        }

       
    }

}
