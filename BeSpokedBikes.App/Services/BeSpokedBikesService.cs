using BeSpokedBikes.Shared.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace BeSpokedBikes.App.Services
{
    public class BeSpokedBikesService : IBeSpokedBikesService
    {
        private readonly HttpClient _httpClient;
        private readonly JsonSerializerOptions options = new JsonSerializerOptions() { PropertyNameCaseInsensitive = true };

        public BeSpokedBikesService(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        public async Task<IEnumerable<ProductDto>> GetProducts()
        {
            try
            {
                var response = await _httpClient.GetAsync("api/products");

                if (response.IsSuccessStatusCode)
                {
                    return await JsonSerializer.DeserializeAsync<IEnumerable<ProductDto>>(await response.Content.ReadAsStreamAsync(), options);
                }

                return null;
            }
            catch (Exception e)
            {
                Console.WriteLine($"{e.Message} - {e.StackTrace}");
                return null;
            }
            //var products =  await JsonSerializer.DeserializeAsync<IEnumerable<ProductDto>>(await _httpClient.GetStreamAsync($"api/products"), options);

            //return products;
        }

        public async Task<ProductDto> GetProduct(int id)
        {
            return await JsonSerializer.DeserializeAsync<ProductDto>(await _httpClient.GetStreamAsync($"api/products/" + id), options);
        }

        public async Task<bool> UpdateProduct(int id, ProductUpdateDto updateProduct)
        {
            var productJson = new StringContent(JsonSerializer.Serialize(updateProduct), Encoding.UTF8, "application/json");

            var response = await _httpClient.PutAsync("api/products/" + id, productJson);

            return response.IsSuccessStatusCode;
        }

        public async Task<IEnumerable<SalesPersonDto>> GetSalesPersons()
        {
            return await JsonSerializer.DeserializeAsync<IEnumerable<SalesPersonDto>>(await _httpClient.GetStreamAsync($"api/salespersons"), options);
        }

        public async Task<SalesPersonDto> GetSalesPerson(int id)
        {
            return await JsonSerializer.DeserializeAsync<SalesPersonDto>(await _httpClient.GetStreamAsync($"api/salespersons/" + id), options);
        }

        public async Task<bool> UpdateSalesPerson(int id, SalesPersonUpdateDto updateSalesPerson)
        {
            var salesPersonJson = new StringContent(JsonSerializer.Serialize(updateSalesPerson), Encoding.UTF8, "application/json");

            var response = await _httpClient.PutAsync("api/salespersons/" + id, salesPersonJson);

            return response.IsSuccessStatusCode;
        }

        public async Task<IEnumerable<CustomerDto>> GetCustomers()
        {
            return await JsonSerializer.DeserializeAsync<IEnumerable<CustomerDto>>(await _httpClient.GetStreamAsync($"api/customers"), options);
        }

        public async Task<CustomerDto> GetCustomer(int id)
        {
            return await JsonSerializer.DeserializeAsync<CustomerDto>(await _httpClient.GetStreamAsync($"api/customers/" + id), options);
        }

        public async Task<IEnumerable<SaleDto>> GetSales()
        {
            return await JsonSerializer.DeserializeAsync<IEnumerable<SaleDto>>(await _httpClient.GetStreamAsync($"api/sales"), options);
        }

        public async Task<SaleDto> GetSale(int id)
        {
            return await JsonSerializer.DeserializeAsync<SaleDto>(await _httpClient.GetStreamAsync($"api/sales/" + id), options);
        }

        public async Task<SaleDto> CreateSale(SalesCreationDto createSale)
        {
            var salesJson = new StringContent(JsonSerializer.Serialize(createSale), Encoding.UTF8, "application/json");

            var response = await _httpClient.PostAsync("api/sales", salesJson);

            if (response.IsSuccessStatusCode)
            {
                return await JsonSerializer.DeserializeAsync<SaleDto>(await response.Content.ReadAsStreamAsync(), options);
            }

            return null;
        }

        public async Task<IEnumerable<DiscountDto>> GetDiscounts(bool OnlyActiveDiscounts = false)
        {
            return await JsonSerializer.DeserializeAsync<IEnumerable<DiscountDto>>
                (await _httpClient.GetStreamAsync($"api/discounts?OnlyActiveDiscounts=" + OnlyActiveDiscounts), options);
        }
    }
}
