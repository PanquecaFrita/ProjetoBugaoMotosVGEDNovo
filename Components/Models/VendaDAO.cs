namespace AppBugaoMotoFVLE.Components.Models
{
    using MySql.Data.MySqlClient;

    public class VendaDAO
    {
        private readonly string connectionString;

        public VendaDAO(IConfiguration config)
        {
            connectionString = config.GetConnectionString("mysqlConnection");
        }

        public int CriarVenda(Venda venda)
        {
            using var conexao = new MySqlConnection(connectionString);
            conexao.Open();

            string sql = "INSERT INTO venda (data_venda, valor_total) VALUES (@data_venda, @valor_total); SELECT LAST_INSERT_ID();";

            using var cmd = new MySqlCommand(sql, conexao);
            cmd.Parameters.AddWithValue("@data_venda", venda.DataVenda);
            cmd.Parameters.AddWithValue("@valor_total", venda.ValorTotal);

            return Convert.ToInt32(cmd.ExecuteScalar());
        }

        public void SalvarServico(VendaServico s)
        {
            using var conexao = new MySqlConnection(connectionString);
            conexao.Open();

            string sql = @"INSERT INTO venda_servico (id_venda, servico, valor, status)
                       VALUES (@id_venda, @servico, @valor, @status)";

            using var cmd = new MySqlCommand(sql, conexao);
            cmd.Parameters.AddWithValue("@id_venda", s.IdVenda);
            cmd.Parameters.AddWithValue("@servico", s.Servico);
            cmd.Parameters.AddWithValue("@valor", s.Valor);
            cmd.Parameters.AddWithValue("@status", s.Status);
            cmd.ExecuteNonQuery();
        }

        public void SalvarProduto(VendaProduto p)
        {
            using var conexao = new MySqlConnection(connectionString);
            conexao.Open();

            string sql = @"INSERT INTO venda_produto (id_venda, produto, quantidade, valor_unitario, valor_total, status)
                       VALUES (@id_venda, @produto, @quantidade, @valor_unitario, @valor_total, @status)";

            using var cmd = new MySqlCommand(sql, conexao);
            cmd.Parameters.AddWithValue("@id_venda", p.IdVenda);
            cmd.Parameters.AddWithValue("@produto", p.Produto);
            cmd.Parameters.AddWithValue("@quantidade", p.Quantidade);
            cmd.Parameters.AddWithValue("@valor_unitario", p.ValorUnitario);
            cmd.Parameters.AddWithValue("@valor_total", p.ValorTotal);
            cmd.Parameters.AddWithValue("@status", p.Status);

            cmd.ExecuteNonQuery();
        }
    }

}
