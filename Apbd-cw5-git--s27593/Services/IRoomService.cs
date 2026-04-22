using Apbd_cw5_git__s27593.Models;

namespace Apbd_cw5_git__s27593.Services;

public interface IRoomService 
{
    public List<Room> GetRooms();
    public void Add(Room room);
}