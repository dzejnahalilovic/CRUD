﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace IdeaTrading.ViewModels
{
    public class UserViewModel
    {
        public int ID { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Address { get; set; }
        public string City { get; set; }
        public DateTime DateOfEmployment { get; set; }
        public string Position { get; set; }
        public string Phone { get; set; }
    }
}