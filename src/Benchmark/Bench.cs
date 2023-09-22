using BenchmarkDotNet.Attributes;

namespace Benchmark;

public class Bench
{
    [Benchmark]
    public async Task<string> Everything() => await TestServices.ExecuteRequestAsync(c => c.SetQuery(
        """
        query everything {
          authorById(id: "QXV0aG9yCmkx") {
            name
            bio
            books(first: 3) {
              nodes {
                title
              }
            }
          }
        }
        """));

    [Benchmark]
    public async Task<string> BooksOnly() => await TestServices.ExecuteRequestAsync(c => c.SetQuery(
      """
      query booksOnly {
        authorById(id: "QXV0aG9yCmkx") {
          books(first: 3) {
            nodes {
              title
            }
          }
        }
      }
      """));
}