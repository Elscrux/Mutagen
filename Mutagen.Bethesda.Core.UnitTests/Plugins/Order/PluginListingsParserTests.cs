﻿using System.Text;
using FluentAssertions;
using Mutagen.Bethesda.Plugins.Order;
using Mutagen.Bethesda.Plugins.Order.DI;
using Xunit;

namespace Mutagen.Bethesda.UnitTests.Plugins.Order;

public class PluginListingsParserTests
{
    private Stream GetStream(params string[] listings)
    {
        var sb = new StringBuilder();
        foreach (var listing in listings)
        {
            sb.AppendLine(listing);
        }
        var stream = new MemoryStream();
        var writer = new StreamWriter(stream);
        writer.Write(sb.ToString());
        writer.Flush();
        stream.Position = 0;
        return stream;
    }
        
    [Fact]
    public void Typical()
    {
        var parser = new PluginListingsParser( 
            new PluginListingCommentTrimmer(),
            new LoadOrderListingParser(
                new HasEnabledMarkersInjection(true)));
        var result = parser.Parse(GetStream(@"*ModA.esm
ModB.esp
*ModC.esp"))
            .ToList();
        result.Should().Equal(
            new LoadOrderListing("ModA.esm", true),
            new LoadOrderListing("ModB.esp", false),
            new LoadOrderListing("ModC.esp", true));
    }
        
    [Fact]
    public void CommentsWithNoEntry()
    {
        var parser = new PluginListingsParser( 
            new PluginListingCommentTrimmer(),
            new LoadOrderListingParser(
                new HasEnabledMarkersInjection(true)));
        var result = parser.Parse(GetStream(@"*ModA.esm
#ModB.esp
*ModC.esp"))
            .ToList();
        result.Should().Equal(
            new LoadOrderListing("ModA.esm", true),
            new LoadOrderListing("#ModB.esp", false),
            new LoadOrderListing("ModC.esp", true));
    }
        
    [Fact]
    public void CommentTrimming()
    {
        var parser = new PluginListingsParser( 
            new PluginListingCommentTrimmer(),
            new LoadOrderListingParser(
                new HasEnabledMarkersInjection(true)));
        var result = parser.Parse(GetStream(@"*ModA.esm
ModB.esp#Hello
*ModC.esp"))
            .ToList();
        result.Should().Equal(
            new LoadOrderListing("ModA.esm", true),
            new LoadOrderListing("ModB.esp", false),
            new LoadOrderListing("ModC.esp", true));
    }

    [Fact]
    public void PrintLinesOnFailure()
    {
        var parser = new PluginListingsParser(
            new PluginListingCommentTrimmer(),
            new LoadOrderListingParser(
                new HasEnabledMarkersInjection(true)));

        parser.Invoking(p => p.Parse(GetStream(
@"*ModA.esm
ModB.esp
*Malformed"))
            .ToList())
            .Should()
            .Throw<InvalidDataException>()
            .WithMessage("Load order file had malformed line at line 3: \"*Malformed\"");
    }
}