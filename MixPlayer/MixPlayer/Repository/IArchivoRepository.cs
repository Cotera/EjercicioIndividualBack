using MixPlayer.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MixPlayer.Repository
{
	public interface IArchivoRepository
	{
		Archivo Create(Archivo _archivo);

		Archivo Read(long id);

		IQueryable<Archivo> Read();

		void Update(Archivo _archivo);

		Archivo Delete(long id);
		
	}
}
