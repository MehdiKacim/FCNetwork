using System.ComponentModel.DataAnnotations.Schema;

namespace FCNetwork.Infrastructure.Entities
{
    public class Device
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public string Id { get; set; }
        public string Name { get; set; }
        public string? ImageBase64 { get; set; }
    }
}
