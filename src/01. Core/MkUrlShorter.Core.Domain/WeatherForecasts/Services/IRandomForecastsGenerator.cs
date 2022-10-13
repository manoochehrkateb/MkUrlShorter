using MkUrlShorter.Core.Domain.WeatherForecasts.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace MkUrlShorter.Core.Domain.WeatherForecasts.Services
{
    public interface IRandomForecastsGenerator
    {
        List<WeatherForecast> Execute();
    }
}
