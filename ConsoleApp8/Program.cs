using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Remoting.Messaging;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp8
{
    internal class Program
    {
        public struct DadoCadastrais
        {
            public string Nome;
            public DateTime DataDeNascimento;
            public string NomeDaRua;
            public UInt32 NumeroDaCasa;
        }

        public enum Resultado_e
        {
            sair = 0,
            sucesso = 1,
            exceção = 2
        }

        public static Resultado_e PegarString(ref string MinhaMensagem, string mensagem)
        {
            Resultado_e retorno;

            Console.WriteLine(mensagem);
            string temp = Console.ReadLine();

            if (temp == "s" || temp == "S")
            {
                retorno = Resultado_e.sair;

            }
            else
            {
                MinhaMensagem = temp;
                retorno = Resultado_e.sucesso;
            }

            Console.Clear();
            return retorno; 
        }

        public static Resultado_e PegarData(ref DateTime MinhaData, string mensagem)
        {
            Resultado_e retorno;

            do
            {
                Console.WriteLine(mensagem);
                string temp = Console.ReadLine();

                if (temp == "s" || temp == "S")
                    retorno = Resultado_e.sair;
                else 
                {
                    try
                    {
                        MinhaData = Convert.ToDateTime(temp);
                        retorno = Resultado_e.sucesso;
                    }
                    catch (Exception e)
                    {
                        Console.WriteLine("Exceção: " + e.Message);
                        Console.ReadLine();
                        retorno = Resultado_e.exceção;
                    }
                }

            } while (retorno == Resultado_e.exceção);

            Console.Clear();
            return retorno; 
        }
        public static Resultado_e PegarNumero(ref UInt32 MeuNumero, string mensagem)
        {
            Resultado_e retorno;

            do
            {
                Console.WriteLine(mensagem);
                string temp = Console.ReadLine();

                if (temp == "s" || temp == "S")
                    retorno = Resultado_e.sair;
                else
                {
                    try
                    {
                        MeuNumero = Convert.ToUInt32(temp);
                        retorno = Resultado_e.sucesso;
                    }
                    catch (Exception e)
                    {
                        Console.WriteLine("Exceção: " + e.Message);
                        Console.ReadLine();
                        retorno = Resultado_e.exceção;
                    }
                }

            } while (retorno == Resultado_e.exceção);

            Console.Clear();
            return retorno;
        }

        public static void Cadastrar(ref List<DadoCadastrais> DadosDoUsuario)
        {
            DadoCadastrais cadastroUsuario;

            cadastroUsuario.Nome = "";
            cadastroUsuario.NomeDaRua = "";
            cadastroUsuario.NumeroDaCasa = 0 ;
            cadastroUsuario.DataDeNascimento = new DateTime();

            if (PegarString(ref cadastroUsuario.Nome, "Digite seu nome ou aperte s para sair.") != Resultado_e.sucesso)
                return;
            if (PegarString(ref cadastroUsuario.NomeDaRua, "Digite o nome da sua rua ou aperte s para sair.") != Resultado_e.sucesso)
                return;
            if (PegarNumero(ref cadastroUsuario.NumeroDaCasa, "Digite o numero da sua casa ou aperte s para sair.") != Resultado_e.sucesso)
                return;
            if (PegarData(ref cadastroUsuario.DataDeNascimento, "Digite sua data de nascimento no formato DD/MM/AA ou aperte s para sair.") != Resultado_e.sucesso)
                return;

            DadosDoUsuario.Add(cadastroUsuario);
        }

        public static void ExibirMensagem(string mensagem )
        {
            Console.WriteLine("\n" + mensagem );
            Console.ReadLine();
            Console.Clear();
        }
        static void Main(string[] args)
        {
            List<DadoCadastrais> DadosDoUsuario = new List<DadoCadastrais>();   

            string opção;
            do
            {
                Console.WriteLine("Digite c para cadastrar e s para sair.");
                opção = Console.ReadKey(true).KeyChar.ToString().ToLower();

                if (opção == "c")
                {
                    Cadastrar(ref DadosDoUsuario);
                }
                else if (opção == "s")
                {
                    ExibirMensagem("A aplicação será finalizada.");
                }
                else
                {
                    ExibirMensagem("Comando não identificado.");
                }

            } while (opção != "s");
             
        }
    }
}
