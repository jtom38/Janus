
class GetComputers {
    constructor() {

    }

    Get() {
        var req = new XMLHttpRequest();
        req.open('GET', '/api/ComputersIDs/');
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

    Hello() {
        alert("Hello World.. did I work?")
    }
}
