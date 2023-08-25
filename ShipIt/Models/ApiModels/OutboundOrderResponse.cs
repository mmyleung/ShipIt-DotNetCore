﻿using System.Collections.Generic;
using System.Security.Cryptography.X509Certificates;
using System.Linq;

namespace ShipIt.Models.ApiModels
{
    public class OutBoundOrderResponse
    {
        public double ConvoyPackedPercentage { get; set; }
        public List<Truck> Manifest { get; set; }
        
        //Empty constructor required for xml serialization.
        public OutBoundOrderResponse(List<Truck> manifest)
        {
            Manifest = manifest;
            ConvoyPackedPercentage = (manifest.Sum(truck => truck.MaxCapacity) - manifest.Sum(truck => truck.RemainingCapacity)) / manifest.Sum(truck => truck.MaxCapacity);
        }
    }
}