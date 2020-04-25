using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;


    public class Vector<T> : ICollection<T>, IComparable<Vector<T>>
        where T: new()
{
        private readonly List<T> _vector;
        private readonly ICalculatable<T> _calculator;

       public Vector() { }

        public Vector(ICalculatable<T> iCalc) : this(iCalc, new List<T>()) { }

        public Vector(ICalculatable<T> iCalc, IEnumerable<T> collection)
        {
            this._calculator = iCalc;
            _vector = new List<T>(collection);
        }

        public Vector(ICalculatable<T> iCalc, int n)
        {
            this._calculator = iCalc;
            _vector = new List<T>(n);
        }
    public static Vector<T> SummaVec(Vector<T> left, Vector<T> right)
    {
        var result = new Vector<T>(left._calculator);
        try
        {

            for (int i = 0; i < left.Count; i++)
            {
                T sum = left._calculator.Sum(left[i], right[i]);
                result.Add(sum);

            }
            return result;
        }
        catch (ArgumentNullException e)
        {
            Console.WriteLine("Ошибка! нулевой аргумент");
            if (left == null)
            return new Vector<T>(right._calculator ,0);
            else return new Vector<T>(left._calculator, 0);
        }
       
    }
    public static Vector<T> SubVec(Vector<T> left, Vector<T> right)
    {
        var result = new Vector<T>(left._calculator);
        try
        {

            for (int i = 0; i < left.Count; i++)
            {
                T sum = left._calculator.Sub(left[i], right[i]);
                result.Add(sum);

            }
            return result;
        }
        catch (ArgumentNullException e)
        {
            Console.WriteLine("Ошибка! нулевой аргумент");
            if (left == null)
                return new Vector<T>(right._calculator, 0);
            else return new Vector<T>(left._calculator, 0);
        }

    }
    public static Vector<T> operator +(Vector<T> left, Vector<T> right)//сделать метод который будет вызываться в перегрузке операторов
        {
           
            return SummaVec(left,right);
        }

        public static Vector<T> operator -(Vector<T> left, Vector<T> right)
        {
            
            return SubVec(left,right);
        }
        public static Vector<T> Mult(Vector<T> left, T k)
    {
        if (left == null)
            return new Vector<T>(left._calculator, 0);
        var result = new Vector<T>(left._calculator);

        for (int i = 0; i < left.Count; i++)
        {
            T multi = left._calculator.Mult(left[i], k);
            result.Add(multi);
        }
        return result;
    }

        public static Vector<T> operator *(Vector<T> left, T k)
    { 
            return Mult(left,k);
        }
    public static Vector<T> operator *(T k, Vector<T> left)
    {

        return Mult(left, k);
    }


    public T Module()
        {
        T sum = default(T);
            for (int i = 0; i < _vector.Count; i++)
            {
                T numberInSqrt = _calculator.Pow(_vector[i], 2);
                sum = _calculator.Sum(sum, numberInSqrt);
            }
            T modul = _calculator.Sqrt(sum);
            
            return modul;
        }
    

    public T Scalar_vector(Vector<T> b)
        {
        if (_vector.Count != b.Count)
        {
            Console.WriteLine("вектора разной длины, операция невозможна");
            Environment.Exit(1);
        }
            T skal = default(T);//
            for (int i = 0; i < _vector.Count; i++)
            {
                T multi = _calculator.Mult(_vector[i], b[i]);
                skal = _calculator.Sum(skal, multi);
            }
            return skal;
        }

        public T this[int index]
        {
            get => _vector[index];
            set => _vector[index] = value;
        }
    

    public override string ToString()
        {
        var str = new StringBuilder();
        str.Append("(");
        for (int i = 0; i < _vector.Count; i++)
        {
            str.Append(_vector[i] + ",");
            }
            return str.ToString().TrimEnd(',', ' ') + ")";
        }

        public static List<Vector<T>> Ortogon(List<Vector<T>> vect)
        {
            var n = vect.Count;
            var copyVect = new List<Vector<T>>(vect);
            var sizesimVect = new List<Vector<T>>(n);

            for (int i = 0; i < vect.Count; i++)
            {
                var result = new Vector<T>(copyVect[i]._calculator, copyVect[i].Count);
                if (i == 0)
                {
                    sizesimVect.Insert(i, copyVect[i]);
                }
                else if (i != 0)
                {
                    int j = i;
                    while (j != 0)
                    {
                        try
                        {
                            if (result.Count == 0)
                                result = forOrt(copyVect[i], sizesimVect[j - 1]);
                            else if (result.Count != 0)
                                result = result + (forOrt(copyVect[i], sizesimVect[j - 1]));
                            j--;
                        }
                        catch (ArithmeticException ex)
                        {
                            Console.WriteLine(ex.Message);
                            break;
                        }
                    }
                    sizesimVect.Insert(i, (copyVect[i] - result));
                }
            }
            return sizesimVect;
        }

        public static Vector<T> forOrt(Vector<T> first, Vector<T> second)
        {
            T scalar1_2 = first.Scalar_vector(second);
            T scalar2_1 = second.Scalar_vector(first);
            T temp = first._calculator.Div(scalar1_2, scalar2_1);
            var result = second * temp;
            return result;
        }

        public T[] To_Array()
        {
            T[] array = _vector.ToArray();
            return array;
        }

        public IEnumerator<T> GetEnumerator()
        {
            return _vector.GetEnumerator();
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }

        public void Add(T item)
        {
            _vector.Add(item);
        }

        public void Clear()
        {
            _vector.Clear();
        }

        public bool Contains(T item)
        {
            return _vector.Contains(item);
        }

        public void CopyTo(T[] array, int arrayIndex)
        {
            _vector.CopyTo(array, arrayIndex);
        }

        public bool Remove(T item)
        {
            return _vector.Remove(item);
        }
        public int Count => _vector.Count;
        public bool IsReadOnly => false;

        public int CompareTo(Vector<T> A)
    {
        return  this._calculator.Comp(this, A);

    }
        

    }


