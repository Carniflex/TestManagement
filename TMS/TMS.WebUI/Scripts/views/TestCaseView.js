$('#case').on('click', '#testcasedetails',function() {
        var id = $(this).attr("value");
        $.ajax({
                url: '/TestCase/TestCaseDetails/' + id,
                contentType: 'application/html; charset=utf-8',
                type: 'GET',
                dataType: 'html'
            })
            .success(function(result) {

                $('#partialcontent').html(result);
                $('#currentTestCaseId').val(id);
                $('#editTestCase').bind('click', editTestCase);
            })
            .error(function(xhr, status) {
                alert(status);
            });

    });


function editTestCase() {

    $.ajax({
        url: '/TestCase/EditTestCase/' + $('#currentTestCaseId').attr("value"),
        contentType: 'application/html; charset=utf-8',
        type: 'GET',
        dataType: 'html'
    })
        .success(function (result) {

            $('#partialcontent').html(result);
            $('#TestPlanId').val($('#currentPlanId').val());
            $('#addtestcase').bind('click', createTestCase);
        })
        .error(function (xhr, status) {
            alert(status);
        });


}


