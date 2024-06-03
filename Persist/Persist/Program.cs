using Controller;
using Model;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Diagnostics;

class Program
{
    static void Main(string[] args)
    {
        RadarController radarController = new RadarController();
        int opcao = 0;
        Radar radar = null;


        Radar ReceiveDataFromUser(Radar novoRadar)
        {
            Console.WriteLine("--- Vamos inserir um novo radar... ---");
            novoRadar = new();
            Console.Write("Concessionária: ");
            novoRadar.Concessionaria = Console.ReadLine();
            Console.Write("Ano do PNV/SNV: ");
            novoRadar.AnoDoPnvSnv = Console.ReadLine();
            Console.Write("Rodovia: ");
            novoRadar.Rodovia = Console.ReadLine();
            Console.Write("UF: ");
            novoRadar.Uf = Console.ReadLine();
            Console.Write("KM/M: ");
            novoRadar.Km_m = Console.ReadLine();
            Console.Write("Município: ");
            novoRadar.Municipio = Console.ReadLine();
            Console.Write("Tipo de Pista: ");
            novoRadar.TipoPista = Console.ReadLine();
            Console.Write("Sentido: ");
            novoRadar.Sentido = Console.ReadLine();
            Console.Write("Data da Inativação (yyyy-MM-dd): ");
            novoRadar.DataDaInativacao = DateTime.Parse(Console.ReadLine());
            Console.Write("Latitude: ");
            novoRadar.Latitude = Console.ReadLine();
            Console.Write("Longitude: ");
            novoRadar.Longitude = Console.ReadLine();
            Console.Write("Velocidade Leve: ");
            novoRadar.VelocidadeLeve = Console.ReadLine();

            return novoRadar;
        }

        ListaRadar GetJsonRadarData()
        {
            string path = @"C:\5by5\radar-proj\data";
            string file = Path.Combine(path, "radar.json");
            string json = "";
            ListaRadar radarData = new();

            try
            {
                if (!Directory.Exists(path)) Directory.CreateDirectory(path);

                if (File.Exists(file)) json = File.ReadAllText(file);
                else Console.WriteLine($"Arquivo não encontrado: {file}");
            }
            catch (Exception e) { Console.WriteLine($"-- ERRO ao processar o arquivo JSON: {e.Message}"); }

            return JsonConvert.DeserializeObject<ListaRadar>(json);
        }

        do
        {
            Console.WriteLine("SISTEMA DE RADARES\n" +
                "1 - Inserir um radar;\n" +
                "2 - Atualizar um radar registrado;\n" +
                "3 - Deletar um radar registrado;\n" +
                "4 - Mostrar todos os radares registrados;\n" +
                "5 - Mostrar um radar específico (por Id);\n" +
                "6 - Inserir radares do arquivo .JSON externo;\n" +
                "0 - Encerrar programa.");
            opcao = int.Parse(Console.ReadLine());

            switch (opcao)
            {
                case 1:
                    Console.Clear();
                    radar = ReceiveDataFromUser(radar);
                    Console.WriteLine(radarController.Insert(radar) ? "Registro inserido!" : "-- ERRO ao inserir registro...");

                    Console.WriteLine("\nPressione qualquer tecla para continuar...");
                    Console.ReadKey();
                    break;

                case 2:
                    Console.Clear();
                    radar = ReceiveDataFromUser(radar);
                    Console.WriteLine(radarController.Update(radar) ? "Atualização inserida!" : "-- ERRO ao atualizar registro...");

                    Console.WriteLine("\nPressione qualquer tecla para continuar...");
                    Console.ReadKey();
                    break;

                case 3:
                    Console.Clear();
                    Console.Write("Informe o ID do radar a ser DELETADO: ");
                    int id = int.Parse(Console.ReadLine());
                    Console.WriteLine(radarController.Delete(id) ? "Registro deletado!" : "-- ERRO ao deletar registro...");

                    Console.WriteLine("\nPressione qualquer tecla para continuar...");
                    Console.ReadKey();
                    break;

                case 4:
                    Console.Clear();
                    foreach (var item in radarController.GetAll()) Console.WriteLine(item);

                    Console.WriteLine("\nPressione qualquer tecla para continuar...");
                    Console.ReadKey();
                    break;

                case 5:
                    Console.Clear();
                    Console.Write("ID do radar: ");
                    id = int.Parse(Console.ReadLine());
                    Console.WriteLine(radarController.Get(id));

                    Console.WriteLine("\nPressione qualquer tecla para continuar...");
                    Console.ReadKey();
                    break;

                case 6:
                    Console.Clear();

                    Stopwatch sw = new();
                    sw.Start();
                    Console.WriteLine(radarController.InsertMany(GetJsonRadarData().Radares) ? "Registros inseridos!" : "Erro ao inserir registros...");
                    sw.Stop();

                    Console.WriteLine($"A insersão demorou {sw.ElapsedMilliseconds} milissegundos.");

                    Console.WriteLine("\nPressione qualquer tecla para continuar...");
                    Console.ReadKey();
                    break;
                default:
                    break;
            }
        } while (opcao != 0);

        Console.WriteLine("Programa encerrado.");
    }
}
