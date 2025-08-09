using CrudProdutos.Controllers;

public class Program
{
    public static void Main(string[] args)
    {
        Console.WriteLine("\n*** SISTEMA DE CONTROLE DE PRODUTOS:***\n");

        Console.WriteLine("(1) CADASTRAR PRODUTO");
        Console.WriteLine("(2) ATUALIZAR PRODUTO");
        Console.WriteLine("(3) EXCLUIR PRODUTO");
        Console.WriteLine("(4) CONSULTAR PRODUTO");
        Console.WriteLine("(5) SAIR");

        Console.Write("\nINFORME A OPÇÃO DESEJADA: ");
        var opcao = Console.ReadLine();

        var produtoController = new ProdutoController();

        switch (opcao)
        {
            case "1":
                produtoController.CadastrarProduto();
                Main(args); //recursividade
                break;

            case "2":
                produtoController.AtualizarProduto();
                Main(args); //recursividade
                break;

            case "3":
                produtoController.ExcluirProduto();
                Main(args); //recursividade
                break;

            case "4":
                produtoController.ConsultarProdutos();
                Main(args); //recursividade
                break;

            case "5":
                Console.WriteLine("\nFIM DO PROGRAMA!");
                break;

            default:
                Console.WriteLine("\nOPÇÃO INVÁLIDA!");
                Main(args); //recursividade
                break;
        }
    }
}


