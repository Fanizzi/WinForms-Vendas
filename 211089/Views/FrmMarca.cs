using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using _211089.Models;

namespace _211089.Views
{
    public partial class FrmMarca : Form
    {
        Marca m;
        public FrmMarca()
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
            m = new Marca()
            {
                nome = pesquisa
            };
            dgvMarcas.DataSource = m.Consultar();
        }

        private void btnFechar_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void btnExcluir_Click(object sender, EventArgs e)
        {
            if (txtId.Text == "") return;

            if (MessageBox.Show("Deseja excluir a cidade?", "Exclusão",
                MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                m = new Marca()
                {
                    id = int.Parse(txtId.Text)
                };
                m.Excluir();

                limparControles();
                carregarGrid("");
            }
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            limparControles();
            carregarGrid("");
        }

        private void btnAlterar_Click(object sender, EventArgs e)
        {
            if (txtId.Text == String.Empty) return;

            m = new Marca()
            {
                id = int.Parse(txtId.Text),
                nome = txtNome.Text,
            };
            m.Alterar();

            limparControles();
            carregarGrid("");
        }

        private void btnIncluir_Click(object sender, EventArgs e)
        {
            if (txtNome.Text == String.Empty) return;

            m = new Marca()
            {
                nome = txtNome.Text,
            };
            m.Incluir();

            limparControles();
            carregarGrid("");
        }

        private void btnPesquisa_Click(object sender, EventArgs e)
        {
            carregarGrid(txtPesquisa.Text);
        }

        private void DgvMarcas_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (dgvMarcas.RowCount > 0)
            {
                txtId.Text = dgvMarcas.CurrentRow.Cells["id"].Value.ToString();
                txtNome.Text = dgvMarcas.CurrentRow.Cells["nome"].Value.ToString();
            }
        }

        private void FrmMarca_Load(object sender, EventArgs e)
        {
            limparControles();
            carregarGrid("");
        }
    }
}
