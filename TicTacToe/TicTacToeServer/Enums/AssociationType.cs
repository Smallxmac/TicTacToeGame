﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TicTacToeServer.Enums
{
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
