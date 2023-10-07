namespace OnlineMuhasebeServer.Domain.Dtos;

public sealed record RefreshTokenDto(
    string Token,
    string RefreshToken,
    DateTime RefreshTokenExpires);
