<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="NonAsciiFilenames.Default" %>
<%@ Import Namespace="NonAsciiFilenames.Classes" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>File List</title>
    <style type="text/css">
        table{border-collapse:collapse}
        table th, table td {
             border: 1px solid black;
            text-align: left;
            min-width: 80px;
        }
        table th.focus, table td.focus {
            background: #9fd8f7;
        }
        table th:first-child, table td:first-child {
            width: 320px;
        }
        #result{margin-bottom:100px;}
		#result td{ text-align: center;}
        #result td:first-child{ text-align: left;}
        table td.wrong {
            background: #F81414;
        }
        table td.right {
            background: #119239;
        }
    </style>
</head>
<body>
    <fieldset>
        <legend>
            Introduction
        </legend>
        <p>
            Hi there, this is an example application showing several ways to output filenames properly when serving files from an ASP.NET application.<br />
            You can upload a file at this page and then you can see 7 links for your file, each of them refers to one way for outputing the filename. You may take the contrast by clicking these links in different browsers to see different effects.<br />
        </p>
    </fieldset>
    <form id="form1" action="Upload.ashx" method="POST" enctype="multipart/form-data">
        <h2>Upload a file</h2>
        <input type="file" name="uploaded-file" accept="*"/>
        <input type="submit" value="Start Upload"/>
    </form>
    <br />
    <h2>Files for testing</h2>
    <table>
        <thead>
            <tr>
                <th>Filename</th>
                <th>Size</th>
                <th>Last Modified</th>
                <th>Normal</th>
                <th>Server.UrlEncode</th>
                <th>Server.UrlPathEncode</th>
                <th>Uri.EscapeDataString</th>
                <th>Uri.UriEscapeUriString</th>
				<th class="focus">Quotes</th>
                <th class="focus">FixedCode</th>
            </tr>
        </thead>
        <tbody>
            <%foreach (UploadedFile file in FileStorage.LoadFilesForTesting()){%>
                <tr>
                    <td><%=file.Filename %></td>
                    <td><%=file.Size %> bytes</td>
                    <td><%=file.LastModified %></td>
                    <td><a target="_blank" href="<%=file.GenerateDownloadLink(DownloadLinkType.Normal) %>">Download</a></td>
                    <td><a target="_blank" href="<%=file.GenerateDownloadLink(DownloadLinkType.ServerUrlEncode) %>">Download</a></td>
                    <td><a target="_blank" href="<%=file.GenerateDownloadLink(DownloadLinkType.ServerUrlPathEncode) %>">Download</a></td>
                    <td><a target="_blank" href="<%=file.GenerateDownloadLink(DownloadLinkType.UriEscapeDataString) %>">Download</a></td>
                    <td><a target="_blank" href="<%=file.GenerateDownloadLink(DownloadLinkType.UriEscapeUriString) %>">Download</a></td>
					<td class="focus"><a target="_blank" href="<%=file.GenerateDownloadLink(DownloadLinkType.Quotes) %>">Download</a></td>
                    <td class="focus"><a target="_blank" href="<%=file.GenerateDownloadLink(DownloadLinkType.FixedCodes) %>">Download</a></td>
                </tr>
            <% } %>
        </tbody>
    </table>
    <br /><br />
    <h2>Result</h2>
    <table id="result">
        <thead>
            <tr>
                <th>Browser</th>
                <th>Version</th>
                <th>OS</th>
                <th>Normal</th>
                <th>Server.UrlEncode</th>
                <th>Server.UrlPathEncode</th>
                <th>Uri.EscapeDataString</th>
                <th>Uri.UriEscapeUriString</th>
				<th class="focus">Quotes</th>
                <th class="focus">FixedCode</th>
            </tr>
        </thead>
        <tbody>
                <tr><td>Internet Explor</td><td>10</td><td>Windows 8</td><td>&nbsp;</td><td>&nbsp;</td><td></td><td></td><td></td><td></td><td></td>                </tr>
                <tr><td>Internet Explor</td><td>9</td><td>Windows 7</td><td>&nbsp;</td><td>&nbsp;</td><td></td><td></td><td></td><td></td><td></td></tr>
                <tr><td>Internet Explor</td><td>8</td><td>Windows 7</td><td>X</td><td>√</td><td>√</td><td>√</td><td>√</td><td>X</td><td>√</td></tr>
                <tr><td>Internet Explor</td><td>6</td><td>Windows XP</td><td>&nbsp;</td><td>&nbsp;</td><td></td><td></td><td></td><td></td><td></td></tr>
                <tr><td>Chrome</td><td>21</td><td>Windows 7</td><td>√</td><td>X</td><td>√</td><td>X</td><td>X</td><td>√</td><td>√</td></tr>
				<tr><td>Chrome</td><td>8</td><td>Windows 7</td><td></td><td></td><td></td><td></td><td></td><td></td><td></td></tr>
                <tr><td>Firefox</td><td>12</td><td>Windows 7</td><td></td><td></td><td></td><td></td><td></td><td></td><td></td></tr>
                <tr><td>Firefox</td><td>6</td><td>Windows 7</td><td>X</td><td>X</td><td>X</td><td>X</td><td>X</td><td>√</td><td>√</td></tr>
                <tr><td>Opera</td><td>12</td><td>Windows 7</td><td>√</td><td>X</td><td>X</td><td>X</td><td>X</td><td>√</td><td>√</td></tr>
                <tr><td>Safari</td><td>2</td><td>Mac OSX</td><td>&nbsp;</td><td>&nbsp;</td><td></td><td></td><td></td><td></td><td></td></tr>
                <tr><td>Chrome</td><td>4</td><td>Linux(Debian)</td><td>&nbsp;</td><td>&nbsp;</td><td></td><td></td><td></td><td></td><td></td></tr>
                <tr><td>Firefox</td><td>4</td><td>Linux(Debian)</td><td>&nbsp;</td><td>&nbsp;</td><td></td><td></td><td></td><td></td><td></td></tr>
                <tr><td>Safari</td><td>4</td><td>iPad</td><td>&nbsp;</td><td>&nbsp;</td><td></td><td></td><td></td><td></td><td></td></tr>
                <tr><td>Chrome</td><td>4</td><td>iPad</td><td>&nbsp;</td><td>&nbsp;</td><td></td><td></td><td></td><td></td><td></td></tr>
        </tbody>
    </table>

    <script type="text/javascript">
        var results = document.getElementById("result").getElementsByTagName('TD');
        for (var i = 0, l = results.length; i < l; i++) {
            if (results[i].innerHTML === "X") {
                results[i].className = "wrong";
            } else if (results[i].innerHTML === "√") {
                results[i].className = "right";
            }
        }
    </script>
</body>
</html>
