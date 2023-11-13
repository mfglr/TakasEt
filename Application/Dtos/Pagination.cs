using Microsoft.AspNetCore.Http;
using System;

namespace Application.Dtos
{
	
	public class Pagination
	{
        public int Skip { get; set; }
        public int Take { get; set; }
		public int Year { get; set; }
		public int Month { get; set; }
		public int Day { get; set; }
		public int Hour { get; set; }
		public int Minute { get; set; }
		public int Second { get; set; }
		public int Milisecond { get; set; }

		public DateTime getQueryDate()
		{
			return new DateTime(Year, Month, Day, Hour, Minute, Second,Milisecond);
		}

		public Pagination(IQueryCollection collection)
        {
			Skip = int.Parse(collection.Where(x => x.Key == "skip").FirstOrDefault().Value.ToString());
			Take = int.Parse(collection.Where(x => x.Key == "take").FirstOrDefault().Value.ToString());
			Year = int.Parse(collection.Where(x => x.Key == "year").FirstOrDefault().Value.ToString());
			Month = int.Parse(collection.Where(x => x.Key == "month").FirstOrDefault().Value.ToString());
			Day = int.Parse(collection.Where(x => x.Key == "day").FirstOrDefault().Value.ToString());
			Hour = int.Parse(collection.Where(x => x.Key == "hour").FirstOrDefault().Value.ToString());
			Minute = int.Parse(collection.Where(x => x.Key == "minute").FirstOrDefault().Value.ToString());
			Second = int.Parse(collection.Where(x => x.Key == "second").FirstOrDefault().Value.ToString());
			Milisecond = int.Parse(collection.Where(x => x.Key == "milisecond").FirstOrDefault().Value.ToString());
		}
	}
}
