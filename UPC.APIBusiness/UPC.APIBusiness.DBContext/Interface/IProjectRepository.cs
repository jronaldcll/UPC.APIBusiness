using DBEntity;
using System;
using System.Collections.Generic;
using System.Text;

namespace DBContext
{
	public interface IProjectRepository
	{
		//List<EntityProject> GetProjects();
		BaseResponse GetProjects();

		//EntityProject GetProject(int id);
		BaseResponse GetProject(int id);

		//List<EntityProject> GetProjectPrice(decimal price_min, decimal price_max, string direccion);
		BaseResponse GetProjectPrice(decimal price_min, decimal price_max, string direccion);
	}
}
