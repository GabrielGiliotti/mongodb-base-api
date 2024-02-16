# mongodb-base-api

Default API for future implementations with MongoDB.

Using repository structure to separate different domains (for DDD implementations), used in the same context (as in UnitOfWork, but not yet implemented).

It is worth mentioning that DDD is a design that follows business rules in application development. Therefore, although there are some common structure for DDD, there is no single implementation for this design.

## Three Layers of DDD:

Application Layer: Depends on Domain-Model Layer and Infrastructure Layer. In this API, you can consider Controllers and Services as part of this layer.

Domain-Model Layer: It's a independent layer that defines the Business Models. DTOs are not part of this layer, because it's just a resource to map data input-Out the API.

Infrastructure: Depends on Domain-Model layer only. It's a layer responsible for set the Context of the different domains-models and work with data (comunication between API and Database). You can use this layer to set different contexts in the same API, but is not usual (In general, each API has you own context).

######################################################################################

## The motivating power of an interview gone wrong kkk

DEV does not live by practice alone.
The theoretical/conceptual part is also important.
Fundamentals matter to be able to communicate with DEVs and Non-DEVs.

The motivation for this section is because of an interview I did, where I "slipped" (not to mention I was terrible) in theoretical concepts related to TDD and DDD. Really theoretical concepts, and by the way very basic, that when it comes to changing and integrating APIs, we may not remember much because we are focused on making everything work.

### 1 - What is the difference between an Entity and a Value Object ?

Entities are domain objects that have a unique identity, independent of their attributes. An entity's state may change over time, but its identity remains the same. Entities are used to represent objects in the domain that have a continuous life cycle.

Ex: A user, identified by a unique user ID.

Value objects are immutable objects that represent specific attributes or properties in the domain. They are defined by their attributes, and two value objects are considered equal if their attributes are the same. They have no identity as they are determined only by their value.

Ex: An address, represented by street, city, state and zip code.

"Within a context (as DDD revolves around the context of the Domain), an Entity is defined by its mutability and unique identification, while the Value Object is defined by all its attributes, which must be immutable."

### 2 - What are the 3 pillars of DDD (Domain Design Driven) ?

The 3 pillars of DDD are ubiquitous language, bounded contexts and context maps.

Ubiquitous Language: is the set of terms and interrelations that provide the semantics of domain communication, which reflects the business vision.

In a way, we can say that they are the "jargon" or "terminology" used by non-DEVs (in this case, experts in the domain in which we are working) and that they should be used at the time of development. So when an entity, a value object or even methods and actions are going to be defined, we will use these terms so that everyone (DEVs and non-DEVs) can understand how the application reflects the business rule of that domain.

Bounded Contexts: delimitation of the different application contexts.

In this pillar, this is what the definition itself says. DEVs must, through a story or a description of actions that will be performed, separate the different contexts (within the application) so that methods and objects are separated and used in their specific contexts. This does not prevent interrelationships within the application, but helps in understanding and organizing the project for everyone.

Context maps: this is the mapping of Bounded Contexts.

As already described, the interrelationships between contexts. It is worth remembering that there are main, generic and auxiliary contexts, where the main contexts are the Core of the application, the generic contexts are those that can be common to more than a single context and the auxiliary contexts help with functionalities more related to the application's infrastructure, such as authentication and authorization (it is not a rule, but an example, and yes, there may be confusion in understanding between contexts).

### 3 - Name advantages and disadvantages of TDD (Test Driven Design).

Advantages:

* Design modularization;
* Less need for debugging;
* Clean code: promotes easy-to read and write code due to test orientation;
* Reduced refactoring time: easy to find bugs or problems;
* Code integrity: It is possible to test almost everything, making it easier to find breaks in changes;
* Documentation: everything up until then has been tested, including new features.

Disadvantages:

* Longer implementation time: due to the need to implement tests and the algorithm itself;
* Learning curve: It is not always clear where to start testing your application.
* The entire team must know how to do it or understand the need to do it, including non-DEVs;
* Refactoring the code implies refactoring the tests (Not always, but sometimes);
* Does not prevent bugs included in the tests themselves.