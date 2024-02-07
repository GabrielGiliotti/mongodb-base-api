# mongodb-base-api

Default API for future implementations with MongoDB.

Using repository structure to separate different domains (for DDD implementations), used in the same context (as in UnitOfWork, but not yet implemented).

It is worth mentioning that DDD is a design that follows business rules in application development. Therefore, although there are some common structure for DDD, there is no single implementation for this design.

## Three Layers of DDD:

Application Layer: Depends on Domain-Model Layer and Infrastructure Layer. In this API, you can consider Controllers and Services as part of this layer.

Domain-Model Layer: It's a independent layer that defines the Business Models. DTOs are not part of this layer, because it's just a resource to map data input-Out the API.

Infrastructure: Depends on Domain-Model layer only. It's a layer responsible for set the Context of the different domains-models and work with data (comunication between API and Database). You can use this layer to set different contexts in the same API, but is not usual (In general, each API has you own context).