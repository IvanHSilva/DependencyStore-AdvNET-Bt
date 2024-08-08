﻿using Dapper;
using DependencyStore.Models;
using DependencyStore.Repositories.Contracts;
using Microsoft.Data.SqlClient;

namespace DependencyStore.Repositories;

public class CustomerRepository : ICustomerRepository {

    private readonly SqlConnection _connection;

    public CustomerRepository(SqlConnection connection) => 
        _connection = connection;

    public async Task<Customer> GetCustomerByIdAsync(string customerId) {
        const string query = "SELECT Id, Name, Email FROM CUSTOMER WHERE ID=@id";
        return await _connection.QueryFirstAsync<Customer>(query, new {id = customerId});
    }
}
