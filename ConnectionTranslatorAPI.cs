using Newtonsoft.Json;
using System.Text;
using translator;
using Translator.InfoConnection;

namespace Translator
{
    internal class ConnectionTranslatorAPI
    {
        public async Task connectionAPI(Message message)
        {
            InfoConnectionTranslate infoConnectionTranslate = new InfoConnectionTranslate();

            string route = $"/translate?api-version=3.0&from={message.getLanguageFrom()}&to={message.getLanguageTo()}";
            string textToTranslate = message.getText();

            object[] body = new object[] { new { Text = textToTranslate } };

            var requestBody = JsonConvert.SerializeObject(body);

            using (var client = new HttpClient())
        
            using (var request = new HttpRequestMessage())
        
            {
                request.Method = HttpMethod.Post;
                request.RequestUri = new Uri(infoConnectionTranslate.getEndpoint() + route);
                request.Content = new StringContent(requestBody, Encoding.UTF8 ,"application/json");
                request.Headers.Add("Ocp-Apim-Subscription-Key", infoConnectionTranslate.getKey());
                request.Headers.Add("Ocp-Apim-Subscription-Region", infoConnectionTranslate.getLocation());
                HttpResponseMessage response = await client.SendAsync(request).ConfigureAwait(false);
                string result = await response.Content.ReadAsStringAsync();
                setResult(result);
            }
        }
        
        private string result;
        public string getResult()
        {
            return result;
        }
        public void setResult(string result)
        {
            this.result = result;
        }
    
    }
}