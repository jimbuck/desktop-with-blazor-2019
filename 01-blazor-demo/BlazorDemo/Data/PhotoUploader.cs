using System;
using System.Collections.Generic;
using System.Linq;
using BlazorDemo.Models;

namespace BlazorDemo.Data
{
    public class PhotoUploader
    {
        private const string unsplashBaseUrl = "https://images.unsplash.com/";
        private const string unsplashQueryStr = "?auto=format&fit=crop&h=540&w=960&q=20";
        private static readonly string[] photos = new string[]
            {
                "photo-1572295727871-7638149ea3d7",
                "photo-1571847490051-491c12ff6540",
                "photo-1571586100122-0869bd6e77c9",
                "photo-1542033644763-2354d1e19f63",
                "photo-1571217668979-f46db8864f75",
                "photo-1570942872213-1242607a35eb"
            };

        public List<Photo> GetPhotos()
        {
            var timestamps = GetTimestamps(DateTime.Today, photos.Length);

            return photos.Select((url, i) => new Photo(unsplashBaseUrl + url + unsplashQueryStr, timestamps[i])).ToList();
        }

        private List<string> GetTimestamps(DateTime today, int count)
        {
            var sessionGenerator = new SessionGenerator();

            sessionGenerator.AddTimeframe(today.AddDays(-3).AddHours(08), TimeSpan.FromHours(2), 3);
            sessionGenerator.AddTimeframe(today.AddDays(-2).AddHours(13), TimeSpan.FromHours(2), 1);
            sessionGenerator.AddTimeframe(today.AddDays(-2).AddHours(17), TimeSpan.FromHours(5), 3);
            sessionGenerator.AddTimeframe(today.AddDays(-1).AddHours(09), TimeSpan.FromHours(3), 2);

            return sessionGenerator.GetTimestamps(count);
        }

        private class SessionGenerator
        {
            private List<SessionTimeframe> _timeframes = new List<SessionTimeframe>();
            private double TotalWeight => _timeframes.Sum(tf => (double)tf.Weight);

            public void AddTimeframe(DateTime start, TimeSpan duration, int weight)
            {
                _timeframes.Add(new SessionTimeframe() { Start = start, End = start.Add(duration), Weight = weight });
            }

            public List<string> GetTimestamps(int totalCount)
            {
                var rand = new Random(10);

                return _timeframes.SelectMany(tf =>
                {
                    var count = (int)Math.Round(totalCount * (tf.Weight / TotalWeight));

                    var lastPhoto = tf.Start;
                    var range = (int)Math.Round((tf.End - tf.Start).TotalMinutes / (count + 1), 0);

                    return Enumerable.Range(0, count).Select(i =>
                    {
                        lastPhoto = lastPhoto.Add(TimeSpan.FromMinutes(rand.Next(1, range)));
                        return lastPhoto.ToString();
                    });
                }).Take(totalCount).ToList();
            }
        }

        private class SessionTimeframe
        {
            public DateTime Start { get; set; }
            public DateTime End { get; set; }
            public int Weight { get; set; }
        }
    }
}
