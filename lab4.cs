using System;

// ===== Money =====
class Money
{
    private int first;
    private int second;

    public Money(int f, int s)
    {
        first = f;
        second = s;
    }

    public int this[int index]
    {
        get
        {
            if (index == 0) return first;
            if (index == 1) return second;
            throw new Exception("Невірний індекс");
        }
        set
        {
            if (index == 0) first = value;
            else if (index == 1) second = value;
            else throw new Exception("Невірний індекс");
        }
    }

    public static Money operator ++(Money m)
    {
        m.first++;
        m.second++;
        return m;
    }

    public static Money operator --(Money m)
    {
        m.first--;
        m.second--;
        return m;
    }

    public static bool operator !(Money m)
    {
        return m.second != 0;
    }

    public static Money operator +(Money m, int value)
    {
        return new Money(m.first, m.second + value);
    }

    public static implicit operator string(Money m)
    {
        return $"{m.first},{m.second}";
    }

    public static explicit operator Money(string s)
    {
        var parts = s.Split(',');
        return new Money(int.Parse(parts[0]), int.Parse(parts[1]));
    }

    public void Show()
    {
        Console.WriteLine($"Money: {first}, {second}");
    }
}

// ===== Vector =====
class Vector
{
    private double[] arr;

    public Vector(int size)
    {
        arr = new double[size];
    }

    public int Size => arr.Length;

    public double this[int i]
    {
        get => arr[i];
        set => arr[i] = value;
    }

    public static Vector operator +(Vector a, Vector b)
    {
        int size = Math.Max(a.Size, b.Size);
        Vector res = new Vector(size);

        for (int i = 0; i < Math.Min(a.Size, b.Size); i++)
            res[i] = a[i] + b[i];

        return res;
    }

    public static Vector operator +(Vector a, double k)
    {
        Vector res = new Vector(a.Size);

        for (int i = 0; i < a.Size; i++)
            res[i] = a[i] + k;

        return res;
    }

    public static bool operator ==(Vector a, Vector b)
    {
        if (a.Size != b.Size) return false;

        for (int i = 0; i < a.Size; i++)
            if (a[i] != b[i]) return false;

        return true;
    }

    public static bool operator !=(Vector a, Vector b)
    {
        return !(a == b);
    }

    public void Show()
    {
        foreach (var x in arr)
            Console.Write(x + " ");
        Console.WriteLine();
    }
}

// ===== Person =====
struct Person
{
    public string Name;
    public int Year;
    public double Height;
    public double Weight;
}

// ===== MatrixLong =====
class MatrixLong
{
    protected long[,] LongArray;
    protected uint n, m;
    protected int codeError;
    protected static int num_m;

    public MatrixLong(uint n, uint m)
    {
        this.n = n;
        this.m = m;
        LongArray = new long[n, m];
        num_m++;
    }

    public long this[int i, int j]
    {
        get
        {
            if (i >= 0 && i < n && j >= 0 && j < m)
                return LongArray[i, j];

            codeError = -1;
            return 0;
        }
        set
        {
            if (i >= 0 && i < n && j >= 0 && j < m)
                LongArray[i, j] = value;
            else
                codeError = -1;
        }
    }

    public void Show()
    {
        for (int i = 0; i < n; i++)
        {
            for (int j = 0; j < m; j++)
                Console.Write(LongArray[i, j] + " ");
            Console.WriteLine();
        }
    }
}

// ===== MAIN =====
class Program
{
    static void Main()
    {
        // ===== Money =====
        Console.WriteLine("=== Money ===");
        Money m = new Money(10, 5);
        m.Show();

        m++;
        m.Show();

        m = m + 3;
        m.Show();

        string s = m;
        Console.WriteLine("String: " + s);

        Money m2 = (Money)s;
        m2.Show();

        Console.WriteLine("!Money: " + (!m));

        // ===== Vector =====
        Console.WriteLine("\n=== Vector ===");
        Vector v1 = new Vector(3);
        Vector v2 = new Vector(3);

        for (int i = 0; i < 3; i++)
        {
            v1[i] = i + 1;
            v2[i] = (i + 1) * 2;
        }

        Vector v3 = v1 + v2;
        v3.Show();

        // ===== Person =====
        Console.WriteLine("\n=== Person ===");
        Person p = new Person
        {
            Name = "Іван",
            Year = 2000,
            Height = 180,
            Weight = 75
        };

        Console.WriteLine($"{p.Name}, {p.Year}, {p.Height}, {p.Weight}");

        // ===== Matrix =====
        Console.WriteLine("\n=== Matrix ===");
        MatrixLong matrix = new MatrixLong(2, 2);

        matrix[0, 0] = 1;
        matrix[0, 1] = 2;
        matrix[1, 0] = 3;
        matrix[1, 1] = 4;

        matrix.Show();
    }
