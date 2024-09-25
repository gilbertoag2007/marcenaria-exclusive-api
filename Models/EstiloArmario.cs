using System.ComponentModel;

namespace MarcenariaExclusiveAPI.Models
{
    public enum EstiloArmario
    {
       [Description("Livre")]
        LIVRE,

        [Description("Portas e gavetas")]
        PORTASEGAVETAS,

        [Description("Apenas portas")]
        APENASPORTAS = 3,

        [Description("Apenas gavetas")]
        APENASGAVETAS = 4
    }

}
