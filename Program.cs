using SimuladorBanco;
using System;
using static SimuladorBanco.Conta;
class Program
{
     static void Main(string[] args)
    {
        Console.WriteLine("Informe a quantidade de contas que deseja criar: ");

        int cont = int.Parse(Console.ReadLine());

        Conta[] contasList = new Conta[cont];
        Cliente[] clienteList = new Cliente[cont];

        bool contasInseridas = false;
        Exec();

        void Exec()
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

        void Informacoes()
        {
            for (int x = 0; x < cont; x++)
            {

                Console.WriteLine("Informe o nome do cliente:");
                string nomeCliente = Console.ReadLine();
                Console.WriteLine("Informe a idade do cliente (maior que 18 anos):");
                int idadeCliente = Convert.ToInt32(Console.ReadLine());

                if (idadeCliente <= 18)
                {
                    Console.WriteLine("A idade do cliente deve ser maior que 18 anos.");
                    return;
                }

                Console.WriteLine("Informe o CPF do cliente (11 dígitos):");
                string cpfCliente = Console.ReadLine();

                if (cpfCliente.Length != 11)
                {
                    Console.WriteLine("O CPF do cliente deve ter 11 dígitos.");
                    return;
                }

                Console.WriteLine("Informe o número da agência :");
                int numeroAgencia = Convert.ToInt32(Console.ReadLine());
                Console.WriteLine("Informe o CEP da agência:");
                string cepAgencia = Console.ReadLine();
                Console.WriteLine("Informe o telefone da agência:");
                string telefoneAgencia = Console.ReadLine();

                Agencia agencia = new Agencia(numeroAgencia, cepAgencia, telefoneAgencia); 

                Console.WriteLine("Informe o número da conta:");
                long numeroConta = Convert.ToInt64(Console.ReadLine());
                Console.WriteLine("Informe o saldo inicial da conta (maior que 10):");
                decimal saldoConta = Convert.ToDecimal(Console.ReadLine());

                if (saldoConta <= 10)
                {
                    Console.WriteLine("O saldo da conta deve ser maior que 10.");
                    return;
                }

                Console.WriteLine("Informe o nome do banco:");
                string nomeBanco = Console.ReadLine();
                Console.WriteLine("Informe o número do banco:");
                int numeroBanco = Convert.ToInt32(Console.ReadLine());
                Banco banco = new Banco(nomeBanco, numeroBanco);

                contasList[x] = new Conta(numeroConta, agencia, banco, saldoConta);
                clienteList[x] = new Cliente(nomeCliente, idadeCliente, cpfCliente);
                contasInseridas = true;
            }
        }

        void Menu()
        {
            while (true)
            {
                Console.WriteLine("Menu Principal:");
                Console.WriteLine("1 - Saldo Total Geral");
                Console.WriteLine("2 - Mostrar dados do cliente");
                Console.WriteLine("3 - Fazer saque");
                Console.WriteLine("4 - Fazer depósito");
                Console.WriteLine("0 - Sair");

                Int64 escolha = Int64.Parse(Console.ReadLine());

                switch (escolha)
                {
                    case 1:
                        if (contasInseridas == true)
                        {

                            decimal saldoTotal = CalcularSaldoTotal(contasList);
                            Console.WriteLine($"Saldo total geral: {saldoTotal}");
                        }
                        else
                        {
                            Console.WriteLine("Por favor, insira as informações das contas primeiro.");
                        }
                        break;
                    case 2:
                        if (contasInseridas == true)
                        {
                            MostrarDadosCliente();
                        }
                        else
                        {
                            Console.WriteLine("Por favor, insira as informações das contas primeiro.");
                        }
                        break;
                    case 3:
                        if (contasInseridas == true)
                        {
                            RealizarSaque();
                        }
                        else
                        {
                            Console.WriteLine("Por favor, insira as informações das contas primeiro.");
                        }
                        break;
                    case 4:
                        if (contasInseridas == true)
                        {
                            AdicionarDinheiro();
                        }
                        else
                        {
                            Console.WriteLine("Por favor, insira as informações das contas primeiro.");
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

        void MostrarDadosCliente()
        {
            Console.WriteLine($"Qual dos clientes você deseja as informações? (de 0 até {cont - 1})");
            int cli = int.Parse(Console.ReadLine());
            if ( cli < 0 && cli >= cont ) {
                Console.WriteLine("Esse cliente não existe.");
            }
            else {
                Console.WriteLine($"Nome: {clienteList[cli].Nome}, CPF: {clienteList[cli].CPF}, Saldo: R${contasList[cli].Saldo}");
                Console.WriteLine($"Idade em decimal: {clienteList[cli].Idade} anos");
                Console.WriteLine($"Idade em romanos: {clienteList[cli].Romano()}");
                Console.WriteLine($"Número da Conta: {contasList[cli].Numero}");
                Console.WriteLine($"Número da Agência: {contasList[cli].agencia.Numero}");
                Console.WriteLine($"Nome do Banco: {contasList[cli].banco.Nome}");
                Console.WriteLine($"Número do Banco: {contasList[cli].banco.Numero}");
            }
        }

        void RealizarSaque()
        {
            Console.WriteLine($"Qual dos clientes deseja realizar o saque? (de 0 até {cont - 1})");
            int cli = int.Parse(Console.ReadLine());
            if (cli < 0 && cli >= cont)
            {
                Console.WriteLine("Esse cliente não existe.");
            }
            else
            {

                Console.WriteLine($"Digite o valor do saque da Conta {contasList[cli].Numero}:");
                decimal valorSaque = Convert.ToDecimal(Console.ReadLine());
                contasList[cli].Saque(valorSaque);
                Console.WriteLine($"Saldo da Conta {contasList[cli].Numero} após saque: {contasList[cli].Saldo}");
            }
        }

        void AdicionarDinheiro()
        {
            Console.WriteLine($"Qual dos clientes deseja realizar o depósito? (de 0 até {cont - 1})");
            int cli = int.Parse(Console.ReadLine());
            if (cli < 0 && cli >= cont)
            {
                Console.WriteLine("Esse cliente não existe.");
            }
            else
            {
                Console.WriteLine($"Digite o valor a ser adicionado à Conta {contasList[cli].Numero}:");
                decimal valorAdicionar = Convert.ToDecimal(Console.ReadLine());
                contasList[cli].AtualizarSaldo(valorAdicionar);
                Console.WriteLine($"Saldo da Conta {contasList[cli].Numero} após adição: {contasList[cli].Saldo}");
            }
        }
    }
}
