using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Day1.Models
{
    public class product
    {
        public int id { get; set; }
        public string name { get; set; }
        public string description { get; set; }
        public decimal price { get; set; }
        public string image { get; set; }
    }
    public class ModelProduct
    {
        List<product> lstpro = new List<product>() { 
        new product{id=1,name="iphone 11",description="ram 16",price=1000,image="1.jpg"},
        new product{id=2,name="iphone 16",description="ram 32",price=2000,image="2.jpg"},
        new product{id=3,name="iphone 10",description="ram 12",price=3000,image="3.jpg"},
        new product{id=4,name="iphone 6",description="ram 8",price=4000,image="4.jpg"},
        new product{id=5,name="iphone 7",description="ram 14",price=5000,image="5.jpg"},
       
        };
        public List<product> GetAll()
        {
            return lstpro;
        }
        public product GetByID(int id)
        {
            return lstpro.Find(a=>a.id==id);
        }
    }
}
