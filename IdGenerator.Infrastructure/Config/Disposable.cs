using System;

namespace IdGenerator.Infrastructure.Config
{
    public abstract class Disposable : IDisposable
    {
        bool _isDisposed;

        ~Disposable()
        {
            Dispose(false);
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }
        void Dispose(bool disposing)
        {
            if (!_isDisposed && disposing)
            {
                DisposeCore();
            }

            _isDisposed = true;
        }

        protected abstract void DisposeCore();
    }
}
