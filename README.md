# PlanProject

Resumen del repositorio y notas rápidas.

## Descripción
Proyecto `PlanProject` — aplicación relacionada con gestión hospitalaria.

## Lo que hice esta semana
- Implementé la validación en `Appointment` para lanzar `ArgumentException` cuando `EndAt <= StartAt`.
- Añadí tests unitarios en `Test.Domain.Tests/Tests/AppointmentTests.cs` para asegurar esa validación.
- Configuré el proyecto de tests (`Test.Domain.Tests`) añadiendo referencias a `xUnit` y `Microsoft.NET.Test.Sdk` y la referencia de proyecto al dominio.

##Segunda semana
Resumen: En la Semana 2 se reforzó la capa de dominio: se añadieron value objects, se refactorizaron las entidades para usar un AuditableEntity, se implementó el servicio de dominio SchedulingPolicy y se cubrieron las reglas críticas con pruebas unitarias.

Qué se hizo

Auditable base: AuditableEntity con CreatedBy y CreatedDate.

Value objects: Email y PhoneNumber con validaciones.

Entidades refactorizadas: Patient, Doctor, Appointment, MedicalRecord, Department usando los value objects y heredando de AuditableEntity.

Reglas e invariantes: validaciones en constructores (p. ej., EndAt > StartAt, DOB no en el futuro, Ids requeridos).

Domain service: SchedulingPolicy que valida solapamientos y aplica buffer por doctor.

Tests: xUnit en tests/Domain.Tests cubriendo creación de entidades, invariantes y reglas de scheduling.

Archivos clave y rutas

src/core/domain/Entities/* — entidades y AuditableEntity

src/core/domain/ValueObjects/* — Email.cs, PhoneNumber.cs

src/core/domain/Services/SchedulingPolicy.cs

tests/Domain.Tests/* — pruebas unitarias





