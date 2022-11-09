using Microsoft.VisualStudio.TestTools.UnitTesting;
using Poo_PS_GoF_ChainOfResponsibility;

namespace ResponsabilidadPruebas
{
    [TestClass]
    public class PruebasUnitaria
    {
        [TestMethod]
        public void Test_AprobadoPorDirector()
        {
            //Set Up

            Ejecutivo[] Jerarquia = new Ejecutivo[3];
            Jerarquia[0] = new Coordinador();
            Jerarquia[1] = new Director();
            Jerarquia[2] = new Presidente();

            Jerarquia[0].Monto = 2;
            Jerarquia[1].Monto = 4;
            Jerarquia[2].Monto = 6;

            for(int i = 0; i <2; i++)
            {
                Jerarquia[i].AsignaJefe(Jerarquia[i + 1]);
            }
            Pedido PedidoPrueba = new Pedido();
            PedidoPrueba.Valor = 3;

            string Expected = "Aprobado por Director Director sin nombre";

            //Act

            Jerarquia[0].ProcesaPedido(PedidoPrueba);

            //Assert

            string Result = PedidoPrueba.Aprobador;
            try
            {
                Assert.AreEqual(Expected, Result);
                System.Console.WriteLine("Aprobado por el director funcional");
            }
            catch(AssertFailedException e)
            {
                System.Console.WriteLine("Aprobado por el director falla\n" + e.Message);
            }
        }

        [TestMethod]
        public void Test_JuntaDirectiva()
        {
            //Set Up

            Ejecutivo[] Jerarquia = new Ejecutivo[3];
            Jerarquia[0] = new Coordinador();
            Jerarquia[1] = new Director();
            Jerarquia[2] = new Presidente();

            Jerarquia[0].Monto = 2;
            Jerarquia[1].Monto = 4;
            Jerarquia[2].Monto = 6;

            for (int i = 0; i < 2; i++)
            {
                Jerarquia[i].AsignaJefe(Jerarquia[i + 1]);
            }
            Pedido PedidoPrueba = new Pedido();
            PedidoPrueba.Valor = 8;

            string Expected = "El pedido debe aprobarse en Junta Directiva";

            //Act

            Jerarquia[0].ProcesaPedido(PedidoPrueba);

            //Assert

            string Result = PedidoPrueba.Aprobador;
            try
            {
                Assert.AreEqual(Expected, Result);
                System.Console.WriteLine("Llamada a Junta funcional");
            }
            catch (AssertFailedException e)
            {
                System.Console.WriteLine("Pailander, tuki tuki muñeco\n" + e.Message);
            }
        }
    }
}
