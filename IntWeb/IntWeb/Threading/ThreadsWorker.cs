using System.Collections.Generic;
using System.Linq;
using System.Threading;

namespace IntWeb.Framework.Threading
{
    public class ThreadsWorker
    {
        private readonly Dictionary<Thread, object> threads = new Dictionary<Thread, object>();

        public Thread StartInThread(ThreadStart threadStart)
        {
            Thread thread = new Thread(threadStart);
            threads[thread] = threadStart.Target;
            thread.Start();
            return thread;
        }

        public Thread StartInThread(ParameterizedThreadStart parameterizedThreadStart)
        {
            Thread thread = new Thread(parameterizedThreadStart);
            threads[thread] = parameterizedThreadStart.Target;
            thread.Start();
            return thread;
        }

        public void InterruptAllThreads(bool clearAfter = false)
        {
            foreach(Thread thread in threads.Keys)
            {
                if(thread.IsAlive)
                {
                    thread.Interrupt();
                }
            }

            if(clearAfter)
            {
                threads.Clear();
            }
        }

        public void InterruptThreads<T>(bool clearAfter = false)
        {
            foreach (Thread thread in GetThreads<T>())
            {
                if (thread.IsAlive)
                {
                    thread.Interrupt();

                    if(clearAfter)
                    {
                        threads.Remove(thread);
                    }
                }
            }
        }

        public void InterruptThread<T>(bool removeAfter = false)
        {
            Thread thread = GetThread<T>();

            if(thread.IsAlive)
            {
                thread.Interrupt();

                if (removeAfter)
                {
                    threads.Remove(thread);
                }
            }
        }

        public List<Thread> GetThreads()
        {
            return threads.Keys.ToList();
        }

        public List<Thread> GetThreads<T>()
        {
            List<Thread> threadsResult = new List<Thread>();

            foreach(Thread thread in threads.Keys)
            {
                if(threads[thread] is T)
                {
                    threadsResult.Add(thread);
                }
            }

            return threadsResult;
        }

        public int GetThreadsCount()
        {
            return threads.Count;
        }

        public int GetThreadsCount<T>()
        {
            return GetThreads<T>().Count;
        }

        public Thread GetThread<T>()
        {
            return GetThreads<T>().SingleOrDefault();
        }

        public object GetThreadTargetClass(Thread thread)
        {
            return threads[thread];
        }
    }
}