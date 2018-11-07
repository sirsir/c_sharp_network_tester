var isLoadFinish = false

function SendRequest0(method, url)
{

    //alert(url)
    //return method
    return {
        'method': method,
        'url': url
    }
}

function SendRequest(method,url,data) {
    try {
        setTimeout(function () {
            var returnJson = {}

            // Assign handlers immediately after making the request,
            // and remember the jqxhr object for this request

            $.ajaxSetup({
                async: false,
                dataType: "jsonp"
            });

            returnJson = ""

            $.getJSON(url, function (data) {
                returnJson = JSON.stringify(data)
            })
             .fail(function () {
                 returnJson = ""
             })

            alert(returnJson)

            //log(returnJson)
            return returnJson
        }, 1);

    }
    catch (err) {
        //log(err.message);
    }
}

//alert('xxxxyyyy')

isLoadFinish = true