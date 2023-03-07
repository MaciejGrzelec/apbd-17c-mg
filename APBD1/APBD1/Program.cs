// See https://aka.ms/new-console-template for more information
using System.Collections;
using System.Net;
using System.Text.RegularExpressions;

internal class Program
{
    private static async Task Main(string[] args)
    {
        if (args.Length < 1) throw new ArgumentNullException();
        var url = args[0];

        if (!IsValidUrl(url)) throw new ArgumentException();

        var httpClient = new HttpClient();

        var regex = new Regex(@"[a-zA-Z0-9_.+-]+@[a-zA-Z0-9-]+\.[a-zA-Z0-9-.]+");

        var response = await httpClient.GetAsync(url);

        HttpStatusCode statusCode = response.StatusCode;
        if((int)statusCode<200 || (int)statusCode > 299) {
            throw new Exception("Błąd w czasie pobierania strony");
        };

        string content = await response.Content.ReadAsStringAsync();

        MatchCollection result = regex.Matches(content);

        Hashtable hashtable = new Hashtable();

        string foundmatch;

        foreach (Match match in result)
        {
            foundmatch = match.ToString();
            if (hashtable.Contains(foundmatch) == false)
                hashtable.Add(foundmatch, string.Empty);
        }

        if(hashtable.Count == 0) throw new Exception("Nie znaleziono adresów email");

        foreach (DictionaryEntry element in hashtable)
        {
            Console.WriteLine(element.Key);
        }
    }

    public static bool IsValidUrl(string url)
    {
        Uri? uriResult;
        var test1= Uri.TryCreate(url, UriKind.Absolute, out uriResult) &&
                (uriResult.Scheme == Uri.UriSchemeHttp || uriResult.Scheme == Uri.UriSchemeHttps);

        var test2= Uri.IsWellFormedUriString(url, UriKind.Absolute);

        return test1 && test2;
    }
}