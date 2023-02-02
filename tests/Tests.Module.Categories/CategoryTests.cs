using Microsoft.EntityFrameworkCore;
using Module.Categories.Core.Abstractions;
using Module.Categories.Core.Commands;
using Module.Categories.Core.Entities;
using Module.Categories.Core.Queries;
using Module.Categories.Infrastructure.Persistence;
using Module.Categories.Infrastructure.Repositories;
using Moq;
using System.Linq;

namespace Tests.Module.Categories;

public class CategoryTests : IDisposable
{
    private readonly CategoryRepository _repository;
    private readonly CategoryDbContext _CategoryDbContext;
    Guid categoryId;
    public CategoryTests()
    {
        DbContextOptionsBuilder<CategoryDbContext> dbOptions = new DbContextOptionsBuilder<CategoryDbContext>().UseInMemoryDatabase(Guid.NewGuid().ToString());
        _CategoryDbContext = new CategoryDbContext(dbOptions.Options);
        _repository = new CategoryRepository(_CategoryDbContext);
        SeedDatabase();
    }
    public void SeedDatabase()
    {
        _CategoryDbContext.Database.EnsureCreated();

        _CategoryDbContext.Categories.AddRange(new List<Category>()
        {
            new Category("Cloths"),
            new Category("Eletronics"),
            new Category("Audio"),
            new Category("Books"),
            new Category("Forniture")
        });

        _CategoryDbContext.SaveChanges();

        categoryId = _CategoryDbContext.Categories.FirstOrDefault().Id;
    }

    public void Dispose()
    {
        _CategoryDbContext.Database.EnsureDeleted();
    }


    [Fact]
    public async void Should_Query_All_Categories()
    {
        var CategoriesEnumerable = await _repository.GetAll();
        var CategoriesList = CategoriesEnumerable.ToList();

        Assert.Contains(CategoriesList, x => x.Name == "Cloths");
        Assert.Contains(CategoriesList, x => x.Name == "Eletronics");
        Assert.Contains(CategoriesList, x => x.Name == "Audio");
        Assert.Contains(CategoriesList, x => x.Name == "Books");
        Assert.Contains(CategoriesList, x => x.Name == "Forniture");
        Assert.Equal(5, CategoriesList.Count());
    }

    [Fact]
    public async void Should_Query_Category_By_Id()
    {
        var Category = await _repository.GetById(new GetCategoryByIdQuery(categoryId), CancellationToken.None);
        Assert.Equal("Cloths", Category.Name);
    }

    [Fact]
    public async void Should_Add_Category()
    {
        var addCategoryCommand = new CreateCategoryCommand()
        {
            Name = "Food"
        };

        Guid addedCategoryId = await _repository.Create(addCategoryCommand, CancellationToken.None);

        Assert.Contains(_CategoryDbContext.Categories, x => x.Id == addedCategoryId);
        Assert.Contains(_CategoryDbContext.Categories, x => x.Name == "Food");
        Assert.Equal(6, _CategoryDbContext.Categories.ToList().Count());
    }

    [Fact]
    public async void Should_Update_Category()
    {
        var Category = new Category("Food");
        _CategoryDbContext.Categories.Add(Category);
        _CategoryDbContext.SaveChanges();

        var updateCategoryCommand = new UpdateCategoryCommand()
        {
            Id = Category.Id,
            Name = "Drinks"
        };

        bool sucessfull = await _repository.Update(updateCategoryCommand, CancellationToken.None);

        Assert.True(sucessfull);
        Assert.Contains(_CategoryDbContext.Categories, x => x.Name == "Drinks");
        Assert.DoesNotContain(_CategoryDbContext.Categories, x => x.Name == "Food");
    }

    [Fact]
    public async void Should_Delete_Category()
    {
        var Category = new Category("Gardening");
        _CategoryDbContext.Categories.Add(Category);
        _CategoryDbContext.SaveChanges();

        var deleteCategoryCommand = new DeleteCategoryCommand()
        {
            Id = Category.Id,
        };

        bool sucessfull = await _repository.Delete(deleteCategoryCommand, CancellationToken.None);

        Assert.True(sucessfull);
        Assert.DoesNotContain(_CategoryDbContext.Categories, x => x.Name == "Gardening");
    }
}