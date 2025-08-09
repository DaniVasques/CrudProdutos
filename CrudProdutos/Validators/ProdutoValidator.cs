using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CrudProdutos.Entites;
using FluentValidation;

namespace CrudProdutos.Validators
{
    public class ProdutoValidator : AbstractValidator<Produto>
    {
        public ProdutoValidator()
        {
            RuleFor(p => p.Nome)
                .NotEmpty().WithMessage("Por favor, informe o nome do produto.")
                .Length(8, 100).WithMessage("Por favor,informe o nome do produto de 8 a 100 caracteres.");

            RuleFor(p => p.Preco)
                .NotNull().WithMessage("Por favor, informe o preço do produto.")
                .GreaterThan(0).WithMessage("Por favor, informe um preço maior que zero.")
                .LessThanOrEqualTo(10000).WithMessage("Por favor, informe um preço menor ou igual a 10.000.");

            RuleFor(p => p.Quantidade)
                .NotNull().WithMessage("Por favor, informe a quantidade do produto.")
                .GreaterThanOrEqualTo(1).WithMessage("Por favor, informe uma quantidade maior ou igual a um.")
                .LessThanOrEqualTo(1000).WithMessage("Por favor, informe uma quantidade menor ou igual a 1.000.");
        }
    }
}
