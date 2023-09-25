using EntityLayer.Concrete;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.ValidationRules
{
    public class MessageValidator:AbstractValidator<Message>
    {
        public MessageValidator() 
        {
            RuleFor(x => x.ReceiverMail).NotEmpty().WithMessage("You Must Enter a Receiver Mail!...");
            RuleFor(x => x.Subject).NotEmpty().WithMessage("You Must Enter a Subject for Mail!...");
            RuleFor(x => x.MessageContent).NotEmpty().WithMessage("You Must Enter the Content!... ");
            RuleFor(x => x.ReceiverMail).NotEmpty().WithMessage("E-Mail Address Cannot Be Null!...").EmailAddress().WithMessage("Invalid E-Mail Address.");
            RuleFor(x => x.Subject).MinimumLength(3).WithMessage("Please, Enter At Least 3 Characters!...");
            RuleFor(x => x.Subject).MaximumLength(100).WithMessage("Please, Enter Maximum 100 Characters!...");
        }
    }
}
