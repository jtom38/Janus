# Janus

## Requirements

* .Net Core 2.1

## Personal Notes

## Application Layers

1. Domain - Core

This is the layer for things like entities, types, enum, exceptions
No running code exists here.
Depends on:

* Nothing

2. Application Layer - Business Logic

This layer contains all application logic. It is dependent on the domain layer, but has no dependencies on any other layer or project.
This layer defines interfaces that are implemented by outside layers. 
For example, if the application need to access a notification service, a new interface would be added to application and an implementation would be created within infrastructure.
Depends on:

* Domain
* Persistence

3. Infrastructure Layer - Service Layer

This layer contains classes for accessing external resources such as file systems, web services, smtp, and so on.
These classes should be based on interfaces defined within the application layer
This will implament the interfaces we defined in Domain/Core
Depends on:

* Application

4. Persistence Layer - Database

This layer contains the interaction to the DB.
Depends on:

* Domain

5. Presentation Layer - UI/Console/Desktop Interfaces

This layer is the interface that the end user interacts with.
The thought is if you make a change to the UI the layers below will still support that new UI given the logic exists in other places.
Depends on:

* Application
* Infrastructure
