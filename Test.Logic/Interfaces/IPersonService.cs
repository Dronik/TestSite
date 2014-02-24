﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Test.Model.Model;

namespace Test.Logic.Interfaces
{
    public interface IPersonService
    {
        Person GetPerson(int id);
        void CreatePerson(Person person);
        Person UpdatePerson(Person person);
        void DeletePerson(int id);

    }
}