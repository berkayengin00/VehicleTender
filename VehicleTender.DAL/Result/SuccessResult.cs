using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VehicleTender.Entity.Concrete;

namespace VehicleTender.DAL.Result
{
	public class SuccessResult<T>:Result<T>
	{

		public bool IsSuccess { get; set; }

		public SuccessResult(string message,T data,bool isSuccess=true):base(message,true)
		{
		}

	}
}
