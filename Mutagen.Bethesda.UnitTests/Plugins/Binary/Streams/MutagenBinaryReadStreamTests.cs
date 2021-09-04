﻿using System.IO;
using FluentAssertions;
using Mutagen.Bethesda.Core.UnitTests;
using Mutagen.Bethesda.Core.UnitTests.AutoData;
using Mutagen.Bethesda.Plugins;
using Mutagen.Bethesda.Plugins.Binary.Streams;
using Xunit;
using Noggog.Testing.IO;

namespace Mutagen.Bethesda.UnitTests.Plugins.Binary.Streams
{
    public class MutagenBinaryReadStreamTests
    {
        [Theory, MutagenAutoData]
        public void StreamModKeyCtorDoesNotDisposeStream()
        {
            var stream = new DisposeTesterWrapStream(File.OpenRead(TestPathing.SkyrimOverrideMod));
            var mutaStream = new MutagenBinaryReadStream(
                stream,
                ModKey.FromNameAndExtension("Skyrim.esm"),
                GameRelease.SkyrimSE);
            stream.Disposed.Should().BeFalse();
        }
    }
}