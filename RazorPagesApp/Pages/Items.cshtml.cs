// Pages/Items.cshtml.cs
using Microsoft.AspNetCore.Mvc.RazorPages;
using RazorPagesApp.Models;
using RazorPagesApp.Services;
using System.Collections.Generic;

public class ItemsModel : PageModel
{
    private readonly ItemService _service;
    public List<Item> ItemList { get; set; }

    public ItemsModel(ItemService service)
    {
        _service = service;
    }

    public void OnGet()
    {
        ItemList = _service.GetAll();
    }
}