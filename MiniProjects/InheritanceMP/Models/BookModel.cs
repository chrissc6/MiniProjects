using System;

namespace InheritanceMP
{
    public class BookModel : InventoryItemModel, IPurchasable
    {
        public int NumOfPgs { get; set; }

        public void Purchase()
        {
            QuantityInStock -= 1;
            Console.WriteLine("Book has been purchased");
        }
    }
}
