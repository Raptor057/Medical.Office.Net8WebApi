﻿namespace Common.Common
{
    public interface ISuccess
    { }

    public interface ISuccess<T> : ISuccess
    {
        T Data { get; }
    }
}
