function initializeDropzone(selector)
{
    var dropzoneOptions =
    {
        url: "api/file", // Your API endpoint
        paramName: "file",
        maxFilesize: 5, // Max file size in MB
        acceptedFiles: ".jpg,.jpeg,.png,.pdf", // Allowed file types
        addRemoveLinks: true,
        success: function (file, response) {
            debugger;
        }
    };

    new Dropzone(selector, dropzoneOptions);
}