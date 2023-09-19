using bytebank.Modelos.Conta;
using static bytebank_ATENDIMENTO.byreBank.Exceptions.ByteBankExceptions;

namespace bytebank_ATENDIMENTO.byteBank.Atendimento;

#nullable disable
internal class ByteBankAtendimento
{
    private List<ContaCorrente> _listaDeContas = new List<ContaCorrente>()
{
    new ContaCorrente(95, "123456-X") {Saldo = 100, Titular = new Cliente() {Nome = "Mariana", Cpf = "11111111111" } },
    new ContaCorrente(100, "123895-S") {Saldo = 10, Titular = new Cliente() {Nome = "Wilson", Cpf = "45678978988" } },
    new ContaCorrente(95, "897897-W") {Saldo = 50, Titular = new Cliente() {Nome = "João", Cpf = "22222222222" } },
};
    public void AtendimentoCliente()
    {
        try
        {
            char opcao = '0';
            while (opcao != '6')
            {
                Console.Clear();
                Console.WriteLine("=============================================");
                Console.WriteLine("====            Atendimento              ====");
                Console.WriteLine("====1 -        Cadastrar Conta           ====");
                Console.WriteLine("====2 -        Listar Contas             ====");
                Console.WriteLine("====3 -        Remover Conta             ====");
                Console.WriteLine("====4 -        Ordenar Contas            ====");
                Console.WriteLine("====5 -        Pesquisar Conta           ====");
                Console.WriteLine("====6 -        Sair do Sistema           ====");
                Console.WriteLine("=============================================");
                Console.WriteLine("\n\n");
                Console.Write("Digite a opção desejada: ");
                try
                {
                    opcao = Console.ReadLine() [0];
                }
                catch (Exception excecao)
                {

                    throw new ByteBankException(excecao.Message);
                }

                switch (opcao)
                {
                    case '1':
                        CadastrarConta();
                        break;
                    case '2':
                        ListarContas();
                        break;
                    case '3':
                        RemoverContas();
                        break;
                    case '4':
                        OrdenarContas();
                        break;
                    case '5':
                        PesquisarContas();
                        break;
                    case '6':
                        EncerrarAplicacao();
                        break;
                    default:
                        Console.WriteLine("Opção não existe");
                        break;
                }
            }
        }
        catch (ByteBankException excecao)
        {
            Console.WriteLine($"{excecao.Message}");
        }
    }

    private void EncerrarAplicacao()
    {
        Console.WriteLine("...Encerrando a aplicação...");
        Console.ReadKey();
    }

    private void PesquisarContas()
    {
        Console.Clear();
        Console.WriteLine("=============================================");
        Console.WriteLine("====           Pesquisar Contas         ====");
        Console.WriteLine("=============================================");
        Console.WriteLine("\n");
        Console.Write("Deseja pesquisar por (1) número da conta, (2) CPF do titular ou (3) Número Agência: ");
        switch (int.Parse(Console.ReadLine()))
        {
            case 1:
                {
                    Console.Write("Informe o número da conta: ");
                    string _numeroConta = Console.ReadLine();
                    ContaCorrente consultaConta = ConsultaPorNumeroConta(_numeroConta);
                    Console.WriteLine(consultaConta.ToString());
                    Console.ReadKey();
                    break;
                }
            case 2:
                {
                    Console.Write("Informe o CPF do títular: ");
                    string _cpf = Console.ReadLine();
                    ContaCorrente consultaCpf = ConsultaPorCPF(_cpf);
                    Console.WriteLine(consultaCpf.ToString());
                    Console.ReadKey();
                    break;
                }
            case 3:
                {
                    Console.Write("Informe o N° da agência: ");
                    int _numeroAgencia = int.Parse(Console.ReadLine());
                    var contasPorAgencia = ConsultaPorAgencia(_numeroAgencia);
                    ExibirListaDeContas(contasPorAgencia);
                    Console.ReadKey();
                    break;
                }
            default:
                Console.WriteLine("Opção não implementada!");
                break;
        }
    }

    private void ExibirListaDeContas(List<ContaCorrente> contasPorAgencia)
    {
        if (contasPorAgencia == null)
        {
            Console.WriteLine("... A consulta não retornou dados...");
        }
        else
        {
            foreach (var item in contasPorAgencia)
            {
                Console.WriteLine(item.ToString());
            }
        }
    }

