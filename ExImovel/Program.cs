namespace ExImovel
{
    public class Program
    {
        public static void Main(string[] args)
        {
            // Cria uma configuração padrão para um projeto WebAPI
            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.

            //Tudo que é configuração tem que ser antes desse Build
            var app = builder.Build();

            // Configure the HTTP request pipeline.

            var imoveis = new List<Imovel>();
            int idContador = 1;
            imoveis.Add(new Imovel(01, "Bairro Olimpico", "Casa"));
            idContador++;
            imoveis.Add(new Imovel(02, "Oswaldo Cruz", "Apartamento"));
            idContador++;

            app.MapGet("/imovel", () => imoveis);

            app.MapGet("/imovel/{id}", (int id) =>
            {
                Imovel imovel = imoveis.FirstOrDefault(x => x.Id == id);
                return imovel;
            });


            app.MapPost("/imovel", (Imovel imovel) =>
            {
                imovel.Id = idContador++;
                imoveis.Add(imovel);
                return Results.Created($"/imovel/{imovel.Id}", imovel);
            });

            app.Run();
        }
    }
}
