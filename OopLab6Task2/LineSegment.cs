using System;

namespace OopLab6
{
    class LineSegment
    {
        // Поля (Задание 2)
        private double x;
        private double y;

        // Свойства без автосвойств (Задание 2)
        public double X
        {
            get { return x; }
            set { x = value; }
        }

        public double Y
        {
            get { return y; }
            set { y = value; }
        }

        // Конструкторы (Задание 2)
        public LineSegment()
        {
            this.x = 0;
            this.y = 0;
        }

        public LineSegment(double x, double y)
        {
            this.x = x;
            this.y = y;
        }

        // Метод пересечения (Задание 2)
        public LineSegment Intersect(LineSegment other)
        {
            if (other == null) return null;

            double s1 = Math.Min(this.x, this.y);
            double e1 = Math.Max(this.x, this.y);
            double s2 = Math.Min(other.x, other.y);
            double e2 = Math.Max(other.x, other.y);

            double intersectStart = Math.Max(s1, s2);
            double intersectEnd = Math.Min(e1, e2);

            if (intersectStart <= intersectEnd)
            {
                return new 
                    LineSegment(intersectStart, intersectEnd);
            }
            return null;
        }

        // --- Перегрузка операций (Задание 3) ---

        // Унарная операция ! (исправление диапазона через 0)
        public static LineSegment operator !(LineSegment s)
        {
            double newX = s.x;
            double newY = s.y;

            if (newX > newY)
            {
                // Пытаемся занулить X.
                // Если 0 <= Y, диапазон станет правильным.

                if (0 <= newY) newX = 0;
                // Иначе пытаемся занулить Y.
                // Если X <= 0, диапазон станет правильным.
                else if (newX <= 0) newY = 0;
                // Если оба варианта не спасают, зануляем оба.
                else { newX = 0; newY = 0; }
            }
            return new LineSegment(newX, newY);
        }

        // Неявное приведение к int (целая часть Y)
        public static implicit operator int(LineSegment s)
        {
            return (int)s.y;
        }

        // Явное приведение к double (координата X)
        public static explicit operator double(LineSegment s)
        {
            return s.x;
        }

        // Бинарная операция + (левосторонняя:
        // отрезок + число = меняем X)
        public static LineSegment operator +(LineSegment s, int val)
        {
            LineSegment res = new LineSegment(s.x + val, s.y);
            // Обеспечиваем правильный диапазон
            if (res.x > res.y) { double t = res.x; res.x = res.y; res.y = t; }
            return res;
        }

        // Бинарная операция + (правосторонняя:
        // число + отрезок = меняем Y)
        public static LineSegment operator +(int val, LineSegment s)
        {
            LineSegment res = new LineSegment(s.x, s.y + val);
            if (res.x > res.y) 
            { double t = res.x; res.x = res.y; res.y = t; }
            return res;
        }

        // Оператор > (левый включает правый)
        public static bool operator >(LineSegment left, LineSegment right)
        {
            double lMin = Math.Min(left.x, left.y);
            double lMax = Math.Max(left.x, left.y);
            double rMin = Math.Min(right.x, right.y);
            double rMax = Math.Max(right.x, right.y);
            return (lMin <= rMin) && (lMax >= rMax);
        }

        // Обязательная пара для >
        public static bool operator <(LineSegment left, LineSegment right)
        {
            return !(left > right);
        }

        public override string ToString()
        {
            return $"[{this.x}; {this.y}]";
        }
    }
}