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
	public class ArchivoService : IArchivoService
	{
		public IArchivoRepository archivoRepository;

		public ArchivoService(IArchivoRepository _archivoRepo)
		{
			this.archivoRepository = _archivoRepo;
		}

		public Archivo Create(Archivo _archivo)
		{
			using (var context = new ApplicationDbContext())
			{
				ApplicationDbContext.applicationDbContext = context;
				using (var dbContextTransaction = context.Database.BeginTransaction())
				{
					try {
						_archivo = archivoRepository.Create(_archivo);
						context.SaveChanges();
						dbContextTransaction.Commit();
					} catch (Exception ex) {
						dbContextTransaction.Rollback();
						throw new Exception("Rollback realizado ", ex);
					}
				}
				return _archivo;
			}
		}

		public IQueryable<Archivo> Read()
		{
			using (var context = new ApplicationDbContext())
			{
				IQueryable<Archivo> resultadoLst;
				ApplicationDbContext.applicationDbContext = context;
				using (var dbContextTransaction = context.Database.BeginTransaction())
				{
					try {
						resultadoLst = archivoRepository.Read();
						context.SaveChanges();
						dbContextTransaction.Commit();
					} catch (Exception ex) {
						dbContextTransaction.Rollback();
						throw new Exception("Rollback realizado ", ex);
					}
				}
				return resultadoLst;
			}
		}

		public Archivo Read(long id)
		{
			using (var context = new ApplicationDbContext())
			{
				Archivo resultado;
				ApplicationDbContext.applicationDbContext = context;
				using (var dbContextTransaction = context.Database.BeginTransaction())
				{
					try {
						resultado = archivoRepository.Read(id);
						context.SaveChanges();
						dbContextTransaction.Commit();
					}
					catch (Exception ex) {
						dbContextTransaction.Rollback();
						throw new Exception("Rollback realizado ", ex);
					}
				}
				return resultado;
			}
		}

		public void Update(Archivo _archivo)
		{
			using (var context = new ApplicationDbContext())
			{
				ApplicationDbContext.applicationDbContext = context;
				using (var dbContextTransaction = context.Database.BeginTransaction())
				{
					try
					{
						archivoRepository.Update(_archivo);
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

		public Archivo Delete(long id)
		{
			Archivo resultado;
			using (var context = new ApplicationDbContext())
			{
				ApplicationDbContext.applicationDbContext = context;
				using (var dbContextTransaction = context.Database.BeginTransaction())
				{
					try {
						resultado = archivoRepository.Delete(id);
						context.SaveChanges();
						dbContextTransaction.Commit();
					} catch (NoEncontradoException) {
						dbContextTransaction.Rollback();
						throw;
					} catch (Exception ex) {
						throw new Exception("Rollback realizado ", ex);
					}
				}
			}
			return resultado;
		}
	}
}