using Business.Concrete;
using DataAccess.Concrete.EntityFrameWorks;
using Entity.Concrete;
using System;

namespace ConsoleUI
{
    class Program
    {
        static void Main(string[] args)
        {
            //carControl();

            //brandAdd();
            //colorAdd();
            // colorDelete();
            
            

        }

        private static void colorDelete()
        {
            ColorManager colorManager = new ColorManager(new EfColorDal());
           
        }

        private static void colorAdd()
        {
            ColorManager colorManager = new ColorManager(new EfColorDal());

            Color color = new Color() { ColorId = 8, ColorName = "kahverengi" };

            colorManager.Add(color);
        }

        private static void brandAdd()
        {
            BrandManager brandManager = new BrandManager(new EfBrandDal());
            brandManager.Add(new Brand {  BrandName = "polo" });
            
        }

        private static void carControl()
        {
            CarManager carManager = new CarManager(new EfCarDal());

            foreach (var car in carManager.GetAll().Data)
            {
                Console.WriteLine(car.DailyPrice);
            }
        }
    }
}
