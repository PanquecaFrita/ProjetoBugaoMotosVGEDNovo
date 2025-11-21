namespace AppBugaoMotoFVLE.Components.Models;
using AppBugaoMotoFVLE.Configs;
using Microsoft.AspNetCore.Razor.TagHelpers;
using Microsoft.AspNetCore.Routing;


public class ClienteDAO
{
    private readonly Conexao _conexao;

    public ClienteDAO(Conexao conexao)
    {
        _conexao = conexao;
    }

    public void InserirCliente(Cliente cliente)
    {
        try
        {
            var comando = _conexao.CreateCommand(
     @"INSERT INTO Cliente 
    (nome_clie, telefone_clie, estado_clie, cpf_clie, cidade_clie, complemento_clie, bairro_clie, rua_clie, cep_clie)
    VALUES 
    (@_nome_clie, @_telefone_clie, @_estado_clie, @_cpf_clie, @_cidade_clie, @_complemento_clie, @_bairro_clie, @_rua_clie, @_cep_clie)");

            comando.Parameters.AddWithValue("@_nome_clie", cliente.Nome);
            comando.Parameters.AddWithValue("@_telefone_clie",cliente.Telefone);
            comando.Parameters.AddWithValue("@_cep_clie", cliente.Cep);
            comando.Parameters.AddWithValue("@_complemento_clie", cliente.Complemento);
            comando.Parameters.AddWithValue("@_cpf_clie", cliente.Cpf);
            comando.Parameters.AddWithValue("@_rua_clie", cliente.Rua);
            comando.Parameters.AddWithValue("@_estado_clie", cliente.Estado);
            comando.Parameters.AddWithValue("@_cidade_clie", cliente.Cidade);
            comando.Parameters.AddWithValue("@_bairro_clie", cliente.Bairro);
       
            comando.ExecuteNonQuery();
        }
        catch (Exception)
        {
            throw;
        }
    }
    //Eduardo arrumou
    public List<Cliente> ListarCliente()
    {
        var listaClie = new List<Cliente>();
        var comando = _conexao.CreateCommand("SELECT * FROM Cliente");
        var leitor = comando.ExecuteReader();

        while (leitor.Read())
        {
            //ERRO AQUI
            var cliente = new Cliente();
            cliente.IdCli = leitor.GetInt32("id_clie");
            cliente.Nome = DAOHelper.GetString(leitor, "nome_clie");
            cliente.Telefone = DAOHelper.GetString(leitor, "telefone_clie");
            cliente.Estado = DAOHelper.GetString(leitor, "estado_clie");
            cliente.Cpf = DAOHelper.GetString(leitor, "cpf_clie");
            cliente.Cidade = DAOHelper.GetString(leitor, "cidade_clie");
            cliente.Complemento = DAOHelper.GetString(leitor, "complemento_clie");
            cliente.Bairro = DAOHelper.GetString(leitor, "bairro_clie");
            cliente.Rua = DAOHelper.GetString(leitor, "rua_clie");
            cliente.Cep = DAOHelper.GetString(leitor, "cep_clie");

            listaClie.Add(cliente);
        }

        return listaClie;
    }

    public void DeletarCliente(int id)
    {
        try
        {
            var comando = _conexao.CreateCommand(
                @"DELETE FROM Cliente 
              WHERE id_clie = @_id_clie");

            comando.Parameters.AddWithValue("@_id_clie", id);

            int linhasAfetadas = comando.ExecuteNonQuery();

            if (linhasAfetadas == 0)
            {
                throw new Exception("Nenhum cliente encontrado com esse ID.");
            }
        }
        catch (Exception)
        {
            throw;
        }
    }

    public Cliente BuscarClientePorId(int id)
    {
        try
        {
            var comando = _conexao.CreateCommand(
                @"SELECT * FROM Cliente WHERE id_clie = @_id_clie");

            comando.Parameters.AddWithValue("@_id_clie", id);

            var leitor = comando.ExecuteReader();

            if (leitor.Read())
            {
                return new Cliente
                {
                    IdCli = leitor.GetInt32("id_clie"),
                    Nome = DAOHelper.GetString(leitor, "nome_clie"),
                    Telefone = DAOHelper.GetString(leitor, "telefone_clie"),
                    Estado = DAOHelper.GetString(leitor, "estado_clie"),
                    Cpf = DAOHelper.GetString(leitor, "cpf_clie"),
                    Cidade = DAOHelper.GetString(leitor, "cidade_clie"),
                    Complemento = DAOHelper.GetString(leitor, "complemento_clie"),
                    Bairro = DAOHelper.GetString(leitor, "bairro_clie"),
                    Rua = DAOHelper.GetString(leitor, "rua_clie"),
                    Cep = DAOHelper.GetString(leitor, "cep_clie")
                };
            }

            return null;
        }
        catch
        {
            throw;
        }
    }

    public void AtualizarCliente(Cliente cliente)
    {
        try
        {
            var comando = _conexao.CreateCommand(
                @"UPDATE Cliente SET
                nome_clie = @_nome_clie,
                telefone_clie = @_telefone_clie,
                estado_clie = @_estado_clie,
                cpf_clie = @_cpf_clie,
                cidade_clie = @_cidade_clie,
                complemento_clie = @_complemento_clie,
                bairro_clie = @_bairro_clie,
                rua_clie = @_rua_clie,
                cep_clie = @_cep_clie
              WHERE id_clie = @_id_clie");

            comando.Parameters.AddWithValue("@_id_clie", cliente.IdCli);
            comando.Parameters.AddWithValue("@_nome_clie", cliente.Nome);
            comando.Parameters.AddWithValue("@_telefone_clie", cliente.Telefone);
            comando.Parameters.AddWithValue("@_estado_clie", cliente.Estado);
            comando.Parameters.AddWithValue("@_cpf_clie", cliente.Cpf);
            comando.Parameters.AddWithValue("@_cidade_clie", cliente.Cidade);
            comando.Parameters.AddWithValue("@_complemento_clie", cliente.Complemento);
            comando.Parameters.AddWithValue("@_bairro_clie", cliente.Bairro);
            comando.Parameters.AddWithValue("@_rua_clie", cliente.Rua);
            comando.Parameters.AddWithValue("@_cep_clie", cliente.Cep);

            comando.ExecuteNonQuery();
        }
        catch
        {
            throw;
        }
    }



}

