using System;

namespace ProjetoFinal.Classes
{
    public abstract class Conta
    {
        public Conta(Cliente cliente, int numero, decimal saldo)
        {
            if (!cliente.EhMaiorIDade)
                throw new Exception("O cliente não possúi a idade mínima para criação da conta!");

            if (numero.ToString().Length < 5)
                throw new Exception("Número da conta inválido!");

            Cliente = cliente;
            Numero = numero;
            Saldo = saldo;
        }

        private decimal _saldo;

        public int Numero { get; private set; }

        public Cliente Cliente { get; private set; }

        public string MensagemTransacoes { get; protected set; }

        public decimal Saldo
        {
            get { return _saldo; }
            protected set
            {
                if (value >= 0)
                    _saldo = value;
                else
                    _saldo = 0;
            }
        }

        public abstract bool Sacar(decimal valorSaque);

        public abstract bool Depositar(decimal valorDeposito);

        public void Transferir(decimal valor, Conta destino)
        {
            var sucessoTransferenciaSaque = Sacar(valor);
            var sucessoTransferenciaDeposito = destino.Depositar(valor);

            if (sucessoTransferenciaSaque && sucessoTransferenciaDeposito)
            {
                MensagemTransacoes = "Transferência realizada com suceso!!";
            }

            MensagemTransacoes = "Falha na operação!!!";
        }
    }
}
