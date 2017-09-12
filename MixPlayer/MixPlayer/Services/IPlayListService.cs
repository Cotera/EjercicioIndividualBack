﻿using MixPlayer.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MixPlayer.Services
{
	public interface IPlayListService
	{
		PlayList Create(PlayList _playList);

		PlayList Read(long id);

		IQueryable<PlayList> Read();

		void Update(PlayList _playList);

		PlayList Delete(long id);
	}
}
