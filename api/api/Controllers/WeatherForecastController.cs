﻿using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;

namespace api.Controllers;

[ApiController]
[Route("[controller]")]
public class WeatherForecastController : ControllerBase
{
    private static readonly string[] Summaries = new[]
    {
        "Freezing", "Bracing", "Chilly", "Cool", "Mild", "Warm", "Balmy", "Hot", "Sweltering", "Scorching"
    };

    private readonly ILogger<WeatherForecastController> _logger;

    public WeatherForecastController(ILogger<WeatherForecastController> logger)
    {
        _logger = logger;
    }

    [HttpGet(Name = "GetWeatherForecast")]
    public IEnumerable<WeatherForecast> Get()
    {
        return Enumerable.Range(1, 5).Select(index => new WeatherForecast
        {
            Date = DateOnly.FromDateTime(DateTime.Now.AddDays(index)),
            TemperatureC = Random.Shared.Next(-20, 55),
            Summary = Summaries[Random.Shared.Next(Summaries.Length)]
        })
        .ToArray();
    }

    //[Route("SaveNode")]
    [HttpPost]
    public string SaveNode(SaveNodRequest req)
    {
        string filename = $"{req.Title}.txt";
        System.IO.File.WriteAllText(filename, req.Content);
        return filename;
    }

    [ApiExplorerSettings(IgnoreApi = true)]
    public string AA()
    {
        return "";
    }

    [HttpGet("{countryName}")]
    public IActionResult GetCountryCode(string countryName)
    {
        if(countryName == "中国")
        {
            return Ok(86);
        }else if(countryName == "新西兰")
        {
            return Ok(64);
        }else
        {
            return NotFound($"国家代码{countryName}不存在");
        }
    }
}

