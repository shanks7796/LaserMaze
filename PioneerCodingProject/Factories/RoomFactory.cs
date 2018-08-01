using PioneerCodingProject.Classes;

namespace PioneerCodingProject.Factories
{
    public class RoomFactory
    {
        public Room BuildRoom(int x, int y)
        {
            return new Room(x, y);
        }
    }
}
