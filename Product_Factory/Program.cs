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

            //封装委托
            Func<Product> Milk = new Func<Product>(productFactory.MakeMilk); 
            Func<Product> Car = new Func<Product>(productFactory.MakeCar);

            //调用委托
            Box box1 = wrapFactroy.WrapProduct(Milk);
            Box box2 = wrapFactroy.WrapProduct(Car);

            //打印输出box中的物品
            System.Console.WriteLine(box1.Product.Name.ToString());
            System.Console.WriteLine(box2.Product.Name.ToString());

            //pause
            System.Console.ReadKey();
        }
    }

    //产品类
    public class Product
    {
        public string Name { get; set; }
    }
    //包装盒类
    public class Box 
    {
        public Product Product { get; set; }
    }

    //包装厂类
    public class WrapFactroy
    { 
        //包装产品的委托方法
        public Box WrapProduct(Func<Product> wrap_product) 
        {
            Box box = new Box();
            //获取产品
            Product product = wrap_product.Invoke();
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
                Name = "Milk"
            };
            return product;
        }

        public Product MakeCar()
        {
            Product product = new Product
            {
                Name = "Car"
            };
            return product;

        }

    }
}
