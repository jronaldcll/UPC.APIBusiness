﻿using DBEntity;
using System;
using System.Collections.Generic;
using System.Text;

namespace DBContext
{
    public interface IImageRepository
    {
        List<EntityImage> GetImage(int id);
    }
}
