using System;

namespace InheritanceMP
{
    public class ExcavatorModel : InventoryItemModel, IRentable
    {
        public void Dig()
        {
            Console.WriteLine("Digging");
        }

        public void Rent()
        {
            QuantityInStock -= 1;
            Console.WriteLine("Excavator has been rented.");
        }

        public void ReturnRental()
        {
            QuantityInStock += 1;
            Console.WriteLine("Excavator has been returned.");
        }
    }
}
