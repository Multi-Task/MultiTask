using System.Collections.Generic;
using System.Threading.Tasks;

namespace MultiTasks
{
    /// <summary>
    /// Provides support for awaiting multiple tasks and more conventient handling of return values and exceptions.
    /// </summary>
    public static class MultiTask
    {
        /// <summary>
        /// Creates a task that will complete when all of the Task objects have completed.
        /// </summary>
        /// <param name="tasks">An optional number of <see cref="Task"/> objects that must complete before returning a value.</param>
        /// <exception cref="System.AggregateException">Thrown when the task is awaited and an unhandled exception has occured in one of more of the supplied tasks.</exception>
        /// <returns>A task that represents the completion of all of the supplied tasks.</returns>
        /// <remarks>
        /// This method differs from <see cref="Task.WhenAll(Task[])"/> when an unhandled exception occurs. It will then always throw an <see cref="System.AggregateException"/> when awaited.
        /// This makes exception handling easier when handling <see cref="Task"/>s in parallel.
        /// </remarks>
        public static async Task WhenAll(params Task[] tasks)
        {
            await Task.WhenAll(tasks).AggregateExceptions().ConfigureAwait(false);
        }

        /// <summary>
        /// Creates a task that will complete when all of the <see cref="Task{TResult}"/> and <see cref="Task"/> objects have completed.
        /// </summary>
        /// <typeparam name="T">Return type of the first <see cref="Task{TResult}"/>.</typeparam>
        /// <param name="t">A <see cref="Task"/> that can return av value.</param>
        /// <param name="otherTasks">An optional number of <see cref="Task"/> objects that must complete before returning a value.</param>
        /// <exception cref="System.AggregateException">Thrown when the task is awaited and an unhandled exception has occured in one of more of the supplied tasks.</exception>
        /// <returns>A task that represents the completion of all of the supplied tasks.</returns>
        /// <remarks>This method differs from <see cref="Task.WhenAll(Task[])"/> when an unhandled exception occurs. It will then always throw an <see cref="System.AggregateException"/> when awaited.
        /// This makes exception handling easier when handling <see cref="Task"/>s in parallel.</remarks>
        public static async Task<T> WhenAll<T>(Task<T> t, params Task[] otherTasks)
        {
            var tasks = new List<Task>(1 + otherTasks.Length) { t };
            tasks.AddRange(otherTasks);

            await Task.WhenAll(tasks).AggregateExceptions().ConfigureAwait(false);

            return t.Result;
        }

        /// <summary>
        /// Creates a task that will complete when all of the <see cref="Task{TResult}"/> and <see cref="Task"/> objects have completed.
        /// </summary>
        /// <typeparam name="T">Return type of the first <see cref="Task{TResult}"/>.</typeparam>
        /// <typeparam name="T2">Return type of the second <see cref="Task{TResult}"/>.</typeparam>
        /// <param name="t1">A <see cref="Task{TResult}"/> that can return av value.</param>
        /// <param name="t2">A <see cref="Task{TResult}"/> that can return av value.</param>
        /// <param name="otherTasks">An optional number of <see cref="Task"/> objects that must complete before returning a value.</param>
        /// <exception cref="System.AggregateException">Thrown when the task is awaited and an unhandled exception has occured in one of more of the supplied tasks.</exception>
        /// <returns>A task that represents the completion of all of the supplied tasks.</returns>
        /// <remarks>This method differs from <see cref="Task.WhenAll(Task[])"/> when an unhandled exception occurs. It will then always throw an <see cref="System.AggregateException"/> when awaited.
        /// This makes exception handling easier when handling <see cref="Task"/>s in parallel.</remarks>
        public static async Task<(T, T2)> WhenAll<T, T2>(Task<T> t1, Task<T2> t2, params Task[] otherTasks)
        {
            var tasks = new List<Task>(2 + otherTasks.Length) { t1, t2 };
            tasks.AddRange(otherTasks);

            await Task.WhenAll(tasks).AggregateExceptions().ConfigureAwait(false);

            return (t1.Result, t2.Result);
        }

