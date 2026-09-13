# Monat.Guard

Simple and lightweight guard clauses for .NET applications.

## Installation

```bash

dotnet add package Monat.Guard

```

You can also install it via NuGet Package Manager:


## Usage

```csharp

using Monat.Guard;

Guard.NotNull(user);

Guard.NotNullOrWhiteSpace(name);

Guard.NotEmpty(userId);

Guard.Positive(age);

Guard.NotNegative(price);

Guard.NotDefault(orderId);

Guard.InRange(page, 1, 100);

Guard.NotNullOrEmpty(items);

```

## Available Guards

| Method                | Description                                     |
| --------------------- | ----------------------------------------------- |
| `NotNull`             | Ensures a value is not null                     |
| `NotNullOrWhiteSpace` | Ensures a string contains a value               |
| `NotEmpty`            | Ensures a Guid is not empty                     |
| `Positive`            | Ensures an integer is greater than zero         |
| `NotNegative`         | Ensures a decimal is not negative               |
| `NotDefault`          | Ensures a value is not its default value        |
| `InRange`             | Ensures an integer is within a range            |
| `NotNullOrEmpty`      | Ensures a collection contains at least one item |

## License

MIT

