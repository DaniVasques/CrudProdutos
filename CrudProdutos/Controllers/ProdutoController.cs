using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CrudProdutos.Entites;
using CrudProdutos.Repositories;
using CrudProdutos.Validators;

namespace CrudProdutos.Controllers
{
    public class ProdutoController
    {
        public void CadastrarProduto()
        {
            Console.WriteLine("\n***CADASTRAR PRODUTO***\n");
            var produto = new Produto();

            Console.Write("NOME DO PRODUTO..........:");
            produto.Nome = Console.ReadLine() ?? string.Empty;

            Console.Write("PREÇO DO PRODUTO.........:");
            produto.Preco = double.Parse(Console.ReadLine() ?? "0");

            Console.Write("QUANTIDADE DO PRODUTO....:");
            produto.Quantidade = int.Parse(Console.ReadLine() ?? "0");

            var validator = new ProdutoValidator();
            var result = validator.Validate(produto);

            if (result.IsValid)
            {
                var produtorepository = new ProdutoRepository();
                produtorepository.Inserir(produto);
                Console.WriteLine("\nPRODUTO CADASTRADO COM SUCESSO!");
            }
            else
            {

                foreach (var item in result.Errors)
                {
                    Console.WriteLine($"\nERRO: {item.ErrorMessage}");
                }
            }

        }
        public void AtualizarProduto()
        {
            Console.WriteLine("\nATUALIZAÇÃO DE PRODUTO:\n");

            var produto = new Produto();

            Console.Write("ID DO PRODUTO.....: ");
            produto.Id = Guid.Parse(Console.ReadLine() ?? string.Empty);

            Console.Write("NOME DO PRODUTO...: ");
            produto.Nome = Console.ReadLine() ?? string.Empty;

            Console.Write("PREÇO.............: ");
            produto.Preco = double.Parse(Console.ReadLine() ?? "0");

            Console.Write("QUANTIDADE........: ");
            produto.Quantidade = int.Parse(Console.ReadLine() ?? "0");

            var validator = new ProdutoValidator();
            var result = validator.Validate(produto);

            if (result.IsValid)
            {
                var produtoRepository = new ProdutoRepository();

                if (produtoRepository.Atualizar(produto))
                    Console.WriteLine("\nPRODUTO ATUALIZADO COM SUCESSO!");
                else
                    Console.WriteLine("\nNENHUM PRODUTO FOI ENCONTRADO. VERIFIQUE O ID INFORMADO.");
            }

            else
            {
                foreach (var item in result.Errors)
                {
                    Console.WriteLine($"\nERRO: {item.ErrorMessage}");
                }
            }

        }
        public void ExcluirProduto()
        {
            Console.WriteLine("\nEXCLUSÃO DE PRODUTO:\n");

            Console.Write("ID DO PRODUTO.....: ");
            var id = Guid.Parse(Console.ReadLine() ?? string.Empty);

            var produtoRepository = new ProdutoRepository();

            if (produtoRepository.Excluir(id))
                Console.WriteLine("\nPRODUTO EXCLUÍDO COM SUCESSO!");
            else
                Console.WriteLine("\nNENHUM PRODUTO FOI ENCONTRADO. VERIFIQUE O ID INFORMADO.");
        }

        public void ConsultarProdutos()
        {
            Console.WriteLine("\nCONSULTA DE PRODUTOS:\n");

            Console.Write("NOME DO PRODUTO..: ");
            var nome = Console.ReadLine() ?? string.Empty;

            var produtoRepository = new ProdutoRepository();

            foreach (var item in produtoRepository.Consultar(nome))
            {
                Console.WriteLine($"ID...............: {item.Id}");
                Console.WriteLine($"NOME.............: {item.Nome}");
                Console.WriteLine($"PREÇO............: {item.Preco}");
                Console.WriteLine($"QUANTIDADE.......: {item.Quantidade}");
                Console.WriteLine($"CADASTRADO EM....: {item.DataHoraCadastro}");
                Console.WriteLine($"ALTERADO EM......: {item.DataHoraUltimaAlteracao}");
                Console.WriteLine("...");


            }
        }

    }
}
