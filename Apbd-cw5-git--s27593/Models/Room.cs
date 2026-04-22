namespace Apbd_cw5_git__s27593.Models;

public class Room
{
    public static List<Room> roomslist = new List<Room>();
    
    public int Id { get; set; }
    public String Name { get; set; }
    public int BuildingCode { get; set; }
    public int Floor { get; set; }
    public int Capacity { get; set; }
    public bool hasProjector { get; set; }
    public bool isActive { get; set; }

    public Room(int id, string name, int buildingCode, int floor, int capacity, bool hasProjector, bool isActive)
    {
        Id = id;
        Name = name;
        BuildingCode = buildingCode;
        Floor = floor;
        Capacity = capacity;
        this.hasProjector = hasProjector;
        this.isActive = isActive;
        roomslist.Add(this);
    }

    public Room()
    {
        
    }
}