using System.Runtime.ExceptionServices;
using System.Threading.Tasks;

namespace MultiTask
{
    public static class TaskExtensions
    {
        public static async Task AggregateExceptions(this Task task)
        {
            try
            {
                await task.ConfigureAwait(false);
            }
            catch
            {
                if (task.IsFaulted)
                {
                    ExceptionDispatchInfo.Capture(task.Exception).Throw();
                }
                throw;
            }
        }

        public static async Task<T> AggregateExceptions<T>(this Task<T> task)
        {
            try
            {
                return await task.ConfigureAwait(false);
            }
            catch
            {
                if (task.IsFaulted)
                {
                    ExceptionDispatchInfo.Capture(task.Exception).Throw();
                }
                throw;
            }
        }
    }
}
