using _211089.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace _211089.Views
{
    public partial class FrmProduto : Form
    {
        Produto p;
        Categoria c;
        Marca m;
        public FrmProduto()
        {
            InitializeComponent();
        }

        void limpaControles()
        {
            txtID.Clear();
            txtDescricao.Clear();
            cboCategorias.SelectedIndex = -1;
            cboMarcas.SelectedIndex = -1;
            picFoto.ImageLocation = "";
            txtValorVenda.Clear();
            txtEstoque.Clear();
        }

        void carregarGrid(string pesquisa)
        {
            p = new Produto()
            {
                descricao = pesquisa
            };
            dgvProdutos.DataSource = p.Consultar();
        }

        private void FrmProduto_Load(object sender, EventArgs e)
        {
            // Cria um objeto do tipo produto
            // E alimenta o comboBox

            c = new Categoria();
            cboCategorias.DataSource = c.Consultar();
            cboCategorias.DisplayMember = "nome";
            cboCategorias.ValueMember = "id";

            m = new Marca();
            cboMarcas.DataSource = m.Consultar();
            cboMarcas.DisplayMember = "nome";
            cboMarcas.ValueMember = "id";

            limpaControles();
            carregarGrid("");

            // Deixa invisível colunas do Grid
            dgvProdutos.Columns["idCategoria"].Visible = false;
            dgvProdutos.Columns["idMarca"].Visible = false;
            dgvProdutos.Columns["foto"].Visible = false;
        }
        private void cboCategorias_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cboCategorias.SelectedIndex != -1)
            {
                DataRowView reg = (DataRowView)cboCategorias.SelectedItem;
            }
        }

        private void cboMarcas_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cboMarcas.SelectedIndex != -1)
            {
                DataRowView reg = (DataRowView)cboMarcas.SelectedItem;
            }
        }

        private void picFoto_Click(object sender, EventArgs e)
        {
            ofdArquivo.InitialDirectory = "D:/fotos/clientes/";
            ofdArquivo.FileName = "";
            ofdArquivo.ShowDialog();
            picFoto.ImageLocation = ofdArquivo.FileName;
        }

        private void dgvProdutos_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (dgvProdutos.RowCount > 0)
            {
                txtID.Text = dgvProdutos.CurrentRow.Cells["id"].Value.ToString();
                txtDescricao.Text = dgvProdutos.CurrentRow.Cells["descricao"].Value.ToString();
                cboCategorias.Text = dgvProdutos.CurrentRow.Cells["categoria"].Value.ToString();
                cboMarcas.Text = dgvProdutos.CurrentRow.Cells["marca"].Value.ToString();
                txtValorVenda.Text = dgvProdutos.CurrentRow.Cells["valorVenda"].Value.ToString();
                txtEstoque.Text = dgvProdutos.CurrentRow.Cells["estoque"].Value.ToString();
                picFoto.ImageLocation = dgvProdutos.CurrentRow.Cells["foto"].Value.ToString();
            }
        }

        private void btnIncluir_Click(object sender, EventArgs e)
        {
            if (txtDescricao.Text == "") return;

            p = new Produto()
            {
                descricao = txtDescricao.Text,
                idCategoria = (int)cboCategorias.SelectedValue,
                idMarca = (int)cboMarcas.SelectedValue,
                valorVenda = decimal.Parse(txtValorVenda.Text),
                estoque = decimal.Parse(txtValorVenda.Text),
                foto = picFoto.ImageLocation,
            };
            p.Incluir();

            limpaControles();
            carregarGrid("");
        }

        private void btnAlterar_Click(object sender, EventArgs e)
        {
            if (txtDescricao.Text == "") return;

            p = new Produto()
            {
                descricao = txtDescricao.Text,
                idCategoria = (int)cboCategorias.SelectedValue,
                idMarca = (int)cboMarcas.SelectedValue,
                valorVenda = decimal.Parse(txtValorVenda.Text),
                estoque = decimal.Parse(txtValorVenda.Text),
                foto = picFoto.ImageLocation,
            };
            p.Alterar();

            limpaControles();
            carregarGrid("");
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            limpaControles();
            carregarGrid("");
        }

        private void btnExcluir_Click(object sender, EventArgs e)
        {
            if (txtID.Text == "") return;

            if (MessageBox.Show("Deseja excluir o cliente?", "Exclusão",
                MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                p = new Produto()
                {
                    id = int.Parse(txtID.Text)
                };
                p.Excluir();

                limpaControles();
                carregarGrid("");
            }
        }

        private void btnFechar_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void btnConsultar_Click(object sender, EventArgs e)
        {
            carregarGrid(txtPesquisa.Text);
        }
    }
}
