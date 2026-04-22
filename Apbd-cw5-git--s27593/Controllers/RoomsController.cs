using Apbd_cw5_git__s27593.Models;
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

    [HttpGet("{id}")]
    public Room GetRoom(int id)
    {
        return Room.roomslist[id];
    }
}