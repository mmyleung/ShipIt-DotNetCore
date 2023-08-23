﻿namespace ShipIt.Models.ApiModels
{
    public class OutBoundOrderResponse
    {
        public int TruckCount { get; set; }

        //Empty constructor required for xml serialization.
        public OutBoundOrderResponse(int truckCount)
        {
            TruckCount = truckCount;
        }
    }
}