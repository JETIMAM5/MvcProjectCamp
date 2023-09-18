using EntityLayer.Concrete;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.ValidationRules
{
    public class WriterValidator : AbstractValidator<Writer>
    {
        public WriterValidator()
        {
            RuleFor(x => x.WriterName).NotEmpty().WithMessage("You must enter a Writer name !");
            RuleFor(x => x.WriterSurname).NotEmpty().WithMessage("You must enter a Surname !");
            RuleFor(x => x.WriterAbout).NotEmpty().WithMessage("You must enter an About part !");
            RuleFor(x => x.WriterAbout).Must(c => c != null && c.ToUpper().Contains("A")).WithMessage("About Part must contain an (A,a) letter");
            RuleFor(x => x.WriterName).MinimumLength(2).WithMessage("Writer name must have contain at least 2 characters");
            RuleFor(x => x.WriterName).MaximumLength(20).WithMessage("Writer name cannot be larger than 20 characters");
        }
    }
}
