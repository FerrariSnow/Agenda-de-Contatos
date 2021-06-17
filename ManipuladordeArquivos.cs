using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Agenda_Contatos
{
    public class ManipuladordeArquivos
    {
        private static string EnderecoArquivo = AppDomain.CurrentDomain.BaseDirectory + "contatos.txt";

        public static List<Contato> LerArquivo()
        {
            List<Contato> ContatoList = new List<Contato>();

            if(File.Exists(@EnderecoArquivo))
            {
                using (StreamReader sr = File.OpenText(@EnderecoArquivo))
                {
                    while(sr.Peek()>=0)
                    {
                        string Linha = sr.ReadLine();
                        string[] LinhaComSplit = Linha.Split(';');
                        if (LinhaComSplit.Count() == 3) 
                        {
                            Contato contato = new Contato();
                            contato.Nome = LinhaComSplit[0];
                            contato.Email = LinhaComSplit[1];
                            contato.Fone = LinhaComSplit[2];

                            ContatoList.Add(contato);
                        }
                    }
                }
            }
            return ContatoList;
        }

        public static void EscreverArquivo(List<Contato> ContatosList)
        {
            using (StreamWriter sw = new StreamWriter(@EnderecoArquivo, false))
            {
                foreach(Contato contato in ContatosList)
                {
                    string linha = string.Format("{0};{1};{2}", contato.Nome, contato.Email, contato.Fone);
                    sw.WriteLine(linha);
                }
                sw.Flush();
            }
        }

    }
}
