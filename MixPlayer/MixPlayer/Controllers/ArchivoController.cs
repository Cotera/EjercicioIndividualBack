using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.Description;
using MixPlayer.Entities;
using MixPlayer.Models;
using System.Web.Http.Cors;
using MixPlayer.Services;
using GestorPlantillas;

namespace MixPlayer.Controllers
{
	[EnableCors(origins: "*", headers: "*", methods: "*")]
	public class ArchivoController : ApiController
    {
		private IArchivoService archivoService;

		public ArchivoController (IArchivoService _archivoServ)
		{
			this.archivoService = _archivoServ;
		}

		// POST: api/Archivos
		[ResponseType(typeof(Archivo))]
		public IHttpActionResult PostArchivo(Archivo archivo)
		{
			if (!ModelState.IsValid)
			{
				return BadRequest(ModelState);
			}

			this.archivoService.Create(archivo);
			return CreatedAtRoute("DefaultApi", new { id = archivo.Id }, archivo);
		}

		// GET: api/Archivos
		public IQueryable<Archivo> GetArchivoes()
        {
            return archivoService.Read();
        }

        // GET: api/Archivos/5
        [ResponseType(typeof(Archivo))]
        public IHttpActionResult GetArchivo(long id)
        {
			Archivo resultado = this.archivoService.Read(id);
            if (resultado == null)
            {
                return NotFound();
            }

            return Ok(resultado);
        }

        // PUT: api/Archivos/5
        [ResponseType(typeof(void))]
        public IHttpActionResult PutArchivo(long id, Archivo archivo)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != archivo.Id)
            {
                return BadRequest();
            }

            try {
				this.archivoService.Update(archivo);
            }
			catch (DbUpdateConcurrencyException) {
                if (this.GetArchivo(id) == null)
                {
                    return NotFound();
                } else {
                    throw;
                }
            }

            return StatusCode(HttpStatusCode.NoContent);
        }

        // DELETE: api/Archivos/5
        [ResponseType(typeof(Archivo))]
        public IHttpActionResult DeleteArchivo(long id)
        {
            try {
				return Ok(this.archivoService.Delete(id));
			} catch (NoEncontradoException){
				return NotFound();
			}
        }
    }
}