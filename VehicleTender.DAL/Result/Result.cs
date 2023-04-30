using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VehicleTender.DAL.Result
{
	public class DataResult<T>:Result
	{
		public T Data { get; set; }

		public DataResult(string message, T data, bool isSuccess):base(message, isSuccess)
		{
			Data = data;
		}
	}

	public class Result
	{
		public string Message { get; set; }
		public bool IsSuccess { get; set; }

		public Result(string message, bool isSuccess)
		{
			Message = message;
			IsSuccess = isSuccess;
		}
	}
}
