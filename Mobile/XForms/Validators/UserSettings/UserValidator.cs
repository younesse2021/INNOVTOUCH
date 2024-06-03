//using System;
//using FluentValidation;
//using XForms.ViewModels;

//namespace XForms.Validators.User
//{
//    public class UserValidator : AbstractValidator<AddNewUserViewModel>
//    {
//        public UserValidator()
//        {

//            RuleFor(vm => vm.FirstName)
//             .NotEmpty()
//             .WithMessage(m => "First name required");

//            RuleFor(vm => vm.LastName)
//                .NotEmpty()
//                .WithMessage(m => "Last name required");
//                //.When(c => c.CreateNewUserData != null);


//            RuleFor(vm => vm.Email)
//                .NotEmpty()
//                .WithMessage(m => "E-mail required")
//                .EmailAddress()
//                .WithMessage(m => "Invalid email address ");


//            RuleFor(vm => vm.Password)
//                .NotEmpty()
//                .WithMessage(m => "Password required")
//                .MinimumLength(6)
//                .WithMessage(m => "Please enter at least 6 Characters");


//            RuleFor(vm => vm.ConfirmPassword)
//                .NotEmpty()
//                .WithMessage(m => "Confirm password required")
//                .Equal(vm => vm.Password)
//                .WithMessage(m => "Passwords are not the same");

//            RuleFor(vm => vm.NumberPhone)
//               .NotEmpty()
//                .WithMessage(m => "number phone required");

//        }
//    }
//}