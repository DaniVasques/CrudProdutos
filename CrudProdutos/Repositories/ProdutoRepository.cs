using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CrudProdutos.Entites;
using CrudProdutos.Settings;
using Dapper;
using Microsoft.Data.SqlClient;

namespace CrudProdutos.Repositories
{
    public class ProdutoRepository
    {
        public void Inserir(Produto produto)
        {
            var query = @"
                         INSERT INTO PRODUTO(ID, NOME, PRECO, QUANTIDADE, DATAHORACADASTRO, DATAHORAULTIMAALTERACAO)
                         VALUES(@ID, @NOME, @PRECO, @QUANTIDADE, @DATAHORACADASTRO, @DATAHORAULTIMAALTERACAO)
                        ";
            using (var connection = new SqlConnection(AppSetting.GetConnectionString()))
            { 
                connection.Execute(query,produto);
            }
            
        }

        public bool Atualizar(Produto produto)
        {
            var query = @"
                         UPDATE PRODUTOS
                         SET NOME = @NOME, 
                         PRECO = @PRECO, 
                         QUANTIDADE = @QUANTIDADE, 
                         DATAHORAULTIMAALTERACAO = @DATAHORAULTIMAALTERACAO
                         WHERE 
                            ID = @ID
                        ";
            using (var connection = new SqlConnection(AppSetting.GetConnectionString()))
            {
                var rowsAffected = connection.Execute(query, produto);
                return rowsAffected > 0;
            }
        }

        public bool Excluir(Guid id)
        {
            var query = @"
                         DELETE FROM PRODUTOS
                         WHERE ID = @ID
                        ";
            using (var connection = new SqlConnection(AppSetting.GetConnectionString()))
            {
                var rowsAffected = connection.Execute(query,new { @Id = id });
                return rowsAffected > 0;

            }
        }

        public List<Produto> Consultar(string nome)
        {
            var query = @"
                         SELECT ID, NOME, PRECO, QUANTIDADE, DATAHORACADASTRO, DATAHORAULTIMAALTERACAO
                            FROM PRODUTO
                            WHERE NOME LIKE @NOME
                            ORDER BY NOME ASC
                        ";
            using (var connection = new SqlConnection(AppSetting.GetConnectionString()))
            {
                return connection.Query<Produto>(query, new { @Nome = $"%{nome}%" }).ToList();
            }
        }

        public Produto? ObterPorId(Guid id)
        {
           var quary = @"
                         SELECT ID, NOME, PRECO, QUANTIDADE, DATAHORACADASTRO, DATAHORAULTIMAALTERACAO
                            FROM PRODUTOS
                            WHERE ID = @ID
                        ";
            using (var connection = new SqlConnection(AppSetting.GetConnectionString()))
            {
                return connection.QueryFirstOrDefault<Produto>(quary, new { @ID = id });
            }

        }


    }
}
