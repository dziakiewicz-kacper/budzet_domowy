﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BudzetDomowy.Models
{
    public interface ICommand
    {
        public void Execute(Account account);
    }
}
