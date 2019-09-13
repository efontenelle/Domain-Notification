using System;
using System.Linq;
using Domain.ContratoAggregate;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Domain.Tests.ValueObjects
{
    [TestClass]
    public class NumeroContratoTests
    {
        [TestMethod]
        public void NaoDeveCriarNumeroContratoNulo()
        {
            var resultado = NumeroContrato.Criar(null);

            Assert.AreEqual(null, resultado.Result);
            Assert.IsFalse(resultado.Created);
            Assert.AreEqual(1, resultado.Errors.Count);
            Assert.AreEqual("Número do contrato deve ser informado.", resultado.Errors.ElementAt(0).Message);
        }
        [TestMethod]
        public void NaoDeveCriarNumeroContratoParaValorNaoNumerico()
        {
            var resultado = NumeroContrato.Criar("12345678901a");

            Assert.AreEqual(null, resultado.Result);
            Assert.IsFalse(resultado.Created);
            Assert.AreEqual(1, resultado.Errors.Count);
            Assert.AreEqual("Número do contrato deve ser númerico.", resultado.Errors.ElementAt(0).Message);
        }
        [TestMethod]
        public void NaoDeveCriarNumeroContratoComNumeroDiferente12Posicoes()
        {
            var resultado = NumeroContrato.Criar("1234567");

            Assert.AreEqual(null, resultado.Result);
            Assert.IsFalse(resultado.Created);
            Assert.AreEqual(1, resultado.Errors.Count);
            Assert.AreEqual("Número do contrato precisa ter 12 posições.", resultado.Errors.ElementAt(0).Message);
        }

        [TestMethod]
        public void DeveCriarNumeroContratoValido()
        {
            var resultado = NumeroContrato.Criar("123456789012");

            Assert.IsTrue(resultado.Created);
            Assert.AreNotEqual(null, resultado.Result);
            Assert.IsFalse(resultado.Errors.Any());
            Assert.AreEqual("123456789012", resultado.Result.Numero);
        }
    }
}
