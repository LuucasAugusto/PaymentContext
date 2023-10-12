using Microsoft.VisualStudio.TestTools.UnitTesting;
using PaymentContext.Domain.Commands;
using PaymentContext.Domain.Enums;
using PaymentContext.Domain.Handlers;
using PaymentContext.Tests.Mocks;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PaymentContext.Tests.Handlers
{
    [TestClass]
    public class SubscriptionHandlerTests
    {
        // Red, Green, Refactor

        [TestMethod]
        public void ShouldReturnErrorWhenDocumentExists()
        {
            var handler = new SubscriptionHandler(new FakeStudentRepository(), new FakeEmailService());
            var command = new CreateBoletoSubscriptionCommand();
            command.FirstName = "Jhin";
            command.LastName = "Augusto";
            command.Document = "99999999999";
            command.Email = "Pkred@ORed.io2";
            command.BarCode = "123456789";
            command.BoletoNumber = "1234654987";
            command.PaymentNumber = "123121";
            command.PaidDate = DateTime.Now;
            command.ExpireDate = DateTime.Now.AddMonths(1);
            command.Total = 60;
            command.TotalPaid = 60;
            command.Payer = "Riot";
            command.PayerDocument = "12345678911";
            command.PayerDocumentType = EDocumentType.CPF;
            command.PayerEmail = "batman@dc.com";
            command.Street = "Rua";
            command.Number = "123";
            command.Neighborhood = "Bairro";
            command.City = "Cidade";
            command.State = "Liquido";
            command.Country = "Pais";
            command.ZipCode = "12345678";

            handler.Handle(command);
            Assert.AreEqual(false, handler.Valid);
        }
    }
}
