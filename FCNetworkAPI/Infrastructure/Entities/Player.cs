using AutoMapper;

namespace FCNetwork.Infrastructure.Entities
{
    public class Player
    {
        public string Id { get; set; }
        public string? DeviceId { get; set; }
        public Device? Device { get; set; }
        public string? GameTag { get; set; }
        public SocialProfile? SocialProfile { get; set; }
        
     //   public List<string>? FriendIds { get; set; }  // IDs of friends
        //public List<Post>? Posts { get; set; }  // Posts made by the player
    }
}
