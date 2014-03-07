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

