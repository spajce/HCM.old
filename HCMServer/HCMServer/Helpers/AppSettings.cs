namespace HCMServer.Helpers;

public class AppSettings
{
    public string? Key { get; set; }
    public double AccessExpireSeconds { get; set; }
    public string? Issuer { get; set; }
    // refresh token time to live (in days), inactive tokens are
    // automatically deleted from the database after this time
    public int RefreshTokenValidityInDays { get; set; }
}
