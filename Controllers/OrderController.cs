using Dapper;
using DependencyStore.Models;
using DependencyStore.Repositories.Contracts;
using DependencyStore.Services.Contracts;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Data.SqlClient;
using RestSharp;

namespace DependencyStore.Controllers;

public class OrderController : ControllerBase { 

    private readonly ICustomerRepository _repository;
    private readonly IDeliveryFeeService _service;
    private readonly IPromoCodeRepository _promo;

    public OrderController(ICustomerRepository customerRepository, 
        IDeliveryFeeService deliveryFeeService, IPromoCodeRepository promoCodeRepository) {
        _repository = customerRepository;
        _service = deliveryFeeService;
        _promo = promoCodeRepository;
    }

    [Route("v1/orders")]
    [HttpPost]
    public async Task<IActionResult> Place(string customerId, string zipCode, string promoCode, int[] products)
    {
        Customer customer = await _repository.GetCustomerByIdAsync(customerId);
        if (customer == null) 
            return NotFound();

        double deliveryFee = await _service.GetDeliveryFeeAsync(zipCode);
        PromoCode cupom = await _promo.GetPromoCodeAsync(promoCode);
        double discount = cupom.Value;
        Order order = new(deliveryFee, discount, new List<Product>());
        return Ok($"Pedido {order.Code} gerado com sucesso!");
    }
}