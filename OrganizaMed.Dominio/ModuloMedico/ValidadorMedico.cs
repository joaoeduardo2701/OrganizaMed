using FluentValidation;

namespace OrganizaMed.Dominio.ModuloMedico;

public class ValidadorMedico : AbstractValidator<Medico>
{
    public ValidadorMedico()
    {
        RuleFor(m => m.Nome)
            .NotEmpty().WithMessage("O nome do {PropertyName} é obrigatório.")
            .DependentRules(() =>
            {
                RuleFor(m => m.Nome)
                    .MinimumLength(3).WithMessage("O nome do {PropertyName} deve ter pelo menos {MinLength} caracteres.")
                    .MaximumLength(100).WithMessage("O nome do {PropertyName} deve ter no máximo 100 caracteres.");
            }); 
                
        RuleFor(m => m.CRM)
            .NotEmpty().WithMessage("O CRM do médico é obrigatório.")
            .Matches(@"^\d{5}-[A-Z]{2}$").WithMessage("O campo {PropertyName} deve seguir o formato 00000-UF");
    }
}
