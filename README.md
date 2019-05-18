# Clean Data Driven Architecture
An alternate approach to the Clean Architecture design pattern implemented with .Net Core and Entity Framework Core

If you are unfamiliar with the concept of Clean Architecture you can [read about it here.](https://blog.cleancoder.com/uncle-bob/2012/08/13/the-clean-architecture.html)


## Project Structure

![Diagram of project architecture](https://i.imgur.com/A0COBsE.png)
### Core
#### The Domain Layer
The domain layer contains all entities, enums, exceptions, types and logic specific to the domain.
This is the core of the application and has no dependencies on the outer layers or any custom frameworks.
Neither business logic or persistence (database access) logic happens at this layer, only logic that is core to the domain entities
and represents enforced and consistent behaviour throughout your application.
This type of logic should be confined to the entity within which it is defined.

For example, the User entity has two methods `CreatePasswordHash(string password)` and `VerifyPasswordHash(string password)`.
These methods don't have any interaction with any objects outside of the User entity, they only work with properties within the class.

Similarly the Contact entiity has a `GetFullname()` method which has the same qualities.

This is the type of logic that belongs in the domain layer.



