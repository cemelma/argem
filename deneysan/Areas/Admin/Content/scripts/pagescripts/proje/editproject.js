var imageCount = 0;
var imageFiles = [];
$(function () {
    var imgsize = $("#imagesCount").val();
    if (imgsize != undefined)
        imageCount = imgsize;
    $('#projedokumanfile').uploadify({
        'preventCaching': false,
        'swf': "/js/uploadify/uploadify.swf",
        "uploader": '/Project/SaveProjectDocumentFile',
        //       'folder': '/Content/uploads',
        //      "cancelImg": "/js/uploadify/uploadify-cancel.png",
        "removeCompleted": false,
        'buttonText': 'Yeni Dosya Seçin',
        'queueSizeLimit': 1,
        'multi': false,
        'uploadLimit' : 1,
        'onUploadSuccess': function (file, data, response) {
            $('#projedokumanfile').uploadify('disable', true);
            $("#hdnProjeDokumani").val(data);
            $(".uploadify-queue-item").css("display", "none");
            $('.uploadify-queue').css("display", "block");
            $(".projedokumanilabel").text(data);
        }
    });



    $('#projeresimfile').uploadify({
        'preventCaching': false,
        'swf': "/js/uploadify/uploadify.swf",
        "uploader": '/Project/SaveProjectImages',
   //     'folder': '/Content/uploads',
        "cancelImg": "/js/uploadify/uploadify-cancel.png",
        "removeCompleted": false,
        'buttonText': 'Dosya Seçin',
        'uploadLimit': 5-imageCount,
        'multi': false,
        'onUploadSuccess': function (file, data, response) {
            imageFiles.push(data);
            $("#hdnimagefile").val(imageFiles);
            addedFile = data;
            //var files = $("#hdnimagefile").val();
            //if (!files) {
            //    files = data;
            //    $("#hdnimagefile").val(files);
            //}
            //else {
            //    files += "," + data;
            //    $("#hdnimagefile").val(files);
            //}

            //  $("#hdndokumanfile").val(data);
            $("#projeresimfile-queue").children('.uploadify-queue-item').each(function () {
                $(this).children(".cancel").children("span").remove();
                $(this).children(".cancel").children("a").attr("href", "#");
                $(this).children(".cancel").children("a").remove();
                $(this).children(".cancel").append("<span onclick='RemoveImageFile(this);return false;' style='float:right;cursor:pointer;'>X</span>");
            });
            //$('.uploadify-queue').show();
            //$(".uploadify-queue-item").children(".cancel").children("a").attr("href", "#");
            //$(".uploadify-queue-item").children(".cancel").children("a").remove();
            //$(".uploadify-queue-item").children(".cancel").append("<span onclick='RemoveDocumentFile();return false;' style='float:right;cursor:pointer;'>X</span>");
        }

    });



});


function RemoveImageFile(e) {
    $(e).parents(".uploadify-queue-item").css("display", "none");

    for (var i = imageFiles.length - 1; i >= 0; i--) {
        if (imageFiles[i] === addedFile) {
            imageFiles.splice(i, 1);
        }
    }

    $("#hdnimagefile").val(imageFiles);

}

function RemoveDokuman() {
    $("#hdnProjeDokumani").val("");
    $('#projedokumanfile-button').removeClass('disabled');
    $(".projedokumanilabel").text("Proje Dökümanı eklenmemiş");
    $("#hdnProjeDokumani").val("");
    $("#Project_ProjeDok_mani").val("");
    $("#dwnloadFile").text("");
}

function DeleteProjectImage(id) {

    var postdata = { id: id };
    $.ajax({
        type: 'POST',
        url: "/Project/DeleteProjectImage",
        data: postdata,
     
        success: function (result) {
            $("#projectImage_" + id).closest("li").fadeOut();
        },
        error: function () {
         alert("İşlem sırasında bir hata oluştu")
        }
    });

}