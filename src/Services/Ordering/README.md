# Ordering
Clean Architecture using DDD, CQRS, Mediator, Automapper, EF Core, Sql Server

## Overview CA
With Clean Architecture, the **Domain** and **Application** layers are at the centre of the design. This is known as the **Core** of the system.

The **Domain** layer contains *enterprise logic* and *types* and the **Application** layer contains *business logic* and *types*. The difference is that *enterprise logic* could be *shared* across many systems, whereas the *business* logic will typically only be used within this system.

**Core** should not be dependent on **data access** and other **infrastructure** concerns so those dependencies are inverted. This is achieved by adding *interfaces* or *abstractions* within **Core** that are implemented by layers outside of **Core**. For example, if you wanted to implement the Repository pattern you would do so by adding an *interface* within **Core** and adding the implementation within **Infrastructure**.

All dependencies flow inwards and **Core** has no dependency on any other layer. **Infrastructure** and **Presentation** depend on **Core**, but not on one another.

![alt text](https://i0.wp.com/jasontaylor.dev/wp-content/uploads/2020/01/Figure-01-2.png?w=531&ssl=1)

## Ordering.API - Presentation
This layer depends on both the Application and Infrastructure layers, however, the dependency on Infrastructure is only to support dependency injection. Therefore only Startup.cs should reference Infrastructure.

`Ordering.API depends on Ordering.Application & Ordering.Infrastructure`


## Ordering.Infrastructure
This layer contains classes for accessing external resources such as file systems, web services, smtp, and so on. These classes should be based on interfaces defined within the application layer.

`Ordering.Infrastructure depends on Ordering.Application`

## Ordering.Application
This layer contains all application logic. It is dependent on the domain layer, but has no dependencies on any other layer or project. This layer defines interfaces that are implemented by outside layers. For example, if the application need to access a notification service, a new interface would be added to application and an implementation would be created within infrastructure.

`Ordering.Application depends on Ordering.Domain`

## Ordering.Domain
This will contain all entities, enums, exceptions, interfaces, types and logic specific to the domain layer.

`Has no dependencies 😜`

## MediatR and CQRS
![alt text](https://user-images.githubusercontent.com/69347197/149569560-63b0670d-3659-4cc0-9ed5-e7f479bf1ad9.png)

![alt text](https://user-images.githubusercontent.com/69347197/149571430-52177ec4-a7aa-431b-9bb7-c6f408a5e5b1.png)

- MediatR pipelines for Behaviours code
![alt text](https://www.google.com/url?sa=i&url=https%3A%2F%2Fwww.roundthecode.com%2Fdotnet%2Fhooking-into-mediator-pipelines&psig=AOvVaw0_sR3s5dXfLHOG-nHJQyNU&ust=1642283153854000&source=images&cd=vfe&ved=0CAsQjRxqFwoTCJCRh9ObsvUCFQAAAAAdAAAAABAg)


## References
- [Jason Taylor CA conference](https://www.youtube.com/watch?app=desktop&v=5OtUm1BLmG0mG0)
- [Jason Taylor CA](https://jasontaylor.dev/clean-architecture-getting-started/)
- [Gill Cleeren CA](https://www.pluralsight.com/courses/architecting-asp-dot-net-core-applications-best-practices)
-[VS Code add reference project](https://docs.microsoft.com/en-us/dotnet/core/tools/dotnet-add-reference)
- [ValueObject DDD](https://docs.microsoft.com/en-us/dotnet/standard/microservices-architecture/microservice-ddd-cqrs-patterns/implement-value-objects)

## Helpful Cmdlets
- `dotnet add ./Ordering.Application/Ordering.Application.csproj reference ./Ordering.Domain/Ordering.Domain.csproj`: add `Ordering.Domain.csproj` to `Ordering.Applicaiont.csproj`
- `dotnet ef migrations add InitialCreate --project ../Ordering.Infrastructure/Ordering.Infrastructure.csproj`: run this command from `Ordering.API` to generate a EF Migration in `Ordering.Infrastructure`.