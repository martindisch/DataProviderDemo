# Benchmark

## Usage

`dotnet run --project src/Benchmark --configuration Release`

## Methodology

The benchmark graph contains two big object types with 99 fields each.

- `DataProduct` is a dumb DTO that is immediately preloaded in the resolver
  with a DataLoader
- `LazyProduct` uses a DataLoader on each of its fields to load the underlying
  DTO on-demand

```csharp
public class Query
{
    [NodeResolver]
    public async Task<DataProduct> GetDataProductById(int id, DataProductDataLoader dataLoader) =>
        await dataLoader.LoadAsync(id);

    [NodeResolver]
    public LazyProduct GetLazyProductById(int id) => new(id);
}
```

## Results

They differ only by how many products are requested, e.g. one

```graphql
query dataProduct {
  dataProductById(id: "RGF0YVByb2R1Y3QKaTE=") {
    ...EverythingDataProduct
  }
}
```

vs five

```graphql
query dataProduct {
  product01: dataProductById(id: "RGF0YVByb2R1Y3QKaTE=") {
    ...EverythingDataProduct
  }
  product02: dataProductById(id: "RGF0YVByb2R1Y3QKaTI=") {
    ...EverythingDataProduct
  }
  product03: dataProductById(id: "RGF0YVByb2R1Y3QKaTM=") {
    ...EverythingDataProduct
  }
  product04: dataProductById(id: "RGF0YVByb2R1Y3QKaTQ=") {
    ...EverythingDataProduct
  }
  product05: dataProductById(id: "RGF0YVByb2R1Y3QKaTU=") {
    ...EverythingDataProduct
  }
}
```

### 1 product (= 99 fields)

| Method   |      Mean |    Error |   StdDev |
| -------- | --------: | -------: | -------: |
| Preload  |  98.07 us | 1.165 us | 1.032 us |
| OnDemand | 335.06 us | 0.771 us | 0.684 us |
