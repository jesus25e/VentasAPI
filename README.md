# InventoryAPI

REST API para la gestión de inventario desarrollada con **ASP.NET Core**, siguiendo principios de arquitectura limpia y buenas prácticas de desarrollo backend.

El proyecto fue creado como parte de mi proceso de aprendizaje y evolución como desarrollador, implementando progresivamente diferentes patrones y tecnologías utilizadas en aplicaciones empresariales.

## 🚀 Tecnologías utilizadas

* **.NET / ASP.NET Core**
* **C#**
* **Entity Framework Core**
* **SQL Server / PostgreSQL**
* **JWT Authentication**
* **Swagger / OpenAPI**
* **MediatR**
* **CQRS**
* **Repository Pattern**
* **Unit of Work**
* **FluentValidation**
* **Serilog**

## 🏗️ Arquitectura

El proyecto utiliza un enfoque basado en **Clean Architecture**, buscando separar las responsabilidades de cada componente y reducir el acoplamiento entre las diferentes capas.

```text
InventoryAPI
│
├── Inventory.Domain
│   └── Entidades y reglas de negocio
│
├── Inventory.Application
│   └── Casos de uso, DTOs, CQRS e interfaces
│
├── Inventory.Infrastructure
│   └── Persistencia, Entity Framework e implementaciones
│
└── Inventory.API
    └── Endpoints, configuración y middleware
```

Esta estructura permite mantener una separación clara entre la lógica de negocio, los casos de uso, la infraestructura y la exposición de la API.

## 🔐 Autenticación y seguridad

La API incorpora autenticación mediante **JWT (JSON Web Tokens)** para proteger los recursos que requieren autorización.

Entre las funcionalidades implementadas se encuentran:

* Registro de usuarios.
* Inicio de sesión.
* Autenticación mediante JWT.
* Manejo de roles y permisos.
* Refresh Tokens.
* Cierre de sesión.
* Protección de endpoints mediante autorización.

## 📦 Funcionalidades principales

El sistema permite administrar diferentes elementos relacionados con un inventario:

* Gestión de productos.
* Gestión de categorías.
* Gestión de tiendas.
* Creación, consulta, actualización y eliminación de registros.
* Validación de datos.
* Manejo centralizado de excepciones.
* Paginación y filtros.
* Documentación de endpoints mediante Swagger.

## 🧩 Patrones y principios

Durante el desarrollo se aplicaron diferentes conceptos de ingeniería de software:

* **Clean Architecture**
* **CQRS**
* **Repository Pattern**
* **Unit of Work**
* **Dependency Injection**
* **SOLID**
* **DTOs**
* **MediatR**
* **Pipeline Behaviors**
* **Validación mediante FluentValidation**

El objetivo no fue únicamente construir una API funcional, sino también mantener una estructura organizada y preparada para futuras mejoras.

## 📖 Documentación de la API

El proyecto utiliza **Swagger/OpenAPI** para facilitar la exploración y prueba de los diferentes endpoints disponibles.

Una vez ejecutada la aplicación, Swagger permite consultar los recursos disponibles, revisar los modelos utilizados y realizar pruebas directamente desde la interfaz web.

## ⚙️ Configuración

Para ejecutar el proyecto localmente:

### 1. Clonar el repositorio

```bash
git clone https://github.com/tu-usuario/InventoryAPI.git
cd InventoryAPI
```

### 2. Configurar la base de datos

Actualizar la cadena de conexión en `appsettings.json` o mediante variables de entorno.

```json
{
  "ConnectionStrings": {
    "DefaultConnection": "TU_CONNECTION_STRING"
  }
}
```

### 3. Aplicar las migraciones

```bash
dotnet ef database update
```

### 4. Ejecutar el proyecto

```bash
dotnet run
```

Después de iniciar la aplicación, se puede acceder a Swagger desde la URL configurada por el proyecto.

## 🎯 Objetivo del proyecto

InventoryAPI representa una etapa inicial de mi aprendizaje y evolución en el desarrollo de aplicaciones backend con **.NET**.

El proyecto me permitió trabajar de manera práctica con conceptos como arquitectura limpia, autenticación, persistencia de datos, patrones de diseño y construcción de APIs REST.

A partir de esta experiencia, el proyecto sirve como base para continuar explorando arquitecturas más avanzadas, escalabilidad, multi-tenancy, pruebas automatizadas, Docker y otras prácticas utilizadas en aplicaciones empresariales.

## 🔮 Próximas mejoras

Algunas funcionalidades que pueden incorporarse en futuras versiones:

* [ ] Multi-tenancy
* [ ] Dockerización
* [ ] Pruebas unitarias e integración
* [ ] Rate Limiting
* [ ] Caché
* [ ] Auditoría de operaciones
* [ ] Mejoras en observabilidad
* [ ] CI/CD
* [ ] Despliegue en la nube

## 👨‍💻 Autor

**Jesús**

Estudiante de Ingeniería Informática interesado en el desarrollo de software, backend, bases de datos y arquitectura de aplicaciones.

Este proyecto forma parte de mi portafolio y representa mi proceso de aprendizaje y crecimiento en el desarrollo backend con .NET.
