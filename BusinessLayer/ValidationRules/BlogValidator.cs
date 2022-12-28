using EntityLayer;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.ValidationRules
{
    public class BlogValidator : AbstractValidator<Blog>
    {
        public BlogValidator()
        {
            RuleFor(x => x.BlogTitle).NotEmpty().WithMessage("Blog başlığını boş geçemezsiniz !");
            RuleFor(x => x.BlogContent).NotEmpty().WithMessage("Blog içeriği boş geçilemez !");
            RuleFor(x => x.BlogTitle).MaximumLength(150).WithMessage("Başlıklar 150 karakterden fazla olmamalı...");
            RuleFor(x => x.BlogTitle).MinimumLength(5).WithMessage("Başlıklar 5 karakterden az olmamalı...");
        }
    }
}
