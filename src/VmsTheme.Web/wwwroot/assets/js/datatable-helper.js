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
    _dotNetRef = dotNetRef;

    var datatables = abp.utils.createNamespace(abp, 'libs.datatables');

    datatables.defaultConfigurations.language = function () {
        return {};
    };

    // Use the passed options to override the default ones
    const extendedOptions = Object.assign({}, defaultOptions, options);
    //Added actions panel
    renderFunctionAlive(extendedOptions);

    _dataTable = $(`#${options.gridId}`).DataTable(abp.libs.datatables.normalizeConfiguration({
        ...extendedOptions,
        ajax: abp.libs.datatables.createAjax(eval(options.apiReference), function () {
            return {
                filter: _filter
            }
        })
    }));
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

function blazorEventTrigger(functionName, parameter)
{
    if (!!parameter) {
        _dotNetRef.invokeMethodAsync(functionName, parameter)
            .then(() => {
                console.log('Blazor function was called with parameter.');
            })
            .catch(error => console.error(error));
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
