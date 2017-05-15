﻿using System.IO;

namespace MirrorSharp.FSharp.Internal {
    internal class NonDisposingStreamWrapper : Stream {
        private readonly Stream _stream;

        public NonDisposingStreamWrapper(Stream stream) {
            _stream = stream;
        }

        public override void Flush() => _stream.Flush();
        public override long Seek(long offset, SeekOrigin origin) => _stream.Seek(offset, origin);
        public override void SetLength(long value) => _stream.SetLength(value);
        public override int Read(byte[] buffer, int offset, int count) => _stream.Read(buffer, offset, count);
        public override void Write(byte[] buffer, int offset, int count) => _stream.Write(buffer, offset, count);
        public override bool CanRead => _stream.CanRead;
        public override bool CanSeek => _stream.CanSeek;
        public override bool CanWrite => _stream.CanWrite;
        public override long Length => _stream.Length;

        public override long Position {
            get => _stream.Position;
            set => _stream.Position = value;
        }

        public override void Close() {
            Flush();
        }
    }
}
