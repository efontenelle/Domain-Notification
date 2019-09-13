using System;
using Domain.Shared;
using Domain.Shared.Entity;
using Flunt.Validations;

namespace Domain.ContratoAggregate
{
    public class Contrato : Entity
    {
        public Contrato(NumeroContrato numeroContrato, Opcao possuiVesting, Opcao possuiPenalidade)
        {
            NumeroContrato = numeroContrato;
            PossuiVesting = possuiVesting;
            PossuiPenalidade = possuiPenalidade;
            Status = StatusContrato.EmCadastramento;

            Validar();
        }

        private void Validar()
        {
            AddNotifications(new Contract()
                                 .Requires()
                                 .IsNotNull(NumeroContrato, "NumeroContrato", "Número contrato deve ser informado."));
        }

        public NumeroContrato NumeroContrato { get; private set; }
        public Opcao PossuiVesting { get; private set; }
        public Opcao PossuiPenalidade { get; private set; }
        public StatusContrato Status { get; private set; }

        public void Ativar()
        {
            AddNotifications(new Contract().Requires()
                                           .IsTrue(PossuiPenalidade != Opcao.NaoInformado,"Possui Penalidadse", "Opção de penalidade deve ser informada");

            if (Valid)
                Status = StatusContrato.Ativo;
        }


    }
}
