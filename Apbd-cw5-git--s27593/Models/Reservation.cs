namespace Apbd_cw5_git__s27593.Models;

public class Reservation
{
    public int Id { get; set; }
    public int RoomId { get; set; }
    public String OrganizerName { get; set; }
    public String Topic { get; set; }
    public DateTime Date { get; set; }
    public DateTime StartTime { get; set; }
    public DateTime EndTime { get; set; }
    public Status status { get; set; }

    public enum Status
    {
        planned, confirmed, cancelled
    }
}