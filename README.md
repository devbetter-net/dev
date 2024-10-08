# Dev Software Architecture

## Overview

This architecture follows a **modular approach** where different features or functionalities are packaged into independent **plugins**. Each plugin has its own API Controller, Blazor Components, and follows the **CQRS (Command Query Responsibility Segregation)** pattern. 

### Key Components:
1. **Dev.WebHost**: 
   - The main **Web Host** responsible for hosting the web application.
   - It **dynamically loads plugins** and integrates their functionalities into the main application.
   - Use `useModules` to manage plugins.

2. **Plugins**: 
   - Each feature or module is encapsulated as a plugin.
   - A plugin contains:
     - **API Controller**: Handles HTTP requests.
     - **Blazor Components**: Frontend UI components rendered using Blazor.
     - **CQRS Handlers**: Implements the separation of command and query responsibilities.
     - **DbContext & Connection String**: Each plugin has its own database context, allowing them to use a separate **Connection String** for data access.

3. **Plugin Example: `Dev.Plugin.Blog`**
   - This plugin provides blogging functionality.
   - It contains:
     - **API Controller**: Exposes endpoints for managing blog posts.
     - **Blazor Components**: Renders the UI for blog creation, editing, and viewing.
     - **CQRS**: Manages the flow of data through commands (to update) and queries (to read).
     - **DbContext**: Isolated database context for blog-related data.

## Technologies Used
- **Blazor**: For building interactive web UI with C#.
- **Entity Framework Core**: For interacting with the database.
- **CQRS Pattern**: To separate command and query logic.
- **ASP.NET Core Web API**: For API Controllers.

## Data Flow
1. The **Blazor Components** in each plugin interact with their **API Controllers**.
2. The API Controllers then utilize the plugin-specific **DbContext** to query or update the database.
3. **CQRS** separates read and write operations, improving scalability and maintainability.

## Independent Plugin Development
- Plugins such as `Dev.Plugin.Blog` are developed almost **independently**, ensuring **modularity** and **flexibility**.
- Each plugin can be added or removed without major changes to the `Dev.WebHost`.
- The `DbContext` per plugin ensures that each module can have its own **database schema** and connection logic.

## Architecture Diagram
Below is a conceptual diagram of this architecture:

### Modular Architecture Diagram
```
+------------------------------------------------+
|                  Dev.WebHost                   |
|                                                |
|   +----------------------+   +---------------+|
|   | Dev.Plugin.Blog       |   | Dev.Plugin.X  ||
|   | API, Blazor, DbContext|   | API, Blazor   ||
|   +----------------------+   +---------------+|
|                                                |
+------------------------------------------------+
```

1. **Dev.WebHost** dynamically loads the plugins.
2. Each **Plugin** has its own API, Blazor UI, CQRS handlers, and DbContext.
3. The plugins interact with their own databases via Entity Framework Core, keeping data isolated.

