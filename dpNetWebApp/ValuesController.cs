using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using dpNetWebApp.Models;


namespace dpNetWebApp
{
    [Route("api/[controller]")]
    public class ValuesController : Controller
    {

        public ActionResult Get()
        {
            MySQLRepository mySQLRepository = new MySQLRepository();
            PatternModel patternModel = mySQLRepository.Read(1);

            return Ok(new {patternModel});

        }
    }
}

