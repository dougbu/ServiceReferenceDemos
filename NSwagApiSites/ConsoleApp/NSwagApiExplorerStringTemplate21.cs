namespace ConsoleApp
{
    public partial class nswagApiExplorerStringClient
    {
        partial void UpdateJsonSerializerSettings(Newtonsoft.Json.JsonSerializerSettings settings)
        {
            settings.Converters.Add(new Newtonsoft.Json.Converters.XmlNodeConverter());
        }

        partial void ProcessResponse(System.Net.Http.HttpClient client, System.Net.Http.HttpResponseMessage response)
        {
            var text = response.Content.ReadAsStringAsync().Result;
            if (text.Length > 0 && text[0] == '<')
            {
                var document = new System.Xml.XmlDocument();
                document.LoadXml(text);

                text = Newtonsoft.Json.JsonConvert.SerializeXmlNode(document, Newtonsoft.Json.Formatting.None);
                var headers = response.Content.Headers;
                var enumerator = headers.ContentEncoding?.GetEnumerator();
                enumerator?.MoveNext();
                var encoding = enumerator?.Current ?? "UTF-8";

                response.Content = new System.Net.Http.StringContent(
                    text,
                    System.Text.Encoding.GetEncoding(encoding),
                    headers.ContentType.MediaType);
            }
        }
    }
}
