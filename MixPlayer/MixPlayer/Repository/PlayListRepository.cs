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
	public class PlayListRepository : IPlayListRepository
	{
		public PlayList Create(PlayList _playList)
		{
			return ApplicationDbContext.applicationDbContext.PlayList.Add(_playList);
		}

		public IQueryable<PlayList> Read()
		{
			IList<PlayList> lista = new List<PlayList>(ApplicationDbContext.applicationDbContext.PlayList);
			return lista.AsQueryable();
		}

		public PlayList Read(long id)
		{
			return ApplicationDbContext.applicationDbContext.PlayList.Find(id);
		}

		public void Update(PlayList _playList)
		{
			ApplicationDbContext.applicationDbContext.Entry(_playList).State = EntityState.Modified;
		}

		public PlayList Delete(long id)
		{
			PlayList resultado = this.Read(id);
			if (resultado == null)
			{
				throw new NoEncontradoException("No se ha encontrado el tipo de documento a eliminar");
			}
			return ApplicationDbContext.applicationDbContext.PlayList.Remove(resultado);
		}
	}
}