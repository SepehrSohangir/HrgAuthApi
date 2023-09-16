using FluentValidation.Results;
using HrgAuthApi.Dto;

namespace HrgAuthApi.Validation
{
    public class ValidationHandler : Interfaces.IValidationHandler
    {
        public bool ValidateJsonObject(ValidationResult validationResult, out FailedResponseDto badRequestObject)
        {
            var isValid = validationResult.IsValid;
            if (isValid)
            {
                badRequestObject = new FailedResponseDto();
                return true;
            }
            var errorMessage = new FailedResponseDto
            {
                Status = "BadRequest",
                StatusCode = StatusCodes.Status400BadRequest,
                Message = "تعدادی از اطلاعات وارد شده معتبر نمیباشند",
                Errors = validationResult.Errors.ToDictionary
                (
                    e => e.ErrorCode,
                    e => e.ErrorMessage
                    )
            };
            badRequestObject = errorMessage;
            return false;
        }

        public SuccessfulResponseDto<T> WrapSuccessfulResponse<T>(T Data)
        {
            var result = new SuccessfulResponseDto<T>
            {
                Status = "Success",
                StatusCode = StatusCodes.Status200OK,
                Data = Data
            };
            return result;
        }
    }
}
