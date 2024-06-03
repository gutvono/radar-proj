using RadarRepository;
using RAPController;
using System.Diagnostics;

class Program
{
    static void Main(string[] args)
    {
        RadarRepositoryClass radarRepositoryClass = new ();
        RAPControllerClass rAPControllerClass = new ();
        Stopwatch sw = new ();

        Console.WriteLine("Pressione qualquer tecla para realizar a persistência dos dados do SQL para o MongoDB...\n");
        Console.ReadKey();

        var ListaRadares = radarRepositoryClass.GetAll();
        sw.Start ();
        Console.WriteLine(rAPControllerClass.InsertMany(ListaRadares) ? "Dados inseridos com sucesso!\n" : "-- ERRO ao inserir dados.\n");
        sw.Stop ();

        Console.WriteLine($"Demorou {sw.ElapsedMilliseconds} milissegundos para a inserção e persistência de dados no MongoDB.\n" +
            "Pressione qualquer tecla para continuar...");
        Console.ReadKey();
    }
}