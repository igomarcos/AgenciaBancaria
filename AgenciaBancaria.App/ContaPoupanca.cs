using AgenciaBancaria.Dominio;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AgenciaBancaria.App
{
    public class ContaPoupanca : ContaBancaria
    {
        public ContaPoupanca(Cliente cliente) : base(cliente)
        {
            PercentualRendimento = 0.003M;       //significa que a conta poupanca renderá 0,30% ao mes
        }

        public decimal PercentualRendimento { get; private set; }

    }
}
