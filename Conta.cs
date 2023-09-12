using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SimuladorBanco
{
    class Conta
    {
        private int numero;
        private decimal saldo;

        public int Numero
        {
            get => numero; 
            set => numero = value;
        }

        public decimal Saldo
        {
            get
            {
                return saldo;
            }
            set
            {if (value >= 0.0m)
                {
                    saldo = value;
                } else
                {
                    Console.WriteLine("O saldo não pode ser definido como negativo");
                }
            }
        }
        public void deposito(decimal valor)
        {
            if (valor > 0)
            {
                saldo += valor;
            }
        }
    }
}
