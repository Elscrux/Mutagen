# Asset Links
An AssetLink is a strongly typed object wrapping what is normally a `string` subpath pointing to an asset.

For example, a Skyrim Weapon's Model has a `File` member, which is the `MODL` subrecord, which contains a string relative to the `Data/Meshes` folder.   Rather than exposing this as a `string`, Mutagen exposes this as an `AssetLink<SkyrimModelAssetType>`.

!!! info "Enhanced FilePath"
    If you're just after the path, you can still get it via an AssetLink's `RawPath` member.  But the AssetLink now comes with a bunch of additional features and convenience

## Members
### RawPath
`RawPath` is the string that is present on disk in the record itself as it appears.  This is also the field that you can set when you want to modify an AssetLink to point to a different path.

`AssetLink`s are implicitly convertible to/from `string`, which uses `RawPath` as the string to return.  This is in place to provide some backwards compatibility

### DataRelativePath
`DataRelativePath` is a `get` only member that does some checking/trimming of `RawPath` to try to standardize it to be relative to a game's Data folder.

It will trim a prefixed "Data" folder in the path, while also ensuring the appropriate asset subfolder is present.  Some examples:

| RawPath                        | DataRelativePath          |
|--------------------------------|---------------------------|
| textures/some/subpath.nif      | textures/some/subpath.nif |
| data/textures/some/subpath.nif | textures/some/subpath.nif |
| some/subpath.nif               | textures/some/subpath.nif |

In all examples, the `DataRelativePath` remains the same, as that is what it's attempting to do: keep it standardized to be relative the Data folder, no matter the RawPath's contents.

### AssetType Generic
An `AssetLink`'s generic type is the type of asset it relates to.  

For example, a Skyrim Model path will be of type `AssetLink<SkyrimModelAssetType>`, where `SkyrimModelAssetType` is a meta class containing information about Skyrim Model assets.

[:octicons-arrow-right-24: AssetType](#Asset-Type)

## Asset Type
AssetTypes are constant meta objects that contain the information 

- `BaseFolder`, what subfolder underneath /Data/ these assests are expected to live
- `FileExtensions`, what expected file extensions these types of meta files will have

## Asset Enumeration
Similar to FormLinks, a mod can enumerate AssetLinks of a desired type.   The details are slightly different, though.

### Typical Usage
=== "Specific Asset Types"
    ``` { .cs hl_lines="5" }
    IStarfieldModGetter mod = ...;
    ILinkCache linkCache = ...;
    var assetLinkCache = linkCache.CreateImmutableAssetLinkCache();

    foreach (var asset in mod.EnumerateAllAssetLinks<StarfieldModelAssetType>(assetLinkCache))
    {
        // Loops each asset
    }
    ```
=== "All Asset Types"
    ``` { .cs hl_lines="5" }
    IStarfieldModGetter mod = ...;
    ILinkCache linkCache = ...;
    var assetLinkCache = linkCache.CreateImmutableAssetLinkCache();

    foreach (var asset in mod.EnumerateAllAssetLinks(assetLinkCache))
    {
        // Loops each asset
    }
    ```


## AssetLinkQuery
This is a flag enum with three options, letting you control what type of Assets you want to enumerate:

- `Listed`.  Assets explicitly listed in the records:
    - Skyrim Model Path

- `Inferred`.  Assets that can be inferred by fields that exist on the record
    - Armor Addon World Model `_0` `_1` suffix assets
    - Book text `src` links pointing to textures

- `Resolved`.  Assets that can be inferred by looking at other records, and require FormLink lookups on a Link Cache.
    - Dialog Topic's Voice Type paths 

By combining flags, you can control what Asset categories you are interested in.  There are also convenience methods like `EnumerateListedAssetLinks` that handle the flags for you.

## AssetLinkCache
`Resolved` asset enumerations require an `IAssetLinkCache`.  This is due to their complex nature requiring a lot of work to locate the same data repeatedly, a cache object helps speed up the internal logic.  Some AssetLink enumeration calls will not require AssetLinkCaches if you are not querying for Resolved assets

!!! tip "Reuse Cache"
    It is best to reuse the same Asset Link Cache for multiple queries, and recreate only if the wrapped LinkCache is invalidated.
    
### Construction
An AssetLinkCache is a cache wrapper around LinkCache, to provide specific functionality for asset lookup.  
```cs
ILinkCache linkCache = ...;
var assetLinkCache = linkCache.CreateImmutableAssetLinkCache();
```

