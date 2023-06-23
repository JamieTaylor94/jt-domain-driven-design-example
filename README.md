# jt-domain-driven-design-example (incomplete)

The purpose of this repository is to serve as a personal reference for implementing a basic structure of Domain-Driven Design (DDD) and hexagonal architecture.

Most of this is just my opinion at the time of writing and is likely not 100% correct and I generated the benefits and drawbacks. I will also use rocket league concepts for this just for fun.

## Domain

In the domain layer, we focus on the core business logic. In this example, we have a central concept called "Vehicle," representing a route object within the vehicle domain. The Vehicle object is designed to be unchangeable and can only be created internally using a specific method.

## Application

The application layer is the core of the system and contains various application services, such as handlers. These handlers interact with secondary services in the Infrastructure layer. We also use Data Transfer Objects (DTOs) in this layer to communicate between different parts of the system. These DTOs help us protect our internal business logic from external influences. We also use mappers to convert data between different formats in this layer.

## Infrastructure

The infrastructure layer includes all the external components and services used by our application. This includes databases, message queues, file systems, and external services. Interfaces belong in the domain layer so that we can switch out underlying services from the infrastructure layer.

## Presentation

The presentation layer is responsible for interacting with the main application. In this repository, we provide an example of an API controller that directly calls the corresponding handler. The presentation layer should not have direct access to the business logic in the domain layer. Instead, it communicates with the application layer, which acts as a bridge between the presentation layer and the domain layer.

## Benefits of Domain-Driven Design

Domain-Driven Design offers several advantages, including:

1. **Modularity**: DDD promotes a modular architecture that makes it easier to maintain, test, and scale the application.
2. **Domain-Focused Design**: DDD helps ensure that the software accurately reflects the real-world problem domain by focusing on the core concepts.
3. **Improved Collaboration**: DDD encourages collaboration between domain experts, developers, and stakeholders, leading to a shared understanding of the problem domain.
4. **Flexible and Evolvable**: DDD supports flexibility and adaptability in software systems, allowing for easier refactoring and extension as requirements change.
5. **Clear Separation of Concerns**: DDD separates business logic from infrastructure-related code, improving code organization and making the system easier to understand and maintain.

## Drawbacks of Domain-Driven Design

While Domain-Driven Design offers numerous benefits, it's important to be aware of potential drawbacks, including:

1. **Complexity**: Implementing DDD can introduce additional complexity, especially in large-scale projects, requiring a solid understanding and expertise.
2. **Learning Curve**: Developers new to DDD may face a learning curve, as it requires a different approach to software design.
3. **Increased Development Time**: DDD emphasises analysis, modelling, and collaboration, which may extend the development timeline.
4. **Team Skill Set**: Adopting DDD may require acquiring new skills and knowledge within the development team.
5. **Over-Engineering**: Without careful consideration, DDD can lead to over-engineering, resulting in unnecessary complexity.

## Useful resources

[Herberto Graca](https://herbertograca.com/2017/11/16/explicit-architecture-01-ddd-hexagonal-onion-clean-cqrs-how-i-put-it-all-together/)
