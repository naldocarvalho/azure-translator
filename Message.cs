using HtmlAgilityPack;
using Translator;

namespace translator
{
    internal class Message 
    {
        private static readonly HttpClient _httpClient = new HttpClient();
        private string text;

        public string getText()
        {
            return text;
        }

        public void setText(string text)
        {
            this.text = text;
        }

        private string systemText;
        public string getSystemText()
        {
            return systemText;
        }

        public void setSystemText(string systemText)
        {
            this.systemText = systemText;
        }

        private string systemTextUser;
        public string getSystemTextUser()
        {
            return systemTextUser;
        }

        public void setSystemTextUser(string systemTextUser)
        {
            this.systemTextUser = systemTextUser;
        }

        private string languageFrom;
        public string getLanguageFrom()
        {
            return languageFrom;
        }

        public void setLanguageFrom(string languageFrom)
        {
            this.languageFrom = languageFrom;
        }
        
        private string languageTo;
        public string getLanguageTo()
        {
            return languageTo;
        }

        public void setLanguageTo(string languageTo)
        {
            this.languageTo = languageTo;
        }

        public async Task readText()
        {

            Console.Write("\nInforme o idioma do texto: ");
            setLanguageFrom(Console.ReadLine());

            Console.Write("\nInforme o idioma de tradução: ");
            setLanguageTo(Console.ReadLine());

            Console.Write("\nInforme a menssagem: ");
            setText(Console.ReadLine());

            try
            {
                ConnectionTranslatorAPI connectionTranslatorAPI = new ConnectionTranslatorAPI();
                await connectionTranslatorAPI.connectionAPI(this);
                Console.WriteLine(connectionTranslatorAPI.getResult());
            }
            catch (Exception ex)
            {
                Console.WriteLine($"\nErro ao processar a tradução: {ex.Message}\n");
            }

        }

        public async Task readDocument()
        {
            string url = "";

            Console.Write($"\nInforme o idioma do texto: ");
            setLanguageFrom(Console.ReadLine());

            Console.Write($"\nInforme o idioma de tradução: ");
            setLanguageTo(Console.ReadLine());

            Console.Write("\nInforme o site: ");
            url = Console.ReadLine();

            try
            {
                var htmlDocument = new HtmlDocument();
                var html = await _httpClient.GetStringAsync(url);
                htmlDocument.LoadHtml(html);

                setText(htmlDocument.DocumentNode.InnerText);

                ConnectionTranslatorAPI connectionTranslatorAPI = new ConnectionTranslatorAPI();
                await connectionTranslatorAPI.connectionAPI(this);

                Console.WriteLine(connectionTranslatorAPI.getResult());
            }
            catch(Exception ex)
            {
                Console.WriteLine($"\nErro ao processar o arquivo: {ex.Message}\n");
            }
            
        }
    }
}