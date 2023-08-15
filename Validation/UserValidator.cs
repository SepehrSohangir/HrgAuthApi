using FluentValidation;
using HrgAuthApi.Dto;

namespace HrgAuthApi.Validation
{
    public class UserValidator : AbstractValidator<UsersDto>
    {
        public UserValidator()
        {

        }
    }
}
