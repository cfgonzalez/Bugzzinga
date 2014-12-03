Pace.on("start", function () {
    $("#paceDiv").css("display", "block");
});

Pace.on("done", function () {
    $("#paceDiv").css("display", "none");
});


//Mergea dos colecciones por la propiedad de un objeto
function mergearColeccionPorPropiedad(arr1, arr2, prop) {

    return _.each(arr2, function (arr2obj) {
        var arr1obj = _.find(arr1, function (arr1obj) {
            return arr1obj[prop] === arr2obj[prop];
        });

        arr1obj ? _.extend(arr2obj, arr1obj) : arr1.push(arr2obj);
    });
}