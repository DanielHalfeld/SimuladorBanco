using SimuladorBanco;
using System;

namespace SimuladorBanco
{
    public class Conta
    {
        public class Agencia
        {
            public int Numero { get; private set; }
            public string CEP { get; private set; }
            public string Telefone { get; private set; }

            public Agencia(int numero, string cep, string telefone)
            {
                Numero = numero;
                CEP = cep;
                Telefone = telefone;
            }
        }

        public class Banco
        {
            public string Nome { get; private set; }
            public int Numero { get; private set; }

            public Banco(string nome, int numero)
            {
                Nome = nome;
                Numero = numero;
            }
        }

        public Conta(long numero, Agencia agencia, Banco banco, decimal saldoInicial)
        {
            this.Numero = numero;
            this.Saldo = saldoInicial; // Não verifica mais o saldo inicial
            this.Titular = null;
            this.agencia = agencia;
            this.banco = banco;
        }

        public long Numero { get; private set; }
        public decimal Saldo { get; private set; }
        public Cliente? Titular { get; private set; }
        public Agencia agencia { get; private set; }
        public Banco banco { get; private set; }
        public static decimal SaldoTotalGeral { get; private set; }

        public decimal Saque(decimal valorSaque)
        {
            if (valorSaque > Saldo)
            {
                Console.WriteLine("Saldo insuficiente para saque");
                return Saldo;
            }

            Saldo -= valorSaque;
            return Saldo;
        }

        public void AtualizarSaldo(decimal novoSaldo)
        {
            if (novoSaldo <= 10.00m)
            {
                Console.WriteLine("O valor a ser adicionado à conta deve ser maior que R$10,00.");
                Environment.Exit(0);
            }

            Saldo += novoSaldo;
        }

        public void DefinirCliente(Cliente cliente)
        {
            if (cliente != null)
            {
                this.Titular = cliente;
            }
            else
            {
                Console.WriteLine("Cliente inválido");
            }
        }

        public static decimal CalcularSaldoTotal(params Conta[] contas)
        {
            decimal saldoTotal = 0;

            foreach (var conta in contas)
            {
                saldoTotal += conta.Saldo;
            }

            return saldoTotal;
        }
    }
}
