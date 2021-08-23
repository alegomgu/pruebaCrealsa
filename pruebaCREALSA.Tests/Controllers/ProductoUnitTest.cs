using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using pruebaCREALSA;
using pruebaCREALSA.Controllers;
using System.Collections.Generic;
using System.Linq;
using System.Web.Http.Results;
using System.Net;
using System.Web.Http;

namespace pruebaCREALSA.Tests.Controllers
{
    [TestClass]
    public class ProductoUnitTest
    {

        [TestMethod]
        public void GetAllProducts()
        {
            // Disponer

            ProductoController controller = new ProductoController();
            // Actuar
            IEnumerable<pruebaCREALSA.Models.Producto> result = controller.GetProducto();

            // Declarar

            Assert.IsNotNull(result);
            Assert.AreEqual(4, result.Count());
        }

        // ACCION DEVUELVE OK CON CUERPO DE RESPUESTA

        [TestMethod]
        public void GetProduct_ShouldReturnProductWithSameID()
        {
            // Disponer
            ProductoController controller = new ProductoController();

            // Actuar
            var actionResult = controller.GetProducto(1) as OkNegotiatedContentResult<pruebaCREALSA.Models.Producto>;

            // Declarar
            Assert.IsNotNull(actionResult);
            Assert.IsNotNull(actionResult.Content);
            Assert.AreEqual(1, actionResult.Content.id);
        }


        [TestMethod]
        public void GetProduct_ShouldNotFindProduct()
        {
            ProductoController controller = new ProductoController();

            var result = controller.GetProducto(999);
            Assert.IsInstanceOfType(result, typeof(NotFoundResult));
        }


        [TestMethod]
        public void PostProductos_ShouldReturnSameProduct()
        {
            ProductoController controller = new ProductoController();

            var item = GetDemoProducto();

            var result =
                controller.PostProducto(item) as CreatedAtRouteNegotiatedContentResult<pruebaCREALSA.Models.Producto>;

            Assert.IsNotNull(result);
            Assert.AreEqual(result.RouteName, "DefaultApi");
            Assert.AreEqual(result.RouteValues["id"], result.Content.id);
            Assert.AreEqual(result.Content.nombre, item.nombre);
        }


        [TestMethod]
        public void PutProduct_ShouldFail_WhenDifferentID()
        {
            ProductoController controller = new ProductoController();

            var badresult = controller.PutProducto(999, GetDemoProducto());
            Assert.IsInstanceOfType(badresult, typeof(BadRequestResult));
        }


        [TestMethod]
        public void PutProduct_ShouldReturnStatusCode()
        {
            ProductoController controller = new ProductoController();

            var item = GetDemoProducto();

            var result = controller.PutProducto(item.id, item) as StatusCodeResult;
            Assert.IsNotNull(result);
            Assert.IsInstanceOfType(result, typeof(StatusCodeResult));
            Assert.AreEqual(HttpStatusCode.NoContent, result.StatusCode);
        }


        [TestMethod]
        public void DeleteReturnsOk()
        {
            // Arrange


            ProductoController controller = new ProductoController();

            // Act
            IHttpActionResult actionResult = controller.DeleteProducto(5);

            // Assert
            Assert.IsInstanceOfType(actionResult, typeof(OkNegotiatedContentResult<Models.Producto>));
        }



        Models.Producto GetDemoProducto()
        {
            Models.Categorias cat = new Models.Categorias() { id = 1, nombre = "INFORMATICA", descripcion = "Productos de informatica" };
            return new Models.Producto() { id = 2, nombre = "Demo producto", precio = 5, cantidad = 18,categoria_id = 1 ,Categorias = cat };
        }

    }
}
