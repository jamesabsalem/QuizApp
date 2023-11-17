function ShowToastr(messageType, message) {
    window.toastr.options = {
        "closeButton": true,
        "debug": false,
        "newestOnTop": false,
        "progressBar": true,
        "positionClass": "toast-bottom-right",
        "preventDuplicates": false,
        "onclick": null,
        "showDuration": "300",
        "hideDuration": "1000",
        "timeOut": "5000",
        "extendedTimeOut": "1000",
        "showEasing": "swing",
        "hideEasing": "linear",
        "showMethod": "fadeIn",
        "hideMethod": "fadeOut"
    };

    switch (messageType) {
        case "success":
            window.toastr.success(message,"Success");
            break;
        case "warning":
            window.toastr.warning(message,"Warning");
            break;
        case "error":
            window.toastr.error(message,"Error");
            break;
        case "info":
            window.toastr.info(message,"Info");
    }
}