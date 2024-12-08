namespace DesafioRotasViagem.Domain.Entities
{
    public class Rota
    {
        public int Id { get; set; }
        private string origem;
        public string Origem
        {
            get => origem;
            set => origem = value?.ToUpper();
        }

        private string destino;
        public string Destino
        {
            get => destino;
            set => destino = value?.ToUpper();
        }
        public decimal Custo { get; set; }
    }
}
