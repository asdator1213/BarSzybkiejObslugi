$.connection.hub.start()
    .done(function (data) {
        for (var i = 0; i < data.length; i++) {
            console.log(data[i].DataDodania);
        }
            
    })
    .fail(function () { console.log("WEEE NOT WORKIN :(") });