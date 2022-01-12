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


function openModal() {
    alert('test');
}
