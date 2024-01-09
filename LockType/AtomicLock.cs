namespace LockType
{
#if NET48 || NETSTANDARD2_0
#pragma warning disable CS0659 // Typ überschreibt Object.Equals(object o), überschreibt jedoch nicht Object.GetHashCode()
#endif
    public struct AtomicLock<T>
#if NET48 || NETSTANDARD2_0
#pragma warning restore CS0659 // Typ überschreibt Object.Equals(object o), überschreibt jedoch nicht Object.GetHashCode()
#endif
    {
        private T? _value;
        private readonly object _lock = new object();

        public AtomicLock()
        {
            _value = default(T);
        }

        public AtomicLock(T value)
        {
            _value = value;
        }

        public void ExecuteOperation(Func<T, T> operation)
        {
            lock (_lock)
            {
                _value = operation(_value ?? throw new InvalidOperationException("Cannot get value of null"));
            }
        }

        public void UpdateValue(T value)
        {
            lock (_lock)
            {
                _value = value;
            }
        }

        public override bool Equals(object? obj)
        {
            return obj is T val &&
                   EqualityComparer<T?>.Default.Equals(_value, val);
        }

#if NET5_0_OR_GREATER
        public override int GetHashCode()
        {
            return HashCode.Combine(_value);
        }
#endif

        public static implicit operator T(AtomicLock<T> lockedValue)
        {
            lock (lockedValue._lock)
            {
                if (lockedValue._value == null)
                {
                    throw new InvalidOperationException("Cannot get value of null");
                }

                return lockedValue._value;
            }
        }

        public static implicit operator AtomicLock<T>(T value)
        {
            return new AtomicLock<T>(value);
        }

#if NET5_0_OR_GREATER
        public static AtomicLock<T> operator ++(AtomicLock<T> lockedValue)
        {
            lock (lockedValue._lock)
            {
                try
                { 
                    dynamic value = lockedValue._value ?? throw new Exception($"The type {typeof(T).Name} may not be null for this operation");
                    value++;
                    return value;
                }
                catch (Exception)
                {
                    throw new InvalidOperationException($"The type {typeof(T).Name} does not support this operation");
                }
            }
        }

        public static AtomicLock<T> operator --(AtomicLock<T> lockedValue)
        {
            lock (lockedValue._lock)
            {
                try
                {
                    dynamic value = lockedValue._value ?? throw new Exception($"The type {typeof(T).Name} may not be null for this operation");
                    value--;
                    return value;
                }
                catch (Exception)
                {
                    throw new InvalidOperationException($"The type {typeof(T).Name} does not support this operation");
                }
            }
        }

        public static AtomicLock<T> operator ~(AtomicLock<T> lockedValue)
        {
            lock (lockedValue._lock)
            {
                try
                {
                    dynamic value = lockedValue._value ?? throw new Exception($"The type {typeof(T).Name} may not be null for this operation");
                    return ~value;
                }
                catch (Exception)
                {
                    throw new InvalidOperationException($"The type {typeof(T).Name} does not support this operation");
                }
            }
        }

        public static AtomicLock<T> operator !(AtomicLock<T> lockedValue)
        {
            lock (lockedValue._lock)
            {
                try
                {
                    dynamic value = lockedValue._value ?? throw new Exception($"The type {typeof(T).Name} may not be null for this operation");
                    return !value;
                }
                catch (Exception)
                {
                    throw new InvalidOperationException($"The type {typeof(T).Name} does not support this operation");
                }
            }
        }

        public static AtomicLock<T> operator +(AtomicLock<T> lockedValue, AtomicLock<T> anotherLockedValue)
        {
            lock (lockedValue._lock)
            {
                try
                {
                    dynamic value = lockedValue._value ?? throw new Exception($"The type {typeof(T).Name} may not be null for this operation");
                    dynamic anotherValue = anotherLockedValue._value ?? throw new Exception($"The type {typeof(T).Name} may not be null for this operation");
                    return value + anotherValue;
                }
                catch (Exception)
                {
                    throw new InvalidOperationException($"The type {typeof(T).Name} does not support this operation");
                }
            }
        }

        public static AtomicLock<T> operator -(AtomicLock<T> lockedValue, AtomicLock<T> anotherLockedValue)
        {
            lock (lockedValue._lock)
            {
                try
                {
                    dynamic value = lockedValue._value ?? throw new Exception($"The type {typeof(T).Name} may not be null for this operation");
                    dynamic anotherValue = anotherLockedValue._value ?? throw new Exception($"The type {typeof(T).Name} may not be null for this operation");
                    return value - anotherValue;
                }
                catch (Exception)
                {
                    throw new InvalidOperationException($"The type {typeof(T).Name} does not support this operation");
                }
            }
        }

        public static AtomicLock<T> operator *(AtomicLock<T> lockedValue, AtomicLock<T> anotherLockedValue)
        {
            lock (lockedValue._lock)
            {
                try
                {
                    dynamic value = lockedValue._value ?? throw new Exception($"The type {typeof(T).Name} may not be null for this operation");
                    dynamic anotherValue = anotherLockedValue._value ?? throw new Exception($"The type {typeof(T).Name} may not be null for this operation");
                    return value * anotherValue;
                }
                catch (Exception)
                {
                    throw new InvalidOperationException($"The type {typeof(T).Name} does not support this operation");
                }
            }
        }

        public static AtomicLock<T> operator /(AtomicLock<T> lockedValue, AtomicLock<T> anotherLockedValue)
        {
            lock (lockedValue._lock)
            {
                try
                {
                    dynamic value = lockedValue._value ?? throw new Exception($"The type {typeof(T).Name} may not be null for this operation");
                    dynamic anotherValue = anotherLockedValue._value ?? throw new Exception($"The type {typeof(T).Name} may not be null for this operation");
                    return value / anotherValue;
                }
                catch (Exception)
                {
                    throw new InvalidOperationException($"The type {typeof(T).Name} does not support this operation");
                }
            }
        }

        public static AtomicLock<T> operator %(AtomicLock<T> lockedValue, AtomicLock<T> anotherLockedValue)
        {
            lock (lockedValue._lock)
            {
                try
                {
                    dynamic value = lockedValue._value ?? throw new Exception($"The type {typeof(T).Name} may not be null for this operation");
                    dynamic anotherValue = anotherLockedValue._value ?? throw new Exception($"The type {typeof(T).Name} may not be null for this operation");
                    return value % anotherValue;
                }
                catch (Exception)
                {
                    throw new InvalidOperationException($"The type {typeof(T).Name} does not support this operation");
                }
            }
        }

        public static AtomicLock<T> operator &(AtomicLock<T> lockedValue, AtomicLock<T> anotherLockedValue)
        {
            lock (lockedValue._lock)
            {
                try
                {
                    dynamic value = lockedValue._value ?? throw new Exception($"The type {typeof(T).Name} may not be null for this operation");
                    dynamic anotherValue = anotherLockedValue._value ?? throw new Exception($"The type {typeof(T).Name} may not be null for this operation");
                    return value & anotherValue;
                }
                catch (Exception)
                {
                    throw new InvalidOperationException($"The type {typeof(T).Name} does not support this operation");
                }
            }
        }

        public static AtomicLock<T> operator |(AtomicLock<T> lockedValue, AtomicLock<T> anotherLockedValue)
        {
            lock (lockedValue._lock)
            {
                try
                {
                    dynamic value = lockedValue._value ?? throw new Exception($"The type {typeof(T).Name} may not be null for this operation");
                    dynamic anotherValue = anotherLockedValue._value ?? throw new Exception($"The type {typeof(T).Name} may not be null for this operation");
                    return value | anotherValue;
                }
                catch (Exception)
                {
                    throw new InvalidOperationException($"The type {typeof(T).Name} does not support this operation");
                }
            }
        }

        public static AtomicLock<T> operator ^(AtomicLock<T> lockedValue, AtomicLock<T> anotherLockedValue)
        {
            lock (lockedValue._lock)
            {
                try
                {
                    dynamic value = lockedValue._value ?? throw new Exception($"The type {typeof(T).Name} may not be null for this operation");
                    dynamic anotherValue = anotherLockedValue._value ?? throw new Exception($"The type {typeof(T).Name} may not be null for this operation");
                    return value ^ anotherValue;
                }
                catch (Exception)
                {
                    throw new InvalidOperationException($"The type {typeof(T).Name} does not support this operation");
                }
            }
        }

        public static AtomicLock<T> operator <<(AtomicLock<T> lockedValue, int shift)
        {
            lock (lockedValue._lock)
            {
                try
                {
                    dynamic value = lockedValue._value ?? throw new Exception($"The type {typeof(T).Name} may not be null for this operation");
                    return value << shift;
                }
                catch (Exception)
                {
                    throw new InvalidOperationException($"The type {typeof(T).Name} does not support this operation");
                }
            }
        }

        public static AtomicLock<T> operator >>(AtomicLock<T> lockedValue, int shift)
        {
            lock (lockedValue._lock)
            {
                try
                {
                    dynamic value = lockedValue._value ?? throw new Exception($"The type {typeof(T).Name} may not be null for this operation");
                    return value >> shift;
                }
                catch (Exception)
                {
                    throw new InvalidOperationException($"The type {typeof(T).Name} does not support this operation");
                }
            }
        }

        public static bool operator true(AtomicLock<T> lockedValue)
        {
            lock (lockedValue._lock)
            {
                try
                {
                    dynamic value = lockedValue._value ?? throw new Exception($"The type {typeof(T).Name} may not be null for this operation");
                    return value;
                }
                catch (Exception)
                {
                    throw new InvalidOperationException($"The type {typeof(T).Name} does not support this operation");
                }
            }
        }

        public static bool operator false(AtomicLock<T> lockedValue)
        {
            lock (lockedValue._lock)
            {
                try
                {
                    dynamic value = lockedValue._value ?? throw new Exception($"The type {typeof(T).Name} may not be null for this operation");
                    return value;
                }
                catch (Exception)
                {
                    throw new InvalidOperationException($"The type {typeof(T).Name} does not support this operation");
                }
            }
        }

        public static bool operator ==(AtomicLock<T> lockedValue, AtomicLock<T> anotherLockedValue)
        {
            lock (lockedValue._lock)
            {
                try
                {
                    dynamic value = lockedValue._value ?? throw new Exception($"The type {typeof(T).Name} may not be null for this operation");
                    dynamic anotherValue = anotherLockedValue._value ?? throw new Exception($"The type {typeof(T).Name} may not be null for this operation");
                    return value == anotherValue;
                }
                catch (Exception)
                {
                    throw new InvalidOperationException($"The type {typeof(T).Name} does not support this operation");
                }
            }
        }

        public static bool operator !=(AtomicLock<T> lockedValue, AtomicLock<T> anotherLockedValue)
        {
            lock (lockedValue._lock)
            {
                try
                {
                    dynamic value = lockedValue._value ?? throw new Exception($"The type {typeof(T).Name} may not be null for this operation");
                    dynamic anotherValue = anotherLockedValue._value ?? throw new Exception($"The type {typeof(T).Name} may not be null for this operation");
                    return value != anotherValue;
                }
                catch (Exception)
                {
                    throw new InvalidOperationException($"The type {typeof(T).Name} does not support this operation");
                }
            }
        }

        public static bool operator <(AtomicLock<T> lockedValue, AtomicLock<T> anotherLockedValue)
        {
            lock (lockedValue._lock)
            {
                try
                {
                    dynamic value = lockedValue._value ?? throw new Exception($"The type {typeof(T).Name} may not be null for this operation");
                    dynamic anotherValue = anotherLockedValue._value ?? throw new Exception($"The type {typeof(T).Name} may not be null for this operation");
                    return value < anotherValue;
                }
                catch (Exception)
                {
                    throw new InvalidOperationException($"The type {typeof(T).Name} does not support this operation");
                }
            }
        }

        public static bool operator >(AtomicLock<T> lockedValue, AtomicLock<T> anotherLockedValue)
        {
            lock (lockedValue._lock)
            {
                try
                {
                    dynamic value = lockedValue._value ?? throw new Exception($"The type {typeof(T).Name} may not be null for this operation");
                    dynamic anotherValue = anotherLockedValue._value ?? throw new Exception($"The type {typeof(T).Name} may not be null for this operation");
                    return value > anotherValue;
                }
                catch (Exception)
                {
                    throw new InvalidOperationException($"The type {typeof(T).Name} does not support this operation");
                }
            }
        }

        public static bool operator <=(AtomicLock<T> lockedValue, AtomicLock<T> anotherLockedValue)
        {
            lock (lockedValue._lock)
            {
                try
                {
                    dynamic value = lockedValue._value ?? throw new Exception($"The type {typeof(T).Name} may not be null for this operation");
                    dynamic anotherValue = anotherLockedValue._value ?? throw new Exception($"The type {typeof(T).Name} may not be null for this operation");
                    return value <= anotherValue;
                }
                catch (Exception)
                {
                    throw new InvalidOperationException($"The type {typeof(T).Name} does not support this operation");
                }
            }
        }

        public static bool operator >=(AtomicLock<T> lockedValue, AtomicLock<T> anotherLockedValue)
        {
            lock (lockedValue._lock)
            {
                try
                {
                    dynamic value = lockedValue._value ?? throw new Exception($"The type {typeof(T).Name} may not be null for this operation");
                    dynamic anotherValue = anotherLockedValue._value ?? throw new Exception($"The type {typeof(T).Name} may not be null for this operation");
                    return value >= anotherValue;
                }
                catch (Exception)
                {
                    throw new InvalidOperationException($"The type {typeof(T).Name} does not support this operation");
                }
            }
        }
#endif
    }
}