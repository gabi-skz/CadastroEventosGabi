namespace CadastroEventosGabi.Models
{
    public class Evento
    {
        public string LocalEvento { get; set; }
        public int NumPessoas { get; set; }
        public string NomeEvento { get; set; }
        public DateTime DataInicio { get; set; }
        public DateTime DataFinal { get; set; }
        public decimal CustoPorParticipante { get; set; }
        public int Duracao
        {
            get => DataFinal.Subtract(DataInicio).Days;
        }
        public decimal CustoTotal
        {
            get => NumPessoas * CustoPorParticipante;
        }
    }
}
