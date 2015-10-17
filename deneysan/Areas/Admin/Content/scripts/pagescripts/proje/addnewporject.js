var imageFiles = [];
var addedFile = "";
jQuery(function ($) {

    var docSize = 0;

    $('#projedokumanfile').uploadify({
        'preventCaching': false,
        'swf': "http://localhost:1745/js/uploadify/uploadify.swf",
        "uploader": '../FProjects/SaveProjectDocumentFile',
        'folder': 'http://localhost:1745/Content/uploads',
        "cancelImg": "http://localhost:1745/js/uploadify/uploadify-cancel.png",
        "removeCompleted": false,
        'buttonText': 'Dosya Seçin',
        'queueSizeLimit': 1,
        'multi': false,
        'onUploadSuccess': function (file, data, response) {
            $('#projedokumanfile').uploadify('disable', true);
            $("#hdndokumanfile").val(data);
            $('.uploadify-queue').css("display", "block");
            //$('.uploadify-queue').show();
            $(".uploadify-queue-item").children(".cancel").children("a").attr("href", "#");
            $(".uploadify-queue-item").children(".cancel").children("a").remove();
            $(".uploadify-queue-item").children(".cancel").append("<span onclick='RemoveDocumentFile();return false;' style='float:right;cursor:pointer;'>X</span>");

            //  $(".uploadify-queue-item").children(".cancel").children("a").attr("onclick", "RemoveDocumentFile()");
        }

    });


    $('#projeresimfile').uploadify({
        'preventCaching': false,
        'swf': "http://localhost:1745/js/uploadify/uploadify.swf",
        "uploader": '../FProjects/SaveProjectImages',
        'folder': 'http://localhost:1745/Content/uploads',
        "cancelImg": "http://localhost:1745/js/uploadify/uploadify-cancel.png",
        "removeCompleted": false,
        'buttonText': 'Dosya Seçin',
        'uploadLimit': 5,
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

    //$('#projedokumanfile').fileupload({
    //    url: '../FProjects/SaveProjectDocumentFile',
    //    dataType: 'json',
    //    autoUpload: false,
    //    done: function (e, data) {
    //        $.each(data.result.files, function (index, file) {
    //            $('<p/>').text(file.name).appendTo('#files');
    //        });
    //    },
    //    progressall: function (e, data) {
    //        var progress = parseInt(data.loaded / data.total * 100, 10);
    //        $('#progress .progress-bar').css(
    //            'width',
    //            progress + '%'
    //        );
    //    }
    //}).prop('disabled', !$.support.fileInput)
    //  .parent().addClass($.support.fileInput ? undefined : 'disabled');

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



function RemoveDocumentFile() {
    $('.uploadify-queue').css("display", "none");
    $('#projedokumanfile-button').removeClass('disabled');
    $("#hdndokumanfile").val("");
}

function Success() {
    $("#loader-overlay").fadeOut();

    $("#projectform input[type='text']").val("");
    $("textarea").val("");
    $('#projedokumanfile-button').removeClass('disabled');

    $('.uploadify-queue').css("display", "none");
    //alert("Proje başarıyla kaydedildi");

    $("#successdiv").removeClass("hide");
    $("#errordiv").addClass("hide");
}

function ShowLoader() {
    $("#loader-overlay").fadeIn();
}

function showError() {
    $("#loader-overlay").fadeOut();

    $("#projectform input[type='text']").val("");
    $("textarea").val("");
    $('#projedokumanfile-button').removeClass('disabled');

    $('.uploadify-queue').css("display", "none");
    //alert("Proje başarıyla kaydedildi");

    $("#errordiv").removeClass("hide");
    $("#successdiv").addClass("hide");
}