using Microsoft.EntityFrameworkCore;
using Module.Products.Core.Abstractions;
using Module.Products.Core.Commands;
using Module.Products.Core.Entities;
using Module.Products.Infrastructure.Persistence;
using Module.Products.Infrastructure.Repositories;
using Moq;
using System.Linq;

namespace Tests.Module.Products;

public class ProductTests : IDisposable
{
    private readonly ProductRepository _repository;
    private readonly ProductDbContext _productDbContext;
    Guid tennisId;
    public ProductTests()
    {
        DbContextOptionsBuilder<ProductDbContext> dbOptions = new DbContextOptionsBuilder<ProductDbContext>().UseInMemoryDatabase(Guid.NewGuid().ToString());
        _productDbContext = new ProductDbContext(dbOptions.Options);
        _repository = new ProductRepository(_productDbContext);
        SeedDatabase();
    }
    public void SeedDatabase()
    {
        _productDbContext.Database.EnsureCreated();

        _productDbContext.Products.AddRange(new List<Product>()
        {
            new Product("Tennis"),
            new Product("Smarpthone"),
            new Product("Bag"),
            new Product("T-shirt"),
            new Product("Watch")
        });

        _productDbContext.SaveChanges();

        tennisId = _productDbContext.Products.FirstOrDefault().Id;
    }

    public void Dispose()
    {
        _productDbContext.Database.EnsureDeleted();
    }


    [Fact]
    public async void Should_Query_All_Products()
    {
        var productsEnumerable = await _repository.GetAll();
        var productsList = productsEnumerable.ToList();

        Assert.Contains(productsList, x => x.Name == "Bag");
        Assert.Contains(productsList, x => x.Name == "Smarpthone");
        Assert.Contains(productsList, x => x.Name == "Tennis");
        Assert.Contains(productsList, x => x.Name == "Watch");
        Assert.Contains(productsList, x => x.Name == "T-shirt");
        Assert.Equal(5, productsList.Count());
    }

    [Fact]
    public async void Should_Query_Product_By_Id()
    {
        var product = await _repository.GetById(new GetProductByIdQuery(tennisId), CancellationToken.None);
        Assert.Equal("Tennis", product.Name);
    }

    [Fact]
    public async void Should_Add_Product()
    {
        var addProductCommand = new CreateProductCommand()
        {
            Name = "Jacket"
        };

        Guid addedProductId = await _repository.Create(addProductCommand, CancellationToken.None);

        Assert.Contains(_productDbContext.Products, x => x.Id == addedProductId);
        Assert.Contains(_productDbContext.Products, x => x.Name == "Jacket");
        Assert.Equal(6, _productDbContext.Products.ToList().Count());
    }

    [Fact]
    public async void Should_Update_Product()
    {
        var product = new Product("Pants");
        _productDbContext.Products.Add(product);
        _productDbContext.SaveChanges();

        var updateProductCommand = new UpdateProductCommand()
        {
            Id = product.Id,
            Name = "Trousers"
        };

        bool sucessfull = await _repository.Update(updateProductCommand, CancellationToken.None);

        Assert.True(sucessfull);
        Assert.Contains(_productDbContext.Products, x => x.Name == "Trousers");
        Assert.DoesNotContain(_productDbContext.Products, x => x.Name == "Pants");
    }

    [Fact]
    public async void Should_Delete_Product()
    {
        var product = new Product("Pants");
        _productDbContext.Products.Add(product);
        _productDbContext.SaveChanges();

        var deleteProductCommand = new DeleteProductCommand()
        {
            Id = product.Id,
        };

        bool sucessfull = await _repository.Delete(deleteProductCommand, CancellationToken.None);

        Assert.True(sucessfull);
        Assert.DoesNotContain(_productDbContext.Products, x => x.Name == "Pants");
    }
}