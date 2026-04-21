using MyApi.DTOs;
using MyApi.Models;
using MyApi.Repositories;

namespace MyApi.Services;

// ─── Product Service ────────────────────────────────────────────

public interface IProductService
{
    Task<PagedResult<ProductDto>> GetAllAsync(int page, int pageSize);
    Task<ProductDto?> GetByIdAsync(int id);
    Task<ProductDto> CreateAsync(CreateProductDto dto);
    Task<ProductDto?> UpdateAsync(int id, UpdateProductDto dto);
    Task<bool> DeleteAsync(int id);
}

public class ProductService : IProductService
{
    private readonly IRepository<Product> _repository;

    public ProductService(IRepository<Product> repository)
        => _repository = repository;

    public async Task<PagedResult<ProductDto>> GetAllAsync(int page, int pageSize)
    {
        var items = await _repository.GetAllAsync(page, pageSize);
        var total = await _repository.CountAsync();
        return new PagedResult<ProductDto>(items.Select(ToDto), total, page, pageSize);
    }

    public async Task<ProductDto?> GetByIdAsync(int id)
    {
        var product = await _repository.GetByIdAsync(id);
        return product is null ? null : ToDto(product);
    }

    public async Task<ProductDto> CreateAsync(CreateProductDto dto)
    {
        var product = new Product
        {
            Name = dto.Name,
            Description = dto.Description,
            Price = dto.Price,
            Stock = dto.Stock
        };
        var created = await _repository.CreateAsync(product);
        return ToDto(created);
    }

    public async Task<ProductDto?> UpdateAsync(int id, UpdateProductDto dto)
    {
        var product = await _repository.GetByIdAsync(id);
        if (product is null) return null;

        product.Name = dto.Name;
        product.Description = dto.Description;
        product.Price = dto.Price;
        product.Stock = dto.Stock;
        product.UpdatedAt = DateTime.UtcNow;

        var updated = await _repository.UpdateAsync(product);
        return ToDto(updated);
    }

    public Task<bool> DeleteAsync(int id)
        => _repository.DeleteAsync(id);

    private static ProductDto ToDto(Product p) =>
        new(p.Id, p.Name, p.Description, p.Price, p.Stock, p.CreatedAt, p.UpdatedAt);
}

// ─── User Service ───────────────────────────────────────────────

public interface IUserService
{
    Task<PagedResult<UserDto>> GetAllAsync(int page, int pageSize);
    Task<UserDto?> GetByIdAsync(int id);
    Task<UserDto> CreateAsync(CreateUserDto dto);
    Task<UserDto?> UpdateAsync(int id, UpdateUserDto dto);
    Task<bool> DeleteAsync(int id);
}

public class UserService : IUserService
{
    private readonly IRepository<User> _repository;

    public UserService(IRepository<User> repository)
        => _repository = repository;

    public async Task<PagedResult<UserDto>> GetAllAsync(int page, int pageSize)
    {
        var items = await _repository.GetAllAsync(page, pageSize);
        var total = await _repository.CountAsync();
        return new PagedResult<UserDto>(items.Select(ToDto), total, page, pageSize);
    }

    public async Task<UserDto?> GetByIdAsync(int id)
    {
        var user = await _repository.GetByIdAsync(id);
        return user is null ? null : ToDto(user);
    }

    public async Task<UserDto> CreateAsync(CreateUserDto dto)
    {
        var user = new User
        {
            FirstName = dto.FirstName,
            LastName = dto.LastName,
            Email = dto.Email
        };
        var created = await _repository.CreateAsync(user);
        return ToDto(created);
    }

    public async Task<UserDto?> UpdateAsync(int id, UpdateUserDto dto)
    {
        var user = await _repository.GetByIdAsync(id);
        if (user is null) return null;

        user.FirstName = dto.FirstName;
        user.LastName = dto.LastName;
        user.Email = dto.Email;
        user.UpdatedAt = DateTime.UtcNow;

        var updated = await _repository.UpdateAsync(user);
        return ToDto(updated);
    }

    public Task<bool> DeleteAsync(int id)
        => _repository.DeleteAsync(id);

    private static UserDto ToDto(User u) =>
        new(u.Id, u.FirstName, u.LastName, u.Email, u.CreatedAt, u.UpdatedAt);
}
