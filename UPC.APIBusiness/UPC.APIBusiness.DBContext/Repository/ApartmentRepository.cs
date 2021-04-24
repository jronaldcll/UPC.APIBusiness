using Dapper;
using DBEntity;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;

namespace DBContext
{
    public class ApartmentRepository : BaseRepository, IApartmentRepository
    {
        public List<EntityApartment> GetApartments()
        {
            var returnEntity = new List<EntityApartment>();
            try
            {
                using (var db = GetSqlConnection())
                {
                    const string sql = @"usp_Listar_Departamentos";
                    returnEntity = db.Query<EntityApartment>(sql, commandType: CommandType.StoredProcedure).ToList();
                }
            }
            catch(Exception ex)
            {
                throw new Exception(ex.Message);
            }
            return returnEntity;
        }

        public List<EntityApartment> GetApartments(int id)
        {
            var returnEntity = new List<EntityApartment>();
            try
            {
                using (var db = GetSqlConnection())
                {
                    const string sql = @"usp_Listar_Departamentos_X_Proyecto";
                    var p = new DynamicParameters();
                    p.Add(name: "@IDPROYECTO", value: id, dbType: DbType.Int32, direction: ParameterDirection.Input);
                   
                    returnEntity = db.Query<EntityApartment>(sql, param: p, commandType: CommandType.StoredProcedure).ToList();
                }

            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
            return returnEntity;
        }
    }
}
