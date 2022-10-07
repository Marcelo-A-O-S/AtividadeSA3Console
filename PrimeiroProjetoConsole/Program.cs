// See https://aka.ms/new-console-template for more information
using AtividadeSA3Console.Models;
using System.ComponentModel.Design;
using System.Reflection.Metadata;

public class Program
{
    
    static void Main() 
    {

        Console.WriteLine("Olá,tudo bem? \nEsta é a aplicacão relacionada a atividade da SA3, vamos iniciar os testes? \nDigite uma das opcões do menu abaixo para prosseguir: ");
        Menu();
    }

    public static string Caminho()
    {
        
        string path = Directory.GetCurrentDirectory();
        var resultado = path.Split("\\bin\\Debug\\net6.0");
        var caminho = resultado[0] + @"\Dados\pessoa.txt";
        return caminho;
    }

    private static void Fechar()
    {
        Console.Clear();
        string operador = "";
        Console.WriteLine("Tem certeza que deseja sair? Escolha uma opcão e aperte enter para prosseguir. \n1- Sim \n2- Não");
        operador = Console.ReadLine();
        switch (operador) 
        {
            case "1":
                Environment.Exit(0);
                break;
                case "2":
                Menu();
                break;
            default:
                Console.WriteLine("A tecla digitada não corresponde a nenhuma opcão,peco que digite novamente, aperte qualquer tecla para prosseguir.");
                Console.ReadKey(true);
                Fechar();
                break;
        }
    }

    private static void Menu()
    {
        string operador = "";
        while (operador != "0")
        {
            Console.WriteLine("-------------------MENU PRINCIPAL-------------------------");
            Console.WriteLine("Digite uma das opcões abaixo e aperte enter para prosseguir: ");
            Console.WriteLine("1- Cadastrar usuários \n2- Listar usuários \n0- Sair");
            operador = Console.ReadLine();
            switch (operador)
            {
                case "0":
                    Fechar();
                    break;
                case "1":
                    Cadastrar();
                    break;
                    case"2":
                    Listar();
                    break;
                default:
                    Console.WriteLine("A tecla digitada não corresponde a nenhuma opcão,peco que aperte qualquer tecla para prosseguir para o menu principal.");
                    Console.ReadKey(true);
                    Menu();
                    break;
            }
        }
    }

    private static void Listar()
    {
        string operador = "";
        var arquivo = File.Exists(Caminho());
        if(arquivo == false) 
        {
            Console.WriteLine("Infelizmente não foi encontrado nenhum cadastro salvo, cadastre um usuário antes de prosseguir.\nEscolha uma das opcões a seguir e aperte enter para prosseguir: \n1- Leve-me para cadastrar um usuário\n2- Menu \n3- Sair da aplicacão ");
            operador = Console.ReadLine();
            switch (operador) 
            {
                case "1":
                    Console.Clear();
                    Cadastrar();
                    break;
                case "2":
                    Console.Clear();
                    Menu();
                    break;
                case "3":
                    Console.Clear();
                    Fechar();
                    break;
                    default:
                    Console.Clear();
                    Console.WriteLine("A tecla digitada não corresponde a nenhuma opcão,peco que aperte qualquer tecla para prosseguir para cadastrar um usuário.");
                    Console.ReadKey(true);
                    Console.Clear();
                    Cadastrar();
                    break;

            }

        }
        string[] linhas = File.ReadAllLines(Caminho());
        Console.Clear();
        Console.WriteLine("Lista de Usuários:");
        foreach (var linha in linhas)
        {
            Console.WriteLine(linha);

        }
        Console.WriteLine("---------------------------------------------");
        Console.WriteLine("Deseja cadastrar um novo usuário? Escolha uma opcão e aperte enter para prosseguir. \n1- Cadastrar um novo usuário\n2- Ir para o menu \n3- Sair da aplicacão");
        operador = Console.ReadLine();
        switch (operador) 
        {
            case "1":
                Console.Clear();
                Cadastrar();
                break;
            case "2":
                Console.Clear();
                Menu();
                break;
            case "3":
                Console.Clear();
                Fechar();
                break;
            default:
                Console.Clear();
                Console.WriteLine("A tecla digitada não corresponde a nenhuma opcão,peco que aperte qualquer tecla para prosseguir para o menu principal.");
                Console.ReadKey(true);
                Console.Clear();
                Menu();
                break;

        }
    }

    private static void Salvar(Pessoa user)
    { 
        var arquivo = File.Exists(Caminho());
        if (arquivo == false) 
        {
            using (var criaArquivo = new StreamWriter(Caminho()))
            {
                criaArquivo.WriteLine("Nome,Idade");
                criaArquivo.Close();
            }
        }
        var escreva = File.AppendText(Caminho());
        escreva.WriteLine($"{user.nome},{user.idade}");
        escreva.Close();
    }

    public static void Cadastrar()
    {
        Console.Clear();
        string operador = "";
        Pessoa user = new Pessoa();
        Console.WriteLine("Digite as informacões necessarias.");
        Console.WriteLine("Digite seu nome:");
        user.nome = Console.ReadLine();
        Console.WriteLine("Digite sua idade:");
        user.idade = Console.ReadLine();
        Salvar(user);
        Console.WriteLine("Cadastrar outro usuário?\n1- Sim \n2- Não, quero voltar para o menu principal");
        operador = Console.ReadLine();
        switch (operador) 
        {
            case "1":
                Console.Clear();
                Cadastrar();
                break;
            case "2":
                Console.Clear();
                Menu();
                break;
                default:
                Console.WriteLine("A tecla digitada não corresponde a nenhuma opcão,peco que aperte qualquer tecla para prosseguir para o menu principal.");
                Console.ReadKey(true);
                Console.Clear();
                Menu();
                break;
        }
    }
}