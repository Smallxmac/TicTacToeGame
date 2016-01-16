namespace TicTacToeClient.Enums
{
    /// <summary>
    /// Login Response are used in the login/register/forgot password
    /// process to understand how the server reacted to the request.
    /// </summary>
    public enum LoginResponseType: byte
    {
        Error,
        Correct,
        InvalidPassword,
        AccountLocked,
        AccountNotVerified,
        AccountVerified,
        AccountInUse,
        TooManyTries,
        InvalidMac,

        AccountCreated,
        UsernameInUse,
        EmailInUse,
        CreationBlocked,

        ResetSent,
        ResetInvalid,
        ResetLocked,
        ResetVerified,

        DatabaseError
    }
}
