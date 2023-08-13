using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model
{
	public class Category : Entity
	{
        public string Name { get; set; }
        public ICollection<Article> Atricles { get; set; }
    }
}
