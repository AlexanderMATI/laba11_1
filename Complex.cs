using System;



    public sealed class Complex
    {
        public static EventHandler<MyEventArgs> ZeroDiv;

        private double _re;
        private double _im;

       

        public Complex(double real, double im)
        {
            this._re = real;
            this._im = im;
        }
    public Complex() : this(0, 0) { }
    
        public Complex(double _real) : this(_real, 0) { }



    public static Complex operator +(Complex A, Complex B)
    {
        if (A == null || B == null)
            return new Complex(0, 0);
        else if (A == null) return B;
        else if (B == null) return A;


        var sumre = A._re + B._re;
            var sumim = A._im + B._im;
            return new Complex(sumre, sumim);
        }
        public static Complex operator -(Complex A, Complex B)
        {
        if (A == null || B == null)
            return new Complex(0, 0);
        else if (A == null) return B;
        else if (B == null) return A;
        double subRe = A._re - B._re;
            double subIm = A._im - B._im;
            return new Complex(subRe, subIm);
        }
        public static Complex operator *(Complex A, Complex B)
        {
        if (A == null || B == null)


            return new Complex(0, 0);

        double resRe = A._re * B._re - A._im * B._im;
            double resIm = A._re * B._im + A._im * B._re;
            return new Complex(resRe, resIm);
        }
        public static Complex operator *(Complex A, double k)
        {
        if(A == null )
            return new Complex(0,0);
        return new Complex(A._re * k, A._im * k);
        }
    public static Complex operator *(double k, Complex A)
    {
        if (A == null)
            return new Complex(0, 0);
        return new Complex(A._re * k, A._im * k);
    }
    public static Complex operator /(Complex A, Complex B)
        {
           
            double diver = B._re * B._re + B._im * B._im;
            Complex result = new Complex();
            if (diver == 0)
            {
            if (ZeroDiv != null)
            {
                ZeroDiv(B, new MyEventArgs("  Ошибка! Деление на ноль. Продолжить с нулевым результатом? Иначе - выход из программы. Y/N  "));
                ConsoleKey key = Console.ReadKey().Key;
                if (key == ConsoleKey.Y)
                    result = new Complex(0, 0);
                else Environment.Exit(1);
            }
        }
            else
            {
                result = new Complex((A._re * B._re + A._im * B._im) / diver, (A._im * B._re - A._re * B._im) / diver);
            }
            return result;
        }

        

        public double Module()
        {
            double sumReIm = _re * _re + _im * _im;
            return Math.Sqrt(sumReIm);
        }

        public double Angle()
        {
            return Math.Atan2(_im, _re);
        }
        public static bool operator>(Complex a,Complex b)
    {
        if (a.Module() > b.Module())
            return true;
        else return false;

    }
    public static bool operator <(Complex a, Complex b)
    {
        if (a.Module() < b.Module())
            return true;
        else  return false;

    }

  /*  public static bool operator ==(Complex a, Complex b)
    {
        if (a.Module() == b.Module())
            return true;
        else return false;

    }
    public static bool operator !=(Complex a, Complex b)
    {
        if (!(a.Module() == b.Module()))
            return true;
        else return false;

    }
    public  int Equals(Complex b)
    {
        if (this > b)
            return 1;
        else if (this == b)
            return 0;
        else 
            return -1;
    }*/
    public Complex Pow(double k)
        {
            double modDeg = Math.Pow(Module(), k);
            double angcoef = k * Angle();
            double resRe = modDeg * Math.Cos(angcoef);
            double resIm = modDeg * Math.Sin(angcoef);
            Complex result = new Complex(resRe, resIm);
            return result;
        }

        public Complex[] Root(int n)
        {
            double modinDeg = Math.Pow(Module(), 1 / (double)n);
            double angleWithCoef = Angle() / (double)n;
            double oneRadianInDegree = 57.295;
            Complex[] result = new Complex[n];
            for (int i = 0; i < n; i++)
            {
                result[i] = new Complex();
            }
            for (int i = 0; i < n; i++)
            {
                double degree = 360 * i / ((double)n * oneRadianInDegree);
                result[i]._re = modinDeg * Math.Cos(angleWithCoef + degree);
                result[i]._im = modinDeg * Math.Sin(angleWithCoef + degree);
            }
            return result;
        }

        public override string ToString()
        {
            if (_im == 0)
                return (_re.ToString());
            if (_im > 0)
                return (_re + "+" + _im + "i");

            return (_re.ToString() + _im + "i");
        }

        
    }


public class MyEventArgs : EventArgs
{
    public string EventMessage;
    public MyEventArgs(string message)
    {
        EventMessage = message;
    }

}
