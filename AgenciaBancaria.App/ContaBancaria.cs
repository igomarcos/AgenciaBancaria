using AgenciaBancaria.Dominio;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace AgenciaBancaria.App
{
    public abstract class ContaBancaria
    {
        public ContaBancaria(Cliente cliente)
        {
            Random random = new Random();        //essa classe puxada da biblioteca system cria um numero randomico( aleatorio).
            NumeroConta = random.Next(50000, 100000);
            DigitoVerificador = random.Next(0, 9);

            Situacao = SituacaoConta.Criada;

            Cliente = cliente ?? throw new Exception("o Cliente de ser informado.");
        }

        public void Abrir( string senha)
        {
            SetaSenha(senha);

            Senha = senha.ValidaStringVazia();

            Situacao = SituacaoConta.Aberta;
            DataAbertura = DateTime.Now;
        }
        private void SetaSenha(string senha)
        {
            senha = senha.ValidaStringVazia();

            if (!Regex.IsMatch(senha, @"^(?=.*?[a-z])(?=.*?[0-9]).{8,}$"))     //valida de acordo com uma expressão regular, nesse caso essa senha deverar ter pelo menos uma letra, um numero e ate 8 caracteres.
            {
                throw new Exception("senha invalida");
            }

            Senha = senha;
        }

        public virtual void Sacar(decimal valor, string senha)
        {
            if(Senha != senha)
            {
                throw new Exception("Senha Invalida");
            }

            if(Saldo < valor) 
            {
                throw new Exception("Saldo Insuficiente");
            }

            Saldo -= valor;
        }

        public int NumeroConta { get; init; }
        public int DigitoVerificador { get; init; }
        public decimal Saldo { get; protected set; }
        public DateTime? DataAbertura { get; private set; }
        public DateTime?  DataEncerramento { get; private set; }
        public SituacaoConta  Situacao { get; private set; }
        public string Senha { get; private set; }
        public Cliente Cliente { get; init; }

    }
}
