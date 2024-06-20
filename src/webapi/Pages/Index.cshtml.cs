using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

public class IndexModel : PageModel
{
    public int Counter { get; set; } = 0;
    
    public void OnGet()
    {
    }

    public IActionResult OnPost(){
        int count = int.Parse(Request.Form["count"]);
        count++;
        return Content(PagesRepository.BuildForm(count), "text/html");
    }
}
