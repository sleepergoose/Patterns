using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

/// <summary>
/// Паттерн Прототип (Prototype) позволяет создавать объекты на основе уже ранее 
/// созданных объектов-прототипов. То есть по сути данный паттерн предлагает 
/// технику клонирования объектов.
/// </summary>
namespace Patterns.CreationalPatterns
{
    /// <summary>
    /// Using
    /// </summary>
    public static class Prototype
    {
        public static void Test()
        {
            IShape circle = new Circle(10, 20, 30);
            IShape clonedCircle = circle.Clone();
            circle.Info();
            clonedCircle.Info();

            IShape triangle = new Triangle(x1: 0, y1: 0, x2: 100, y2: 100);
            IShape clonedTriangle = triangle.Clone();
            triangle.Info();
            clonedTriangle.Info();
        }

    }


    /// <summary>
    /// Prototype Interface
    /// </summary>
    public interface IShape
    {
        IShape Clone();
        void Info();
    }

    /// <summary>
    /// ConcretePrototype 1 
    /// </summary>
    public class Circle : IShape
    {
        public int CenterX { get; private set; }
        public int CenterY { get; private set; }
        public int Radius { get; private set; }

        public Circle(int centerX, int centerY, int radius)
        {
            this.CenterX = centerX;
            this.CenterY = centerY;
            this.Radius = radius;
        }
        public IShape Clone()
        {
            return this.MemberwiseClone() as IShape;
        }

        public void Info()
        {
            Console.WriteLine($"Circle: X = {CenterX}; Y = {CenterY}; R = {Radius};");
        }
    }

    /// <summary>
    /// ConcretePrototype 2 
    /// </summary>
    public class Triangle : IShape
    {
        public int X1 { get; private set; }
        public int Y1 { get; private set; }
        public int X2 { get; private set; }
        public int Y2 { get; private set; }

        public Triangle(int x1, int y1, int x2, int y2)
        {
            this.X1 = x1;
            this.Y1 = y1;
            this.X2 = x2;
            this.Y1 = y1;
        }
        public IShape Clone()
        {
            return this.MemberwiseClone() as IShape;
        }

        public void Info()
        {
            Console.WriteLine($"Triangle: X1 = {X1}; Y1 = {Y1}; X2 = {X2}; Y2 = {Y2};");
        }
    }
}
