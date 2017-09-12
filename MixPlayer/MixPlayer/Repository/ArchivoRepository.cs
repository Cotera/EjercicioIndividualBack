using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using MixPlayer.Entities;
using MixPlayer.Models;
using System.Data.Entity;
using GestorPlantillas;

namespace MixPlayer.Repository
{
	public class ArchivoRepository : IArchivoRepository
	{
		public Archivo Create(Archivo _archivo)
		{
			return ApplicationDbContext.applicationDbContext.Archivo.Add(_archivo);
		}

		public IQueryable<Archivo> Read()
		{
			IList<Archivo> lista = new List<Archivo>(ApplicationDbContext.applicationDbContext.Archivo);
			return lista.AsQueryable();
		}

		public Archivo Read(long id)
		{
			return ApplicationDbContext.applicationDbContext.Archivo.Find(id);
		}

		public void Update(Archivo _archivo)
		{
			ApplicationDbContext.applicationDbContext.Entry(_archivo).State = EntityState.Modified;
		}

		public Archivo Delete(long id)
		{
			Archivo TipoDoc = this.Read(id);
			if (TipoDoc == null)
			{
				throw new NoEncontradoException("No se ha encontrado el tipo de documento a eliminar");
			}
			return ApplicationDbContext.applicationDbContext.Archivo.Remove(TipoDoc);
		}
	}
}