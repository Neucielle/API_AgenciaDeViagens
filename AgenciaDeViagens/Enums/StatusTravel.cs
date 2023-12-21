using System.ComponentModel;

namespace AgenciaDeViagens.Enums
{
    public enum StatusTravel
    {
        [Description("Compra não Realizada")]
        AFazer = 1,
        [Description("Compra em Andamento")]
        EmAndamento = 2,
        [Description("Compra Finalizada")]
        Concluido = 3
    }
}
