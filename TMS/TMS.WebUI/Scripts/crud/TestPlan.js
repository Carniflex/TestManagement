$(document).ready(function () {
    $("#btnSaveTestPlan").click(function () {

        $.ajax(
        {

            type: "POST", //HTTP POST Method  
            url: "/TestPlan/CreateTestPlan", // Controller/View   
            data: { //Passing data  

                TestPlanName: $("#testPlanModel_TestPlanName").val(), //Reading text box values using Jquery   
                ProjectId: $("#testPlanModel_ProjectId").val(),
                Author: $("#testPlanModel_Author").val(),
                Status: $("#testPlanModel_Status").val()
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
    $("#btnUpdateTestPlan").click(function () {
        $.ajax(
          {

              type: "POST", //HTTP POST Method  
              url: "/TestPlan/EditTestPlan", // Controller/View   
              data: { //Passing data  
                  ID: $("#testPlanModel_ID").val(),
                  TestPlanName: $("#testPlanModel_TestPlanName").val(), //Reading text box values using Jquery   
                  ProjectId: $("#testPlanModel_ProjectId").val(),
                  Author: $("#testPlanModel_Author").val(),
                  Status: $("#testPlanModel_Status").val()
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
