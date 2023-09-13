using EntityLayer.Concrete;
using FluentValidation;
using System;
using System.CodeDom;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.ValidationRules
{
    public class CategoryValidator:AbstractValidator<Category>
    {
        public CategoryValidator()
        {
            RuleFor(x => x.CategoryName).NotEmpty().WithMessage("You must enter a category name !");
            RuleFor(x => x.CategoryDescription).NotEmpty().WithMessage("You must enter a description !");
            RuleFor(x => x.CategoryName).MinimumLength(3).WithMessage("Category name must have contain at least 3 characters");
            RuleFor(x => x.CategoryName).MaximumLength(20).WithMessage("Category name cannot be larger than 20 characters");
        }
    }
}
