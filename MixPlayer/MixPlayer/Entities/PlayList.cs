using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MixPlayer.Entities
{
	public class PlayList
	{
		public long Id { get; set; }

		public String Nombre { get; set; }
		public int NumElementos { get; set; }
		public TimeSpan DuracionTotal { get; set; }
		public bool EsPublica { get; set; }
	}
}