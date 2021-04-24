using DBEntity;
using System;
using System.Collections.Generic;
using System.Text;

namespace DBContext
{
    public interface IApartmentRepository
    {
        //List<EntityApartment> GetApartments();
        BaseResponse GetApartments();

        //List<EntityApartment> GetApartments(int id);
        BaseResponse GetApartments(int id);
    }
}
