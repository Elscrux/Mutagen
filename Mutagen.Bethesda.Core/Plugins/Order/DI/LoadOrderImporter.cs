﻿using System.IO.Abstractions;
using Mutagen.Bethesda.Environments.DI;
using Mutagen.Bethesda.Plugins.Binary.Headers;
using Mutagen.Bethesda.Plugins.Binary.Parameters;
using Mutagen.Bethesda.Plugins.Exceptions;
using Mutagen.Bethesda.Plugins.Masters;
using Mutagen.Bethesda.Plugins.Records;
using Mutagen.Bethesda.Plugins.Records.DI;
using Mutagen.Bethesda.Strings;
using Noggog;

namespace Mutagen.Bethesda.Plugins.Order.DI;

public interface ILoadOrderImporter
{
    /// <summary>
    /// Returns a load order filled with mods constructed
    /// </summary>
    ILoadOrder<IModListing<IModGetter>> Import(BinaryReadParameters? param = null);
}
    
public interface ILoadOrderImporter<TMod>
    where TMod : class, IModGetter
{
    /// <summary>
    /// Returns a load order filled with mods constructed
    /// </summary>
    ILoadOrder<IModListing<TMod>> Import(BinaryReadParameters? param = null);
}

public sealed class LoadOrderImporter<TMod> : ILoadOrderImporter<TMod>
    where TMod : class, IModGetter
{
    private readonly IFileSystem _fileSystem;
    private readonly IDataDirectoryProvider _dataDirectoryProvider;
    public ILoadOrderListingsProvider LoadOrderListingsProvider { get; }
    public IModImporter<TMod> Importer { get; }

    public LoadOrderImporter(
        IFileSystem fileSystem,
        IDataDirectoryProvider dataDirectoryProvider,
        ILoadOrderListingsProvider loadOrderListingsProvider,
        IModImporter<TMod> importer)
    {
        _fileSystem = fileSystem;
        _dataDirectoryProvider = dataDirectoryProvider;
        LoadOrderListingsProvider = loadOrderListingsProvider;
        Importer = importer;
    }
        
    public ILoadOrder<IModListing<TMod>> Import(BinaryReadParameters? param = null)
    {
        var loList = LoadOrderListingsProvider.Get().ToList();
        var results = new (ModKey ModKey, int ModIndex, TryGet<TMod> Mod, bool Enabled)[loList.Count];
        try
        {
            Parallel.ForEach(loList, (listing, _, modIndex) =>
            {
                try
                {
                    var modPath = new ModPath(listing.ModKey, _dataDirectoryProvider.Path.GetFile(listing.ModKey.FileName).Path);
                    if (!_fileSystem.File.Exists(modPath.Path))
                    {
                        results[modIndex] = (listing.ModKey, (int)modIndex, TryGet<TMod>.Failure, listing.Enabled);
                        return;
                    }
                    var mod = Importer.Import(modPath, param: param);
                    results[modIndex] = (listing.ModKey, (int)modIndex, TryGet<TMod>.Succeed(mod), listing.Enabled);
                }
                catch (Exception ex)
                {
                    throw RecordException.Enrich(ex, listing.ModKey);
                }
            });
            return new LoadOrder<IModListing<TMod>>(results
                .OrderBy(i => i.ModIndex)
                .Select(item =>
                {
                    if (item.Mod.Succeeded)
                    {
                        return new ModListing<TMod>(item.Mod.Value, item.Enabled);
                    }
                    else
                    {
                        return ModListing<TMod>.CreateUnloaded(item.ModKey, item.Enabled);
                    }
                }));
        }
        catch (Exception)
        {
            // We're aborting, but we still want to dispose any that were successful
            foreach (var result in results)
            {
                if (result.Mod.Value is IDisposable disp)
                {
                    disp.Dispose();
                }
            }
            throw;
        }
    }
}

public sealed class LoadOrderImporter : ILoadOrderImporter
{
    private readonly IFileSystem _fileSystem;
    private readonly IGameReleaseContext _gameRelease;
    private readonly IDataDirectoryProvider _dataDirectoryProvider;
    public ILoadOrderListingsProvider LoadOrderListingsProvider { get; }
    public IModImporter Importer { get; }

    public LoadOrderImporter(
        IFileSystem fileSystem,
        IGameReleaseContext gameRelease,
        IDataDirectoryProvider dataDirectoryProvider,
        ILoadOrderListingsProvider loadOrderListingsProvider,
        IModImporter importer)
    {
        _fileSystem = fileSystem;
        _gameRelease = gameRelease;
        _dataDirectoryProvider = dataDirectoryProvider;
        LoadOrderListingsProvider = loadOrderListingsProvider;
        Importer = importer;
    }
        
    public ILoadOrder<IModListing<IModGetter>> Import(BinaryReadParameters? param = null)
    {
        var loList = LoadOrderListingsProvider.Get().ToList();
        var results = new (ModKey ModKey, int ModIndex, TryGet<IModGetter> Mod, bool Enabled)[loList.Count];
        param ??= BinaryReadParameters.Default;
        if (param.MasterFlagsLookup == null)
        {
            param = param with
            {
                MasterFlagsLookup = new LoadOrder<IModFlagsGetter>(loList
                    .Select(listing =>
                    {
                        var modPath = new ModPath(listing.ModKey,
                            _dataDirectoryProvider.Path.GetFile(listing.ModKey.FileName).Path);
                        if (!_fileSystem.File.Exists(modPath)) return null;
                        using var mod = ModInstantiator.ImportGetter(modPath, _gameRelease.Release, new BinaryReadParameters()
                        {
                            FileSystem = _fileSystem
                        });
                        return new ModFlags(mod);
                    })
                    .NotNull())
            };
        }
        try
        {
            Parallel.ForEach(loList, (listing, _, modIndex) =>
            {
                try
                {
                    var modPath = new ModPath(listing.ModKey, _dataDirectoryProvider.Path.GetFile(listing.ModKey.FileName).Path);
                    if (!_fileSystem.File.Exists(modPath.Path))
                    {
                        results[modIndex] = (listing.ModKey, (int)modIndex, TryGet<IModGetter>.Failure, listing.Enabled);
                        return;
                    }
                    var mod = Importer.Import(modPath, param);
                    results[modIndex] = (listing.ModKey, (int)modIndex, TryGet<IModGetter>.Succeed(mod), listing.Enabled);
                }
                catch (Exception ex)
                {
                    throw RecordException.Enrich(ex, listing.ModKey);
                }
            });
            return new LoadOrder<IModListing<IModGetter>>(results
                .OrderBy(i => i.ModIndex)
                .Select(item =>
                {
                    if (item.Mod.Succeeded)
                    {
                        return new ModListing<IModGetter>(item.Mod.Value, item.Enabled);
                    }
                    else
                    {
                        return ModListing<IModGetter>.CreateUnloaded(item.ModKey, item.Enabled);
                    }
                }));
        }
        catch (Exception)
        {
            // We're aborting, but we still want to dispose any that were successful
            foreach (var result in results)
            {
                if (result.Mod.Value is IDisposable disp)
                {
                    disp.Dispose();
                }
            }
            throw;
        }
    }
}