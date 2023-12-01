using System;

namespace Shape
{
    class Program
    {
        static void Main(string[] args)
        {
            Shape[] shapes = [new Circle(4), new Isoscelestriangle(8, 4), new Quadrate(25), new Equilateraltriangle(5)];
            foreach (Shape shape in shapes)
            {
                Console.WriteLine();
                shape.Info();
                Console.WriteLine("Периметр: {0}", shape.Perimeter());
                Console.WriteLine("Площадь: {0}", shape.Square());
                Console.WriteLine("Радиус вписанной окружности: {0}", shape.Ring());
                shape.Rotate();
                shape.Ring();
            }
            Console.WriteLine("\nФигуры до сортировки по радиусу вписанной окружности");
            foreach (var shape in shapes)
            {
                Console.WriteLine(shape.ToString());
            }
            Array.Sort(shapes);
                Console.WriteLine("\nФигуры отсортированы по радиусу вписанной окружности");
                foreach (var shape in shapes)
                {
                Console.WriteLine(shape.ToString()); 
                }
        }
    }
    public abstract class Shape : IComparable<Shape>
    {
        public abstract void Info();
        public abstract double Perimeter();
        public abstract double Square();
        public abstract double Ring();
        public virtual void Rotate()
        { }
        public int CompareTo(Shape other)
        {
            return Ring().CompareTo(other.Ring());
        }
      }
    class Circle : Shape
    {
        protected double r;
         public Circle(double r)
        {
            this.r = r;
        }
        public override void Info()
        {
            Console.WriteLine(" Окружность с радиусом  r = {0}", r);
        }
        public override double Perimeter()
        {
            return 2 * 3.14 * r;
        }
        public override double Square()
        {
            return 3.14 * r * r;
        }
        public override double Ring()
        {
             return r;
        }
    }
    class Isoscelestriangle : Shape
    {
        protected double a, b;
        public Isoscelestriangle(double a, double b)
        {
            this.a = a;
            this.b = b;
        }
        public override void Info()
        {
            Console.WriteLine("Равнобедренный треугольник со сторонами а = {0}, b = {1}", a, b);
        }
        public override double Perimeter()
        {
            return a + b + b;
        }
        public override double Square()
        {
            double h = (4 * a * a - b * b) / 2;
            return b * h / 2;
        }
        public override double Ring()
        {
            double p = a + b + b;
            return (b * (4 * a * a - b * b) / 2 / 2) / p;
        }
         public override void Rotate() { Console.WriteLine("Фигура совершила вращение вокруг своего центра"); }
    }
    class Quadrate : Shape
    {
        protected double d;
        public Quadrate(double d)
        {
            this.d = d;
        }
        public override void Info()
        {
            Console.WriteLine("Квадрат со стороной d = {0}", d);
        }
        public override double Perimeter()
        {
            return d + d + d + d;
        }
        public override double Square()
        {
            return d * d;
        }
        public override double Ring()
        {
            return d / 2;
        }
        public override void Rotate() { Console.WriteLine("Фигура совершила вращение вокруг своего центра"); }
        }

    class Equilateraltriangle : Shape
    {
        protected double v;
        public Equilateraltriangle(double v)
        {
            this.v = v;
        }
        public override void Info()
        {
            Console.WriteLine("Равносторонний треугольник со стороной v = {0}", v);
        }
        public override double Perimeter()
        {
            return v * 3;
        }
        public override double Square()
        {
            double p = v * 3  / 2;
            return Math.Sqrt(3) * v * v / 4;
        }
        public override double Ring() 
        {
            return v / (Math.Sqrt(3) * 2);
        }
    }
}