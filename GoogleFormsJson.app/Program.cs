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

        var errors = new List<string>();

        if (string.IsNullOrEmpty(form.FormTitle)) errors.Add("formTitle cannot be empty");

        if (form.Questions.Count == 0) errors.Add("form.questions should have at least 1 question");

        for (var i = 0; i < form.Questions.Count; i++)
        {
            if (string.IsNullOrEmpty(form.Questions[i].Title)) errors.Add($"[question at index {i}] question.title cannot be null");
            if (form.Questions[i].QuestionType.Equals(null)) errors.Add($"[question at index {i}] question.type cannot be null");
            if (string.IsNullOrEmpty(form.Questions[i].CorrectOption)) errors.Add($"[question at index {i}] question.correctAsnwer cannot be empty");
            if (form.Questions[i].Options.Count <= 1) errors.Add($"[question at index {i}] a question should have at least 2 options");

            for (var j = 0; j < form.Questions[i].Options.Count; j++)
            {
                if (string.IsNullOrEmpty(form.Questions[i].Options[j])) errors.Add($"[question at index {i}] option {j} cannot be empty");
            }
        }

        if (errors.Count > 0) throw new Exception($"found validation errors: {string.Join(", ", errors.ToArray())}");

        return form;
    }
}