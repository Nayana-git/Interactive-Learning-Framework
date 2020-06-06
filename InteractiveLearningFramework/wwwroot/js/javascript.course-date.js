$.validator.setDefaults({
    ignore: ""
});

$(function () {

    $('#Description').summernote({
        placeholder: 'Description',
        tabsize: 2,
        height: 300
    });


    var currentDate = new Date();
    var oneYearBefore = new Date(new Date().setFullYear(new Date().getFullYear()));
    var getOnlyYear = oneYearBefore.getFullYear();


    var tenYearBefore = new Date(new Date().setFullYear(oneYearBefore.getFullYear() + 5)).getFullYear();


    $("#start_date").dateDropdowns({
        defaultDateFormat: "mm/dd/yyyy",
        submitFormat: "mm/dd/yyyy",
        displayFormat: "mdy",
        submitFieldName: 'StartDate',
        dropdownClass: 'form-control',
        maxYear: tenYearBefore,
        minYear: getOnlyYear,
        daySuffixes: false,
    });
    $("#end_date").dateDropdowns({
        defaultDateFormat: "mm/dd/yyyy",
        submitFormat: "mm/dd/yyyy",
        displayFormat: "mdy",
        submitFieldName: 'EndDate',
        dropdownClass: 'form-control',
        maxYear: tenYearBefore,
        minYear: getOnlyYear,
        daySuffixes: false,
    });

    $('select.day').addClass('col-md-2 mr-2')
    $('select.month').addClass('col-md-3 mr-2')
    $('select.year').addClass('col-md-2 mr-2')

    addRequiredAttr();

});
$("#start_date").on("change", function () {
    $('span[data-valmsg-for="StartDate"]').removeClass("field-validation-error").addClass("field-validation-valid").text('');
});
$("#end_date").on("change", function () {
    $('span[data-valmsg-for="EndDate"]').removeClass("field-validation-error").addClass("field-validation-valid").text('');
});

function addRequiredAttr() {
    var startDate = document.getElementsByName("StartDate");
    $(startDate).attr('required', 'required');
    $(startDate).attr('title', 'The Start Date field is required.');

    var endDate = document.getElementsByName("EndDate");
    $(endDate).attr('required', 'required');
    $(endDate).attr('title', 'The End Date field is required.');
}

function readURL() {
    var $input = $(this);
    var $newinput = $(this).parent().parent().parent().find('.portimg ');
    if (this.files && this.files[0]) {
        var reader = new FileReader();
        reader.onload = function (e) {
            reset($newinput.next('.delbtn'), true);
            $newinput.attr('src', e.target.result).show();

            $newinput.after('<p><a href="#" class="btn btn-danger delbtn removebtn" role="button">Remove</a></p>');
        }

        reader.readAsDataURL(this.files[0]);
    }
}
$(".fileUpload").change(readURL);
$("form").on('click', '.delbtn', function (e) {
    reset($(this));
});

function reset(elm, prserveFileName) {
    if (elm && elm.length > 0) {
        debugger;
        var $input = elm;
        $input.closest('.upload-demo').find('img').attr('src', '').hide();
        if (!prserveFileName) {
            $($input).parent().parent().parent().parent().find('input.fileUpload').val("");
        }
        elm.remove();
    }
}