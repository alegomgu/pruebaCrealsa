# pruebaCrealsa
Proyecto de prueba MVC para CREALSA


Branchs GITHUB:

- MAIN: Proyecto principal vacio
- Version-servicios-web: Proyecto con controlador CRUD para el modelo Producto implementado
- Version-tests: Versión final con controlador CRUD y tests unitarios incluidos.

Contenido de las carpetas:

- pruebaCREALSA: Proyecto con los servicios web
- pruebaCREALSA.Tests: Test unitarios de los servicios
- resultados POSTMAN: Capturas de los resultados de invocar los servicios mediante POSTMAN. Captura de la ejecución de los tests unitarios.
- SCRIPT DB: Script sql para la generación y completado de la base de datos.

Las herramientas que he utilizado para la realización de la prueba son:

- Visual Studio 2019
- Entity Framework 6
- Microsoft Sql Server
- Microsoft Sql Server Managmenet Studio

Tests Unitarios:

- GetAllProducts: Chequea que se devuelven todos los productos de la tabla de la base de datos
- GetProduct_ShouldReturnProductWithSameID: Chequea que el producto que se devuelve se corresponde con el id pasado.
- GetProduct_ShouldNotFindProduct: Chequea que no se encuentra el producto correspondiente a un id pasado.
- PostProductos_ShouldReturnSameProduct: Chequea que se ha realizado correctamente la insercción de un nuevo producto.
- PutProduct_ShouldFail_WhenDifferentID: Chequea que falla al intentar actualizar un producto inexistente.
- PutProduct_ShouldReturnStatusCode: Chequea que se actualiza correctamente un producto.
- DeleteReturnsOk: Chequea que se elimina el producto indicado mediante el id pasado.

** NOTA: Por comodidad y falta de tiempo he incluido únicamente las tablas de producto y categorías, y el controlador para el modelo producto. Entiendo que para la base de datos del diagrama
se pueden obtener el resto de tablas y relaciones, definir vistas y por lo tanto implementar modelos, controladores y test unitarios para todos ellos, como comento más que por la complejidad es 
por la falta de tiempo por lo que he reducido el trabajo. 