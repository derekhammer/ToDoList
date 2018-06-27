using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Collections.Generic;
using ToDoList.Models;
using System;

namespace ToDoList.Tests
{
  [TestClass]
  public class ItemTest : IDisposable
  {
    [TestMethod]
    public void SetDescription_SetDescription_String()
    {
      //Arrange
      string description = "Walk the dog.";
      Item newItem = new Item(description);
      Console.WriteLine(newItem.GetDescription());
      description = "Do the dishes.";

      //Act
      newItem.SetDescription("Do the dishes.");
      Console.WriteLine(newItem.GetDescription());
      string result = newItem.GetDescription();

      //Assert
      Assert.AreEqual(description, result);
    }
    [TestMethod]
    public void GetDescription_ReturnsDescription_String()
    {
      //Arrange
      string description = "Walk the dog.";
      Item newItem = new Item(description);
      newItem.Save();

      //Act
      List<Item> instances = Item.GetAll();
      Item savedItem = instances[0];

      //Assert
      Assert.AreEqual(newItem, savedItem);
    }
    [TestMethod]
    public void GetAll_ReturnsItems_ItemList()
    {
      //Arrange
      string description01 = "Walk the dog";
      string description02 = "Wash the dishes";
      Item newItem1 = new Item(description01);
      newItem1.Save();
      Item newItem2 = new Item(description02);
      newItem2.Save();
      List<Item> newList = new List<Item> { newItem1, newItem2 };

      //Act
      List<Item> result = Item.GetAll();

      //Assert
      CollectionAssert.AreEqual(newList, result);
    }
    public void Dispose()
    {
      Item.ClearAll();
    }
  }
}