using System.Collections.Generic;

namespace ShipIt.Models.ApiModels
{
    //individual truck model
    public class Truck
    {
        public int TruckID { get; set; }
        public double MaxCapacity { get; set; }
        public double RemainingCapacity { get; set; }
        public double PackedPercentage { get; set; }
        public List<PackingLine> PackingLines  { get; set; }

        public Truck(int index)
        {
            TruckID = index + 1;
            MaxCapacity = 2000*1000;
            RemainingCapacity = MaxCapacity;
            PackingLines = new List<PackingLine>();
            PackedPercentage = 0;
        }

        public void addToTruck(PackingLine packingLine) 
        {
            PackingLines.Add(packingLine);
            RemainingCapacity -= packingLine.packingLineWeight;
            PackedPercentage = (MaxCapacity - RemainingCapacity) / MaxCapacity;
        }
    }
}
