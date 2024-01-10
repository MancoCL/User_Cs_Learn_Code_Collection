using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Product_Factory
{
    internal class Program
    {
        static void Main(string[] args)
        {
            ProductFactory productFactory = new ProductFactory();
            WrapFactroy wrapFactroy = new WrapFactroy();
            Logger logger = new Logger();

            //封装委托
            Func<Product> Milk = new Func<Product>(productFactory.MakeMilk); 
            Func<Product> Car = new Func<Product>(productFactory.MakeCar);
            Action<Product> Log = new Action<Product>(logger.Log);

            //调用委托
            Box box1 = wrapFactroy.WrapProduct(Milk, Log);
            Box box2 = wrapFactroy.WrapProduct(Car, Log);

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
        public Box WrapProduct(Func<Product> wrap_product,Action<Product> log) 
        {
            Box box = new Box();

            //获取产品
            Product product = wrap_product.Invoke();

            if (product.Price > 100)
            { 
                log(product);
            }

            //包装产品
            box.Product = product;

            //返回包装完成的产品
            return box;
        }
    }

    //生产工厂类
    public class ProductFactory 
    {
        public Product MakeMilk() 
        {
            Product product = new Product
            {
                Name = "Milk",
                Price = 2,
            };
            return product;
        }

        public Product MakeCar()
        {
            Product product = new Product
            {
                Name = "Car",
                Price = 50000,
            };
            return product;

        }

    }

    public class Logger
    {
        public void Log(Product product)
        {
            System.Console.WriteLine("Product:'{0}',Price:'{1}',Created at '{2}'.", product.Name, product.Price, DateTime.UtcNow);
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
