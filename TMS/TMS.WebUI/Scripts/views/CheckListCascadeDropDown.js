
function dataFormatter(date) {

     var ndate = date.substr(6);
     var currentTime = new Date(parseInt(ndate));
    var month = currentTime.getMonth() + 1;
    var day = currentTime.getDate();
    var year = currentTime.getFullYear();
    var parsedDate = day + "/" + month + "/" + year;
    return parsedDate;
}


    $(function () {
        $.ajax({
            type: "GET",
            url: "/CheckList/getProjects",
            datatype: "Json",
            success: function (data) {
                $.each(data, function (index, value) {
                    $('#dropdownProjects').append('<option value="' + value.ID + '">' + value.ProjectName + '</option>');
                });
            }
        });
 
        $('#dropdownProjects').change(function () {
 
            $('#dropdownPlan').empty();
 
            $.ajax({
                type: "POST",
                url: "/CheckList/getTestPlans",
                datatype: "Json",
                data: { projectId: $('#dropdownProjects').val() },
                success: function (data) {
                    $.each(data, function (index, value) {
                        $('#dropdownPlan').append('<option value="' + value.ID + '">' + value.TestPlanName + '</option>');
                    });
                }
            });
        });


        $('#sbmCheckList')
            .click(function() {

                $.ajax({
                    type: "POST",
                    url: "/CheckList/getCheckList",
                    datatype: "Json",
                    data: { testPlanId: $('#dropdownPlan').val() },
                    success: function (data) {
                        for (var i = 0; i < data.length; ++i) {
                            $('#suites').append('<tr id="hi"> <td>' + data[i].TestSuiteName + '<td>' + data[i].Author + '</td>' + '<td>' + dataFormatter(data[i].CreatedDate) + '</td></tr>');
                            if (data[i].TestCases.length != 0) {
                                for (var j = 0; j < data[i].TestCases.length; j++) {
                                    $('#cases')
                                        .append('<tr><td>' +
                                            data[i].TestCases[j].TestCaseName +'<td>'+data[i].TestCases[j].Author +'</td>'+'<td>'+data[i].TestCases[j].RunStatus +
                                            '</td></tr>');
                                }
                                
                            }
                        }
                    }
                });
            });
    });



