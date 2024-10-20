using Inventory_Management_System.VerticalSlicing.Common.Consts;

namespace Inventory_Management_System.VerticalSlicing.Data.Context;

public static class StoreContextseed
{
    public static async Task seedAsync(ApplicationDBContext dbcontext)
    {
        Role? adminRole = null;
        Role? memberRole = null;

        if (!dbcontext.Set<Role>().Any(r => r.Name == DefaultRoles.Admin))
        {
            adminRole = new Role
            {
                Name = DefaultRoles.Admin
            };

            await dbcontext.Set<Role>().AddAsync(adminRole);
            await dbcontext.SaveChangesAsync();
        }
        else
        {
            adminRole = await dbcontext.Set<Role>().FirstOrDefaultAsync(r => r.Name == DefaultRoles.Admin);
        }

        if (!dbcontext.Set<Role>().Any(r => r.Name == DefaultRoles.Member))
        {
            memberRole = new Role
            {
                Name = DefaultRoles.Member,
                IsDefault = true
            };

            await dbcontext.Set<Role>().AddAsync(memberRole);
            await dbcontext.SaveChangesAsync();
        }
        else
        {
            memberRole = await dbcontext.Set<Role>().FirstOrDefaultAsync(r => r.Name == DefaultRoles.Member);
        }

        if (!dbcontext.Set<User>().Any(u => u.UserName == DefaultUsers.AdminUserName))
        {
            var user = new User
            {
                Country = DefaultUsers.Country,
                Email = DefaultUsers.AdminEmail,
                UserName = DefaultUsers.AdminUserName,
                IsEmailVerified = true,
                PhoneNumber = DefaultUsers.AdminPhoneNumber,
                VerificationOTP = null,
                PasswordHash = PasswordHasher.HashPassword(DefaultUsers.AdminPassword)
            };

            await dbcontext.Set<User>().AddAsync(user);
            await dbcontext.SaveChangesAsync();

        }
    }
}
