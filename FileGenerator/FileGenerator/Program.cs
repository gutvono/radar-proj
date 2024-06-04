using FileGenerator;

class Program
{
    static void Main(string[] args)
    {
        int optMenuPrincipal;
        int optMenuArquivo = -1;

        do
        {
            Console.Clear();
            Console.WriteLine("Bem vindo ao gerador de arquivos.\n" +
                              "Gerar a partir do banco:\n" +
                              "1 - SQL Server;\n" +
                              "2 - MongoDB;\n" +
                              "0 - Finalizar programa.");
            optMenuPrincipal = int.Parse(Console.ReadLine());

            if (optMenuPrincipal == 0)
            {
                Console.WriteLine("Finalizando programa...");
                break;
            }

            FileWriter fileWriter = new(optMenuPrincipal);

            do
            {
                Console.Clear();
                Console.WriteLine("Gerar arquivo com extensão:\n" +
                                  "1 - .csv;\n" +
                                  "2 - .json;\n" +
                                  "3 - .xml;\n" +
                                  "0 - Voltar.");
                optMenuArquivo = int.Parse(Console.ReadLine());

                switch (optMenuArquivo)
                {
                    case 1:
                        fileWriter.GenerateCsv();
                        Console.WriteLine("Pressione qualquer tecla para continuar...");
                        Console.ReadKey();
                        break;
                    case 2:
                        fileWriter.GenerateJson();
                        Console.WriteLine("Pressione qualquer tecla para continuar...");
                        Console.ReadKey();
                        break;
                    case 3:
                        fileWriter.GenerateXml();
                        Console.WriteLine("Pressione qualquer tecla para continuar...");
                        Console.ReadKey();
                        break;
                    default:
                        break;
                }
            } while (optMenuArquivo != 0);

        } while (optMenuPrincipal != 0);
    }
}
