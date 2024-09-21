using System.ComponentModel;

namespace MarcenariaExclusiveAPI.Models
{
    public enum TipoMovel
    {
        [Description("Armario multiuso")]
        Livre = 1,

        [Description("Armario Aereo")]
        PortasEGavetas = 2,

        [Description("Nicho")]
        ApenasPortas = 3,

        [Description("Comoda")]
        ApenasGavetas = 4

    }
}
