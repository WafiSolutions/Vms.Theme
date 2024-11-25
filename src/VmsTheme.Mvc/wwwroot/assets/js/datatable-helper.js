var _dataTable = {};
var _dotNetRef = {};
var _filter = {};

// Default configuration options
const defaultOptions = {
    processing: true,
    paging: true,
    info: true,
    searching: false,
    autoWidth: false,
    scrollCollapse: true,
    scrollX: true,
    conditionalPaging: true,
    pageLength: 10,
    lengthMenu: [
        [10, 25, 50, 100, 1000],
        [10, 25, 50, 100, 'All']],
    serverSide: true,
    order: []
};

function initializeDataTable(dotNetRef, options)
{
    _filter = {};
    _dotNetRef = dotNetRef;

    var datatables = abp.utils.createNamespace(abp, 'libs.datatables');
    var datatableLanguages = datatables.defaultConfigurations.language();
    delete datatableLanguages.paginate;

    datatables.defaultConfigurations.language = function () {
        return datatableLanguages;
    };

    // Use the passed options to override the default ones
    const extendedOptions = Object.assign({}, defaultOptions, options);
    //Added actions panel
    renderFunctionAlive(extendedOptions);

    if (options.hasExportOptions)
    {
        extendedOptions["buttons"] = [
            {
                extend: 'csv',
                orientation: 'landscape'
            },
            {
                extend: 'excel',
                orientation: 'landscape'
            },
            {
                extend: 'pdf',
                orientation: 'landscape'
            }
        ]
    }
    
    _dataTable = $(`#${options.gridId}`).DataTable(abp.libs.datatables.normalizeConfiguration({
        ...extendedOptions,
        ajax: abp.libs.datatables.createAjax(eval(options.apiReference), function () {
            return {
                filter: _filter
            }
        }),
        layout: {
            topStart: ['buttons', 'pageLength']
        },
    }));
    
    setTimeout(() => {
        // Manually add buttons to the specified container
        _dataTable.buttons().container()
            .appendTo(`#${options.gridId}_wrapper`);
    }, 100);
}

function reload() {
    _dataTable.ajax.reload();
}

function renderFunctionAlive(extendedOptions) {
    var columnDefs = extendedOptions["columnDefs"];

    for (var i = 0; i < columnDefs.length; i++) {
        var columnDef = columnDefs[i];

        if (!!columnDef.render && typeof (columnDef.render) != "function")
        {
            columnDef.render = new Function(columnDef.render)();
        }
    }
}

function filter(customFilter)
{
    _filter = customFilter;

    // Reload the DataTable with the updated filter
    _dataTable.ajax.reload();
}

function blazorEventTrigger(functionName)
{
    if (arguments.length > 0)
    {
        var params = [];
        params.push(functionName);

        for (var i = 0; i < arguments.length; i++) {
            if (i != 0) {
                params.push(arguments[i]);
            }
        }

        _dotNetRef.invokeMethodAsync.apply(_dotNetRef, params);
    }
    else
    {
        _dotNetRef.invokeMethodAsync(functionName)
            .then(() => {
                console.log('Blazor function was called with parameter.');
            })
            .catch(error => console.error(error));
    }
}

function exportCsv()
{
    $(".buttons-csv").trigger("click");
}

function exportExcel() {
    $(".buttons-excel").trigger("click");
}

function exportPdf() {
    $(".buttons-pdf").trigger("click");
}
