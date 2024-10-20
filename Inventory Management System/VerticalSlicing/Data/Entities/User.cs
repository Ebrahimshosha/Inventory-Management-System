namespace FoodApp.Api.VerticalSlicing.Data.Entities
{
    public class User : BaseEntity
    {
        public string UserName { get; set; } = null!;
        public string Email { get; set; } = null!;
        public string PasswordHash { get; set; } = null!;
        public bool IsEmailVerified { get; set; } = false;
        public string PhoneNumber { get; set; } = null!;
        public string Country { get; set; } = null!;
        public string? VerificationOTP { get; set; }
        public DateTime? VerificationOTPExpiration { get; set; }
        public string? PasswordResetOTP { get; set; }
        public DateTime? PasswordResetOTPExpiration { get; set; }
        public int RoleId { get; set; }
        public Role Role { get; set; } = null!;
    }
}
