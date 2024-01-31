namespace Models.Entities
{
	/* Entities which has been derived 'IRemovableByManyUsers' interface are able to removed many users.
	 * For example :
	 *		if A Message of a conversation or a group is deleted by a user, the other users are able to read the message.
	 *		
	 *		A record is added to [message]UserRemoving table, When a user (whose id is 1) delete a message ( with id 1 )
	 *		
	 *		[message]UserRemoving Table
	 *		***************************
	 *		[Message]Id - RemoverId
	 *			      1	-	      1
	 *		***************************
	 *		
	 *		So the message is able to be read the users except the user with id 1.
	 */

	/* We can use the entity User instead of The generic type V :
	 * 
	 * public interface IRemovableByManyUsers<TCrossEntity,T> 
	 *		where T : IBaseEntity
	 *		where TCrossEntity : CrossEntity<T, User>
	 * 
	 * But, entities that are derived the Entity User are able be created.
	 */

	public interface IRemovableByManyUsers<TCrossEntity,T,V> 
		where T : IBaseEntity
		where V : User
		where TCrossEntity : CrossEntity<T,V>
	{
		IReadOnlyCollection<TCrossEntity> UsersWhoRemovedTheEntity { get; }
		void RemoveTheEntityFromUser(int removerId);
		void AddAgainTheEntityToUser(int removerId);
	}
}
