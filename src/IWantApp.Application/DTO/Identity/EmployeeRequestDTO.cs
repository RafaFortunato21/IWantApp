﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IWantApp.Application.DTO.Identity
{
    public class EmployeeRequestDTO
    {
        public string Email { get; set; }
        public string Password { get; set; }
        public string Name { get; set; }
        public string EmployeeCode { get; set; }
    }
}
