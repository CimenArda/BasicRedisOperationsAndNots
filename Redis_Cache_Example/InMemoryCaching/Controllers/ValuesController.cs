﻿using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Caching.Memory;

namespace InMemoryCaching.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ValuesController : ControllerBase
    {
        private readonly IMemoryCache _memoryCache;

        public ValuesController(IMemoryCache memoryCache)
        {
            _memoryCache = memoryCache;
        }

        //[HttpGet]
        //public string Get()
        //{
        //    if (_memoryCache.TryGetValue<string>("name",out string name))
        //    {
        //        return name.Substring(0, 3);

        //    }

        //    return "";
        //}




        //[HttpGet("set")]
        //public void Set(string name)
        //{
        //    _memoryCache.Set("name", name);
        //}

        [HttpGet("SetDate")]
        public void SetDate()
        {
            _memoryCache.Set<DateTime>("date",DateTime.Now,options: new()
            {
                AbsoluteExpiration = DateTime.Now.AddSeconds(30),
                SlidingExpiration = TimeSpan.FromSeconds(5),
            });

        }

        [HttpGet("GetDate")]
        public DateTime GetDate()
        {
            return _memoryCache.Get<DateTime>("date");  
        }





    }
}
