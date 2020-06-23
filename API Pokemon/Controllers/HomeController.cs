using API_Pokemon.Models;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Web;
using System.Web.Mvc;

namespace API_Pokemon.Controllers
{
    public class HomeController : Controller
    {
        static int pagesize=8;
        static int page = 8;
        
        public ActionResult Index()
        {
            try
            {
                string version = "v1";
                int page = 1;
                int pagesize = 8;
                WebClient wc = new WebClient();
                var url = $"https://api.pokemontcg.io/{version}/cards?page={page}&pageSize={pagesize}";

                string pokemonstring= wc.DownloadString(url);
          
                byte[] bytes = Encoding.Default.GetBytes(pokemonstring);
                pokemonstring = Encoding.UTF8.GetString(bytes);
                RootObject datalist = JsonConvert.DeserializeObject<RootObject>(pokemonstring);
                return View(datalist);
            }
            catch (WebException ex)
            {

                return Content(ex.Message.ToString());
            }

        }
        [HttpPost]
        public ActionResult GetCards()
        {
            try
            {
                string version = "v1";
                int page = 1;
               pagesize = pagesize + 8;
               
                WebClient wc = new WebClient();
                var url = $"https://api.pokemontcg.io/{version}/cards?page={page}&pageSize={pagesize}";

                var pokemonstring = wc.DownloadString(url);
                byte[] bytes = Encoding.Default.GetBytes(pokemonstring);
                pokemonstring = Encoding.UTF8.GetString(bytes);
                RootObject datalist = JsonConvert.DeserializeObject<RootObject>(pokemonstring);
                return View("Index",datalist);
            }
            catch (WebException ex)
            {

                return Content(ex.Message.ToString());
            }

        }

    }
}