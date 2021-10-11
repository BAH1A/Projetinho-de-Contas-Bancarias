using System;
using System.Collections.Generic;

namespace ProjetodeContas
{
    class Program
    {
        static List<Conta> ListConta = new List<Conta>();
        static void Main(string[] args)
        {
            string opcaoUsuario = ObterOpcaoUsuario();

            while (opcaoUsuario.ToUpper() != "X")
            {
                switch (opcaoUsuario)
                {
                    case "1":
                        ListarContas();
                        break;

                    case "2":
                        InserirConta();
                        break;

                    case "3":
                        Transferir();
                        break;

                    case "4":
                        Sacar();
                        break;

                    case "5":
                        Depositar();
                        break;

                    case "C":
                        Console.Clear();
                        break;
                    default:
                        throw new ArgumentOutOfRangeException();
                }
                opcaoUsuario = ObterOpcaoUsuario();
            }
        }

        private static void Depositar()
        {
            Console.Write("Digite o número da conta: ");
            int indiceConta = int.Parse(Console.ReadLine());

            Console.Write("Qual valor de deposito? ");
            double valorDeposito = int.Parse(Console.ReadLine());

            ListConta[indiceConta].Depositar(valorDeposito);
        }

        private static void Sacar()
        {
            Console.Write("Digite o número da conta: ");
            int indiceConta = int.Parse(Console.ReadLine());

            Console.Write("Quanto gostaria de sacar? ");
            double valorSaque = int.Parse(Console.ReadLine());

            ListConta[indiceConta].Sacar(valorSaque);
        }

        private static void Transferir()
        {
            Console.Write("Qual o número da conta de origem? ");
            int indiceContaOrigem = int.Parse(Console.ReadLine());

            Console.Write("Qual o número da conta de destino? ");
            int indiceContaDestino = int.Parse(Console.ReadLine());

            Console.Write("Qual o valor da transferencia? ");
            int valorTransferencia = int.Parse(Console.ReadLine());

            ListConta[indiceContaOrigem].Transferir(valorTransferencia, ListConta[indiceContaDestino]);
        }

        private static void ListarContas()
        {
            Console.WriteLine("Contas cadastradas:");
            
            if (ListConta.Count == 0)
            {Console.WriteLine("Não foi encontrado nenhuma conta no sistema. Você pode adicionar uma nova conta em Inserir Contas (opção 2)."); return;}

            for (int i = 0; i < ListConta.Count; i++)
            { 
                Conta conta = ListConta[i];
                Console.Write("#{0} . ", i);
                Console.WriteLine(conta);
            }
        }

        private static void InserirConta()
        {
            Console.WriteLine("Inserir nova conta");

            Console.Write("É preciso saber se a conta é para uma pessoa fisíca ou jurídica. \nDigite 1 caso Conta Fisíca ou 2 para Juridíca: ");
            int entradaTipoConta = int.Parse(Console.ReadLine());
           
            Console.Write("Qual o nome do Cliente? ");
            string entradaNome = Console.ReadLine();

            Console.Write("Saldo inicial(R$): ");
            double entradaSaldo= double.Parse(Console.ReadLine());

            Console.Write("Agora me informe o crédito(R$): ");
            double entradaCredito = double.Parse(Console.ReadLine());

            Conta novaConta = new Conta(tipoConta: (TipoConta)entradaTipoConta, 
            saldo: entradaSaldo, credito: entradaCredito, nome: entradaNome);

            ListConta.Add(novaConta);
        }

        private static string ObterOpcaoUsuario()
        {
            Console.WriteLine();
            Console.WriteLine("Bem-vindo ao JEFF'S Bank :)");
            Console.WriteLine("Escolha um dos serviços abaixo: ");
            Console.WriteLine("1- Listar Contas");
            Console.WriteLine("2- Inserir Conta");
            Console.WriteLine("3- Transferir");
            Console.WriteLine("4- Saque");
            Console.WriteLine("5- Deposito");
            Console.WriteLine("C- Limpar Tela");
            Console.WriteLine("X- Sair");
            Console.WriteLine();

            string opçãoUsuario = Console.ReadLine().ToUpper();
            Console.WriteLine();
            return opçãoUsuario;
        }
    }
}
