using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FluentValidation;

namespace Dados
{
    public class ClienteValidator:AbstractValidator<Cliente>
    {
        public ClienteValidator()
        {
            RuleFor(cliente => cliente.Nome).NotEmpty().WithMessage("ERRO DE CAMPO:{NOME} OBRIGATÓRIO");
           // RuleFor(cliente => cliente.Nome).Length(10, 50).WithMessage("Tamanho do campo nome deve estar entre 10 e 50!");
            RuleFor(cliente => cliente.Email).NotEmpty().WithMessage("ERRO DE CAMPO:{EMAIL} OBRIGATÓRIO").EmailAddress().WithMessage("EMAIL deve ser válido");
            RuleFor(cliente => cliente.tipoPessoa).IsInEnum().WithMessage("ERRO DE CAMPO:{TIPO PESSOA} DEVE SER ESPECIFICADO");
            
        }
    }
}
