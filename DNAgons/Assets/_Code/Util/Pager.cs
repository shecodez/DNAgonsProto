using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pager {

    public int TotalItems { get; private set; }
    public int CurrentPage { get; private set; }
    public int ItemsPerPage { get; private set; }
    public int TotalPages { get; private set; }

    public int StartIndex { get; private set; }
    public int EndIndex { get; private set; }

    public Pager (int totalItems, int? page, int itemsPerPage = 4)
    {
        var _totalPages = (int)Mathf.Ceil((float)totalItems / (float)itemsPerPage);
        var _currentPage = page != null ? (int)page : 1;

        int _startIndex = _currentPage * itemsPerPage - itemsPerPage;

        int _endIndex = _startIndex + itemsPerPage;
        if (_endIndex > totalItems)
            _endIndex = totalItems;

        TotalItems = totalItems;
        ItemsPerPage = itemsPerPage;
        CurrentPage = _currentPage;
        TotalPages = _totalPages;

        StartIndex = _startIndex;
        EndIndex = _endIndex;
    }

    public void Print()
    {
        Debug.Log("Total Items: "+ TotalItems);
        Debug.Log("Items Per Page: "+ ItemsPerPage);
        Debug.Log("Current Page: " + CurrentPage);
        Debug.Log("Total Pages: " + TotalPages);
        Debug.Log("Start Index: " + StartIndex);
        Debug.Log("End Index: " + EndIndex);
    }
}
