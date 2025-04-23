using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using GoogleFormsJson.app.Enums;

namespace GoogleFormsJson.app.Records
{
    internal record JsonQuestionDto(
        [property: JsonPropertyName("title")] string Title,
        [property: JsonPropertyName("questionType")] QuestionType QuestionType,
        [property: JsonPropertyName("correctOption")] string CorrectOption,
        [property: JsonPropertyName("options")] List<string> Options
    );
}
