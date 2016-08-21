Very simple Windows Service that will request a web page after a specified interal. Used to keep an ASP.Net web application active when hosted by a company that doesn't allow the IIS Timeout interval to be changed (ie. GoDaddy).
By requesting the website every so often the IIS server will not timeout and shutdown, which prevents significant load times upon the next http request for the website.
