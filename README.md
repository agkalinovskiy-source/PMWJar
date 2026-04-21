# MyApi — .NET 8 REST API

Полноценный REST API на ASP.NET Core 8 с CRUD операциями, EF Core и чистой архитектурой.

## Стек

- **ASP.NET Core 8** — фреймворк
- **Entity Framework Core 8 + SQLite** — база данных (легко заменить на PostgreSQL / SQL Server)
- **Swagger / OpenAPI** — документация API
- **Repository + Service pattern** — архитектура

## Структура проекта

```
MyApi/
├── Controllers/
│   ├── ProductsController.cs   # CRUD для товаров
│   └── UsersController.cs      # CRUD для пользователей
├── Data/
│   └── AppDbContext.cs         # EF Core контекст
├── DTOs/
│   └── Dtos.cs                 # Data Transfer Objects
├── Middleware/
│   └── ExceptionMiddleware.cs  # Глобальная обработка ошибок
├── Models/
│   └── Entities.cs             # Сущности БД
├── Repositories/
│   └── Repository.cs           # Универсальный репозиторий
├── Services/
│   └── Services.cs             # Бизнес-логика
├── Program.cs                  # Точка входа, DI, пайплайн
└── appsettings.json
```

## Запуск

```bash
# Восстановить зависимости
dotnet restore

# Запустить
dotnet run

# Swagger UI откроется по адресу:
# https://localhost:5001/swagger
```

## API Endpoints

### Товары `/api/products`

| Метод  | URL                  | Описание                        |
|--------|----------------------|---------------------------------|
| GET    | /api/products        | Список товаров (page, pageSize) |
| GET    | /api/products/{id}   | Получить товар по ID            |
| POST   | /api/products        | Создать товар                   |
| PUT    | /api/products/{id}   | Обновить товар                  |
| DELETE | /api/products/{id}   | Удалить товар                   |

### Пользователи `/api/users`

| Метод  | URL               | Описание                            |
|--------|-------------------|-------------------------------------|
| GET    | /api/users        | Список пользователей (page, pageSize)|
| GET    | /api/users/{id}   | Получить пользователя по ID         |
| POST   | /api/users        | Создать пользователя                |
| PUT    | /api/users/{id}   | Обновить пользователя               |
| DELETE | /api/users/{id}   | Удалить пользователя                |

## Примеры запросов

```bash
# Получить все товары
curl -X GET "https://localhost:5001/api/products?page=1&pageSize=10"

# Создать товар
curl -X POST "https://localhost:5001/api/products" \
  -H "Content-Type: application/json" \
  -d '{"name":"Планшет","description":"10 дюймов","price":30000,"stock":15}'

# Обновить товар
curl -X PUT "https://localhost:5001/api/products/1" \
  -H "Content-Type: application/json" \
  -d '{"name":"Ноутбук Pro","description":"16 дюймов","price":95000,"stock":5}'

# Удалить товар
curl -X DELETE "https://localhost:5001/api/products/1"
```

## Смена базы данных

Для перехода на **PostgreSQL** замените в `MyApi.csproj`:
```xml
<PackageReference Include="Npgsql.EntityFrameworkCore.PostgreSQL" Version="8.0.0" />
```

И в `Program.cs`:
```csharp
options.UseNpgsql(connectionString)
```

Для **SQL Server**:
```csharp
options.UseSqlServer(connectionString)
```
