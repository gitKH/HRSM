<%@ Page Language="C#" Inherits="System.Web.Mvc.ViewPage<MvcApplication1.Models.WeeklySchedule>" %>

<!DOCTYPE html>

<html>
<head runat="server">
    <meta name="viewport" content="width=device-width" />
    <title>Index</title>
    <script src="../../Scripts/jquery-2.2.3.js"></script>
    <script src="../../Content/dist/js/bootstrap.js"></script>
    <link href="../../Content/dist/css/bootstrap.css" rel="stylesheet" />

    <script>

        $(document).ready(function () {


            $.get("/Home/GetEmployees", null, function (data) {
                $.each(data, function (i, item) {

                    $('#cmbEmployees').append("<option id='emp" + item.EmployeeID + "' value='" + item.EmployeeID + "'>" + item.Name + "</option>");
                    $('#cmbEmployeesByName').append("<option id='emp" + item.Name + "' value='" + item.Name + "'>" + item.Name + "</option>");
                });
            });
            $("#EmployeeID").focusout(function () {

                var id = $(this).val();
                var name = $("#emp" + id).text();
                $("#employeeName").val(name);
            });

            $("#employeeName").focusout(function () {

            });

            $("#switchSearch").click(function () {


                if ($("#employeeName").is(':disabled')) {
                    $("#employeeName").prop("disabled", false);
                    $("#EmployeeID").prop("disabled", true);
                }
                else {
                    $("#employeeName").prop("disabled", true);
                    $("#EmployeeID").prop("disabled", false);
                }

            });
        });

    </script>
</head>
<body>
    <div>


        <%= Html.ValidationSummary() %>
        <form id="frm" name="frm" method="post" action="/Home/Index">
            <br />

            <div class="col-xs-1">
                <input id="EmployeeID" name="EmployeeID" list="cmbEmployees" class="form-control" />

                <datalist id="cmbEmployees">
                </datalist>
            </div>
            <div class="col-xs-4">
                <input id="employeeName" class="form-control" list="cmbEmployeesByName" disabled />
                <datalist id="cmbEmployeesByName">
                </datalist>
                <input id="switchSearch" type="button" class="btn btn-success" value="Switch Serach" />

            </div>
            <br />
            <br />
            <br />
            <br />


            <div class="container">
                <div class="table-responsive">

                    <table class="table table-striped">
                        <thead class="text-center">
                            <tr>
                                <td>Sunday</td>
                                <td>Monday</td>
                                <td>Tuesday</td>
                                <td>Wednesday</td>
                                <td>Thursday</td>
                                <td>Friday</td>
                                <td>Saturday</td>
                            </tr>
                        </thead>
                        <tbody>
                            <tr>

                                <td><%=Html.TextAreaFor(model => model.Sunday.Customer.CustomerID, new { @class = "form-control text-center" ,@rows = "4" ,@placeholder = "ΠΕΛΑΤΗΣ", @tabindex= "1" })%></td>
                                <td><%=Html.TextAreaFor(model => model.Monday.Customer.CustomerID, new { @class = "form-control text-center" , @rows = "4"  ,@placeholder = "ΠΕΛΑΤΗΣ" , @tabindex= "4"}) %></td>
                                <td><%=Html.TextAreaFor(model => model.Tuesday.Customer.CustomerID, new { @class = "form-control text-center" , @rows = "4" ,@placeholder = "ΠΕΛΑΤΗΣ", @tabindex= "7" }) %></td>
                                <td><%=Html.TextAreaFor(model => model.Wednesday.Customer.CustomerID, new { @class = "form-control text-center" , @rows = "4" , @placeholder = "ΠΕΛΑΤΗΣ" , @tabindex= "10"}) %></td>
                                <td><%=Html.TextAreaFor(model => model.Thursday.Customer.CustomerID, new { @class = "form-control text-center" ,@rows = "4" ,@placeholder = "ΠΕΛΑΤΗΣ", @tabindex= "13" }) %></td>
                                <td><%=Html.TextAreaFor(model => model.Friday.Customer.CustomerID, new { @class = "form-control text-center" ,@rows = "4" , @placeholder = "ΠΕΛΑΤΗΣ", @tabindex= "16" }) %></td>
                                <td><%=Html.TextAreaFor(model => model.Saturday.Customer.CustomerID, new { @class = "form-control text-center" ,@rows = "4" ,@placeholder = "ΠΕΛΑΤΗΣ" , @tabindex= "19"}) %></td>
                            </tr>
                            <tr>
                                <td><%=Html.TextBoxFor(model => model.Sunday.From, new { @class = "form-control" , @tabindex= "2" }) %></td>
                                <td><%=Html.TextBoxFor(model => model.Monday.From, new { @class = "form-control", @tabindex= "5" }) %></td>
                                <td><%=Html.TextBoxFor(model => model.Tuesday.From, new { @class = "form-control" , @tabindex= "8"}) %></td>
                                <td><%=Html.TextBoxFor(model => model.Wednesday.From, new { @class = "form-control", @tabindex= "11" }) %></td>
                                <td><%=Html.TextBoxFor(model => model.Thursday.From, new { @class = "form-control", @tabindex= "14" }) %></td>
                                <td><%=Html.TextBoxFor(model => model.Friday.From, new { @class = "form-control", @tabindex= "17" }) %></td>
                                <td><%=Html.TextBoxFor(model => model.Saturday.From, new { @class = "form-control" , @tabindex= "20"}) %></td>
                            </tr>
                            <tr>
                                <td><%=Html.TextBoxFor(model => model.Sunday.To, new { @class = "form-control" , @tabindex= "3"  }) %></td>
                                <td><%=Html.TextBoxFor(model => model.Monday.To, new { @class = "form-control", @tabindex= "6" }) %></td>
                                <td><%=Html.TextBoxFor(model => model.Tuesday.To, new { @class = "form-control", @tabindex= "9" }) %></td>
                                <td><%=Html.TextBoxFor(model => model.Wednesday.To, new { @class = "form-control", @tabindex= "12" }) %></td>
                                <td><%=Html.TextBoxFor(model => model.Thursday.To, new { @class = "form-control" , @tabindex= "15"}) %></td>
                                <td><%=Html.TextBoxFor(model => model.Friday.To, new { @class = "form-control", @tabindex= "18" }) %></td>
                                <td><%=Html.TextBoxFor(model => model.Saturday.To, new { @class = "form-control", @tabindex= "21" }) %></td>
                            </tr>
                        </tbody>
                    </table>
                </div>
            </div>

            <input type="submit" name="btnSave" value="save" />
        </form>

    </div>
</body>
</html>
