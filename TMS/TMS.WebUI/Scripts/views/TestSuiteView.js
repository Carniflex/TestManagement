$('button#addsuite').click(function() {
    $.ajax({
        url: '/TestSuite/CreateTestSuite',
        contentType: 'application/html; charset=utf-8',
        type: 'GET',
        dataType: 'html'
    })
   .success(function (result) {
            
       $('#partialcontent').html(result);
            $('#TestPlanId').val($('#currentPlanId').val());
        })
   .error(function (xhr, status) {
       alert(status);
   })

})



$('#suite').on('click', '#suiteitem', function () {

    var id = $(this).attr("value");

    $.ajax({

        url: '/TestSuite/TestSuiteDetails/' + id,
        contentType: 'application/html; charset=utf-8',
        type: 'GET',
        dataType: 'html'
    })
       .success(function (result) {

           $('#partialcontent').html(result);
           $('#TestPlanId').val($('#currentPlanId').val());
           $('#editTestSuite').bind('click', editTestSuite);
           $('#currentTestSuiteId').val(id);
       })
       .error(function (xhr, status) {
           alert(status);
       })

});


function editTestSuite() {

    $.ajax({
            url: '/TestSuite/EditTestSuite/' + $('#currentTestSuiteId').attr("value"),
            contentType: 'application/html; charset=utf-8',
            type: 'GET',
            dataType: 'html'
        })
        .success(function(result) {

            $('#partialcontent').html(result);
            $('#TestPlanId').val($('#currentPlanId').val());
            $('#addtestcase').bind('click', createTestCase);
        })
        .error(function(xhr, status) {
            alert(status);
        });


}

function createTestCase() {

    var id = $('#ID').val();

    $.ajax({
            url: '/TestCase/CreateTestCase',
            contentType: 'application/html; charset=utf-8',
            type: 'GET',
            dataType: 'html'
        })
        .success(function(result) {

            $('#partialcontent').html(result);
            $('#TestCaseModel_TestSuiteId').val(id);
        })
        .error(function(xhr, status) {
            alert(status);
        });

};
