<%@ Page Language="C#" Inherits="System.Web.Mvc.ViewPage<dynamic>" %>

<!DOCTYPE html>

<html>
<head runat="server">
    <%--    jQuery--%>
    <script src="../../Scripts/jquery-2.2.3.js"></script>

    <%--    jQuery unobtrusive required for Ajax.BeginFrom and for Asynchronous operations--%>
    <script src="../../Scripts/jquery.unobtrusive-ajax.js"></script>

    <%--    BootStrap also has depedency to jQuery--%>
    <link href="../../Contents/dist/css/bootstrap.css" rel="stylesheet" />
    <script src="../../Contents/dist/js/bootstrap.js"></script>

    <%--    JQuery Mask Framework--%>
    <script src="../../Scripts/jquery.mask.js"></script>


    <meta name="viewport" content="width=device-width" />
    <title>Create</title>
    <script>
        //jQuery Mask Plugin
        //https://github.com/igorescobar/jQuery-Mask-Plugin
        //http://igorescobar.github.io/jQuery-Mask-Plugin/
        $(document).ready(function () {
            $("#datetime").mask('00/00/0000 00:00');
            $("#hour").mask("00:00");
        });
    </script>
    <script type="text/javascript">
        //This Function Called after success form POST
        function finished(data) {
            $("#tbl").append("<tr><td>" + data.Title + "</td><td>" + data.Director + "</td><td>" + data.Released + "</td></tr>");
        }

        //Client Side Convert DateTime Format
        function ToJavaScriptDate(value) {
            var pattern = /Date\(([^)]+)\)/;
            var results = pattern.exec(value);
            var dt = new Date(parseFloat(results[1]));
            return dt.getDate() + "/" + (dt.getMonth() + 1) + "/" + dt.getFullYear() + " " + dt.getHours() + "-" + dt.getMinutes();
        }
    </script>
</head>
<body>
    <div class="container">


        <div class="jumbotron">
            <h1>Hello To my Movies</h1>
            <p>KEIMENO KEIMENO KEIMENO KEIMENO KEIMENO KEIMENO KEIMENO KEIMENO KEIMENO KEIMENO KEIMENO KEIMENO KEIMENO KEIMENO KEIMENO KEIMENO KEIMENO KEIMENO </p>
        </div>

        <%-- BootStrap Model--%>
        <button type="button" class="btn btn-info btn-lg" data-toggle="modal" data-target="#myModal">Create New</button>

        <div class="table-responsive">
            <table class="table table-striped">
                <thead>
                    <tr>
                        <td>Title</td>
                        <td>Director</td>
                        <td>Released</td>
                    </tr>
                </thead>
                <tbody id="tbl">
                    <% var mdl = (IEnumerable<MvcApplication2.Models.Movie>)Model;
                       if (mdl == null)
                           return;

                       foreach (var item in mdl)
                       { 
                    %>
                    <tr>
                        <td><%= item.Title %></td>
                        <td><%= item.Director %></td>
                        <td><%= item.Released.ToString("dd/MM/yyyy HH:mm") %></td>
                    </tr>


                    <% } %>
                </tbody>
            </table>
        </div>

        <!-- Modal -->
        <div id="myModal" class="modal fade" role="dialog">
            <div class="modal-dialog">

                <!-- Modal content-->
                <div class="modal-content">
                    <div class="modal-header">
                        <button type="button" class="close" data-dismiss="modal">&times;</button>
                        <h4 class="modal-title">Add your movies</h4>
                    </div>
                    <div class="modal-body">
                        <% using (Ajax.BeginForm("Create", "Home", new AjaxOptions() { HttpMethod = "POST", OnSuccess = "finished" }))
                           { %>
                        <input type="text" name="Title" placeholder="Title" class="form-control" /><br />
                        <input type="text" name="Director" placeholder="Director" class="form-control" /><br />
                        <input id="datetime" type="text" name="Released" placeholder="Released" class="form-control" /><br />
                        <input id="hour" type="text" name="hour" placeholder="Hour" class="form-control" /><br />
                        <input type="submit" class="btn btn-success" value="Submit" />
                        <%}%>
                    </div>
                    <div class="modal-footer">
                        <button type="button" class="btn btn-default" data-dismiss="modal">Close</button>
                    </div>
                </div>

            </div>
        </div>
    </div>
</body>
</html>
