using BenchmarkDotNet.Attributes;

namespace Benchmark;

public class Bench
{
    [Benchmark]
    public async Task<string> Preload() => await TestServices.ExecuteRequestAsync(c => c.SetQuery(
        """
        fragment EverythingDataProduct on DataProduct {
          field01
          field02
          field03
          field04
          field05
          field06
          field07
          field08
          field09
          field10
          field11
          field12
          field13
          field14
          field15
          field16
          field17
          field18
          field19
          field20
          field21
          field22
          field23
          field24
          field25
          field26
          field27
          field28
          field29
          field30
          field31
          field32
          field33
          field34
          field35
          field36
          field37
          field38
          field39
          field40
          field41
          field42
          field43
          field44
          field45
          field46
          field47
          field48
          field49
          field50
          field51
          field52
          field53
          field54
          field55
          field56
          field57
          field58
          field59
          field60
          field61
          field62
          field63
          field64
          field65
          field66
          field67
          field68
          field69
          field70
          field71
          field72
          field73
          field74
          field75
          field76
          field77
          field78
          field79
          field80
          field81
          field82
          field83
          field84
          field85
          field86
          field87
          field88
          field89
          field90
          field91
          field92
          field93
          field94
          field95
          field96
          field97
          field98
          field99
        }
        
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
          product06: dataProductById(id: "RGF0YVByb2R1Y3QKaTY=") {
            ...EverythingDataProduct
          }
          product07: dataProductById(id: "RGF0YVByb2R1Y3QKaTc=") {
            ...EverythingDataProduct
          }
          product08: dataProductById(id: "RGF0YVByb2R1Y3QKaTg=") {
            ...EverythingDataProduct
          }
          product09: dataProductById(id: "RGF0YVByb2R1Y3QKaTk=") {
            ...EverythingDataProduct
          }
          product10: dataProductById(id: "RGF0YVByb2R1Y3QKaTEw") {
            ...EverythingDataProduct
          }
        }
        """));

    [Benchmark]
    public async Task<string> OnDemand() => await TestServices.ExecuteRequestAsync(c => c.SetQuery(
      """
      fragment EverythingLazyProduct on LazyProduct {
        field01
        field02
        field03
        field04
        field05
        field06
        field07
        field08
        field09
        field10
        field11
        field12
        field13
        field14
        field15
        field16
        field17
        field18
        field19
        field20
        field21
        field22
        field23
        field24
        field25
        field26
        field27
        field28
        field29
        field30
        field31
        field32
        field33
        field34
        field35
        field36
        field37
        field38
        field39
        field40
        field41
        field42
        field43
        field44
        field45
        field46
        field47
        field48
        field49
        field50
        field51
        field52
        field53
        field54
        field55
        field56
        field57
        field58
        field59
        field60
        field61
        field62
        field63
        field64
        field65
        field66
        field67
        field68
        field69
        field70
        field71
        field72
        field73
        field74
        field75
        field76
        field77
        field78
        field79
        field80
        field81
        field82
        field83
        field84
        field85
        field86
        field87
        field88
        field89
        field90
        field91
        field92
        field93
        field94
        field95
        field96
        field97
        field98
        field99
      }
      
      query lazyProduct {
        product01: lazyProductById(id: "TGF6eVByb2R1Y3QKaTE=") {
          ...EverythingLazyProduct
        }
        product02: lazyProductById(id: "TGF6eVByb2R1Y3QKaTI=") {
          ...EverythingLazyProduct
        }
        product03: lazyProductById(id: "TGF6eVByb2R1Y3QKaTM=") {
          ...EverythingLazyProduct
        }
        product04: lazyProductById(id: "TGF6eVByb2R1Y3QKaTQ=") {
          ...EverythingLazyProduct
        }
        product05: lazyProductById(id: "TGF6eVByb2R1Y3QKaTU=") {
          ...EverythingLazyProduct
        }
        product06: lazyProductById(id: "TGF6eVByb2R1Y3QKaTY=") {
          ...EverythingLazyProduct
        }
        product07: lazyProductById(id: "TGF6eVByb2R1Y3QKaTc=") {
          ...EverythingLazyProduct
        }
        product08: lazyProductById(id: "TGF6eVByb2R1Y3QKaTg=") {
          ...EverythingLazyProduct
        }
        product09: lazyProductById(id: "TGF6eVByb2R1Y3QKaTk=") {
          ...EverythingLazyProduct
        }
        product10: lazyProductById(id: "TGF6eVByb2R1Y3QKaTEw") {
          ...EverythingLazyProduct
        }
      }
      """));
}