using MarcenariaExclusiveAPI.Application.DTOs;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using Xunit;


public class ArmarioDtoTests
{
    private List<ValidationResult> ValidateModel(object model)
    {
        var results = new List<ValidationResult>();
        var context = new ValidationContext(model, serviceProvider: null, items: null);
        Validator.TryValidateObject(model, context, results, validateAllProperties: true);
        return results;
    }

    [Fact]
    public void ArmarioDto_DeveSerInvalido_QuandoAlturaForaDoIntervalo()
    {
        var dto = new ArmarioDto { Altura = 50, Largura = 150, Profundidade = 50, NomeProjeto = "Projeto Teste", Email = "teste@email.com" };
        var results = ValidateModel(dto);
        Assert.Contains(results, v => v.ErrorMessage.Contains("A altura deve estar entre 100 e 200 cm."));
    }

   [Fact]
    public void ArmarioDto_DeveSerInvalido_QuandoLarguraForaDoIntervalo()
    {
        var dto = new ArmarioDto { Altura = 120, Largura = 29, Profundidade = 50, NomeProjeto = "Projeto Teste", Email = "teste@email.com" };
        var results = ValidateModel(dto);
        Assert.Contains(results, v => v.ErrorMessage.Contains("A largura deve estar entre 30 e 200 cm."));
    }

    [Fact]
    public void ArmarioDto_DeveSerInvalido_QuandoProfundidadeForaDoIntervalo()
    {
        var dto = new ArmarioDto { Altura = 120, Largura = 29, Profundidade = 71, NomeProjeto = "Projeto Teste", Email = "teste@email.com" };
        var results = ValidateModel(dto);
        Assert.Contains(results, v => v.ErrorMessage.Contains("A profundidade deve estar entre 20 e 70 cm."));
    }
    [Fact]
    public void ArmarioDto_DeveSerInvalido_QuandoEmailNaoInformado()
    {
        var dto = new ArmarioDto { Altura = 150, Largura = 150, Profundidade = 50, NomeProjeto = "Projeto Teste" };
        var results = ValidateModel(dto);
        Assert.Contains(results, v => v.ErrorMessage.Contains("O e-mail é obrigatório."));
    }

    [Fact]
    public void ArmarioDto_DeveSerInvalido_QuandoSemNenhumNivel()
    {
        var dto = new ArmarioDto { Altura = 150, Largura = 150, Profundidade = 50, NomeProjeto = "Projeto Teste", Email = "teste@email.com", Niveis = new List<NivelDto>() };
        var results = ValidateModel(dto);
        Assert.Contains(results, v => v.ErrorMessage.Contains("O armário deve ter pelo menos um nível."));
    }
}
