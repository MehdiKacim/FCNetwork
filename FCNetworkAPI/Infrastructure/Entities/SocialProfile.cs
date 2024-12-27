using System.ComponentModel.DataAnnotations.Schema;

namespace FCNetwork.Infrastructure.Entities
{
    public class SocialProfile
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public string Id { get; set; }
        
        public string? Bio { get; set; }
        public string? ProfileImageBase64 { get; set; }
        public string? PreferredPosition { get; set; } // Preferred in-game position
        public string? FavoriteTeam { get; set; } // Favorite real-world team
        public string? PreferredFormations { get; set; }

    }
}
