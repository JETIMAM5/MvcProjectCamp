using EntityLayer.Concrete;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.ValidationRules
{
    public class ContactValidator:AbstractValidator<Contact>
    {
        public ContactValidator() 
        {
            RuleFor(x => x.UserMail).NotEmpty().WithMessage("You Must Enter a Mail Address ! ");
            RuleFor(x => x.Subject).NotEmpty().WithMessage("You have to Write Your Subject or Issue ! ");
            RuleFor(x => x.UserName).NotEmpty().WithMessage("Please Enter Your Username ! ");
            RuleFor(x => x.Subject).MinimumLength(3).WithMessage("You Must Enter At Least 3 Characters ! ");
            RuleFor(x => x.UserName).MinimumLength(3).WithMessage("Please check your Username , it cannot contain less than 3 characters ! ");
            RuleFor(x => x.Subject).MaximumLength(150).WithMessage("Please , Enter Maximum 150 Characters !");

        }   
    }
}
