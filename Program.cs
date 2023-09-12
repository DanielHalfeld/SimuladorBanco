using SimuladorBanco;
using System;
using static SimuladorBanco.Conta;

namespace SimuladorBanco
{
    class Program
    {
        private Conta conta1 = null;
        private Conta conta2 = null;
        private Cliente cliente1 = null;
        private Cliente cliente2 = null;
        private Agencia agencia1 = null;
        private Agencia agencia2 = null;
        private Banco banco = null;

        public void Exec()
        {
            while (true)
            {
                Console.WriteLine("Menu Inicial:");
                Console.WriteLine("1 - Criar contas");
                Console.WriteLine("0 - Sair");

                int escolhaInicial = int.Parse(Console.ReadLine());

                switch (escolhaInicial)
                {
                    case 1:
                        Informacoes();
                        Menu();
                        break;
                    case 0:
                        Console.WriteLine("Saindo do programa.");
                        return;
                    default:
                        Console.WriteLine("Opção inválida.");
                        break;
                }
            }
        }

        private void Menu()
        {
            bool contasInseridas = true;

            while (true)
            {
                Console.WriteLine("Menu Principal:");
                Console.WriteLine("2 - Saldo Total Geral");
                Console.WriteLine("3 - Dados do Cliente 1");
                Console.WriteLine("4 - Dados do Cliente 2");
                Console.WriteLine("5 - Saque da Conta 1");
                Console.WriteLine("6 - Saque da Conta 2");
                Console.WriteLine("7 - Depósito da Conta 1");
                Console.WriteLine("8 - Depósito da Conta 2");
                Console.WriteLine("0 - Sair");

                int escolha = int.Parse(Console.ReadLine());

                switch (escolha)
                {
                    case 2:
                        if (contasInseridas)
                        {
                            decimal saldoTotal = Conta.CalcularSaldoTotal(conta1, conta2);
                            Console.WriteLine($"Saldo total geral: {saldoTotal}");
                        }
                        else
                        {
                            Console.WriteLine("Por favor, insira as informações das contas primeiro.");
                        }
                        break;
                    case 3:
                        if (contasInseridas)
                        {
                            MostrarDadosCliente(cliente1, conta1, banco, agencia1);
                        }
                        else
                        {
                            Console.WriteLine("Por favor, insira as informações das contas primeiro.");
                        }
                        break;
                    case 4:
                        if (contasInseridas)
                        {
                            MostrarDadosCliente(cliente2, conta2, banco, agencia2);
                        }
                        else
                        {
                            Console.WriteLine("Por favor, insira as informações das contas primeiro.");
                        }
                        break;
                    case 5:
                        if (conta1 != null)
                        {
                            RealizarSaque(conta1);
                        }
                        else
                        {
                            Console.WriteLine("Conta 1 não está definida.");
                        }
                        break;
                    case 6:
                        if (conta2 != null)
                        {
                            RealizarSaque(conta2);
                        }
                        else
                        {
                            Console.WriteLine("Conta 2 não está definida.");
                        }
                        break;
                    case 7:
                        if (conta1 != null)
                        {
                            AdicionarDinheiro(conta1);
                        }
                        else
                        {
                            Console.WriteLine("Conta 1 não está definida.");
                        }
                        break;
                    case 8:
                        if (conta2 != null)
                        {
                            AdicionarDinheiro(conta2);
                        }
                        else
                        {
                            Console.WriteLine("Conta 2 não está definida.");
                        }
                        break;
                    case 0:
                        Console.WriteLine("Saindo do programa.");
                        return;
                    default:
                        Console.WriteLine("Opção inválida.");
                        break;
                }
            }
        }

