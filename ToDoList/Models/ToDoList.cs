using System.Collections.Generic;
using System;

namespace ToDoList.Models
{
  public class Item
  {
    private string _description;
    private static List<Item> _instances = new List<Item> {};

    public Item(string description)
    {
      _description = description;
    }
    public string GetDescription()
    {
      return _description;
    }
    public void SetDescription(string newDescription)
    {
      _description = newDescription;
    }
    public static List<Item> GetAll()
    {
      return _instances;
    }
    public void Save()
    {
      _instances.Add(this);
    }
    public static void ClearAll()
    {
      _instances.Clear();
    }
  }
  class Program
  {
    public static void Main()
    {
      Console.WriteLine("Welcome to List. What would you like to do? [Add/View/Quit]");
      string userOption = Console.ReadLine();

      if(userOption == "Add" || userOption == "add")
      {
        Console.WriteLine("Add Item to List");
        string userItem = Console.ReadLine();
        Item newItem = new Item(userItem);
        newItem.Save();
        Main();
      }
      else if(userOption == "View" || userOption == "view")
      {
        List<Item> result = Item.GetAll();
        foreach (Item listItems in result)
        {
            Console.WriteLine(listItems.GetDescription());
        }
        Main();
      }
      else if(userOption == "Quit" || userOption == "quit")
      {

      }
      else
      {
        Console.WriteLine("Invalid input, try again.");
        Main();
      }
    }
  }
}
