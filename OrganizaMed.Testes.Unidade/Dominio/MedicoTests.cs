using FluentValidation.TestHelper;
using OrganizaMed.Dominio.ModuloMedico;

namespace OrganizaMed.Testes.Unidade.Dominio;

[TestClass]
[TestCategory("Testes de Unidade")]
public class MedicoTests
{
    private ValidadorMedico? _validador;

    [TestInitialize]
    public void TestInitialize()
    {
        _validador = new ValidadorMedico();
    }

    [TestMethod]
    public void Deve_Criar_Medico_Valido()
    {
        Medico medico = new Medico("José Testes", "12345-SC");

        var resultado = _validador.TestValidate(medico);
            
        resultado.ShouldNotHaveAnyValidationErrors();
    }

    [TestMethod]
    public void Deve_Validar_Nome_Obrigatorio()
    {
        Medico medico = new Medico("", "12345-SC");

        var resultado = _validador.TestValidate(medico);

        resultado.ShouldHaveValidationErrorFor(m => m.Nome)
            .WithErrorMessage("O nome do Nome é obrigatório.");
    }

    [TestMethod]
    public void Deve_Validar_CRM_Obrigatorio()
    {
        Medico medico = new Medico("José Testes", "");

        var resultado = _validador.TestValidate(medico);

        resultado.ShouldHaveValidationErrorFor(m => m.CRM)
            .WithErrorMessage("O CRM do médico é obrigatório.");
    }

    [TestMethod]
    public void Deve_Validar_Formato_CRM()
    {
        Medico medico = new Medico("José Testes", "1234-SC");
        var resultado = _validador.TestValidate(medico);
        resultado.ShouldHaveValidationErrorFor(m => m.CRM)
            .WithErrorMessage("O campo CRM deve seguir o formato 00000-UF");
    }

    [TestMethod]
    public void Deve_Validar_Tamanho_Minimo_Nome()
    {
        Medico medico = new Medico("Jo", "12345-SC");
        var resultado = _validador.TestValidate(medico);
        resultado.ShouldHaveValidationErrorFor(m => m.Nome)
            .WithErrorMessage("O nome do Nome deve ter pelo menos 3 caracteres.");
    }
}
