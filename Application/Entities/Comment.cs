using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model.Entities
{
    public class Comment : Entity
    {
        public string Content { get; private set; }
        public int NumberOfLikes { get; private set; } = 0;
    }
}
