﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Entities.Concrete
{
	public class ErrorResponse
	{
		public ErrorResponse(string message)
		{
			Message = message;
		}
		public string Message { get; set; }
	}
}
