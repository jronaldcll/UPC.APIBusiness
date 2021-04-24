using Dapper;
using DBEntity;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;

namespace DBContext
{
	public class ProjectRepository : BaseRepository, IProjectRepository
	{
        public BaseResponse GetProject(int id)
        {
            var returnEntity = new BaseResponse();
            var entityProject = new EntityProject();

            try
            {
                using(var db = GetSqlConnection())
                {
                    const string sql = @"usp_ObtenerProyecto";
                    var p = new DynamicParameters();
                    p.Add(name: "@IDPROYECTO", value: id, dbType: DbType.Int32, direction: ParameterDirection.Input);

                    entityProject = db.Query<EntityProject>(sql, param: p, commandType: CommandType.StoredProcedure).FirstOrDefault();

                    if (entityProject != null)
                    {
                        returnEntity.isSuccess = true;
                        returnEntity.errorCode = "0000";
                        returnEntity.errorMessage = string.Empty;
                        returnEntity.data = entityProject;
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


        public BaseResponse GetProjectPrice(decimal price_min, decimal price_max, string direccion)
        {
            var returnEntity = new BaseResponse();
            var entitiesProject = new List<EntityProject>();
            try
            {
                using (var db = GetSqlConnection())
                {
                    const string sql = @"usp_ObtenerProyecto_v2";
                    var p = new DynamicParameters();
                    p.Add(name: "@PRECIO_MIN", value: price_min, dbType: DbType.Decimal, direction: ParameterDirection.Input);
                    p.Add(name: "@PRECIO_MAX", value: price_max, dbType: DbType.Decimal, direction: ParameterDirection.Input);
                    p.Add(name: "@DIRECCION", value: direccion, dbType: DbType.String, direction: ParameterDirection.Input);

                    entitiesProject = db.Query<EntityProject>(sql, param: p, commandType: CommandType.StoredProcedure).ToList();

                    if (entitiesProject != null)
                    {
                        returnEntity.isSuccess = true;
                        returnEntity.errorCode = "0000";
                        returnEntity.errorMessage = string.Empty;
                        returnEntity.data = entitiesProject;
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
                returnEntity.isSuccess = false;
                returnEntity.errorCode = "0001";
                returnEntity.errorMessage = ex.Message;
                returnEntity.data = null;
            }
            return returnEntity;
        }

        public BaseResponse GetProjects()
        {
			var returnEntity = new BaseResponse();
            var entitiesProject = new List<EntityProject>();
            var imageRepository = new ImageRepository();

            try
            {
                using (var db = GetSqlConnection())
                {
                    const string sql = @"usp_ListarProyectos";
                    entitiesProject = db.Query<EntityProject>(sql, commandType: CommandType.StoredProcedure).ToList();

                    foreach(var obj in entitiesProject)
                    {
                        obj.images = imageRepository.GetImage(obj.IdProyecto);
                    }

                    if (entitiesProject.Count > 0)
                    {
                        returnEntity.isSuccess = true;
                        returnEntity.errorCode = "0000";
                        returnEntity.errorMessage = string.Empty;
                        returnEntity.data = entitiesProject;
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
    }
}
