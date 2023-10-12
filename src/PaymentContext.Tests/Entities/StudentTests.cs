using Microsoft.VisualStudio.TestTools.UnitTesting;
using PaymentContext.Domain.Entities;
using PaymentContext.Domain.Enums;
using PaymentContext.Domain.ValueObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PaymentContext.Tests.Entities
{
    [TestClass]
    public class StudentTests
    {
        private readonly Student _student;
        private readonly Subscription _subscription;
        private readonly Name _name;
        private readonly Address _address;
        private readonly Document _document;
        private readonly Email _email;

        public StudentTests()
        {
            _name = new Name("Jhin", "Four");
            _document = new Document("12354312254", EDocumentType.CPF);
            _email = new Email("lucas.fernandes0522@gmail.com");
            _address = new Address("Rua rift", "4", "Bot", "Ionia", "SP", "Ionia", "12331123");
            _student = new Student(_name, _document, _email);

        }

        [TestMethod]
        public void ShouldReturnErrorWhenHadActiveSubscription()
        {
            var subscription = new Subscription(null);
            var payment = new PayPalPayment("12345678", DateTime.Now, DateTime.Now.AddDays(5), 10, 10, "WAYNE CORP", _document, _address, _email);
            
            subscription.AddPayment(payment);

            _student.AddSubscription(subscription);
            _student.AddSubscription(subscription);

            Assert.IsTrue(_student.Invalid);
        }

        [TestMethod]
        public void ShouldReturnErrorWhenSubscriptionHasNoPayment()
        {
            var subscription = new Subscription(null);
            _student.AddSubscription(subscription);

            Assert.IsTrue(_student.Invalid);
        }

        [TestMethod]
        public void ShouldReturnSucessWhenHadNoActiveSubscription()
        {
            var subscription = new Subscription(null);
            var payment = new PayPalPayment("12345678", DateTime.Now, DateTime.Now.AddDays(5), 10, 10, "Riot", _document, _address, _email);
            subscription.AddPayment(payment);

            _student.AddSubscription(subscription);

            Assert.IsTrue(_student.Valid);
        }
    }
}
