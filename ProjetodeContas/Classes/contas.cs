using System;
namespace ProjetodeContas
{
	public class Conta
	{
		private TipoConta TipoConta { get; set; }
		private double Saldo { get; set; }
		private double Credito { get; set; }
		private string Nome { get; set; }
		public Conta(TipoConta tipoConta, double saldo, double credito, string nome) 
		{
			this.TipoConta = tipoConta;
			this.Saldo = saldo;
			this.Credito = credito;
			this.Nome = nome;
		}
		public bool Sacar(double valorSaque)
        {
			if (this.Saldo - valorSaque < (this.Credito *-1))
            {
				Console.WriteLine("Saldo insuficiente!");
				return false;
            }
			this.Saldo = this.Saldo - valorSaque;
			Console.WriteLine("Saldo atual da conta de {0} é {1}", this.Nome, this.Saldo);
			//Em "{0}" e "{1}" será os dados mostrados para o usuário, esses dados são respectivamente:
			//{0} para o Nome;
			//{1} para o Saldo.	
			return true;
		}
		public void Depositar(double ValorDeposito)
        {
			this.Saldo = this.Saldo + ValorDeposito;
			Console.WriteLine("Saldo atual da conta de {0} é {1}", this.Nome, this.Saldo);
        }
		public void Transferir(double ValorTransferencia, Conta contadestino)
		{
			if (this.Sacar(ValorTransferencia))
            {
				contadestino.Depositar(ValorTransferencia);
            }
		}
        public override string ToString()
        {
			string retorno = "";
			retorno += "Tipo da conta: " + this.TipoConta + " | ";
			retorno += "Titular: " + this.Nome + " | ";
			retorno += "Saldo R$ " + this.Saldo + " | ";
			retorno += "Crédito R$ " + this.Credito + " | ";
			return retorno;
        }
    }

}
