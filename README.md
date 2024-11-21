# PT.Dasigno
Prueba técnica Dasigno Web API .Net 8

# Proyecto Dasigno

Este proyecto es una API para la gestión de usuarios, incluyendo funcionalidades como creación, actualización, búsqueda y paginación de usuarios.

## Descripción

La solución incluye la implementación de un método protegido en la clase `GenericRepository` para obtener el `DbContext`. Este método facilita el acceso al contexto de la base de datos dentro de las clases derivadas.

## Implementación

El método `GetContext` está definido en la clase `GenericRepository` dentro del archivo `GenericRepository.cs`. Este método devuelve una instancia del `DbContext` utilizado por el repositorio.

### Patrones de Diseño Implementados
En la solución se han implementado varios patrones de diseño que ayudan a mejorar la mantenibilidad, escalabilidad y testabilidad del código. A continuación se describen los patrones utilizados:
#### 1. Repository Pattern (Patrón de Repositorio)
El patrón de repositorio se utiliza para abstraer la lógica de acceso a datos y proporcionar una interfaz para realizar operaciones CRUD. Esto se puede ver en las interfaces y clases de repositorio:
- **Interfaces**: IUsersRepository, IGenericRepository
- **Implementaciones**: UsersRepository, GenericRepository
  
#### 2. Unit of Work Pattern (Patrón de Unidad de Trabajo)
El patrón de Unidad de Trabajo se utiliza para agrupar operaciones que deben ser tratadas como una única transacción. Esto se puede ver en la interfaz IUnitOfWork y su implementación.

#### 3. Dependency Injection (Inyección de Dependencias)
La inyección de dependencias se utiliza para gestionar las dependencias entre objetos y promover la inversión de control. Esto se puede ver en la forma en que los servicios y repositorios se inyectan en los controladores y otros servicios.

#### 4. DTO (Data Transfer Object) Pattern
El patrón DTO se utiliza para transferir datos entre capas de la aplicación. Esto se puede ver en las clases UserDto y las solicitudes de creación y actualización de usuarios.

### Resumen
En resumen, los patrones de diseño implementados en la solución incluyen:
- **1.	Repository Pattern**: Para abstraer la lógica de acceso a datos.
- **2.	Unit of Work Pattern**: Para agrupar operaciones en una única transacción.
- **3.	Dependency Injection**: Para gestionar dependencias y promover la inversión de control.
- **4.	DTO Pattern**: Para transferir datos entre capas de la aplicación.

### Beneficios

- **Encapsulación**: El método `GetContext` encapsula el acceso al `DbContext`, lo que mejora la mantenibilidad del código.
- **Reutilización**: Facilita la reutilización del código al proporcionar un acceso centralizado al `DbContext`.
- **Flexibilidad**: Permite realizar consultas personalizadas y otras operaciones específicas de la base de datos dentro de los repositorios.

## Contribuciones

Si deseas contribuir a este proyecto, por favor sigue los pasos descritos a continuación:

1. Haz un fork del repositorio.
2. Crea una nueva rama (`git checkout -b feature/nueva-funcionalidad`).
3. Realiza los cambios necesarios y haz commit (`git commit -am 'Añadir nueva funcionalidad'`).
4. Sube los cambios a tu fork (`git push origin feature/nueva-funcionalidad`).
5. Abre un Pull Request en el repositorio original.


