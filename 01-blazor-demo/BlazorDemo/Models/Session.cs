using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BlazorDemo.Models
{
    public class Session
    {
        public string Name { get; set; }
        public List<string> Tags { get; set; } = new List<string>();
        public DateTime StartTime { get; set; } = DateTime.MaxValue;
        public DateTime EndTime { get; set; } = DateTime.MinValue;
        public List<Photo> Photos { get; set; } = new List<Photo>();

        public void AddPhoto(Photo photo)
        {
            StartTime = new DateTime(Math.Min(StartTime.Ticks, photo.DateTaken.Ticks));
            EndTime = new DateTime(Math.Max(EndTime.Ticks, photo.DateTaken.Ticks));
            Photos.Add(photo);
        }
    }
}
