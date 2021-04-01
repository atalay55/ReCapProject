using System;
using System.Collections.Generic;
using System.Text;
using Core.Entities;
using Core.Utilities;

namespace Core.Business
{
    public interface IEntityRespositoryService<T> where T : class, IEntity,new()
    {
        IDataResult<List<T>> GetAll();
        IResult Add(T items);
        IResult Delete(T items);
        IResult Update(T items);
    }
}
