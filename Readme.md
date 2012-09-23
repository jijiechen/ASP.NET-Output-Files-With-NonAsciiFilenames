# Output Files With NonAsciiFilenames in ASP.NET #


Two problems occur when we are attempting to output a file via stream using asp.net: filenames with special symbols(e.g: space; # @ ! $ ) or Non-US-ASCII characters either cannot be supported by some browsers or cause incorrect filename in client machine. 

This project shows how to solve the encode problem when outputing files using asp.net. You can clone it to your local disk and take a test by yourself.

I will write another article on this topic and publish it on [my blog](http://blog.ciznx.com/ "ciznx's blog") shortly. (So you will see the link then)

I had writen [an article around this issue ](http://blog.ciznx.com/post/aspnetstreamdownloaddisplaynonunicodespacechar.aspx "解决Asp.net 文件下载时文件名的中文乱码和空格异常")two years before. When I joined my last company, this technology brought great improment for our several online projects.

Even these days, I can still see many people get to my blog to read that article, they search from Google or even translate my article to many other languages.
So, I am deciding to rebuild this project to provide a laboratory for showing how to solve the problem entirely.

I HAVE NOT tested for all platforms and browsers (Sorry for this), because I donot have these devices or browsers. So if you have more platforms and are glad to provide any test result data for this project, it will be warmly welcome. Just fork this project and send me a pull request.

You can use the source code freely.

From the Author: ciznx chan




----------



#在ASP.NET中输出非ASCII字符或特殊符号文件名的文件#

当我们使用 ASP.NET 输出文件名中含有特殊符号或其他非 ASCII 字符的文件时，会发生两个问题：那些特殊符号或非 ASCII 字符经常会导致在客户端浏览器中产生乱码或者其他不正确的输出。

这个项目向您展示了如何更好地解决使用 ASP.NET 输出文件时的文件名编码的问题。您可以自行克隆到本地，并自己用它完成测试。

我计划过一阵再写一篇有关这个话题的文章发表在[我的博客](http://blog.ciznx.com/ "ciznx's blog")上，届时您将可以看到测试结果。

两年之前我曾经写过 [一篇关于这个问题的文章](http://blog.ciznx.com/post/aspnetstreamdownloaddisplaynonunicodespacechar.aspx "解决Asp.net 文件下载时文件名的中文乱码和空格异常")。后来当我加入我的上一家公司时，使用本项目中的技术对当时在线的几个项目作了极大的改善。

即使到现在，还有很多人来到我的博客上阅读这篇文章，甚至还有人使用 Google 翻译将文章翻译成很多其他的文字。因此，我决定重新整理这个项目，并提供一个供测试如何完善地解决这个问题的实验项目。

我并未在所有平台和浏览器中做测试（同时为此感到抱歉），也正因为我并没有这么多种类的设备和浏览器。因此，如果您手头上刚好有这些设备或浏览器，欢迎您 fork 这个项目，并向我推送您的测试结果。

您可以自由地使用这份源代码。

来自作者：陈计节