using System;
using System.Collections.Generic;


    class Programm
    {
        public static void ShowMessage(object sender, MyEventArgs m)
        {
            Console.WriteLine("{0}: {1}", sender, m.EventMessage);
        }
        static void Main(string[] args)
        {
            Complex.ZeroDiv += ShowMessage;
        Complex complex1 = new Complex(5, 1);
            Complex complex2 = new Complex(1, 2);
            Complex complex3 = new Complex(3,2);
            var list1 = new List<Complex>() { complex1, complex2 };
            var list2 = new List<Complex>() { complex1, complex3 };
            var vector1 = new Vector<Complex>(new ComplexICalcRealisation(), list1);
            var vector2 = new Vector<Complex>(new ComplexICalcRealisation(), list2);
            var vector3 = new Vector<int>(new IntICalcRealisation());
            vector3.Add(2);
            vector3.Add(2);
            vector3.Add(-1);
        vector3.Add(6);
        var vector4 = new Vector<int>(new IntICalcRealisation());
        vector4.Add(5);
        vector4.Add(3);
        vector4.Add(1);
        vector4.Add(5);
        Console.WriteLine("модуль числа А: ");
        Console.WriteLine(complex1.Module());
        Console.WriteLine("A + B = {0}",complex1 + complex2);

        Console.WriteLine(vector3.Module());
            Console.WriteLine("скалярное произведение 3 и 4 векторов: {0}",vector3.Scalar_vector(vector4));
            List<Vector<int>> test = new List<Vector<int>>() { vector3, vector4 };
       
            var result = (Vector<int>.Ortogon(test));
            
            Console.WriteLine("vec1+vec2 = {0}",vector1 + vector2);

            Console.WriteLine("vec1: {0}",vector1.ToString());
            Console.ReadKey();

          }
    }
