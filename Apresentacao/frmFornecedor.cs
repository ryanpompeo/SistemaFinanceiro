﻿using System;
using System.Collections.Generic;
using System.Data;
using System.Windows.Forms;
using Dados;
using Negocio;
using FluentValidation;
using FluentValidation.Results;

namespace Apresentacao
{
    public partial class frmFornecedor : Form
    {
        private readonly FornecedorService _fornecedorService;
        private DataTable tblFornecedor = new DataTable();

        //sinaliza qual operação está em andamento
        //0 = nada
        //1 = inclusão (novo)
        //2 = alteração
        private int modo = 0; //sinaliza qual operação está em andamento
        public frmFornecedor()
        {
            InitializeComponent();
            _fornecedorService = new FornecedorService();

            dgFornecedor.Columns.Add("Id", "ID");
            dgFornecedor.Columns.Add("Nome", "NOME");
            dgFornecedor.Columns.Add("tipoPessoa", "TIPO PESSOA");
            dgFornecedor.Columns.Add("email", "EMAIL");
            dgFornecedor.Columns.Add("cpf_cnpj", "CPF/CNPJ");
            dgFornecedor.Columns.Add("razao_social", "RAZAO SOCIAL");
            dgFornecedor.Columns.Add("cep", "CEP");
            dgFornecedor.Columns.Add("rua", "RUA");
            dgFornecedor.Columns.Add("numero", "NUMERO");
            dgFornecedor.Columns.Add("bairro", "BAIRRO");
            dgFornecedor.Columns.Add("cidade", "CIDADE");
            dgFornecedor.Columns.Add("complemento", "COMPLEMENTO");
            dgFornecedor.Columns.Add("telefone", "TELEFONE");
            dgFornecedor.Columns.Add("celular", "CELULAR");


            dgFornecedor.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgFornecedor.AllowUserToAddRows = false;
            dgFornecedor.AllowUserToDeleteRows = false;
            dgFornecedor.AllowUserToOrderColumns = true;
            dgFornecedor.ReadOnly = true;

            tblFornecedor = _fornecedorService.getAll();

        }

        private void Habilita()
        {
            switch (modo)
            {
                case 0: //neutro
                    btnInclui.Enabled = true;
                    btnAltera.Enabled = true;
                    btnExclui.Enabled = true;
                    btnSalva.Enabled = false;
                    btnCancela.Enabled = false;
                    grpDados.Enabled = false;
                    dgFornecedor.Enabled = true;
                    break;
                case 1: //inclusão
                    btnInclui.Enabled = false;
                    btnAltera.Enabled = false;
                    btnExclui.Enabled = false;
                    btnSalva.Enabled = true;
                    btnCancela.Enabled = true;
                    grpDados.Enabled = true;
                    dgFornecedor.Enabled = false;
                    break;
                case 2:
                    btnInclui.Enabled = false;
                    btnAltera.Enabled = false;
                    btnExclui.Enabled = false;
                    btnSalva.Enabled = true;
                    btnCancela.Enabled = true;
                    grpDados.Enabled = true;
                    dgFornecedor.Enabled = false;
                    break;
            }

        }

        public void LimpaForm()
        {
            txtNome.Clear();
            txtEmail.Clear();
            txtId.Clear();
            radioPessoaFisica.Checked = false;
            radioPessoaJuridica.Checked = false;
            txtBairro.Clear();
            txtCel.Clear();
            txtCep.Clear();
            txtCidade.Clear();
            txtComplemento.Clear();
            txtCpfCnpj.Clear();
            txtRua.Clear();
            txtNumero.Clear();
            txtRazaoSocial.Clear();
            txtTel.Clear();
           

            txtNome.Focus();
        }


