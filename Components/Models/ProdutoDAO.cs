namespace AppBugaoMotoFVLE.Components.Models;
using AppBugaoMotoFVLE.Configs;

public class ProdutoDAO
{
    private readonly Conexao _conexao;

    public ProdutoDAO(Conexao conexao)
    {
        _conexao = conexao;
    }

    public void InserirProduto(Produto produto)
    {
        try
        {
            var comando = _conexao.CreateCommand("INSERT INTO Produto VALUES (null,null, @_nome_prod, @_codigo_prod, @_quantidade_prod, @_valor_prod)");
            comando.Parameters.AddWithValue("@_nome_prod", produto.Nome);
            comando.Parameters.AddWithValue("@_codigo_prod", produto.Codigo);


            comando.Parameters.AddWithValue("@_quantidade_prod", produto.Quantidade);
            comando.Parameters.AddWithValue("@_valor_prod", produto.Valor);


            comando.ExecuteNonQuery();
        }
        catch (Exception)
        {
            throw;
        }
    }
    public List<Produto> ListarTodos()
    {
        var lista = new List<Produto>();

        var comando = _conexao.CreateCommand("SELECT * FROM produto;");
        var leitor = comando.ExecuteReader();

        while (leitor.Read())
        {
            var produto = new Produto();
            produto.IdProduto = leitor.GetInt32("id_prod");
            produto.Nome = DAOHelper.GetString(leitor, "nome_prod");
            produto.Codigo = DAOHelper.GetString(leitor, "codigo_prod");
            produto.Quantidade = leitor.GetInt32("quantidade_prod");
            produto.Valor = leitor.GetDouble("valor_prod");

            lista.Add(produto);
        }
        return lista;
    }

    public Produto? BuscarPorId(int id)
    {
        var comando = _conexao.CreateCommand(
            "SELECT * FROM produto WHERE id_prod = @id;"
        );

        comando.Parameters.AddWithValue("@id", id);

        var leitor = comando.ExecuteReader();

        if (leitor.Read())
        {
            var produto = new Produto();
            produto.IdProduto = leitor.GetInt32("id_prod");
            produto.Nome = DAOHelper.GetString(leitor, "nome_prod");
            produto.Codigo = DAOHelper.GetString(leitor, "codigo_prod");
            produto.Quantidade = leitor.GetInt32("quantidade_prod");
            produto.Valor = leitor.GetDouble("valor_prod");
            produto.IdFornecedor = leitor.GetInt32("id_forne_fk");

            return produto;
        }

        return null;
    }


    public void Atualizar(Produto produto)
    {
        try
        {
            var comando = _conexao.CreateCommand(
                "UPDATE produto SET nome_prod = @_nome, codigo_prod = @_codigo, " +
                "quantidade_prod = @_quantidade, valor_prod = @_valor, " +
                "id_forne_fk = @_fornecedor WHERE id_prod = @_id;"
            );

            comando.Parameters.AddWithValue("@_nome", produto.Nome);
            comando.Parameters.AddWithValue("@_codigo", produto.Codigo);
            comando.Parameters.AddWithValue("@_quantidade", produto.Quantidade);
            comando.Parameters.AddWithValue("@_valor", produto.Valor);
            comando.Parameters.AddWithValue("@_fornecedor", produto.IdFornecedor);
            comando.Parameters.AddWithValue("@_id", produto.IdProduto);

            comando.ExecuteNonQuery();
        }
        catch
        {
            throw;
        }
    }



}

