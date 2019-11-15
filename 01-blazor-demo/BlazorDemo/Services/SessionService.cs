using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BlazorDemo.Models;

namespace BlazorDemo.Services
{
    public class SessionService
    {
        /// <summary>
        /// Converts a collection of photos into a list of sessions with photos.
        /// </summary>
        /// <param name="photos">The photos to group.</param>
        /// <param name="maxIdle">The maximum allowed time between photos to be considered a session.</param>
        /// <returns></returns>
        public List<Session> CreateSessions(List<Photo> photos, TimeSpan maxIdle)
        {
            return photos
                .OrderBy(p => p.DateTaken)
                .Aggregate(new List<Session>(), (sessions, photo) =>
                {
                    var session = sessions.FirstOrDefault(s => photo.IsInSession(s, maxIdle));

                    if (session == null) sessions.Add(session = new Session());

                    session.AddPhoto(photo);
                    return sessions;
                });
        }
    }
}
