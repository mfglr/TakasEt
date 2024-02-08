namespace OnSentRequestToJoinGroup_SendNotificationsToAdmins.WorkerService.Contents
{
    public class RequestToJoinGroupContent
    {
        public int GroupId { get; set; }
        public int IdOfUserWhoWantsToJoinGroup { get; set; }
    }
}
