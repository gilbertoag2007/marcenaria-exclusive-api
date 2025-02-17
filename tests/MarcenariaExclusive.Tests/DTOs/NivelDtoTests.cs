using MarcenariaExclusiveAPI.Application.DTOs;
using MarcenariaExclusiveAPI.Domain.Enums;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using Xunit;


public class NivelDtoTests
{
    private List<ValidationResult> ValidateModel(object model)
    {
        var results = new List<ValidationResult>();
        var context = new ValidationContext(model, serviceProvider: null, items: null);
        Validator.TryValidateObject(model, context, results, validateAllProperties: true);
        return results;
    }

    [Fact]
    public void NivelDto_DeveSerValido_QuandoParametrosCorretos()
    {
        var dto = new NivelDto
        {
            NumeroNivel = 5,
            AlturaNivel = 80,
            ConteudoNivel = ConteudoNivel.Gavetas,
            QuantidadeGavetas = 5,
            QuantidadePortas = 2
        };
        var results = ValidateModel(dto);
        Assert.Empty(results);
    }

    [Fact]
    public void NivelDto_DeveSerInvalido_QuandoAlturaNivelAbaixoDoMinimo()
    {
        var dto = new NivelDto { NumeroNivel = 2, AlturaNivel = 5, ConteudoNivel = ConteudoNivel.VazadoComFundo };
        var results = ValidateModel(dto);
        Assert.Contains(results, v => v.ErrorMessage.Contains("O percentual de ocupação do espaço do nível deve estar entre 10 e 100"));
    }

    [Fact]
    public void NivelDto_DeveSerInvalido_QuandoQuantidadeGavetasForaDoLimite()
    {
        var dto = new NivelDto { NumeroNivel = 1, AlturaNivel = 50, ConteudoNivel = ConteudoNivel.Gavetas, QuantidadeGavetas = 15 };
        var results = ValidateModel(dto);
        Assert.Contains(results, v => v.ErrorMessage.Contains("A quantidade de gavetas deve estar entre 1 e 10"));
    }
}
