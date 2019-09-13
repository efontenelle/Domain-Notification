using Domain.Shared.ValueObject;
using Flunt.Validations;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.ContratoAggregate
{
    public class NumeroContrato
    {
        public string Numero { get; private set; }

        private NumeroContrato(string numero)
        {
            Numero = numero;
        }

        public static CreateValueObjectResult<NumeroContrato> Criar(string numeroContrato)
        {
            var contratoValidacao = new Contract()
            .Requires()
            .IsNotNullOrEmpty(numeroContrato, "NumeroContrato", "Número do contrato deve ser informado.");

            if(contratoValidacao.Valid)
                contratoValidacao = contratoValidacao.Requires()
                                                     .IsDigit(numeroContrato, "NumeroContrato", "Número do contrato deve ser númerico.")
                                                     .HasLen(numeroContrato, 12, "NumeroContrato", "Número do contrato precisa ter 12 posições.");
            if (contratoValidacao.Invalid)
                return CreateValueObjectResult<NumeroContrato>.CreateFailResult(contratoValidacao.Notifications);
            else
                return CreateValueObjectResult<NumeroContrato>.CreateSuccesResult(new NumeroContrato(numeroContrato));
        }
    }
}
