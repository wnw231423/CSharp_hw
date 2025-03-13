using System;
using System.Collections;

namespace Assignment3 {
    public interface Shape {
        bool isValid();
        double getArea();
    }

    public class Triangle: Shape {
        public double s1, s2, s3;
        
        public Triangle(double s1, double s2, double s3) { 
            this.s1 = s1;
            this.s2 = s2;
            this.s3 = s3;
        }

        public bool isValid() {
            return (s1 + s2) > s3 && (s1 + s3) > s2 && (s2 + s3) > s1;
        }

        public double getArea() {
            if (!this.isValid())
            {
                throw new InvalidOperationException("unable to get the area of an invalid shape");
            }
            double p = (s1 + s2 + s3) / 2;
            return Math.Sqrt(p * (p - s1) * (p - s2) * (p - s3));
        }
        public override string ToString()
        {
            return $"Triangle [Sides: {s1}, {s2}, {s3}, Area: {getArea()}]";
        }
    }

    public class Rectangle : Shape {
        public double height, width;
        
        public Rectangle(double height, double width) {
            this.height = height;
            this.width = width;
        }

        public bool isValid() {
            return width >= 0 && height >= 0;
        }

        public double getArea() {
            if (!this.isValid())
            {
                throw new InvalidOperationException("unable to get the area of an invalid shape");
            }
            return height * width;
        }
        public override string ToString()
        {
            return $"Rectangle [Height: {height}, Width: {width}, Area: {getArea()}]";
        }
    }

    public class Square : Rectangle {
        public Square(double s): base(s, s) {}
        public override string ToString()
        {
            return $"Square [Side: {height}, Area: {getArea()}]";
        }
    }

    public class ShapeFactory {
        private static Random random = new Random();

        public static List<Shape> getShapes(int n) {
            List<Shape> shapes = new List<Shape>();

            for (int i = 0; i < n; i++)
            {
                int shapeType = random.Next(0, 3); // 0: Triangle, 1: Rectangle, 2: Square

                switch (shapeType)
                {
                    case 0:
                        double s1 = random.Next(1, 10);
                        double s2 = random.Next(1, 10);
                        double s3 = random.Next(1, 10);
                        shapes.Add(new Triangle(s1, s2, s3));
                        break;

                    case 1:
                        double height = random.Next(1, 10);
                        double width = random.Next(1, 10);
                        shapes.Add(new Rectangle(height, width));
                        break;

                    case 2:
                        double side = random.Next(1, 10);
                        shapes.Add(new Square(side));
                        break;
                }
            }

            return shapes;
        }
    }

    public class Program { 
        public static void Main(string[] args)
        {
            var shapes = ShapeFactory.getShapes(10);
            double total_area = 0;
            foreach (Shape shape in shapes) { 
                Console.WriteLine(shape.ToString());
                total_area += shape.getArea();
            }
            Console.WriteLine($"Total area is {total_area}");
        }
    }
}