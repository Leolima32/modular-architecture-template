using Microsoft.EntityFrameworkCore;
using Module.Brands.Core.Commands;
using Module.Brands.Core.Queries;
using Module.Brands.Core.Entities;
using Module.Brands.Infrastructure.Persistence;
using Module.Brands.Infrastructure.Repositories;

namespace Tests.Module.Brands;

public class BrandTests : IDisposable
{
    private readonly BrandRepository _repository;
    private readonly BrandDbContext _BrandDbContext;
    Guid brandId;
    public BrandTests()
    {
        DbContextOptionsBuilder<BrandDbContext> dbOptions = new DbContextOptionsBuilder<BrandDbContext>().UseInMemoryDatabase(Guid.NewGuid().ToString());
        _BrandDbContext = new BrandDbContext(dbOptions.Options);
        _repository = new BrandRepository(_BrandDbContext);
        SeedDatabase();
    }
    public void SeedDatabase()
    {
        _BrandDbContext.Database.EnsureCreated();

        _BrandDbContext.Brands.AddRange(new List<Brand>()
        {
            new Brand("Amazon"),
            new Brand("Google"),
            new Brand("Meta"),
            new Brand("Twitter"),
            new Brand("Tesla")
        });

        _BrandDbContext.SaveChanges();

        brandId = _BrandDbContext.Brands.FirstOrDefault().Id;
    }

    public void Dispose()
    {
        _BrandDbContext.Database.EnsureDeleted();
    }


    [Fact]
    public async void Should_Query_All_Brands()
    {
        var BrandsEnumerable = await _repository.GetAll();
        var BrandsList = BrandsEnumerable.ToList();

        Assert.Contains(BrandsList, x => x.Name == "Amazon");
        Assert.Contains(BrandsList, x => x.Name == "Google");
        Assert.Contains(BrandsList, x => x.Name == "Meta");
        Assert.Contains(BrandsList, x => x.Name == "Twitter");
        Assert.Contains(BrandsList, x => x.Name == "Tesla");
        Assert.Equal(5, BrandsList.Count());
    }

    [Fact]
    public async void Should_Query_Brand_By_Id()
    {
        var Brand = await _repository.GetById(new GetBrandByIdQuery(brandId), CancellationToken.None);
        Assert.Equal("Amazon", Brand.Name);
    }

    [Fact]
    public async void Should_Add_Brand()
    {
        var addBrandCommand = new CreateBrandCommand()
        {
            Name = "Sony"
        };

        Guid addedBrandId = await _repository.Create(addBrandCommand, CancellationToken.None);

        Assert.Contains(_BrandDbContext.Brands, x => x.Id == addedBrandId);
        Assert.Contains(_BrandDbContext.Brands, x => x.Name == "Sony");
        Assert.Equal(6, _BrandDbContext.Brands.ToList().Count());
    }

    [Fact]
    public async void Should_Update_Brand()
    {
        var Brand = new Brand("Apple");
        _BrandDbContext.Brands.Add(Brand);
        _BrandDbContext.SaveChanges();

        var updateBrandCommand = new UpdateBrandCommand()
        {
            Id = Brand.Id,
            Name = "Microsoft"
        };

        bool sucessfull = await _repository.Update(updateBrandCommand, CancellationToken.None);

        Assert.True(sucessfull);
        Assert.Contains(_BrandDbContext.Brands, x => x.Name == "Microsoft");
        Assert.DoesNotContain(_BrandDbContext.Brands, x => x.Name == "Apple");
    }

    [Fact]
    public async void Should_Delete_Brand()
    {
        var Brand = new Brand("Pants");
        _BrandDbContext.Brands.Add(Brand);
        _BrandDbContext.SaveChanges();

        var deleteBrandCommand = new DeleteBrandCommand()
        {
            Id = Brand.Id,
        };

        bool sucessfull = await _repository.Delete(deleteBrandCommand, CancellationToken.None);

        Assert.True(sucessfull);
        Assert.DoesNotContain(_BrandDbContext.Brands, x => x.Name == "Pants");
    }
}