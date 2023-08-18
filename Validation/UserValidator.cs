using FluentValidation;
using HrgAuthApi.Dto;
using HrgAuthApi.Interfaces;

namespace HrgAuthApi.Validation
{
    public sealed class UserValidator : AbstractValidator<UsersDto>
    {

        public UserValidator(IUserRepository userRepository)
        {
            RuleFor(p => p.UserId)
                .NotEqual(0)
                .WithMessage("وارد کردن اطلاعات کاربر اجباری است.");
            RuleFor(p => p.Password)
                .NotNull()
                .NotEmpty()
                .WithMessage("رمز عبور کاربر به درستی وارد نشده است.");
            RuleFor(p => p.CompanyID)
                .NotEqual(0)
                .WithMessage("اطلاعات کمپانی کاربر معتبر نمیباشد.");

            When(p => p.UserId != 0 && p.CompanyID != 0 && !string.IsNullOrEmpty(p.Password), () =>
            {
                RuleFor(p => p.UserId)
                .Must((userInfo,_) =>
                {
                    return userRepository.DoesUserExist(userInfo);
                })
                .WithMessage("کاربر وارد شده در سیستم موجود نمیباشد.");
                RuleFor(p => p.MoadianSubSystemId)
                .Must((moadianSubSystemId) =>
                {
                    return userRepository.MoadianSubSystemExists(moadianSubSystemId);
                })
                .WithMessage("زیرسیستم وارد شده موجود نیست.");
            });
        }
    }
}
