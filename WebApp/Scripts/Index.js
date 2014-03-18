$.validator.setDefaults({
    showErrors: function (errorMap, errorList) {
        this.defaultShowErrors();

        // destroy tooltips on valid elements                              
        $("." + this.settings.validClass)
            .tooltip("destroy");

        // add/update tooltips 
        for (var i = 0; i < errorList.length; i++) {
            var error = errorList[i];

            $("#" + error.element.id)
                .tooltip({ trigger: "focus" })
                .attr("data-original-title", error.message);
        }
    }
});


function personAdded() {
    $('#addPersonModal').modal('hide');
}


function personUpdated() {
    $('#updatePersonModal').modal('hide');
}

function showModal() {
    $.validator.unobtrusive.parse($('#updatePersonModal').find('form'));
    $('#updatePersonModal').modal('show');
}

$(function() {
    $('.modal').on('hidden.bs.modal', function(e) {
        var form = $(this).find('form');
        var validator = form.validate();
        validator.resetForm();
        form.trigger('reset');
    });
});

