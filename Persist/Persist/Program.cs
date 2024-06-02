using Controller;
using Model;
using System;
using System.Collections.Generic;

class Program
{
    static void Main(string[] args)
    {
        RadarController radarController = new RadarController();
        int opcao = 0;
        Radar radar = null;

        Radar ReceiveDataFromUser()
        {
            Radar radar = new();
            Console.Write("Concessionária: ");
            radar.Concessionaria = Console.ReadLine();
            Console.Write("Ano do PNV/SNV: ");
            radar.AnoDoPnvSnv = Console.ReadLine();
            Console.Write("Rodovia: ");
            radar.Rodovia = Console.ReadLine();
            Console.Write("UF: ");
            radar.Uf = Console.ReadLine();
            Console.Write("KM/M: ");
            radar.Km_m = Console.ReadLine();
            Console.Write("Município: ");
            radar.Municipio = Console.ReadLine();
            Console.Write("Tipo de Pista: ");
            radar.TipoPista = Console.ReadLine();
            Console.Write("Sentido: ");
            radar.Sentido = Console.ReadLine();
            Console.Write("Data da Inativação (yyyy-MM-dd): ");
            radar.DataDaInativacao = DateTime.Parse(Console.ReadLine());
            Console.Write("Latitude: ");
            radar.Latitude = Console.ReadLine();
            Console.Write("Longitude: ");
            radar.Longitude = Console.ReadLine();
            Console.Write("Velocidade Leve: ");
            radar.VelocidadeLeve = Console.ReadLine();

            return radar;
        }

        do
        {
            Console.WriteLine("SISTEMA DE RADARES\n" +
                "1 - Inserir um radar;\n" +
                "2 - Atualizar um radar registrado;\n" +
                "3 - Deletar um radar registrado;\n" +
                "4 - Mostrar todos os radares registrados;\n" +
                "5 - Mostrar um radar específico (por Id);\n" +
                "6 - Inserir múltiplos radares;\n" +
                "0 - Encerrar programa.");
            opcao = int.Parse(Console.ReadLine());

            switch (opcao)
            {
                case 1:
                    radar = ReceiveDataFromUser();
                    Console.WriteLine(radarController.Insert(radar) ? "Registro inserido!" : "Erro ao inserir registro...");
                    break;

                case 2:
                    radar = ReceiveDataFromUser();

                    Console.WriteLine(radarController.Update(radar) ? "Atualização inserida!" : "Erro ao atualizar registro...");
                    break;

                case 3:
                    Console.Write("Informe o ID do radar a ser DELETADO: ");
                    int id = int.Parse(Console.ReadLine());
                    Console.WriteLine(radarController.Delete(id) ? "Registro deletado!" : "Erro ao deletar registro...");
                    break;

                case 4:
                    foreach (var item in radarController.GetAll()) Console.WriteLine(item);
                    break;

                case 5:
                    Console.Write("ID do radar: ");
                    id = int.Parse(Console.ReadLine());
                    Console.WriteLine(radarController.Get(id));
                    break;

                case 6:
                    List<Radar> radarList = new List<Radar>();
                    Console.Write("Quantos radares deseja inserir? ");
                    int quantidade = int.Parse(Console.ReadLine());

                    for (int i = 0; i < quantidade; i++)
                    {
                        radar = ReceiveDataFromUser();
                    }

                    Console.WriteLine(radarController.InsertMany(radarList) ? "Registros inseridos!" : "Erro ao inserir registros...");
                    break;

                default:
                    break;
            }
        } while (opcao != 0);

        Console.WriteLine("Programa encerrado.");
    }
}
