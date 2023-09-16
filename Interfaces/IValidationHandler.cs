using FluentValidation.Results;
using HrgAuthApi.Dto;

namespace HrgAuthApi.Interfaces
{
    public interface IValidationHandler
    {
        bool ValidateJsonObject(ValidationResult validationResult, out FailedResponseDto badRequestObject);
        SuccessfulResponseDto<T> WrapSuccessfulResponse<T>(T Data);
    }
}