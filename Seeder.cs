using Microsoft.Extensions.DependencyInjection;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ContainerApi
{
    public class Seeder
    {
        public static void Seedit(string jsonData, IServiceProvider serviceProvider)
        {
            var events = JsonConvert.DeserializeObject<List<WeatherEvent>>(jsonData);
            using (var serviceScope = serviceProvider.GetRequiredService<IServiceScopeFactory>().CreateScope())
            {
                var context = serviceScope.ServiceProvider.GetService<WeatherContext>();
                if (context.WeatherEvents.Any()) return;

                context.AddRange(events);
                context.SaveChanges();
            }
        }
    }
}
