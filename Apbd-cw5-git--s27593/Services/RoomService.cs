using Apbd_cw5_git__s27593.Models;

namespace Apbd_cw5_git__s27593.Services;

public class RoomService : IRoomService
{
    private readonly List<Room> _rooms = new()
    {
        new Room(4, "Sala 253C", 2, 5, 55, true, false),
        new Room(5, "Sala 153", 1, 5, 55, true, false),
    };

    public List<Room> GetRooms()
    {
        return _rooms;
    }

    public void Add(Room room)
    {
        if (room.Id == 0)
        {
            throw new ArgumentNullException("Id of room can not be 0");
        }
        else if(room.Name == null)
        {
            throw new ArgumentNullException("Name of room can not be null");
        }
        else if(!room.hasProjector)
        {
            Console.Write("Be careful this room will not have a projector");
        }
    }
    
}