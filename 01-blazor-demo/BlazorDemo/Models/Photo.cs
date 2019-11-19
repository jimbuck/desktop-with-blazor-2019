using System;

namespace BlazorDemo.Models
{
    public class Photo
    {
        public string Path { get; set; }
        public DateTime DateTaken { get; set; }
        public bool Selected { get; set; }

        public Photo(string path, string dateTaken)
        {
            Path = path;
            DateTaken = DateTime.Parse(dateTaken);
        }

        public bool IsInSession(Session session, TimeSpan maxIdle)
        {
            return (DateTaken - session.EndTime) < maxIdle;
        }
    }
}
