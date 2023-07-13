using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace StoreTest.Models
{
    public class Cart
    {
        private int iD;
        private string name, image;
        private int quality, cost;

        public int ID { get => iD; set => iD = value; }
        public string Name { get => name; set => name = value; }
        public string Image { get => image; set => image = value; }
        public int Quality { get => quality; set => quality = value; }
        public int Cost { get => cost; set => cost = value; }
    }
}