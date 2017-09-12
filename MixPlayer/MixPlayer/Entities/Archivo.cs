using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace MixPlayer.Entities
{

	public class Archivo
	{
		[Key]
		public long Id { get; set; }

		public String Titulo { get; set; }
		public String Tipo { get; set; }
		public String Formato { get; set; }
		public float TamanioMb { get; set; }
		//public DateTime Duracion { get; set; }
		public TimeSpan Duracion { get; set; }
	}
}