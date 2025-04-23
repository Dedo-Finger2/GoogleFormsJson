using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace GoogleFormsJson.app.Records
{
    internal record JsonFormDto(
        [property: JsonPropertyName("formTitle")] string FormTitle,
        [property: JsonPropertyName("questions")] List<JsonQuestionDto> Questions
    );
}
