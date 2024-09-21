namespace MarcenariaExclusiveAPI.Utils
{
    using Microsoft.OpenApi.Any;
    using Microsoft.OpenApi.Models;
    using Swashbuckle.AspNetCore.SwaggerGen;
    using System;
    using System.ComponentModel;
    using System.Linq;

    //Filtro utilizado para apresentar a descrição dos ENUMs no Swagger
    public class EnumSchemaFilter : ISchemaFilter
    {
        public void Apply(OpenApiSchema schema, SchemaFilterContext context)
        {
            if (context.Type.IsEnum)
            {
                var enumType = context.Type;
                var enumValues = Enum.GetValues(enumType).Cast<Enum>();

                schema.Enum.Clear();
                foreach (var enumValue in enumValues)
                {
                    var description = enumValue
                        .GetType()
                        .GetField(enumValue.ToString())
                        .GetCustomAttributes(typeof(DescriptionAttribute), false)
                        .Cast<DescriptionAttribute>()
                        .FirstOrDefault()?.Description ?? enumValue.ToString();

                    schema.Enum.Add(new OpenApiString($"{Convert.ToInt32(enumValue)} - {description}"));
                }
            }
        }
    }

}
