﻿namespace Common.Common
{
    public sealed class FailureResult<T> : Result<T>, IFailure
    {
        public FailureResult(string message) => Exception = new Exception(message);

        public FailureResult(Exception ex) => Exception = ex;

        public Exception Exception { get; }

        public string Message => Exception.Message;
    }
}
