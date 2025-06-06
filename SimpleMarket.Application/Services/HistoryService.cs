﻿using SimpleMarket.Application.DTOs.Response;
using SimpleMarket.Application.Mapping;
using SimpleMarket.Core.Interfaces.Repositories;
using SimpleMarket.Core.Models;

namespace SimpleMarket.Application.Services;

public class HistoryService(IHistoryRepository historyRepository, HistoryProductService historyProductService)
{
    public async Task<History> GetHistoryById(long id)
    {
        var history = await historyRepository.GetHistoryById(id);
        
        if (history == null)
            throw new KeyNotFoundException($"History with id {id} not found");
        
        return history;
    }
    
    public async Task<List<GetProductDto>> GetHistoryByUser(long userId)
    {
        var history = await historyRepository.GetHistoryByUser(userId);
        
        if (history == null)
            throw new KeyNotFoundException($"History for user {userId} not found");
        
        var products = history.Products.Select(p => p.Product).ToList();
        
        return products.Select(ProductMapping.MapToGetProductDto).ToList();
    }

    public async Task AddProduct(long productId, long historyId)
    {
        await historyRepository.AddProduct(productId, historyId);
    }
    
    public async Task CreateHistory(long userId)
    {
        var cart = new History()
        {
            UserId = userId
        };

        await historyRepository.CreateHistory(cart);
    }

    public async Task DeleteHistory(long id)
    {
        await historyProductService.DeleteHistory(id);
    }
}