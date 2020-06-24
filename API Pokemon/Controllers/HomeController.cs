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

      static int page ;
        static RootObject datalist;
        public ActionResult Index()
        {
            int pagesize=200;
            if (page < pagesize - 4)
            {
                page += 4;
            }
            else
            { page = pagesize - 1;
                ViewBag.End = "No more data";
            }
            
            ViewBag.Name = page;
           try {
                if (datalist  is null)
                {
                    WebClient wc = new WebClient();
                    var url = $"https://api.pokemontcg.io/v1/cards?pageSize={pagesize}";

                    string pokemonstring = wc.DownloadString(url);

                    byte[] bytes = Encoding.Default.GetBytes(pokemonstring);
                    pokemonstring = Encoding.UTF8.GetString(bytes);
                    datalist = JsonConvert.DeserializeObject<RootObject>(pokemonstring);
                }
                return View(datalist);
            }
            catch (WebException ex)
            {

                return Content(ex.Message.ToString());
            }

        }

      
    }
}