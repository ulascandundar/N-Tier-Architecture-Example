﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.Dtos
{
	public class UpdateProductStockDto
	{
		public long ProductId { get; set; }
		public long Stock { get; set; }
	}
}
