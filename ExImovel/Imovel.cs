namespace ExImovel
{
    public class Imovel
    {
        public int Id { get; set; }
        public string Bairro { get; set; }
        public string Tipo { get; set; }

        public Imovel(int id, string bairro, string tipo) {
            Id = id;
            Bairro = bairro;
            Tipo = tipo;
        }
    }
}
