using translator;

class Program
{
    static async Task Main(string[] args)
    {
        int choice;
   
        Console.WriteLine("Selecione uma opção:");
        Console.WriteLine("Pressione a tecla 1 para traduzir um texto");
        Console.WriteLine("Pressione a tecla 2 para traduzir o texto de um site");

        choice = Convert.ToInt32(Console.ReadLine());

        Message message = new Message();

        switch (choice)
        {
            case 1:        
                await message.readText();
                break;
            case 2:
                await message.readDocument();
                break;
            default:
                Console.WriteLine("Escolha inválida");
                break;
        }
    }
}