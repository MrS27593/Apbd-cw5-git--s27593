using Apbd_cw5_git__s27593.Models;
using Apbd_cw5_git__s27593.Services;
using Microsoft.AspNetCore.Mvc;
namespace Apbd_cw5_git__s27593.Controllers;
[ApiController]
[Route("api/[controller]")]
public class RoomsController : ControllerBase
{
    private List<Room> _rooms = new List<Room>();
    [HttpGet]
    public IActionResult GetAllRooms()
    {
        var list = new List<Room>();
        list.Add(new Room(1,"Aula A",2,0,1000,true,true));
        list.Add(new Room(2,"Aula B",1,1,2000,true,false));
        list.Add(new Room(3,"Sala 243C",2,4,50,false,true));
        if (Room.roomslist.Count < 0)
        {
            return NotFound();
        }
        return Ok(Room.roomslist);
    }
    [HttpGet("/easy")]
    public IActionResult GetAllRoomsEasier()
    {
        return Ok(_rooms);
    }
    [HttpPost()]
    public IActionResult CreateRoom([FromBody]Room room)
    {
        _rooms.Add(room);
        return Ok(_rooms);
    }
    //Convention over configuration
    [HttpGet("/{idRoom}")]
    public IActionResult GetRoomByidRoom(int idRoom, string name)
    {
        //api/rooms/1?name=Name
        var room = _rooms.FirstOrDefault(r => r.Id == idRoom); 
        //First(first if not then EXC), Single(one if not EXC), FirstOrDefault(first or null), SingleOrDefault(one if not null)
        if (room == null)
        {
            return NotFound("Room not found");
        }
        return Ok(_rooms.FirstOrDefault(x => x.Id == idRoom));
    }
    private readonly IRoomService _roomService;
    public RoomsController(IRoomService roomService)
    {
        _roomService = roomService;
    }
    [HttpGet("building/{buildingCode}")]
    public IActionResult GetByBuilding(int buildingCode)
    {
        var rooms = _rooms.Where(r => r.BuildingCode == buildingCode).ToList();
        return Ok(rooms);
    }
    [HttpGet("filter")]
    public IActionResult GetFiltered(
        [FromQuery] int? minCapacity,
        [FromQuery] bool? hasProjector,
        [FromQuery] bool? activeOnly)
    {
        var query = _rooms.AsQueryable();
        if (minCapacity.HasValue)
            query = query.Where(r => r.Capacity >= minCapacity);
        if (hasProjector.HasValue)
            query = query.Where(r => r.hasProjector == hasProjector);
        if (activeOnly == true)
            query = query.Where(r => r.isActive);
        return Ok(query.ToList());
    }
    [HttpPut("{id}")]
    public IActionResult Update(int id, [FromBody] Room updated)
    {
        var room = _rooms.FirstOrDefault(r => r.Id == id);
        if (room == null)
            return NotFound();
        room.Name = updated.Name;
        room.Capacity = updated.Capacity;
        room.BuildingCode = updated.BuildingCode;
        room.Floor = updated.Floor;
        room.hasProjector = updated.hasProjector;
        room.isActive = updated.isActive;
        return Ok(room);
    }
    [HttpDelete("{id}")]
    public IActionResult Delete(int id)
    {
        var room = _rooms.FirstOrDefault(r => r.Id == id);
        if (room == null)
            return NotFound();
        _rooms.Remove(room);
        return NoContent();
    }
}