using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using VehicleTender.DAL.Concrete;
using VehicleTender.Entity.View.Tramer;

namespace VehicleTender.UnitTest
{
	[TestClass]
	public class UnitTest1
	{
		[TestMethod]
		public void TestMethod1()
		{
			TramerDal tramerDal = new TramerDal();
			var res= tramerDal.GetTramerAddVM();
		}
	}
}
