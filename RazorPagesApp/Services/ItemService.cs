// Services/ItemService.cs
using RazorPagesApp.Models;
using System.Collections.Generic;
using System.Linq;

namespace RazorPagesApp.Services;
public class ItemService
{
    private readonly List<Item> _items = new List<Item>();
    private int _nextId = 1;

    public List<Item> GetAll() => _items;

    public void Add(Item item)
    {
        item.Id = _nextId++;
        _items.Add(item);
    }
}