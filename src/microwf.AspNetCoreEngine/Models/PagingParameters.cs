using System;
using System.Collections.Generic;

namespace tomware.Microwf.Engine
{
  public class PagingParameters
  {
    public int PageIndex { get; set; } = 1;

    public int PageSize { get; set; } = 10;

    public int GetSkipCount()
    {
      return this.PageSize * (this.PageIndex - 1);
    }
  }

  public class PaginatedList<T> : List<T>
  {
    public int PageIndex { get; private set; }
    public int TotalPages { get; private set; }

    public int AllItemCount { get; private set; }

    public PaginatedList(IEnumerable<T> items, int count, int pageIndex, int pageSize)
    {
      PageIndex = pageIndex;
      TotalPages = (int)Math.Ceiling(count / (double)pageSize);
      AllItemCount = count;

      this.AddRange(items);
    }

    public bool HasPreviousPage
    {
      get
      {
        return PageIndex > 1;
      }
    }

    public bool HasNextPage
    {
      get
      {
        return PageIndex < TotalPages;
      }
    }
  }
}