        private void frmFornecedor_Load(object sender, System.EventArgs e)
        {
            radioPessoaFisica.Text = TipoPessoa.PESSOA_FISICA.ToString();
            radioPessoaJuridica.Text = TipoPessoa.PESSOA_JURIDICA.ToString();

            // NOVO ====================
            dgFornecedor.ColumnCount = 14;
            dgFornecedor.AutoGenerateColumns = false;
            dgFornecedor.Columns[0].Width = 20;
            dgFornecedor.Columns[0].HeaderText = "ID";
            dgFornecedor.Columns[0].DataPropertyName = "Id";
            //dgCliente.Columns[0].Visible = false;
            dgFornecedor.Columns[1].Width = 250;
            dgFornecedor.Columns[1].HeaderText = "NOME";
            dgFornecedor.Columns[1].DataPropertyName = "Nome";
            dgFornecedor.Columns[2].Width = 170;
            dgFornecedor.Columns[2].HeaderText = "EMAIL";
            dgFornecedor.Columns[2].DataPropertyName = "email";
            dgFornecedor.Columns[3].Width = 40;
            dgFornecedor.Columns[3].HeaderText = "TIPO";
            dgFornecedor.Columns[3].DataPropertyName = "tipoPessoa";
            dgFornecedor.Columns[4].Width = 100;
            dgFornecedor.Columns[4].HeaderText = "CPF/CNPJ";
            dgFornecedor.Columns[4].DataPropertyName = "cpf_cnpj";
            dgFornecedor.Columns[5].Width = 70;
            dgFornecedor.Columns[5].HeaderText = "RAZAO";
            dgFornecedor.Columns[5].DataPropertyName = "razao_social";
            dgFornecedor.Columns[6].Width = 100;
            dgFornecedor.Columns[6].HeaderText = "CEP";
            dgFornecedor.Columns[6].DataPropertyName = "cep";
            dgFornecedor.Columns[7].Width = 100;
            dgFornecedor.Columns[7].HeaderText = "RUA";
            dgFornecedor.Columns[7].DataPropertyName = "rua";
            dgFornecedor.Columns[8].Width = 65;
            dgFornecedor.Columns[8].HeaderText = "NUMERO";
            dgFornecedor.Columns[8].DataPropertyName = "numero";
            dgFornecedor.Columns[9].Width = 85;
            dgFornecedor.Columns[9].HeaderText = "BAIRRO";
            dgFornecedor.Columns[9].DataPropertyName = "bairro";
            dgFornecedor.Columns[10].Width = 85;
            dgFornecedor.Columns[10].HeaderText = "CIDADE";
            dgFornecedor.Columns[10].DataPropertyName = "cidade";
            dgFornecedor.Columns[11].Width = 100;
            dgFornecedor.Columns[11].HeaderText = "COMPLEMENTO";
            dgFornecedor.Columns[11].DataPropertyName = "complemento";
            dgFornecedor.Columns[12].Width = 90;
            dgFornecedor.Columns[12].HeaderText = "TELEFONE";
            dgFornecedor.Columns[12].DataPropertyName = "telefone";
            dgFornecedor.Columns[13].Width = 90;
            dgFornecedor.Columns[13].HeaderText = "CELULAR";
            dgFornecedor.Columns[13].DataPropertyName = "celular";

            dgFornecedor.AllowUserToAddRows = false;
            dgFornecedor.AllowUserToDeleteRows = false;
            dgFornecedor.MultiSelect = false;
            dgFornecedor.SelectionMode = DataGridViewSelectionMode.FullRowSelect;

            carregaGridView();

        }

        private void carregaGridView()
        {
            dgFornecedor.DataSource = _fornecedorService.getAll();
            dgFornecedor.Refresh();
        }

        private void btnBusca_Click(object sender, EventArgs e)
        {
            frmPrompt f = new frmPrompt();
            string txtBusca = "";
            f.ShowDialog();
            txtBusca = f.Texto;
            DataTable tbFornecedores = _fornecedorService.filterByName(txtBusca);
            if (tbFornecedores != null)
            {
                dgFornecedor.DataSource = tbFornecedores;
                dgFornecedor.Refresh();
            }
        }

        private void dgFornecedor_SelectionChanged(object sender, EventArgs e)
        {
            DataGridView row = (DataGridView)sender;
            if (row.CurrentRow == null)
                return;

            //limpa os TextBoxes
            txtId.Text = dgFornecedor.CurrentRow.Cells[0].Value.ToString();
            txtNome.Text = dgFornecedor.CurrentRow.Cells[1].Value.ToString();
            txtEmail.Text = dgFornecedor.CurrentRow.Cells[2].Value.ToString();
            if (dgFornecedor.CurrentRow.Cells[3].Value.ToString() == ((int)TipoPessoa.PESSOA_FISICA).ToString())
                radioPessoaFisica.Checked = true;
            else
                radioPessoaJuridica.Checked = true;
            txtCpfCnpj.Text = dgFornecedor.CurrentRow.Cells[4].Value.ToString();
            txtRazaoSocial.Text = dgFornecedor.CurrentRow.Cells[5].Value.ToString();
            txtCep.Text = dgFornecedor.CurrentRow.Cells[6].Value.ToString();
            txtRua.Text = dgFornecedor.CurrentRow.Cells[7].Value.ToString();
            txtNumero.Text = dgFornecedor.CurrentRow.Cells[8].Value.ToString();
            txtBairro.Text = dgFornecedor.CurrentRow.Cells[9].Value.ToString();
            txtCidade.Text = dgFornecedor.CurrentRow.Cells[10].Value.ToString();
            txtComplemento.Text = dgFornecedor.CurrentRow.Cells[11].Value.ToString();
            txtTel.Text = dgFornecedor.CurrentRow.Cells[12].Value.ToString();
            txtCel.Text = dgFornecedor.CurrentRow.Cells[13].Value.ToString();
        }

