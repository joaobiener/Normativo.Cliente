function Print() {
    $(".hideWhenPrint").hide();
    window.print();
    $(".hideWhenPrint").show();
}

function PrintPanel() {
    var panel = document.getElementById("content");
    $(".hideWhenPrint").hide();

    var printWindow = window.open('', '', 'height=400,width=800');
    printWindow.document.write('<html><head><title></title>');
    printWindow.document.write('</head><body >');
    printWindow.document.write(panel.innerHTML);
    printWindow.document.write('</body></html>');
    printWindow.document.close();
    setTimeout(function () {
        printWindow.print();
        printWindow.close();
    }, 500);
    $(".hideWhenPrint").show();
    return false;
}