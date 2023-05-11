using System.Text.Json;

namespace QuizMaster.Models
{
	public class QuestionModel
	{
		public string? Id { get; set; }
		public string? Question { get; set; }
		public string[]? Answers { get; set; }
		public int? AnswerIndex { get; set; }
		public string? Hint { get; set; }
		public string? Contributor { get; set; }
		public int[]? Ratings { get; set; }

		public override string ToString() => JsonSerializer.Serialize(this);
	}
}
