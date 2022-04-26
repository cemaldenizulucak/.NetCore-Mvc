using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using MvcOrnek.Models;
using MvcOrnek.Models.ViewModels;

namespace MvcOrnek.Controllers
{
    public class ProductController : Controller
    {
        // Action Türleri Dönüş Tipleri
        /*
            Bildiğimiz üzere clientten gelen requesti controller karşılayıp uygun actiona yönlendiriyordu.
            Actionda ihtiyaca göre operasyonu yönetiyordu 
            İşte bu durumlarda döndürülen dönen kısımların farklı türleri mevcut
            
         */
        #region ViewResult
        //public ViewResult GetProducts()
        //{
        //    // Response olarak bir view dosyasını(cshtml) render yapmamı sağlar.
        //    //ViewResult viewResult =View();
        //    //return viewResult;

        //}
        #endregion
        #region PartialViewResult

        //public PartialViewResult GetProducts()
        //{
        //// Diğeri bir bütün olarak web sayfasını ele alırken bunda belli bir kısım üzerinde işlem yapılıyor.
        //PartialViewResult partialViewResult =PartialView();
        //return partialViewResult;

        //}

        #endregion
        #region JsonResult

        //public JsonResult GetProducts()
        //{
        //    // üretilen datayı json türüne dönüştürüp döndüren bir action tipidir.
        //    JsonResult jsonResult = Json(new Product 
        //    { 
        //        Id=3,
        //        ProductName="Samsung",
        //        ProductPrice=6000
        //    });
        //    return jsonResult;
        //}

        #endregion
        #region EmptyResult

        //public EmptyResult GetProducts()
        //{
        //    return new EmptyResult();
        //}
        #endregion
        #region ContentResult
        //public ContentResult GetProducts()
        //{
        //    ContentResult contentResult = Content("Merhabalar Efenim...");
        //    return contentResult;
        //}
        #endregion
        #region ActionResult
        // Gelen isteğe göre geriye döndürülecek action türleri farklılık gösterdiğinde kullanılır.
        //public ActionResult GetProducts()
        //{
        //    if (true)
        //    {
        //        return Json(new object());
        //    }
        //    else if (false)
        //    {
        //        return Content("Merhaba");
        //    }
        //}
        #endregion

        /*
          NONACTİON - NONCONTROLLER KAVRAMLARI

        Kontrollerlar iş yapan değil yönetenlerdir.
        Actionlarda onların yardımcıları gibi çalışırlar.
        Onlarda iş yapmaz yönetirler(Servisleri çağırır yönlendirme yapar vb.)
        */


        #region ORNEK
        //public IActionResult Index()
        //{
        //    Y();
        //    return View();
        //}
        // NOT: Kontrollerlar sınıfın içindeki metodun türü ne olursa olsun actiondur.
        // Yani request karşılarlar.

        //[NonAction]
        //public void Y()
        //{

        //}

        //public IActionResult IndexTest()
        //{
        //    return View();
        //}


        #endregion


        // VİEW E VERİ TAŞIMA VE VERİ YAPILANMASI

        /*
             Css Html Js gibi yapılar evrenseldir.
             Ancak cshtml dosyaları sadece bu teknolojiye özeldir vekullanıcı bunu html olarak görür.
             
         */

        public IActionResult Index()
        {
            var products = new List<Product>
            {
                new Product
                {
                    Id=1,
                    ProductName="Iphone",
                    ProductPrice=8000
                },
                 new Product
                {
                    Id=2,
                    ProductName="Samsung",
                    ProductPrice=600
                },
                  new Product
                {
                    Id=4,
                    ProductName="Vestel",
                    ProductPrice=5000
                }
            };


            #region MODEL ESASLI VERİ GÖNDERİMİ
            // return View(products);
            #endregion

            #region VİEWBAG
            //Taşınacak olan veriyi sistamatik bir şekilde taşımamızı sağlayan kontroldür(değişkenle).
            //ViewBag.products = products;
            #endregion

            #region VİEWDATA
            // Bu kontrolde viewbag de olduğu gibi veri taşımamızı sağlar
            ViewData["products"] = products;
            #endregion

            #region TEMPDATA
            // Buda bir çeşit veri taşıma kontrolüdür.
            TempData["products"] = products;


            #endregion
            return View();
        }


        /*VİEWE BİRDEN FAZLA VERİ GÖNDERİMİ*/
        public IActionResult GetProducts()
        {
            Product product = new Product()
            {
                Id = 5,
                ProductName="Alcatel",
                ProductPrice=3000
            };
            Category category = new Category()
            {
                catID =5,
                catName = "Telefonlar"
            };


            CategoryProduct categoryProduct = new CategoryProduct()
            {
                Category = category,
                Product = product
            };

            return View(categoryProduct);
        }
    }
}
