# Ordering
Clean Architecture using DDD, CQRS, Mediator, Automapper, EF Core, Sql Server

## Ordering.API
This layer depends on both the Application and Infrastructure layers, however, the dependency on Infrastructure is only to support dependency injection. Therefore only Startup.cs should reference Infrastructure.


## Ordering.Infrastructure
This layer contains classes for accessing external resources such as file systems, web services, smtp, and so on. These classes should be based on interfaces defined within the application layer.
## Ordering.Application
This layer contains all application logic. It is dependent on the domain layer, but has no dependencies on any other layer or project. This layer defines interfaces that are implemented by outside layers. For example, if the application need to access a notification service, a new interface would be added to application and an implementation would be created within infrastructure.
## Ordering.Domain
This will contain all entities, enums, exceptions, interfaces, types and logic specific to the domain layer.

## References
- [Jason Taylor CA](https://www.youtube.com/watch?app=desktop&v=5OtUm1BLmG0mG0)
- [Gill Cleeren CA](https://www.pluralsight.com/courses/architecting-asp-dot-net-core-applications-best-practices)

## Helpful Cmdlets