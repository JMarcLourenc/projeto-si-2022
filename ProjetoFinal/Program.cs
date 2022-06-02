
using ProjetoFinal.Classes;
using System;


namespace ProjetoFinal
{
    class Program
    {
        static void Main()
        {
            try
            {
                cadastro:
                Console.Clear();
                Console.Write("Dados do Clientes 1\n\n");
                Console.Write("Nome.........: ");
                string NomeCliente1 = Console.ReadLine().ToUpper();
                
                Console.Write("CPF..........: ");
                string CpfCliente1 = Console.ReadLine();

                Console.Write("Data Nasc. ..: ");
                DateTime DataNascimentoCliente1 = Convert.ToDateTime(Console.ReadLine());

                Console.Write("Endereço.....: ");
                string EnderecoCliente1 = Console.ReadLine().ToUpper();

                Console.Write("Número Conta.: ");
                int NumeroConta1 = int.Parse(Console.ReadLine());

                Console.Write("Depósito Inicia..: R$ ");
                decimal DepositoInicialCliente1 = Decimal.Parse(Console.ReadLine());

                Console.Write("\n\nDados do Clientes 2\n\n");

                Console.Write("Nome.........: ");
                string NomeCliente2 = Console.ReadLine().ToUpper();

                Console.Write("CPF..........: ");
                string CpfCliente2 = Console.ReadLine();

                Console.Write("Data Nasc. ..: ");
                DateTime DataNascimentoCliente2 = Convert.ToDateTime(Console.ReadLine());

                Console.Write("Endereço.....: ");
                string EnderecoCliente2 = Console.ReadLine().ToUpper();

                Console.Write("Número Conta.: ");
                int NumeroConta2 = int.Parse(Console.ReadLine());

                Console.Write("Depósito Inicia..: R$ ");
                decimal DepositoInicialCliente2 = Decimal.Parse(Console.ReadLine());

                var cliente1 = Cliente.CreateCliente(NomeCliente1, CpfCliente1, DataNascimentoCliente1, EnderecoCliente1);
                var cliente2 = Cliente.CreateCliente(NomeCliente2, CpfCliente1, DataNascimentoCliente2, EnderecoCliente2);

                Console.Clear();
                Console.WriteLine(cliente1.ToString() + "\n\n" + cliente2.ToString());

                Conta contaCorrente = new ContaCorrente(cliente1, NumeroConta1, DepositoInicialCliente1);
                Conta contaPoupanca = new Poupanca(cliente2, NumeroConta2, DepositoInicialCliente2);

                menu:
                Console.Write("\n\n digite (N)ovo cadastro dos Clientes, (O)peração ou (S)air ...: ");
                string OpcaoMenu = Console.ReadLine().ToUpper();
                switch (OpcaoMenu)
                {
                    case "N":
                        goto cadastro;
                    case "O":
                        goto operacoes;
                    case "S":
                        break;
                    default:
                        Console.WriteLine("Digite somente as oções indicadas no menu");
                        break;
                }
            operacoes:
                Console.Clear();
                Console.Write("Qual operação deseja realizar");
                Console.Write("\n1-Conta Corrente (Deposito)\n2-Conta Corrente (Saque)\n3-Poupança (Deposito)\n4-Poupança (Saque)\n5-Transferência entre contas\n6-Sair\n\nDigite a Opção desejada....: ");
                string OpcaoOperacoes = Console.ReadLine().ToUpper();
                
                switch (OpcaoOperacoes)
                {
                    case "1":
                        Console.WriteLine("Saldo da Conta Corrente é R$ " + contaCorrente.Saldo);
                        Console.Write("\n\nEntre com o valor do deposito......: R$ ");
                        decimal ValorDoDepositoContaCorrente = Decimal.Parse(Console.ReadLine());
                        contaCorrente.Depositar(ValorDoDepositoContaCorrente);
                        Console.WriteLine("\n\nO Saldo da Conta Corrente atualizado é de R$ " + contaCorrente.Saldo);
                        Console.ReadKey();
                        goto operacoes;
                    case "2":
                        Console.WriteLine("Saldo da Conta Corrente é R$ " + contaCorrente.Saldo);
                        Console.Write("\n\nEntre com o valor do saque.........: R$ ");
                        decimal ValorDoSaqueContaCorrente = Decimal.Parse(Console.ReadLine());
                        contaCorrente.Sacar(ValorDoSaqueContaCorrente);
                        Console.WriteLine("\n\nO Saldo da Conta Corrente atualizado é de R$ " + contaCorrente.Saldo);
                        Console.ReadKey();
                        goto operacoes;
                    case "3":
                        Console.WriteLine("Saldo da Conta Corrente é R$ " + contaPoupanca.Saldo);
                        Console.Write("\n\nEntre com o valor do Deposito é de ...: R$ ");
                        decimal ValorDoDepositoContaPoupanca = Decimal.Parse(Console.ReadLine());
                        contaPoupanca.Depositar(ValorDoDepositoContaPoupanca);
                        Console.WriteLine("\n\nO Saldo da Conta Poupança atualizado é de R$ " + contaPoupanca.Saldo + "(Saldo + (Depósito + 5%))");
                        Console.ReadKey();
                        goto operacoes;
                    case "4":
                        Console.WriteLine("Saldo da Conta Corrente é R$ " + contaPoupanca.Saldo);
                        Console.Write("\n\nEntre com o valor do Deposito é de ...: R$ ");
                        decimal ValorDoSaqueContaPoupanca = Decimal.Parse(Console.ReadLine());
                        contaPoupanca.Sacar(ValorDoSaqueContaPoupanca);
                        Console.WriteLine("\n\nO Saldo da Conta Poupança atualizado é de R$ " + contaPoupanca.Saldo + "(Saldo - (Depósito + 10%))");
                        Console.ReadKey();
                        goto operacoes;
                    case "5":
                        goto transferencias;
                    case "6":
                        goto final;
                    default:
                        Console.WriteLine("Digite somente as oções indicadas no menu");
                        break;
                }
            
            transferencias:
            Console.Clear();
            Console.Write("Entre quais contas você deseja realizar a transferência");
            Console.Write("\n1-Conta Corrente para Poupança\n2-Poupança para Conta Corrente\n3-Voltar o menu de operações\n\nDigite a Opção desejada....: ");
            string OpcaoTransferencias = Console.ReadLine().ToUpper();

            switch (OpcaoTransferencias)
                {
                    case "1":
                        Console.WriteLine("Saldo da Conta Corrente de Origem é R$ " + contaCorrente.Saldo);
                        Console.Write("\n\nEntre com o valor da Transferencia....: R$ ");
                        decimal ValorDaTransferenciaContaCorrente = Decimal.Parse(Console.ReadLine());
                        contaCorrente.Transferir(ValorDaTransferenciaContaCorrente, contaPoupanca);
                        Console.WriteLine("\n\nSaldo atualziado da Conta Poupança de Destino é de R$ " + contaPoupanca.Saldo);
                        Console.ReadKey();
                        goto transferencias;
                    case "2":
                        Console.WriteLine("Saldo da Conta Poupança de Origem é R$ " + contaPoupanca.Saldo);
                        Console.Write("\n\nEntre com o valor da Transferencia....: R$ ");
                        decimal ValorDaTransferenciaContaPoupanca = Decimal.Parse(Console.ReadLine());
                        contaPoupanca.Transferir(ValorDaTransferenciaContaPoupanca, contaCorrente);
                        Console.WriteLine("\n\nSaldo atualziado da Conta Poupança de Destino é de R$ " + contaCorrente.Saldo);
                        Console.ReadKey();
                        goto transferencias;
                    case "3":
                        goto operacoes;
                    default:
                        Console.WriteLine("Digite somente as oções indicadas no menu");
                        break;

                }
            final:
                return;
            
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }
    }
}
