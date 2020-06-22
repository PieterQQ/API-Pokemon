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
        public ActionResult Index()
        {
            WebClient wc = new WebClient();
            var url = "https://api.pokemontcg.io/v1/cards";

            var pokemonstring = wc.DownloadString(url);
            byte[] bytes = Encoding.Default.GetBytes(pokemonstring);
            pokemonstring = Encoding.UTF8.GetString(bytes);
            RootObject datalist = JsonConvert.DeserializeObject<RootObject>(pokemonstring);
            return View(datalist);
        }
    }
}