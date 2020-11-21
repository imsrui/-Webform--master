using System;

namespace Model
{
    public class FriendShips 
    {
        public Guid FriendShips_Id { get; set; } = Guid.NewGuid();

        public int FriendShips_DeleteId { get; set; } = 1;

        public DateTime FriendShips_CreateTime { get; set; } = DateTime.Now;
        public DateTime FriendShips_UpdateTime { get; set; } = DateTime.Now;
        public string FriendShips_Title { get; set; }
        public string FriendShips_Link { get; set; }
    }
}