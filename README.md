##Colegio Mundo Constructivo API 🏫
#La API de Colegio Mundo Constructivo es una aplicación ASP.NET Core que proporciona operaciones CRUD para estudiantes, profesores, cursos y calificaciones.

#🛠️ Tecnologías y herramientas utilizadas
ASP.NET Core: Un framework para construir aplicaciones web y servicios en .NET.
Entity Framework Core: Un ORM (Object-Relational Mapper) para .NET que se utiliza para interactuar con la base de datos.
AutoMapper: Una biblioteca .NET para mapear entre objetos.
JWT (JSON Web Tokens): Un estándar para autenticar y autorizar usuarios.
Swagger: Una herramienta para documentar y probar la API.
SQL Server: El sistema de gestión de bases de datos utilizado para almacenar los datos de la aplicación.

#📚 Tablas
La aplicación utiliza las siguientes tablas:

Students
Teachers
Courses
Grades
#🔐 Autenticación
La API utiliza JSON Web Tokens (JWT) para la autenticación. Los clientes deben enviar un token JWT válido en el encabezado Authorization de sus solicitudes HTTP.

#⚙️ Configuración
La configuración de la API se proporciona a través del archivo appsettings.json. Este archivo incluye configuraciones para la conexión a la base de datos, el registro, la autenticación JWT y las opciones de contraseñas.

#📡 Endpoints
La API expone endpoints para cada una de las tablas mencionadas anteriormente. Cada tabla tiene endpoints para operaciones CRUD, incluyendo:

GET /api/<table> para obtener una lista de todos los elementos en una tabla
GET /api/<table>/{id} para obtener un elemento específico por su ID
POST /api/<table> para crear un nuevo elemento
PUT /api/<table>/{id} para actualizar un elemento existente
DELETE /api/<table>/{id} para eliminar un elemento existente
Los endpoints de Students y Courses también soportan la paginación y el filtrado.
