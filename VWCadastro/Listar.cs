using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using RNCadastro;
using TOCadastro;

namespace ViewCadastro
{
    public partial class Listar : Form
    {

        public Listar()
        {
            InitializeComponent();

            dgv_load();  
    }

        private  List<ToPessoas> Lista;

      private void dgv_load()
        {
            ToPessoas to = new();
            RNPessoas rn = new();
            Retorno < List < ToPessoas >> retorno = new();

            retorno = rn.Listar(to);

            var novaListPessoas = retorno.Dados.Select(toPessoas => new
            {
                id = toPessoas.Id,
                nome = toPessoas.Nome,
                endereco = toPessoas.Endereco,
                telefone = toPessoas.Telefone
            }).ToList();


            dgv.DataSource = null; //Limpa o grid;
            dgv.DataSource = novaListPessoas;
            Lista = retorno.Dados;
            dgv.Refresh();
        }

        private void dataGridView1_CellContentClick_1(object sender, DataGridViewCellEventArgs e)
        {
            Usuario user = new();
            user.ToObter = Lista[e.RowIndex];
            user.State = "obter";
            
            user.Show();
        }

        private void menuStrip1_ItemClicked(object sender, ToolStripItemClickedEventArgs e)
        {
            Usuario user = new();
            user.State = "novo";
            user.Show();
            
        }
    }
}
