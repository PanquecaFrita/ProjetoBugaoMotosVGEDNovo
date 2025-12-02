namespace AppBugaoMotoFVLE.Components.Models
{
    public class VendaServico
    {
        public int Id { get; set; }
        public int IdVenda { get; set; }
        public string Servico { get; set; }
        public double Valor { get; set; }
        public bool Status { get; set; }
    }

}
