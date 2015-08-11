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
        "uploader": '../FProjects/SaveProjectDocumentFile',
        'folder': 'http://localhost:1745/Content/uploads',
        "cancelImg": "http://localhost:1745/js/uploadify/uploadify-cancel.png",
        "removeCompleted": false,
        'buttonText': 'Dosya Seçin',
        'uploadLimit': 5,
        'multi': false,
        'onUploadSuccess': function (file, data, response) {
            $("#hdndokumanfile").val(data);
            $('.uploadify-queue').css("display", "block");
            //$('.uploadify-queue').show();
            $(".uploadify-queue-item").children(".cancel").children("a").attr("href", "#");
            $(".uploadify-queue-item").children(".cancel").children("a").remove();
            $(".uploadify-queue-item").children(".cancel").append("<span onclick='RemoveDocumentFile();return false;' style='float:right;cursor:pointer;'>X</span>");
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


function RemoveDocumentFile() {
    $('.uploadify-queue').css("display","none");
    $('#projedokumanfile-button').removeClass('disabled');
    $("#hdndokumanfile").val("");
}

function Success()
{
    alert("Dosya başarıyla kaydedildi");
}
