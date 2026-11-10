# EmployeeManagement — Domain & Unit Tests

Proyecto de aprendizaje de **C# y modelado de dominio** para gestión de empleados. Su alcance actual es intencionalmente pequeño: entidades y pruebas de reglas de negocio.

## Estado real

Este repositorio contiene:

- `EmployeeManagement.Domain`: entidades `Empleado`, `Departamento` y `Cargo`.
- `EmployeeManagement.UnitTests`: pruebas unitarias de `Empleado` con xUnit.
- `EmployeeManagement.slnx`: solución .NET.

**No incluye todavía una Web API, frontend React, base de datos ni despliegue.** Es una base de dominio, no un sistema empresarial completo.

## Ejecutar pruebas

Instala el SDK .NET correspondiente al `TargetFramework` de los proyectos y ejecuta desde la raíz:

```powershell
dotnet restore EmployeeManagement.slnx
dotnet build EmployeeManagement.slnx
dotnet test EmployeeManagement.slnx
```

## Objetivo de aprendizaje

Practicar invariantes del dominio, validaciones, diseño orientado a objetos y pruebas unitarias antes de agregar persistencia y HTTP.

**Autor:** José Ignacio Suero.
