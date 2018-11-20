var GetComputers = /** @class */ (function () {
    function GetComputers() {
    }
    GetComputers.prototype.Get = function () {
        var req = new XMLHttpRequest();
        req.open('GET', '/api/ComputersIDs/');
        req.onload = function () {
            if (req.status == 200) {
                try {
                    alert(req.responseXML);
                }
                catch (e) {
                    // No data was found.
                }
            }
        };
        req.send();
    };
    GetComputers.prototype.Hello = function () {
        alert("Hello World.. did I work?");
    };
    return GetComputers;
}());
