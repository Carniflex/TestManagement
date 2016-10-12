function getParameterByName(name, url)
{
    if (!url) url = window.location.href;
    name = name.replace(/[\[\]]/g, "\\$&");
    var regex = new RegExp("[?&]" + name + "(=([^&#]*)|&|#|$)"),
        results = regex.exec(url);
    if (!results) return null;
    if (!results[2]) return '';
    return decodeURIComponent(results[2].replace(/\+/g, " "));
}

function removeParamFromUrl(url) {

    url = document.location.href;
    var parts = url.split('?');
    if (parts.length == 2) {
        var baseUrl = parts[0];
        window.location.replace(baseUrl);
       
    }
}



    $(document).ready(function () {

        if (getParameterByName("status", document.URL) == "success") {
            $("#successbar").slideDown(300);
        }

    });


$(document)
    .ready(function() {

        $("#close")
            .click(function() {
                $("#successbar").hide("fast");
                removeParamFromUrl(document.URL);
            });

    });


//validation error


   