        private void btnAltera_Click(object sender, EventArgs e)
        {
            modo = 2;
            Habilita();
        }

        private void btnInclui_Click(object sender, EventArgs e)
        {
            modo = 1;
            Habilita();
            LimpaForm();
        }

        private void btnSalva_Click(object sender, EventArgs e)
        {
            int id=0;
            string nome;
            string email;
            string cpf_cnpj;
            string razao_social;
            string rua;
            int numero;
            string bairro;
            string cidade;
            string complemento;
            string telefone;
            string celular;
            string cep;

            string resultado;
            string msg;
            int regAtual = 0;

            if (String.IsNullOrEmpty(txtId.Text))
                id = 0;
            else
                id = Convert.ToInt32(txtId.Text);

            nome = txtNome.Text;
            email = txtEmail.Text;
            cpf_cnpj = txtCpfCnpj.Text;
            razao_social = txtRazaoSocial.Text;
            rua = txtRua.Text;

            if(String.IsNullOrEmpty(txtNumero.Text))
                numero = -1;
            else
                numero = Convert.ToInt32(txtNumero.Text);
            
            cidade = txtCidade.Text;
            bairro = txtBairro.Text;
            complemento = txtComplemento.Text;
            telefone = txtTel.Text;
            celular = txtCel.Text;
            cep = txtCep.Text;
            TipoPessoa tp = 0;
            if (radioPessoaFisica.Checked)
            {
                tp = TipoPessoa.PESSOA_FISICA;
            }
            else if (radioPessoaJuridica.Checked)
            {
                tp = TipoPessoa.PESSOA_JURIDICA;
            }
           

            Fornecedor fornecedor = new Fornecedor(id, tp, cpf_cnpj, razao_social, nome, rua, numero, bairro, cidade, complemento, cep, telefone, celular, email);

            //Inicio da validação
            if (fornecedor != null)
            {
                FornecedorValidator validator = new FornecedorValidator();
                ValidationResult results = validator.Validate(fornecedor);
                IList<ValidationFailure> failures = results.Errors;
                if (!results.IsValid)
                {
                    foreach (ValidationFailure failure in failures)
                    {
                        MessageBox.Show(failure.ErrorMessage, "Aviso do sistema", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        return;
                    }
                }
            }
            //Fim da validação

            if (modo == 1)
            {
                resultado = _fornecedorService.Update(fornecedor);
                if (resultado == "SUCESSO")
                {
                    msg = "FORNECEDOR CADASTRADO COM SUCESSO!";
                    carregaGridView();
                }
                else
                {
                    msg = "ERRO";
                }
                MessageBox.Show(msg, "Aviso do sistema!", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else if (modo == 2)
            {
                resultado = _fornecedorService.Update(fornecedor);
                if (resultado == "SUCESSO")
                {
                    msg = "FORNECEDOR ATUALIZADO COM SUCESSO!";
                    carregaGridView();
                }
                else 
                {
                    msg = "ERRO";
                }
                MessageBox.Show(msg, "Aviso do sistema!", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }

            modo = 0;
            Habilita();

        }

        private void btnExclui_Click(object sender, EventArgs e)
        {
            string resultado;
            String msg;
            DialogResult resposta;
            resposta = MessageBox.Show("Confirma exclusão?", "Aviso do sistema!", MessageBoxButtons.OKCancel, MessageBoxIcon.Question);
            if (resposta == DialogResult.OK)
            {
                int idFornecedor = Convert.ToInt32(txtId.Text);
                resultado = _fornecedorService.Remove(idFornecedor);
                if (resultado == "SUCESSO")
                {
                    msg = "FORNECEDOR EXCLUIDO COM SUCESSO!";
                    carregaGridView();
                }
                else
                {
                    msg = "FALHA AO EXCLUIR FORNECEDOR!";
                }
                MessageBox.Show(msg, "Aviso do sistema!", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }

        }

        private void btnCancela_Click(object sender, EventArgs e)
        {
            modo = 0;
            Habilita();
        }

        


        private void btnInclui_Click_1(object sender, EventArgs e)
        {
            modo = 1;
            Habilita();
            LimpaForm();
        }

        private void txtCep_TextChanged(object sender, EventArgs e)
        {

        }

        /*private void btnExibirTabela_Click(object sender, EventArgs e)
        {
            frmDadosFornecedor frmDadosFornecedor = new frmDadosFornecedor();
            frmDadosFornecedor.Show(this);
        }*/
    }
}
