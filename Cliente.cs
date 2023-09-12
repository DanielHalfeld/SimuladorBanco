using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SimuladorBanco
{
    public class Cliente
    {
        public string Nome { get; set; }
        public int Idade { get; set; }
        public string CPF { get; private set; }

        public Cliente(string nome, int idade, string cpf)
        {
            if (idade > 18 && cpf.Length == 11)
            {
                Nome = nome;
                Idade = idade;
                CPF = cpf;
            }
            else
            {
                Console.WriteLine("Dados inválidos");
                Environment.Exit(0);
            }
        }

        public string CalcularIdadeRomana()
        {
            int idade = this.Idade;
            if (idade <= 0)
                return "Desconhecida";

            string romano = string.Empty;

            string[] unidades = { "I", "II", "III", "IV", "V", "VI", "VII", "VIII", "IX" };
            string[] dezenas = { "X", "XX", "XXX", "XL", "L", "LX", "LXX", "LXXX", "XC" };
            string[] centenas = { "C", "CC", "CCC", "CD", "D", "DC", "DCC", "DCCC", "CM" };

            if (idade >= 100)
            {
                romano += centenas[(idade / 100) - 1];
                idade %= 100;
            }
            if (idade >= 10)
            {
                romano += dezenas[(idade / 10) - 1];
                idade %= 10;
            }
            if (idade > 0)
            {
                romano += unidades[idade - 1];
            }

            return romano;
        }
    }
}
