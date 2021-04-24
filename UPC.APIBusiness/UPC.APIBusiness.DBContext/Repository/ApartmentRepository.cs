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
        //public List<EntityApartment> GetApartments()
        public BaseResponse GetApartments()
        {
            var returnEntity = new BaseResponse();
            var entityApartment = new List<EntityApartment>();
            try
            {
                using (var db = GetSqlConnection())
                {
                    const string sql = @"usp_Listar_Departamentos";
                    entityApartment = db.Query<EntityApartment>(sql, commandType: CommandType.StoredProcedure).ToList();
                    if (entityApartment != null)
                    {
                        returnEntity.isSuccess = true;
                        returnEntity.errorCode = "0000";
                        returnEntity.errorMessage = string.Empty;
                        returnEntity.data = entityApartment;
                    }
                    else
                    {
                        returnEntity.isSuccess = false;
                        returnEntity.errorCode = "0000";
                        returnEntity.errorMessage = string.Empty;
                        returnEntity.data = null;
                    }
                }
            }
            catch(Exception ex)
            {
                returnEntity.isSuccess = false;
                returnEntity.errorCode = "0001";
                returnEntity.errorMessage = ex.Message;
                returnEntity.data = null;
            }
            return returnEntity;
        }

        //public List<EntityApartment> GetApartments(int id)
        public BaseResponse GetApartments(int id)
        {
            var returnEntity = new BaseResponse();
            var entityAparment = new List<EntityApartment>();
            try
            {
                using (var db = GetSqlConnection())
                {
                    const string sql = @"usp_Listar_Departamentos_X_Proyecto";
                    var p = new DynamicParameters();
                    p.Add(name: "@IDPROYECTO", value: id, dbType: DbType.Int32, direction: ParameterDirection.Input);

                    entityAparment = db.Query<EntityApartment>(sql, param: p, commandType: CommandType.StoredProcedure).ToList();
                    if(entityAparment != null)
                    {
                        returnEntity.isSuccess = true;
                        returnEntity.errorCode = "0000";
                        returnEntity.errorMessage = string.Empty;
                        returnEntity.data = entityAparment;
                    }
                    else
                    {
                        returnEntity.isSuccess = false;
                        returnEntity.errorCode = "0000";
                        returnEntity.errorMessage = string.Empty;
                        returnEntity.data = null;
                    }
                }

            }
            catch (Exception ex)
            {
                //throw new Exception(ex.Message);
                returnEntity.isSuccess = false;
                returnEntity.errorCode = "0001";
                returnEntity.errorMessage = ex.Message;
                returnEntity.data = null;
            }
            return returnEntity;
        }
    }
}
