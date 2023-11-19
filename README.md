# Formula One API

This is a hobby project used to explore .NET 8

## Pull changes from database

dotnet ef dbcontext scaffold "Host=;Port=;Database=;Username=;Password=;" -o Models/EDMs Npgsql.EntityFrameworkCore.PostgreSQL