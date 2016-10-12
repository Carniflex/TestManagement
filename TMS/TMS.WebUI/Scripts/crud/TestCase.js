$(document).on('click','#createTestCase',
        function ()
        {

            var data = JSON.stringify({ //Passing data  
                TestCaseName: $("#TestCaseModel_TestCaseName").val(), //Reading text box values using Jquery   
                SrsLink: $("#TestCaseModel_SrsLink").val(),
                RunStatus: $("#TestCaseModel_RunStatus").val(),
                Steps: $("#TestCaseModel_Steps").val(),
                TestSuiteId: $("#TestCaseModel_TestSuiteId").val(),
           
            });
                     
            $.ajax(
            {
                type: "POST", //HTTP POST Method  
                url: "/TestCase/CreateTestCase", // Controller/View   
                contentType :'application/json; charset=utf-8',
                data: data
                })
                .success(function(result) {

                   
                
                    if (result.code == "error") {

                        $("#successbar").slideDown(300);

                    } else {
                   
                        window.location.href = result;
                    }


                });


        });




$(document).on('click', '#updateTestCase',
        function () {

            var data = JSON.stringify({ //Passing data
                ID: $("#testCaseId").val(),
                TestCaseName: $("#TestCaseModel_TestCaseName").val(), //Reading text box values using Jquery   
                Author: $("#TestCaseModel_Author").val(),
                Steps: $("#TestCaseModel_Steps").val(),
                SrsLink: $("#TestCaseModel_SrsLink").val(),
                RunStatus: $("#TestCaseModel_RunStatus").val(),
                TestSuiteId: $("#TestCaseModel_TestSuiteId").val()
           
            });

            $.ajax(
            {
                type: "POST", //HTTP POST Method  
                url: "/TestCase/EditTestCase", // Controller/View   
                contentType: 'application/json; charset=utf-8',
                data: data
            })
                .success(function (result) {


                    debugger;
                    if (result.code == "error") {

                        $("#successbar").slideDown(300);

                    } else {

                        window.location.href = result;
                    }


                });


        });


