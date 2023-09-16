using FluentValidation;
using HrgAuthApi.Dto;
using HrgAuthApi.Interfaces;
using HrgAuthApi.Validation.ErrorCodes;
namespace HrgAuthApi.Validation
{
    public sealed class UserValidator : AbstractValidator<UsersDto>
    {

        public UserValidator(IUserRepository userRepository)
        {
            RuleFor(p => p.UserId)
                .NotEmpty()
                .WithErrorCode(UserEnum.UserIdEmpty.ToString("d"))
                .WithMessage("وارد کردن شناسه کاربر اجباری است.");
            RuleFor(p => p.Password)
                .NotEmpty()
                .WithErrorCode(UserEnum.PasswordEmpty.ToString("d"))
                .WithMessage("رمز عبور کاربر به درستی وارد نشده است.");
            RuleFor(p => p.CompanyID)
                .GreaterThan(0)
                .WithErrorCode(UserEnum.CompanyIdInvalid.ToString("d"))
                .WithMessage("اطلاعات کمپانی کاربر معتبر نمیباشد.");
            RuleFor(p => p.InvYear)
                .InclusiveBetween(1300, 1500)
                .WithErrorCode(UserEnum.InvYearInvalid.ToString("d"))
                .WithMessage("سال مالی وارد شده معتبر نمیباشد.");

            When(p => p.UserId != 0 && p.CompanyID != 0 && !string.IsNullOrEmpty(p.Password), () =>
            {
                RuleFor(p => p.UserId)
                .Must((userInfo,_) =>
                {
                    return userRepository.DoesUserExist(userInfo);
                })
                .WithErrorCode(UserEnum.UserNotExist.ToString("d"))
                .WithMessage("کاربر وارد شده در سیستم موجود نمیباشد.");
                RuleFor(p => p.MoadianSubSystemId)
                .Must((moadianSubSystemId) =>
                {
                    return userRepository.MoadianSubSystemExists(moadianSubSystemId);
                })
                .WithErrorCode(UserEnum.SubsystemNotExist.ToString("d"))
                .WithMessage("زیرسیستم وارد شده موجود نیست.");

            });
        }
    }
}
