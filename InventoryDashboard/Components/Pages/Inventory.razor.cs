using InventoryReport.Data;
using Microsoft.AspNetCore.Components;
using System.Globalization;

namespace InventoryDashboard.Components.Pages
{
    public partial class Inventory
    {

        protected override async Task OnInitializedAsync()
        {
            Items = await InventoryService.GetInventoryItemsAsync();
        }

        public int CurrentPage { get; set; } = 1;
        public int PageSize { get; set; } = 10;
        public int TotalPages => (int)Math.Ceiling(FilteredItemsUnpaginated.Count() / (double)PageSize);

        public IEnumerable<InventoryItem> FilteredItemsUnpaginated =>
            GetSortedItems(Items.Where(CombinedFilter));

        public IEnumerable<InventoryItem> FilteredItems =>
            FilteredItemsUnpaginated
                .Skip((CurrentPage - 1) * PageSize)
                .Take(PageSize);


        [Parameter] public List<InventoryItem> Items { get; set; } = new();
        [Parameter] public EventCallback<InventoryItem> OnRowSelected { get; set; }

        public string? _searchTerm;
        public string? searchTerm
        {
            get => _searchTerm;
            set
            {
                _searchTerm = value;
                DebounceFilter();
            }
        }

        private DateTime? _startDate;
        public DateTime? startDate
        {
            get => _startDate;
            set
            {
                _startDate = value;
                StateHasChanged();
            }
        }

        private DateTime? _endDate;
        public DateTime? endDate
        {
            get => _endDate;
            set
            {
                _endDate = value;
                StateHasChanged();
            }
        }


        public CancellationTokenSource? _debounceCts;
        public string? sortColumn;
        public bool sortAscending = true;
        public InventoryItem? selectedItem;
        public InventoryItem? ExpandedItem { get; set; }

        public async void DebounceFilter()
        {
            _debounceCts?.Cancel();
            _debounceCts = new CancellationTokenSource();

            try
            {
                await Task.Delay(200, _debounceCts.Token);
                await InvokeAsync(StateHasChanged);
            }
            catch (TaskCanceledException)
            {
                // Debounced
            }
        }

        public IOrderedEnumerable<InventoryItem> GetSortedItems(IEnumerable<InventoryItem> items)
        {
            if (string.IsNullOrEmpty(sortColumn))
                return items.OrderBy(x => x.Id);

            return sortAscending
                ? items.OrderBy(GetPropertyValue)
                : items.OrderByDescending(GetPropertyValue);
        }

        public object GetPropertyValue(InventoryItem item) => sortColumn switch
        {
            "Id" => item.Id,
            "Date" => item.Date,
            "CI" => item.CI,
            "DocType" => item.DocType,
            "Cargo" => item.Cargo,
            "Weight" => item.Weight,
            "Parcels" => item.Parcels,
            "Value" => item.Value,
            "Customer" => item.Customer,
            "DateLeft" => item.DateLeft ?? DateTime.MinValue,
            _ => item.Id
        };

        public bool FilterFunc(InventoryItem item)
        {
            if (string.IsNullOrWhiteSpace(searchTerm)) return true;

            var term = searchTerm!.Trim().ToLowerInvariant();

            return CheckMatch(item.Id.ToString(), term)
                || CheckMatch(item.Date.ToString("d"), term)
                || CheckMatch(item.CI, term)
                || CheckMatch(item.DocType, term)
                || CheckMatch(item.Cargo, term)
                || CheckMatch(item.Weight.ToString(CultureInfo.InvariantCulture), term)
                || CheckMatch(item.Parcels.ToString(), term)
                || CheckMatch(item.Value.ToString(CultureInfo.InvariantCulture), term)
                || CheckMatch(item.Customer, term)
                || CheckMatch(item.DateLeft?.ToString("d"), term);
        }

        public bool CombinedFilter(InventoryItem item)
        {
            bool matchesSearch = string.IsNullOrWhiteSpace(searchTerm) || FilterFunc(item);

            bool matchesDate = true;
            if (startDate.HasValue && endDate.HasValue)
                matchesDate = item.Date >= startDate.Value && item.Date <= endDate.Value;

            return matchesSearch && matchesDate;
        }

        public static bool CheckMatch(string? value, string term) =>
            !string.IsNullOrEmpty(value) && value.ToLowerInvariant().Contains(term);

        public void Dispose() => _debounceCts?.Cancel();

        public void SortBy(string columnName)
        {
            if (sortColumn == columnName)
                sortAscending = !sortAscending;
            else
            {
                sortColumn = columnName;
                sortAscending = true;
            }
            StateHasChanged();
        }

        public MarkupString SortIcon(string columnName)
        {
            if (sortColumn != columnName)
                return (MarkupString)"&nbsp;&nbsp;";

            return sortAscending
                ? (MarkupString)"&nbsp;↑"
                : (MarkupString)"&nbsp;↓";
        }

        public async Task OnRowClick(InventoryItem item)
        {
            selectedItem = item;

            // Toggle expansion
            if (ExpandedItem == item)
                ExpandedItem = null;
            else
                ExpandedItem = item;

            await OnRowSelected.InvokeAsync(item);
        }

        public void NextPage()
        {
            if (CurrentPage < TotalPages)
            {
                CurrentPage++;
                StateHasChanged();
            }
        }

        public void PrevPage()
        {
            if (CurrentPage > 1)
            {
                CurrentPage--;
                StateHasChanged();
            }
        }

        public bool CanGoNext => CurrentPage < TotalPages;
        public bool CanGoPrev => CurrentPage > 1;


    }
}