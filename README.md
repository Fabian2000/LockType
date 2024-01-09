# AtomicLock<T> Class

## Overview
The `AtomicLock<T>` class is a thread-safe structure designed to encapsulate a value and provide atomic operations on it. This class ensures that operations on the encapsulated value are performed safely in a multithreaded environment, preventing race conditions and ensuring consistency.

## Features
- **Thread-Safety**: Ensures that all operations on the value are thread-safe.
- **Atomic Operations**: Supports atomic operations like increment (`++`), decrement (`--`), and basic comparison operators.
- **Flexibility**: Allows executing custom operations on the value through a provided delegate.
- **Easy to Use**: Designed with simplicity in mind, offering an intuitive API.

## Usage

### Instantiation - Example 1
```csharp
AtomicLock<int> atomicInt = new AtomicLock<int>(initialValue);
```

### Instantiation - Example 2
```csharp
AtomicLock<int> atomicInt = 0;
```

### Performing Atomic Operations
```csharp
atomicInt++;  // Atomic increment
atomicInt--;  // Atomic decrement
// And a lot of other pre-defined operations
// (Not AOT friendly - Use ExecuteOperations instead)
```

### Executing Custom Operations
```csharp
atomicInt.ExecuteOperation(x => x * 2); // Custom operation
```

### Thread-Safe Value Update
```csharp
atomicInt.UpdateValue(newValue);
```

### Example code in C#
```csharp
using LockType;
using static System.Console;

AtomicLock<int> locked = 0;

locked++; // <-- Thread Safe
WriteLine(locked);
locked++; // <-- Thread Safe
WriteLine(locked);

ReadKey(false);
```

## Notes
- The class uses `dynamic` for some operations, which may have performance implications in certain scenarios.
- Exception handling is integrated for runtime errors, especially for operations involving `dynamic`.
- AOT developers should use ExecuteOperations Method instead of the Atomic Operations.
- Accessing the value by casting it to the original type is possible, but could not be thread safe.

## License
This project is licensed under the [MIT License](LICENSE).
