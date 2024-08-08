namespace DependencyStore.Models;

public class Order {

    public Order(double deliveryFee, double dicount, List<Product> products) {
        Code = Guid.NewGuid().ToString().ToUpper()[..15];
        Date = DateTime.Now;
        DeliveryFee = deliveryFee;
        Discount = dicount;
    }

    public string Code { get; set; } = string.Empty;
    public DateTime Date { get; set; }
    public double DeliveryFee { get; set; }
    public double Discount { get; set; }
    public List<Product> Products { get; set; } = null!;
    public double SubTotal => Products.Sum(p => p.Price);
    public double Total => SubTotal - Discount + DeliveryFee;
}