using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Gifts_ServerSide.Models.DAL;

namespace Gifts_ServerSide.Models
{
    public class Items
    {
        int id;
        string name;
        string description;
        string image;
        int price;
        string category;

        public Items(int id, string name, string description, string image, int price, string category)
        {
            Id = id;
            Name = name;
            Description = description;
            Image = image;
            Price = price;
            Category = category;
        }

        public Items() { }

        public int Id { get => id; set => id = value; }
        public string Name { get => name; set => name = value; }
        public string Description { get => description; set => description = value; }
        public string Image { get => image; set => image = value; }
        public int Price { get => price; set => price = value; }
        public string Category { get => category; set => category = value; }

        public int Insert()
        {
            DataServices ds = new DataServices();
            return ds.Insert(this);
        }
    }
}