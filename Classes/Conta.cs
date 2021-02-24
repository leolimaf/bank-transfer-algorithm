using System;
using System.Text;

namespace DIO.Bank
{
    class Conta
    {
        private TipoConta TipoConta { get; set; }
        private double Saldo { get; set; }
        private string Nome { get; set; }
        private double Credito { get; set; }

        public Conta(TipoConta tipoConta, double saldo, double credito, string nome)
        {
            TipoConta = tipoConta;
            Saldo = saldo;
            Nome = nome;
            Credito = credito;
        }

        public bool Sacar(double valorSaque)
        {
            if (Saldo - valorSaque < Credito * (- 1))
            {
                Console.WriteLine("Saldo Isuficiente!");
                return false;
            }

            Saldo -= valorSaque;
            Console.WriteLine("Saldo atual da conta de {0}, {1}", Nome, Saldo);
            return true;
        }

        public void Depositar(double valorDeposito)
        {
            Saldo += valorDeposito;

            Console.WriteLine("Saldo atual da conta de {0} é {1}", Nome, Saldo);
        }

        public void Transferir(double valorTransferencia, Conta contaDestino)
        {
            if (Sacar(valorTransferencia))
            {
                contaDestino.Depositar(valorTransferencia);
            }
        }

        public override string ToString()
        {
            var sb = new StringBuilder();
            sb.Append("Tipo conta " + TipoConta + " | ");
            sb.Append("Nome " + Nome + " | ");
            sb.Append("Saldo " + Saldo + " | ");
            sb.Append("Crédito " + Credito);
            return sb.ToString();
        }
    }
}