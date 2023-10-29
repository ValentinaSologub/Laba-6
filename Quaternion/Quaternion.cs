

    public class Quaternion
    {
        public double W { get; set; }
        public double X { get; set; }
        public double Y { get; set; }
        public double Z { get; set; }

        public Quaternion(double w, double x, double y, double z)
        {
            W = w;
            X = x;
            Y = y;
            Z = z;
        }

        public double Norm()
        {
            return Math.Sqrt(W * W + X * X + Y * Y + Z * Z);
        }

        public Quaternion Conjugate()
        {
            return new Quaternion(W, -X, -Y, -Z);
        }

        public Quaternion Inverse()
        {
            double normSquared = Norm() * Norm();
            if (normSquared == 0)
                throw new InvalidOperationException("Cannot calculate the inverse of a quaternion with zero norm.");

            Quaternion conjugate = Conjugate();
            return new Quaternion(conjugate.W / normSquared, conjugate.X / normSquared, conjugate.Y / normSquared, conjugate.Z / normSquared);
        }

        public static Quaternion operator +(Quaternion a, Quaternion b)
        {
            return new Quaternion(a.W + b.W, a.X + b.X, a.Y + b.Y, a.Z + b.Z);
        }

        public static Quaternion operator -(Quaternion a, Quaternion b)
        {
            return new Quaternion(a.W - b.W, a.X - b.X, a.Y - b.Y, a.Z - b.Z);
        }

        public static Quaternion operator *(Quaternion a, Quaternion b)
        {
            double w = a.W * b.W - a.X * b.X - a.Y * b.Y - a.Z * b.Z;
            double x = a.W * b.X + a.X * b.W + a.Y * b.Z - a.Z * b.Y;
            double y = a.W * b.Y - a.X * b.Z + a.Y * b.W + a.Z * b.X;
            double z = a.W * b.Z + a.X * b.Y - a.Y * b.X + a.Z * b.W;
            return new Quaternion(w, x, y, z);
        }

        public override bool Equals(object obj)
        {
            if (obj is Quaternion other)
            {
                return W == other.W && X == other.X && Y == other.Y && Z == other.Z;
            }
            return false;
        }

        public override int GetHashCode()
        {
            return W.GetHashCode() ^ X.GetHashCode() ^ Y.GetHashCode() ^ Z.GetHashCode();
        }

        public static bool operator ==(Quaternion a, Quaternion b)
        {
            return a.Equals(b);
        }

        public static bool operator !=(Quaternion a, Quaternion b)
        {
            return !a.Equals(b);
        }

        public double[,] ToRotationMatrix()
        {
        double norm = Norm();
        double s = norm > 0 ? 2.0 / norm : 0;

        double wx = s * W * X;
        double wy = s * W * Y;
        double wz = s * W * Z;
        double xx = s * X * X;
        double xy = s * X * Y;
        double xz = s * X * Z;
        double yy = s * Y * Y;
        double yz = s * Y * Z;
        double zz = s * Z * Z;

        return new double[,]
        {
            { 1 - (yy + zz), xy - wz, xz + wy },
            { xy + wz, 1 - (xx + zz), yz - wx },
            { xz - wy, yz + wx, 1 - (xx + yy) }
        };
    }

        public static Quaternion FromRotationMatrix(double[,] matrix)
        {
            if (matrix.GetLength(0) != 3 || matrix.GetLength(1) != 3)
            {
                throw new ArgumentException("Rotation matrix must be 3x3.");
            }

            double m00 = matrix[0, 0];
            double m11 = matrix[1, 1];
            double m22 = matrix[2, 2];
            double trace = m00 + m11 + m22;

            if (trace > 0)
            {
                double S = Math.Sqrt(trace + 1.0) * 2.0;
                double invS = 1.0 / S;
                double x = (matrix[2, 1] - matrix[1, 2]) * invS;
                double y = (matrix[0, 2] - matrix[2, 0]) * invS;
                double z = (matrix[1, 0] - matrix[0, 1]) * invS;
                double w = 0.25 * S;
                return new Quaternion(w, x, y, z);
            }
            else if (m00 > m11 && m00 > m22)
            {
                double S = Math.Sqrt(1.0 + m00 - m11 - m22) * 2.0;
                double invS = 1.0 / S;
                double x = 0.25 * S;
                double y = (matrix[0, 1] + matrix[1, 0]) * invS;
                double z = (matrix[0, 2] + matrix[2, 0]) * invS;
                double w = (matrix[2, 1] - matrix[1, 2]) * invS;
                return new Quaternion(w, x, y, z);
            }
            else if (m11 > m22)
            {
                double S = Math.Sqrt(1.0 + m11 - m00 - m22) * 2.0;
                double invS = 1.0 / S;
                double x = (matrix[0, 1] + matrix[1, 0]) * invS;
                double y = 0.25 * S;
                double z = (matrix[1, 2] + matrix[2, 1]) * invS;
                double w = (matrix[0, 2] - matrix[2, 0]) * invS;
                return new Quaternion(w, x, y, z);
            }
            else
            {
                double S = Math.Sqrt(1.0 + m22 - m00 - m11) * 2.0;
                double invS = 1.0 / S;
                double x = (matrix[0, 2] + matrix[2, 0]) * invS;
                double y = (matrix[1, 2] + matrix[2, 1]) * invS;
                double z = 0.25 * S;
                double w = (matrix[1, 0] - matrix[0, 1]) * invS;
                return new Quaternion(w, x, y, z);
            }
        }
    }


