namespace Models
{
    public class Product
    {
        public string Name { get; set; }
        public string Category { get; set; }    
        public double Price { get; set; }
        public int Quantity { get; set; }
        public override string ToString()
        {
            return $"{Name} {Category} {Price} {Quantity}";
        }
    }
}
