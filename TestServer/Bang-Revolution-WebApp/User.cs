﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Bang_Revolution_WebApp
{
    [Serializable]
    public class User
    {
        public string name { get; set; }
        public string pass { get; set; }
        public bool checkLogin { get; set; }
    }
}