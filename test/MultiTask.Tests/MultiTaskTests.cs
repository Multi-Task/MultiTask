using MultiTask.Exceptions;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Xunit;

namespace MultiTask
{
    public class MultiTaskTests
    {
        private readonly string _expectedResult1;
        private readonly int _expectedResult2;
        private readonly bool _expectedResult3;
        private readonly string[] _expectedResult4;
        private readonly int[] _expectedResult5;
        private readonly string _expectedResult6;
        private readonly string _expectedResult7;
        private readonly Task<string> _t1;
        private readonly Task<int> _t2;
        private readonly Task<bool> _t3;
        private readonly Task<string[]> _t4;
        private readonly Task<int[]> _t5;
        private readonly Task<string> _t6;
        private readonly Task<string> _t7;
        private readonly Task _tp;

        public MultiTaskTests()
        {
            _expectedResult1 = "expectedResult";
            _expectedResult2 = 42;
            _expectedResult3 = true;
            _expectedResult4 = new[] { "arrayResult" };
            _expectedResult5 = new[] { 4 };
            _expectedResult6 = "sixthResult";
            _expectedResult7 = "seventhResult";

            _t1 = Task.FromResult(_expectedResult1);
            _t2 = Task.FromResult(_expectedResult2);
            _t3 = Task.FromResult(_expectedResult3);
            _t4 = Task.FromResult(_expectedResult4);
            _t5 = Task.FromResult(_expectedResult5);
            _t6 = Task.FromResult(_expectedResult6);
            _t7 = Task.FromResult(_expectedResult7);
            _tp = Task.CompletedTask;
        }

        [Fact]
        public async Task WhenAll_OneValueTask_ReturnsResult()
        {
            var result = await MultiTask.WhenAll(_t1, _tp);

            Assert.Equal(_expectedResult1, result);
        }

        [Fact]
        public async Task WhenAll_TwoValueTasks_ReturnsResults()
        {
            var (r1, r2) = await MultiTask.WhenAll(_t1, _t2, _tp);

            Assert.Equal(_expectedResult1, r1);
            Assert.Equal(_expectedResult2, r2);
        }

        [Fact]
        public async Task WhenAll_ThreeValueTasks_ReturnsResults()
        {
            var (r1, r2, r3) = await MultiTask.WhenAll(_t1, _t2, _t3, _tp);

            Assert.Equal(_expectedResult1, r1);
            Assert.Equal(_expectedResult2, r2);
            Assert.Equal(_expectedResult3, r3);
        }

        [Fact]
        public async Task WhenAll_FourValueTasks_ReturnsResults()
        {
            var (r1, r2, r3, r4) = await MultiTask.WhenAll(_t1, _t2, _t3, _t4, _tp);

            Assert.Equal(_expectedResult1, r1);
            Assert.Equal(_expectedResult2, r2);
            Assert.Equal(_expectedResult3, r3);
            Assert.Equal(_expectedResult4, r4);
        }

        [Fact]
        public async Task WhenAll_FiveValueTasks_ReturnsResults()
        {
            var (r1, r2, r3, r4, r5) = await MultiTask.WhenAll(_t1, _t2, _t3, _t4, _t5, _tp);

            Assert.Equal(_expectedResult1, r1);
            Assert.Equal(_expectedResult2, r2);
            Assert.Equal(_expectedResult3, r3);
            Assert.Equal(_expectedResult4, r4);
            Assert.Equal(_expectedResult5, r5);
        }

        [Fact]
        public async Task WhenAll_SixValueTasks_ReturnsResults()
        {
            var (r1, r2, r3, r4, r5, r6) = await MultiTask.WhenAll(_t1, _t2, _t3, _t4, _t5, _t6, _tp);

            Assert.Equal(_expectedResult1, r1);
            Assert.Equal(_expectedResult2, r2);
            Assert.Equal(_expectedResult3, r3);
            Assert.Equal(_expectedResult4, r4);
            Assert.Equal(_expectedResult5, r5);
            Assert.Equal(_expectedResult6, r6);
        }

        [Fact]
        public async Task WhenAll_SevenValueTasks_ReturnsResults()
        {
            var (r1, r2, r3, r4, r5, r6, r7) = await MultiTask.WhenAll(_t1, _t2, _t3, _t4, _t5, _t6, _t7, _tp);

            Assert.Equal(_expectedResult1, r1);
            Assert.Equal(_expectedResult2, r2);
            Assert.Equal(_expectedResult3, r3);
            Assert.Equal(_expectedResult4, r4);
            Assert.Equal(_expectedResult5, r5);
            Assert.Equal(_expectedResult6, r6);
            Assert.Equal(_expectedResult7, r7);
        }

        [Theory]
        [MemberData(nameof(GetTasksWithExceptions))]
        public async Task WhenAll_TaskExceptions_AggregatesExceptions(int numberOfExceptions, Task whenAll, TestException expectedException)
        {
            var ae = await Assert.ThrowsAsync<AggregateException>(() => whenAll);
            var te = whenAll.Exception;

            Assert.All(ae.InnerExceptions, (e) => e.Equals(expectedException));
            Assert.Equal(numberOfExceptions, ae.InnerExceptions.Count);
        }

        public static IEnumerable<object[]> GetTasksWithExceptions()
        {
            var expectedException = new TestException();
            var vet = Task.FromException<string>(expectedException); //Value exception task
            var pet = Task.FromException(expectedException); //Plain exception task


            var t1 = MultiTask.WhenAll(vet, pet);
            var t2 = MultiTask.WhenAll(vet, vet, pet);
            var t3 = MultiTask.WhenAll(vet, vet, vet, pet);
            var t4 = MultiTask.WhenAll(vet, vet, vet, vet, pet);
            var t5 = MultiTask.WhenAll(vet, vet, vet, vet, vet, pet);
            var t6 = MultiTask.WhenAll(vet, vet, vet, vet, vet, vet, pet);
            var t7 = MultiTask.WhenAll(vet, vet, vet, vet, vet, vet, vet, pet);

            yield return new object[] { 2, t1, expectedException };
            yield return new object[] { 3, t2, expectedException };
            yield return new object[] { 4, t3, expectedException };
            yield return new object[] { 5, t4, expectedException };
            yield return new object[] { 6, t5, expectedException };
            yield return new object[] { 7, t6, expectedException };
            yield return new object[] { 8, t7, expectedException };
        }
    }
}
