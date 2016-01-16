namespace TicTacToeClient.Enums
{
    /// <summary>
    /// Association types are used to understand the request sent by the server for friends.
    /// </summary>
    public enum AssociationType : short
    {
        RemoveFriend,
        Friend,
        FriendRequest,
        FriendAccept,
        FriendDeny,
        Blocked
    }
}
