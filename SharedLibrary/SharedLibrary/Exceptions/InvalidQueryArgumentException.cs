﻿using System.Net;

namespace SharedLibrary.Exceptions
{
	public class InvalidQueryArgumentException : AppException
	{
		public InvalidQueryArgumentException(string value,string key) : 
			base(
				$"Invalid query argument exception => {{ key : {key} , value : {value} }}", 
				HttpStatusCode.BadRequest
			)
		{
		}
	}
}
