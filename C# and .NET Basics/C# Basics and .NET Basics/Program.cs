using C__Basics_and_.NET_Basics;

var myList = new MyCustomList<string>();
myList.Add("First element");
myList.Add("Second element");
myList.Add("Third element");

//yield returns elements in reversed order
foreach (var item in myList)
{
    Console.WriteLine(item);
}

var product = new ProductCloneable 
{
    Id = 1, Name = "Test", 
    Price=30, 
    ProductTags = new List<ProductTag> { new ProductTag { Title = "testTag1"}, new ProductTag { Title = "testTag2" }, new ProductTag { Title = "testTag3" } } 
};

//Example of how deep copy is working
//If we used a shallow copy the Clear() method would clear both collections in product and deepCopyProduct,
//but since we use deep copy, only the collection inside deepCopyProduct is cleared
var deepCopyProduct = (ProductCloneable)product.Clone();
Console.WriteLine(deepCopyProduct.ProductTags.Count);
deepCopyProduct.ProductTags.Clear();
Console.WriteLine(product.ProductTags.Count);