using MvcApplication2.Models;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MvcApplication2.Controllers
{
    public class HomeController : Controller
    {
        private Repository db;


        public HomeController()
        {
            db = Repository.GetInstance();
        }
        //
        // GET: /Home/

        public ActionResult Index()
        {
            return RedirectToAction("Create");
        }


        [AcceptVerbs(HttpVerbs.Get)]
        public ActionResult Create()
        {
            return View(db.Movies);
        }

        [AcceptVerbs(HttpVerbs.Post)]
        public MyJsonResult Create(Movie newMovie)
        {
            db.Movies.Add(newMovie);
            return new MyJsonResult() { Data = newMovie };
        }


        public MyJsonResult Get()
        {
            return new MyJsonResult() { Data = new Movie() { Title = "Title", Director = "D", Released = DateTime.Now } };
        }

    }

    public class MyJsonResult : JsonResult
    {
        public object Data { get; set; }
        public override void ExecuteResult(ControllerContext context)
        {
            HttpResponseBase response = context.HttpContext.Response;
            response.ContentType = "application/json";
            if (ContentEncoding != null)
                response.ContentEncoding = ContentEncoding;
            if (Data != null)
            {
                JsonTextWriter writer = new JsonTextWriter(response.Output) { Formatting = Formatting.Indented };
                JsonSerializer serializer = JsonSerializer.Create(new JsonSerializerSettings());
                serializer.Converters.Add(new DateTimeJsonConverter());
                serializer.Serialize(writer, Data);
                writer.Flush();
            }
        }
    }

    public class DateTimeJsonConverter : DateTimeConverterBase
    {
        public DateTimeJsonConverter()
        {
            string x = "asdfsadf";
        }
        public override bool CanConvert(Type objectType)
        {
            return base.CanConvert(objectType);
        }

        public override object ReadJson(JsonReader reader, Type objectType, object existingValue, JsonSerializer serializer)
        {
            return null;
        }
        public override void WriteJson(JsonWriter writer, object value, JsonSerializer serializer)
        {
            if (value is DateTime)
            {
                DateTime date = (DateTime)value;
                writer.WriteValue(string.Format("{0}", date.ToString("dd/MM/yyyy HH:mm")));
            }

        }
    }


    public class Repository
    {
        private static Repository _database;
        public List<Movie> Movies { get; set; }
        private Repository()
        {
            this.Movies = new List<Movie>(){

                new  Movie() { Title = "Tris ton poutso klegane" , Director="Arxidas", Released= DateTime.Now},
            };
        }

        public static Repository GetInstance()
        {
            if (_database == null)
                _database = new Repository();



            return _database;
        }
    }
}
