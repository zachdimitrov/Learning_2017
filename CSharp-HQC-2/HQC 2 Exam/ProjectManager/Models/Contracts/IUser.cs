﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjectManager.Models.Contracts
{
    public interface IUser
    {
        string Username { get; set; }

        string Email { get; set; }
    }
}
