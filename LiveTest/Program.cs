using LockType;
using static System.Console;

AtomicLock<int> locked = 0;

locked++;
WriteLine(locked);
locked++;
WriteLine(locked);

ReadKey(false);