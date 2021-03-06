﻿namespace TicTacToeServer.Enums
{
    enum LoginResponseType: byte
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
