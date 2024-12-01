using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dados
{
    public class Fornecedor
    {
        //Guid = numero de 16 bytes usado como identificador único
        public int? id { get; set; }
        public TipoPessoa tipoPessoa { get; set; }
        public string cpf_cnpj { get; set; }
        public string razao_social { get; set; }
        public string nome { get; set; }
        public string rua { get; set; }
        public int? numero { get; set; }
        public string bairro { get; set; }
        public string cidade { get; set; }
        public string complemento { get; set; }
        public string cep { get; set; }
        public string telefone { get; set; }
        public string celular { get; set; }
        public string email { get; set; }
        

        public Fornecedor()
        {
        }

        public Fornecedor(int? id, TipoPessoa tipoPessoa, string cpf_cnpj, string razao_social, string nome, string rua, int numero, string bairro, string cidade, string complemento, string cep, string telefone, string celular, string email)
         {
             this.id = id;
             this.tipoPessoa = tipoPessoa;
             this.cpf_cnpj = cpf_cnpj;
             this.razao_social = razao_social;
             this.nome = nome;
             this.rua = rua;
             this.numero = numero;
             this.bairro = bairro;
             this.cidade = cidade;
             this.complemento = complemento;
             this.cep = cep;
             this.telefone = telefone;
             this.celular = celular;
             this.email = email;
         }



         public override bool Equals(object obj)
         {
             return obj is Fornecedor fornecedor &&
                    id == fornecedor.id &&
                    tipoPessoa == fornecedor.tipoPessoa &&
                    cpf_cnpj == fornecedor.cpf_cnpj &&
                    razao_social == fornecedor.razao_social &&
                    nome == fornecedor.nome &&
                    rua == fornecedor.rua &&
                    numero == fornecedor.numero &&
                    bairro == fornecedor.bairro &&
                    cidade == fornecedor.cidade &&
                    complemento == fornecedor.complemento &&
                    cep == fornecedor.cep &&
                    telefone == fornecedor.telefone &&
                    celular == fornecedor.celular &&
                    email == fornecedor.email;
         }

         public override int GetHashCode()
         {
             int hashCode = -1544928225;
             hashCode = hashCode * -1521134295 + id.GetHashCode();
             hashCode = hashCode * -1521134295 + tipoPessoa.GetHashCode();
             hashCode = hashCode * -1521134295 + EqualityComparer<string>.Default.GetHashCode(cpf_cnpj);
             hashCode = hashCode * -1521134295 + EqualityComparer<string>.Default.GetHashCode(razao_social);
             hashCode = hashCode * -1521134295 + EqualityComparer<string>.Default.GetHashCode(nome);
             hashCode = hashCode * -1521134295 + EqualityComparer<string>.Default.GetHashCode(rua);
             hashCode = hashCode * -1521134295 + EqualityComparer<string>.Default.GetHashCode(bairro);
             hashCode = hashCode * -1521134295 + EqualityComparer<string>.Default.GetHashCode(cidade);
             hashCode = hashCode * -1521134295 + EqualityComparer<string>.Default.GetHashCode(complemento);
             hashCode = hashCode * -1521134295 + EqualityComparer<string>.Default.GetHashCode(cep);
             hashCode = hashCode * -1521134295 + EqualityComparer<string>.Default.GetHashCode(telefone);
             hashCode = hashCode * -1521134295 + EqualityComparer<string>.Default.GetHashCode(celular);
             hashCode = hashCode * -1521134295 + EqualityComparer<string>.Default.GetHashCode(email);
             return hashCode;
         }


    }
}
