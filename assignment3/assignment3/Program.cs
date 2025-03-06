using System;

namespace Assignment3 {
    public interface Pattern {
        bool isValid();
        double getArea();
    }

    public class Triangle: Pattern {
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
            double p = (s1 + s2 + s3) / 2;
            return Math.Sqrt(p * (p - s1) * (p - s2) * (p - s3));
        }
    }

    public class Rectangle : Pattern {
        public double height, weight;
        
        public Rectangle(double height, double weight) {
            this.height = height;
            this.weight = weight;
        }

        public bool isValid() {
            return weight >= 0 && height >= 0;
        }

        public double getArea() { 
            return height * weight;
        }
    }

    public class Square : Rectangle {
        public Square(double s): base(s, s) {}
    }

    public static class PatternFactory { 
        
    }
}