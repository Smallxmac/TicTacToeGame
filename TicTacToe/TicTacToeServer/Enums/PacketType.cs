namespace TicTacToeServer.Enums
{
    public enum PacketType : short
    {
        MaccAddress = 100,
        LoginRequest = 120,
        LoginResponse = 121,
        RegisterRequest = 123,
        RegisterResponse = 124,
        ForgotPasswordRequest = 125,
        ForgotPasswordResponse = 126,

        ChatMessage = 200,
        PlayerAssociation = 201,
        PlayerData = 202,
        GameInvite = 203,

    }
}
