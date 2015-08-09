jQuery(function ($) {
   
    $('#projedokumanfile').fileupload({
        dataType: 'json',
        url: '../FProjects/SaveProjectDocumentFile',
        done: function (e, data) {
            $('#uploadedfilename').text(data.files[0].name);
            $("#hdndokumanfile").val(data.files[0].name);
        }

        //done: function (e, data) {
        //    $.each(data.result.files, function (index, file) {
        //        $('#uploadedfilename').text(file.name);
        //        $("#hdndokumanfile").val(file.name);
        //    });
        //}
        //error: function () {
        //    alert("dosya yüklemesi sırasında hata oluştu.");
        //}
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

function Success()
{
    alert("Dosya başarıyla kaydedildi");
}
