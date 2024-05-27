using Microsoft.AspNetCore.Identity;

namespace TraversalCoreProje.Models
{
    public class CustomIdentityValidaytor:IdentityErrorDescriber
    {
        public override IdentityError PasswordTooShort(int length)
        {
            return new IdentityError()
            {
                Code= "PasswordTooShort",
                Description=$"Şifre en az {length} karakter olmalıdır"
            };
        }
        public override IdentityError PasswordRequiresUpper()
        {
            return new IdentityError()
            {
                Code = "PasswordRequiresUpper",
                Description = $"Şifre en az bir büyük harf içermelidir."
            };
        }
        public override IdentityError PasswordRequiresLower()
        {
            return new IdentityError()
            {
                Code = "PasswordRequiresLower",
                Description = $"Şifre en az bir küçük harf içermelidir."
            };
        }
    }
}
