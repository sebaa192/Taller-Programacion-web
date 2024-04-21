using Microsoft.AspNetCore.Identity;

namespace almacen.Models
{
    public class ApplicationUser:IdentityUser
    {
        public string Nombre { get; set; }
    }
}
