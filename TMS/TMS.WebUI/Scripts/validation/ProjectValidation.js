
$(document)
    .ready(function() {

        $("#btnSave")
            .click(function() {

                validate();
            });
    });



function validate() {

  
    $('#createProject').valid({ // initialize the plugin
        rules: {
            ProjectName: {
                required: true
               
            },
            messages: {
                ProjectName: {
                    required: 'Enter project name'
                }
            }
            
        }
    });

};