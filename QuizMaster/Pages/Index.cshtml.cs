using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace QuizMaster.Pages
{
	public class IndexModel : PageModel
	{
		private readonly ILogger<IndexModel> _logger;
		public bool quiz = true;
		public bool editor = false;
		public IndexModel(ILogger<IndexModel> logger)
		{
			_logger = logger;
		}

		public void OnGet()
		{

		}
		public void OnPostSetQuiz()
		{
			quiz = true;
			editor = false;
			Console.WriteLine(quiz);
		}
		public void OnPostSetEditor()
		{
			quiz = false;
			editor = true;
		}
	}
}