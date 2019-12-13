using MultiTask.Exceptions;
using System;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using Xunit;

namespace MultiTask.Tests
{
    public class TaskExtensionsTest
    {

        [Fact]
        public async Task AggregateExceptions_NoException_ReturnsWithoutDrama()
        {
            var task = Task.Run(() => { });

            await task.AggregateExceptions();
        }

        [Fact]
        public async Task AggregateExceptions_ExceptionThrown_ThrowsAggregateException()
        {
            var task = Task.Run(() => throw new TestException());

            await Assert.ThrowsAsync<TestException>(() => task);
            var ae = await Assert.ThrowsAsync<AggregateException>(() => task.AggregateExceptions());
            Assert.IsType<TestException>(ae.InnerExceptions.Single());
        }

        [Fact]
        public async Task AggregateExceptions_TaskCancelled_ThrowsOperationCancelledException()
        {
            var cancellationSource = new CancellationTokenSource();
            cancellationSource.Cancel();

            var task = Task.Run(() => throw new TestException(), cancellationSource.Token);

            await Assert.ThrowsAsync<TaskCanceledException>(() => task.AggregateExceptions());
        }

        [Fact]
        public async Task AggregateExceptionsT_NoException_ReturnsValue()
        {
            var expectedValue = "result";
            var task = Task.Run(() => expectedValue);

            var result = await task;

            Assert.Equal(expectedValue, result);
        }

        [Fact]
        public async Task AggregateExceptionsT_ExceptionThrown_ThrowsAggregateException()
        {
            static Task<string> f() { throw new TestException(); }
            Task<string> task = Task.Run(f);

            await Assert.ThrowsAsync<TestException>(() => task);
            var ae = await Assert.ThrowsAsync<AggregateException>(() => task.AggregateExceptions());
            Assert.IsType<TestException>(ae.InnerExceptions.Single());
        }

        [Fact]
        public async Task AggregateExceptionsT_TaskCancelled_ThrowsOperationCancelledException()
        {
            var cancellationSource = new CancellationTokenSource();
            cancellationSource.Cancel();
            var expectedValue = "result";

            var task = Task.Run(() => expectedValue, cancellationSource.Token);

            await Assert.ThrowsAsync<TaskCanceledException>(() => task.AggregateExceptions());
        }
    }
}
