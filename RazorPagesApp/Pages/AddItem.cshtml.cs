// Pages/AddItem.cshtml.cs
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using RazorPagesApp.Models;
using RazorPagesApp.Services;

public class AddItemModel : PageModel
{
    private readonly ItemService _service;

    [BindProperty]
    public Item NewItem { get; set; }

    public AddItemModel(ItemService service)
    {
        _service = service;
    }

    public void OnGet()
    {
    }

    public IActionResult OnPost()
    {
        if (!ModelState.IsValid)
        {
            return Page();
        }

        _service.Add(NewItem);
        return RedirectToPage("Items");
    }
}