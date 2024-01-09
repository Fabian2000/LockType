using LockType;
using static System.Console;

AtomicLock<int> locked = new AtomicLock<int>();

locked++;
WriteLine(locked);
locked++;
WriteLine(locked);

AtomicLock<string> locked2 = new AtomicLock<string>();

ReadKey(false);