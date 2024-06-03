using System;
using FluentValidation;
using XForms.ViewModels;
using XForms.ViewModels.SignUp;

namespace XForms.Validators.Authentication
{
    public class AuthenticationValidator : AbstractValidator<SignUpViewModel>
    {
        public AuthenticationValidator()
        {
            RuleFor(vm => vm.SingInUserName)
             .NotEmpty()
             .WithMessage(m => "L'adresse e-mail est vide");

            RuleFor(vm => vm.SingInPassword)
            .NotEmpty()
            .WithMessage(m => "Le mot de passe est vide");
        }
    }
}