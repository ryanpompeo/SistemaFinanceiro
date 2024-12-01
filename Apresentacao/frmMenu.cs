using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Apresentacao
{
    public partial class frmMenu : Form
    {
        public frmMenu()
        {
            InitializeComponent();
      
            frmFornecedor frmFornecedor = new frmFornecedor();
            frmFornecedor.MdiParent = this;

            frmCliente frmCliente = new frmCliente();
            frmCliente.MdiParent = this;
        }

        private void clienteToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmCliente frmCliente = new frmCliente();
            frmCliente.Show();
        }

        private void fornecedorToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmFornecedor frmFornecedor = new frmFornecedor();
            frmFornecedor.Show();
        }

        private void ajudaToolStripMenuItem_Click(object sender, EventArgs e)
        {
            
        }

        private void sobreToolStripMenuItem_Click(object sender, EventArgs e)
        {
            MessageBox.Show("ALUNO: RYAN POMPEO BUSSULA - RA: 203420\n\nALUNO: PAMELA NACHBAR - RA: 203431", "Sobre", MessageBoxButtons.OK);
        }

        private void listagemDeFornecedoresToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FrmRelFor frmRelFor = new FrmRelFor();
            frmRelFor.MdiParent = this;
            frmRelFor.Show();
        }

        private void sairToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void frmMenu_Load(object sender, EventArgs e)
        {

        }

        private void frmMenu_FormClosing(object sender, FormClosingEventArgs e)
        {
            DialogResult resultado;
            resultado = MessageBox.Show("Deseja realmente sair?", "Pergunta", MessageBoxButtons.YesNo, MessageBoxIcon.Question); 
            
            if (resultado.Equals(DialogResult.No))
            {
                e.Cancel = true;
            }
        }
    }
}
