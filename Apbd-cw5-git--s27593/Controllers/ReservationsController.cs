using Apbd_cw5_git__s27593.Models;
using Microsoft.AspNetCore.Mvc;
namespace Apbd_cw5_git__s27593.Controllers;
[ApiController]
[Route("api/[controller]")]
public class ReservationsController : ControllerBase
{
    private List<Reservation> _reservations = new List<Reservation>();
    [HttpGet]
    public IActionResult GetAll()
    {
        return Ok(_reservations);
    }
    [HttpGet("{id}")]
    public IActionResult GetById(int id)
    {
        var res = _reservations.FirstOrDefault(r => r.Id == id);
        if (res == null)
            return NotFound();
        return Ok(res);
    }
    [HttpPost]
    public IActionResult Create([FromBody] Reservation res)
    {
        var room = Room.roomslist.FirstOrDefault(r => r.Id == res.RoomId);
        if (room == null)
            return NotFound("Room does not exist");
        if (!room.isActive)
            return BadRequest("Room is inactive");
        var conflict = _reservations.Any(r =>
            r.RoomId == res.RoomId &&
            r.Date.Date == res.Date.Date &&
            res.StartTime < r.EndTime &&
            res.EndTime > r.StartTime);
        if (conflict)
            return Conflict("Reservation conflict");
        _reservations.Add(res);
        return Created($"/api/reservations/{res.Id}", res);
    }
    [HttpPut("{id}")]
    public IActionResult Update(int id, [FromBody] Reservation updated)
    {
        var res = _reservations.FirstOrDefault(r => r.Id == id);
        if (res == null)
            return NotFound();
        res.RoomId = updated.RoomId;
        res.Topic = updated.Topic;
        res.OrganizerName = updated.OrganizerName;
        res.Date = updated.Date;
        res.StartTime = updated.StartTime;
        res.EndTime = updated.EndTime;
        res.status = updated.status;
        return Ok(res);
    }
}