# DogShelter

### The solution was structured with evolvability and scalability in mind. For challenge purposes, the persistence layer was implemented in memory.
### The structure of this solution is Clean Architecture based, in which on the external layers we have the Presentation and Infrastructure layer, in the middle the Application layer and inside the Domain layer.
### The stateless system design and the abstraction provided by the application layer enables us to easily plug in a different frontend, API, etc. without the need to change the core application and domain models. Same if we want to move into a different data storage.
### The Application layer is being used like an orchestrator between layers and the Domain is responsible for the business rules. Despite the low number of business rules for this case, this approach was used thinking in scalability (if the dog shelter rules become more and more complex)

### Taking into account this is a challenge some unit tests were made to cover the dog filtering feature.

## Assumptions
### Regarding the call of the external api (breeds), for simplicity it was assumed if there are more than 1 breed with a specific name, the first one should be returned.
### We can combine multiple filters to filter dogs (Size and Breed and Temperament)
