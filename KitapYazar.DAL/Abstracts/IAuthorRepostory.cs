﻿using KitapYazar.Entity.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KitapYazar.DAL.Abstracts
{
	public interface IAuthorRepostory: IGenericRepostory<Author>
	{
		Task<List<Author>> GetVirtualizedAuthorsAsync();
	}
}