        /// <summary>
        ///  Creates a task that will complete when all of the <see cref="Task{TResult}"/> and <see cref="Task"/> objects have completed.
        /// </summary>
        /// <typeparam name="T">Return type of the first <see cref="Task{TResult}"/>.</typeparam>
        /// <typeparam name="T2">Return type of the second <see cref="Task{TResult}"/>.</typeparam>
        /// <typeparam name="T3">Return type of the third <see cref="Task{TResult}"/>.</typeparam>
        /// <param name="t1">A <see cref="Task{TResult}"/> that can return av value.</param>
        /// <param name="t2">A <see cref="Task{TResult}"/> that can return av value.</param>
        /// <param name="t3">A <see cref="Task{TResult}"/> that can return av value.</param>
        /// <param name="otherTasks">An optional number of <see cref="Task"/> objects that must complete before returning a value.</param>
        /// <exception cref="System.AggregateException">Thrown when the task is awaited and an unhandled exception has occured in one of more of the supplied tasks.</exception>
        /// <returns>A task that represents the completion of all of the supplied tasks.</returns>
        /// <remarks>This method differs from <see cref="Task.WhenAll(Task[])"/> when an unhandled exception occurs. It will then always throw an <see cref="System.AggregateException"/> when awaited.
        /// This makes exception handling easier when handling <see cref="Task"/>s in parallel.</remarks>
        public static async Task<(T, T2, T3)> WhenAll<T, T2, T3>(Task<T> t1, Task<T2> t2, Task<T3> t3, params Task[] otherTasks)
        {
            var tasks = new List<Task>(3 + otherTasks.Length) { t1, t2, t3 };
            tasks.AddRange(otherTasks);

            await Task.WhenAll(tasks).AggregateExceptions().ConfigureAwait(false);

            return (t1.Result, t2.Result, t3.Result);
        }

        /// <summary>
        ///  Creates a task that will complete when all of the <see cref="Task{TResult}"/> and <see cref="Task"/> objects have completed.
        /// </summary>
        /// <typeparam name="T">Return type of the first <see cref="Task{TResult}"/>.</typeparam>
        /// <typeparam name="T2">Return type of the second <see cref="Task{TResult}"/>.</typeparam>
        /// <typeparam name="T3">Return type of the third <see cref="Task{TResult}"/>.</typeparam>
        /// <typeparam name="T4">Return type of the fourth <see cref="Task{TResult}"/>.</typeparam>
        /// <param name="t1">A <see cref="Task{TResult}"/> that can return av value.</param>
        /// <param name="t2">A <see cref="Task{TResult}"/> that can return av value.</param>
        /// <param name="t3">A <see cref="Task{TResult}"/> that can return av value.</param>
        /// <param name="t4">A <see cref="Task{TResult}"/> that can return av value.</param>
        /// <param name="otherTasks">An optional number of <see cref="Task"/> objects that must complete before returning a value.</param>
        /// <exception cref="System.AggregateException">Thrown when the task is awaited and an unhandled exception has occured in one of more of the supplied tasks.</exception>
        /// <returns>A task that represents the completion of all of the supplied tasks.</returns>
        /// <remarks>This method differs from <see cref="Task.WhenAll(Task[])"/> when an unhandled exception occurs. It will then always throw an <see cref="System.AggregateException"/> when awaited.
        /// This makes exception handling easier when handling <see cref="Task"/>s in parallel.</remarks>
        public static async Task<(T, T2, T3, T4)> WhenAll<T, T2, T3, T4>(Task<T> t1, Task<T2> t2, Task<T3> t3, Task<T4> t4, params Task[] otherTasks)
        {
            var tasks = new List<Task>(4 + otherTasks.Length) { t1, t2, t3, t4 };
            tasks.AddRange(otherTasks);

            await Task.WhenAll(tasks).AggregateExceptions().ConfigureAwait(false);

            return (t1.Result, t2.Result, t3.Result, t4.Result);
        }

