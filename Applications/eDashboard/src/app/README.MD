# structure

1. App Structure
    - [modules](#Modules)
        - dashboard
            - layout
                - main-dashboard (layout)
            - components
            - pages
                - takttime
        - private
            - layout
                - private (layout)
            - components
                - private-header
                - private-sidebar
                - private-side-overlay
            - pages
                - materials
                    - materials-serialized
                - orders
                    - order-prioritize
                    - order-tracking
                    - order-tracking-summary
                - overview
                - shopfloor
                    - sub-assembly-validation
        - public
            - layout
                - public (layout)
            - components
            - pages
                - authentication
                - site
                - versions

    - [core](#Core)
        - authentication
        - guards
        - http
        - interceptors
        - mocks
        - services
            - security
    - [shared](#Shared)
        - componenets
            - errors
            - footer
        - directives
        - pipes
        - models
    - [config](#Config)

## App Structure

This has the purpose to have a clear way to put our code into the project in basis to best practices in Angular projects

### Modules

Every Module has logic, pages and components by separated. It's perfect for scaling the application

#### Dasboard

Dedicated to dashboard applications

#### Private

For CTO Back End

##### Layout

Just if it is necessary

##### Componets

Componenets for this module

##### Pages

Every module should has a one page

###### componenet (layout)

Every module should has a layout

##### Public

Dedicated for public site

### Core

The CoreModule should contain singleton services (which is usually the case), universal components and other features where there’s only once instance per application. To prevent re-importing the core module elsewhere

#### Guards

The guards folder contains all of the guards I use to protect different routes in my applications.

#### Mocks

Mocks are specially useful for testing, but you can also use them to retrieve fictional data until the back-end is set up. The mocks folder contains all the mock-files of our app.

#### Authentication

The authentication folder simply handles the authentication-cycle of the user (from login to logout).

#### Http

The http folder handles stuff like http calls from our application. I’ve also added a api.service.ts file to keep all http calls running through our application in one single place. The folder does otherwise contain folders for interacting with the different API-routes.

#### Interceptors

Angular > 4.x  introduced a long-awaited feature for handling http requests — the HttpInterceptor interface. This allows us to catch and modify the requests and responses from our API calls. The interceptors folder is a collection of interceptors

#### services

All additional singleton services are placed in the services folder.

##### security

There are several security functionalities

### Shared

The SharedModule is where any shared components, pipes/filters and services should go. The SharedModule can be imported in any other module when those items will be re-used. The shared module shouldn’t have any dependency to the rest of the application and should therefore not rely on any other module.

#### Components

The components folder contains all the “shared” components. This are components like loaders and buttons , which multiple components would benefit from.

#### Directives

1. Components—directives with a template.
2. Structural directives—change the DOM layout by adding and removing DOM elements.
3. Attribute directives—change the appearance or behavior of an element, component, or another directive.

Components are the most common of the three directives. You saw a component for the first time in the Getting Started.

Structural Directives change the structure of the view. Two examples are NgFor and NgIf. Learn about them in the Structural Directives guide.

Attribute directives are used as attributes of elements. The built-in NgStyle directive in the Template Syntax guide, for example, can change several element styles at the same time.

#### Pipelines

A pipe takes in data as input and transforms it to a desired output. In this page, you'll use pipes to transform a component's birthday property into a human-friendly date.

#### (Models)

### Config

The config folder contains app settings and other predefined values.

## Sources

[How to define a highly scalable folder structure for your Angular project](https://itnext.io/choosing-a-highly-scalable-folder-structure-in-angular-d987de65ec7)

[Editor.md](https://pandao.github.io/editor.md/en.html#Core)

## Designed by

## Luis Raúl Espinoza Barboza

[Github](https://github.com/lreb)
[Email](luis_espinoza6@jabil.com)
[LinkedIn](https://linkedin.com/in/luis-raúl-espinoza-barboza-5b767751/)