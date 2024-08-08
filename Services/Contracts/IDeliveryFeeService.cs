namespace DependencyStore.Services.Contracts; 

public interface IDeliveryFeeService {
    Task<double> GetDeliveryFeeAsync(string zipCode);
}
