using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;
using CapaMVC.Models;
using Newtonsoft.Json;

namespace CapaMVC.Controllers
{
    public class BBCharacterController : Controller
    {
        public ActionResult BBCharactersAll()
        {
            List<BBCharacters> character = null;

            string json;
            WebRequest request = WebRequest.Create(new Uri ("https://www.breakingbadapi.com/api/characters"));
            request.Method = "GET";
            request.PreAuthenticate = false;
            request.ContentType = "application/json;charset=utf-8'";
            var httpResponse = (HttpWebResponse)request.GetResponse();
            using (var streamReader = new StreamReader(httpResponse.GetResponseStream()))
            {
                json = streamReader.ReadToEnd();
            }
            character = JsonConvert.DeserializeObject<List<BBCharacters>>(json);
            return View(character);
        }
        public ActionResult BBCharactersOne()
        {
            List<BBCharacters> character = null;

            string json;
            WebRequest request = WebRequest.Create(new Uri("https://www.breakingbadapi.com/api/characters"));
            request.Method = "GET";
            request.PreAuthenticate = false;
            request.ContentType = "application/json;charset=utf-8'";
            var httpResponse = (HttpWebResponse)request.GetResponse();
            using (var streamReader = new StreamReader(httpResponse.GetResponseStream()))
            {
                json = streamReader.ReadToEnd();
            }
            character = JsonConvert.DeserializeObject<List<BBCharacters>>(json);
            return View(character);
        }
    }
}