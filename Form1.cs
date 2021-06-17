using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Agenda_Contatos
{
    public partial class frmAgendaContatos : Form
    {
        public frmAgendaContatos()
        {
            InitializeComponent();
        }

        private void frmAgendaContatos_Shown(object sender, EventArgs e)
        {
            AlterarBotoesSalvareCancelar(false);
            AlterarBotoesIncluirAlterareExcluir(true);
        }

        private void AlterarBotoesSalvareCancelar(bool estado)
        {
            btnSalvar.Enabled = estado;
            btnCancelar.Enabled = estado; 
        }

        private void AlterarBotoesIncluirAlterareExcluir(bool estado)
        {
            btnIncluir.Enabled = estado;
            btnAlterar.Enabled = estado;
            btnExcluir.Enabled = estado;
        }

        private void btnIncluir_Click(object sender, EventArgs e)
        {
            AlterarBotoesSalvareCancelar(true);
            AlterarBotoesIncluirAlterareExcluir(false);

        }

        private void btnAlterar_Click(object sender, EventArgs e)
        {
            AlterarBotoesSalvareCancelar(true);
            AlterarBotoesIncluirAlterareExcluir(false);
        }

        private void btnExcluir_Click(object sender, EventArgs e)
        {
            AlterarBotoesSalvareCancelar(true);
            AlterarBotoesIncluirAlterareExcluir(false);
        }

        private void btnSalvar_Click(object sender, EventArgs e)
        {
            Contato contato = new Contato
            {
                Nome = txbNome.Text,
                Email = txbEmail.Text,
                Fone = txbFone.Text,
            };
            List<Contato> ContatosList = new List<Contato>();
            foreach(Contato ContatoDaLista in lxbContatos.Items)
            {
                ContatosList.Add(ContatoDaLista);
            }
            ContatosList.Add(contato);
            ManipuladordeArquivos.EscreverArquivo(ContatosList);
            CarregarListaContatos();
            LimparCampos();
            AlterarBotoesSalvareCancelar(false);
            AlterarBotoesIncluirAlterareExcluir(true);
                     
        
        }

        private void CarregarListaContatos()
        {
            lxbContatos.Items.Clear();
            lxbContatos.Items.AddRange(ManipuladordeArquivos.LerArquivo().ToArray());

        }
        private void LimparCampos()
        {
            txbNome.Text = "";
            txbEmail.Text = "";
            txbFone.Text = "";
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            
            AlterarBotoesSalvareCancelar(false);
            AlterarBotoesIncluirAlterareExcluir(true);

        }
    }
}