        private void Informacoes()
        {
            Console.WriteLine("Informe o nome do cliente 1:");
            string nomeCliente1 = Console.ReadLine();
            Console.WriteLine("Informe a idade do cliente 1 (maior que 18 anos):");
            int idadeCliente1 = Convert.ToInt32(Console.ReadLine());

            if (idadeCliente1 <= 18)
            {
                Console.WriteLine("A idade do cliente 1 deve ser maior que 18 anos.");
                return;
            }

            Console.WriteLine("Informe o CPF do cliente 1 (11 dígitos):");
            string cpfCliente1 = Console.ReadLine();

            if (cpfCliente1.Length != 11)
            {
                Console.WriteLine("O CPF do cliente 1 deve ter 11 dígitos.");
                return;
            }

            Console.WriteLine("Informe o número da agência 1:");
            int numeroAgencia1 = Convert.ToInt32(Console.ReadLine());
            Console.WriteLine("Informe o CEP da agência 1:");
            string cepAgencia1 = Console.ReadLine();
            Console.WriteLine("Informe o telefone da agência 1:");
            string telefoneAgencia1 = Console.ReadLine();
            agencia1 = new Agencia(numeroAgencia1, cepAgencia1, telefoneAgencia1);

            Console.WriteLine("Informe o número da conta 1:");
            long numeroConta1 = Convert.ToInt64(Console.ReadLine()); // Aqui está o número da conta 1
            Console.WriteLine("Informe o saldo inicial da conta 1 (maior que 10):");
            decimal saldoConta1 = Convert.ToDecimal(Console.ReadLine()); // Aqui está o saldo inicial da conta 1

            if (saldoConta1 <= 10)
            {
                Console.WriteLine("O saldo da conta 1 deve ser maior que 10.");
                return;
            }

            Console.WriteLine("Informe o nome do cliente 2:");
            string nomeCliente2 = Console.ReadLine();
            Console.WriteLine("Informe a idade do cliente 2 (maior que 18 anos):");
            int idadeCliente2 = Convert.ToInt32(Console.ReadLine());

            if (idadeCliente2 <= 18)
            {
                Console.WriteLine("A idade do cliente 2 deve ser maior que 18 anos.");
                return;
            }

            Console.WriteLine("Informe o CPF do cliente 2 (11 dígitos):");
            string cpfCliente2 = Console.ReadLine();

            if (cpfCliente2.Length != 11)
            {
                Console.WriteLine("O CPF do cliente 2 deve ter 11 dígitos.");
                return;
            }

            Console.WriteLine("Informe o número da agência 2:");
            int numeroAgencia2 = Convert.ToInt32(Console.ReadLine());
            Console.WriteLine("Informe o CEP da agência 2:");
            string cepAgencia2 = Console.ReadLine();
            Console.WriteLine("Informe o telefone da agência 2:");
            string telefoneAgencia2 = Console.ReadLine();
            agencia2 = new Agencia(numeroAgencia2, cepAgencia2, telefoneAgencia2);

            Console.WriteLine("Informe o número da conta 2:");
            long numeroConta2 = Convert.ToInt64(Console.ReadLine()); // Aqui está o número da conta 2
            Console.WriteLine("Informe o saldo inicial da conta 2 (maior que 10):");
            decimal saldoConta2 = Convert.ToDecimal(Console.ReadLine()); // Aqui está o saldo inicial da conta 2

            if (saldoConta2 <= 10)
            {
                Console.WriteLine("O saldo da conta 2 deve ser maior que 10.");
                return;
            }

            Console.WriteLine("Informe o nome do banco:");
            string nomeBanco = Console.ReadLine();
            Console.WriteLine("Informe o número do banco:");
            int numeroBanco = Convert.ToInt32(Console.ReadLine());
            banco = new Banco(nomeBanco, numeroBanco);

            conta1 = new Conta(numeroConta1, agencia1, banco, saldoConta1);
            cliente1 = new Cliente(nomeCliente1, idadeCliente1, cpfCliente1);

            conta2 = new Conta(numeroConta2, agencia2, banco, saldoConta2);
            cliente2 = new Cliente(nomeCliente2, idadeCliente2, cpfCliente2);
        }

        private void MostrarDadosCliente(Cliente cliente, Conta conta, Banco banco, Agencia agencia)
        {
            Console.WriteLine($"Dados do cliente: {cliente.Nome}, CPF: {cliente.CPF}, Saldo: R${conta.Saldo}");
            Console.WriteLine($"Idade em decimal: {cliente.Idade} anos");
            Console.WriteLine($"Idade em romanos: {cliente.Romano()}");
            Console.WriteLine($"Número da Conta: {conta.Numero}");
            Console.WriteLine($"Número da Agência: {agencia.Numero}");
            Console.WriteLine($"Nome do Banco: {banco.Nome}");
            Console.WriteLine($"Número do Banco: {banco.Numero}");
        }

        private void RealizarSaque(Conta conta)
        {
            Console.WriteLine($"Digite o valor do saque da Conta {conta.Numero}:");
            decimal valorSaque = Convert.ToDecimal(Console.ReadLine());
            conta.Saque(valorSaque);
            Console.WriteLine($"Saldo da Conta {conta.Numero} após saque: {conta.Saldo}");
        }

        private void AdicionarDinheiro(Conta conta)
        {
            Console.WriteLine($"Digite o valor a ser adicionado à Conta {conta.Numero}:");
            decimal valorAdicionar = Convert.ToDecimal(Console.ReadLine());
            conta.AtualizarSaldo(valorAdicionar);
            Console.WriteLine($"Saldo da Conta {conta.Numero} após adição: {conta.Saldo}");
        }
        public static void Main(string[] args)
        {
            Program exec = new Program();
            exec.Exec();
        }
    }
}