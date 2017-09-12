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
	public class PlayListController : ApiController
    {
		private IPlayListService playListService;

		public PlayListController(IPlayListService _playListServ)
		{
			this.playListService = _playListServ;
		}

		// POST: api/PlayList
		[ResponseType(typeof(PlayList))]
		public IHttpActionResult PostPlayList(PlayList playList)
		{
			if (!ModelState.IsValid)
			{
				return BadRequest(ModelState);
			}

			this.playListService.Create(playList);
			return CreatedAtRoute("DefaultApi", new { id = playList.Id }, playList);
		}

		// GET: api/PlayList
		public IQueryable<PlayList> GetPlayListes()
        {
            return playListService.Read();
        }

        // GET: api/PlayList/5
        [ResponseType(typeof(PlayList))]
        public IHttpActionResult GetPlayList(long id)
        {
			PlayList resultado = this.playListService.Read(id);
            if (resultado == null)
            {
                return NotFound();
            }

            return Ok(resultado);
        }

        // PUT: api/PlayList/5
        [ResponseType(typeof(void))]
        public IHttpActionResult PutPlayList(long id, PlayList playList)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != playList.Id)
            {
                return BadRequest();
            }

            try {
				this.playListService.Update(playList);
            }
			catch (DbUpdateConcurrencyException) {
                if (this.GetPlayList(id) == null)
                {
                    return NotFound();
                } else {
                    throw;
                }
            }

            return StatusCode(HttpStatusCode.NoContent);
        }

        // DELETE: api/PlayList/5
        [ResponseType(typeof(PlayList))]
        public IHttpActionResult DeletePlayList(long id)
        {
            try {
				return Ok(this.playListService.Delete(id));
			} catch (NoEncontradoException){
				return NotFound();
			}
        }
    }
}