using FluentAssertions;

namespace yandexTests.Helpers
{
    public class SoftAssertions
    {
        private List<SingleAssert> _verifications = new();

        public void Add(string message, string expected, string actual)
        {
            _verifications.Add(new SingleAssert(message, expected, actual));
        }

        public void Add(string message, bool expected, bool actual)
        {
            _verifications.Add(new SingleAssert(message, expected.ToString(), actual.ToString()));
        }

        public void Add(string message, int expected, int actual)
        {
            _verifications.Add(new SingleAssert(message, expected.ToString(), actual.ToString()));
        }

        public void AddTrue(string message, bool actual)
        {
            _verifications.Add(new SingleAssert(message, true.ToString(), actual.ToString()));
        }

        public void AddFalse(string message, bool actual)
        {
            _verifications.Add(new SingleAssert(message, false.ToString(), actual.ToString()));
        }

        public void AssertAll()
        {
            List<SingleAssert> failed = _verifications.Where(v => v.Failed).ToList();
            failed.Should().BeEmpty();
        }

        private class SingleAssert
        {
            private readonly string _message;
            private readonly string _expected;
            private readonly string _actual;

            public bool Failed { get; }

            public SingleAssert(string message, string expected, string actual)
            {
                _message = message;
                _expected = expected;
                _actual = actual;
                Failed = _expected != _actual;
            }

            public override string ToString()
            {
                return "\n'" + _message + "' assert was expected to be '" 
                    + _expected + "' but it was '" + _actual + "'";
            }
        }
    }
}
