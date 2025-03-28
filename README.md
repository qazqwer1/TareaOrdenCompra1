# Tarea Técnica - API REST .NET 7 🧩

Este proyecto implementa una API REST desarrollada en .NET 7 que gestiona un sistema de órdenes de compra.  
Incluye operaciones CRUD sobre órdenes y productos, junto con validaciones, descuentos automáticos y pruebas unitarias con xUnit y Moq.

---

##  Requisitos

- .NET 7 SDK
- SQL Server local
- Visual Studio o VS Code
- EF Core CLI (`dotnet ef`)
- (Opcional) Postman o Swagger para probar

---

##  Tecnologías Usadas

- ASP.NET Core 7 (Web API)
- Entity Framework Core
- SQL Server
- Swagger (Swashbuckle)
- xUnit + Moq (pruebas unitarias)

---

##  Endpoints disponibles

### 🛒 Ordenes
- `POST /api/ordenes` → Crear orden de compra con productos
- `GET /api/ordenes` → Listar órdenes (con paginación `?page=1&pageSize=10`)
- `GET /api/ordenes/{id}` → Obtener orden específica
- `PUT /api/ordenes/{id}` → Editar orden
- `DELETE /api/ordenes/{id}` → Eliminar orden

###  Productos
- `POST /api/productos` → Crear producto
- `GET /api/productos` → Listar productos

---

##  Descuento automático

La lógica aplica descuentos en las órdenes:

-  **10%** si el total supera **$500**
-  **5%** si la cantidad de productos supera **5**
-  Sin descuento si no cumple ninguna condición

---

## Para generar base de datos
dotnet ef migrations add NombreDeLaMigracion
dotnet ef database update

---
##  Pruebas unitarias

- Se implementan con `xUnit` y `Moq`
- Cubren la lógica de descuentos y creación de órdenes
- Ejecutar con:

```bash
dotnet test

##
## Realizado Por Giovanni Fernández Quezada 18.784.154-2. 3/28/2025.


