using FluentValidation;
using FluentValidation.Results;
using JobEntryy.Application.Parametres.ResponseParametres;

namespace JobEntryy.Application.Extensions
{
    public static class ValidationExtension
    {
        public static string ValidationErrorString(this ValidationResult validationResult)
        {
            return string.Join(", ", validationResult.Errors.Select(x => x.ErrorMessage));
        }

        public static async Task<JobEntryy.Application.Parametres.ResponseParametres.Result> ValidatorResult<T>(AbstractValidator<T> validator, T instance)
        {
            var validationResult = await validator.ValidateAsync(instance);
            if (!validationResult.IsValid)
            {
                return ErrorResult.Create(validationResult.ValidationErrorString());
            }
            return Result.Create(true);
        }
    }
}
