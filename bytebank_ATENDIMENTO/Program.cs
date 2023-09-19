using bytebank.Modelos.Conta;
using bytebank_ATENDIMENTO.bytebank.Util;
using bytebank_ATENDIMENTO.byteBank.Atendimento;

Console.WriteLine("Boas Vindas ao ByteBank, Atendimento.");
new ByteBankAtendimento().AtendimentoCliente();
#region Exemplos Arrays em C#
void TestaArrayInt()
{
    int[] idades = new int[5];
    idades[0] = 30;
    idades[1] = 40;
    idades[2] = 17;
    idades[3] = 21;
    idades[4] = 18;
    Console.WriteLine("Tamanho do Array {0}", idades.Length);
    int acumulador = 0;
    for(int i = 0; i < idades.Length; i++)
    {
        int idade = idades[i];
        Console.WriteLine("Idade no índice ({0}) {1}",i, idade);
        acumulador += idade;
    }

    int media = acumulador / idades.Length;
    Console.WriteLine("Média de idades = {0}", media);
}
void TestaBuscarPalavra()
{
    string[] arrayDePalavras = new string[5];
    for(int i= 0; i < arrayDePalavras.Length; i++)
    {
        Console.Write($"Digite {i+1}° Palavra: ");
        arrayDePalavras[i] = Console.ReadLine()!;
    }

    Console.Write("Digite a palavra a ser encontrada: ");
    var buscaPalavra = Console.ReadLine();

    foreach(string palavra in arrayDePalavras)
    {
        if(palavra.Equals(buscaPalavra))
        {
            Console.WriteLine($"Palavra encontrada = {buscaPalavra}");
            break;
        }
    }
}

//TestaArrayInt();

//TestaBuscarPalavra();

Array amostra = Array.CreateInstance(typeof(double), 5);
amostra.SetValue(5.9, 0);
amostra.SetValue(1.8, 1);
amostra.SetValue(7.1, 2);
amostra.SetValue(10, 3);
amostra.SetValue(6.9, 4);

void TestaMediano(Array array)
{
    if(array == null || array.Length == 0)
    {
        Console.WriteLine("Array para cálculo mediano, está vazio ou nulo");
    }

    double[] numerosOrdenados = (double[])array.Clone();
    Array.Sort(numerosOrdenados);

    int tamanho = numerosOrdenados.Length;
    int meio = tamanho / 2;
    double mediana = (tamanho % 2 != 0) ? numerosOrdenados[meio] : numerosOrdenados[meio] + numerosOrdenados[meio - 1] / 2;
    Console.WriteLine($"Com base na amostra, a mediana é = {mediana}");
}
//TestaMediano(amostra);

void MediaAmostra(Array array)
{
    double somaArray = 0;
    double media = 0;
    double[] numerosArray = (double[])array.Clone();
    for(int i = 0; i < numerosArray.Length; i++)
    {
        if(array == null || array.Length == 0)
        {
            Console.WriteLine("O array está vazio!");
        }
        else
        {
            somaArray += numerosArray[i];
        }
    }

    media = somaArray / numerosArray.Length;

    Console.WriteLine("A média do array é: {0}", media);
}

//MediaAmostra(amostra);

void TestaArrayDeContasCorrentes()
{
    ListaDeContasCorrentes listaDeContas = new ListaDeContasCorrentes();
    listaDeContas.Adicionar(new ContaCorrente(874, "5679787-A"));
    listaDeContas.Adicionar(new ContaCorrente(874, "4456668-B"));
    listaDeContas.Adicionar(new ContaCorrente(874, "7781438-C"));
    listaDeContas.Adicionar(new ContaCorrente(874, "7781438-C"));
    listaDeContas.Adicionar(new ContaCorrente(874, "7781438-C"));
    listaDeContas.Adicionar(new ContaCorrente(874, "7781438-C"));
    var contaDoMauricio = new ContaCorrente(963, "123456-X");
    listaDeContas.Adicionar(contaDoMauricio);
    //listaDeContas.ExibeLista();
    //Console.WriteLine("==============================");
    //listaDeContas.Remover(contaDoMauricio);
    //listaDeContas.ExibeLista();

    for(int i = 0; i < listaDeContas.Tamanho; i++)
    {
        ContaCorrente conta = listaDeContas[i];
        Console.WriteLine($"Indice [{i}] -> Conta: {conta.Conta}/{conta.Numero_agencia}");
    }
}

//TestaArrayDeContasCorrentes();
#endregion 


