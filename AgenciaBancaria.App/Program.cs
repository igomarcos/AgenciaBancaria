using AgenciaBancaria.Dominio;
using System;

namespace AgenciaBancaria.App
{
    class Program
    {
        static void Main(string[] args)
        {
            try
            {
                Endereco endereco = new Endereco("carlos", "123456", "Guarulhos", "SP");

                Cliente cliente = new Cliente("igo", "12345567", "45678946454", endereco);

                ContaCorrente conta = new ContaCorrente(cliente, 100);

                string senha = "igo184545487";
                conta.Abrir(senha); //validaçao da conta atraves da senha

                Console.WriteLine("IGO BANK");
                Console.WriteLine();
                Console.WriteLine("PARABÉNS A SUA CONTA FOI CRIADA ");
                Console.WriteLine();
                Console.WriteLine("Esses é a sua agência e sua conta:"+ conta.Situacao);
                Console.WriteLine();
                Console.WriteLine("AGÊNCIA: 0001");
                Console.WriteLine("CONTA :" + conta.NumeroConta +"-" + conta.DigitoVerificador);
                Console.WriteLine();
                Console.WriteLine("SEU SALDO É:" + conta.Saldo);

                conta.Sacar(10, senha);


            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }

    }
}
