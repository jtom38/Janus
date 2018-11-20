var Janus;
(function (Janus) {
    var Page;
    (function (Page) {
        var Computers;
        (function (Computers) {
            var GetComputers = /** @class */ (function () {
                function GetComputers() {
                }
                GetComputers.prototype.Get = function () {
                    var req = new XMLHttpRequest();
                    req.open('GET', '/api/ComputersIDs/GetComputerIDs');
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
                return GetComputers;
            }());
        })(Computers = Page.Computers || (Page.Computers = {}));
    })(Page = Janus.Page || (Janus.Page = {}));
})(Janus || (Janus = {}));
//# sourceMappingURL=ApiComputers.js.map