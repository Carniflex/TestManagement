    $(document).ready(function () {
        $("#btnSave").click(function () {

            $.ajax(
            {

                type: "POST", //HTTP POST Method  
                url: "/Project/CreateProject", // Controller/View   
                data: { //Passing data  

                    ProjectName: $("#projectModel_ProjectName").val(), //Reading text box values using Jquery   
                    PaymentType: $("#projectModel_PaymentType").val(),
                    Status: $("#projectModel_Status").val(),
                    UserId: $("#projectModel_UserId").val()
                }

            }).success(function (result) {

                
                if (result.code == "error") {
                    
                    $("#successbar").slideDown(300);

                }
                else {

                    window.location.href = result;
                }
             

            });

        });
    });




 $(document).ready(function () {
        $("#btnUpdate").click(function () {
          $.ajax(
            {

                type: "POST", //HTTP POST Method  
                url: "/Project/EditProject", // Controller/View   
                data: { //Passing data  
                    ID:$("#projectModel_ID").val(),
                    ProjectName: $("#projectModel_ProjectName").val(), //Reading text box values using Jquery   
                    PaymentType: $("#projectModel_PaymentType").val(),
                    Status: $("#projectModel_Status").val(),
                    UserId: $("#projectModel_UserId").val()
                }

            }).success(function (result) {

                if (result.code == "error") {

                    $("#successbar").slideDown(300);

                }
                else {

                    window.location.href = result;
                }

            });

        });
    });
