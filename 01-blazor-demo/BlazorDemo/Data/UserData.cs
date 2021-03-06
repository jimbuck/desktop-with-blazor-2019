﻿using System;
using System.Collections.Generic;

using BlazorDemo.Models;

namespace BlazorDemo.Data
{
    public class UserData
    {
        public List<Photo> Photos { get; set; } = new List<Photo>();
        public List<Session> Sessions { get; set; } = new List<Session>();

        public void Reset()
        {
            Photos = new List<Photo>();
            Sessions = new List<Session>();
        }
    }
}
