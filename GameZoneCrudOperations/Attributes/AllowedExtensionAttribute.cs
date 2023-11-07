using System.ComponentModel.DataAnnotations;

namespace GameZoneCrudOperations.Attributes
{
    public class AllowedExtensionAttribute:ValidationAttribute
    {
        readonly string _allowedExtesions;

        public AllowedExtensionAttribute(string allowedExtesions)
        {
            _allowedExtesions = allowedExtesions;
        }

        protected override ValidationResult? IsValid(object? value, ValidationContext validationContext)
        {
            var file = value as IFormFile;
            if (file != null)
            {
                var extension = Path.GetExtension(file.FileName);
                var isAllowed = _allowedExtesions.Split(",").Contains(extension,StringComparer.OrdinalIgnoreCase);
                if (!isAllowed)
                {
                    return new ValidationResult($"Only {_allowedExtesions} are allowed!");
                }
            }
            return ValidationResult.Success;
        }

    }
}
