﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web;

namespace ShipIt.Models.ApiModels
{
    public class PackingLine
    {
        public String gtin { get; set; }
        public String productName { get; set; }
        public int quantity { get; set; }
        public double gtinWeight { get; set; }
        public double packingLineWeight { get; set; }

        public PackingLine(OrderLine orderLine, string name, double weight)
        {
            gtin = orderLine.gtin;
            productName = name;
            quantity = orderLine.quantity;
            gtinWeight = weight;
            packingLineWeight = weight * quantity;
        }

    }
}