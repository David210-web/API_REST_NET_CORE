# Mi API REST

Esta es una api rest de un sistema de biblioteca hecho con asp.net core y sql server
esta api esta hecha con principios solid, y utiliza las bibliotecas de swagger (para la documentacion de la api),
fluentValidation (para la validacion de datos), Automapper (para el mapeo de datos), aparte de eso se utilizo 
el orm de entity framework

- Usuarios
- Categorias
- Autores
- Libros
- Prestamos

Los endpoints de la api son

Usuarios:
-GET: https://localhost:7039/api/Autores
-GET: https://localhost:7039/api/Autores/{id}
-POST: https://localhost:7039/api/Autores
-PUT: https://localhost:7039/api/Autores{id}
-DELETE: https://localhost:7039/api/Autores/{id}

Categoria:
-GET: https://localhost:7039/api/Categoria
-GET: https://localhost:7039/api/Categoria/{id}
-POST: https://localhost:7039/api/Categoria
-PUT: https://localhost:7039/api/Categoria/{id}
-DELETE: https://localhost:7039/api/Categoria/{id}

Libros:
-GET: https://localhost:7039/api/Libros
-GET: https://localhost:7039/api/Libros/{id}
-GET: https://localhost:7039/api/Libros/categoria/{id} #Obtener los libros por categorias
-GET: https://localhost:7039/api/Libros/autor/{id} #Obtener los libros por su actor
-POST: https://localhost:7039/api/Libros
-PUT: https://localhost:7039/api/Libros/{id}
-DELETE: https://localhost:7039/api/Libros/{id}

Prestamos:
-GET: https://localhost:7039/api/Prestamos
-GET: https://localhost:7039/api/Prestamos/{id}
-POST: https://localhost:7039/api/Prestamos
-PUT: https://localhost:7039/api/Prestamos/{id}
-DELETE: https://localhost:7039/api/Prestamos/{id}

Usuarios: 
-GET: https://localhost:7039/api/Usuario
-GET: https://localhost:7039/api/Usuario/{id}
-POST: https://localhost:7039/api/Usuario
-PUT: https://localhost:7039/api/Usuario/{id}
-DELTE: https://localhost:7039/api/Usuario/{id}
