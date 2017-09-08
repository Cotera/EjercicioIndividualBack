using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace MixPlayer.Entities
{
	public enum Tipo
	{
		AUDIO,
		VIDEO,
		IMAGEN
	}

	public class Archivo
	{
		[Key]
		public long Id { get; set; }

		public String Titulo { get; set; }
		public String Autor { get; set; }
		public Tipo Tipo;
		public String Formato { get; set; }
		public float TamanioMb { get; set; }
		public DateTime Duracion { get; set; }

	}
}