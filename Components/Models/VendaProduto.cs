namespace AppBugaoMotoFVLE.Components.Models
{
    public class VendaProduto
    {
        public int IdV { get; set; }
        public int IdVenda { get; set; }
        public string Produto { get; set; }
        public int Quantidade { get; set; }
        public double ValorUnitario { get; set; }
        public double ValorTotal { get; set; }
        public bool Status { get; set; }
    }

}
