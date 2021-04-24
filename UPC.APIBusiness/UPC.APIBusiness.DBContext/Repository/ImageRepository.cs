using Dapper;
using DBEntity;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;

namespace DBContext
{
    class ImageRepository : BaseRepository, IImageRepository
    {
        public List<EntityImage > GetImage(int id)
        {
            var returnEntity = new List<EntityImage>();
            try
            {
                using (var db= GetSqlConnection())
                {
                    const string sql = @"usp_Listar_Images_X_Proyecto";
                    var p = new DynamicParameters();
                    p.Add(name: "@IDPROYECTO", value: id, dbType: DbType.Int32, direction: ParameterDirection.Input);
                    returnEntity = db.Query<EntityImage>(sql, param: p, commandType: CommandType.StoredProcedure).ToList();
                }
            }
            catch(Exception ex)
            {
                throw new Exception(ex.Message);
            }
            return returnEntity;
        }
    }
}
