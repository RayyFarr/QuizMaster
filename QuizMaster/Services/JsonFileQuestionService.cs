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
		public void UpdateDataBase(QuestionModel[] questions)
		{
			using var outputStream = File.Create(JsonFileName);
			
			JsonSerializer.Serialize(
				new Utf8JsonWriter(outputStream, new JsonWriterOptions
				{
					SkipValidation = true,
					Indented = true
				}),
				questions
			);
		}
		public void AddRating(string questionId, int rating)
		{
			var questions = GetQuestions();

			var query = questions.First(x => x.Id == questionId);
			if (query.Ratings == null)
			{
				query.Ratings = new int[] { rating };
			}
			else
			{
				var ratings = query.Ratings.ToList();
				ratings.Add(rating);
				query.Ratings = ratings.ToArray();
			}

			using var outputStream = File.OpenWrite(JsonFileName);

			JsonSerializer.Serialize(
				new Utf8JsonWriter(outputStream, new JsonWriterOptions
				{
					SkipValidation = true,
					Indented = true
				}),
				questions
			);
		}
	}
}
