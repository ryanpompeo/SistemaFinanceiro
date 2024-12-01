using MySql.Data.MySqlClient;
using MySqlConnector;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Data.SqlTypes;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dados
{
    public class FornecedorRepository
    {
        public string Insert(Fornecedor fornecedor)
        {
            string resp = "";
            try
            {
                Connection.getConnection();

                MySql.Data.MySqlClient.MySqlCommand SqlCmd = new MySql.Data.MySqlClient.MySqlCommand
                {
                    Connection = Connection.SqlCon,
                    CommandText = "INSERT INTO fornecedor (nome, email, tipoPessoa, cpf_cnpj, razao_social, rua, numero, bairro, cidade, complemento, telefone, celular, cep)" +
                    " VALUES (@pNome, @pEmail, @pTipoPessoa, @pCpf_cnpj, @pRazao_social, @pRua, @pNumero, @pBairro, @pCidade, @pComplemento, @pTelefone, @pCelular, @pCep) ",
                    CommandType = CommandType.Text
                };
                SqlCmd.Parameters.AddWithValue("pNome", fornecedor.nome);
                SqlCmd.Parameters.AddWithValue("pEmail", fornecedor.email);
                SqlCmd.Parameters.AddWithValue("pTipoPessoa", fornecedor.tipoPessoa);
                SqlCmd.Parameters.AddWithValue("pCpf_cnpj", fornecedor.cpf_cnpj);
                SqlCmd.Parameters.AddWithValue("pRazao_social", fornecedor.razao_social);
                SqlCmd.Parameters.AddWithValue("pRua", fornecedor.rua);
                SqlCmd.Parameters.AddWithValue("pNumero", fornecedor.numero);
                SqlCmd.Parameters.AddWithValue("pBairro", fornecedor.bairro);
                SqlCmd.Parameters.AddWithValue("pCidade", fornecedor.cidade);
                SqlCmd.Parameters.AddWithValue("pComplemento", fornecedor.complemento);
                SqlCmd.Parameters.AddWithValue("pTelefone", fornecedor.telefone);
                SqlCmd.Parameters.AddWithValue("pCelular", fornecedor.celular);
                SqlCmd.Parameters.AddWithValue("pCep", fornecedor.cep);
                //executa o stored procedure
                resp = SqlCmd.ExecuteNonQuery() == 1 ? "SUCESSO" : "FALHA";
            }
            catch (Exception ex)
            {
                resp = ex.Message;
            }
            finally
            {
                if (Connection.SqlCon.State == ConnectionState.Open)
                    Connection.SqlCon.Close();
            }

            return resp;
        }

        public string Update(Fornecedor fornecedor)
        {
            string resp = "";
            try
            {
                Connection.getConnection();

                string updateSql = String.Format("UPDATE fornecedor SET " +
                                    "nome = @pNome, email = @pEmail, tipoPessoa = @pTipoPessoa, cpf_cnpj = @pCpfCnpj, razao_social = @pRazaoSocial, rua = @pRua, numero = @pNumero, bairro = @pBairro , cidade = @pCidade, complemento = @pComplemento, telefone = @pTelefone, celular = @pCelular , cep = @pCep " +
                                    "WHERE id = @pId ");
                MySql.Data.MySqlClient.MySqlCommand SqlCmd = new MySql.Data.MySqlClient.MySqlCommand(updateSql, Connection.SqlCon);
                SqlCmd.Parameters.AddWithValue("pNome", fornecedor.nome);
                SqlCmd.Parameters.AddWithValue("pEmail", fornecedor.email);
                SqlCmd.Parameters.AddWithValue("pTipoPessoa", fornecedor.tipoPessoa);
                SqlCmd.Parameters.AddWithValue("pCpfCnpj", fornecedor.cpf_cnpj);
                SqlCmd.Parameters.AddWithValue("pRazaoSocial", fornecedor.razao_social);
                SqlCmd.Parameters.AddWithValue("pRua", fornecedor.rua);
                SqlCmd.Parameters.AddWithValue("pNumero", fornecedor.numero);
                SqlCmd.Parameters.AddWithValue("pBairro", fornecedor.bairro);
                SqlCmd.Parameters.AddWithValue("pCidade", fornecedor.cidade);
                SqlCmd.Parameters.AddWithValue("pComplemento", fornecedor.complemento);
                SqlCmd.Parameters.AddWithValue("pTelefone", fornecedor.telefone);
                SqlCmd.Parameters.AddWithValue("pCelular", fornecedor.celular);
                SqlCmd.Parameters.AddWithValue("pCep", fornecedor.cep);

                SqlCmd.Parameters.AddWithValue("pId", fornecedor.id);

                //executa o stored procedure
                resp = SqlCmd.ExecuteNonQuery() == 1 ? "SUCESSO" : "FALHA";
            }
            catch (Exception ex)
            {
                resp = ex.Message;
            }
            finally
            {
                if (Connection.SqlCon.State == ConnectionState.Open)
                    Connection.SqlCon.Close();
            }
            return resp;
        }

        public string Remove(int idFornecedor)
        {
            string resp = "";
            try
            {
                Connection.getConnection();

                string updateSql = String.Format("DELETE FROM fornecedor " +
                                    "WHERE id = @pId ");
                MySql.Data.MySqlClient.MySqlCommand SqlCmd = new MySql.Data.MySqlClient.MySqlCommand(updateSql, Connection.SqlCon);
                SqlCmd.Parameters.AddWithValue("pId", idFornecedor);

                //executa o stored procedure
                resp = SqlCmd.ExecuteNonQuery() == 1 ? "SUCESSO" : "FALHA";
            }
            catch (Exception ex)
            {
                resp = ex.Message;
            }
            finally
            {
                if (Connection.SqlCon.State == ConnectionState.Open)
                    Connection.SqlCon.Close();
            }
            return resp;
        }

        public DataTable getAll()
        {
            DataTable DtResultado = new DataTable("fornecedor");
            try
            {
                Connection.getConnection();
                String sqlSelect = "select * from fornecedor";

                MySql.Data.MySqlClient.MySqlCommand SqlCmd = new MySql.Data.MySqlClient.MySqlCommand();
                SqlCmd.Connection = Connection.SqlCon;
                SqlCmd.CommandText = sqlSelect;
                SqlCmd.CommandType = CommandType.Text;
                MySql.Data.MySqlClient.MySqlDataAdapter SqlData = new MySql.Data.MySqlClient.MySqlDataAdapter(SqlCmd);
                SqlData.Fill(DtResultado);
            }
            catch (Exception ex)
            {
                DtResultado = null;
            }
            return DtResultado;
        }

        public DataTable filterByName(string pNome)
        {
            DataTable DtResultado = new DataTable("fornecedor");
            string selectSql;
            try
            {
                Connection.getConnection();
                if (!string.IsNullOrEmpty(pNome))
                {
                    selectSql = String.Format("SELECT * FROM fornecedor WHERE nome LIKE @pNome");
                    pNome = '%' + pNome + '%';
                }
                else
                {
                    selectSql = String.Format("SELECT * FROM fornecedor");
                }
                MySql.Data.MySqlClient.MySqlCommand SqlCmd = new MySql.Data.MySqlClient.MySqlCommand(selectSql, Connection.SqlCon);
                if (!string.IsNullOrEmpty(pNome))
                    SqlCmd.Parameters.AddWithValue("pNome", pNome);
                MySql.Data.MySqlClient.MySqlDataAdapter SqlData = new MySql.Data.MySqlClient.MySqlDataAdapter(SqlCmd);
                SqlData.Fill(DtResultado);
            }
            catch (Exception ex)
            {
                DtResultado = null;
            }
            return DtResultado;
        }

        public string verificaEmail(string emailFornecedor) 
        {
            string resp = "";
            try
            {
                Connection.getConnection();
                String sqlSelect = "SELECT COUNT(*) FROM fornecedor WHERE email = @pEmail";

                MySql.Data.MySqlClient.MySqlCommand SqlCmd = new MySql.Data.MySqlClient.MySqlCommand();

                SqlCmd.Parameters.AddWithValue("pEmail", emailFornecedor);

                SqlCmd.Connection = Connection.SqlCon;
                SqlCmd.CommandText = sqlSelect;
                SqlCmd.CommandType = CommandType.Text;
                int count = Convert.ToInt32(SqlCmd.ExecuteScalar());

                // Verificar o resultado
                if (count > 0)
                {
                    resp = "TEM";
                }
                else
                {
                    resp = "NAO TEM";
                }
                MySql.Data.MySqlClient.MySqlDataAdapter SqlData = new MySql.Data.MySqlClient.MySqlDataAdapter(SqlCmd);


            }
            catch (Exception ex)
            {
                resp = ex.Message;
            }
            return resp;
        }


    }
    
}
