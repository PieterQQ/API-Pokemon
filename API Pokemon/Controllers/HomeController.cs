using API_Pokemon.Models;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Web;
using System.Web.Mvc;

namespace API_Pokemon.Controllers
{
    public class HomeController : Controller
    {

        public static int page = 8;
        public ActionResult Index()
        {
            page += 8;
            ViewBag.Name = page;
           try {

                WebClient wc = new WebClient();
                var url = "https://api.pokemontcg.io/v1/cards";

                string pokemonstring= wc.DownloadString(url);
          
                byte[] bytes = Encoding.Default.GetBytes(pokemonstring);
                 pokemonstring=Encoding.UTF8.GetString(bytes);
                RootObject datalist = JsonConvert.DeserializeObject<RootObject>(pokemonstring);
               
                return View(datalist);
            }
            catch (WebException ex)
            {

                return Content(ex.Message.ToString());
            }

        }
      
    }
}