﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FactoryPattern.Abstractions
{
    public interface IDiscounts
    {

        double GetPrice(int Price);
        
    }
}
