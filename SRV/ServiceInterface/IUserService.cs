﻿using SRV.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SRV.ServiceInterface
{
    public interface IUserService
    {
        RegisterModel GetByName(string name);
        void Save(RegisterModel model);
    }
}