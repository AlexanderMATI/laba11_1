using System;
    public interface ICalculatable<T> where T: new() 
    {
        T Sum(T a, T b);
        T Sub(T a, T b);
        T Mult(T a, T b);
        T MulOnNumber(T a, double b);
        T Div(T a, T b);
        T Pow(T a, int b);
        T Sqrt(T a);
    int Comp(Vector<T> a, Vector<T> b);
   // int Comp(Vector<T> a, Vector<T> b);

    }

    class IntICalcRealisation : ICalculatable<int>
    {
        public int Sum(int a, int b)
        {
            return a + b;
        }

        public int Sub(int a, int b)
        {
            return a - b;
        }

        public int Mult(int a, int b)
        {
            return a * b;
        }

        public int MulOnNumber(int a, double b)
        {
            int _b = Convert.ToInt32(b);
            return a * _b;
        }

        public int Div(int a, int b)
        {
            return a / b;
        }

        public int Pow(int a, int b)
        {
        return (int)Math.Pow(a,b);
        }

        public int Sqrt(int a)
        {
            return (int) Math.Sqrt(a);
        }
    public int Comp(Vector<int> a, Vector<int> b)
    {
        int a_c = a.Module();
        int b_c = b.Module();
        if (a_c > b_c)
            return 1;
        else
        if (a_c - b_c ==0)
            return 0;
        else return -1;

    }

}

    class DoubleICalcRealisation : ICalculatable<double>
    {
        public double Sum(double a, double b)
        {
            return a + b;
        }

        public double Sub(double a, double b)
        {
            return a - b;
        }

        public double Mult(double a, double b)
        {
            return a * b;
        }

        public double MulOnNumber(double a, double b)
        {
            return a * b;
        }

        public double Div(double a, double b)
        {
            return a / b;
        }

        public double Pow(double a, int b)
        {
            return (double) Math.Pow(a, b);
        }

        public double Sqrt(double a)
        {
            return (double) Math.Sqrt(a);
        }
    public int Comp(Vector<double> a, Vector<double>b)
    {
        double a_c = a.Module();
        double b_c = b.Module();
        if (a_c > b_c)
            return 1;
        else
        if (a.Module() - b.Module() == 0)
            return 0;
        else return -1;

    }
}

class ComplexICalcRealisation : ICalculatable<Complex>
{
    public Complex Sum(Complex a, Complex b)
    {
        return a + b;
    }

    public Complex Sub(Complex a, Complex b)
    {
        return a - b;
    }

    public Complex Mult(Complex a, Complex b)
    {
        return a * b;
    }

    public Complex MulOnNumber(Complex a, double b)
    {
        return a * b;
    }

    public Complex Div(Complex a, Complex b)
    {
        return a / b;
    }

    public Complex Pow(Complex a, int b)
    {
        double temp = a.Module();
        Complex Ctemp = new Complex(temp, 0);
        return a.Pow(b);

    }

    public Complex Sqrt(Complex a)
    {
        return Sqrt(a);
    }
    public int Comp(Vector<Complex> a, Vector<Complex> b)
    {
       Complex a_c = a.Module();
       Complex b_c = b.Module();
        if (a_c > b_c)
            return 1;
        if (a_c < b_c)
            return -1;
        else return 0;




    }
}


