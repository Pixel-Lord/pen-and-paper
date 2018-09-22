using Microsoft.Win32.SafeHandles;
using System;
using System.Diagnostics;
using System.Runtime.InteropServices;

namespace PenAndPaper.NUnit.HelpClasses.Timer
{
    internal class Timer : IDisposable
    {
        internal enum Approach
        {
            Manuel, Attribute
        }

        private readonly Stopwatch watch;
        private bool disposed = false;
        private SafeHandle handle = new SafeFileHandle(IntPtr.Zero, true);
        
        public Timer() => watch = Stopwatch.StartNew();

        public void Stop(string className, string methodeName, Approach method = Approach.Manuel)
        {
            watch.Stop();
            long time = watch.ElapsedMilliseconds;
            DateTime date = DateTime.Now;
        }

        public void Dispose()
        {
            GC.SuppressFinalize(this);
        }

        protected virtual void Dispose(bool disposing)
        {
            if (disposed)
                return;

            if (disposing)
            {
                handle.Dispose();
            }

            disposed = true;
        }
    }
}
