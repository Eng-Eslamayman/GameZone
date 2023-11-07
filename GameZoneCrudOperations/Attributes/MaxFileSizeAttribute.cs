using System.ComponentModel.DataAnnotations;

namespace GameZoneCrudOperations.Attributes
{
    public class MaxFileSizeAttribute:ValidationAttribute
    {
        readonly int _maxFileSize;

        public MaxFileSizeAttribute(int maxFileSize)
        {
            _maxFileSize = maxFileSize;
        }

        protected override ValidationResult? IsValid(object? value, ValidationContext validationContext)
        {
            var file = value as IFormFile;
            if (file is not null)
            {
                if (file.Length > _maxFileSize)
                {
                    return new ValidationResult($"Only {_maxFileSize} are allowed!");
                }
            }
            return ValidationResult.Success;
        }

    }
}

