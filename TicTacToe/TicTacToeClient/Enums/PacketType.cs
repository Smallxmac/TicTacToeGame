namespace TicTacToeClient.Enums
{
    public enum PacketType : short
    {
        LoginRequest = 120,
        LoginResponse = 121,
        RegisterRequest = 123,
        RegisterResponse = 124,
        ForgotPasswordRequest = 125,
        ForgotPasswordResponse = 126
    }
}
