module Janus.Page.Computers {
    class GetComputers {
        constructor() {

        }

        Get() {
            var req = new XMLHttpRequest();
            req.open('GET', '/api/ComputersIDs/GetComputerIDs');
            req.onload = function () {
                if (req.status == 200) {
                    try {
                        alert(req.responseXML);
                    }catch (e){
                        // No data was found.
                    }
                    
                }
            }
            req.send();
        }
    }
}