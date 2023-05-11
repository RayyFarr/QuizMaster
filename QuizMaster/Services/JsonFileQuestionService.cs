using QuizMaster.Models;
using System.Text.Json;

namespace QuizMaster.Services
{
	public class JsonFileQuestionService
	{
		public JsonFileQuestionService(IWebHostEnvironment webHostEnvironment)
		{
			WebHostEnvironment = webHostEnvironment;
		}

		public IWebHostEnvironment WebHostEnvironment { get; }

		private string JsonFileName => Path.Combine(WebHostEnvironment.WebRootPath, "data", "questions.json");

		public QuestionModel[] GetQuestions()
		{
			using var jsonFileReader = File.OpenText(JsonFileName);
			return JsonSerializer.Deserialize<QuestionModel[]>(jsonFileReader.ReadToEnd(),
				new JsonSerializerOptions
				{
					PropertyNameCaseInsensitive = true
				});
		}
	}
}
