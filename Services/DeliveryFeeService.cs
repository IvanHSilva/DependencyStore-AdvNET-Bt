using DependencyStore.Services.Contracts;
using RestSharp;

namespace DependencyStore.Services;

public class DeliveryFeeService : IDeliveryFeeService {

    private readonly Configuration _configuration;

    public DeliveryFeeService(Configuration configuration) 
        => _configuration = configuration;

    public async Task<double> GetDeliveryFeeAsync(string zipCode) {
        
        RestClient restClient = new(_configuration.DeliveryFeeServiceUrl);
        RestRequest restRequest = new RestRequest().AddJsonBody(new {ZipCode = zipCode });
        double deliveryFee = await restClient.PostAsync<double>(restRequest);
        return deliveryFee < 5 ? 5 : deliveryFee;
    }
}
