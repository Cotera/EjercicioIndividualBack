using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using MixPlayer.Entities;
using MixPlayer.Repository;
using MixPlayer.Models;
using GestorPlantillas;

namespace MixPlayer.Services
{
	public class PlayListService : IPlayListService
	{
		public IPlayListRepository playlistRepository;

		public PlayListService (IPlayListRepository _playlistRepo)
		{
			this.playlistRepository = _playlistRepo;
		}

		public PlayList Create(PlayList _playList)
		{
			using (var context = new ApplicationDbContext())
			{
				ApplicationDbContext.applicationDbContext = context;
				using (var dbContextTransaction = context.Database.BeginTransaction())
				{
					try
					{
						_playList = playlistRepository.Create(_playList);
						context.SaveChanges();
						dbContextTransaction.Commit();
					}
					catch (Exception ex)
					{
						dbContextTransaction.Rollback();
						throw new Exception("Rollback realizado ", ex);
					}
				}
				return _playList;
			}
		}

		public IQueryable<PlayList> Read()
		{
			using (var context = new ApplicationDbContext())
			{
				IQueryable<PlayList> resultadoLst;
				ApplicationDbContext.applicationDbContext = context;
				using (var dbContextTransaction = context.Database.BeginTransaction())
				{
					try
					{
						resultadoLst = playlistRepository.Read();
						context.SaveChanges();
						dbContextTransaction.Commit();
					}
					catch (Exception ex)
					{
						dbContextTransaction.Rollback();
						throw new Exception("Rollback realizado ", ex);
					}
				}
				return resultadoLst;
			}
		}

		public PlayList Read(long id)
		{
			using (var context = new ApplicationDbContext())
			{
				PlayList resultado;
				ApplicationDbContext.applicationDbContext = context;
				using (var dbContextTransaction = context.Database.BeginTransaction())
				{
					try
					{
						resultado = playlistRepository.Read(id);
						context.SaveChanges();
						dbContextTransaction.Commit();
					}
					catch (Exception ex)
					{
						dbContextTransaction.Rollback();
						throw new Exception("Rollback realizado ", ex);
					}
				}
				return resultado;
			}
		}

		public void Update(PlayList _playList)
		{
			using (var context = new ApplicationDbContext())
			{
				ApplicationDbContext.applicationDbContext = context;
				using (var dbContextTransaction = context.Database.BeginTransaction())
				{
					try
					{
						playlistRepository.Update(_playList);
						context.SaveChanges();
						dbContextTransaction.Commit();
					}
					catch (Exception ex)
					{
						dbContextTransaction.Rollback();
						throw new Exception("Rollback realizado ", ex);
					}

				}
			}
		}

		public PlayList Delete(long id)
		{
			PlayList resultado;
			using (var context = new ApplicationDbContext())
			{
				ApplicationDbContext.applicationDbContext = context;
				using (var dbContextTransaction = context.Database.BeginTransaction())
				{
					try
					{
						resultado = playlistRepository.Delete(id);
						context.SaveChanges();
						dbContextTransaction.Commit();
					}
					catch (NoEncontradoException)
					{
						dbContextTransaction.Rollback();
						throw;
					}
					catch (Exception ex)
					{
						throw new Exception("Rollback realizado ", ex);
					}
				}
			}
			return resultado;
		}
	}
}