    private List<ContaCorrente> ConsultaPorAgencia(int numeroAgencia)
    {
        var consulta = (from conta in _listaDeContas
                        where conta.Numero_agencia == numeroAgencia
                        select conta).ToList();
        return consulta;
    }

    private ContaCorrente ConsultaPorCPF(string? cpf)
    {
        //ContaCorrente conta = null;
        //for(int i = 0; i < _listaDeContas.Count; i++)
        //{
        //    if (_listaDeContas[i].Titular.Cpf.Equals(cpf))
        //    {
        //        conta = _listaDeContas[i];
        //    }
        //}
        //return conta;
        return _listaDeContas.Where(conta => conta.Titular.Cpf == cpf).FirstOrDefault();
    }

    private ContaCorrente ConsultaPorNumeroConta(string? numeroConta)
    {
        //ContaCorrente conta = null;
        //for (int i = 0; i < _listaDeContas.Count; i++)
        //{
        //    if (_listaDeContas[i].Conta.Equals(numeroConta))
        //    {
        //        conta = _listaDeContas[i];
        //    }
        //}
        //return conta;

        return _listaDeContas.Where(conta => conta.Conta == numeroConta).FirstOrDefault();
    }

    private void OrdenarContas()
    {
        _listaDeContas.Sort();
        Console.WriteLine("...Lista de contas ordenada...");
        Console.ReadKey();
    }

    private void RemoverContas()
    {
        Console.Clear();
        Console.WriteLine("=============================================");
        Console.WriteLine("====           Remover Contas          ====");
        Console.WriteLine("=============================================");
        Console.WriteLine("\n");
        Console.Write("Informe o número da conta: ");
        string numeroConta = Console.ReadLine();
        ContaCorrente conta = null;
        foreach (var item in _listaDeContas)
        {
            if (item.Conta.Equals(numeroConta))
            {
                conta = item;
            }
        }
        if (conta != null)
        {
            _listaDeContas.Remove(conta);
            Console.WriteLine("...Conta removida da lista!...");
        }
        else
        {
            Console.WriteLine("...Conta para remoção não encontrada...");
            Console.ReadKey();
        }
    }

    private void ListarContas()
    {
        Console.Clear();
        Console.WriteLine("=============================================");
        Console.WriteLine("====           Lista de contas           ====");
        Console.WriteLine("=============================================");
        Console.WriteLine("\n");
        if (_listaDeContas.Count <= 0)
        {
            Console.WriteLine("... Não há contas cadastradas!...");
            Console.ReadKey();
            return;
        }

        foreach (ContaCorrente item in _listaDeContas)
        {
            //Console.WriteLine("=== Dados da conta ===");
            //Console.WriteLine("Número da conta: " + item.Conta);
            //Console.WriteLine("Saldo da conta: " + item.Saldo);
            //Console.WriteLine("Títular da conta: " + item.Titular.Nome);
            //Console.WriteLine("CPF do títular: " + item.Titular.Cpf);
            //Console.WriteLine("Profissão do títular: " + item.Titular.Profissao);
            Console.WriteLine(item.ToString());
            Console.WriteLine(">>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>");
            Console.ReadKey();
        }
    }

    private void CadastrarConta()
    {
        Console.Clear();
        Console.WriteLine("=============================================");
        Console.WriteLine("====             Cadastro de contas      ====");
        Console.WriteLine("=============================================");
        Console.WriteLine("\n");
        Console.WriteLine("===      Informe os dados da conta       ====");
        Console.Write("Número da agência: ");
        int numeroAgencia = int.Parse(Console.ReadLine());
        ContaCorrente conta = new ContaCorrente(numeroAgencia);
        Console.WriteLine($"Número da conta [NOVA]: {conta.Conta}");

        Console.Write("Informe o saldo inicial: ");
        conta.Saldo = double.Parse(Console.ReadLine());

        Console.Write("Informe o nome do titular: ");
        conta.Titular.Nome = Console.ReadLine();

        Console.Write("Informe o CPF do titular: ");
        conta.Titular.Cpf = Console.ReadLine();

        Console.Write("Informe a profissão do titular: ");
        conta.Titular.Profissao = Console.ReadLine();

        _listaDeContas.Add(conta);
        Console.WriteLine("... Conta cadastrada com sucesso! ...");
        Console.ReadKey();
    }
}
