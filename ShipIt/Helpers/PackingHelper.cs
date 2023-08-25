using System;
using System.Collections.Generic;
using System.Linq;
using ShipIt.Models.ApiModels;

namespace ShipIt.Helpers;

public static class PackingHelper
{
    

    public static List<Truck> createManifest(List<PackingLine> packingLines)
    {
        if (packingLines.Exists(x => x.packingLineWeight > 2000*1000))
        {
            throw new ArgumentException("One line item exceeds 2000kg");
        }
        int minTrucks = minimumTrucks(packingLines);
        List<Truck> Convoy = new List<Truck>();
        for (int i = 0; i < minTrucks; i++)
        {
            Convoy.Add(new Truck(i));
        }

        var packingOrderList = packingLines.OrderByDescending(x => x.packingLineWeight).ToList();
        while (packingOrderList.Count > 0)
        {
            var itemToLoad = packingOrderList[0];
            if(Convoy.Exists(x => x.RemainingCapacity > itemToLoad.packingLineWeight))
            {
                Convoy.OrderBy(x => x.RemainingCapacity).ToList();
                var truckIndex = Convoy.FindIndex(x => x.RemainingCapacity > itemToLoad.packingLineWeight);
                Convoy[truckIndex].addToTruck(itemToLoad);
                packingOrderList.Remove(itemToLoad);
            } else {
                var i = Convoy.Count() - 1;
                Convoy.Add(new Truck(i));
            }

        }
        return Convoy;
    }
    private static int minimumTrucks(List<PackingLine> packingLines)
    {
        var totalOrderWeight = 0.0;
        var trucks = 0;
        foreach (var lineItem in packingLines)
        {
            totalOrderWeight += lineItem.quantity * lineItem.gtinWeight;
        }
        trucks = (int) Math.Ceiling(totalOrderWeight/(2000*1000));
        return trucks;
    }

}