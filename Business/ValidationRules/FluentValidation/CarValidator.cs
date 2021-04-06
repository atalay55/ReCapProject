using System;
using System.Collections.Generic;
using System.Text;
using Entities.Concrete;
using FluentValidation;

namespace Business.ValidationRules.FluentValidation
{
   public class CarValidator : AbstractValidator<Car>
    {
        public CarValidator()
        {
            RuleFor(p => p.CarName).NotEmpty();
            RuleFor(p => p.CarName).MinimumLength(3);
            RuleFor(p => p.ColorId).NotEmpty();
            RuleFor(p => p.ColorId).GreaterThan(0);
            RuleFor(p=>p.BrandId).NotEmpty();
            RuleFor(p => p.BrandId).GreaterThan(0);
            RuleFor(p => p.ModelYear).NotEmpty();
            RuleFor(p => p.ModelYear).GreaterThanOrEqualTo(2000);
            RuleFor(p => p.DailyPrice).NotEmpty();
            RuleFor(p => p.DailyPrice).GreaterThan(0);

            


        }

    }
}
