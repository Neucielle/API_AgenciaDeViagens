using AgenciaDeViagens.Enums;

namespace AgenciaDeViagens.Models
{
    public class TravelModel
    {
        public int Id { get; set; }
        public string? Destino { get; set; }
         public StatusTravel Status { get; set; }

        public int UserId { get; set; }
        public virtual UserModel User { get; set; } 
    }
}
