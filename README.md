# DogShelter

A simple CRUD of dogs that consumes a list of breeds from an external API.

The solution was structured with evolvability and scalability in mind. For challenge purposes, the persistence layer was implemented in memory.

The solution was implemented in two CQRS based microservices. One of them implements the authentication provider for the other one.

Both APIs are documented with swagger.


## Assumptions
Regarding the call of the external api (breeds), for simplicity it was assumed if there are more than 1 breed with a specific name, the first one should be returned.
