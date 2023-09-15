using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Threading.Tasks;
using WebApplication1.Infrastructure;
using WebApplication1.Infrastructure.Models;

namespace WebApplication1.Controllers
{
    [Route("api/weather")]
    [ApiController]
    public class WeatherController : ControllerBase
    {
        public IDBManager DBManager { get; }

        public WeatherController(IDBManager dBManager)
        {
            DBManager = dBManager;
        }

        [HttpGet]
        [Route("getcurrent")]
        public responseCurr MainMethodCurr(string city, bool ImperialUnits)
        {
             
            string urlCurr = "https://api.weatherbit.io/v2.0/current?city=@tbilisi&key=a55bf3b444ad4af5a58385a2b5ffa2a1&units=@M";

            urlCurr = urlCurr.Replace("@tbilisi", city);
            if (ImperialUnits == true)
            {
                urlCurr = urlCurr.Replace("@M", "I");

            }
            else
            {
                urlCurr = urlCurr.Replace("@M", "M");

            }

            

            WebRequest requestCurr = GetWeatherInfo(urlCurr, "get");

            var WebResponseCurr = (HttpWebResponse)requestCurr.GetResponse();

            if (WebResponseCurr.StatusCode == HttpStatusCode.OK)
            {
                using (var streamReaderCurr = new StreamReader(WebResponseCurr.GetResponseStream()))
                {
                    var resultCurr = streamReaderCurr.ReadToEnd();
                    responseCurr resCurr = JsonConvert.DeserializeObject<responseCurr>(resultCurr);
                    streamReaderCurr.Close();
                    streamReaderCurr.Dispose();

                    WebResponseCurr.Close();
                    if (resCurr.data == null)
                    {
                        //MessageBox.Show("city not found");

                        return null;
                    }
                    //DispResCurr(resCurr);
                   DBManager.SaveDataToDBCurr(resCurr, urlCurr, ImperialUnits);
                    return resCurr;
                }

            }
            else
            {
                return null;
            }

        }
        [HttpGet]
        [Route("createrequest")]
        static WebRequest GetWeatherInfo(string url, string post_get)
        {
            WebRequest request = null;
            try
            {
                request = WebRequest.Create(url);
                request.PreAuthenticate = true;
                request.Method = post_get;
                request.ContentType = "application/json; charset=utf-8";
            }

            catch 
            {
            }
            return request;
        }

        [HttpGet]
        [Route("getforecast")]
        public responseFore MainMethodFore(string city, bool ImperialUnits)
        {
            string urlFore = "https://api.weatherbit.io/v2.0/forecast/daily?city=@Tbilisi&days=4&key=a55bf3b444ad4af5a58385a2b5ffa2a1&units=@M";
            if (ImperialUnits == true)
            {

                urlFore = urlFore.Replace("@M", "I");
            }
            else
            {

                urlFore = urlFore.Replace("@M", "M");
            }

            urlFore = urlFore.Replace("@Tbilisi", city);

            WebRequest requestFore = GetWeatherInfo(urlFore, "get");

            var WebResponseFore = (HttpWebResponse)requestFore.GetResponse();

            if (WebResponseFore.StatusCode == HttpStatusCode.OK)
            {
                using (var streamReaderFore = new StreamReader(WebResponseFore.GetResponseStream()))
                {
                    var resultFore = streamReaderFore.ReadToEnd();
                    responseFore resFore = JsonConvert.DeserializeObject<responseFore>(resultFore);
                    streamReaderFore.Close();
                    streamReaderFore.Dispose();
                    WebResponseFore.Close();

                    //DispResFore(resFore);
                    DBManager.SaveDataToDBFore(resFore, urlFore, ImperialUnits);
                    return resFore;

                }

            }
            else
            {
                return null;
            }
        }



    }
}
