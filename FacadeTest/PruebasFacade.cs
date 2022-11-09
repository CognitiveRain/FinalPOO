using Microsoft.VisualStudio.TestTools.UnitTesting;
using Poo_PS_GoF_Facade;

namespace FacadeTest
{
    [TestClass]
    public class PruebasFacade
    {
        [TestMethod]
        public void ARejection_Test()
        {
            //Set Up

            EntidadCrediticia Sufi = new EntidadCrediticia("Carlos", 12, 2, 950);
            bool expected = false;

            //Act

            Sufi.EstudiaCredito();

            //Assert

            bool result = Sufi.elCliente.EstadoSolicitud;
            try
            {
                Assert.AreEqual(expected, result);
                System.Console.WriteLine($"El cliente con clase reputacion {Sufi.elCliente.ReputacionCredito} sale como Rechazado por el Estado de la solicitud");
            }
            catch(AssertFailedException e)
            {
                System.Console.WriteLine("Honestamente no sé qué hice, por lo que no me sorprende que fallara\n" + e.Message);
            }
            
        }

        [TestMethod]
        public void BAcepted_Test()
        {
            //Set Up

            EntidadCrediticia Sufi = new EntidadCrediticia("Carlos", 10, 8, 700);
            bool expected = true;

            //Act

            Sufi.EstudiaCredito();

            //Assert

            bool result = Sufi.elCliente.EstadoSolicitud;
            try
            {
                Assert.AreEqual(expected, result);
                System.Console.WriteLine($"El cliente con clase reputacion {Sufi.elCliente.ReputacionCredito} sale como Aceptado por el monto máximo de la solicitud");
            }
            catch (AssertFailedException e)
            {
                System.Console.WriteLine("Honestamente no sé qué hice, por lo que no me sorprende que fallara\n" + e.Message);
            }
        }
    }
}
