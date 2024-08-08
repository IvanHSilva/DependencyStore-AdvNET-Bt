using DependencyStore.Services.Contracts;
using RestSharp;

namespace DependencyStore.Services;

public class DeliveryFeeService : IDeliveryFeeService {
    
    public async Task<double> GetDeliveryFeeAsync(string zipCode) {
        RestClient restClient = new("https://api.myorg.com");
        RestRequest restRequest = new RestRequest().AddJsonBody(new {ZipCode = zipCode });
        double deliveryFee = await restClient.PostAsync<double>(restRequest);
        return deliveryFee < 5 ? 5 : deliveryFee;
    }
}
