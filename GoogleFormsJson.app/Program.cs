using System.Text.Json;
using GoogleFormsJson.app.Records;
using Newtonsoft.Json;

internal class Program
{
    public static void Main(string[] args)
    {
        var form = GetFormAsJsonObject();

        Console.WriteLine(form.FormTitle);
    }

    private static JsonFormDto GetFormAsJsonObject()
    {
        string? formJsonFilePath;
        JsonFormDto? form;

        do
        {
            formJsonFilePath = Console.ReadLine();
        } while (string.IsNullOrEmpty(formJsonFilePath));

        if (!File.Exists(formJsonFilePath)) throw new Exception("form JSON file not found");

        using (var streamReader = new StreamReader(formJsonFilePath))
        {
            var content = streamReader.ReadToEnd();
            form = JsonConvert.DeserializeObject<JsonFormDto>(content);
        }

        if (form == null) throw new Exception("failed to parse form JSON file");

        return form;
    }
}