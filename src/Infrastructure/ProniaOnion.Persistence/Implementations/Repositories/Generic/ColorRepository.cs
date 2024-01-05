﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ProniaOnion.Application.Abstractions.Repositories;
using ProniaOnion.Domain.Entities;
using ProniaOnion.Persistence.Contexts;

namespace ProniaOnion.Persistence.Implementations.Repositories.Generic
{
    public class ColorRepository:Repository<Color>,IColorRepository
    {
        public ColorRepository(AppDbContext context) : base(context) { }
    }
}
