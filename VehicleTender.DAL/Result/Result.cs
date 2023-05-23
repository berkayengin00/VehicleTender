using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VehicleTender.DAL.Result
{
	public class Result<T>
	{
		public string Message { get; set; }
		public bool IsSuccess { get; set; }
		public T Data { get; set; }

		public Result(string message, T data, bool isSuccess)
		{
			Message = message;
			IsSuccess = isSuccess;
			Data = data;
		}
	}
}
