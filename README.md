# Simple .NET Web API Example

Минимальное API на .NET 8, содержащее:

- `/health` — проверка состояния приложения и подключения к базе данных  
- `/hello` — вывод `"Hello, world!"` в JSON  
- `GET /user/{id}` — получение пользователя по ID  
- `POST /user` — создание пользователя  
- Миграции EF Core для PostgreSQL

## 📦 Требования

- .NET 8 SDK
- PostgreSQL
- EF Core CLI:
  ```bash
  dotnet tool install --global dotnet-ef
  ```

## 🛠 Переменные окружения

Перед запуском необходимо задать параметры подключения:

```bash
export DB_HOST=localhost
export DB_PORT=5432
export DB_USER=postgres
export DB_PASSWORD=postgres
export DB_NAME=testdb
```

## 🗄 Миграции

Создать миграцию:

```bash
dotnet ef migrations add InitialCreate
```

Применить миграцию:

```bash
dotnet ef database update
```

## 🚀 Запуск приложения

```bash
dotnet run
```

Сервер будет доступен по адресу:

```
http://localhost:5000
```

## 📚 Примеры запросов

### Healthcheck
```
GET /health
```

### Hello
```
GET /hello
```

### Получить пользователя
```
GET /user/1
```

### Создать пользователя
```
POST /user
Content-Type: application/json

{
  "name": "Alex",
  "email": "alex@example.com"
}
```

## 🧩 Зависимости

- Microsoft.EntityFrameworkCore
- Microsoft.EntityFrameworkCore.Design
- Npgsql.EntityFrameworkCore.PostgreSQL

Установка:

```bash
dotnet restore
```