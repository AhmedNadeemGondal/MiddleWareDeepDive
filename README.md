# MiddleWareDeepDive

## Purpose
This repository is dedicated to exploring the internal mechanics and implementation strategies of Middleware within the .NET ecosystem. The goal is to move beyond high-level abstractions and understand exactly how the request-response pipeline operates at a foundational level.

## Core Objectives
* **Logical Foundation:** Understanding the "root" logic of how the pipeline handles HTTP contexts.
* **Pattern Exploration:** Comparing convention-based vs. factory-based middleware implementations.
* **Practical Application:** Implementing cross-cutting concerns like global exception handling, custom logging, and request/response transformation.

## Key Concepts Covered
- **The Pipeline Flow:** Visualizing the bi-directional nature of middleware execution.
- **Short-circuiting:** Managing logic that prevents further middleware from executing.
- **Dependency Injection:** Managing lifetimes (Scoped, Transient, Singleton) within middleware components.

### Credits
Credit to **Frank Liu**. Check out his [video series](https://www.youtube.com/watch?v=F4dDe0SLjJM&list=PLgRlicSxjeMOXiYY7deqzO5qKdkg9wrqM&index=1&pp=iAQB) for the original walkthrough.