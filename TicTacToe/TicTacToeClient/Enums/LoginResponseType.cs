namespace TicTacToeClient.Enums
{
    public enum LoginResponseType: byte
    {
        Error,
        Correct,
        InvalidPassword,
        AccountLocked,
        AccountNotVerified,
        AccountVerified,
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
