namespace DependencyStore.Models;

public class PromoCode
{
    public DateTime ExpireDate { get; set; }
    public double Value { get; set; }
    public string Code { get; set; } = string.Empty;
}