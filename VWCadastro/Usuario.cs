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
        public Listar Main { get; set; }
        public ToPessoas ToObter { get; set; }

        public string State
        {

            set
            {
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
                        excluir.Enabled = true;
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
            if (e.ClickedItem.Name == "excluir" && (state == "obter" || state == "editar"))
            {
                if (DialogResult.Yes == MessageBox.Show("Tem certeza que deseja excluir o registro?", "Confirmação", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2))
                {
                    RNPessoas rn = new();
                    ToPessoas to = new() { Id = int.Parse(txtId.Text.Trim())};
                    Retorno<int> retorno = new();
                    retorno = rn.Excluir(to);
                    if (!retorno.Ok) MessageBox.Show("ERRO : " + retorno.Mensagem);
                    else MessageBox.Show(retorno.Mensagem);
                    MessageBox.Show("Registro excluido com sucesso", "Sucesso", MessageBoxButtons.OK, MessageBoxIcon.Information);

                    Main.Dgv_load();
                    this.Close();
                }
            }
            State = e.ClickedItem.Name;

        }

        private void btnSalvar_Click(object sender, EventArgs e)
        {
            switch (state)
            {
                case "editar":
                    if (!validaForm()) MessageBox.Show("Favor preencha todos os campos.");
                    else
                    {
                        if (DialogResult.Yes == MessageBox.Show("Tem certeza que deseja alterar o registro?", "Confirmação", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2))
                        {
                            RNPessoas rn = new();
                            ToPessoas to = new() { Id = int.Parse(txtId.Text.Trim()), Nome = txtNome.Text.Trim(), Endereco = txtEndereco.Text.Trim(), Telefone = txtTelefone.Text.Trim() };
                            Retorno<int> retorno = new();
                            retorno = rn.Alterar(to);
                            if (!retorno.Ok) MessageBox.Show("ERRO : " + retorno.Mensagem);
                            else MessageBox.Show(retorno.Mensagem);
                            MessageBox.Show("Registro alterado com sucesso", "Sucesso", MessageBoxButtons.OK, MessageBoxIcon.Information);

                            Main.Dgv_load();
                            this.Close();
                        }
                    }
                    break;
                case "novo":

                    if (!validaForm()) MessageBox.Show("Favor preencha todos os campos.");
                    else
                    {
                        ToPessoas to = new() { Nome = txtNome.Text.Trim(), Endereco = txtEndereco.Text.Trim(), Telefone = txtTelefone.Text.Trim() };
                        RNPessoas rn = new();
                        Retorno<int> retorno = new();
                        retorno = rn.Incluir(to);
                        if (!retorno.Ok) MessageBox.Show("ERRO : " + retorno.Mensagem);
                        else MessageBox.Show(retorno.Mensagem);

                        Main.Dgv_load();
                        this.Close();
                    }
                    break;
                default:
                    break;
            }

        }

        private bool validaForm()
        {
            bool ret = (txtNome.Text == "") || (txtEndereco.Text == "") || (txtTelefone.Text == "") ? false : true;
            return ret;

        }
    }
}
