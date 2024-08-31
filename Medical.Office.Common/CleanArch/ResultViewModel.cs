﻿namespace Common.Common.CleanArch
{
    public class ResultViewModel<T>
    {
        public ResultViewModel()
        {
            Data = null;
            Message = string.Empty;
            IsSuccess = false;
            UtcTimeStamp = DateTime.UtcNow;
        }

        public object? Data { get; private set; }

        public bool IsSuccess { get; private set; }

        public string? Message { get; private set; }

        public DateTime UtcTimeStamp { get; private set; }

        public void Set(IFailure failure)
        {
            Data = null;
            Message = failure.Message;
            IsSuccess = false;
            UtcTimeStamp = DateTime.UtcNow;
        }

        public void Set<TData>(ISuccess<TData> success, Func<TData, object>? callback = null)
        {
            Data = callback?.Invoke(success.Data) ?? success.Data;
            IsSuccess = true;
            UtcTimeStamp = DateTime.UtcNow;
            Message = null;
        }

        public ResultViewModel<T> Fail(string message)
        {
            Data = null;
            Message = message;
            IsSuccess = false;
            UtcTimeStamp = DateTime.UtcNow;
            return this;
        }
    }
}
