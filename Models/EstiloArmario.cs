using System.ComponentModel;

namespace MarcenariaExclusiveAPI.Models
{
    public enum EstiloArmario
    {
       [Description("Livre")]
        Livre = 1,

        [Description("Portas e gavetas")]
        PortasEGavetas = 2,

        [Description("Apenas portas")]
        ApenasPortas = 3,

        [Description("Apenas gavetas")]
        ApenasGavetas = 4
    }

}
