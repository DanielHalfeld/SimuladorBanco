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
        public int anoNascimento { get; set; }
        public string CPF { get; set; }
        public Cliente() { }
        public Cliente(string nome, int anoNascimento, string CPF)
        {
            this.Nome = nome;
            this.CPF = CPF;
            this.anoNascimento = anoNascimento;
        }
    }
}
