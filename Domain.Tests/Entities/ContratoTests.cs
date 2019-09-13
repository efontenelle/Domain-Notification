using System;
using Domain.ContratoAggregate;
using Domain.Shared;
using Flunt.Notifications;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Domain.Tests.Entities
{
    [TestClass]
    public class ContratoTests : Notifiable
    {
        [TestMethod]
        public void NaoDeveCriarContratoValidoComNumeroContratoNulo()
        {
            var fabricaNumeroContrato = NumeroContrato.Criar("1234567");
            AddNotifications(fabricaNumeroContrato.Errors);

          

            var contrato = new Contrato(NumeroContrato.Criar("1234").Result, Opcao.NaoInformado, Opcao.NaoInformado);
            contrato.AddNotification("teste", "nova notificação");
            
        }
    }
}
