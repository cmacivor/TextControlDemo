function SaveToController(DocumentName) {
    TXTextControl.saveDocument(TXTextControl.streamType.InternalUnicodeFormat,
        function (e) {
            console.log(DocumentName)
            console.log(e.data)
            var serviceURL = "/Home/SaveTemplate";

            $.ajax({
                type: "POST",
                url: serviceURL,
                contentType: 'application/json',
                data: JSON.stringify({
                    DocumentName: DocumentName,
                    BinaryDocument: e.data
                }),
                success: successFunc,
                error: errorFunc
            });

            function successFunc(data, status) {
                var modal = document.getElementById("myModal");
                modal.style.display = "none";
                alert("Document has been saved successfully.");
            }

            function errorFunc() {
                alert('Error');
            }
        });
}


function saveFile() {
    var fileName = document.getElementById("txtFileName").value;

    SaveToController(fileName);
}

function loadFile() {
    var fileName = document.getElementById("txtFileName").value;
    LoadFromController(fileName);
}



// load the document from the controller and load
// it into the TXTextControl.Web
function LoadFromController(DocumentName) {
    var serviceURL = "/Home/LoadTemplate";
    $.ajax({
        type: "POST",
        url: serviceURL,
        contentType: 'application/json',
        data: JSON.stringify({
            DocumentName: DocumentName
        }),
        success: successFunc,
        error: errorFunc
    });
    function successFunc(data, status) {
        TXTextControl.isTrackChangesEnabled = true;
        TXTextControl.showSideBar(TXTextControl.SideBarType.TrackChanges, 1);
        TXTextControl.loadDocument(TXTextControl.streamType.InternalUnicodeFormat, data);
    }
    function errorFunc() {
        alert('Error');
    }

}

function trackedChangeSwitchEventHandler() {
    var checkBox = document.getElementById("chkTrackChanges");
    if (checkBox.checked) {
        //alert('its checked!');
        TXTextControl.isTrackChangesEnabled = true;
        TXTextControl.showSideBar(TXTextControl.SideBarType.TrackChanges, 1);
    } else {
        alert('its not checked');
    }
}


function openModal() {
    alert('test');
}
