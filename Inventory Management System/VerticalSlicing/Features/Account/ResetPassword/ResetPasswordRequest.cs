﻿namespace FoodApp.Api.VerticalSlicing.Features.Account.ResetPassword
{
    public class ResetPasswordRequest
    {
        public string Email { get; set; } = null!;
        public string OTP { get; set; } = null!;
        public string NewPassword { get; set; } = null!;
        public string ConfirmPassword { get; set; } = null!;
    }
}
