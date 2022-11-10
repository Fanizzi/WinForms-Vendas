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
    public partial class FrmCategoria : Form
    {
        Categoria ca;
        public FrmCategoria()
        {
            InitializeComponent();
        }

        void limparControles()
        {
            txtId.Clear();
            txtNome.Clear();
            txtPesquisa.Clear();
        }

        void carregarGrid(string pesquisa)
        {
            ca = new Categoria()
            {
                nome = pesquisa
            };
            dgvCategorias.DataSource = ca.Consultar();
        }

        private void FrmCategoria_Load(object sender, EventArgs e)
        {
            limparControles();
            carregarGrid("");
        }

        private void btnIncluir_Click(object sender, EventArgs e)
        {
            if (txtNome.Text == String.Empty) return;

            ca = new Categoria()
            {
                nome = txtNome.Text,
            };
            ca.Incluir();

            limparControles();
            carregarGrid("");
        }

        private void btnAlterar_Click(object sender, EventArgs e)
        {
            if (txtId.Text == String.Empty) return;

            ca = new Categoria()
            {
                id = int.Parse(txtId.Text),
                nome = txtNome.Text,
            };
            ca.Alterar();

            limparControles();
            carregarGrid("");
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            limparControles();
            carregarGrid("");
        }

        private void btnExcluir_Click(object sender, EventArgs e)
        {
            if (txtId.Text == "") return;

            if (MessageBox.Show("Deseja excluir a cidade?", "Exclusão",
                MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                ca = new Categoria()
                {
                    id = int.Parse(txtId.Text)
                };
                ca.Excluir();

                limparControles();
                carregarGrid("");
            }
        }

        private void btnFechar_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void btnPesquisa_Click(object sender, EventArgs e)
        {
            carregarGrid(txtPesquisa.Text);
        }

        private void dgvCategorias_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (dgvCategorias.RowCount > 0)
            {
                txtId.Text = dgvCategorias.CurrentRow.Cells["id"].Value.ToString();
                txtNome.Text = dgvCategorias.CurrentRow.Cells["nome"].Value.ToString();
            }
        }
    }
}
