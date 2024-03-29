﻿namespace SharedLibrary.Entities
{

	/* Entities which has been derived 'IRemovableByUsers' interface are able to removed by many users.
	 * For example :
	 *		if A Message of a conversation or a group is deleted by a user, the other users are able to read the message.
	 *		
	 *		A record is added to [message]UserRemoving table, When a user (whose id is 1) delete a message ( with id 1 )
	 *		
	 *		[message]UserRemoving Table
	 *		***************************
	 *		[Message]Id - RemoverId
	 *		**********1 - ********1
	 *		***************************
	 *		
	 *		So the message is able to be read by users except the user with id 1.
	 */
  
	public interface IRemovableByUsers<TCrossEntity,TUserId> where TCrossEntity : Entity<TUserId>
    {
		IReadOnlyCollection<TCrossEntity> UsersWhoRemovedTheEntity { get; }
		void Remove(TUserId userId);
		void Reinsert(TUserId userId);
		bool IsRemovedByUser(TUserId userId);
	}

	public interface IRemovableByUsers<TCrossEntity> : IRemovableByUsers<TCrossEntity,int> where TCrossEntity : Entity<int>
	{
		
	}
}
