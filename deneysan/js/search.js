

$(document).ready(function(){ 
    var $hiddenSearch = $("#hidden-search"),
//		$displaySearch = $("#display-search"),
		$searchOverlay = $("#search-overlay");
//		$artistsList = $("#artists");


    $("#search").click(function () { //when the search link is clicked...
        $searchOverlay.show(); //show the search overlay
        $hiddenSearch.val("");
        $hiddenSearch.focus(); //give the hidden input box focus
    });

    $(".searchboxclose").click(function () {
        $("#search-overlay").fadeOut();
    });


    $('#hidden-search').live("keypress", function(e) {
        if (e.keyCode == 13) {
            var lang = $("#hdnCulture").val();
            var crt = $("#hidden-search").val();
            $.post("../FHome/KriteriAyarla", { kriter: crt })
           .done(function () {
               if (lang == "tr")
                   window.location = "/tr/projelistesi";
               else
                   window.location = "/en/projectlist";
               return false; // prevent the button click from happening
           });



            
        }
    });


  



});



function closeSearchPanel() {
   
}