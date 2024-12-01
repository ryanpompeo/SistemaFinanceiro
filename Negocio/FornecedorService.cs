using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Dados;
using MySql.Data.MySqlClient;
using Org.BouncyCastle.Cms;
using Org.BouncyCastle.Ocsp;

namespace Negocio
{
    public class FornecedorService
    {
        private FornecedorRepository _repository;

        public FornecedorService()
        {
            _repository = new FornecedorRepository();
        }

        /*public string Update(int? id, TipoPessoa tipoPessoa, string nome, string email, string cpf_cnpj, string razao_social, string rua, int? numero, string bairro, string cidade, string complemento, string telefone, string celular, string cep)
        {

            var fornecedor = new Fornecedor
            {
                id = id,
                tipoPessoa = tipoPessoa,
                nome = nome,
                email = email,
                cpf_cnpj = cpf_cnpj,
                razao_social = razao_social,
                rua = rua,
                numero = numero,
                bairro = bairro,
                cidade = cidade,
                complemento = complemento,
                telefone = telefone,
                celular = celular,
                cep = cep
            };

            if (id == null)
            {
                if (fornecedor.nome.Equals(""))
                {
                    return "NomeNulo";
                }
                else if (fornecedor.email.Equals(""))
                {
                    return "EmailNulo";
                }
                else
                {
                    string resposta = _repository.verificaEmail(fornecedor.email);

                    if (resposta.Equals("TEM"))
                    {
                        return "FALHA2";
                    }
                    else
                    {
                        return _repository.Insert(fornecedor);
                    }
                }
            }
            else
            {
                if (fornecedor.nome.Equals(""))
                {
                    return "NomeNulo";
                }
                else if (fornecedor.email.Equals(""))
                {
                    return "EmailNulo";
                }
                else
                {
                   return _repository.Update(fornecedor);
                }
            }
                
        }*/

        public string Update(Fornecedor fornecedor)
        {
            // Insira as validações e regras de negócio aqui
            // Por exemplo, verificar se o email já está cadastrado
            if (fornecedor.id == 0)
                return _repository.Insert(fornecedor);
            else
                return _repository.Update(fornecedor);

        }

        public string Insert(Fornecedor fornecedor)
        {
            // Insira as validações e regras de negócio aqui
            // Por exemplo, verificar se o email já está cadastrado

            string resposta = _repository.verificaEmail(fornecedor.email);

            if (resposta.Equals("TEM"))
            {
                return "FALHA";
            }
            else
            {
                return _repository.Insert(fornecedor);
            }
            

        }
        public string Remove(int idFornecedor)
        {
            // Insira as validações e regras de negócio aqui
            // Por exemplo, verificar se o email já está cadastrado

            return _repository.Remove(idFornecedor);

        }

        public DataTable getAll()
        {
            return _repository.getAll();
        }
        public DataTable filterByName(string nome)
        {
            return _repository.filterByName(nome);
        }
    }
}
