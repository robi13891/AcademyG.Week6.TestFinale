﻿using System;
using System.Collections.Generic;
using System.Text;

namespace AcademyG.Week6.TestFinale.Core.Interfaces
{
    public interface IRepository<TEntity>
    {
        List<TEntity> FetchAll();
        TEntity GetById(int id);
        bool Add(TEntity item);
        bool Update(TEntity item);
        bool Delete(TEntity item);
    }
}
