using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FluentValidation;

namespace Dados
{
    public class FornecedorValidator : AbstractValidator<Fornecedor>
    {
        public FornecedorValidator()
            {
            RuleFor(fornecedor => fornecedor.nome).NotEmpty().WithMessage("ERRO DE CAMPO:{NOME} OBRIGATÓRIO");
            RuleFor(fornecedor => fornecedor.nome).Length(2, 50).WithMessage("ERRO DE CAMPO:{NOME} DEVE POSSUIR DE 10 A 50 CARACTERES");
            RuleFor(fornecedor => fornecedor.cpf_cnpj).NotEmpty().WithMessage("ERRO DE CAMPO:{CPF} OBRIGATÓRIO");
            RuleFor(fornecedor => fornecedor.cpf_cnpj).Length(11, 11).WithMessage("ERRO DE CAMPO:{CPF} NECESSITA DE 11 DÍGITOS");
            RuleFor(fornecedor => fornecedor.tipoPessoa).NotEmpty().WithMessage("ERRO DE CAMPO:{TIPO PESSOA} OBRIGATÓRIO");
            RuleFor(fornecedor => fornecedor.tipoPessoa).IsInEnum().WithMessage("ERRO DE CAMPO:{TIPO PESSOA} DEVE SER ESPECIFICADO");
            RuleFor(fornecedor => fornecedor.rua).NotEmpty().WithMessage("ERRO DE CAMPO:{RUA} OBRIGATÓRIO");
            RuleFor(fornecedor => fornecedor.rua).Length(1, 80).WithMessage("ERRO DE CAMPO:{RUA} NECESSÁRIO DE 11 A 50 CARACTERES");
            RuleFor(fornecedor => fornecedor.numero).NotEmpty().WithMessage("ERRO DE CAMPO:{NUMERO} OBRIGATÓRIO");
            //RuleFor(fornecedor => fornecedor.complemento).NotEmpty().WithMessage("ERRO DE CAMPO:{COMPLEMENTO} OBRIGATÓRIO");
            //RuleFor(fornecedor => fornecedor.complemento).Length(0, 20).WithMessage("ERRO DE CAMPO:{COMPLEMENTO} NECESSÁRIO DE 1 A 20 CARACTERES ");
            RuleFor(fornecedor => fornecedor.bairro).NotEmpty().WithMessage("ERRO DE CAMPO:{BAIRRO} OBRIGATÓRIO");
            RuleFor(fornecedor => fornecedor.bairro).Length(1, 30).WithMessage("ERRO DE CAMPO:{BAIRRO} NECESSÁRIO DE 1 A 30 CARACTERES");
            RuleFor(fornecedor => fornecedor.cep).NotEmpty().WithMessage("ERRO DE CAMPO:{CEP} OBRIGATÓRIO");
            RuleFor(fornecedor => fornecedor.cep).Length(9, 9).WithMessage("ERRO DE CAMPO:{CEP} NECESSÁRIO 8 DÍGITOS");
            RuleFor(fornecedor => fornecedor.cidade).NotEmpty().WithMessage("ERRO DE CAMPO:{CIDADE} OBRIGATÓRIO");
            RuleFor(fornecedor => fornecedor.cidade).Length(2, 50).WithMessage("ERRO DE CAMPO:{CIDADE} NECESSÁRIO DE 2 A 50 CARACTERES");
            RuleFor(fornecedor => fornecedor.email).NotEmpty().WithMessage("ERRO DE CAMPO:{EMAIL} OBRIGATÓRIO").EmailAddress().WithMessage("ERRO DE CAMPO:{EMAIL} INVÁLIDO");
            //RuleFor(fornecedor => fornecedor.razao_social).Length(1, 30).WithMessage("ERRO DE CAMPO:{RAZAO SOCIAL} NECESSÁRIO DE 1 A 30 CARACTERES");
            RuleFor(fornecedor => fornecedor.celular).NotEmpty().WithMessage("ERRO DE CAMPO:{CELULAR} OBRIGATÓRIO");
            //RuleFor(fornecedor => fornecedor.celular).Length(11, 13).WithMessage("ERRO DE CAMPO:{CELULAR} CONTER 13 DÍGITOS");
            //RuleFor(fornecedor => fornecedor.telefone).NotEmpty().WithMessage("ERRO DE CAMPO:{TELEFONE} OBRIGATÓRIO");
            //RuleFor(fornecedor => fornecedor.telefone).Length(11, 13).WithMessage("ERRO DE CAMPO:{TELEFONE} NO MÍNIMO 11 DÍGITOS");

        }
    }
}
