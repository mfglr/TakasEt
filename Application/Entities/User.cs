﻿using Microsoft.AspNetCore.Identity;

namespace Model.Entities
{

    public class User : IdentityUser<Guid>, IEntity
    {
        public DateTime CreatedDate { get; private set; }
        public DateTime? UpdatedDate { get; private set; }

		public void SetId()
		{
			Id = Guid.NewGuid();
		}

		public void SetCreatedDate()
		{
			CreatedDate = DateTime.UtcNow;
		}

		
		public void SetUpdatedDate()
		{
			UpdatedDate = DateTime.UtcNow;
		}
	}
}
