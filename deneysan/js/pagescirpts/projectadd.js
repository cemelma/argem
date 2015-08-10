jQuery(function ($) {
    $('.multi').Multifile();
    //$('#projedokumanfile').uploadify({
    //    'preventCaching': false,
    //    'swf': "http://localhost:1745/js/uploadify/uploadify.swf",
    //    "uploader": '../FProjects/SaveProjectDocumentFile',
    //    'folder': 'http://localhost:1745/Content/uploads',
    //   "cancelImg": "http://localhost:1745/js/uploadify/uploadify-cancel.png",
    //    "removeCompleted": false,
    //    'buttonText': 'Dosya Seçin',
       
    //    'multi': false,
    //    'onUploadSuccess': function (file, data, response) {
    //        //$('.uploadify-queue').show();
    //        $(".uploadify-queue-item").children(".cancel").children("a").attr("href", "#");
    //        $(".uploadify-queue-item").children(".cancel").children("a").attr("onclick", "RemoveDocumentFile()");
    //    }
 
    //});

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
    
}

function Success()
{
    alert("Dosya başarıyla kaydedildi");
}
