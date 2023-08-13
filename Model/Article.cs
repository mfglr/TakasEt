using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Principal;
using System.Text;
using System.Threading.Tasks;

namespace Model
{
	public class Article : Entity
	{
        public string Title { get; private set; }
        public string Content { get; private set; }
        public string SumaryOfContent { get; private set; }
		public int NumberOfLikes { get; private set; } = 0;
		public int NumberOfViews { get; private set; } = 0;
        public DateTime PublishedDate { get; private set; }

    }
}