        /// <summary>
        ///  Creates a task that will complete when all of the <see cref="Task{TResult}"/> and <see cref="Task"/> objects have completed.
        /// </summary>
        /// <typeparam name="T">Return type of the first <see cref="Task{TResult}"/>.</typeparam>
        /// <typeparam name="T2">Return type of the second <see cref="Task{TResult}"/>.</typeparam>
        /// <typeparam name="T3">Return type of the third <see cref="Task{TResult}"/>.</typeparam>
        /// <typeparam name="T4">Return type of the fourth <see cref="Task{TResult}"/>.</typeparam>
        /// <typeparam name="T5">Return type of the fifth <see cref="Task{TResult}"/>.</typeparam>
        /// <param name="t1">A <see cref="Task{TResult}"/> that can return av value.</param>
        /// <param name="t2">A <see cref="Task{TResult}"/> that can return av value.</param>
        /// <param name="t3">A <see cref="Task{TResult}"/> that can return av value.</param>
        /// <param name="t4">A <see cref="Task{TResult}"/> that can return av value.</param>
        /// <param name="t5">A <see cref="Task{TResult}"/> that can return av value.</param>
        /// <param name="otherTasks">An optional number of <see cref="Task"/> objects that must complete before returning a value.</param>
        /// <exception cref="System.AggregateException">Thrown when the task is awaited and an unhandled exception has occured in one of more of the supplied tasks.</exception>
        /// <returns>A task that represents the completion of all of the supplied tasks.</returns>
        /// <remarks>This method differs from <see cref="Task.WhenAll(Task[])"/> when an unhandled exception occurs. It will then always throw an <see cref="System.AggregateException"/> when awaited.
        /// This makes exception handling easier when handling <see cref="Task"/>s in parallel.</remarks>
        public static async Task<(T, T2, T3, T4, T5)> WhenAll<T, T2, T3, T4, T5>(Task<T> t1, Task<T2> t2, Task<T3> t3, Task<T4> t4, Task<T5> t5,
            params Task[] otherTasks)
        {
            var tasks = new List<Task>(5 + otherTasks.Length) { t1, t2, t3, t4, t5 };
            tasks.AddRange(otherTasks);

            await Task.WhenAll(tasks).AggregateExceptions().ConfigureAwait(false);

            return (t1.Result, t2.Result, t3.Result, t4.Result, t5.Result);
        }

        /// <summary>
        ///  Creates a task that will complete when all of the <see cref="Task{TResult}"/> and <see cref="Task"/> objects have completed.
        /// </summary>
        /// <typeparam name="T">Return type of the first <see cref="Task{TResult}"/>.</typeparam>
        /// <typeparam name="T2">Return type of the second <see cref="Task{TResult}"/>.</typeparam>
        /// <typeparam name="T3">Return type of the third <see cref="Task{TResult}"/>.</typeparam>
        /// <typeparam name="T4">Return type of the fourth <see cref="Task{TResult}"/>.</typeparam>
        /// <typeparam name="T5">Return type of the fifth <see cref="Task{TResult}"/>.</typeparam>
        /// <typeparam name="T6">Return type of the sixth <see cref="Task{TResult}"/>.</typeparam>
        /// <param name="t1">A <see cref="Task{TResult}"/> that can return av value.</param>
        /// <param name="t2">A <see cref="Task{TResult}"/> that can return av value.</param>
        /// <param name="t3">A <see cref="Task{TResult}"/> that can return av value.</param>
        /// <param name="t4">A <see cref="Task{TResult}"/> that can return av value.</param>
        /// <param name="t5">A <see cref="Task{TResult}"/> that can return av value.</param>
        /// <param name="t6">A <see cref="Task{TResult}"/> that can return av value.</param>
        /// <param name="otherTasks">An optional number of <see cref="Task"/> objects that must complete before returning a value.</param>
        /// <exception cref="System.AggregateException">Thrown when the task is awaited and an unhandled exception has occured in one of more of the supplied tasks.</exception>
        /// <returns>A task that represents the completion of all of the supplied tasks.</returns>
        /// <remarks>This method differs from <see cref="Task.WhenAll(Task[])"/> when an unhandled exception occurs. It will then always throw an <see cref="System.AggregateException"/> when awaited.
        /// This makes exception handling easier when handling <see cref="Task"/>s in parallel.</remarks>
        public static async Task<(T, T2, T3, T4, T5, T6)> WhenAll<T, T2, T3, T4, T5, T6>(Task<T> t1, Task<T2> t2, Task<T3> t3, Task<T4> t4, Task<T5> t5,
            Task<T6> t6, params Task[] otherTasks)
        {
            var tasks = new List<Task>(6 + otherTasks.Length) { t1, t2, t3, t4, t5, t6 };
            tasks.AddRange(otherTasks);

            await Task.WhenAll(tasks).AggregateExceptions().ConfigureAwait(false);

            return (t1.Result, t2.Result, t3.Result, t4.Result, t5.Result, t6.Result);
        }

