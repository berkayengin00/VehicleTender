namespace VehicleTender.DAL.Results
{
	public class DataResult<T>:Result
	{
		public T Data { get; set; }

		public DataResult(string message, T data, bool isSuccess):base(message, isSuccess)
		{
			Data = data;
		}
	}
}