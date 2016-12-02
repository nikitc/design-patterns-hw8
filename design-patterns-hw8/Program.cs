using System;
using System.Collections.Generic;

namespace design_patterns_hw8
{
    class Program
    {
        private static void Main()
        {
            var figures = new Geometry();
            figures.Add(new Triangle { A = 3, B = 4, C = 5});
            figures.Add(new Rectangle { A = 3, B = 5});
            figures.Add(new Circle { Radius = 15});
            figures.Accept(new AreaVisitor());
            figures.Accept(new PerimeterVisitor());
            figures.Accept(new DrawVisitor());

        }
    }

    public interface IVisitor
    {
        void VisitTriangle(Triangle fugure);
        void VisitRectangle(Rectangle figure);
        void VisitCircle(Circle figure);
    }

    public class AreaVisitor : IVisitor
    {
        public void VisitTriangle(Triangle fugure)
        {
            var semiperimeter = (fugure.A + fugure.B + fugure.C)/2;
            var area =
                Math.Sqrt(semiperimeter*(semiperimeter - fugure.A)*(semiperimeter - fugure.B)*(semiperimeter - fugure.C));

            Console.WriteLine($"Площадь треугольника равна: {area}см");
        }

        public void VisitRectangle(Rectangle figure)
        {
            var area = figure.A * figure.B;
            Console.WriteLine($"Площадь прямоугольника равна: {area}см");
        }

        public void VisitCircle(Circle figure)
        {
            var area = Math.PI*figure.Radius*figure.Radius/2;
            Console.WriteLine($"Площадь окружности равна: {area}см");
        }
    }

    public class PerimeterVisitor : IVisitor
    {
        public void VisitTriangle(Triangle fugure)
        {
            var perimeter = fugure.A + fugure.B + fugure.C;
            Console.WriteLine($"Периметер треугольника равен: {perimeter}см");
        }

        public void VisitRectangle(Rectangle figure)
        {
            var perimeter = 2 * (figure.A + figure.B);
            Console.WriteLine($"Периметер прямоугольника равен: {perimeter}см");
        }

        public void VisitCircle(Circle figure)
        {
            var perimeter = 2 * Math.PI * figure.Radius;
            Console.WriteLine($"Периметер окружности равен: {perimeter}см");
        }
    }

    class DrawVisitor : IVisitor
    {
        public void VisitTriangle(Triangle fugure)
        {
            Console.WriteLine("Рисуем треугольник:");
            Console.WriteLine("       /\\      ");
            Console.WriteLine("      /  \\");
            Console.WriteLine("     /    \\");
            Console.WriteLine("    /      \\");
            Console.WriteLine("   /        \\");
            Console.WriteLine("  /          \\");
            Console.WriteLine(" _______________");
        }

        public void VisitRectangle(Rectangle figure)
        {
            Console.WriteLine("Рисуем прямоугольник:");
            Console.WriteLine("  _________________");
            Console.WriteLine(" |                 |");
            Console.WriteLine(" |                 |");
            Console.WriteLine(" |                 |");
            Console.WriteLine(" |                 |");
            Console.WriteLine(" |                 |");
            Console.WriteLine(" |                 |");
            Console.WriteLine("  _________________");
        }

        public void VisitCircle(Circle figure)
        {
            Console.WriteLine("Рисуем окружность:");
            Console.WriteLine("   _____  ");
            Console.WriteLine("  /    \\ ");
            Console.WriteLine(" /      \\");
            Console.WriteLine("\\       /");
            Console.WriteLine(" \\     / ");
            Console.WriteLine("   -----  ");
        }
    }

    public class Geometry
    {
        private readonly List<IFigure> _figures = new List<IFigure>();
        public void Add(IFigure acc)
        {
            _figures.Add(acc);
        }
        public void Remove(IFigure acc)
        {
            _figures.Remove(acc);
        }
        public void Accept(IVisitor visitor)
        {
            foreach (IFigure figure in _figures)
                figure.Accept(visitor);
        }
    }

    public interface IFigure
    {
        void Accept(IVisitor visitor);
    }

    public class Circle : IFigure
    {
        public int Radius { get; set; }

        public void Accept(IVisitor visitor)
        {
            visitor.VisitCircle(this);
        }
    }

    public class Rectangle : IFigure
    {
        public int A { get; set; }
        public int B { get; set; }

        public void Accept(IVisitor visitor)
        {
            visitor.VisitRectangle(this);
        }
    }

    public class Triangle : IFigure
    {
        public int A { get; set; }
        public int B { get; set; }
        public int C { get; set; }

        public void Accept(IVisitor visitor)
        {
            visitor.VisitTriangle(this);
        }
    }
}
