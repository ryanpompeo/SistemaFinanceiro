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
    public partial class FrmRelFor : Form
    {
        public FrmRelFor()
        {
            InitializeComponent();
        }

        private void FrmRelFor_Load(object sender, EventArgs e)
        {
            // TODO: esta linha de código carrega dados na tabela 'DatabaseDataSet.fornecedor'. Você pode movê-la ou removê-la conforme necessário.
            this.fornecedorTableAdapter.Fill(this.DatabaseDataSet.fornecedor);

            this.reportViewer1.RefreshReport();
        }

        private void reportViewer1_Load(object sender, EventArgs e)
        {

        }
    }
}
