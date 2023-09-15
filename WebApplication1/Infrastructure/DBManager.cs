using System.Threading.Tasks;
using System;
using WebApplication1.Controllers;
using Microsoft.EntityFrameworkCore;
using WebApplication1.Infrastructure.Models;

namespace WebApplication1.Infrastructure;

public class DBManager : IDBManager
{
    private readonly WeatherContext _dbContext;

    public DBManager(WeatherContext dbContext)
    {
        _dbContext = dbContext;
    }

    public Task SaveDataToDBCurr(responseCurr res, string url, bool toggleSwitchUnits)
    {
        var result = res.data[0];

        request_history request = new request_history
        {
            requestURL = url,
            date__ = DateTime.Now,
            city = result.city_name,
            temperature = AppDesignController.convertUnitsTemp(result.app_temp.ToString(), toggleSwitchUnits),
            weather_desc = result.weather.description,
            humidity = result.clouds.ToString() + "%",
            chance_of_rain = result.rh.ToString() + "%"
        };
        _dbContext.request_history.Add(request);
        _dbContext.SaveChanges();

        return Task.CompletedTask;
    }


    public Task SaveDataToDBFore(responseFore res, string url, bool toggleSwitchUnits)
    {

        var result = res.data;

        for (int i = 0; i < result.Length; i++)
        {
            request_fore request = new request_fore
            {
                requestURL1 = url,
                date__1 = DateTime.Now.AddDays(i + 1),
                city1 = res.city_name,
                maxtemp = AppDesignController.convertUnitsTemp(result[i].low_temp.ToString(), toggleSwitchUnits),
                mintemp = AppDesignController.convertUnitsTemp(result[i].high_temp.ToString(), toggleSwitchUnits),
                weather_desc1 = result[i].weather.description,
                humidity1 = result[i].clouds.ToString() + "%",
                sunrise = AppDesignController.ConvertFromUnix(Convert.ToInt64(result[i].sunrise_ts), false).AddHours(4).ToString("HH:mm"),
                sunset = AppDesignController.ConvertFromUnix(Convert.ToInt64(result[i].sunset_ts), false).AddHours(4).ToString("HH:mm")
            };
            _dbContext.request_fore.Add(request);
            _dbContext.SaveChanges();

        }

        return Task.CompletedTask;

    }


    public Task SaveUserLogToDB(string mail, string ip, string mac, string username, int role)
    {
        Users_Log user = new Users_Log
        {
            date = DateTime.Now,
            mail = mail,
            ip = ip,
            mac = mac,
            username = username,
            role_id = role

        };
        _dbContext.Users_Log.Add(user);
        _dbContext.SaveChanges();

        return Task.CompletedTask;
    }
}
