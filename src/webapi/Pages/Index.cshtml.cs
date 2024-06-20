using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

public class IndexModel : PageModel
{
    public int Counter { get; set; }
    
    public void OnGet()
    {
        Counter = 0;
    }

    public IActionResult OnPost(){
        return Content(PagesRepository.BuildForm(Counter + 1), "text/html");
    }
}
