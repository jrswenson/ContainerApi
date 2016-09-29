using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ContainerApi
{
    public class WeatherEvent
    {
        public static WeatherEvent Create(DateTime date, WeatherType type)
        {
            var we = new WeatherEvent(date, type);

            return we;
        }

        public WeatherEvent() { }

        public WeatherEvent(DateTime dateTime, WeatherType type)
        {
            Date = dateTime;
            Time = dateTime.TimeOfDay;
            Type = type;
            Reactions = new List<Reaction>();
        }

        public int Id { get; set; }
        public DateTime Date { get; set; }
        public TimeSpan Time { get; set; }
        public WeatherType Type { get; set; }
        public ICollection<Reaction> Reactions { get; set; }
        public string MostCommonWord { get; set; }
    }

    public class Reaction
    {
        public Reaction()
        {
            Comments = new List<Comment>();
        }
        public int Id { get; set; }
        public string Name { get; set; }
        public string Quote { get; set; }
        public int WeatherEventId { get; set; }
        public ICollection<Comment> Comments { get; set; }
    }

    public class Comment
    {
        public int Id { get; set; }
        public string Text { get; set; }
    }

    public enum WeatherType
    {
        Rain = 1,
        Snow = 2,
        Sleet = 3,
        Hail = 4,
        Sun = 5,
        Cloudy = 6
    }
}
