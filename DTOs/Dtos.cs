namespace MyApi.DTOs;

// ─── Product DTOs ───────────────────────────────────────────────

public record ProductDto(
    int Id,
    string Name,
    string? Description,
    decimal Price,
    int Stock,
    DateTime CreatedAt,
    DateTime UpdatedAt
);

public record CreateProductDto(
    string Name,
    string? Description,
    decimal Price,
    int Stock
);

public record UpdateProductDto(
    string Name,
    string? Description,
    decimal Price,
    int Stock
);

// ─── User DTOs ──────────────────────────────────────────────────

public record UserDto(
    int Id,
    string FirstName,
    string LastName,
    string Email,
    DateTime CreatedAt,
    DateTime UpdatedAt
);

public record CreateUserDto(
    string FirstName,
    string LastName,
    string Email
);

public record UpdateUserDto(
    string FirstName,
    string LastName,
    string Email
);

// ─── Common ─────────────────────────────────────────────────────

public record PagedResult<T>(
    IEnumerable<T> Items,
    int TotalCount,
    int Page,
    int PageSize
);
