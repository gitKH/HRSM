<%@ Page Language="C#" Inherits="System.Web.Mvc.ViewPage<IEnumerable<MvcApplication1.Models.DailySchedule>>" %>

<!DOCTYPE html>

<html>
<head runat="server">
    <meta name="viewport" content="width=device-width" />
    <title>Daily</title>
</head>
<body>

    <table>
        <thead>
            <tr>
                <td>Employee ID</td>
                <td>Name</td>
                <td>Company ID</td>
                <td>Company Name</td>
                <td>From</td>
                <td>To</td>
            </tr>
        </thead>
        <tbody>
            <% foreach (var item in Model)
               { %>
                <tr>
                    <td> <%= item.Employee.EmployeeID %></td>
                    <td> <%= item.Employee.Name %></td>
                    <td> <%= item.Customer.CustomerID %></td>
                    <td> <%= item.Customer.CompanyName %></td>
                    <td> <%= item.From %></td>
                    <td> <%= item.To %></td>
                </tr>
            <%} %>
        </tbody>
    </table>
</body>
</html>
