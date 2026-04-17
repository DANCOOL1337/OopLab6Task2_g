using System;

namespace OopLab6
{
    class LineSegment
    {
        
        private double x;
        private double y;

        
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

        // --- (Задание 3) ---

        
        public static LineSegment operator !(LineSegment s)
        {
            double newX = s.x;
            double newY = s.y;

            if (newX > newY)
            {
               

                if (0 <= newY) newX = 0;
                
                else if (newX <= 0) newY = 0;
                
                else { newX = 0; newY = 0; }
            }
            return new LineSegment(newX, newY);
        }

        
        public static implicit operator int(LineSegment s)
        {
            return (int)s.y;
        }

        
        public static explicit operator double(LineSegment s)
        {
            return s.x;
        }

        
        public static LineSegment operator +(LineSegment s, 
            int val)
        {
            LineSegment res = new LineSegment(s.x + val, s.y);
            
            if (res.x > res.y) { double t = res.x; res.x = 
                    res.y; res.y = t; }
            return res;
        }

        
        public static LineSegment operator +(int val,
            LineSegment s)
        {
            LineSegment res = new LineSegment(s.x, s.y + val);
            if (res.x > res.y) 
            { double t = res.x; res.x = res.y; res.y = t; }
            return res;
        }

        
        public static bool operator >(LineSegment left,
            LineSegment right)
        {
            double lMin = Math.Min(left.x, left.y);
            double lMax = Math.Max(left.x, left.y);
            double rMin = Math.Min(right.x, right.y);
            double rMax = Math.Max(right.x, right.y);
            return (lMin <= rMin) && (lMax >= rMax);
        }

        
        public static bool operator <(LineSegment left,
            LineSegment right)
        {
            return !(left > right);
        }

        public override string ToString()
        {
            return $"[{this.x}; {this.y}]";
        }
    }
}
