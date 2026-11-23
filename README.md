# Products API

A REST API for managing products, built with C# and ASP.NET Core, with data stored in PostgreSQL through Entity Framework Core.

## Tech stack

- C# and ASP.NET Core Web API (.NET 10)
- Entity Framework Core with the Npgsql provider
- PostgreSQL

## Features

- Full CRUD for products (create, read, update, delete)
- Data stored permanently in a PostgreSQL database
- Database tables created from the C# model using EF Core migrations
- Correct HTTP status codes (200, 201, 204, 404)

## Endpoints

| Method | Endpoint | Description | Success response |
|---|---|---|---|
| GET | `/api/products` | List all products | 200 |
| GET | `/api/products/{id}` | Get one product | 200, or 404 if not found |
| POST | `/api/products` | Create a product | 201 |
| PUT | `/api/products/{id}` | Update a product | 204, or 404 if not found |
| DELETE | `/api/products/{id}` | Delete a product | 204, or 404 if not found |

## Example

Create a product:

```bash
curl -X POST http://localhost:5204/api/products \
  -H "Content-Type: application/json" \
  -d '{"name":"Phone","price":450000}'
```

Response:

```json
{ "id": 1, "name": "Phone", "price": 450000 }
```

## Running it locally

**Requirements:** .NET 10 SDK and PostgreSQL.

1. Clone the repo:
   ```bash
   git clone https://github.com/Toluwani2024/products-api.git
   cd products-api
   ```
2. Create a database named `productsdb` in PostgreSQL.
3. Check the connection string in `appsettings.json` and change the host or username if yours are different.
4. Create the tables:
   ```bash
   dotnet ef database update
   ```
5. Run the API:
   ```bash
   dotnet run
   ```
   It listens on `http://localhost:5204`.

## What's next

- Input validation and clearer error responses
- User authentication with JWT
- Orders and Paystack payment integration
- Deployment