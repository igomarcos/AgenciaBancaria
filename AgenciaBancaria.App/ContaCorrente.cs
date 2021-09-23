﻿using AgenciaBancaria.Dominio;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AgenciaBancaria.App
{
    public class ContaCorrente : ContaBancaria
    {
        public ContaCorrente (Cliente cliente,decimal limite): base(cliente)
        {
            ValorTaxaManutencao = 0.05M;
            Limite = limite;
        }

        public override void Sacar(decimal valor, string senha)
        {
            if (Senha != senha)
            {
                throw new Exception("Senha Invalida");
            }

            if ((Saldo + Limite) < valor)
            {
                throw new Exception("Saldo Insuficiente");
            }

            Saldo -= valor;
        }


        public decimal Limite { get;private set; }

        public decimal ValorTaxaManutencao { get; private set; }


    }
}
