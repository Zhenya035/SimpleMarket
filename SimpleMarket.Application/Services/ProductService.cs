using SimpleMarket.Application.DTOs.Request;
using SimpleMarket.Application.DTOs.Response;
using SimpleMarket.Application.Mapping;
using SimpleMarket.Core.Interfaces.Repositories;

namespace SimpleMarket.Application.Services;

public class ProductService(IProductRepository repository, CategoryService categoryService)
{
    public async Task<List<GetProductDto>> GetProducts()
    {
        var products = await repository.GetAllProducts();
            
        if(products.Count == 0)
            throw new Exception("No products found");
        
        return products.Select(ProductMapping.MapToGetProductDto).ToList(); 
    }

    public async Task<GetProductDto> GetProductById(long id)
    {
        var product = await repository.GetProductById(id);

        return ProductMapping.MapToGetProductDto(product);
    }

    public async Task CreateProduct(AddProductDto addProduct)
    { 
        await categoryService.GetCategoryByIdAsync(addProduct.CategoryId);
        var product = ProductMapping.MapFromAddProductDto(addProduct);
        
        await repository.CreateProduct(product);
    }

    public async Task UpdateProduct(AddProductDto addProduct, long id)
    {
        if(addProduct == null)
            throw new NullReferenceException("Product cannot be null");

        await repository.GetProductById(id);
        
        var product = ProductMapping.MapFromAddProductDto(addProduct);
        
        await repository.UpdateProduct(product, id);
    }

    public async Task DeleteProduct(long id)
    {
        await repository.DeleteProduct(id);
    }
}