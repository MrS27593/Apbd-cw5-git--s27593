using System.ComponentModel.DataAnnotations;

namespace Apbd_cw5_git__s27593.Models;

public class Room
{
    public static List<Room> roomslist = new List<Room>();
    public static int MaxCapacity = 5000;
    public static int MinCapacity = 10;
    public static int MaxBuldingCode = 10;
    public static int MinBuldingCode = 1;
    public static int MaxFloors = 6;
    public static int MinFloors = -1;
    [Required]
    [Range(1, 100)]
    public int Id { get; set; }
    [Required]
    public String Name { get; set; }
    [Required]
    [Range(1, 10)]
    public int BuildingCode { get; set; }
    [Required]
    [Range(-1, 6)]
    public int Floor { get; set; }
    [Required]
    [Range(10, 5000)]
    public int Capacity { get; set; }
    [Required]
    public bool hasProjector { get; set; }
    [Required]
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