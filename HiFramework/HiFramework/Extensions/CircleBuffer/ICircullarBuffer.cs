﻿/****************************************************************************
 * Description:
 *
 * Author: hiramtan@live.com
 ****************************************************************************/

using System;

namespace HiFramework
{
    public interface ICircleBuffer<T> : IDisposable
    {
        T[] Buffer { get; }
        int Size { get; }
        int BlockSize { get; set; }

        int ReadPosition { get; }
        int WritePosition { get; }

        void MoveReadPostion(int length);
        void MoveWritePosition(int length);
        void MoveReadPositionTo(int index);
        void MoveWritePostionTo(int index);

        T[] Read(int length);
        void Read(T[] destinationArray, int destinationIndex, int length);

        void Write(T[] sourceArray);
        void Write(T[] sourceArray, int sourceIndex, int length);

        void ResetIndex();
    }
}