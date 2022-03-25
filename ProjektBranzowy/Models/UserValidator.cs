using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ProjektBranzowy.Models
{
    public class UserValidator : AbstractValidator<User>
    {
        public UserValidator()
        {
            RuleFor(x => x.Name)
                .Cascade(CascadeMode.StopOnFirstFailure)
                .NotEmpty().WithMessage("Please provide a valid {PropertyName}.")
                .Must(ValidString).WithMessage("{PropertyName} contains invalid characters.");

            RuleFor(x => x.Surname)
                .Cascade(CascadeMode.StopOnFirstFailure)
                .NotEmpty().WithMessage("Please provide a valid {PropertyName}.")
                .Must(ValidString).WithMessage("{PropertyName} contains invalid characters.");

            RuleFor(x => x.Email)
                .Cascade(CascadeMode.StopOnFirstFailure)
                .NotEmpty().WithMessage("Please provide a {PropertyName}.")
                .Must(ValidEmail).WithMessage("Email doesn't contain '@'.");



            RuleFor(x => x.Password)
                .Cascade(CascadeMode.StopOnFirstFailure)
                .NotEmpty().WithMessage("Please provide a {PropertyName}.")
                .Length(8, 30).WithMessage("Length ({TotalLength}) of {PropertyName} is invalid.");


            


        }
        protected bool ValidString(string name)
        {
            name = name.Replace(" ", "");
            name = name.Replace("-", "");
            return name.All(Char.IsLetter);
        }

        protected bool ValidEmail(string email)
        {
            if(email.Contains('@'))
            {
                return true;
            }
            return false;
                        

            
            
        }
    }
}
