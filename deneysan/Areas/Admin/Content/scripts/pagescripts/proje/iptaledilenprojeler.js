$(function () {
    var id = 0;
    $("#LanguageList").change(function () {
        var lang = $("#LanguageList option:selected").val();
        window.location.href = "/yonetim/onaylananprojeler/" + lang;
    });

    $("#GroupList").change(function () {
        var lang = $("#LanguageList option:selected").val();
        id = $("#GroupList option:selected").val();
        window.location.href = "/yonetim/onaylananprojeler/" + lang + "/" + id;
    });
   // SortOrderByCategory(id, "/Product/SortRecords");
});


function ProjeDurumChanged(e, id) {
    var status = $(e).find("option:selected").val();

    $.ajax({
        type: 'POST',
        url: '/Project/ChangeProjectStatus',
        data: '{id:"' + id + '",status:"' + status + '"}',
        contentType: "application/json; charset=utf-8",
        dataType: 'json',
        success: function (result) {
            if (result == "true" || result == "True") {
                $(this).closest("tr").fadeOut();

            }
            else {
                alert("İşlem sırasında bir hata oluştu");
            }
        },
        error: function () {
            alert("İşlem sırasında bir hata oluştu");
        }
    });

}