        /// <summary>
        ///  Creates a task that will complete when all of the <see cref="Task{TResult}"/> and <see cref="Task"/> objects have completed.
        /// </summary>
        /// <typeparam name="T">Return type of the first <see cref="Task{TResult}"/>.</typeparam>
        /// <typeparam name="T2">Return type of the second <see cref="Task{TResult}"/>.</typeparam>
        /// <typeparam name="T3">Return type of the third <see cref="Task{TResult}"/>.</typeparam>
        /// <typeparam name="T4">Return type of the fourth <see cref="Task{TResult}"/>.</typeparam>
        /// <typeparam name="T5">Return type of the fifth <see cref="Task{TResult}"/>.</typeparam>
        /// <typeparam name="T6">Return type of the sixth <see cref="Task{TResult}"/>.</typeparam>
        /// <typeparam name="T7">Return type of the seventh <see cref="Task{TResult}"/>.</typeparam>
        /// <param name="t1">A <see cref="Task{TResult}"/> that can return av value.</param>
        /// <param name="t2">A <see cref="Task{TResult}"/> that can return av value.</param>
        /// <param name="t3">A <see cref="Task{TResult}"/> that can return av value.</param>
        /// <param name="t4">A <see cref="Task{TResult}"/> that can return av value.</param>
        /// <param name="t5">A <see cref="Task{TResult}"/> that can return av value.</param>
        /// <param name="t6">A <see cref="Task{TResult}"/> that can return av value.</param>
        /// <param name="t7">A <see cref="Task{TResult}"/> that can return av value.</param>
        /// <param name="otherTasks">An optional number of <see cref="Task"/> objects that must complete before returning a value.</param>
        /// <exception cref="System.AggregateException">Thrown when the task is awaited and an unhandled exception has occured in one of more of the supplied tasks.</exception>
        /// <returns>A task that represents the completion of all of the supplied tasks.</returns>
        /// <remarks>This method differs from <see cref="Task.WhenAll(Task[])"/> when an unhandled exception occurs. It will then always throw an <see cref="System.AggregateException"/> when awaited.
        /// This makes exception handling easier when handling <see cref="Task"/>s in parallel.</remarks>
        public static async Task<(T, T2, T3, T4, T5, T6, T7)> WhenAll<T, T2, T3, T4, T5, T6, T7>(Task<T> t1, Task<T2> t2, Task<T3> t3, Task<T4> t4, Task<T5> t5,
            Task<T6> t6, Task<T7> t7, params Task[] otherTasks)
        {
            var tasks = new List<Task>(7 + otherTasks.Length) { t1, t2, t3, t4, t5, t6, t7 };
            tasks.AddRange(otherTasks);

            await Task.WhenAll(tasks).AggregateExceptions().ConfigureAwait(false);

            return (t1.Result, t2.Result, t3.Result, t4.Result, t5.Result, t6.Result, t7.Result);
        }
    }
}
