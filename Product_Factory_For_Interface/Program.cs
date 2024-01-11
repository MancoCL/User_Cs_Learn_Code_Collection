using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Product_Factory_For_Interface
{
    internal class Program
    {
        static void Main(string[] args)
        {
            IProductFactory milkFactory = new MilkFactory();
            IProductFactory carFactory = new CarFactory();
            WrapFactroy wrapFactroy = new WrapFactroy();

            //调用接口
            Box box1 = wrapFactroy.WrapProduct(milkFactory);
            Box box2 = wrapFactroy.WrapProduct(carFactory);

            //打印输出box中的物品
            System.Console.WriteLine(box1.Product.Name.ToString());
            System.Console.WriteLine(box2.Product.Name.ToString());

            //pause
            System.Console.ReadKey();
        }
    }

    //包装厂类
    public class WrapFactroy
    {
        //包装产品的委托方法
        public Box WrapProduct(IProductFactory productFactory)
        {
            Box box = new Box();

            //获取产品
            Product product = productFactory.MakeProduct();

            //包装产品
            box.Product = product;

            //返回包装完成的产品
            return box;
        }
    }

    public interface IProductFactory 
    {
        Product MakeProduct();
    }

    //牛奶工厂接口实现
    class MilkFactory : IProductFactory
    {
        public Product MakeProduct()
        {
            Product product = new Product
            {
                Name = "Milk",
                Price = 2,
            };
            return product;
        }
    }

    //汽车工厂接口实现
    class CarFactory : IProductFactory
    {
        public Product MakeProduct()
        {
            Product product = new Product
            {
                Name = "Car",
                Price = 50000,
            };
            return product;
        }
    }

    //产品类
    public class Product
    {
        public string Name { get; set; }
        public double Price { get; set; }
    }

    //包装盒类
    public class Box
    {
        public Product Product { get; set; }
    }
}
