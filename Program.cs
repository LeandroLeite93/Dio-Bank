using System;
using System.Collections.Generic;

namespace dioBank
{
    class Program
    {
        static List<Conta> listContas = new List<Conta>();

        static void Main(string[] args)
        {   
          
          string opcaoUsuario = ObterOpcaoUsuario();
          

          while (opcaoUsuario.ToUpper() != "X")
          {
              switch (opcaoUsuario)
              {
                  case "1":
                  ListarConta();
                  break;
                  case "2":
                  InserirConta();
                  break;
                  case "3": 
                  Transferir();
                  break; 
                  case "4":
                  Sacar();
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
          Console.WriteLine("Obrigado por utilizar nossos serviços.");
          Console.ReadLine();
        }

      private static void Transferir()
      {
          Console.Write("Digite o numero da conta de origem: ");
          int indiceContaOrigem = int.Parse(Console.ReadLine());

          Console.Write("Digite o numero da conta de destino: ");
          int indiceContaDestino = int.Parse(Console.ReadLine());

          Console.Write("Digite o valor a ser Transferido: ");
          double valorTransferencia = double.Parse(Console.ReadLine());

          listContas[indiceContaOrigem].Transferir(valorTransferencia, listContas[indiceContaDestino]); 
      }

      private static void Sacar()
      {
          Console.Write("Digite o numero da conta: ");
          int indiceConta = int.Parse(Console.ReadLine());

          Console.Write("Digite o valor a ser sacado: ");
          double valorSaque = double.Parse(Console.ReadLine());

          listContas[indiceConta].Sacar(valorSaque);
      }

      private static void Depositar()
      {
          Console.Write("Digitar o Numero da conta: ");
          int indiceConta = int.Parse(Console.ReadLine());

          Console.Write("Digite o valor a ser depositado: ");
          double valorDeposito = double.Parse(Console.ReadLine());

          listContas[indiceConta].Depositar(valorDeposito);
      }

        private static void InserirConta()
        {
            Console.WriteLine("Inserir Nova Conta");

            Console.WriteLine("Digite 1 para conta fisica e 2 para juridica: ");
            int entradaTipoConta = int.Parse(Console.ReadLine());

            Console.WriteLine("digite o nome do cliente: ");
            string entradaNome = Console.ReadLine();

            Console.WriteLine("Digite o Saldo Inicial: ");
            double entradaSaldo = double.Parse(Console.ReadLine());

            Console.WriteLine("Digite o Credito: ");
            double entradaCredito = double.Parse(Console.ReadLine());

            Conta novaConta = new Conta(tipoConta: (TipoConta)entradaTipoConta,
                                        saldo: entradaSaldo,
                                        credito: entradaCredito,
                                        nome: entradaNome);

            listContas.Add(novaConta);                           
        }

        private static void ListarConta()
        {
            Console.WriteLine("Listar contas");
            if (listContas.Count == 0)
            {
                Console.WriteLine("Nenhuma conta Cadastrada.");
                return;
            }

            for (int i = 0; i < listContas.Count; i++)
            {
               Conta conta = listContas[i];
               Console.Write("#{0} - ", i);
               Console.WriteLine(conta);
            }
        }

        private static string ObterOpcaoUsuario()
        {
            Console.WriteLine();
            Console.WriteLine("DIO Bank ao seu Dispor!");
            Console.WriteLine("Informe a Opcao Desejada");

            Console.WriteLine("1 - Lista Contas");
            Console.WriteLine("2 - Inserir Nova Conta");
            Console.WriteLine("3 - Transferir");
            Console.WriteLine("4 - Sacar");
            Console.WriteLine("5- Depositar");
            Console.WriteLine("C - Lipmar Tela");
            Console.WriteLine("X - Sair");
            Console.WriteLine();

            string opcaoUsuario = Console.ReadLine().ToUpper();
            Console.WriteLine();
            return opcaoUsuario;

        }
    }
}




