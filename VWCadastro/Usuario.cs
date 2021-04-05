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
    public partial class Usuario : Form
    {
        private string state;
        private ToPessoas toObter;

        public ToPessoas ToObter { get; set; }

        public string State
        {
           
            set {
                switch (value)
                {
                    case "novo":                 
                        lblId.Enabled = false;
                        txtId.Visible = false;
                        lblId.Visible = false;
                        txtNome.Enabled = true;
                        txtEndereco.Enabled = true;
                        txtTelefone.Enabled = true;
                        txtId.Text = "";
                        txtNome.Text = "";
                        txtEndereco.Text = "";
                        txtTelefone.Text = "";
                        btnSalvar.Enabled = true;
                        excluir.Enabled = false;
                        editar.Enabled = false;
                        break;
                    case "editar":
                        txtId.Visible = true;
                        lblId.Visible = true;
                        lblId.Enabled = false;
                        txtNome.Enabled = true;
                        txtEndereco.Enabled = true;
                        txtTelefone.Enabled = true;
                        btnSalvar.Enabled = true;
                        excluir.Enabled = false;
                        editar.Enabled = false;
                        break;
                    case "obter":
                        txtId.Visible = true;
                        lblId.Visible = true;
                        lblId.Enabled = false;
                        txtNome.Enabled = false;
                        txtEndereco.Enabled = false;
                        txtTelefone.Enabled = false;
                        txtId.Text = ToObter.Id.ToString();
                        txtNome.Text = ToObter.Nome;
                        txtEndereco.Text = ToObter.Endereco;
                        txtTelefone.Text = ToObter.Telefone;
                        btnSalvar.Enabled = false;
                        excluir.Enabled = true;
                        editar.Enabled = true;
                        break;
                    default:
                        break;
                }
                state = value; 
            }
        }


        public Usuario()
        {
            InitializeComponent();
        }

        private void Usuario_Load(object sender, EventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void menuStrip1_ItemClicked(object sender, ToolStripItemClickedEventArgs e)
        {
            State = e.ClickedItem.Name;
            
        }
    }
}
