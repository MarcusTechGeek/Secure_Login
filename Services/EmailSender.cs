using System.Net.Http;
using System.Text;
using System.Web;

public class EmailSender
{
    private readonly string _apiKey;
    private readonly string _fromEmail;

    public EmailSender(string apiKey, string fromEmail)
    {
        _apiKey = apiKey;
        _fromEmail = fromEmail;
    }

    public async Task SendEmailAsync(string toEmail, string subject, string content)
    {
        var client = new HttpClient();
        client.DefaultRequestHeaders.Add("X-ElasticEmail-ApiKey", _apiKey);

        var body = new Dictionary<string, string>
        {
            { "from", _fromEmail },
            { "to", toEmail },
            { "subject", subject },
            { "body", content },
            { "isTransactional", "true" }
        };

        var requestContent = new FormUrlEncodedContent(body);

        var response = await client.PostAsync("https://api.elasticemail.com/v2/email/send", requestContent);

        response.EnsureSuccessStatusCode();
    }
}