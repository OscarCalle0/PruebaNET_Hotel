
# Products API with JWT Authentication

Esta API, construida con .NET, proporciona un conjunto de endpoints para gestionar productos. Utiliza autenticación JWT para garantizar que solo los usuarios autenticados puedan acceder a los recursos. La API está conectada a una base de datos MySQL, y se utilizan variables de entorno para la configuración.

## Características

- Operaciones CRUD (Crear, Leer, Actualizar, Eliminar) para productos.
- Autenticación y autorización usando JSON Web Tokens (JWT).
- Endpoints protegidos, accesibles solo para usuarios autenticados.
- Integración con Swagger para pruebas y exploración de la API.

## Requisitos

- .NET 8 SDK o superior.
- Servidor MySQL.
- Swagger está integrado, por lo que no se necesitan herramientas externas como Postman para probar la API.

## Variables de Entorno

Asegúrate de establecer las siguientes variables de entorno antes de ejecutar la aplicación:

```plaintext
DB_HOST=tu_host
DB_NAME=tu_nombre_de_base_de_datos
DB_PORT=tu_puerto
DB_USERNAME=tu_usuario
DB_PASSWORD=tu_contraseña

JWT_KEY=tu_clave_jwt
JWT_ISSUER=tu_emisor_jwt
JWT_AUDIENCE=tu_audiencia_jwt
JWT_EXPIRES_IN=tiempo_en_minutos
```

## Configuración del Proyecto

1. **Clona el repositorio:**
   ```bash
   git clone https://github.com/Riwi-io-Medellin/JWT-ProductManager.git
   cd JWT-ProductManager
   ```

2. **Restaura los paquetes NuGet:**
   Ejecuta el siguiente comando en el directorio del proyecto para restaurar los paquetes necesarios:
   ```bash
   dotnet restore
   ```

3. **Establece las variables de entorno:**
   Antes de ejecutar la aplicación, asegúrate de que las variables de entorno para la base de datos y JWT estén configuradas como se muestra arriba.

4. **Aplica las migraciones de la base de datos:**
   Ejecuta el siguiente comando para aplicar las migraciones y configurar las tablas de la base de datos:
   ```bash
   dotnet ef database update
   ```

5. **Ejecuta la API:**
   Inicia la API utilizando el siguiente comando:
   ```bash
   dotnet run
   ```

## Acceso a Swagger UI

Después de ejecutar la API, Swagger estará disponible en [https://localhost:5001/swagger](https://localhost:5001/swagger) o [http://localhost:5000/swagger](http://localhost:5000/swagger), donde podrás explorar y probar la API directamente.

## Autenticación JWT

Para acceder a los endpoints protegidos, primero necesitas autenticarte enviando una solicitud POST a `/api/v1/auth/login` con tus credenciales de usuario. El servidor devolverá un token JWT, que deberás incluir en los encabezados de las solicitudes subsiguientes:

```plaintext
Authorization: Bearer {tu-token-jwt}
```

### Ejemplo de Solicitud de Login

```http
POST /api/v1/auth/login HTTP/1.1
Host: localhost:5000
Content-Type: application/json

{
  "email": "tu_email@example.com",
  "password": "tu_contraseña"
}
```

### Ejemplo de Uso del Token

Una vez que tengas el token, puedes hacer una solicitud a un endpoint protegido como este:

```http
GET /api/v1/products HTTP/1.1
Host: localhost:5000
Authorization: Bearer {tu-token-jwt}
```

## Tecnologías Utilizadas

- ASP.NET Core 8
- Entity Framework Core
- JWT (JSON Web Tokens)
- Base de datos MySQL
- Swagger (para pruebas y documentación de la API)

## Contribuciones

Si deseas contribuir a este proyecto, por favor sigue los pasos de configuración y envía un pull request.

## Licencia

Este proyecto está bajo la Licencia MIT. Consulta el archivo [LICENSE](LICENSE) para más detalles.
```

### Notas Finales
- Asegúrate de que todas las rutas y detalles específicos sean correctos y reflejen tu implementación.
- Revisa y ajusta la sección de "Ejemplo de Solicitud de Login" y "Ejemplo de Uso del Token" según el formato que estés utilizando para tus solicitudes.
- Si hay información adicional que desees incluir, no dudes en hacerlo.
