using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AwfulNET.Core.Rest
{
    public interface IMockHtmlGenerator
    {
        string GenerateMockNewThreadRequestHtml();
        string GenerateMockEditFolderHtml();
        string GenerateMockFolderListHtml();
        string GenerateMockUserSettingsHtml();
        string GenerateMockSmiliesHtml();
        string GenerateMockForumIndexHtml();
        string GenerateMockThreadReplyForm();
        string GenerateMockBookmarksHtml();
        string GenerateMockForumPageHtml();
        string GenerateMockThreadPageHtml();
        string GenerateMockPrivateMessageHtml();
        string GenerateMockPrivateMessageFolderHtml();
        string GenerateMockEditFormHtml();
    }

    /// <summary>
    /// A mock html source for unit testing. A single source will
    /// be used for all request types.
    /// </summary>
    public sealed class MockHtmlGenerator : DefaultMockHtmlGenerator
    {
        private readonly string source = string.Empty;
        public MockHtmlGenerator(string source) : base() { this.source = source; }

        #region Mock Html - Large!

        public override string GenerateMockEditFormHtml()
        {
            return source;
        }

        public override string GenerateMockNewThreadRequestHtml()
        {
            return source;
        }
        public override string GenerateMockEditFolderHtml()
        {
            return source;
        }
        public override string GenerateMockFolderListHtml()
        {
            return source;
        }
        public override string GenerateMockUserSettingsHtml()
        {
            return source;
        }
        public override string GenerateMockSmiliesHtml()
        {
            return source;
        }
        public override string GenerateMockForumIndexHtml()
        {
            return source;
        }
        public override string GenerateMockThreadReplyForm()
        {
            return source;
        }
        public override string GenerateMockBookmarksHtml()
        {
            return source;
        }
        public override string GenerateMockForumPageHtml()
        {
            return source;
        }
        public override string GenerateMockThreadPageHtml()
        {
            return source;
        }
        public override string GenerateMockPrivateMessageHtml()
        {
            return source;
        }
        public override string GenerateMockPrivateMessageFolderHtml()
        {
            return source;
        }

        #endregion
    }

    /// <summary>
    /// The default mock html source. Provides sample html for all user request scenarios.
    /// </summary>
    public class DefaultMockHtmlGenerator : IMockHtmlGenerator
    {
        #region Mock Html - Large!

        public virtual string GenerateMockEditFormHtml()
        {
            return @"<!DOCTYPE html><html><head><title>The Something Awful Forums - Edit this post</title>
	<meta name=""MSSmartTagsPreventParsing"" content=""TRUE"">
	<meta http-equiv=""X-UA-Compatible"" content=""chrome=1"">
	<!--[if lt IE 7]><link rel=""stylesheet"" type=""text/css"" href=""/css/ie.css?1348360344""><![endif]-->
	<!--[if lt IE 8]><link rel=""stylesheet"" type=""text/css"" href=""/css/ie7.css?1348360344""><![endif]-->
	<link rel=""apple-touch-icon"" href=""http://i.somethingawful.com/core/icon/iphone-touch/forums.png"">
	<link rel=""stylesheet"" type=""text/css"" href=""/css/main.css?1359594161"">
	<link rel=""stylesheet"" type=""text/css"" href=""/css/bbcode.css?1348360344"">
	<link rel=""stylesheet"" type=""text/css"" href=""http://www.somethingawful.com/globalcss/globalmenu.css"">
	<!-- <script src=""/__utm.js"" type=""text/javascript""></script> -->
	<!-- script src=""/js/dojo/dojo.js?1348360344"" type=""text/javascript""></script -->
	<script type=""text/javascript"" src=""//ajax.googleapis.com/ajax/libs/jquery/1.8.3/jquery.min.js""></script>
	<link rel=""stylesheet"" type=""text/css"" href=""//ajax.googleapis.com/ajax/libs/jqueryui/1.9.2/themes/redmond/jquery-ui.css"">
	<script type=""text/javascript"" src=""//ajax.googleapis.com/ajax/libs/jqueryui/1.9.2/jquery-ui.min.js""></script>

	<link rel=""stylesheet"" type=""text/css"" href=""http://www.somethingawful.com/css/forums.css?7"">
	<script type=""text/javascript"">
	</script>

	<script type=""text/javascript"" src=""/js/vb/forums.combined.js?1359653372""></script>
	<!-- ts-specific includes -->
</head>
<body id=""something_awful"" class=""editpost forum_192"">

<div id=""globalmenu"">
	<ul>
		<li class=""first""><a href=""https://secure.somethingawful.com/"">Buy Forum Stuff</a></li>
		<li><a href=""http://www.somethingawful.com/"">Something Awful</a></li>
	</ul>
</div>
<div id=""container"">
	<ul id=""nav_purchase"">
		<li><b>Purchase:</b></li>
		<li><a href=""https://secure.somethingawful.com/products/register.php"">Account</a></li>
		<li>- <a href=""https://secure.somethingawful.com/products/platinum.php"">Platinum Upgrade</a></li>
		<li>- <a href=""https://secure.somethingawful.com/products/titlechange.php"">New Avatar</a></li>
		<li>- <a href=""https://secure.somethingawful.com/products/titlechange.php"">Other's Avatar</a></li>
		<li>- <a href=""https://secure.somethingawful.com/products/archives.php"">Archives</a></li>
		<li>- <a href=""https://secure.somethingawful.com/products/noads.php"">No-Ads</a></li>
		<li>- <a href=""https://secure.somethingawful.com/products/namechange.php"">New Username</a></li>
		<li>- <a href=""https://secure.somethingawful.com/products/ad-banner.php"">Banner Advertisement</a></li>
		<li>- <a href=""https://secure.somethingawful.com/products/smilie.php"">Smilie</a></li>
		<li>- <a href=""https://secure.somethingawful.com/products/sticky-thread.php"">Stick Thread</a></li>
		<li>- <a href=""https://secure.somethingawful.com/products/gift-certificate.php"">Gift Cert.</a></li>
	</ul>
	<ul id=""navigation"" class=""navigation"">
<li class=""first""><a href=""/index.php"">SA Forums</a></li>
<li>- <a href=""http://www.somethingawful.com/"">Something Awful</a></li>
<li>- <a href=""/f/search"">Search the Forums</a></li>
<li>- <a href=""/usercp.php"">User Control Panel</a></li>
<li>- <a href=""/private.php"">Private Messages</a></li>
<li>- <a href=""http://www.somethingawful.com/d/forum-rules/forum-rules.php"">Forum Rules</a></li>
<li>- <a href=""/dictionary.php"">SAclopedia</a></li>
<li>- <a href=""/stats.php"">Posting Gloryhole</a></li>
<li>- <a href=""/banlist.php"">Leper's Colony</a></li>
<li>- <a href=""/supportmail.php"">Support</a></li>
<li>- <a href=""/account.php?action=logout&amp;ma=10293618"">Log Out</a></li>
</ul>
<div class=""oma_pal"">
	<!--  Begin Rubicon Project Tag -->
<!--  Site: Something Awful LLC   Zone: Forum ATF Top Quality - Mobile, Pop, Web   Size: Leaderboard  -->
<!--  PLACEMENT: Above the Fold  -->
<script language=""JavaScript"" type=""text/javascript"">
rp_account   = '8539';
rp_site      = '13831';
rp_zonesize  = '80354-2';
rp_adtype    = 'iframe';
rp_width     = '728';
rp_height    = '90';
rp_smartfile = 'http://www.somethingawful.com/revv_smart_file.html';
</script>
<script type=""text/javascript"" src=""https://ads.rubiconproject.com/ad/8539.js""></script>
<!--  End Rubicon Project Tag -->
</div>
	<div id=""content"">
<div class=""breadcrumbs""><span class=""mainbodytextlarge""><b><a href=""/"">The Something Awful Forums</a> &gt; <a href=""forumdisplay.php?forumid=51"">Discussion</a> &gt; <a href=""forumdisplay.php?forumid=192"">Inspect Your Gadgets</a> &gt; <a href=""showthread.php?threadid=3460814"">Awful Forum Reader for Windows Phone</a></b></span></div>
<form enctype=""multipart/form-data"" name=""vbform"" action=""editpost.php"" method=""post"" onSubmit=""return validate(this, 50000)"">
<input type=""hidden"" name=""action"" value=""updatepost"">
<input type=""hidden"" name=""postid"" value=""427267264"">

<table class=""standard"" id=""main_full"">
	<thead><tr><th colspan=""2"">Edit Post</th></tr></thead>
	
	<tr class=""altcolor2"">
		<td>
			<b>Message to edit:</b>
		</td>
		<td>
			<span class=""smalltext"">Originally posted by bootleg robot on Mar 21, 2014 15:11</span><br>
			<textarea name=""message"" rows=""20"" cols=""83"" tabindex=""2"">[quote=&quot;WattsvilleBlues&quot; post=&quot;427246172&quot;]
It allows me to log in on mobile, but it will only load front page, nothing else.
[/quote]

Are you getting blank pages, or any &quot;Oops!&quot; messages?</textarea><br>
			<a class=""check_msg_length"" href=""javascript:checklength(document.vbform, 50000);"">check message length</a>
			<a class=""show_smilies"" href=""/misc.php?action=showsmilies"" target=""_blank"">Smilies</a>
			<a class=""show_bbcode"" href=""/misc.php?action=bbcode"" target=""_blank"">BBcode</a>
		</td>
	</tr>
	<tr>
		<td><b>Options:</b></td>
		<td class=""smalltext"">
			<input type=""checkbox"" name=""parseurl"" value=""yes"" checked> <b>Automatically parse URLs:</b> automatically adds [url] and [/url] around internet addresses.<br>
			<input type=""checkbox"" name=""bookmark"" checked value=""yes""> <b>Bookmark Thread:</b> adds the thread to your bookmarked threads list if checked.<br>
			<input type=""checkbox"" name=""disablesmilies"" value=""yes"" > <b>Disable Smilies in This Post</b><br>
			<input type=""checkbox"" name=""signature""  value=""yes""> <b>Show Signature:</b> include your profile signature.  Only registered users may have signatures.<br>
		</td>
	</tr>
	
</table>

<br>

<div class=""postbuttons"">
	<input type=""submit"" class=""bginput"" name=""submit"" value=""Save Changes"" tabindex=""3"" accesskey=""s"">
	<input type=""submit"" class=""bginput"" name=""preview"" value=""Preview Post"" tabindex=""4"" accesskey=""p"">
</div>

</form>
</div><!-- #content -->
	<ul class=""navigation"">
<li class=""first""><a href=""/index.php"">SA Forums</a></li>
<li>- <a href=""http://www.somethingawful.com/"">Something Awful</a></li>
<li>- <a href=""/f/search"">Search the Forums</a></li>
<li>- <a href=""/usercp.php"">User Control Panel</a></li>
<li>- <a href=""/private.php"">Private Messages</a></li>
<li>- <a href=""http://www.somethingawful.com/d/forum-rules/forum-rules.php"">Forum Rules</a></li>
<li>- <a href=""/dictionary.php"">SAclopedia</a></li>
<li>- <a href=""/stats.php"">Posting Gloryhole</a></li>
<li>- <a href=""/banlist.php"">Leper's Colony</a></li>
<li>- <a href=""/supportmail.php"">Support</a></li>
<li>- <a href=""/account.php?action=logout&amp;ma=10293618"">Log Out</a></li>

</ul>
	<div id=""copyright"">
		Powered by: vBulletin Version 2.2.9 (<a href=""/CHANGES"">SAVB-v2.1.17</a>)<br>
		Copyright &copy;2000, 2001, Jelsoft Enterprises Limited.<br>
		Copyright &copy;2012, Something Awful LLC<br>
	</div>

</div><!-- #container -->

<script type=""text/javascript"">
	// quantcast
	_qoptions = { qacct:""p-82vTvmw-enlng"" };

	try {
		if(document.location.hostname != 'forums.somethingawful.com')
			throw undefined;

		$(document).ready(function() {
			var qcUrl = 'http://edge.quantserve.com/quant.js';
			jQuery.getScript(qcUrl);

			var gaJsHost = ((""https:"" == document.location.protocol) ? ""https://ssl."" : ""http://www."");
			var gaUrl = gaJsHost + 'google-analytics.com/ga.js';
			jQuery.getScript(gaUrl, function() {
				var pageTracker = _gat._getTracker(""UA-3064978-2"");
				pageTracker._initData();
				pageTracker._trackPageview();
			});
		});
	} catch(e) {};

	// indie
	// try {
	// 	if(document.location.hostname != 'forums.somethingawful.com')
	// 		throw undefined;

	// 	$(document).ready(function() {
	// 		var ic_element = document.createElement('script');
	// 		ic_element.type = 'text/javascript';
	// 		ic_element.async = true;
	// 		ic_element.id = 'ic_annonymous_pixel';
	// 		ic_element.src = 'http://pixel.indieclick.com/annonymous/domain/somethingawful.com/reach/script_ic.js';
	// 		var ic_script = document.getElementsByTagName('script')[0];
	// 		ic_script.parentNode.insertBefore(ic_element, ic_script);
	// 	});
	// } catch(e) {};
</script>
<noscript><img src=""http://pixel.quantserve.com/pixel/p-82vTvmw-enlng.gif"" style=""display:none;"" border=""0"" height=""1"" width=""1"" alt=""Quantcast""></noscript>

<!-- PLEASE DO NOT REMOVE -->
<ol id=""debug"" style=""display:none""><li>&nbsp;</ol>

</body>
</html>";
        }
        public virtual string GenerateMockNewThreadRequestHtml()
        {
            return @"<!DOCTYPE html>
<html>
<head>
	<title>The Something Awful Forums - Post New Thread</title>
	
	<meta name=""MSSmartTagsPreventParsing"" content=""TRUE"">
	<meta http-equiv=""X-UA-Compatible"" content=""chrome=1"">
	<!--[if lt IE 7]><link rel=""stylesheet"" type=""text/css"" href=""/css/ie.css?1348360344""><![endif]-->
	<!--[if lt IE 8]><link rel=""stylesheet"" type=""text/css"" href=""/css/ie7.css?1348360344""><![endif]-->
	<link rel=""apple-touch-icon"" href=""http://i.somethingawful.com/core/icon/iphone-touch/forums.png"">
	<link rel=""stylesheet"" type=""text/css"" href=""/css/main.css?1359594161"">
	<link rel=""stylesheet"" type=""text/css"" href=""/css/bbcode.css?1348360344"">
	<link rel=""stylesheet"" type=""text/css"" href=""http://www.somethingawful.com/globalcss/globalmenu.css"">

	

	<!-- <script src=""/__utm.js"" type=""text/javascript""></script> -->
	<!-- script src=""/js/dojo/dojo.js?1348360344"" type=""text/javascript""></script -->
	<script type=""text/javascript"" src=""//ajax.googleapis.com/ajax/libs/jquery/1.8.3/jquery.min.js""></script>
	<link rel=""stylesheet"" type=""text/css"" href=""//ajax.googleapis.com/ajax/libs/jqueryui/1.9.2/themes/redmond/jquery-ui.css"">
	<script type=""text/javascript"" src=""//ajax.googleapis.com/ajax/libs/jqueryui/1.9.2/jquery-ui.min.js""></script>

	<link rel=""stylesheet"" type=""text/css"" href=""http://www.somethingawful.com/css/forums.css?7"">

	

	<script type=""text/javascript"">
		
		
		
		
	</script>

	<script type=""text/javascript"" src=""/js/vb/forums.combined.js?1359653372""></script>

	

	<!-- ts-specific includes -->
	
	
	

	

	

	
</head>
<body id=""something_awful"" class=""newthread forum_192"">

<div id=""globalmenu"">
	<ul>
		<li class=""first""><a href=""https://secure.somethingawful.com/"">Buy Forum Stuff</a></li>
		<li><a href=""http://www.somethingawful.com/"">Something Awful</a></li>
	</ul>
</div>



<div id=""container"">



	

	<ul id=""nav_purchase"">
		<li><b>Purchase:</b></li>
		<li><a href=""https://secure.somethingawful.com/products/register.php"">Account</a></li>
		<li>- <a href=""https://secure.somethingawful.com/products/platinum.php"">Platinum Upgrade</a></li>
		<li>- <a href=""https://secure.somethingawful.com/products/titlechange.php"">New Avatar</a></li>
		<li>- <a href=""https://secure.somethingawful.com/products/titlechange.php"">Other's Avatar</a></li>
		<li>- <a href=""https://secure.somethingawful.com/products/archives.php"">Archives</a></li>
		<li>- <a href=""https://secure.somethingawful.com/products/noads.php"">No-Ads</a></li>
		<li>- <a href=""https://secure.somethingawful.com/products/namechange.php"">New Username</a></li>
		<li>- <a href=""https://secure.somethingawful.com/products/ad-banner.php"">Banner Advertisement</a></li>
		<li>- <a href=""https://secure.somethingawful.com/products/smilie.php"">Smilie</a></li>
		<li>- <a href=""https://secure.somethingawful.com/products/sticky-thread.php"">Stick Thread</a></li>
		<li>- <a href=""https://secure.somethingawful.com/products/gift-certificate.php"">Gift Cert.</a></li>
	</ul>

	<ul id=""navigation"" class=""navigation"">
<li class=""first""><a href=""/index.php"">SA Forums</a></li>
<li>- <a href=""http://www.somethingawful.com/"">Something Awful</a></li>
<li>- <a href=""/f/search"">Search the Forums</a></li>
<li>- <a href=""/usercp.php"">User Control Panel</a></li>
<li>- <a href=""/private.php"">Private Messages</a></li>
<li>- <a href=""http://www.somethingawful.com/d/forum-rules/forum-rules.php"">Forum Rules</a></li>
<li>- <a href=""/dictionary.php"">SAclopedia</a></li>
<li>- <a href=""/stats.php"">Posting Gloryhole</a></li>
<li>- <a href=""/banlist.php"">Leper's Colony</a></li>
<li>- <a href=""/supportmail.php"">Support</a></li>
<li>- <a href=""/account.php?action=logout&amp;ma=10293618"">Log Out</a></li>

</ul>


<div class=""oma_pal"">
	<!--  Begin Rubicon Project Tag -->
<!--  Site: Something Awful LLC   Zone: Forum ATF Top Quality - Mobile, Pop, Web   Size: Leaderboard  -->
<!--  PLACEMENT: Above the Fold  -->
<script language=""JavaScript"" type=""text/javascript"">
rp_account   = '8539';
rp_site      = '13831';
rp_zonesize  = '80354-2';
rp_adtype    = 'iframe';
rp_width     = '728';
rp_height    = '90';
rp_smartfile = 'http://www.somethingawful.com/revv_smart_file.html';
</script>
<script type=""text/javascript"" src=""https://ads.rubiconproject.com/ad/8539.js""></script>
<!--  End Rubicon Project Tag -->
</div>





	<div id=""content"">

	

<div class=""breadcrumbs""><span class=""mainbodytextlarge""><b><a href=""/"">The Something Awful Forums</a> &gt; <a href=""forumdisplay.php?forumid=51"">Discussion</a> &gt; <a href=""forumdisplay.php?forumid=192"">Inspect Your Gadgets</a></b></span></div>



<form enctype=""multipart/form-data"" action=""newthread.php"" method=""POST"" name=""vbform"" onSubmit=""return validate(this)"">
<input type=""hidden"" name=""forumid"" value=""192"">
<input type=""hidden"" name=""action"" value=""postthread"">
<input type=""hidden"" name=""formkey"" value=""255fa601c8ac17b5f04959ca7626933f"">
<input type=""hidden"" name=""form_cookie"" value=""46f568c092c4"">

<table class=""standard"" id=""main_full"">

<thead><tr><th colspan=""2"">Post New Thread</th></tr></thead>



<tr>
	<td><b>Logged in user:</b></td>
	<td class=""user_loggedin"">bootleg robot <a href=""account.php?action=logout&amp;ma=10293618"">logout</a></td>
</tr>

<tr class=""altcolor2"">
	<td><b>Subject:</b></td>
	<td><input type=""text"" class=""bginput"" name=""subject"" value="""" size=""70"" maxlength=""75"" tabindex=""1""></td>
</tr>

<tr>
	<td valign=""top"">
		<div class=""mainbodytext""><b>Post Icons:</b></div>
		<div class=""mainbodytextsmall""><input type=""radio"" name=""iconid"" value=""0"" CHECKED>&nbsp;No icon</div>
	</td>
	<td>
		
		<div class=""posticon"">
			<input type=""radio"" name=""iconid"" value=""365"" >
			<img src=""http://fi.somethingawful.com/forums/posticons/tava-cables.gif"" align=""middle"" alt=""Cables & wires"" width=""60"" height=""15"" onclick=""javascript:posticon_sel(1);"">
		</div>
		<div class=""posticon"">
			<input type=""radio"" name=""iconid"" value=""366"" >
			<img src=""http://fi.somethingawful.com/forums/posticons/tava-gadget.gif"" align=""middle"" alt=""Gadgets"" width=""60"" height=""15"" onclick=""javascript:posticon_sel(2);"">
		</div>
		<div class=""posticon"">
			<input type=""radio"" name=""iconid"" value=""367"" >
			<img src=""http://fi.somethingawful.com/forums/posticons/tava-cellphone.gif"" align=""middle"" alt=""Cellphones"" width=""60"" height=""15"" onclick=""javascript:posticon_sel(3);"">
		</div>
		<div class=""posticon"">
			<input type=""radio"" name=""iconid"" value=""368"" >
			<img src=""http://fi.somethingawful.com/forums/posticons/tava-headphones.gif"" align=""middle"" alt=""Headphones"" width=""60"" height=""15"" onclick=""javascript:posticon_sel(4);"">
		</div>
		<div class=""posticon"">
			<input type=""radio"" name=""iconid"" value=""369"" >
			<img src=""http://fi.somethingawful.com/forums/posticons/tava-mp3.gif"" align=""middle"" alt=""Mp3 players, iPods, Zunes, etc."" width=""60"" height=""15"" onclick=""javascript:posticon_sel(5);"">
		</div>
		<div class=""posticon"">
			<input type=""radio"" name=""iconid"" value=""370"" >
			<img src=""http://fi.somethingawful.com/forums/posticons/tava-highdef.gif"" align=""middle"" alt=""High-defintion"" width=""60"" height=""15"" onclick=""javascript:posticon_sel(6);"">
		</div>
		<div class=""posticon"">
			<input type=""radio"" name=""iconid"" value=""371"" >
			<img src=""http://fi.somethingawful.com/forums/posticons/tava-speakers.gif"" align=""middle"" alt=""Speakers"" width=""60"" height=""15"" onclick=""javascript:posticon_sel(7);"">
		</div>
		<div class=""posticon"">
			<input type=""radio"" name=""iconid"" value=""372"" >
			<img src=""http://fi.somethingawful.com/forums/posticons/icons-08/video.png"" align=""middle"" alt=""Video"" width=""60"" height=""15"" onclick=""javascript:posticon_sel(8);"">
		</div>
		<div class=""posticon"">
			<input type=""radio"" name=""iconid"" value=""373"" >
			<img src=""http://fi.somethingawful.com/forums/posticons/tava-vintage.gif"" align=""middle"" alt=""Vintage"" width=""60"" height=""15"" onclick=""javascript:posticon_sel(9);"">
		</div>
		<div class=""posticon"">
			<input type=""radio"" name=""iconid"" value=""374"" >
			<img src=""http://fi.somethingawful.com/forums/posticons/tava-analog.gif"" align=""middle"" alt=""Analog"" width=""60"" height=""15"" onclick=""javascript:posticon_sel(10);"">
		</div>
		<div class=""posticon"">
			<input type=""radio"" name=""iconid"" value=""420"" >
			<img src=""http://fi.somethingawful.com/forums/posticons/byob-slayer.gif"" align=""middle"" alt=""Slayer"" width=""60"" height=""15"" onclick=""javascript:posticon_sel(11);"">
		</div>
		<div class=""posticon"">
			<input type=""radio"" name=""iconid"" value=""437"" >
			<img src=""http://fi.somethingawful.com/forums/posticons/cell-cdma.gif"" align=""middle"" alt=""CDMA"" width=""60"" height=""15"" onclick=""javascript:posticon_sel(12);"">
		</div>
		<div class=""posticon"">
			<input type=""radio"" name=""iconid"" value=""438"" >
			<img src=""http://fi.somethingawful.com/forums/posticons/cell-gsm.gif"" align=""middle"" alt=""GSM"" width=""60"" height=""15"" onclick=""javascript:posticon_sel(13);"">
		</div>
		<div class=""posticon"">
			<input type=""radio"" name=""iconid"" value=""624"" >
			<img src=""http://fi.somethingawful.com/forums/posticons/cps-android.gif"" align=""middle"" alt=""cps-android.gif"" width=""60"" height=""15"" onclick=""javascript:posticon_sel(14);"">
		</div>
		<div class=""posticon"">
			<input type=""radio"" name=""iconid"" value=""655"" >
			<img src=""http://fi.somethingawful.com/forums/posticons/LF-2wqxulw.gif"" align=""middle"" alt=""LF-2wqxulw.gif"" width=""60"" height=""15"" onclick=""javascript:posticon_sel(15);"">
		</div>
		<div class=""posticon"">
			<input type=""radio"" name=""iconid"" value=""692"" >
			<img src=""http://fi.somethingawful.com/forums/posticons/dd-9-11.gif"" align=""middle"" alt=""9/11"" width=""60"" height=""15"" onclick=""javascript:posticon_sel(16);"">
		</div>
		<div class=""posticon"">
			<input type=""radio"" name=""iconid"" value=""757"" >
			<img src=""http://fi.somethingawful.com/forums/posticons/ddrd-scsa.gif"" align=""middle"" alt=""Install the vent hood: because Stone Cold Said So"" width=""60"" height=""15"" onclick=""javascript:posticon_sel(17);"">
		</div>
		<div class=""posticon"">
			<input type=""radio"" name=""iconid"" value=""60"" >
			<img src=""http://fi.somethingawful.com/forums/posticons/icons-08/en.png"" align=""middle"" alt=""e/n bullshit"" width=""60"" height=""15"" onclick=""javascript:posticon_sel(18);"">
		</div>
		<div class=""posticon"">
			<input type=""radio"" name=""iconid"" value=""61"" >
			<img src=""http://fi.somethingawful.com/forums/posticons/icons-08/unfunny.png"" align=""middle"" alt=""NOT FUNNY AT ALL"" width=""60"" height=""15"" onclick=""javascript:posticon_sel(19);"">
		</div>
		<div class=""posticon"">
			<input type=""radio"" name=""iconid"" value=""66"" >
			<img src=""http://fi.somethingawful.com/forums/posticons/icons-08/rant.png"" align=""middle"" alt=""Rant"" width=""60"" height=""15"" onclick=""javascript:posticon_sel(20);"">
		</div>
		<div class=""posticon"">
			<input type=""radio"" name=""iconid"" value=""77"" >
			<img src=""http://fi.somethingawful.com/forums/posticons/icons-08/stupid.png"" align=""middle"" alt=""Something stupid"" width=""60"" height=""15"" onclick=""javascript:posticon_sel(21);"">
		</div>
		<div class=""posticon"">
			<input type=""radio"" name=""iconid"" value=""79"" >
			<img src=""http://fi.somethingawful.com/forums/posticons/icons-08/weird.png"" align=""middle"" alt=""Something weird"" width=""60"" height=""15"" onclick=""javascript:posticon_sel(22);"">
		</div>
		<div class=""posticon"">
			<input type=""radio"" name=""iconid"" value=""81"" >
			<img src=""http://fi.somethingawful.com/forums/posticons/icons-08/fruity.png"" align=""middle"" alt=""Fruity post"" width=""60"" height=""15"" onclick=""javascript:posticon_sel(23);"">
		</div>
		<div class=""posticon"">
			<input type=""radio"" name=""iconid"" value=""86"" >
			<img src=""http://fi.somethingawful.com/forums/posticons/icons-08/gross.png"" align=""middle"" alt=""Gross"" width=""60"" height=""15"" onclick=""javascript:posticon_sel(24);"">
		</div>
		<div class=""posticon"">
			<input type=""radio"" name=""iconid"" value=""89"" >
			<img src=""http://fi.somethingawful.com/forums/posticons/icons-08/humor.png"" align=""middle"" alt=""Humor"" width=""60"" height=""15"" onclick=""javascript:posticon_sel(25);"">
		</div>
		<div class=""posticon"">
			<input type=""radio"" name=""iconid"" value=""95"" >
			<img src=""http://fi.somethingawful.com/forums/posticons/icons-08/whine.png"" align=""middle"" alt=""Wahhhhhh whine whine whine"" width=""60"" height=""15"" onclick=""javascript:posticon_sel(26);"">
		</div>
		<div class=""posticon"">
			<input type=""radio"" name=""iconid"" value=""115"" >
			<img src=""http://fi.somethingawful.com/forums/posticons/icons-08/serious.png"" align=""middle"" alt=""This is a serious post"" width=""60"" height=""15"" onclick=""javascript:posticon_sel(27);"">
		</div>
		<div class=""posticon"">
			<input type=""radio"" name=""iconid"" value=""64"" >
			<img src=""http://fi.somethingawful.com/forums/posticons/icons-08/question.png"" align=""middle"" alt=""Question"" width=""60"" height=""15"" onclick=""javascript:posticon_sel(28);"">
		</div>
		<div class=""posticon"">
			<input type=""radio"" name=""iconid"" value=""65"" >
			<img src=""http://fi.somethingawful.com/forums/posticons/icons-08/attention.png"" align=""middle"" alt=""ATTENTION!"" width=""60"" height=""15"" onclick=""javascript:posticon_sel(29);"">
		</div>
		<div class=""posticon"">
			<input type=""radio"" name=""iconid"" value=""67"" >
			<img src=""http://fi.somethingawful.com/forums/posticons/icons-08/newbie.png"" align=""middle"" alt=""NEWBIE QUESTION"" width=""60"" height=""15"" onclick=""javascript:posticon_sel(30);"">
		</div>
		<div class=""posticon"">
			<input type=""radio"" name=""iconid"" value=""68"" >
			<img src=""http://fi.somethingawful.com/forums/posticons/icons-08/poll.png"" align=""middle"" alt=""Poll"" width=""60"" height=""15"" onclick=""javascript:posticon_sel(31);"">
		</div>
		<div class=""posticon"">
			<input type=""radio"" name=""iconid"" value=""69"" >
			<img src=""http://fi.somethingawful.com/forums/posticons/icons-08/link.png"" align=""middle"" alt=""URL Link"" width=""60"" height=""15"" onclick=""javascript:posticon_sel(32);"">
		</div>
		<div class=""posticon"">
			<input type=""radio"" name=""iconid"" value=""74"" >
			<img src=""http://fi.somethingawful.com/forums/posticons/icons-08/request.png"" align=""middle"" alt=""Request!"" width=""60"" height=""15"" onclick=""javascript:posticon_sel(33);"">
		</div>
		<div class=""posticon"">
			<input type=""radio"" name=""iconid"" value=""78"" >
			<img src=""http://fi.somethingawful.com/forums/posticons/icons-08/help.png"" align=""middle"" alt=""Help!"" width=""60"" height=""15"" onclick=""javascript:posticon_sel(34);"">
		</div>
		<div class=""posticon"">
			<input type=""radio"" name=""iconid"" value=""104"" >
			<img src=""http://fi.somethingawful.com/forums/posticons/icons-08/event.png"" align=""middle"" alt=""Event planned"" width=""60"" height=""15"" onclick=""javascript:posticon_sel(35);"">
		</div>
		<div class=""posticon"">
			<input type=""radio"" name=""iconid"" value=""113"" >
			<img src=""http://fi.somethingawful.com/forums/posticons/icons-08/goonmeet.png"" align=""middle"" alt=""Goon Meet"" width=""60"" height=""15"" onclick=""javascript:posticon_sel(36);"">
		</div>
		<div class=""posticon"">
			<input type=""radio"" name=""iconid"" value=""120"" >
			<img src=""http://fi.somethingawful.com/forums/posticons/icons-08/repeat.png"" align=""middle"" alt=""Repeated subject / link?"" width=""60"" height=""15"" onclick=""javascript:posticon_sel(37);"">
		</div>
		<div class=""posticon"">
			<input type=""radio"" name=""iconid"" value=""71"" >
			<img src=""http://fi.somethingawful.com/forums/posticons/icons-08/games.png"" align=""middle"" alt=""Games"" width=""60"" height=""15"" onclick=""javascript:posticon_sel(38);"">
		</div>
		<div class=""posticon"">
			<input type=""radio"" name=""iconid"" value=""75"" >
			<img src=""http://fi.somethingawful.com/forums/posticons/icons-08/news.png"" align=""middle"" alt=""News item"" width=""60"" height=""15"" onclick=""javascript:posticon_sel(39);"">
		</div>
		<div class=""posticon"">
			<input type=""radio"" name=""iconid"" value=""80"" >
			<img src=""http://fi.somethingawful.com/forums/posticons/icons-08/music.png"" align=""middle"" alt=""Music"" width=""60"" height=""15"" onclick=""javascript:posticon_sel(40);"">
		</div>
		<div class=""posticon"">
			<input type=""radio"" name=""iconid"" value=""83"" >
			<img src=""http://fi.somethingawful.com/forums/posticons/icons-08/computers.png"" align=""middle"" alt=""Computer issues"" width=""60"" height=""15"" onclick=""javascript:posticon_sel(41);"">
		</div>
		<div class=""posticon"">
			<input type=""radio"" name=""iconid"" value=""85"" >
			<img src=""http://fi.somethingawful.com/forums/posticons/icons-08/politics.png"" align=""middle"" alt=""Political debate"" width=""60"" height=""15"" onclick=""javascript:posticon_sel(42);"">
		</div>
		<div class=""posticon"">
			<input type=""radio"" name=""iconid"" value=""88"" >
			<img src=""http://fi.somethingawful.com/forums/posticons/icons-08/school.png"" align=""middle"" alt=""School"" width=""60"" height=""15"" onclick=""javascript:posticon_sel(43);"">
		</div>
		<div class=""posticon"">
			<input type=""radio"" name=""iconid"" value=""92"" >
			<img src=""http://fi.somethingawful.com/forums/posticons/icons-08/sex.png"" align=""middle"" alt=""Something about sex"" width=""60"" height=""15"" onclick=""javascript:posticon_sel(44);"">
		</div>
		<div class=""posticon"">
			<input type=""radio"" name=""iconid"" value=""93"" >
			<img src=""http://fi.somethingawful.com/forums/posticons/icons-08/cars.png"" align=""middle"" alt=""Cars"" width=""60"" height=""15"" onclick=""javascript:posticon_sel(45);"">
		</div>
		<div class=""posticon"">
			<input type=""radio"" name=""iconid"" value=""101"" >
			<img src=""http://fi.somethingawful.com/forums/posticons/icons-08/guns.png"" align=""middle"" alt=""Guns"" width=""60"" height=""15"" onclick=""javascript:posticon_sel(46);"">
		</div>
		<div class=""posticon"">
			<input type=""radio"" name=""iconid"" value=""105"" >
			<img src=""http://fi.somethingawful.com/forums/posticons/icons-08/tech.png"" align=""middle"" alt=""Technical question"" width=""60"" height=""15"" onclick=""javascript:posticon_sel(47);"">
		</div>
		<div class=""posticon"">
			<input type=""radio"" name=""iconid"" value=""121"" >
			<img src=""http://fi.somethingawful.com/forums/posticons/icons-08/sports.png"" align=""middle"" alt=""Sports"" width=""60"" height=""15"" onclick=""javascript:posticon_sel(48);"">
		</div>
		<div class=""posticon"">
			<input type=""radio"" name=""iconid"" value=""122"" >
			<img src=""http://fi.somethingawful.com/forums/posticons/icons-08/drugs.png"" align=""middle"" alt=""Drugs, maaaan"" width=""60"" height=""15"" onclick=""javascript:posticon_sel(49);"">
		</div>
		<div class=""posticon"">
			<input type=""radio"" name=""iconid"" value=""123"" >
			<img src=""http://fi.somethingawful.com/forums/posticons/icons-08/science.png"" align=""middle"" alt=""Science... and philosophy!"" width=""60"" height=""15"" onclick=""javascript:posticon_sel(50);"">
		</div>
		<div class=""posticon"">
			<input type=""radio"" name=""iconid"" value=""128"" >
			<img src=""http://fi.somethingawful.com/forums/posticons/icons-08/food.png"" align=""middle"" alt=""Food and Cooking"" width=""60"" height=""15"" onclick=""javascript:posticon_sel(51);"">
		</div>
		<div class=""posticon"">
			<input type=""radio"" name=""iconid"" value=""309"" >
			<img src=""http://fi.somethingawful.com/forums/posticons/icons-08/video.png"" align=""middle"" alt=""Another online video link thread"" width=""60"" height=""15"" onclick=""javascript:posticon_sel(52);"">
		</div>
		<div class=""posticon"">
			<input type=""radio"" name=""iconid"" value=""63"" >
			<img src=""http://fi.somethingawful.com/forums/posticons/icons-08/audio.png"" align=""middle"" alt=""Audio file"" width=""60"" height=""15"" onclick=""javascript:posticon_sel(53);"">
		</div>
		<div class=""posticon"">
			<input type=""radio"" name=""iconid"" value=""72"" >
			<img src=""http://fi.somethingawful.com/forums/posticons/icons-08/movies.png"" align=""middle"" alt=""Movie Discussion"" width=""60"" height=""15"" onclick=""javascript:posticon_sel(54);"">
		</div>
		<div class=""posticon"">
			<input type=""radio"" name=""iconid"" value=""73"" >
			<img src=""http://fi.somethingawful.com/forums/posticons/icons-08/books.png"" align=""middle"" alt=""Books and literature"" width=""60"" height=""15"" onclick=""javascript:posticon_sel(55);"">
		</div>
		<div class=""posticon"">
			<input type=""radio"" name=""iconid"" value=""76"" >
			<img src=""http://fi.somethingawful.com/forums/posticons/icons-08/photoshop.png"" align=""middle"" alt=""Photoshop entry"" width=""60"" height=""15"" onclick=""javascript:posticon_sel(56);"">
		</div>
		<div class=""posticon"">
			<input type=""radio"" name=""iconid"" value=""94"" >
			<img src=""http://fi.somethingawful.com/forums/posticons/icons-08/tv.png"" align=""middle"" alt=""Television"" width=""60"" height=""15"" onclick=""javascript:posticon_sel(57);"">
		</div>
		<div class=""posticon"">
			<input type=""radio"" name=""iconid"" value=""114"" >
			<img src=""http://forumimages.somethingawful.com/forums/posticons/icons-08/art.png"" align=""middle"" alt=""Art"" width=""60"" height=""15"" onclick=""javascript:posticon_sel(58);"">
		</div>
		<div class=""posticon"">
			<input type=""radio"" name=""iconid"" value=""116"" >
			<img src=""http://fi.somethingawful.com/forums/posticons/icons-08/photos.png"" align=""middle"" alt=""Photos / webcams / etc"" width=""60"" height=""15"" onclick=""javascript:posticon_sel(59);"">
		</div>
		<div class=""posticon"">
			<input type=""radio"" name=""iconid"" value=""82"" >
			<img src=""http://forumimages.somethingawful.com/forums/posticons/icon23-banme.gif"" align=""middle"" alt=""PLEASE BAN ME"" width=""60"" height=""15"" onclick=""javascript:posticon_sel(60);"">
		</div>
		<div class=""posticon"">
			<input type=""radio"" name=""iconid"" value=""90"" >
			<img src=""http://forumimages.somethingawful.com/forums/posticons/icon-30-attnmod.gif"" align=""middle"" alt=""MODS ONLY"" width=""60"" height=""15"" onclick=""javascript:posticon_sel(61);"">
		</div>
		<div class=""posticon"">
			<input type=""radio"" name=""iconid"" value=""91"" >
			<img src=""http://forumimages.somethingawful.com/forums/posticons/icon-31-hotthread.gif"" align=""middle"" alt=""MODS ONLY"" width=""60"" height=""15"" onclick=""javascript:posticon_sel(62);"">
		</div>
		<div class=""posticon"">
			<input type=""radio"" name=""iconid"" value=""256"" >
			<img src=""http://fi.somethingawful.com/forums/posticons/fyad-trout.gif"" align=""middle"" alt=""Trout Magick"" width=""60"" height=""15"" onclick=""javascript:posticon_sel(63);"">
		</div>
		<div class=""posticon"">
			<input type=""radio"" name=""iconid"" value=""322"" >
			<img src=""http://fi.somethingawful.com/forums/posticons/fyad-blogs.gif"" align=""middle"" alt=""BLOGS"" width=""60"" height=""15"" onclick=""javascript:posticon_sel(64);"">
		</div>
		<div class=""posticon"">
			<input type=""radio"" name=""iconid"" value=""142"" >
			<img src=""http://fi.somethingawful.com/forums/posticons/shsc-win.gif"" align=""middle"" alt=""Windows"" width=""60"" height=""15"" onclick=""javascript:posticon_sel(65);"">
		</div>
		<div class=""posticon"">
			<input type=""radio"" name=""iconid"" value=""139"" >
			<img src=""http://fi.somethingawful.com/forums/posticons/shsc-apple.gif"" align=""middle"" alt=""Mac"" width=""60"" height=""15"" onclick=""javascript:posticon_sel(66);"">
		</div>
		<div class=""posticon"">
			<input type=""radio"" name=""iconid"" value=""141"" >
			<img src=""http://fi.somethingawful.com/forums/posticons/shsc-linux.gif"" align=""middle"" alt=""Lunix"" width=""60"" height=""15"" onclick=""javascript:posticon_sel(67);"">
		</div>
		<div class=""posticon"">
			<input type=""radio"" name=""iconid"" value=""193"" >
			<img src=""http://fi.somethingawful.com/forums/posticons/coupon-nonus.gif"" align=""middle"" alt=""Non-US"" width=""60"" height=""15"" onclick=""javascript:posticon_sel(68);"">
		</div>
	</td>
</tr>

<tr class=""altcolor2"">
	<td>
		<b>Message:</b><br>
		<br>
		<span class=""smalltext"">
		<b>DON'T USE THESE TAGS:</b><br>
		<img src=""http://forumimages.somethingawful.com/forums/posticons/icon-30-attnmod.gif"" alt=""""><br>
		<img src=""http://forumimages.somethingawful.com/forums/posticons/icon-31-hotthread.gif"" alt=""""><br>
		<img src=""http://forumimages.somethingawful.com/forums/posticons/icon23-banme.gif"" alt=""""><br>
		<a href=""http://www.somethingawful.com/d/forum-rules/forum-rules.php"" target=""_blank"">Read the goddamn forum rules before posting!!!</a>  If you break a forum rule, you WILL be banned.  Ignorance is NO excuse.
		<br>
		<br>
		
		You <b>may </b> post new threads<br>
		You <b>may </b> post replies<br>
		You <b>may </b> post attachments<br>
		You <b>may </b> edit your posts<br>
		HTML code is <b>off</b><br>
		<a href=""misc.php?action=bbcode"" target=""_blank"">BBcode</a> is <b>on</b><br>
		<a href=""misc.php?action=showsmilies"" target=""_blank"">Smilies</a> are <b>on</b><br>
		<a href=""misc.php?action=bbcode#imgcode"" target=""_blank"">[IMG]</a> code is <b>on</b>
		</span>
	</td>
	<td>
		<textarea name=""message"" rows=""20"" cols=""83"" tabindex=""2""></textarea><br>
		<a class=""check_msg_length"" href=""javascript:checklength(document.vbform, 50000);"">check message length</a>
		<a class=""show_smilies"" href=""/misc.php?action=showsmilies"" target=""_blank"">Smilies</a>
		<a class=""show_bbcode"" href=""/misc.php?action=bbcode"" target=""_blank"">BBcode</a>
	</td>
</tr>

<tr>
	<td><b>Options:</b></td>
	<td class=""smalltext"">
		<input type=""checkbox"" name=""parseurl"" value=""yes"" checked> <b>Automatically parse URLs:</b> automatically adds [url] and [/url] around internet addresses.<br>
		<input type=""checkbox"" name=""bookmark"" value=""yes"" checked> <b>Bookmark thread:</b> adds thread to your <a href='/bookmarkthreads.php?action=view'>thread bookmarks</a>.<br>
		

		
</td>
</tr>




<tr>
	<td>Platinum Features:</td>
	<td class=""smalltext"">
		To attach a file or create a poll, you must preview this thread first.
	</td>
</tr>


</table>

<br>

<div class=""postbuttons"">

	<input type=""submit"" class=""bginput"" name=""preview"" value=""Preview Post"" tabindex=""4"" accesskey=""s"">
</div>

</form>

</div><!-- #content -->
	<ul class=""navigation"">
<li class=""first""><a href=""/index.php"">SA Forums</a></li>
<li>- <a href=""http://www.somethingawful.com/"">Something Awful</a></li>
<li>- <a href=""/f/search"">Search the Forums</a></li>
<li>- <a href=""/usercp.php"">User Control Panel</a></li>
<li>- <a href=""/private.php"">Private Messages</a></li>
<li>- <a href=""http://www.somethingawful.com/d/forum-rules/forum-rules.php"">Forum Rules</a></li>
<li>- <a href=""/dictionary.php"">SAclopedia</a></li>
<li>- <a href=""/stats.php"">Posting Gloryhole</a></li>
<li>- <a href=""/banlist.php"">Leper's Colony</a></li>
<li>- <a href=""/supportmail.php"">Support</a></li>
<li>- <a href=""/account.php?action=logout&amp;ma=10293618"">Log Out</a></li>

</ul>
	<div id=""copyright"">
		Powered by: vBulletin Version 2.2.9 (<a href=""/CHANGES"">SAVB-v2.1.17</a>)<br>
		Copyright &copy;2000, 2001, Jelsoft Enterprises Limited.<br>
		Copyright &copy;2012, Something Awful LLC<br>
	</div>

</div><!-- #container -->

<script type=""text/javascript"">
	// quantcast
	_qoptions = { qacct:""p-82vTvmw-enlng"" };

	try {
		if(document.location.hostname != 'forums.somethingawful.com')
			throw undefined;

		$(document).ready(function() {
			var qcUrl = 'http://edge.quantserve.com/quant.js';
			jQuery.getScript(qcUrl);

			var gaJsHost = ((""https:"" == document.location.protocol) ? ""https://ssl."" : ""http://www."");
			var gaUrl = gaJsHost + 'google-analytics.com/ga.js';
			jQuery.getScript(gaUrl, function() {
				var pageTracker = _gat._getTracker(""UA-3064978-2"");
				pageTracker._initData();
				pageTracker._trackPageview();
			});
		});
	} catch(e) {};

	// indie
	// try {
	// 	if(document.location.hostname != 'forums.somethingawful.com')
	// 		throw undefined;

	// 	$(document).ready(function() {
	// 		var ic_element = document.createElement('script');
	// 		ic_element.type = 'text/javascript';
	// 		ic_element.async = true;
	// 		ic_element.id = 'ic_annonymous_pixel';
	// 		ic_element.src = 'http://pixel.indieclick.com/annonymous/domain/somethingawful.com/reach/script_ic.js';
	// 		var ic_script = document.getElementsByTagName('script')[0];
	// 		ic_script.parentNode.insertBefore(ic_element, ic_script);
	// 	});
	// } catch(e) {};
</script>
<noscript><img src=""http://pixel.quantserve.com/pixel/p-82vTvmw-enlng.gif"" style=""display:none;"" border=""0"" height=""1"" width=""1"" alt=""Quantcast""></noscript>

<!-- PLEASE DO NOT REMOVE -->
<ol id=""debug"" style=""display:none""><li>&nbsp;</ol>

</body>
</html>";
        }
        public virtual string GenerateMockEditFolderHtml()
        {
            return @"<!DOCTYPE html>
<html>
<head>
	<title>The Something Awful Forums - Private Messaging: Edit Folders</title>
	
	<meta name=""MSSmartTagsPreventParsing"" content=""TRUE"">
	<meta http-equiv=""X-UA-Compatible"" content=""chrome=1"">
	<!--[if lt IE 7]><link rel=""stylesheet"" type=""text/css"" href=""/css/ie.css?1348360344""><![endif]-->
	<!--[if lt IE 8]><link rel=""stylesheet"" type=""text/css"" href=""/css/ie7.css?1348360344""><![endif]-->
	<link rel=""apple-touch-icon"" href=""http://i.somethingawful.com/core/icon/iphone-touch/forums.png"">
	<link rel=""stylesheet"" type=""text/css"" href=""/css/main.css?1359594161"">
	<link rel=""stylesheet"" type=""text/css"" href=""/css/bbcode.css?1348360344"">
	<link rel=""stylesheet"" type=""text/css"" href=""http://www.somethingawful.com/globalcss/globalmenu.css"">

	

	<!-- <script src=""/__utm.js"" type=""text/javascript""></script> -->
	<!-- script src=""/js/dojo/dojo.js?1348360344"" type=""text/javascript""></script -->
	<script type=""text/javascript"" src=""//ajax.googleapis.com/ajax/libs/jquery/1.8.3/jquery.min.js""></script>
	<link rel=""stylesheet"" type=""text/css"" href=""//ajax.googleapis.com/ajax/libs/jqueryui/1.9.2/themes/redmond/jquery-ui.css"">
	<script type=""text/javascript"" src=""//ajax.googleapis.com/ajax/libs/jqueryui/1.9.2/jquery-ui.min.js""></script>

	<link rel=""stylesheet"" type=""text/css"" href=""http://www.somethingawful.com/css/forums.css?7"">

	

	<script type=""text/javascript"">
		
		
		
		
	</script>

	<script type=""text/javascript"" src=""/js/vb/forums.combined.js?1359653372""></script>

	

	<!-- ts-specific includes -->
	
	
	

	

	

	
</head>
<body id=""something_awful"" class=""priv_showfolders"">

<div id=""globalmenu"">
	<ul>
		<li class=""first""><a href=""https://secure.somethingawful.com/"">Buy Forum Stuff</a></li>
		<li><a href=""http://www.somethingawful.com/"">Something Awful</a></li>
	</ul>
</div>



<div id=""container"">



	

	<ul id=""nav_purchase"">
		<li><b>Purchase:</b></li>
		<li><a href=""https://secure.somethingawful.com/products/register.php"">Account</a></li>
		<li>- <a href=""https://secure.somethingawful.com/products/platinum.php"">Platinum Upgrade</a></li>
		<li>- <a href=""https://secure.somethingawful.com/products/titlechange.php"">New Avatar</a></li>
		<li>- <a href=""https://secure.somethingawful.com/products/titlechange.php"">Other's Avatar</a></li>
		<li>- <a href=""https://secure.somethingawful.com/products/archives.php"">Archives</a></li>
		<li>- <a href=""https://secure.somethingawful.com/products/noads.php"">No-Ads</a></li>
		<li>- <a href=""https://secure.somethingawful.com/products/namechange.php"">New Username</a></li>
		<li>- <a href=""https://secure.somethingawful.com/products/ad-banner.php"">Banner Advertisement</a></li>
		<li>- <a href=""https://secure.somethingawful.com/products/smilie.php"">Smilie</a></li>
		<li>- <a href=""https://secure.somethingawful.com/products/sticky-thread.php"">Stick Thread</a></li>
		<li>- <a href=""https://secure.somethingawful.com/products/gift-certificate.php"">Gift Cert.</a></li>
	</ul>

	<ul id=""navigation"" class=""navigation"">
<li class=""first""><a href=""/index.php"">SA Forums</a></li>
<li>- <a href=""http://www.somethingawful.com/"">Something Awful</a></li>
<li>- <a href=""/f/search"">Search the Forums</a></li>
<li>- <a href=""/usercp.php"">User Control Panel</a></li>
<li>- <a href=""/private.php"">Private Messages</a></li>
<li>- <a href=""http://www.somethingawful.com/d/forum-rules/forum-rules.php"">Forum Rules</a></li>
<li>- <a href=""/dictionary.php"">SAclopedia</a></li>
<li>- <a href=""/stats.php"">Posting Gloryhole</a></li>
<li>- <a href=""/banlist.php"">Leper's Colony</a></li>
<li>- <a href=""/supportmail.php"">Support</a></li>
<li>- <a href=""/account.php?action=logout&amp;ma=10293618"">Log Out</a></li>

</ul>


<div class=""oma_pal"">
	<!--  Begin Rubicon Project Tag -->
<!--  Site: Something Awful LLC   Zone: Forum ATF Top Quality - Mobile, Pop, Web   Size: Leaderboard  -->
<!--  PLACEMENT: Above the Fold  -->
<script language=""JavaScript"" type=""text/javascript"">
rp_account   = '8539';
rp_site      = '13831';
rp_zonesize  = '80354-2';
rp_adtype    = 'iframe';
rp_width     = '728';
rp_height    = '90';
rp_smartfile = 'http://www.somethingawful.com/revv_smart_file.html';
</script>
<script type=""text/javascript"" src=""https://ads.rubiconproject.com/ad/8539.js""></script>
<!--  End Rubicon Project Tag -->
</div>





	<div id=""content"">

	

<div class=""breadcrumbs""><span class=""mainbodytextlarge""><b><a href=""/"">The Something Awful Forums</a> &gt; <a href=""private.php?s="">Private Messages</a> &gt; Edit Folders</b></span></div>

<form action=""private.php"" method=""post"">
	<input type=""hidden"" name=""action"" value=""doeditfolders"">

<div class=""standard"">
	<h2><b>Editing your Folders</b></h2>
	<div class=""inner"">
		<b>Your Folders:</b><br>
		1)
<input type=""text"" class=""bginput"" name=""folderlist[5]"" value=""awful! -- testing"" size=""40"" maxlength=""25"">
<br><INPUT TYPE=""hidden"" name=""highest"" value=""7"">
		<br>
		<br>
		<b>Add Folders:</b><br>
		1)
<input type=""text"" class=""bginput"" name=""folderlist[6]"" value="""" size=""40"" maxlength=""25"">
<br>2)
<input type=""text"" class=""bginput"" name=""folderlist[7]"" value="""" size=""40"" maxlength=""25"">
<br>3)
<input type=""text"" class=""bginput"" name=""folderlist[8]"" value="""" size=""40"" maxlength=""25"">
<br>
		<br>
		<input type=""submit"" class=""bginput"" name=""submit"" value=""Edit Folders"">
	</div>
</div>

</form>

<div style=""text-align:center;"" class=""standard"">
	<b>Instructions for this crappy interface:</b><br>
	To <b>delete</b> a folder, remove the folder's name from the respective box.
	All messages in this folder will be moved to the inbox.  To <b>rename</b> a
	folder, edit the name in the box.  To <b>add</b> a folder, enter the name in
	one of the empty boxes at the end of the list.
</div>

</div><!-- #content -->
	<ul class=""navigation"">
<li class=""first""><a href=""/index.php"">SA Forums</a></li>
<li>- <a href=""http://www.somethingawful.com/"">Something Awful</a></li>
<li>- <a href=""/f/search"">Search the Forums</a></li>
<li>- <a href=""/usercp.php"">User Control Panel</a></li>
<li>- <a href=""/private.php"">Private Messages</a></li>
<li>- <a href=""http://www.somethingawful.com/d/forum-rules/forum-rules.php"">Forum Rules</a></li>
<li>- <a href=""/dictionary.php"">SAclopedia</a></li>
<li>- <a href=""/stats.php"">Posting Gloryhole</a></li>
<li>- <a href=""/banlist.php"">Leper's Colony</a></li>
<li>- <a href=""/supportmail.php"">Support</a></li>
<li>- <a href=""/account.php?action=logout&amp;ma=10293618"">Log Out</a></li>

</ul>
	<div id=""copyright"">
		Powered by: vBulletin Version 2.2.9 (<a href=""/CHANGES"">SAVB-v2.1.17</a>)<br>
		Copyright &copy;2000, 2001, Jelsoft Enterprises Limited.<br>
		Copyright &copy;2012, Something Awful LLC<br>
	</div>

</div><!-- #container -->

<script type=""text/javascript"">
	// quantcast
	_qoptions = { qacct:""p-82vTvmw-enlng"" };

	try {
		if(document.location.hostname != 'forums.somethingawful.com')
			throw undefined;

		$(document).ready(function() {
			var qcUrl = 'http://edge.quantserve.com/quant.js';
			jQuery.getScript(qcUrl);

			var gaJsHost = ((""https:"" == document.location.protocol) ? ""https://ssl."" : ""http://www."");
			var gaUrl = gaJsHost + 'google-analytics.com/ga.js';
			jQuery.getScript(gaUrl, function() {
				var pageTracker = _gat._getTracker(""UA-3064978-2"");
				pageTracker._initData();
				pageTracker._trackPageview();
			});
		});
	} catch(e) {};

	// indie
	// try {
	// 	if(document.location.hostname != 'forums.somethingawful.com')
	// 		throw undefined;

	// 	$(document).ready(function() {
	// 		var ic_element = document.createElement('script');
	// 		ic_element.type = 'text/javascript';
	// 		ic_element.async = true;
	// 		ic_element.id = 'ic_annonymous_pixel';
	// 		ic_element.src = 'http://pixel.indieclick.com/annonymous/domain/somethingawful.com/reach/script_ic.js';
	// 		var ic_script = document.getElementsByTagName('script')[0];
	// 		ic_script.parentNode.insertBefore(ic_element, ic_script);
	// 	});
	// } catch(e) {};
</script>
<noscript><img src=""http://pixel.quantserve.com/pixel/p-82vTvmw-enlng.gif"" style=""display:none;"" border=""0"" height=""1"" width=""1"" alt=""Quantcast""></noscript>

<!-- PLEASE DO NOT REMOVE -->
<ol id=""debug"" style=""display:none""><li>&nbsp;</ol>

</body>
</html>";
        }
        public virtual string GenerateMockFolderListHtml()
        {
            return @"<!DOCTYPE html>
<html>
<head>
	<title>The Something Awful Forums - Private Messaging: bootleg robot</title>
	
	<meta name=""MSSmartTagsPreventParsing"" content=""TRUE"">
	<meta http-equiv=""X-UA-Compatible"" content=""chrome=1"">
	<!--[if lt IE 7]><link rel=""stylesheet"" type=""text/css"" href=""/css/ie.css?1348360344""><![endif]-->
	<!--[if lt IE 8]><link rel=""stylesheet"" type=""text/css"" href=""/css/ie7.css?1348360344""><![endif]-->
	<link rel=""apple-touch-icon"" href=""http://i.somethingawful.com/core/icon/iphone-touch/forums.png"">
	<link rel=""stylesheet"" type=""text/css"" href=""/css/main.css?1359594161"">
	<link rel=""stylesheet"" type=""text/css"" href=""/css/bbcode.css?1348360344"">
	<link rel=""stylesheet"" type=""text/css"" href=""http://www.somethingawful.com/globalcss/globalmenu.css"">

	

	<!-- <script src=""/__utm.js"" type=""text/javascript""></script> -->
	<!-- script src=""/js/dojo/dojo.js?1348360344"" type=""text/javascript""></script -->
	<script type=""text/javascript"" src=""//ajax.googleapis.com/ajax/libs/jquery/1.8.3/jquery.min.js""></script>
	<link rel=""stylesheet"" type=""text/css"" href=""//ajax.googleapis.com/ajax/libs/jqueryui/1.9.2/themes/redmond/jquery-ui.css"">
	<script type=""text/javascript"" src=""//ajax.googleapis.com/ajax/libs/jqueryui/1.9.2/jquery-ui.min.js""></script>

	<link rel=""stylesheet"" type=""text/css"" href=""http://www.somethingawful.com/css/forums.css?7"">

	

	<script type=""text/javascript"">
		
		
		
		
	</script>

	<script type=""text/javascript"" src=""/js/vb/forums.combined.js?1359653372""></script>

	

	<!-- ts-specific includes -->
	
	
	

	

	

	
	<script type=""text/javascript"">
	<!--
	function CheckAll() {
		for (var i=0;i<document.form.elements.length;i++) {
			var e = document.form.elements[i];
			if ((e.name != 'allbox') && (e.type=='checkbox')) {
				e.checked = document.form.allbox.checked;
			}
		}
	}
	function CheckCheckAll() {
		var TotalBoxes = 0;
		var TotalOn = 0;
		for (var i=0;i<document.form.elements.length;i++) {
			var e = document.form.elements[i];
			if ((e.name != 'allbox') && (e.type=='checkbox')) {
				TotalBoxes++;
				if (e.checked) {
					TotalOn++;
				}
			}
		}
		if (TotalBoxes==TotalOn) {
			document.form.allbox.checked=true;
		} else {
			document.form.allbox.checked=false;
		}
	}
	//-->
	</script>
	<style type=""text/css"">
		.pmwarn { margin:1em; color:red; font-weight:bold; padding-left:18px; background: url('http://fi.somethingawful.com/images/warning.gif') left no-repeat; }
		.msgbuttons { text-align:center; }
		.msgbuttons img { border:0; }
	</style>
</head>
<body id=""something_awful"" class=""privfolder"">
<div id=""globalmenu"">
	<ul>
		<li class=""first""><a href=""https://secure.somethingawful.com/"">Buy Forum Stuff</a></li>
		<li><a href=""http://www.somethingawful.com/"">Something Awful</a></li>
	</ul>
</div>



<div id=""container"">



	

	<ul id=""nav_purchase"">
		<li><b>Purchase:</b></li>
		<li><a href=""https://secure.somethingawful.com/products/register.php"">Account</a></li>
		<li>- <a href=""https://secure.somethingawful.com/products/platinum.php"">Platinum Upgrade</a></li>
		<li>- <a href=""https://secure.somethingawful.com/products/titlechange.php"">New Avatar</a></li>
		<li>- <a href=""https://secure.somethingawful.com/products/titlechange.php"">Other's Avatar</a></li>
		<li>- <a href=""https://secure.somethingawful.com/products/archives.php"">Archives</a></li>
		<li>- <a href=""https://secure.somethingawful.com/products/noads.php"">No-Ads</a></li>
		<li>- <a href=""https://secure.somethingawful.com/products/namechange.php"">New Username</a></li>
		<li>- <a href=""https://secure.somethingawful.com/products/ad-banner.php"">Banner Advertisement</a></li>
		<li>- <a href=""https://secure.somethingawful.com/products/smilie.php"">Smilie</a></li>
		<li>- <a href=""https://secure.somethingawful.com/products/sticky-thread.php"">Stick Thread</a></li>
		<li>- <a href=""https://secure.somethingawful.com/products/gift-certificate.php"">Gift Cert.</a></li>
	</ul>

	<ul id=""navigation"" class=""navigation"">
<li class=""first""><a href=""/index.php"">SA Forums</a></li>
<li>- <a href=""http://www.somethingawful.com/"">Something Awful</a></li>
<li>- <a href=""/f/search"">Search the Forums</a></li>
<li>- <a href=""/usercp.php"">User Control Panel</a></li>
<li>- <a href=""/private.php"">Private Messages</a></li>
<li>- <a href=""http://www.somethingawful.com/d/forum-rules/forum-rules.php"">Forum Rules</a></li>
<li>- <a href=""/dictionary.php"">SAclopedia</a></li>
<li>- <a href=""/stats.php"">Posting Gloryhole</a></li>
<li>- <a href=""/banlist.php"">Leper's Colony</a></li>
<li>- <a href=""/supportmail.php"">Support</a></li>
<li>- <a href=""/account.php?action=logout&amp;ma=10293618"">Log Out</a></li>

</ul>


<div class=""oma_pal"">
	<!--  Begin Rubicon Project Tag -->
<!--  Site: Something Awful LLC   Zone: Forum ATF Top Quality - Mobile, Pop, Web   Size: Leaderboard  -->
<!--  PLACEMENT: Above the Fold  -->
<script language=""JavaScript"" type=""text/javascript"">
rp_account   = '8539';
rp_site      = '13831';
rp_zonesize  = '80354-2';
rp_adtype    = 'iframe';
rp_width     = '728';
rp_height    = '90';
rp_smartfile = 'http://www.somethingawful.com/revv_smart_file.html';
</script>
<script type=""text/javascript"" src=""https://ads.rubiconproject.com/ad/8539.js""></script>
<!--  End Rubicon Project Tag -->
</div>





	<div id=""content"">

	

<div class=""breadcrumbs""><a href=""index.php"">The Something Awful Forums</a> &gt; <a href=""usercp.php"">User Control Panel For bootleg robot</a> &gt; <a href=""private.php"">Private Messages</a> &gt; Inbox</div>


	<ul id=""usercpnav"">
		<li><a href=""usercp.php"">User CP Home</a></li>
		<li><a href=""member.php?action=accountfeatures"">Account Features</a></li>
		<li><a href=""private.php"">Private Messages</a></li>
		<li><a href=""bookmarkthreads.php"">Bookmarked Threads</a></li>
		<li><a href=""member.php?action=editprofile"">Edit Profile</a></li>
		<li><a href=""member.php?action=editoptions"">Edit Options</a></li>
		<li><a href=""account.php?action=editpassword"">Change Password</a></li>
		<li><a href=""member2.php?action=viewlist&amp;userlist=buddy"">Edit Buddy List</a></li>
		<li><a href=""member2.php?action=viewlist&amp;userlist=ignore"">Edit Ignore List</a></li>
	</ul>


<form class=""date_select"" action=""private.php"" method=""post"">
<input type=""hidden"" name=""folderid"" value="""">
<b>Show Messages From:</b> <select name=""daysprune"" onchange=""window.location=('private.php?folderid=&amp;daysprune=' + this.options[this.selectedIndex].value)"">
	<option value=""1"" >last day</option>
	<option value=""2"" >last 2 days</option>
	<option value=""5"" >last 5 days</option>
	<option value=""10"" >last 10 days</option>
	<option value=""20"" >last 20 days</option>
	<option value=""30"" >last 30 days</option>
	<option value=""45"" >last 45 days</option>
	<option value=""60"" >last 60 days</option>
	<option value=""75"" >last 75 days</option>
	<option value=""100"" >last 100 days</option>
	<option value=""365"" >the last year</option>
	<option value=""9999"" selected>the beginning</option>
</select><input type=""submit"" value=""Go"">
</form>

<form class=""folder"" action=""private.php"" method=""post"">
	<b>Jump to folder:</b>
	<select name=""folderid"" onchange=""window.location=('private.php?folderid=' + this.options[this.selectedIndex].value + '&amp;daysprune=9999')"">
	<option value=""0"" selected>Inbox</option>
	<option value=""-1"" >Sent Items</option>
	<option value=""4"" >awful! -- testing</option>
	
	</select><input type=""submit"" value=""Go"">
</form>


	<div class=""pmwarn"">NOTICE: Only showing the last fifty messages to keep things fast, <a href=""?folderid=0&amp;daysprune=9999&amp;showall=1"">click here</a> to list them all!</div>


<form class=""action"" action=""private.php"" method=""post"" name=""form"">
	<table class=""standard full"">
		<thead>
        <tr>
            <th class=""title"" colspan=""3"">Message Title</th>
            <th class=""sender"">Sender</th>
            <th class=""date"">Date / Time Sent</th>
            <th class=""check""><input name=""allbox"" type=""checkbox"" value=""Check All"" title=""Select/Deselect All"" onClick=""CheckAll();""></th>
        </tr>
        </thead>

        <tbody>
        
		<tr>
			<td class=""status""><img src=""http://fi.somethingawful.com/images/pm.gif"" alt=""""></td>
			<td class=""icon"">&nbsp;</td>
			<td class=""title""><a href=""private.php?action=show&amp;privatemessageid=5284033"">Re: awful beta</a>
			</td>
			<td class=""sender"">Cybernetic Vermin</td>
			<td class=""date"">Feb 25, 2014 at 10:51</td>
			<td class=""check""><input type=""checkbox"" name=""privatemessage[5284033]"" value=""yes""></td>
		</tr>
		<tr>
			<td class=""status""><img src=""http://fi.somethingawful.com/images/pmreplied.gif"" alt=""""></td>
			<td class=""icon"">&nbsp;</td>
			<td class=""title""><a href=""private.php?action=show&amp;privatemessageid=5283835"">Re: awful beta</a>
			</td>
			<td class=""sender"">Cybernetic Vermin</td>
			<td class=""date"">Feb 25, 2014 at 09:11</td>
			<td class=""check""><input type=""checkbox"" name=""privatemessage[5283835]"" value=""yes""></td>
		</tr>
		<tr>
			<td class=""status""><img src=""http://fi.somethingawful.com/images/pmreplied.gif"" alt=""""></td>
			<td class=""icon""><img src=""http://fi.somethingawful.com/forums/posticons/icons-08/drugs.png"" alt=""Drugs, maaaan"" border=""0""></td>
			<td class=""title""><a href=""private.php?action=show&amp;privatemessageid=5191281"">WP8 awful app beta</a>
			</td>
			<td class=""sender"">Mecca-Benghazi</td>
			<td class=""date"">Dec 17, 2013 at 18:55</td>
			<td class=""check""><input type=""checkbox"" name=""privatemessage[5191281]"" value=""yes""></td>
		</tr>
		<tr>
			<td class=""status""><img src=""http://fi.somethingawful.com/images/pmreplied.gif"" alt=""""></td>
			<td class=""icon"">&nbsp;</td>
			<td class=""title""><a href=""private.php?action=show&amp;privatemessageid=5115595"">New Live ID for use in Awful beta</a>
			</td>
			<td class=""sender"">loquacius</td>
			<td class=""date"">Nov  1, 2013 at 10:04</td>
			<td class=""check""><input type=""checkbox"" name=""privatemessage[5115595]"" value=""yes""></td>
		</tr>
		<tr>
			<td class=""status""><img src=""http://fi.somethingawful.com/images/pm.gif"" alt=""""></td>
			<td class=""icon""><img src=""http://fi.somethingawful.com/forums/posticons/icons-08/repeat.png"" alt=""Repeated subject / link?"" border=""0""></td>
			<td class=""title""><a href=""private.php?action=show&amp;privatemessageid=5064952"">test message</a>
			</td>
			<td class=""sender"">bootleg robot</td>
			<td class=""date"">Oct  1, 2013 at 00:58</td>
			<td class=""check""><input type=""checkbox"" name=""privatemessage[5064952]"" value=""yes""></td>
		</tr>
		<tr>
			<td class=""status""><img src=""http://fi.somethingawful.com/images/pm.gif"" alt=""""></td>
			<td class=""icon"">&nbsp;</td>
			<td class=""title""><a href=""private.php?action=show&amp;privatemessageid=5022492"">Re: Awful thread tags are in their own repository</a>
			</td>
			<td class=""sender"">pokeyman</td>
			<td class=""date"">Sep  3, 2013 at 14:46</td>
			<td class=""check""><input type=""checkbox"" name=""privatemessage[5022492]"" value=""yes""></td>
		</tr>
		<tr>
			<td class=""status""><img src=""http://fi.somethingawful.com/images/pmreplied.gif"" alt=""""></td>
			<td class=""icon""><img src=""http://fi.somethingawful.com/forums/posticons/icons-08/link.png"" alt=""URL Link"" border=""0""></td>
			<td class=""title""><a href=""private.php?action=show&amp;privatemessageid=5020312"">Awful thread tags are in their own repository</a>
			</td>
			<td class=""sender"">pokeyman</td>
			<td class=""date"">Sep  2, 2013 at 05:20</td>
			<td class=""check""><input type=""checkbox"" name=""privatemessage[5020312]"" value=""yes""></td>
		</tr>
		<tr>
			<td class=""status""><img src=""http://fi.somethingawful.com/images/pm.gif"" alt=""""></td>
			<td class=""icon"">&nbsp;</td>
			<td class=""title""><a href=""private.php?action=show&amp;privatemessageid=4975760"">Re: One more order!</a>
			</td>
			<td class=""sender"">Night141</td>
			<td class=""date"">Aug  1, 2013 at 13:01</td>
			<td class=""check""><input type=""checkbox"" name=""privatemessage[4975760]"" value=""yes""></td>
		</tr>
		<tr>
			<td class=""status""><img src=""http://fi.somethingawful.com/images/pm.gif"" alt=""""></td>
			<td class=""icon"">&nbsp;</td>
			<td class=""title""><a href=""private.php?action=show&amp;privatemessageid=4966740"">Shipping info Nexus 7</a>
			</td>
			<td class=""sender"">Night141</td>
			<td class=""date"">Jul 26, 2013 at 13:59</td>
			<td class=""check""><input type=""checkbox"" name=""privatemessage[4966740]"" value=""yes""></td>
		</tr>
		<tr>
			<td class=""status""><img src=""http://fi.somethingawful.com/images/pm.gif"" alt=""""></td>
			<td class=""icon"">&nbsp;</td>
			<td class=""title""><a href=""private.php?action=show&amp;privatemessageid=4966720"">Nexus 7</a>
			</td>
			<td class=""sender"">Night141</td>
			<td class=""date"">Jul 26, 2013 at 13:41</td>
			<td class=""check""><input type=""checkbox"" name=""privatemessage[4966720]"" value=""yes""></td>
		</tr>
		<tr>
			<td class=""status""><img src=""http://fi.somethingawful.com/images/pmreplied.gif"" alt=""""></td>
			<td class=""icon"">&nbsp;</td>
			<td class=""title""><a href=""private.php?action=show&amp;privatemessageid=4964145"">Re: Nexus 7</a>
			</td>
			<td class=""sender"">Night141</td>
			<td class=""date"">Jul 24, 2013 at 14:44</td>
			<td class=""check""><input type=""checkbox"" name=""privatemessage[4964145]"" value=""yes""></td>
		</tr>
		<tr>
			<td class=""status""><img src=""http://fi.somethingawful.com/images/pm.gif"" alt=""""></td>
			<td class=""icon"">&nbsp;</td>
			<td class=""title""><a href=""private.php?action=show&amp;privatemessageid=4956423"">Re: Awful Reader Beta</a>
			</td>
			<td class=""sender"">bootleg robot</td>
			<td class=""date"">Jul 18, 2013 at 16:08</td>
			<td class=""check""><input type=""checkbox"" name=""privatemessage[4956423]"" value=""yes""></td>
		</tr>
		<tr>
			<td class=""status""><img src=""http://fi.somethingawful.com/images/pmreplied.gif"" alt=""""></td>
			<td class=""icon"">&nbsp;</td>
			<td class=""title""><a href=""private.php?action=show&amp;privatemessageid=4925821"">Awful Reader Beta</a>
			</td>
			<td class=""sender"">rufius</td>
			<td class=""date"">Jun 27, 2013 at 17:10</td>
			<td class=""check""><input type=""checkbox"" name=""privatemessage[4925821]"" value=""yes""></td>
		</tr>
		<tr>
			<td class=""status""><img src=""http://fi.somethingawful.com/images/pm.gif"" alt=""""></td>
			<td class=""icon""><img src=""http://fi.somethingawful.com/forums/posticons/icons-08/drugs.png"" alt=""Drugs, maaaan"" border=""0""></td>
			<td class=""title""><a href=""private.php?action=show&amp;privatemessageid=4925637"">Hey, maybe you should update the OP or something.</a>
			</td>
			<td class=""sender"">bootleg robot</td>
			<td class=""date"">Jun 27, 2013 at 15:16</td>
			<td class=""check""><input type=""checkbox"" name=""privatemessage[4925637]"" value=""yes""></td>
		</tr>
		<tr>
			<td class=""status""><img src=""http://fi.somethingawful.com/images/pm.gif"" alt=""""></td>
			<td class=""icon"">&nbsp;</td>
			<td class=""title""><a href=""private.php?action=show&amp;privatemessageid=4897741"">Re: Repository of selectors for parsing SA HTML?</a>
			</td>
			<td class=""sender"">pokeyman</td>
			<td class=""date"">Jun 11, 2013 at 12:10</td>
			<td class=""check""><input type=""checkbox"" name=""privatemessage[4897741]"" value=""yes""></td>
		</tr>
		<tr>
			<td class=""status""><img src=""http://fi.somethingawful.com/images/pm.gif"" alt=""""></td>
			<td class=""icon"">&nbsp;</td>
			<td class=""title""><a href=""private.php?action=show&amp;privatemessageid=4897540"">Re: Repository of selectors for parsing SA HTML?</a>
			</td>
			<td class=""sender"">pokeyman</td>
			<td class=""date"">Jun 11, 2013 at 10:43</td>
			<td class=""check""><input type=""checkbox"" name=""privatemessage[4897540]"" value=""yes""></td>
		</tr>
		<tr>
			<td class=""status""><img src=""http://fi.somethingawful.com/images/pmreplied.gif"" alt=""""></td>
			<td class=""icon"">&nbsp;</td>
			<td class=""title""><a href=""private.php?action=show&amp;privatemessageid=4895648"">Re: Repository of selectors for parsing SA HTML?</a>
			</td>
			<td class=""sender"">pokeyman</td>
			<td class=""date"">Jun 10, 2013 at 10:23</td>
			<td class=""check""><input type=""checkbox"" name=""privatemessage[4895648]"" value=""yes""></td>
		</tr>
		<tr>
			<td class=""status""><img src=""http://fi.somethingawful.com/images/pmreplied.gif"" alt=""""></td>
			<td class=""icon""><img src=""http://fi.somethingawful.com/forums/posticons/icons-08/school.png"" alt=""School"" border=""0""></td>
			<td class=""title""><a href=""private.php?action=show&amp;privatemessageid=4894884"">Repository of selectors for parsing SA HTML?</a>
			</td>
			<td class=""sender"">pokeyman</td>
			<td class=""date"">Jun  9, 2013 at 19:57</td>
			<td class=""check""><input type=""checkbox"" name=""privatemessage[4894884]"" value=""yes""></td>
		</tr>
		<tr>
			<td class=""status""><img src=""http://fi.somethingawful.com/images/pm.gif"" alt=""""></td>
			<td class=""icon"">&nbsp;</td>
			<td class=""title""><a href=""private.php?action=show&amp;privatemessageid=4872565"">Re: How do you POST a new thread?</a>
			</td>
			<td class=""sender"">pokeyman</td>
			<td class=""date"">May 25, 2013 at 21:14</td>
			<td class=""check""><input type=""checkbox"" name=""privatemessage[4872565]"" value=""yes""></td>
		</tr>
		<tr>
			<td class=""status""><img src=""http://fi.somethingawful.com/images/pmreplied.gif"" alt=""""></td>
			<td class=""icon"">&nbsp;</td>
			<td class=""title""><a href=""private.php?action=show&amp;privatemessageid=4871868"">Re: How do you POST a new thread?</a>
			</td>
			<td class=""sender"">pokeyman</td>
			<td class=""date"">May 25, 2013 at 09:07</td>
			<td class=""check""><input type=""checkbox"" name=""privatemessage[4871868]"" value=""yes""></td>
		</tr>
		<tr>
			<td class=""status""><img src=""http://fi.somethingawful.com/images/pm.gif"" alt=""""></td>
			<td class=""icon"">&nbsp;</td>
			<td class=""title""><a href=""private.php?action=show&amp;privatemessageid=4863725"">Re: How do you POST a new thread?</a>
			</td>
			<td class=""sender"">pokeyman</td>
			<td class=""date"">May 20, 2013 at 12:53</td>
			<td class=""check""><input type=""checkbox"" name=""privatemessage[4863725]"" value=""yes""></td>
		</tr>
		<tr>
			<td class=""status""><img src=""http://fi.somethingawful.com/images/pmreplied.gif"" alt=""""></td>
			<td class=""icon"">&nbsp;</td>
			<td class=""title""><a href=""private.php?action=show&amp;privatemessageid=4863671"">How do you POST a new thread?</a>
			</td>
			<td class=""sender"">pokeyman</td>
			<td class=""date"">May 20, 2013 at 12:13</td>
			<td class=""check""><input type=""checkbox"" name=""privatemessage[4863671]"" value=""yes""></td>
		</tr>
		<tr>
			<td class=""status""><img src=""http://fi.somethingawful.com/images/pm.gif"" alt=""""></td>
			<td class=""icon"">&nbsp;</td>
			<td class=""title""><a href=""private.php?action=show&amp;privatemessageid=4856950"">Re: Awful Forums App</a>
			</td>
			<td class=""sender"">The Lord Bude</td>
			<td class=""date"">May 15, 2013 at 15:03</td>
			<td class=""check""><input type=""checkbox"" name=""privatemessage[4856950]"" value=""yes""></td>
		</tr>
		<tr>
			<td class=""status""><img src=""http://fi.somethingawful.com/images/pmreplied.gif"" alt=""""></td>
			<td class=""icon"">&nbsp;</td>
			<td class=""title""><a href=""private.php?action=show&amp;privatemessageid=4849472"">Awful Forums App</a>
			</td>
			<td class=""sender"">The Lord Bude</td>
			<td class=""date"">May 10, 2013 at 09:33</td>
			<td class=""check""><input type=""checkbox"" name=""privatemessage[4849472]"" value=""yes""></td>
		</tr>
		<tr>
			<td class=""status""><img src=""http://fi.somethingawful.com/images/pmreplied.gif"" alt=""""></td>
			<td class=""icon"">&nbsp;</td>
			<td class=""title""><a href=""private.php?action=show&amp;privatemessageid=4835468"">Re: Awful!! HD</a>
			</td>
			<td class=""sender"">pocket pool</td>
			<td class=""date"">Apr 29, 2013 at 20:49</td>
			<td class=""check""><input type=""checkbox"" name=""privatemessage[4835468]"" value=""yes""></td>
		</tr>
		<tr>
			<td class=""status""><img src=""http://fi.somethingawful.com/images/pm.gif"" alt=""""></td>
			<td class=""icon"">&nbsp;</td>
			<td class=""title""><a href=""private.php?action=show&amp;privatemessageid=4834961"">Re: test message</a>
			</td>
			<td class=""sender"">bootleg robot</td>
			<td class=""date"">Apr 29, 2013 at 14:18</td>
			<td class=""check""><input type=""checkbox"" name=""privatemessage[4834961]"" value=""yes""></td>
		</tr>
		<tr>
			<td class=""status""><img src=""http://fi.somethingawful.com/images/pm.gif"" alt=""""></td>
			<td class=""icon""><img src=""http://fi.somethingawful.com/forums/posticons/icons-08/newbie.png"" alt=""NEWBIE QUESTION"" border=""0""></td>
			<td class=""title""><a href=""private.php?action=show&amp;privatemessageid=4834904"">test message</a>
			</td>
			<td class=""sender"">bootleg robot</td>
			<td class=""date"">Apr 29, 2013 at 13:39</td>
			<td class=""check""><input type=""checkbox"" name=""privatemessage[4834904]"" value=""yes""></td>
		</tr>
		<tr>
			<td class=""status""><img src=""http://fi.somethingawful.com/images/pmreplied.gif"" alt=""""></td>
			<td class=""icon"">&nbsp;</td>
			<td class=""title""><a href=""private.php?action=show&amp;privatemessageid=4834604"">Re: Awful!! HD</a>
			</td>
			<td class=""sender"">pocket pool</td>
			<td class=""date"">Apr 29, 2013 at 09:21</td>
			<td class=""check""><input type=""checkbox"" name=""privatemessage[4834604]"" value=""yes""></td>
		</tr>
		<tr>
			<td class=""status""><img src=""http://fi.somethingawful.com/images/pm.gif"" alt=""""></td>
			<td class=""icon"">&nbsp;</td>
			<td class=""title""><a href=""private.php?action=show&amp;privatemessageid=4832030"">Re: Awful -- Squishing this bug</a>
			</td>
			<td class=""sender"">The Lord Bude</td>
			<td class=""date"">Apr 26, 2013 at 23:33</td>
			<td class=""check""><input type=""checkbox"" name=""privatemessage[4832030]"" value=""yes""></td>
		</tr>
		<tr>
			<td class=""status""><img src=""http://fi.somethingawful.com/images/pm.gif"" alt=""""></td>
			<td class=""icon"">&nbsp;</td>
			<td class=""title""><a href=""private.php?action=show&amp;privatemessageid=4831910"">Re: Awful -- Squishing this bug</a>
			</td>
			<td class=""sender"">The Lord Bude</td>
			<td class=""date"">Apr 26, 2013 at 21:36</td>
			<td class=""check""><input type=""checkbox"" name=""privatemessage[4831910]"" value=""yes""></td>
		</tr>
		<tr>
			<td class=""status""><img src=""http://fi.somethingawful.com/images/pm.gif"" alt=""""></td>
			<td class=""icon"">&nbsp;</td>
			<td class=""title""><a href=""private.php?action=show&amp;privatemessageid=4831850"">Re: Awful -- Squishing this bug</a>
			</td>
			<td class=""sender"">The Lord Bude</td>
			<td class=""date"">Apr 26, 2013 at 20:29</td>
			<td class=""check""><input type=""checkbox"" name=""privatemessage[4831850]"" value=""yes""></td>
		</tr>
		<tr>
			<td class=""status""><img src=""http://fi.somethingawful.com/images/pmreplied.gif"" alt=""""></td>
			<td class=""icon"">&nbsp;</td>
			<td class=""title""><a href=""private.php?action=show&amp;privatemessageid=4823295"">Re: Awful!! HD</a>
			</td>
			<td class=""sender"">pocket pool</td>
			<td class=""date"">Apr 21, 2013 at 11:00</td>
			<td class=""check""><input type=""checkbox"" name=""privatemessage[4823295]"" value=""yes""></td>
		</tr>
		<tr>
			<td class=""status""><img src=""http://fi.somethingawful.com/images/pm.gif"" alt=""""></td>
			<td class=""icon"">&nbsp;</td>
			<td class=""title""><a href=""private.php?action=show&amp;privatemessageid=4822384"">Re: Awful!! HD</a>
			</td>
			<td class=""sender"">pocket pool</td>
			<td class=""date"">Apr 20, 2013 at 14:58</td>
			<td class=""check""><input type=""checkbox"" name=""privatemessage[4822384]"" value=""yes""></td>
		</tr>
		<tr>
			<td class=""status""><img src=""http://fi.somethingawful.com/images/pmreplied.gif"" alt=""""></td>
			<td class=""icon"">&nbsp;</td>
			<td class=""title""><a href=""private.php?action=show&amp;privatemessageid=4822077"">Awful!! HD</a>
			</td>
			<td class=""sender"">pocket pool</td>
			<td class=""date"">Apr 20, 2013 at 11:44</td>
			<td class=""check""><input type=""checkbox"" name=""privatemessage[4822077]"" value=""yes""></td>
		</tr>
		<tr>
			<td class=""status""><img src=""http://fi.somethingawful.com/images/pm.gif"" alt=""""></td>
			<td class=""icon"">&nbsp;</td>
			<td class=""title""><a href=""private.php?action=show&amp;privatemessageid=4821600"">Re: Forum app beta expired</a>
			</td>
			<td class=""sender"">The Lord Bude</td>
			<td class=""date"">Apr 19, 2013 at 22:25</td>
			<td class=""check""><input type=""checkbox"" name=""privatemessage[4821600]"" value=""yes""></td>
		</tr>
		<tr>
			<td class=""status""><img src=""http://fi.somethingawful.com/images/pmreplied.gif"" alt=""""></td>
			<td class=""icon"">&nbsp;</td>
			<td class=""title""><a href=""private.php?action=show&amp;privatemessageid=4805674"">awful beta</a>
			</td>
			<td class=""sender"">Cybernetic Vermin</td>
			<td class=""date"">Apr  9, 2013 at 12:32</td>
			<td class=""check""><input type=""checkbox"" name=""privatemessage[4805674]"" value=""yes""></td>
		</tr>
		<tr>
			<td class=""status""><img src=""http://fi.somethingawful.com/images/pm.gif"" alt=""""></td>
			<td class=""icon""><img src=""http://fi.somethingawful.com/forums/posticons/icons-08/computers.png"" alt=""Computer issues"" border=""0""></td>
			<td class=""title""><a href=""private.php?action=show&amp;privatemessageid=4799784"">Awful beta</a>
			</td>
			<td class=""sender"">Bender</td>
			<td class=""date"">Apr  4, 2013 at 20:36</td>
			<td class=""check""><input type=""checkbox"" name=""privatemessage[4799784]"" value=""yes""></td>
		</tr>
		<tr>
			<td class=""status""><img src=""http://fi.somethingawful.com/images/pm.gif"" alt=""""></td>
			<td class=""icon"">&nbsp;</td>
			<td class=""title""><a href=""private.php?action=show&amp;privatemessageid=4798111"">Forum app beta expired</a>
			</td>
			<td class=""sender"">The Lord Bude</td>
			<td class=""date"">Apr  3, 2013 at 20:15</td>
			<td class=""check""><input type=""checkbox"" name=""privatemessage[4798111]"" value=""yes""></td>
		</tr>
		<tr>
			<td class=""status""><img src=""http://fi.somethingawful.com/images/pm.gif"" alt=""""></td>
			<td class=""icon"">&nbsp;</td>
			<td class=""title""><a href=""private.php?action=show&amp;privatemessageid=4786258"">Awful!! Beta for Windows Phone invite</a>
			</td>
			<td class=""sender"">NFX</td>
			<td class=""date"">Mar 26, 2013 at 14:52</td>
			<td class=""check""><input type=""checkbox"" name=""privatemessage[4786258]"" value=""yes""></td>
		</tr>
		<tr>
			<td class=""status""><img src=""http://fi.somethingawful.com/images/pm.gif"" alt=""""></td>
			<td class=""icon"">&nbsp;</td>
			<td class=""title""><a href=""private.php?action=show&amp;privatemessageid=4778908"">Re: Awful Reader Beta Access</a>
			</td>
			<td class=""sender"">H2SO4</td>
			<td class=""date"">Mar 20, 2013 at 21:50</td>
			<td class=""check""><input type=""checkbox"" name=""privatemessage[4778908]"" value=""yes""></td>
		</tr>
		<tr>
			<td class=""status""><img src=""http://fi.somethingawful.com/images/pmreplied.gif"" alt=""""></td>
			<td class=""icon"">&nbsp;</td>
			<td class=""title""><a href=""private.php?action=show&amp;privatemessageid=4776809"">Re: Awful Reader Beta Access</a>
			</td>
			<td class=""sender"">H2SO4</td>
			<td class=""date"">Mar 19, 2013 at 14:44</td>
			<td class=""check""><input type=""checkbox"" name=""privatemessage[4776809]"" value=""yes""></td>
		</tr>
		<tr>
			<td class=""status""><img src=""http://fi.somethingawful.com/images/pmreplied.gif"" alt=""""></td>
			<td class=""icon""><img src=""http://fi.somethingawful.com/forums/posticons/icons-08/request.png"" alt=""Request!"" border=""0""></td>
			<td class=""title""><a href=""private.php?action=show&amp;privatemessageid=4776540"">Awful Reader Beta Access</a>
			</td>
			<td class=""sender"">H2SO4</td>
			<td class=""date"">Mar 19, 2013 at 11:43</td>
			<td class=""check""><input type=""checkbox"" name=""privatemessage[4776540]"" value=""yes""></td>
		</tr>
		<tr>
			<td class=""status""><img src=""http://fi.somethingawful.com/images/pmreplied.gif"" alt=""""></td>
			<td class=""icon"">&nbsp;</td>
			<td class=""title""><a href=""private.php?action=show&amp;privatemessageid=4759493"">Screenshots of my stack trace</a>
			</td>
			<td class=""sender"">loquacius</td>
			<td class=""date"">Mar  7, 2013 at 18:43</td>
			<td class=""check""><input type=""checkbox"" name=""privatemessage[4759493]"" value=""yes""></td>
		</tr>
		<tr>
			<td class=""status""><img src=""http://fi.somethingawful.com/images/pm.gif"" alt=""""></td>
			<td class=""icon"">&nbsp;</td>
			<td class=""title""><a href=""private.php?action=show&amp;privatemessageid=4723172"">Re: Lumia 920</a>
			</td>
			<td class=""sender"">Carl Winslow</td>
			<td class=""date"">Feb 12, 2013 at 14:52</td>
			<td class=""check""><input type=""checkbox"" name=""privatemessage[4723172]"" value=""yes""></td>
		</tr>
		<tr>
			<td class=""status""><img src=""http://fi.somethingawful.com/images/pmreplied.gif"" alt=""""></td>
			<td class=""icon"">&nbsp;</td>
			<td class=""title""><a href=""private.php?action=show&amp;privatemessageid=4721932"">Re: Lumia 920</a>
			</td>
			<td class=""sender"">Carl Winslow</td>
			<td class=""date"">Feb 11, 2013 at 18:53</td>
			<td class=""check""><input type=""checkbox"" name=""privatemessage[4721932]"" value=""yes""></td>
		</tr>
		<tr>
			<td class=""status""><img src=""http://fi.somethingawful.com/images/pm.gif"" alt=""""></td>
			<td class=""icon"">&nbsp;</td>
			<td class=""title""><a href=""private.php?action=show&amp;privatemessageid=4721312"">Re: Lumia 920</a>
			</td>
			<td class=""sender"">Carl Winslow</td>
			<td class=""date"">Feb 11, 2013 at 12:11</td>
			<td class=""check""><input type=""checkbox"" name=""privatemessage[4721312]"" value=""yes""></td>
		</tr>
		<tr>
			<td class=""status""><img src=""http://fi.somethingawful.com/images/pm.gif"" alt=""""></td>
			<td class=""icon"">&nbsp;</td>
			<td class=""title""><a href=""private.php?action=show&amp;privatemessageid=4715805"">Re: Lumia 920</a>
			</td>
			<td class=""sender"">Carl Winslow</td>
			<td class=""date"">Feb  7, 2013 at 13:30</td>
			<td class=""check""><input type=""checkbox"" name=""privatemessage[4715805]"" value=""yes""></td>
		</tr>
		<tr>
			<td class=""status""><img src=""http://fi.somethingawful.com/images/pmreplied.gif"" alt=""""></td>
			<td class=""icon"">&nbsp;</td>
			<td class=""title""><a href=""private.php?action=show&amp;privatemessageid=4713084"">Re: Lumia 920</a>
			</td>
			<td class=""sender"">Carl Winslow</td>
			<td class=""date"">Feb  5, 2013 at 17:09</td>
			<td class=""check""><input type=""checkbox"" name=""privatemessage[4713084]"" value=""yes""></td>
		</tr>
		<tr>
			<td class=""status""><img src=""http://fi.somethingawful.com/images/pm.gif"" alt=""""></td>
			<td class=""icon"">&nbsp;</td>
			<td class=""title""><a href=""private.php?action=show&amp;privatemessageid=4708839"">Re: Lumia 920</a>
			</td>
			<td class=""sender"">Carl Winslow</td>
			<td class=""date"">Feb  2, 2013 at 13:17</td>
			<td class=""check""><input type=""checkbox"" name=""privatemessage[4708839]"" value=""yes""></td>
		</tr>
		<tr>
			<td class=""status""><img src=""http://fi.somethingawful.com/images/pmreplied.gif"" alt=""""></td>
			<td class=""icon"">&nbsp;</td>
			<td class=""title""><a href=""private.php?action=show&amp;privatemessageid=4705681"">Re: Lumia 920</a>
			</td>
			<td class=""sender"">Carl Winslow</td>
			<td class=""date"">Jan 31, 2013 at 11:47</td>
			<td class=""check""><input type=""checkbox"" name=""privatemessage[4705681]"" value=""yes""></td>
		</tr>
        </tbody>
		<tfoot>
			<tr>
				<td align=""right"" colspan=""7""><b>
					<input type=""hidden"" name=""action"" value=""dostuff"">
					<input type=""hidden"" name=""thisfolder"" value=""0"">
					Selected messages: <select name=""folderid""><option value=""0"">Inbox</option><option value=""4"" >awful! -- testing</option></select>
					<input type=""submit"" class=""bginput"" name=""move"" value=""Move"">
					
					<input type=""submit"" class=""bginput"" name=""delete"" value=""Delete"">
					</b>
				</td>
			</tr>
		</tfoot>
	</table>
</form>

<br>

<!-- message buttons -->
<div class=""msgbuttons"">
	<a href=""private.php?action=newmessage""><img src=""http://fi.somethingawful.com/images/pm/newmessage.gif"" alt=""Send a new private message""></a>
	
	
	<a href=""private.php?action=editfolders""><img src=""http://fi.somethingawful.com/images/pm/folders.gif"" alt=""Organize your private message folders""></a>
</div>

<br>


<form class=""forum_jump"" action=""forumdisplay.php"" method=""get"">
<input type=""hidden"" name=""s"" value="""">
<input type=""hidden"" name=""daysprune"" value="""">
<select name=""forumid"">
<option value=""-1"" selected>Jump to another forum:</option>
<option value=""-1"">--------------------</option>
<option value=""pm"" >Private Messages</option>
<option value=""cp"" >User Control Panel</option>
<option value=""search"" >Search Forums</option>
<option value=""home"" >Forums Home</option>
<option value=""lc"" >Leper's Colony</option>
<option value=""-1"">--------------------</option>
<option value=""48"" > Main</option><option value=""1"" >-- GBS 1.4</option><option value=""155"" >---- SA's Front Page Discussion</option><option value=""214"" >---- E/N Bullshit</option><option value=""26"" >-- FYAD: http://vimeo.com/86014703</option><option value=""154"" >---- A Beecock Forum.</option><option value=""268"" >-- BYOB 8.2</option><option value=""51"" > Discussion</option><option value=""44"" >-- Games</option><option value=""259"" >---- A Blizzard Subforum</option><option value=""146"" >------ WoW: Goon Squad</option><option value=""145"" >---- The MMO HMO</option><option value=""93"" >---- Private Game Servers</option><option value=""234"" >---- Dice &amp; Drama</option><option value=""103"" >------ The Goblin Ranch</option><option value=""191"" >---- Let's Play!</option><option value=""267"" >---- Dungeons &amp; Dreamcast Recreation Dome</option><option value=""192"" >-- Inspect Your Gadgets</option><option value=""158"" >-- Ask / Tell</option><option value=""162"" >---- Science, Academics and Languages</option><option value=""211"" >---- Tourism &amp; Travel</option><option value=""200"" >---- Business, Finance, and Careers</option><option value=""46"" >-- Debate Disco</option><option value=""22"" >-- Serious Hardware / Software Crap</option><option value=""170"" >---- Haus of Tech Support</option><option value=""202"" >---- The Cavern of COBOL</option><option value=""265"" >------ project.log</option><option value=""219"" >---- YOSPOS</option><option value=""122"" >-- Sports Argument Stadium* </option><option value=""181"" >---- The Football Funhouse</option><option value=""248"" >---- The Armchair Quarterback</option><option value=""175"" >---- The Ray Parlour</option><option value=""177"" >---- Punchsport Pagoda</option><option value=""179"" >-- You Look Like Shit</option><option value=""183"" >---- The Goon Doctor</option><option value=""244"" >---- The Fitness Log Cabin</option><option value=""242"" >-- Paranormal/Conspiracy Forum</option><option value=""161"" >-- Goons With Spoons</option><option value=""167"" >-- Post Your Favorite (or Request)</option><option value=""91"" >-- Automotive Insanity</option><option value=""236"" >---- Cycle Asylum</option><option value=""124"" >-- Pet Island</option><option value=""132"" >-- The Firing Range</option><option value=""90"" >-- The Crackhead Clubhouse</option><option value=""218"" >-- Goons in Platoons</option><option value=""152"" > The Finer Arts</option><option value=""31"" >-- Creative Convention</option><option value=""210"" >---- DIY &amp; Hobbies</option><option value=""247"" >---- The Dorkroom</option><option value=""151"" >-- Cinema Discusso</option><option value=""133"" >---- The Film Dump</option><option value=""182"" >-- The Book Barn</option><option value=""150"" >-- No Music Discussion</option><option value=""104"" >---- Musician's Lounge</option><option value=""130"" >-- The TV IV</option><option value=""144"" >-- Batman's Shameful Secret</option><option value=""27"" >-- ADTRW</option><option value=""215"" >-- Entertainment, Weakly</option><option value=""255"" >-- Rapidly Going Deaf</option><option value=""153"" > The Community</option><option value=""61"" >-- SA-Mart</option><option value=""77"" >---- Feedback &amp; Discussion</option><option value=""85"" >---- Coupons &amp; Deals</option><option value=""43"" >-- Goon Meets</option><option value=""241"" >-- LAN: Your City Sucks - Regional Discussion</option><option value=""188"" >-- Questions, Comments, Suggestions? - Read the stickies first!</option><option value=""49"" > Archives</option><option value=""21"" >-- Comedy Goldmine</option><option value=""264"" >---- Comedy Purgatory</option><option value=""115"" >---- FYAD: Criterion Collection</option><option value=""204"" >---- Helldump Success Stories</option><option value=""222"" >---- LF Goldmine</option><option value=""229"" >---- YCS Goldmine</option><option value=""25"" >-- Comedy Gas Chamber</option>
</select>
<input type=""submit"" value=""Go"">
</form>

<br>

<!-- icon key -->
<table>
<tr>
	<td rowspan=""3"" width=""50%"">&nbsp;</td>
	<td colspan=""6"" align=""center"">
		<b>Message quota for all folders: 500</b>
	</td>
	<td rowspan=""3"" width=""50%"">&nbsp;</td></tr>
</tr>
<tr>
	<td nowrap><img src=""http://fi.somethingawful.com/images/newpm.gif"" alt=""Unread Message""></td>
	<td nowrap><b>Unread Message</b></td>
	<td nowrap><img src=""http://fi.somethingawful.com/images/pm.gif"" border=0 alt=""Message""></td>
	<td nowrap><b>Message</b></td>
	<td nowrap><img src=""http://fi.somethingawful.com/images/trashcan.gif"" alt=""Cancelled Message""></td>
	<td nowrap><b>Cancelled Message</b></td>
<tr>
	<td nowrap><img src=""http://fi.somethingawful.com/images/pmreplied.gif"" alt=""Replied to Message""></td>
	<td nowrap><b>Replied to Message</b></td>
	<td nowrap><img src=""http://fi.somethingawful.com/images/pmforwarded.gif"" alt=""Forwarded Message""></td>
	<td nowrap colspan=""3""><b>Forwarded Message</b></td>
</tr>
</table>
<!-- icon key -->

</div><!-- #content -->
	<ul class=""navigation"">
<li class=""first""><a href=""/index.php"">SA Forums</a></li>
<li>- <a href=""http://www.somethingawful.com/"">Something Awful</a></li>
<li>- <a href=""/f/search"">Search the Forums</a></li>
<li>- <a href=""/usercp.php"">User Control Panel</a></li>
<li>- <a href=""/private.php"">Private Messages</a></li>
<li>- <a href=""http://www.somethingawful.com/d/forum-rules/forum-rules.php"">Forum Rules</a></li>
<li>- <a href=""/dictionary.php"">SAclopedia</a></li>
<li>- <a href=""/stats.php"">Posting Gloryhole</a></li>
<li>- <a href=""/banlist.php"">Leper's Colony</a></li>
<li>- <a href=""/supportmail.php"">Support</a></li>
<li>- <a href=""/account.php?action=logout&amp;ma=10293618"">Log Out</a></li>

</ul>
	<div id=""copyright"">
		Powered by: vBulletin Version 2.2.9 (<a href=""/CHANGES"">SAVB-v2.1.17</a>)<br>
		Copyright &copy;2000, 2001, Jelsoft Enterprises Limited.<br>
		Copyright &copy;2012, Something Awful LLC<br>
	</div>

</div><!-- #container -->

<script type=""text/javascript"">
	// quantcast
	_qoptions = { qacct:""p-82vTvmw-enlng"" };

	try {
		if(document.location.hostname != 'forums.somethingawful.com')
			throw undefined;

		$(document).ready(function() {
			var qcUrl = 'http://edge.quantserve.com/quant.js';
			jQuery.getScript(qcUrl);

			var gaJsHost = ((""https:"" == document.location.protocol) ? ""https://ssl."" : ""http://www."");
			var gaUrl = gaJsHost + 'google-analytics.com/ga.js';
			jQuery.getScript(gaUrl, function() {
				var pageTracker = _gat._getTracker(""UA-3064978-2"");
				pageTracker._initData();
				pageTracker._trackPageview();
			});
		});
	} catch(e) {};

	// indie
	// try {
	// 	if(document.location.hostname != 'forums.somethingawful.com')
	// 		throw undefined;

	// 	$(document).ready(function() {
	// 		var ic_element = document.createElement('script');
	// 		ic_element.type = 'text/javascript';
	// 		ic_element.async = true;
	// 		ic_element.id = 'ic_annonymous_pixel';
	// 		ic_element.src = 'http://pixel.indieclick.com/annonymous/domain/somethingawful.com/reach/script_ic.js';
	// 		var ic_script = document.getElementsByTagName('script')[0];
	// 		ic_script.parentNode.insertBefore(ic_element, ic_script);
	// 	});
	// } catch(e) {};
</script>
<noscript><img src=""http://pixel.quantserve.com/pixel/p-82vTvmw-enlng.gif"" style=""display:none;"" border=""0"" height=""1"" width=""1"" alt=""Quantcast""></noscript>

<!-- PLEASE DO NOT REMOVE -->
<ol id=""debug"" style=""display:none""><li>&nbsp;</ol>

</body>
</html>";
        }
        public virtual string GenerateMockUserSettingsHtml()
        {
            return @"<!DOCTYPE html>
<html>
<head>
<title>The Something Awful Forums - Change options</title>

	<meta name=""MSSmartTagsPreventParsing"" content=""TRUE"">
	<meta http-equiv=""X-UA-Compatible"" content=""chrome=1"">
	<!--[if lt IE 7]><link rel=""stylesheet"" type=""text/css"" href=""/css/ie.css?1348360344""><![endif]-->
	<!--[if lt IE 8]><link rel=""stylesheet"" type=""text/css"" href=""/css/ie7.css?1348360344""><![endif]-->
	<link rel=""apple-touch-icon"" href=""http://i.somethingawful.com/core/icon/iphone-touch/forums.png"">
	<link rel=""stylesheet"" type=""text/css"" href=""/css/main.css?1359594161"">
	<link rel=""stylesheet"" type=""text/css"" href=""/css/bbcode.css?1348360344"">
	<link rel=""stylesheet"" type=""text/css"" href=""http://www.somethingawful.com/globalcss/globalmenu.css"">

	

	<!-- <script src=""/__utm.js"" type=""text/javascript""></script> -->
	<!-- script src=""/js/dojo/dojo.js?1348360344"" type=""text/javascript""></script -->
	<script type=""text/javascript"" src=""//ajax.googleapis.com/ajax/libs/jquery/1.8.3/jquery.min.js""></script>
	<link rel=""stylesheet"" type=""text/css"" href=""//ajax.googleapis.com/ajax/libs/jqueryui/1.9.2/themes/redmond/jquery-ui.css"">
	<script type=""text/javascript"" src=""//ajax.googleapis.com/ajax/libs/jqueryui/1.9.2/jquery-ui.min.js""></script>

	<link rel=""stylesheet"" type=""text/css"" href=""http://www.somethingawful.com/css/forums.css?7"">

	

	<script type=""text/javascript"">
		
		
		
		
	</script>

	<script type=""text/javascript"" src=""/js/vb/forums.combined.js?1359653372""></script>

	

	<!-- ts-specific includes -->
	
	
	

	

	

	
</head>
<body id=""something_awful"" class=""modifyoptions"">
<div id=""globalmenu"">
	<ul>
		<li class=""first""><a href=""https://secure.somethingawful.com/"">Buy Forum Stuff</a></li>
		<li><a href=""http://www.somethingawful.com/"">Something Awful</a></li>
	</ul>
</div>



<div id=""container"">



	

	<ul id=""nav_purchase"">
		<li><b>Purchase:</b></li>
		<li><a href=""https://secure.somethingawful.com/products/register.php"">Account</a></li>
		<li>- <a href=""https://secure.somethingawful.com/products/platinum.php"">Platinum Upgrade</a></li>
		<li>- <a href=""https://secure.somethingawful.com/products/titlechange.php"">New Avatar</a></li>
		<li>- <a href=""https://secure.somethingawful.com/products/titlechange.php"">Other's Avatar</a></li>
		<li>- <a href=""https://secure.somethingawful.com/products/archives.php"">Archives</a></li>
		<li>- <a href=""https://secure.somethingawful.com/products/noads.php"">No-Ads</a></li>
		<li>- <a href=""https://secure.somethingawful.com/products/namechange.php"">New Username</a></li>
		<li>- <a href=""https://secure.somethingawful.com/products/ad-banner.php"">Banner Advertisement</a></li>
		<li>- <a href=""https://secure.somethingawful.com/products/smilie.php"">Smilie</a></li>
		<li>- <a href=""https://secure.somethingawful.com/products/sticky-thread.php"">Stick Thread</a></li>
		<li>- <a href=""https://secure.somethingawful.com/products/gift-certificate.php"">Gift Cert.</a></li>
	</ul>

	<ul id=""navigation"" class=""navigation"">
<li class=""first""><a href=""/index.php"">SA Forums</a></li>
<li>- <a href=""http://www.somethingawful.com/"">Something Awful</a></li>
<li>- <a href=""/f/search"">Search the Forums</a></li>
<li>- <a href=""/usercp.php"">User Control Panel</a></li>
<li>- <a href=""/private.php"">Private Messages</a></li>
<li>- <a href=""http://www.somethingawful.com/d/forum-rules/forum-rules.php"">Forum Rules</a></li>
<li>- <a href=""/dictionary.php"">SAclopedia</a></li>
<li>- <a href=""/stats.php"">Posting Gloryhole</a></li>
<li>- <a href=""/banlist.php"">Leper's Colony</a></li>
<li>- <a href=""/supportmail.php"">Support</a></li>
<li>- <a href=""/account.php?action=logout&amp;ma=10293618"">Log Out</a></li>

</ul>


<div class=""oma_pal"">
	<!--  Begin Rubicon Project Tag -->
<!--  Site: Something Awful LLC   Zone: Forum ATF Top Quality - Mobile, Pop, Web   Size: Leaderboard  -->
<!--  PLACEMENT: Above the Fold  -->
<script language=""JavaScript"" type=""text/javascript"">
rp_account   = '8539';
rp_site      = '13831';
rp_zonesize  = '80354-2';
rp_adtype    = 'iframe';
rp_width     = '728';
rp_height    = '90';
rp_smartfile = 'http://www.somethingawful.com/revv_smart_file.html';
</script>
<script type=""text/javascript"" src=""https://ads.rubiconproject.com/ad/8539.js""></script>
<!--  End Rubicon Project Tag -->
</div>





	<div id=""content"">

	

<div class=""breadcrumbs""><a href=""index.php"">The Something Awful Forums</a> &gt; <a href=""usercp.php"">User Control Panel For bootleg robot</a> &gt; Edit Options</div>


	<ul id=""usercpnav"">
		<li><a href=""usercp.php"">User CP Home</a></li>
		<li><a href=""member.php?action=accountfeatures"">Account Features</a></li>
		<li><a href=""private.php"">Private Messages</a></li>
		<li><a href=""bookmarkthreads.php"">Bookmarked Threads</a></li>
		<li><a href=""member.php?action=editprofile"">Edit Profile</a></li>
		<li><a href=""member.php?action=editoptions"">Edit Options</a></li>
		<li><a href=""account.php?action=editpassword"">Change Password</a></li>
		<li><a href=""member2.php?action=viewlist&amp;userlist=buddy"">Edit Buddy List</a></li>
		<li><a href=""member2.php?action=viewlist&amp;userlist=ignore"">Edit Ignore List</a></li>
	</ul>

<form action=""member.php"" method=""post"">
<input type=""hidden"" name=""action"" value=""updateoptions"">

<table class=""standard vbfake"">
<tr><th colspan=""2""><b>Edit Options - bootleg robot</b></th></tr>

<tr><th colspan=""2""><b>Login, Cookies &amp; Privacy</b></th></tr>
<tr class=""altcolor2"">
	<td><b>Invisible Mode?</b><br>
	Selecting yes allows you to surf the forums without appearing in the online members list.</td>
	<td>
		<input type=""radio"" name=""invisible"" value=""yes"" > <b>yes</b>
		<input type=""radio"" name=""invisible"" value=""no"" checked> <b>no</b>
	</td>
</tr>
<tr class=""altcolor1"">
	<td><b>Automatically login when you return to the site? (uses cookies)</b></td>
	<td>
		<input type=""radio"" name=""cookieuser""  value=""yes""> <b>yes</b>
		<input type=""radio"" name=""cookieuser""  value=""no""> <b>no</b>
	</td>
</tr>
<tr class=""altcolor2"">
	<td><b>Allow other users to email you?</b><br>
	Enable this if you would like other forums members to be able to send you email using the email link in your user profile.  Your email address is not revealed to the sending user, but you will see the address of users that send mail to you.</td>
	<td>
		<input type=""radio"" name=""showemail"" value=""yes"" > <b>yes</b>
		<input type=""radio"" name=""showemail"" value=""no"" checked> <b>no</b>
	</td>
</tr>

<tr><th colspan=""2""><b>Thread Tracking</b></th></tr>
<tr class=""altcolor2"">
	<td><b>Bookmark threads I post/reply in by default</b><br>
		Your <a href=""/bookmarkthreads.php"">bookmark list</a> acts like a custom forum containing only the threads you've bookmarked!
	</td>
	<td>
		<input type=""radio"" name=""bookmark_own_posts"" value=""yes"" checked> <b>yes</b>
		<input type=""radio"" name=""bookmark_own_posts"" value=""no"" > <b>no</b>
	</td>
</tr>
<tr class=""altcolor1"">
	<td><b>Mark posts on pages I've already seen in a different color</b></td>
	<td>
		<input type=""radio"" name=""color_seen"" value=""yes"" checked> <b>yes</b>
		<input type=""radio"" name=""color_seen"" value=""no"" > <b>no</b>
	</td>
</tr>

<tr class=""altcolor2"">
	<td><b>Highlight threads I've seen in a different color</b></td>
	<td>
		<input type=""radio"" name=""threads_highlight_seen"" value=""yes"" checked> <b>yes</b>
		<input type=""radio"" name=""threads_highlight_seen"" value=""no"" > <b>no</b>
	</td>
</tr>
<tr class=""altcolor1"">
	<td><b>Colorize threads according to the bookmark category I've assigned</b></td>
	<td>
		<input type=""radio"" name=""threads_colorize_bookmarks"" value=""yes"" checked> <b>yes</b>
		<input type=""radio"" name=""threads_colorize_bookmarks"" value=""no"" > <b>no</b>
	</td>
</tr>
<tr class=""altcolor2"">
	<td><b>Show an icon next to each post indicating if it has been seen or not</b><br>
		The icon can be clicked on to set the seen time to that of the post.
	</td>
	<td>
		<input type=""radio"" name=""show_seen_icon"" value=""yes"" checked> <b>yes</b>
		<input type=""radio"" name=""show_seen_icon"" value=""no"" > <b>no</b>
	</td>
</tr>
<tr class=""altcolor1"">
	<td><b>Show bookmark category &quot;star buttons&quot; next to threads</b><br>
		Allows you to assign different colored stars to a thread, click the star to cycle through colors
	</td>
	<td>
		<input type=""radio"" name=""threads_star_buttons"" value=""yes"" > <b>yes</b>
		<input type=""radio"" name=""threads_star_buttons"" value=""no"" checked> <b>no</b>
	</td>
</tr>


<tr><th colspan=""2""><b>Messaging &amp; Notification</b></th></tr>
<tr class=""altcolor1"">
	<td><b>Allow Bulletin Board Administrators and Moderators To Send You Email Notices?</b></td>
	<td>
		<input type=""radio"" name=""allowmail"" value=""yes"" checked> <b>yes</b>
		<input type=""radio"" name=""allowmail"" value=""no"" > <b>no</b>
	</td>
</tr>
<tr class=""altcolor2"">
	<td><b>Enable Private Messaging?</b><br>
	Allows people to send Private Messages to you</td>
	<td>
		<input type=""radio"" name=""receivepm"" checked value=""yes""> <b>yes</b>
		<input type=""radio"" name=""receivepm""  value=""no""> <b>no</b>
	</td>
</tr>
<tr>
	<td><b>Send you an email when you receive a Private Message?</b></td>
	<td>
		<input type=""radio"" name=""emailonpm"" checked value=""yes""> <b>yes</b>
		<input type=""radio"" name=""emailonpm""  value=""no""> <b>no</b>
	</td>
</tr>
<tr class=""altcolor2"">
	<td><b>Pop up a box when you receive a Private Message?</b><br>
	This will pop up a small warning box when you receive a Private Message asking whether you want to view the message.</td>
	<td>
		<input type=""radio"" name=""pmpopup""  value=""yes""> <b>yes</b>
		<input type=""radio"" name=""pmpopup"" checked value=""no""> <b>no</b>
	</td>
</tr>

<tr><th colspan=""2""><b>Thread View Options</b></th></tr>
<tr class=""altcolor2"">
	<td><b>Highlight the username of the &quot;original poster&quot; in thread posts</b></td>
	<td>
		<input type=""radio"" name=""threads_highlight_op"" value=""yes"" checked> <b>yes</b>
		<input type=""radio"" name=""threads_highlight_op"" value=""no"" > <b>no</b>
	</td>
</tr>
<tr class=""altcolor1"">
	<td><b>Adjust the page position to the top of the requested post after the page loads</b><br>
		Meant to readjust the page after images load (currently buggy in IE6)
	</td>
	<td>
		<input type=""radio"" name=""js_onload_postjump"" value=""yes"" > <b>yes</b>
		<input type=""radio"" name=""js_onload_postjump"" value=""no"" checked> <b>no</b>
	</td>
</tr>
<tr class=""altcolor2"">
	<td><b>Show user's signatures in their posts?</b></td>
	<td>
		<input type=""radio"" name=""showsignatures"" value=""yes"" > <b>yes</b>
		<input type=""radio"" name=""showsignatures"" value=""no"" checked> <b>no</b>
	</td>
</tr>
<tr>
	<td><b>Show user's avatar in their posts?</b></td>
	<td>
		<input type=""radio"" name=""showavatars"" value=""yes"" checked> <b>yes</b>
		<input type=""radio"" name=""showavatars"" value=""no"" > <b>no</b>
	</td>
</tr>
<tr class=""altcolor2"">
	<td><b>Show image attachments and [img] code in Posts?</b><br>
	Selecting &quot;no&quot; will show a hyperlink instead.</td>
	<td>
		<input type=""radio"" name=""showimages"" value=""yes"" checked> <b>yes</b>
		<input type=""radio"" name=""showimages"" value=""no"" > <b>no</b>
	</td>
</tr>
<tr>
	<td><b>Show video embedded in posts with the [video] tag?</b><br>
	Selecting &quot;no&quot; will show a hyperlink instead.</td>
	<td>
		<input type=""radio"" name=""showvideo"" value=""yes"" checked> <b>yes</b>
		<input type=""radio"" name=""showvideo"" value=""no"" > <b>no</b>
	</td>
</tr>
<tr class=""altcolor2"">
	<td><b>Show smilie images in posts?</b><br>
	Selecting &quot;yes&quot; will convert smilies to images.</td>
	<td>
		<input type=""radio"" name=""showsmilies"" value=""yes"" checked> <b>yes</b>
		<input type=""radio"" name=""showsmilies"" value=""no"" > <b>no</b>
	</td>
</tr>
<tr class=""altcolor1"">
	<td><b>Default Thread View:</b></td>
	<td>
	<select name=""prunedays"">
		<option value=""-1"" selected>Use forum default</option>
		<option value=""1"" >Show threads from last day</option>
		<option value=""2"" >Show threads from last 2 days</option>
		<option value=""5"" >Show threads from last 5 days</option>
		<option value=""10"" >Show threads from last 10 days</option>
		<option value=""20"" >Show threads from last 20 days</option>
		<option value=""30"" >Show threads from last 30 days</option>
		<option value=""45"" >Show threads from last 45 days</option>
		<option value=""60"" >Show threads from last 60 days</option>
		<option value=""75"" >Show threads from last 75 days</option>
		<option value=""100"" >Show threads from last 100 days</option>
		<option value=""365"" >Show threads from the last year</option>
		<option value=""1000"" >Show all threads</option>
	</select></td>
</tr>
<tr class=""altcolor2"">
	<td><b>Default Posts per Thread:</b><br>
	Number of posts that are shown on one page of a thread.</td>
	<td>
	<select name=""umaxposts"">
		<option value=""-1"" >Use forum default</option>
			<option value=""5"" >Show 5 posts per page</option>	<option value=""10"" >Show 10 posts per page</option>	<option value=""20"" >Show 20 posts per page</option>	<option value=""30"" >Show 30 posts per page</option>	<option value=""40"" >Show 40 posts per page</option>
	</select></td>
</tr>

<tr><th colspan=""2""><b>Posting Options</b></th></tr>
<tr>
	<td>
		<b>Disable advanced posting features?</b><br>
		This will disable keyboard shortcuts and auto-formatting pasted Youtube and Imgur links.
	</td>
	<td>
		<input type=""radio"" name=""adv_post_disabled"" value=""yes"" > <b>yes</b>
		<input type=""radio"" name=""adv_post_disabled"" value=""no"" checked> <b>no</b>
	</td>
</tr>

<tr><th colspan=""2""><b>Date &amp; Time Options</b></th></tr>
<tr class=""altcolor1"">
	<td><b>Start of the week</b><br>
	Please choose the day of the week on which weeks start in your culture.
	This is so your calendar appears correct to you.</td>
	<td>
	<select name=""startofweek"">
		<option value=""1"" selected>Sunday</option>
		<option value=""2"" >Monday</option>
		<option value=""3"" >Tuesday</option>
		<option value=""4"" >Wednesday</option>
		<option value=""5"" >Thursday</option>
		<option value=""6"" >Friday</option>
		<option value=""7"" >Saturday</option>
	</select></td>
</tr>
<tr>
	<td colspan=""2""><b>Time offset:</b><br>
	 Please select your time zone from the list:<br>
	<select name=""timezoneoffset"">
		<option value=""-12"" >(GMT -12:00 hours) Eniwetok, Kwajalein</option>
		<option value=""-11"" >(GMT -11:00 hours) Midway Island, Samoa</option>
		<option value=""-10"" >(GMT -10:00 hours) Hawaii</option>
		<option value=""-9"" >(GMT -9:00 hours) Alaska</option>
		<option value=""-8"" >(GMT -8:00 hours) Pacific Time (US &amp; Canada)</option>
		<option value=""-7"" >(GMT -7:00 hours) Mountain Time (US &amp; Canada)</option>
		<option value=""-6"" selected>(GMT -6:00 hours) Central Time (US &amp; Canada), Mexico City</option>
		<option value=""-5"" >(GMT -5:00 hours) Eastern Time (US &amp; Canada), Bogota, Lima, Quito</option>
		<option value=""-4"" >(GMT -4:00 hours) Atlantic Time (Canada), Caracas, La Paz</option>
		<option value=""-3.5"" >(GMT -3:30 hours) Newfoundland</option>
		<option value=""-3"" >(GMT -3:00 hours) Brazil, Buenos Aires, Georgetown</option>
		<option value=""-2"" >(GMT -2:00 hours) Mid-Atlantic</option>
		<option value=""-1"" >(GMT -1:00 hours) Azores, Cape Verde Islands</option>
		<option value=""0"" >(GMT) Western Europe Time, London, Lisbon, Casablanca, Monrovia</option>
		<option value=""+1"" >(GMT +1:00 hours) CET(Central Europe Time), Brussels, Copenhagen, Madrid, Paris</option>
		<option value=""+2"" >(GMT +2:00 hours) EET(Eastern Europe Time), Kaliningrad, South Africa</option>
		<option value=""+3"" >(GMT +3:00 hours) Baghdad, Kuwait, Riyadh, Moscow, St. Petersburg, Volgograd, Nairobi</option>
		<option value=""+3.5"" >(GMT +3:30 hours) Tehran</option>
		<option value=""+4"" >(GMT +4:00 hours) Abu Dhabi, Muscat, Baku, Tbilisi</option>
		<option value=""+4.5"" >(GMT +4:30 hours) Kabul</option>
		<option value=""+5"" >(GMT +5:00 hours) Ekaterinburg, Islamabad, Karachi, Tashkent</option>
		<option value=""+5.5"" >(GMT +5:30 hours) Bombay, Calcutta, Madras, New Delhi</option>
		<option value=""+6"" >(GMT +6:00 hours) Almaty, Dhaka, Colombo</option>
		<option value=""+7"" >(GMT +7:00 hours) Bangkok, Hanoi, Jakarta</option>
		<option value=""+8"" >(GMT +8:00 hours) Beijing, Perth, Singapore, Hong Kong, Chongqing, Urumqi, Taipei</option>
		<option value=""+9"" >(GMT +9:00 hours) Tokyo, Seoul, Osaka, Sapporo, Yakutsk</option>
		<option value=""+9.5"" >(GMT +9:30 hours) Adelaide, Darwin</option>
		<option value=""+10"" >(GMT +10:00 hours) EAST(East Australian Standard), Guam, Papua New Guinea, Vladivostok</option>
		<option value=""+11"" >(GMT +11:00 hours) Magadan, Solomon Islands, New Caledonia</option>
		<option value=""+12"" >(GMT +12:00 hours) Auckland, Wellington, Fiji, Kamchatka, Marshall Island</option>
	</select></td>
</tr>
<tr>
	<td>
		<b>Use Daylight Saving Time?</b><br>
		Do you really need all that day light?  Save some for others to use you jerk!
	</td>
	<td>
		<input type=""radio"" name=""use_dst"" value=""yes"" > <b>yes</b>
		<input type=""radio"" name=""use_dst"" value=""no"" checked> <b>no</b>
	</td>
</tr>
<tr>
	<td>
		<b>Use 12 hour time format?</b><br>
		This will format the time with AM/PM instead of using the 24 hour time format.
	</td>
	<td>
		<input type=""radio"" name=""time_ampm"" value=""yes"" > <b>yes</b>
		<input type=""radio"" name=""time_ampm"" value=""no"" checked> <b>no</b>
	</td>
</tr>

<tr><th colspan=""2""><b>Advertisement Options</b><a name=""adoptions""></a></th></tr>

<tr class=""altcolor2"">
	<td colspan=2>
		Users with the <a href=""https://secure.somethingawful.com/products/noads.php"">No-Ads Upgrade</a> get additional options here to toggle ad banners on and off.
	</td>
</tr>



<tr><th colspan=""2""><b>Other Options</b></th></tr>
<tr>
	<td><b>Hide Google/Amazon search bars?</b><br>
	Toggle the Google and Amazon search bars displayed at the top of the screen.</td>
	<td>
		<input type=""radio"" name=""hidesearchbars"" value=""yes"" checked> <b>yes</b>
		<input type=""radio"" name=""hidesearchbars"" value=""no"" > <b>no</b>
	</td>
</tr>

</table>

<br>

<div style=""text-align:center;"">
	<input type=""submit"" class=""bginput"" name=""Submit"" value=""Submit Modifications"">
	<input type=""reset"" class=""bginput"" name=""Reset"" value=""Reset Fields"">
</div>

</form>

</div><!-- #content -->
	<ul class=""navigation"">
<li class=""first""><a href=""/index.php"">SA Forums</a></li>
<li>- <a href=""http://www.somethingawful.com/"">Something Awful</a></li>
<li>- <a href=""/f/search"">Search the Forums</a></li>
<li>- <a href=""/usercp.php"">User Control Panel</a></li>
<li>- <a href=""/private.php"">Private Messages</a></li>
<li>- <a href=""http://www.somethingawful.com/d/forum-rules/forum-rules.php"">Forum Rules</a></li>
<li>- <a href=""/dictionary.php"">SAclopedia</a></li>
<li>- <a href=""/stats.php"">Posting Gloryhole</a></li>
<li>- <a href=""/banlist.php"">Leper's Colony</a></li>
<li>- <a href=""/supportmail.php"">Support</a></li>
<li>- <a href=""/account.php?action=logout&amp;ma=10293618"">Log Out</a></li>

</ul>
	<div id=""copyright"">
		Powered by: vBulletin Version 2.2.9 (<a href=""/CHANGES"">SAVB-v2.1.17</a>)<br>
		Copyright &copy;2000, 2001, Jelsoft Enterprises Limited.<br>
		Copyright &copy;2012, Something Awful LLC<br>
	</div>

</div><!-- #container -->

<script type=""text/javascript"">
	// quantcast
	_qoptions = { qacct:""p-82vTvmw-enlng"" };

	try {
		if(document.location.hostname != 'forums.somethingawful.com')
			throw undefined;

		$(document).ready(function() {
			var qcUrl = 'http://edge.quantserve.com/quant.js';
			jQuery.getScript(qcUrl);

			var gaJsHost = ((""https:"" == document.location.protocol) ? ""https://ssl."" : ""http://www."");
			var gaUrl = gaJsHost + 'google-analytics.com/ga.js';
			jQuery.getScript(gaUrl, function() {
				var pageTracker = _gat._getTracker(""UA-3064978-2"");
				pageTracker._initData();
				pageTracker._trackPageview();
			});
		});
	} catch(e) {};

	// indie
	// try {
	// 	if(document.location.hostname != 'forums.somethingawful.com')
	// 		throw undefined;

	// 	$(document).ready(function() {
	// 		var ic_element = document.createElement('script');
	// 		ic_element.type = 'text/javascript';
	// 		ic_element.async = true;
	// 		ic_element.id = 'ic_annonymous_pixel';
	// 		ic_element.src = 'http://pixel.indieclick.com/annonymous/domain/somethingawful.com/reach/script_ic.js';
	// 		var ic_script = document.getElementsByTagName('script')[0];
	// 		ic_script.parentNode.insertBefore(ic_element, ic_script);
	// 	});
	// } catch(e) {};
</script>
<noscript><img src=""http://pixel.quantserve.com/pixel/p-82vTvmw-enlng.gif"" style=""display:none;"" border=""0"" height=""1"" width=""1"" alt=""Quantcast""></noscript>

<!-- PLEASE DO NOT REMOVE -->
<ol id=""debug"" style=""display:none""><li>&nbsp;</ol>

</body>
</html>";
        }
        public virtual string GenerateMockSmiliesHtml()
        {
            return @"<!DOCTYPE html>
<html lang=""en"">
<head>
	<title>The Something Awful Forums - Smilies</title>
	<meta http-equiv=""Content-type"" content=""text/html;charset=iso-8859-1"">

	<meta name=""MSSmartTagsPreventParsing"" content=""TRUE"">
	<meta http-equiv=""X-UA-Compatible"" content=""chrome=1"">
	<!--[if lt IE 7]><link rel=""stylesheet"" type=""text/css"" href=""/css/ie.css?1348360344""><![endif]-->
	<!--[if lt IE 8]><link rel=""stylesheet"" type=""text/css"" href=""/css/ie7.css?1348360344""><![endif]-->
	<link rel=""apple-touch-icon"" href=""http://i.somethingawful.com/core/icon/iphone-touch/forums.png"">
	<link rel=""stylesheet"" type=""text/css"" href=""/css/main.css?1359594161"">
	<link rel=""stylesheet"" type=""text/css"" href=""/css/bbcode.css?1348360344"">
	<link rel=""stylesheet"" type=""text/css"" href=""http://www.somethingawful.com/globalcss/globalmenu.css"">

	

	<!-- <script src=""/__utm.js"" type=""text/javascript""></script> -->
	<!-- script src=""/js/dojo/dojo.js?1348360344"" type=""text/javascript""></script -->
	<script type=""text/javascript"" src=""//ajax.googleapis.com/ajax/libs/jquery/1.8.3/jquery.min.js""></script>
	<link rel=""stylesheet"" type=""text/css"" href=""//ajax.googleapis.com/ajax/libs/jqueryui/1.9.2/themes/redmond/jquery-ui.css"">
	<script type=""text/javascript"" src=""//ajax.googleapis.com/ajax/libs/jqueryui/1.9.2/jquery-ui.min.js""></script>

	<link rel=""stylesheet"" type=""text/css"" href=""http://www.somethingawful.com/css/forums.css?7"">

	

	<script type=""text/javascript"">
		
		
		
		
	</script>

	<script type=""text/javascript"" src=""/js/vb/forums.combined.js?1359653372""></script>

	

	<!-- ts-specific includes -->
	
	
	

	

	

	
	<script type=""text/javascript"">
		/* <![CDATA[ */	

       function cb(txt) {
           if(window.clipboardData) {
               window.clipboardData.setData(""Text"", txt);
           } else {
               var fc = 'fc';
               if(!document.getElementById(fc)) {
                   var dh = document.createElement('div');
                   dh.id = fc;
                   document.body.appendChild(dh);
               }
               document.getElementById(fc).innerHTML = '';
               var di = '<embed src=""http://www.somethingawful.com/forums/_clipboard.swf"" FlashVars=""clipboard='+escape(txt)+'"" width=""0"" height=""0"" type=""application/x-shockwave-flash""' + '><' + '/embed>';
               document.getElementById(fc).innerHTML = di;
           }
       }

		dojo.addOnLoad(function() {
			var lis = dojo.html.getElementsByClass('smilie');
			for(i = 0; i < lis.length; i++) {
				var li = lis[i];
				dojo.event.connect(li, 'onclick', function(e) { get_text(e.currentTarget); return true; });
			}
		});

		function get_text(el) {
			if(el.tagName != 'LI') return;
			smtext = dojo.html.getElementsByClass('text', el)[0].innerHTML;
			cb(smtext);
		}

		/* ]]> */
	</script>
</head>
<body id=""something_awful"" class=""smilies"">
<div id=""globalmenu"">
	<ul>
		<li class=""first""><a href=""https://secure.somethingawful.com/"">Buy Forum Stuff</a></li>
		<li><a href=""http://www.somethingawful.com/"">Something Awful</a></li>
	</ul>
</div>



<div id=""container"">



	

	<ul id=""nav_purchase"">
		<li><b>Purchase:</b></li>
		<li><a href=""https://secure.somethingawful.com/products/register.php"">Account</a></li>
		<li>- <a href=""https://secure.somethingawful.com/products/platinum.php"">Platinum Upgrade</a></li>
		<li>- <a href=""https://secure.somethingawful.com/products/titlechange.php"">New Avatar</a></li>
		<li>- <a href=""https://secure.somethingawful.com/products/titlechange.php"">Other's Avatar</a></li>
		<li>- <a href=""https://secure.somethingawful.com/products/archives.php"">Archives</a></li>
		<li>- <a href=""https://secure.somethingawful.com/products/noads.php"">No-Ads</a></li>
		<li>- <a href=""https://secure.somethingawful.com/products/namechange.php"">New Username</a></li>
		<li>- <a href=""https://secure.somethingawful.com/products/ad-banner.php"">Banner Advertisement</a></li>
		<li>- <a href=""https://secure.somethingawful.com/products/smilie.php"">Smilie</a></li>
		<li>- <a href=""https://secure.somethingawful.com/products/sticky-thread.php"">Stick Thread</a></li>
		<li>- <a href=""https://secure.somethingawful.com/products/gift-certificate.php"">Gift Cert.</a></li>
	</ul>

	<ul id=""navigation"" class=""navigation"">
<li class=""first""><a href=""/index.php"">SA Forums</a></li>
<li>- <a href=""http://www.somethingawful.com/"">Something Awful</a></li>
<li>- <a href=""/f/search"">Search the Forums</a></li>
<li>- <a href=""/usercp.php"">User Control Panel</a></li>
<li>- <a href=""/private.php"">Private Messages</a></li>
<li>- <a href=""http://www.somethingawful.com/d/forum-rules/forum-rules.php"">Forum Rules</a></li>
<li>- <a href=""/dictionary.php"">SAclopedia</a></li>
<li>- <a href=""/stats.php"">Posting Gloryhole</a></li>
<li>- <a href=""/banlist.php"">Leper's Colony</a></li>
<li>- <a href=""/supportmail.php"">Support</a></li>
<li>- <a href=""/account.php?action=logout&amp;ma=10293618"">Log Out</a></li>

</ul>


<div class=""oma_pal"">
	<!--  Begin Rubicon Project Tag -->
<!--  Site: Something Awful LLC   Zone: Forum ATF Top Quality - Mobile, Pop, Web   Size: Leaderboard  -->
<!--  PLACEMENT: Above the Fold  -->
<script language=""JavaScript"" type=""text/javascript"">
rp_account   = '8539';
rp_site      = '13831';
rp_zonesize  = '80354-2';
rp_adtype    = 'iframe';
rp_width     = '728';
rp_height    = '90';
rp_smartfile = 'http://www.somethingawful.com/revv_smart_file.html';
</script>
<script type=""text/javascript"" src=""https://ads.rubiconproject.com/ad/8539.js""></script>
<!--  End Rubicon Project Tag -->
</div>





	<div id=""content"">

	

<br>

<div class=""standard smilie_list"" id=""main_full"">
	<h2>Smilies</h2>
	<div class=""inner"">
	Smilies are small graphical images that can be used to convey an emotion or
	feeling.  If you have used email or internet chat, you are likely familiar
	with the smilie concept.  Certain standard strings are automatically
	converted into smilies.  Try twisting your head on one side if you do not
	get smilies; using a bit of imagination should reveal a face of some
	description.<br>
	<br>
	<b>You can click a smilie to copy the smilie text to your clipboard (if your browser supports it).</b><br>
	<br>
	Here's the list of currently accepted smilies:<br>
	<br>

	<h3>Basic Smilies</h3>
<ul class=""smilie_group"">
	<li class=""smilie"">
		<div class=""text"">:(</div>
		<img alt="""" src=""http://fi.somethingawful.com/images/smilies/frown.gif"" title=""frown"">
	<li class=""smilie"">
		<div class=""text"">:)</div>
		<img alt="""" src=""http://fi.somethingawful.com/images/smilies/smile.gif"" title=""smile"">
	<li class=""smilie"">
		<div class=""text"">:30bux:</div>
		<img alt="""" src=""http://fi.somethingawful.com/images/smilies/emot-2001.png"" title=""2001 Monolith"">
	<li class=""smilie"">
		<div class=""text"">:3:</div>
		<img alt="""" src=""http://i.somethingawful.com/forumsystem/emoticons/emot-3.gif"" title=""kitty face"">
	<li class=""smilie"">
		<div class=""text"">:aaa:</div>
		<img alt="""" src=""http://i.somethingawful.com/forumsystem/emoticons/emot-aaa.gif"" title=""my mouth is opening oh no"">
	<li class=""smilie"">
		<div class=""text"">:aaaaa:</div>
		<img alt="""" src=""http://i.somethingawful.com/forumsystem/emoticons/emot-aaaaa.gif"" title=""AAAAAAHHHHHHHHH!"">
	<li class=""smilie"">
		<div class=""text"">:airquote:</div>
		<img alt="""" src=""http://i.somethingawful.com/forumsystem/emoticons/emot-airquote.gif"" title=""metaironysarcasm quoting"">
	<li class=""smilie"">
		<div class=""text"">:allears:</div>
		<img alt="""" src=""http://i.somethingawful.com/forumsystem/emoticons/emot-allears.gif"" title=""All Ears"">
	<li class=""smilie"">
		<div class=""text"">:angel:</div>
		<img alt="""" src=""http://i.somethingawful.com/forumsystem/emoticons/emot-angel.gif"" title=""sop babys"">
	<li class=""smilie"">
		<div class=""text"">:argh:</div>
		<img alt="""" src=""http://i.somethingawful.com/forumsystem/emoticons/emot-argh.gif"" title=""Argh!"">
	<li class=""smilie"">
		<div class=""text"">:arghfist:</div>
		<img alt="""" src=""http://i.somethingawful.com/forumsystem/emoticons/emot-arghfist.gif"" title=""SO ANGRY"">
	<li class=""smilie"">
		<div class=""text"">:bang:</div>
		<img alt="""" src=""http://fi.somethingawful.com/images/smilies/emot-bang.gif"" title=""Banging head against the wall"">
	<li class=""smilie"">
		<div class=""text"">:banjo:</div>
		<img alt="""" src=""http://fi.somethingawful.com/images/smilies/emot-banjo.gif"" title=""Some banjo thing somebody bought for some great reason I suppose"">
	<li class=""smilie"">
		<div class=""text"">:black101:</div>
		<img alt="""" src=""http://i.somethingawful.com/forumsystem/emoticons/emot-black101.gif"" title=""Grimm and frostbitten"">
	<li class=""smilie"">
		<div class=""text"">:blush:</div>
		<img alt="""" src=""http://i.somethingawful.com/forumsystem/emoticons/emot-blush.gif"" title=""Oh... heh, I was just..."">
	<li class=""smilie"">
		<div class=""text"">:bravo2:</div>
		<img alt="""" src=""http://i.somethingawful.com/forumsystem/emoticons/emot-bravo2.gif"" title=""wordjo"">
	<li class=""smilie"">
		<div class=""text"">:butt:</div>
		<img alt="""" src=""http://i.somethingawful.com/forumsystem/emoticons/emot-butt.gif"" title=""butt"">
	<li class=""smilie"">
		<div class=""text"">:catholic:</div>
		<img alt="""" src=""http://i.somethingawful.com/forumsystem/emoticons/emot-catholic.gif"" title=""A Pope culture icon."">
	<li class=""smilie"">
		<div class=""text"">:cawg:</div>
		<img alt="""" src=""http://i.somethingawful.com/forumsystem/emoticons/emot-cawg.gif"" title=""Cackling Aloud With Gusto"">
	<li class=""smilie"">
		<div class=""text"">:cb:</div>
		<img alt="""" src=""http://fi.somethingawful.com/images/smilies/emot-clownballoon.gif"" title=""Clownballoon is coming...!"">
	<li class=""smilie"">
		<div class=""text"">:cheeky:</div>
		<img alt="""" src=""http://fi.somethingawful.com/safs/smilies/0/d/cheeky.001.gif"" title=""smilie with a protruding tongue"">
	<li class=""smilie"">
		<div class=""text"">:cheers:</div>
		<img alt="""" src=""http://i.somethingawful.com/forumsystem/emoticons/emot-cheers.gif"" title=""Here's to us!"">
	<li class=""smilie"">
		<div class=""text"">:chef:</div>
		<img alt="""" src=""http://i.somethingawful.com/forumsystem/emoticons/emot-chef.gif"" title=""I am the chef!"">
	<li class=""smilie"">
		<div class=""text"">:choco:</div>
		<img alt="""" src=""http://fi.somethingawful.com/images/smilies/choco.gif"" title=""Choo!"">
	<li class=""smilie"">
		<div class=""text"">:clint:</div>
		<img alt="""" src=""http://i.somethingawful.com/forumsystem/emoticons/emot-clint.gif"" title=""i'm a cowboy baby"">
	<li class=""smilie"">
		<div class=""text"">:coffee:</div>
		<img alt="""" src=""http://i.somethingawful.com/forumsystem/emoticons/emot-coffee.gif"" title=""best part of waking up!"">
	<li class=""smilie"">
		<div class=""text"">:colbert:</div>
		<img alt="""" src=""http://i.somethingawful.com/forumsystem/emoticons/emot-colbert.gif"" title=""crossarms"">
	<li class=""smilie"">
		<div class=""text"">:comeback:</div>
		<img alt="""" src=""http://i.somethingawful.com/forumsystem/emoticons/emot-comeback.gif"" title=""They're coming back!"">
	<li class=""smilie"">
		<div class=""text"">:commissar:</div>
		<img alt="""" src=""http://i.somethingawful.com/forumsystem/emoticons/emot-commissar.gif"" title=""Summary Execution"">
	<li class=""smilie"">
		<div class=""text"">:confused:</div>
		<img alt="""" src=""http://fi.somethingawful.com/images/smilies/confused.gif"" title=""confused"">
	<li class=""smilie"">
		<div class=""text"">:cool:</div>
		<img alt="""" src=""http://fi.somethingawful.com/images/smilies/cool.gif"" title=""cool"">
	<li class=""smilie"">
		<div class=""text"">:cop:</div>
		<img alt="""" src=""http://i.somethingawful.com/forumsystem/emoticons/emot-cop.gif"" title=""I'm a cop you idiot!"">
	<li class=""smilie"">
		<div class=""text"">:crossarms:</div>
		<img alt="""" src=""http://i.somethingawful.com/forumsystem/emoticons/emot-crossarms.gif"" title=""colbert"">
	<li class=""smilie"">
		<div class=""text"">:cry:</div>
		<img alt="""" src=""http://fi.somethingawful.com/images/smilies/emot-crying.gif"" title=""Some kind of zombie chewing tobacco and crying I guess"">
	<li class=""smilie"">
		<div class=""text"">:cthulhu:</div>
		<img alt="""" src=""http://fi.somethingawful.com/images/smilies/emot-cthulhu.gif"" title=""Cthulhu"">
	<li class=""smilie"">
		<div class=""text"">:D</div>
		<img alt="""" src=""http://fi.somethingawful.com/images/smilies/biggrin.gif"" title=""big grin"">
	<li class=""smilie"">
		<div class=""text"">:dance:</div>
		<img alt="""" src=""http://i.somethingawful.com/images/emot-dance.gif"" title=""Dance"">
	<li class=""smilie"">
		<div class=""text"">:devil:</div>
		<img alt="""" src=""http://i.somethingawful.com/forumsystem/emoticons/emot-devil.gif"" title=""Demonology 101"">
	<li class=""smilie"">
		<div class=""text"">:dings:</div>
		<img alt="""" src=""http://i.somethingawful.com/forumsystem/emoticons/emot-dings.gif"" title=""Dings"">
	<li class=""smilie"">
		<div class=""text"">:doh:</div>
		<img alt="""" src=""http://i.somethingawful.com/forumsystem/emoticons/emot-doh.gif"" title=""D'oh!"">
	<li class=""smilie"">
		<div class=""text"">:downs:</div>
		<img alt="""" src=""http://i.somethingawful.com/forumsystem/emoticons/emot-downs.gif"" title=""Yaaaay!  Happy happy yay!"">
	<li class=""smilie"">
		<div class=""text"">:downsgun:</div>
		<img alt="""" src=""http://i.somethingawful.com/forumsystem/emoticons/emot-downsgun.gif"" title=""Downs botches suicide"">
	<li class=""smilie"">
		<div class=""text"">:downswords:</div>
		<img alt="""" src=""http://i.somethingawful.com/forumsystem/emoticons/emot-downswords.gif"" title=""listen to me :("">
	<li class=""smilie"">
		<div class=""text"">:drac:</div>
		<img alt="""" src=""http://i.somethingawful.com/forumsystem/emoticons/emot-drac.gif"" title=""Dracula is coming"">
	<li class=""smilie"">
		<div class=""text"">:eek:</div>
		<img alt="""" src=""http://fi.somethingawful.com/images/smilies/emot-eek.gif"" title=""Eek"">
	<li class=""smilie"">
		<div class=""text"">:emo:</div>
		<img alt="""" src=""http://fi.somethingawful.com/images/smilies/emot-emo.gif"" title=""Emo"">
	<li class=""smilie"">
		<div class=""text"">:eng101:</div>
		<img alt="""" src=""http://fi.somethingawful.com/images/smilies/emot-eng101.gif"" title=""I don't know"">
	<li class=""smilie"">
		<div class=""text"">:eng99:</div>
		<img alt="""" src=""http://i.somethingawful.com/forumsystem/emoticons/emot-eng99.gif"" title=""Sad eng101"">
	<li class=""smilie"">
		<div class=""text"">:engleft:</div>
		<img alt="""" src=""http://i.somethingawful.com/forumsystem/emoticons/emot-engleft.gif"" title=""Eng Left"">
	<li class=""smilie"">
		<div class=""text"">:eyepop:</div>
		<img alt="""" src=""http://fi.somethingawful.com/safs/smilies/0/a/eyepop.001.gif"" title="":eyepop:"">
	<li class=""smilie"">
		<div class=""text"">:f5:</div>
		<img alt="""" src=""http://i.somethingawful.com/forumsystem/emoticons/emot-f5.gif"" title=""pres butan to go"">
	<li class=""smilie"">
		<div class=""text"">:f5h:</div>
		<img alt="""" src=""http://i.somethingawful.com/forumsystem/emoticons/emot-f5h.gif"" title=""F5 Hand"">
	<li class=""smilie"">
		<div class=""text"">:fap:</div>
		<img alt="""" src=""http://i.somethingawful.com/forumsystem/emoticons/emot-fappery.gif"" title=""Fapping off"">
	<li class=""smilie"">
		<div class=""text"">:fh:</div>
		<img alt="""" src=""http://i.somethingawful.com/forumsystem/emoticons/emot-fh.gif"" title=""JERK JERK JERK JERK"">
	<li class=""smilie"">
		<div class=""text"">:flame:</div>
		<img alt="""" src=""http://i.somethingawful.com/forumsystem/emoticons/emot-flame.gif"" title=""Mr. V gets roasted"">
	<li class=""smilie"">
		<div class=""text"">:gay:</div>
		<img alt="""" src=""http://i.somethingawful.com/forumsystem/emoticons/emot-gay.gif"" title=""not straight"">
	<li class=""smilie"">
		<div class=""text"">:geno:</div>
		<img alt="""" src=""http://fi.somethingawful.com/images/smilies/emot-geno.gif"" title=""The Path is Grey"">
	<li class=""smilie"">
		<div class=""text"">:ghost:</div>
		<img alt="""" src=""http://i.somethingawful.com/forumsystem/emoticons/emot-ghost.gif"" title=""Boo"">
	<li class=""smilie"">
		<div class=""text"">:gibs:</div>
		<img alt="""" src=""http://i.somethingawful.com/forumsystem/emoticons/emot-gibs.gif"" title=""Gibs"">
	<li class=""smilie"">
		<div class=""text"">:glomp:</div>
		<img alt="""" src=""http://i.somethingawful.com/forumsystem/emoticons/emot-glomp.gif"" title=""BLATANTLY STOLEN FROM DEVIANTART"">
	<li class=""smilie"">
		<div class=""text"">:golfclap:</div>
		<img alt="""" src=""http://i.somethingawful.com/forumsystem/emoticons/emot-golfclap.gif"" title=""nice job my nigga"">
	<li class=""smilie"">
		<div class=""text"">:gonk:</div>
		<img alt="""" src=""http://i.somethingawful.com/forumsystem/emoticons/emot-gonk.gif"" title=""GONK"">
	<li class=""smilie"">
		<div class=""text"">:greatgift:</div>
		<img alt="""" src=""http://i.somethingawful.com/forumsystem/emoticons/emot-greatgift.gif"" title=""great gifts for dads and grads"">
	<li class=""smilie"">
		<div class=""text"">:greenangel:</div>
		<img alt="""" src=""http://i.somethingawful.com/u/garbageday/2014/greenangel.gif"" title=""Mr. Green Water Goes to Heaven."">
	<li class=""smilie"">
		<div class=""text"">:haw:</div>
		<img alt="""" src=""http://i.somethingawful.com/forumsystem/emoticons/emot-haw.gif"" title=""Haw haw haw"">
	<li class=""smilie"">
		<div class=""text"">:hawaaaafap:</div>
		<img alt="""" src=""http://i.somethingawful.com/forumsystem/emoticons/emot-hawaaaafap.gif"" title=""tha lowride bitch"">
	<li class=""smilie"">
		<div class=""text"">:hehe:</div>
		<img alt="""" src=""http://i.somethingawful.com/forumsystem/emoticons/emot-hehe.gif"" title=""Heh."">
	<li class=""smilie"">
		<div class=""text"">:henget:</div>
		<img alt="""" src=""http://i.somethingawful.com/u/garbageday/2014/henget.gif"" title=""Mister Green Water, Chicken Catcher."">
	<li class=""smilie"">
		<div class=""text"">:heysexy:</div>
		<img alt="""" src=""http://fi.somethingawful.com/safs/smilies/2/6/heysexy.001.gif"" title=""Hey sexy"">
	<li class=""smilie"">
		<div class=""text"">:hf:</div>
		<img alt="""" src=""http://i.somethingawful.com/forumsystem/emoticons/emot-hf.gif"" title=""You can hi-five stuff now"">
	<li class=""smilie"">
		<div class=""text"">:hfive:</div>
		<img alt="""" src=""http://i.somethingawful.com/forumsystem/emoticons/emot-hfive.gif"" title=""Hi five it up nigga"">
	<li class=""smilie"">
		<div class=""text"">:hist101:</div>
		<img alt="""" src=""http://i.somethingawful.com/forumsystem/emoticons/emot-hist101.gif"" title=""S P Q R"">
	<li class=""smilie"">
		<div class=""text"">:holy:</div>
		<img alt="""" src=""http://i.somethingawful.com/forumsystem/emoticons/emot-holy.gif"" title=""holy dance"">
	<li class=""smilie"">
		<div class=""text"">:huh:</div>
		<img alt="""" src=""http://i.somethingawful.com/forumsystem/emoticons/emot-huh.gif"" title=""huh"">
	<li class=""smilie"">
		<div class=""text"">:hydrogen:</div>
		<img alt="""" src=""http://i.somethingawful.com/forumsystem/emoticons/emot-hydrogen.gif"" title=""Hydrogen"">
	<li class=""smilie"">
		<div class=""text"">:j:</div>
		<img alt="""" src=""http://i.somethingawful.com/forumsystem/emoticons/emot-j.gif"" title=""j is for Jansie"">
	<li class=""smilie"">
		<div class=""text"">:jerkbag:</div>
		<img alt="""" src=""http://i.somethingawful.com/forumsystem/emoticons/emot-jerkbag.gif"" title=""god damn your post sucks"">
	<li class=""smilie"">
		<div class=""text"">:jerky:</div>
		<img alt="""" src=""http://fi.somethingawful.com/images/smilies/emote-louisgod2.gif"" title=""Jerky"">
	<li class=""smilie"">
		<div class=""text"">:jewish:</div>
		<img alt="""" src=""http://i.somethingawful.com/forumsystem/emoticons/emot-jewish.gif"" title=""Orthodox Jew with Torah"">
	<li class=""smilie"">
		<div class=""text"">:jihad:</div>
		<img alt="""" src=""http://fi.somethingawful.com/images/smilies/emot-jihad.gif"" title=""ALLAH ACKBAR!!!1"">
	<li class=""smilie"">
		<div class=""text"">:keke:</div>
		<img alt="""" src=""http://fi.somethingawful.com/images/smilies/emot-keke.gif"" title=""kekekekekekeke"">
	<li class=""smilie"">
		<div class=""text"">:kimchi:</div>
		<img alt="""" src=""http://fi.somethingawful.com/images/smilies/kimchi.gif"" title=""Kimchi"">
	<li class=""smilie"">
		<div class=""text"">:mad:</div>
		<img alt="""" src=""http://fi.somethingawful.com/images/smilies/mad.gif"" title=""mad"">
	<li class=""smilie"">
		<div class=""text"">:megadeath:</div>
		<img alt="""" src=""http://fi.somethingawful.com/images/smilies/smilie-het.gif"" title=""Megadeath"">
	<li class=""smilie"">
		<div class=""text"">:melter:</div>
		<img alt="""" src=""http://i.somethingawful.com/u/garbageday/2014/melter.gif"" title=""Melter"">
	<li class=""smilie"">
		<div class=""text"">:mmmhmm:</div>
		<img alt="""" src=""http://fi.somethingawful.com/smilies/mmmhmm.gif"" title=""MMMM HMM..."">
	<li class=""smilie"">
		<div class=""text"">:monocle:</div>
		<img alt="""" src=""http://fi.somethingawful.com/images/smilies/emot-monocle.gif"" title=""Oh my!  What a saucy lad!"">
	<li class=""smilie"">
		<div class=""text"">:morning:</div>
		<img alt="""" src=""http://fi.somethingawful.com/images/smilies/coffee.gif"" title=""morning coffee"">
	<li class=""smilie"">
		<div class=""text"">:munch:</div>
		<img alt="""" src=""http://i.somethingawful.com/forumsystem/emoticons/emot-munch.gif"" title=""this is gonna be good"">
	<li class=""smilie"">
		<div class=""text"">:neckbeard:</div>
		<img alt="""" src=""http://i.somethingawful.com/forumsystem/emoticons/emot-neckbeard.gif"" title=""neckbeard emot u say?"">
	<li class=""smilie"">
		<div class=""text"">:newfap:</div>
		<img alt="""" src=""http://fi.somethingawful.com/safs/smilies/e/d/newfap.001.gif"" title=""Fap fap fap fap fap fap fap!"">
	<li class=""smilie"">
		<div class=""text"">:newlol:</div>
		<img alt="""" src=""http://fi.somethingawful.com/safs/smilies/e/d/newlol.001.gif"" title=""LOL"">
	<li class=""smilie"">
		<div class=""text"">:niggly:</div>
		<img alt="""" src=""http://i.somethingawful.com/forumsystem/emoticons/emot-niggly.gif"" title=""Nigglypuff rules."">
	<li class=""smilie"">
		<div class=""text"">:ninja:</div>
		<img alt="""" src=""http://i.somethingawful.com/forumsystem/emoticons/emot-ninja.gif"" title=""Ninja"">
	<li class=""smilie"">
		<div class=""text"">:nyd:</div>
		<img alt="""" src=""http://fi.somethingawful.com/images/smilies/emot-nyd.gif"" title=""Oh no you didn't"">
	<li class=""smilie"">
		<div class=""text"">:o:</div>
		<img alt="""" src=""http://fi.somethingawful.com/images/smilies/redface.gif"" title=""embarrasment"">
	<li class=""smilie"">
		<div class=""text"">:ohdear:</div>
		<img alt="""" src=""http://i.somethingawful.com/forumsystem/emoticons/emot-ohdear.png"" title=""oh no lidge"">
	<li class=""smilie"">
		<div class=""text"">:ohdearsass:</div>
		<img alt="""" src=""http://fi.somethingawful.com/safs/smilies/c/3/ohdearsass.001.png"" title=""Worried Santa"">
	<li class=""smilie"">
		<div class=""text"">:pedo:</div>
		<img alt="""" src=""http://i.somethingawful.com/forumsystem/emoticons/emot-pedo.gif"" title=""Come here little kiddie"">
	<li class=""smilie"">
		<div class=""text"">:pervert:</div>
		<img alt="""" src=""http://i.somethingawful.com/forumsystem/emoticons/emot-pervert.gif"" title=""Comin' to get ya"">
	<li class=""smilie"">
		<div class=""text"">:pirate:</div>
		<img alt="""" src=""http://fi.somethingawful.com/images/smilies/emot-pirate.gif"" title=""Pirate"">
	<li class=""smilie"">
		<div class=""text"">:pray:</div>
		<img alt="""" src=""http://i.somethingawful.com/forumsystem/emoticons/emot-pray.gif"" title=""all old folks go 2 heaven"">
	<li class=""smilie"">
		<div class=""text"">:pseudo:</div>
		<img alt="""" src=""http://i.somethingawful.com/forumsystem/emoticons/emot-pseudo.gif"" title=""Pseudo science"">
	<li class=""smilie"">
		<div class=""text"">:raise:</div>
		<img alt="""" src=""http://i.somethingawful.com/forumsystem/emoticons/emot-raise.gif"" title=""Raising Eyebrow"">
	<li class=""smilie"">
		<div class=""text"">:rant:</div>
		<img alt="""" src=""http://i.somethingawful.com/forumsystem/emoticons/emot-rant.gif"" title=""angry smiley ranting GRRR"">
	<li class=""smilie"">
		<div class=""text"">:reject:</div>
		<img alt="""" src=""http://i.somethingawful.com/forumsystem/emoticons/emot-reject.gif"" title=""Disapproving obese smiley"">
	<li class=""smilie"">
		<div class=""text"">:respek:</div>
		<img alt="""" src=""http://i.somethingawful.com/forumsystem/emoticons/emot-respek.gif"" title=""Respek"">
	<li class=""smilie"">
		<div class=""text"">:rimshot:</div>
		<img alt="""" src=""http://i.somethingawful.com/forumsystem/emoticons/emot-rimshot.gif"" title=""Rimshot"">
	<li class=""smilie"">
		<div class=""text"">:roboluv:</div>
		<img alt="""" src=""http://i.somethingawful.com/forumsystem/emoticons/emot-roboluv.gif"" title=""miss u Dono"">
	<li class=""smilie"">
		<div class=""text"">:rock:</div>
		<img alt="""" src=""http://fi.somethingawful.com/images/smilies/emot-rock.gif"" title=""Rock"">
	<li class=""smilie"">
		<div class=""text"">:roflolmao:</div>
		<img alt="""" src=""http://i.somethingawful.com/forumsystem/emoticons/emot-roflolmao.gif"" title=""roflolmao"">
	<li class=""smilie"">
		<div class=""text"">:rolleye:</div>
		<img alt="""" src=""http://fi.somethingawful.com/images/smilies/emot-rolleye.gif"" title=""Rolleye"">
	<li class=""smilie"">
		<div class=""text"">:rolleyes:</div>
		<img alt="""" src=""http://fi.somethingawful.com/images/smilies/rolleyes.gif"" title=""roll eyes (sarcastic)"">
	<li class=""smilie"">
		<div class=""text"">:saddowns:</div>
		<img alt="""" src=""http://i.somethingawful.com/forumsystem/emoticons/emot-saddowns.gif"" title=""Awww. Booo."">
	<li class=""smilie"">
		<div class=""text"">:sassargh:</div>
		<img alt="""" src=""http://fi.somethingawful.com/safs/smilies/0/7/sassargh.001.gif"" title=""coal again?!"">
	<li class=""smilie"">
		<div class=""text"">:science:</div>
		<img alt="""" src=""http://i.somethingawful.com/forumsystem/emoticons/emot-science.gif"" title=""For Science!"">
	<li class=""smilie"">
		<div class=""text"">:shlick:</div>
		<img alt="""" src=""http://i.somethingawful.com/forumsystem/emoticons/emot-shlick.gif"" title=""shlick"">
	<li class=""smilie"">
		<div class=""text"">:shobon:</div>
		<img alt="""" src=""http://i.somethingawful.com/forumsystem/emoticons/emot-shobon.gif"" title=""Shobon... (deflated)"">
	<li class=""smilie"">
		<div class=""text"">:shrug:</div>
		<img alt="""" src=""http://fi.somethingawful.com/safs/smilies/4/1/shrug.001.gif"" title=""shrug"">
	<li class=""smilie"">
		<div class=""text"">:sigh:</div>
		<img alt="""" src=""http://i.somethingawful.com/forumsystem/emoticons/emot-sigh.gif"" title=""oh sigh"">
	<li class=""smilie"">
		<div class=""text"">:silent:</div>
		<img alt="""" src=""http://i.somethingawful.com/forumsystem/emoticons/emot-silent.gif"" title=""Nothing clever to say"">
	<li class=""smilie"">
		<div class=""text"">:siren:</div>
		<img alt="""" src=""http://fi.somethingawful.com/images/smilies/emot-siren.gif"" title=""Breaking News Developing..."">
	<li class=""smilie"">
		<div class=""text"">:smuggo:</div>
		<img alt="""" src=""http://i.somethingawful.com/forumsystem/emoticons/emot-smuggo.gif"" title=""Smuggo"">
	<li class=""smilie"">
		<div class=""text"">:smugmrgw:</div>
		<img alt="""" src=""http://i.somethingawful.com/u/garbageday/2014/smugmrgw.png"" title=""Smug Variation of Mr Green Water."">
	<li class=""smilie"">
		<div class=""text"">:ssh:</div>
		<img alt="""" src=""http://i.somethingawful.com/forumsystem/emoticons/emot-ssh.gif"" title=""aardvarko"">
	<li class=""smilie"">
		<div class=""text"">:ssj:</div>
		<img alt="""" src=""http://fi.somethingawful.com/images/smilies/emot-ssj.gif"" title=""ssj"">
	<li class=""smilie"">
		<div class=""text"">:stare:</div>
		<img alt="""" src=""http://i.somethingawful.com/forumsystem/emoticons/emot-stare.gif"" title=""Astonished stare"">
	<li class=""smilie"">
		<div class=""text"">:stonk:</div>
		<img alt="""" src=""http://fi.somethingawful.com/safs/smilies/1/9/stonk.001.gif"" title=""oh fuck no!"">
	<li class=""smilie"">
		<div class=""text"">:suicide:</div>
		<img alt="""" src=""http://i.somethingawful.com/forumsystem/emoticons/emot-suicide.gif"" title=""Suicide is the best side."">
	<li class=""smilie"">
		<div class=""text"">:sun:</div>
		<img alt="""" src=""http://i.somethingawful.com/forumsystem/emoticons/emot-sun.gif"" title=""A beaming sun"">
	<li class=""smilie"">
		<div class=""text"">:supaburn:</div>
		<img alt="""" src=""http://i.somethingawful.com/forumsystem/emoticons/emot-supaburn.gif"" title=""o snap that burn was fire"">
	<li class=""smilie"">
		<div class=""text"">:sweatdrop:</div>
		<img alt="""" src=""http://i.somethingawful.com/forumsystem/emoticons/emot-sweatdrop.gif"" title=""oh my i am embarassed"">
	<li class=""smilie"">
		<div class=""text"">:swoon:</div>
		<img alt="""" src=""http://i.somethingawful.com/forumsystem/emoticons/emot-swoon.gif"" title=""Love eyes"">
	<li class=""smilie"">
		<div class=""text"">:sympathy:</div>
		<img alt="""" src=""http://i.somethingawful.com/forumsystem/emoticons/emot-sympathy.gif"" title=""It'll be ok :("">
	<li class=""smilie"">
		<div class=""text"">:tinfoil:</div>
		<img alt="""" src=""http://i.somethingawful.com/forumsystem/emoticons/emot-tinfoil.gif"" title=""Tinfoil hat"">
	<li class=""smilie"">
		<div class=""text"">:tipshat:</div>
		<img alt="""" src=""http://i.somethingawful.com/forumsystem/emoticons/emot-tiphat.gif"" title=""Tip of the Hat"">
	<li class=""smilie"">
		<div class=""text"">:tizzy:</div>
		<img alt="""" src=""http://i.somethingawful.com/forumsystem/emoticons/emot-tizzy.gif"" title=""twistmaster tizz"">
	<li class=""smilie"">
		<div class=""text"">:toot:</div>
		<img alt="""" src=""http://i.somethingawful.com/forumsystem/emoticons/emot-toot.gif"" title=""Toots"">
	<li class=""smilie"">
		<div class=""text"">:twisted:</div>
		<img alt="""" src=""http://i.somethingawful.com/forumsystem/emoticons/emot-twisted.gif"" title=""Twisted"">
	<li class=""smilie"">
		<div class=""text"">:v:</div>
		<img alt="""" src=""http://fi.somethingawful.com/images/smilies/emot-v.gif"" title=""v"">
	<li class=""smilie"">
		<div class=""text"">:vince:</div>
		<img alt="""" src=""http://i.somethingawful.com/u/garbageday/2014/vince.gif"" title=""Vince McMahon.GIF, made by Machai"">
	<li class=""smilie"">
		<div class=""text"">:what:</div>
		<img alt="""" src=""http://fi.somethingawful.com/images/smilies/emot-what.gif"" title=""what"">
	<li class=""smilie"">
		<div class=""text"">:whip:</div>
		<img alt="""" src=""http://i.somethingawful.com/forumsystem/emoticons/emot-whip.gif"" title=""Whip it good"">
	<li class=""smilie"">
		<div class=""text"">:witch:</div>
		<img alt="""" src=""http://i.somethingawful.com/images/emot-witch.gif"" title=""Witch Hunt!!!"">
	<li class=""smilie"">
		<div class=""text"">:woop:</div>
		<img alt="""" src=""http://i.somethingawful.com/forumsystem/emoticons/emot-woop.gif"" title=""citizen slang bro"">
	<li class=""smilie"">
		<div class=""text"">:words:</div>
		<img alt="""" src=""http://i.somethingawful.com/forumsystem/emoticons/emot-words.gif"" title=""a shovel (for digging)"">
	<li class=""smilie"">
		<div class=""text"">:worship:</div>
		<img alt="""" src=""http://i.somethingawful.com/forumsystem/emoticons/emot-worship.gif"" title=""bow"">
	<li class=""smilie"">
		<div class=""text"">:wth:</div>
		<img alt="""" src=""http://i.somethingawful.com/forumsystem/emoticons/emot-wth.gif"" title=""what the hell?"">
	<li class=""smilie"">
		<div class=""text"">:xd:</div>
		<img alt="""" src=""http://fi.somethingawful.com/images/smilies/emot-xd.gif"" title=""XD"">
	<li class=""smilie"">
		<div class=""text"">:yarr:</div>
		<img alt="""" src=""http://fi.somethingawful.com/images/smilies/emot-yarr.gif"" title=""Yarr!"">
	<li class=""smilie"">
		<div class=""text"">:yotj:</div>
		<img alt="""" src=""http://fi.somethingawful.com/safs/smilies/b/6/yotj.001.gif"" title=""YOTJ"">
	<li class=""smilie"">
		<div class=""text"">:yum:</div>
		<img alt="""" src=""http://fi.somethingawful.com/safs/smilies/0/9/yum.001.gif"" title=""cereal!"">
	<li class=""smilie"">
		<div class=""text"">:zombie:</div>
		<img alt="""" src=""http://i.somethingawful.com/forumsystem/emoticons/emot-zombie.gif"" title=""Zombie"">
	<li class=""smilie"">
		<div class=""text"">:zoro:</div>
		<img alt="""" src=""http://i.somethingawful.com/forumsystem/emoticons/emot-zoro.gif"" title=""Zoro's Badass moment"">
	<li class=""smilie"">
		<div class=""text"">;)</div>
		<img alt="""" src=""http://fi.somethingawful.com/images/smilies/wink.gif"" title=""wink"">
	<li class=""smilie"">
		<div class=""text"">;-*</div>
		<img alt="""" src=""http://i.somethingawful.com/mjolnir/images/livestock~01-14-04-whore.gif"" title=""Oh you lustful devil you"">
</ul>

<h3>Mostly text</h3>
<ul class=""smilie_group"">
	<li class=""smilie"">
		<div class=""text"">:10bux:</div>
		<img alt="""" src=""http://fi.somethingawful.com/images/smilies/emot-10bux.gif"" title=""Hope u got 10 bux"">
	<li class=""smilie"">
		<div class=""text"">:20bux:</div>
		<img alt="""" src=""http://i.somethingawful.com/forumsystem/emoticons/emot-20bux.gif"" title=""This cost 20 bux"">
	<li class=""smilie"">
		<div class=""text"">:69snypa:</div>
		<img alt="""" src=""http://fi.somethingawful.com/images/smilies/69snypa.gif"" title=""Pg 69 Snypa"">
	<li class=""smilie"">
		<div class=""text"">:banme:</div>
		<img alt="""" src=""http://i.somethingawful.com/forumsystem/emoticons/emot-banme.gif"" title=""banme"">
	<li class=""smilie"">
		<div class=""text"">:bunt:</div>
		<img alt="""" src=""http://fi.somethingawful.com/safs/smilies/8/9/bunt.001.gif"" title=""Bunt"">
	<li class=""smilie"">
		<div class=""text"">:byewhore:</div>
		<img alt="""" src=""http://fi.somethingawful.com/images/smilies/emot-byewhore.gif"" title=""Bye bye, whore!"">
	<li class=""smilie"">
		<div class=""text"">:byob:</div>
		<img alt="""" src=""http://i.somethingawful.com/forumsystem/emoticons/emot-byob.gif"" title=""BYOB Bitches"">
	<li class=""smilie"">
		<div class=""text"">:cadfan:</div>
		<img alt="""" src=""http://fi.somethingawful.com/safs/smilies/f/f/cadfan.001.gif"" title=""We are the CAD [Fans]"">
	<li class=""smilie"">
		<div class=""text"">:clegg:</div>
		<img alt="""" src=""http://fi.somethingawful.com/safs/smilies/2/7/clegg.001.gif"" title=""UK Deputy PM's belief system."">
	<li class=""smilie"">
		<div class=""text"">:cmon:</div>
		<img alt="""" src=""http://i.somethingawful.com/forumsystem/emoticons/emot-cmon.gif"" title=""C'mon Son!"">
	<li class=""smilie"">
		<div class=""text"">:coupons:</div>
		<img alt="""" src=""http://i.somethingawful.com/forumsystem/emoticons/emot-coupons.gif"" title=""How to crash the forums"">
	<li class=""smilie"">
		<div class=""text"">:cumpolice:</div>
		<img alt="""" src=""http://fi.somethingawful.com/images/smilies/cumpolice.gif"" title=""Reverse Sexism"">
	<li class=""smilie"">
		<div class=""text"">:damn:</div>
		<img alt="""" src=""http://i.somethingawful.com/forumsystem/emoticons/emot-damn.gif"" title=""......DAMN!"">
	<li class=""smilie"">
		<div class=""text"">:darksouls:</div>
		<img alt="""" src=""http://fi.somethingawful.com/safs/smilies/b/c/darksouls.001.gif"" title=""fucking dark souls"">
	<li class=""smilie"">
		<div class=""text"">:dealwithit:</div>
		<img alt="""" src=""http://i.somethingawful.com/forumsystem/emoticons/emot-dealwithit.jpg"" title=""Don't be a drama queen"">
	<li class=""smilie"">
		<div class=""text"">:dice:</div>
		<img alt="""" src=""http://fi.somethingawful.com/safs/smilies/2/e/dice.001.gif"" title=""Battlefield more like Bugfilled!"">
	<li class=""smilie"">
		<div class=""text"">:downsowned:</div>
		<img alt="""" src=""http://i.somethingawful.com/forumsystem/emoticons/emot-downsowned.gif"" title=""Downs owned"">
	<li class=""smilie"">
		<div class=""text"">:effort:</div>
		<img alt="""" src=""http://i.somethingawful.com/forumsystem/emoticons/emot-effort.gif"" title=""Ugh, that button..."">
	<li class=""smilie"">
		<div class=""text"">:feelsgood:</div>
		<img alt="""" src=""http://fi.somethingawful.com/safs/smilies/3/1/feelsgood.001.png"" title=""Feels Good Man"">
	<li class=""smilie"">
		<div class=""text"">:filez:</div>
		<img alt="""" src=""http://i.somethingawful.com/forumsystem/emoticons/emot-filez.gif"" title=""FLIEZ"">
	<li class=""smilie"">
		<div class=""text"">:firstpost:</div>
		<img alt="""" src=""http://i.somethingawful.com/forumsystem/emoticons/emot-firstpost.gif"" title=""First Post"">
	<li class=""smilie"">
		<div class=""text"">:frogon:</div>
		<img alt="""" src=""http://fi.somethingawful.com/safs/smilies/a/e/frogon.001.png"" title=""please vacate the premises"">
	<li class=""smilie"">
		<div class=""text"">:frogout:</div>
		<img alt="""" src=""http://i.somethingawful.com/forumsystem/emoticons/emot-frogout.gif"" title=""a frog saying &quot;get out&quot;"">
	<li class=""smilie"">
		<div class=""text"">:ftbrg:</div>
		<img alt="""" src=""http://fi.somethingawful.com/customtitles/emot-ftbrg.gif"" title=""Fuck that butt real good"">
	<li class=""smilie"">
		<div class=""text"">:gb2byob:</div>
		<img alt="""" src=""http://i.somethingawful.com/forumsystem/emoticons/emot-gb2byob.gif"" title=""go bakc 2 huuurrrrrr"">
	<li class=""smilie"">
		<div class=""text"">:gb2fyad:</div>
		<img alt="""" src=""http://fi.somethingawful.com/images/smilies/emot-gb2fyad.gif"" title=""Go back to FYAD"">
	<li class=""smilie"">
		<div class=""text"">:gb2gbs:</div>
		<img alt="""" src=""http://fi.somethingawful.com/images/smilies/emot-gb2gbs.gif"" title=""Go back to GBS"">
	<li class=""smilie"">
		<div class=""text"">:gb2hd2k:</div>
		<img alt="""" src=""http://i.somethingawful.com/forumsystem/emoticons/emot-gb2hd2k.gif"" title=""Damn you, Helldump!"">
	<li class=""smilie"">
		<div class=""text"">:getout:</div>
		<img alt="""" src=""http://i.somethingawful.com/forumsystem/emoticons/emot-getout.png"" title=""GET OUT"">
	<li class=""smilie"">
		<div class=""text"">:godwin:</div>
		<img alt="""" src=""http://i.somethingawful.com/forumsystem/emoticons/emot-godwin.gif"" title=""Hitler Reference!"">
	<li class=""smilie"">
		<div class=""text"">:goof:</div>
		<img alt="""" src=""http://fi.somethingawful.com/images/smilies/emot-goof.gif"" title=""Get out of FYAD"">
	<li class=""smilie"">
		<div class=""text"">:hurr:</div>
		<img alt="""" src=""http://i.somethingawful.com/forumsystem/emoticons/emot-hurr.gif"" title=""what does this do?"">
	<li class=""smilie"">
		<div class=""text"">:iceburn:</div>
		<img alt="""" src=""http://i.somethingawful.com/forumsystem/emoticons/emot-iceburn.gif"" title=""damn you just told son"">
	<li class=""smilie"">
		<div class=""text"">:iia:</div>
		<img alt="""" src=""http://i.somethingawful.com/forumsystem/emoticons/emot-iia.png"" title=""It it awesome!"">
	<li class=""smilie"">
		<div class=""text"">:iiam:</div>
		<img alt="""" src=""http://i.somethingawful.com/forumsystem/emoticons/emot-iiam.gif"" title=""Mysterious happenings!"">
	<li class=""smilie"">
		<div class=""text"">:iiapa:</div>
		<img alt="""" src=""http://fi.somethingawful.com/safs/smilies/5/5/iiapa.001.png"" title=""It is a poo analogy"">
	<li class=""smilie"">
		<div class=""text"">:justpost:</div>
		<img alt="""" src=""http://fi.somethingawful.com/safs/smilies/9/e/justpost.001.gif"" title=""Just fucking post it already!"">
	<li class=""smilie"">
		<div class=""text"">:laffo:</div>
		<img alt="""" src=""http://i.somethingawful.com/forumsystem/emoticons/emot-laffo.gif"" title=""LAFFO"">
	<li class=""smilie"">
		<div class=""text"">:lol:</div>
		<img alt="""" src=""http://fi.somethingawful.com/images/smilies/emot-lol.gif"" title=""lolololerlerlslzollin'"">
	<li class=""smilie"">
		<div class=""text"">:m10:</div>
		<img alt="""" src=""http://i.somethingawful.com/forumsystem/emoticons/emot-m10.gif"" title=""it says mac-10, cool"">
	<li class=""smilie"">
		<div class=""text"">:master:</div>
		<img alt="""" src=""http://i.somethingawful.com/forumsystem/emoticons/emot-master.gif"" title=""masterstroke"">
	<li class=""smilie"">
		<div class=""text"">:milkie:</div>
		<img alt="""" src=""http://fi.somethingawful.com/safs/smilies/4/f/milkie.001.gif"" title=""da Moose is loose"">
	<li class=""smilie"">
		<div class=""text"">:mitt:</div>
		<img alt="""" src=""http://fi.somethingawful.com/safs/smilies/7/3/mitt.001.gif"" title=""Run pander.exe"">
	<li class=""smilie"">
		<div class=""text"">:mordin:</div>
		<img alt="""" src=""http://i.somethingawful.com/forumsystem/emoticons/emot-mordin.gif"" title=""A Scientist Salarian"">
	<li class=""smilie"">
		<div class=""text"">:moreevil:</div>
		<img alt="""" src=""http://fi.somethingawful.com/safs/smilies/0/f/moreevil.001.gif"" title=""evil for evil's sake"">
	<li class=""smilie"">
		<div class=""text"">:ms:</div>
		<img alt="""" src=""http://i.somethingawful.com/forumsystem/emoticons/emot-ms.gif"" title=""Mystery Solved"">
	<li class=""smilie"">
		<div class=""text"">:nattyburn:</div>
		<img alt="""" src=""http://i.somethingawful.com/forumsystem/emoticons/emot-nattyburn.gif"" title=""NATTY ICE BURN fbgm"">
	<li class=""smilie"">
		<div class=""text"">:nms:</div>
		<img alt="""" src=""http://i.somethingawful.com/forumsystem/emoticons/emot-nms.gif"" title=""Not mind safe or worksafe"">
	<li class=""smilie"">
		<div class=""text"">:nws:</div>
		<img alt="""" src=""http://i.somethingawful.com/forumsystem/emoticons/emot-nws.gif"" title=""OMG SO NOT WORK SAFE"">
	<li class=""smilie"">
		<div class=""text"">:owned:</div>
		<img alt="""" src=""http://i.somethingawful.com/forumsystem/emoticons/emot-owned.gif"" title=""PWNED THE AS$ OF A N00B"">
	<li class=""smilie"">
		<div class=""text"">:pedophiles:</div>
		<img alt="""" src=""http://fi.somethingawful.com/safs/smilies/a/7/pedophiles.001.gif"" title=""But what about the pedos?!"">
	<li class=""smilie"">
		<div class=""text"">:protarget:</div>
		<img alt="""" src=""http://i.somethingawful.com/forumsystem/emoticons/emot-protarget.gif"" title=""Pro Target"">
	<li class=""smilie"">
		<div class=""text"">:regd04:</div>
		<img alt="""" src=""http://i.somethingawful.com/forumsystem/emoticons/emot-04.gif"" title=""Fucking 04's"">
	<li class=""smilie"">
		<div class=""text"">:regd05:</div>
		<img alt="""" src=""http://i.somethingawful.com/forumsystem/emoticons/emot-05.gif"" title=""05 baby!"">
	<li class=""smilie"">
		<div class=""text"">:regd06:</div>
		<img alt="""" src=""http://i.somethingawful.com/forumsystem/emoticons/emot-06.gif"" title=""06 HURR!"">
	<li class=""smilie"">
		<div class=""text"">:regd07:</div>
		<img alt="""" src=""http://i.somethingawful.com/forumsystem/emoticons/emot-07.gif"" title=""2007"">
	<li class=""smilie"">
		<div class=""text"">:regd08:</div>
		<img alt="""" src=""http://i.somethingawful.com/forumsystem/emoticons/emot-regd08.gif"" title=""into the ground!"">
	<li class=""smilie"">
		<div class=""text"">:regd10:</div>
		<img alt="""" src=""http://i.somethingawful.com/forumsystem/emoticons/emot-regd10.png"" title=""Holy Diver"">
	<li class=""smilie"">
		<div class=""text"">:rms:</div>
		<img alt="""" src=""http://fi.somethingawful.com/safs/smilies/c/e/rms.001.png"" title=""wget and emailed"">
	<li class=""smilie"">
		<div class=""text"">:sbahj:</div>
		<img alt="""" src=""http://i.somethingawful.com/forumsystem/emoticons/emot-sbahj.gif"" title=""Shit got too reel for me."">
	<li class=""smilie"">
		<div class=""text"">:sicknasty:</div>
		<img alt="""" src=""http://i.somethingawful.com/forumsystem/emoticons/emot-sicknasty.gif"" title=""Space Bro Garrus"">
	<li class=""smilie"">
		<div class=""text"">:speculate:</div>
		<img alt="""" src=""http://fi.somethingawful.com/safs/smilies/c/a/speculate.001.gif"" title=""LOTS OF SPECULATION"">
	<li class=""smilie"">
		<div class=""text"">:stoke:</div>
		<img alt="""" src=""http://fi.somethingawful.com/safs/smilies/2/c/stoke.001.gif"" title=""Stoke Tactical Mastery"">
	<li class=""smilie"">
		<div class=""text"">:tetten:</div>
		<img alt="""" src=""http://fi.somethingawful.com/safs/smilies/3/c/tetten.001.gif"" title=""Tetten, the best thing ever"">
	<li class=""smilie"">
		<div class=""text"">:their:</div>
		<img alt="""" src=""http://i.somethingawful.com/forumsystem/emoticons/emot-their.gif"" title=""Grammer Queen Magnet"">
	<li class=""smilie"">
		<div class=""text"">:vd:</div>
		<img alt="""" src=""http://i.somethingawful.com/forumsystem/emoticons/emot-vd.gif"" title=""violetdragon"">
	<li class=""smilie"">
		<div class=""text"">:w00t:</div>
		<img alt="""" src=""http://i.somethingawful.com/forumsystem/emoticons/emot-w00t.gif"" title=""w00t"">
	<li class=""smilie"">
		<div class=""text"">:w2byob:</div>
		<img alt="""" src=""http://i.somethingawful.com/forumsystem/emoticons/emot-w2byob.gif"" title=""Welcome to BYOB!"">
	<li class=""smilie"">
		<div class=""text"">:waycool:</div>
		<img alt="""" src=""http://fi.somethingawful.com/images/smilies/emot-waycool.gif"" title=""Way Cool (this smilie is gay as hell)"">
	<li class=""smilie"">
		<div class=""text"">:whoptc:</div>
		<img alt="""" src=""http://i.somethingawful.com/forumsystem/emoticons/emot-whoptc.gif"" title=""whopkins"">
	<li class=""smilie"">
		<div class=""text"">:wrongful:</div>
		<img alt="""" src=""http://fi.somethingawful.com/images/smilies/emot-wrongful.gif"" title=""STFU"">
	<li class=""smilie"">
		<div class=""text"">:wtc:</div>
		<img alt="""" src=""http://i.somethingawful.com/forumsystem/emoticons/emot-wtc.gif"" title=""#1 grandpa"">
	<li class=""smilie"">
		<div class=""text"">:wtf:</div>
		<img alt="""" src=""http://fi.somethingawful.com/images/smilies/emot-wtf.gif"" title=""wtf"">
	<li class=""smilie"">
		<div class=""text"">:yohoho:</div>
		<img alt="""" src=""http://i.somethingawful.com/forumsystem/emoticons/emot-yohoho.gif"" title=""SKULL JOKE!"">
</ul>

<h3>Witty</h3>
<ul class=""smilie_group"">
	<li class=""smilie"">
		<div class=""text"">:anime:</div>
		<img alt="""" src=""http://i.somethingawful.com/forumsystem/emoticons/emot-anime.png"" title=""Ego Orb"">
	<li class=""smilie"">
		<div class=""text"">:aslol:</div>
		<img alt="""" src=""http://i.somethingawful.com/forumsystem/emoticons/emot-aslol.gif"" title=""LOL for the deaf"">
	<li class=""smilie"">
		<div class=""text"">:awesome:</div>
		<img alt="""" src=""http://i.somethingawful.com/forumsystem/emoticons/emot-awesome.gif"" title=""uh its AWESOME"">
	<li class=""smilie"">
		<div class=""text"">:baby:</div>
		<img alt="""" src=""http://i.somethingawful.com/forumsystem/emoticons/emot-baby.png"" title=""Gotta love me"">
	<li class=""smilie"">
		<div class=""text"">:backtowork:</div>
		<img alt="""" src=""http://i.somethingawful.com/forumsystem/emoticons/emot-backtowork.gif"" title=""Responsibility Scallop"">
	<li class=""smilie"">
		<div class=""text"">:barf:</div>
		<img alt="""" src=""http://i.somethingawful.com/forumsystem/emoticons/emot-barf.gif"" title=""Look at that guy puke"">
	<li class=""smilie"">
		<div class=""text"">:boonie:</div>
		<img alt="""" src=""http://i.somethingawful.com/forumsystem/emoticons/emot-boonie.gif"" title=""David Boon"">
	<li class=""smilie"">
		<div class=""text"">:bravo:</div>
		<img alt="""" src=""http://i.somethingawful.com/forumsystem/emoticons/emot-bravo.gif"" title=""bravo"">
	<li class=""smilie"">
		<div class=""text"">:buddy:</div>
		<img alt="""" src=""http://i.somethingawful.com/forumsystem/emoticons/emot-buddy.gif"" title=""for realzzies"">
	<li class=""smilie"">
		<div class=""text"">:byodame:</div>
		<img alt="""" src=""http://i.somethingawful.com/forumsystem/emoticons/emot-byodame.gif"" title=""Worst emoticonette ever."">
	<li class=""smilie"">
		<div class=""text"">:byodood:</div>
		<img alt="""" src=""http://i.somethingawful.com/forumsystem/emoticons/emot-byodood.gif"" title=""Worst emoticon ever"">
	<li class=""smilie"">
		<div class=""text"">:c00l:</div>
		<img alt="""" src=""http://i.somethingawful.com/forumsystem/emoticons/emot-c00l.gif"" title=""l33t li3k j3ff k"">
	<li class=""smilie"">
		<div class=""text"">:c00lbert:</div>
		<img alt="""" src=""http://i.somethingawful.com/forumsystem/emoticons/emot-c00lbert.gif"" title=""TAKE THAT MOTHERFUCKERS"">
	<li class=""smilie"">
		<div class=""text"">:can:</div>
		<img alt="""" src=""http://i.somethingawful.com/forumsystem/emoticons/emot-can.gif"" title=""You Opened a Can of Worms"">
	<li class=""smilie"">
		<div class=""text"">:catstare:</div>
		<img alt="""" src=""http://fi.somethingawful.com/safs/smilies/2/4/catstare.001.gif"" title=""I'm hitler IRL"">
	<li class=""smilie"">
		<div class=""text"">:chord:</div>
		<img alt="""" src=""http://i.somethingawful.com/forumsystem/emoticons/emot-chord.gif"" title=""pipe dog"">
	<li class=""smilie"">
		<div class=""text"">:corsair:</div>
		<img alt="""" src=""http://i.somethingawful.com/forumsystem/emoticons/emot-corsair.gif"" title=""Corsair is old."">
	<li class=""smilie"">
		<div class=""text"">:cripes:</div>
		<img alt="""" src=""http://fi.somethingawful.com/safs/smilies/d/0/cripes.001.gif"" title=""Cripes"">
	<li class=""smilie"">
		<div class=""text"">:crow:</div>
		<img alt="""" src=""http://i.somethingawful.com/forumsystem/emoticons/emot-crow.gif"" title=""caw caw"">
	<li class=""smilie"">
		<div class=""text"">:dawkins101:</div>
		<img alt="""" src=""http://i.somethingawful.com/forumsystem/emoticons/emot-Dawkins102.gif"" title=""Pope Gives Up"">
	<li class=""smilie"">
		<div class=""text"">:devilchild:</div>
		<img alt="""" src=""http://fi.somethingawful.com/safs/smilies/8/7/devilchild.001.gif"" title=""Israel-Palestine Discussion"">
	<li class=""smilie"">
		<div class=""text"">:dogout:</div>
		<img alt="""" src=""http://i.somethingawful.com/forumsystem/emoticons/emot-dogout.gif"" title=""out with the frog"">
	<li class=""smilie"">
		<div class=""text"">:douche:</div>
		<img alt="""" src=""http://fi.somethingawful.com/safs/smilies/0/d/douche.001.gif"" title=""egg hating renegger. also douche"">
	<li class=""smilie"">
		<div class=""text"">:downsbravo:</div>
		<img alt="""" src=""http://i.somethingawful.com/forumsystem/emoticons/emot-downsbravo.gif"" title=""Bravo"">
	<li class=""smilie"">
		<div class=""text"">:downsrim:</div>
		<img alt="""" src=""http://i.somethingawful.com/forumsystem/emoticons/emot-downsrim.gif"" title=""downs rimshot"">
	<li class=""smilie"">
		<div class=""text"">:dukedog:</div>
		<img alt="""" src=""http://fi.somethingawful.com/images/smilies/emot-dukedog.png"" title=""Duke Nukem is Forever"">
	<li class=""smilie"">
		<div class=""text"">:faggot:</div>
		<img alt="""" src=""http://i.somethingawful.com/forumsystem/emoticons/emot-faggot.gif"" title=""Smug Jecht"">
	<li class=""smilie"">
		<div class=""text"">:fella:</div>
		<img alt="""" src=""http://fi.somethingawful.com/safs/smilies/1/f/fella.001.gif"" title=""TOO MANY LIMES! TOO MANY LIMES!"">
	<li class=""smilie"">
		<div class=""text"">:fiesta:</div>
		<img alt="""" src=""http://i.somethingawful.com/forumsystem/emoticons/emot-fiesta.gif"" title=""fiesta gbs"">
	<li class=""smilie"">
		<div class=""text"">:forkbomb:</div>
		<img alt="""" src=""http://fi.somethingawful.com/safs/smilies/c/0/forkbomb.001.gif"" title=""hey there pretty lady"">
	<li class=""smilie"">
		<div class=""text"">:frog:</div>
		<img alt="""" src=""http://i.somethingawful.com/forumsystem/emoticons/emot-frog.gif"" title=""Frog Eyes"">
	<li class=""smilie"">
		<div class=""text"">:frogbon:</div>
		<img alt="""" src=""http://i.somethingawful.com/forumsystem/emoticons/emot-frogbon.gif"" title=""R-r-r-ribbit?"">
	<li class=""smilie"">
		<div class=""text"">:frogc00l:</div>
		<img alt="""" src=""http://i.somethingawful.com/forumsystem/emoticons/emot-frogc00l.gif"" title=""cooler than being cool"">
	<li class=""smilie"">
		<div class=""text"">:froggonk:</div>
		<img alt="""" src=""http://i.somethingawful.com/forumsystem/emoticons/emot-froggonk.gif"" title=""Frog Gonk"">
	<li class=""smilie"">
		<div class=""text"">:frogsiren:</div>
		<img alt="""" src=""http://i.somethingawful.com/forumsystem/emoticons/emot-frogsiren.gif"" title=""Frogsiren"">
	<li class=""smilie"">
		<div class=""text"">:fuckoff:</div>
		<img alt="""" src=""http://i.somethingawful.com/forumsystem/emoticons/emot-fuckoff.gif"" title=""Fuck off."">
	<li class=""smilie"">
		<div class=""text"">:fyadride:</div>
		<img alt="""" src=""http://i.somethingawful.com/forumsystem/emoticons/emot-fyadride.gif"" title=""Hello, fags. -TA"">
	<li class=""smilie"">
		<div class=""text"">:gbsmith:</div>
		<img alt="""" src=""http://i.somethingawful.com/forumsystem/emoticons/emot-gbsmith.gif"" title=""a goon's life"">
	<li class=""smilie"">
		<div class=""text"">:getin:</div>
		<img alt="""" src=""http://fi.somethingawful.com/safs/smilies/f/0/getin.001.gif"" title=""get in not go out"">
	<li class=""smilie"">
		<div class=""text"">:gifttank:</div>
		<img alt="""" src=""http://fi.somethingawful.com/safs/smilies/e/f/gifttank.001.gif"" title=""Gifttank"">
	<li class=""smilie"">
		<div class=""text"">:goatsecx:</div>
		<img alt="""" src=""http://fi.somethingawful.com/images/smilies/emot-goatse.gif"" title=""Goatse.cx"">
	<li class=""smilie"">
		<div class=""text"">:goonsay:</div>
		<img alt="""" src=""http://i.somethingawful.com/forumsystem/emoticons/emot-goonsay.gif"" title=""goon says"">
	<li class=""smilie"">
		<div class=""text"">:hampants:</div>
		<img alt="""" src=""http://i.somethingawful.com/forumsystem/emoticons/emot-hampants.gif"" title=""Pants of ham sing joyous!"">
	<li class=""smilie"">
		<div class=""text"">:iamafag:</div>
		<img alt="""" src=""http://i.somethingawful.com/forumsystem/emoticons/emot-fuckyou.gif"" title=""Seriously I'm a big fucking faggot, look at me, I'm King Fag, and here's the smiley to prove it"">
	<li class=""smilie"">
		<div class=""text"">:jiggled:</div>
		<img alt="""" src=""http://i.somethingawful.com/forumsystem/emoticons/emot-jiggled.gif"" title=""jiggled again"">
	<li class=""smilie"">
		<div class=""text"">:mmmsmug:</div>
		<img alt="""" src=""http://i.somethingawful.com/forumsystem/emoticons/emot-mmmsmug.gif"" title=""holy fuck check out this"">
	<li class=""smilie"">
		<div class=""text"">:mrapig:</div>
		<img alt="""" src=""http://fi.somethingawful.com/safs/smilies/b/2/mrapig.001.png"" title=""The Pigman Cometh"">
	<li class=""smilie"">
		<div class=""text"">:mump:</div>
		<img alt="""" src=""http://fi.somethingawful.com/safs/smilies/9/b/mump.001.png"" title=""Mumptruck Mike"">
	<li class=""smilie"">
		<div class=""text"">:parrot:</div>
		<img alt="""" src=""http://i.somethingawful.com/forumsystem/emoticons/emot-parrot.gif"" title=""That fucking bird"">
	<li class=""smilie"">
		<div class=""text"">:psyboom:</div>
		<img alt="""" src=""http://i.somethingawful.com/forumsystem/emoticons/emot-psyboom.gif"" title=""Psyduck head explosion"">
	<li class=""smilie"">
		<div class=""text"">:pwm:</div>
		<img alt="""" src=""http://i.somethingawful.com/forumsystem/emoticons/emot-pwm.gif"" title=""PWM mascot"">
	<li class=""smilie"">
		<div class=""text"">:pwn:</div>
		<img alt="""" src=""http://i.somethingawful.com/forumsystem/emoticons/emot-pwn.gif"" title=""fukken pwned nub"">
	<li class=""smilie"">
		<div class=""text"">:qq:</div>
		<img alt="""" src=""http://i.somethingawful.com/forumsystem/emoticons/emot-qq.gif"" title=""QQ"">
	<li class=""smilie"">
		<div class=""text"">:qqsay:</div>
		<img alt="""" src=""http://i.somethingawful.com/forumsystem/emoticons/emot-qqsay.gif"" title=""get rid of :confused:"">
	<li class=""smilie"">
		<div class=""text"">:razz:</div>
		<img alt="""" src=""http://i.somethingawful.com/forumsystem/emoticons/emot-razz.gif"" title=""ba ba ba baa im razzin it"">
	<li class=""smilie"">
		<div class=""text"">:reddit:</div>
		<img alt="""" src=""http://fi.somethingawful.com/safs/smilies/0/4/reddit.001.gif"" title=""Feeding on pedophile tears"">
	<li class=""smilie"">
		<div class=""text"">:regd09:</div>
		<img alt="""" src=""http://i.somethingawful.com/forumsystem/emoticons/emot-regd09.gif"" title=""regdog"">
	<li class=""smilie"">
		<div class=""text"">:regd11:</div>
		<img alt="""" src=""http://fi.somethingawful.com/safs/smilies/8/0/regd11.001.gif"" title=""Registry &amp; DLL sitting in a tree"">
	<li class=""smilie"">
		<div class=""text"">:rodimus:</div>
		<img alt="""" src=""http://i.somethingawful.com/forumsystem/emoticons/emot-rodimus.gif"" title=""Evil toy scalper w/child"">
	<li class=""smilie"">
		<div class=""text"">:rubshands:</div>
		<img alt="""" src=""http://fi.somethingawful.com/images/smilies/rubshandstogetherandgrinsevilly.gif"" title=""rubshandstogetherandgrinsevilly"">
	<li class=""smilie"">
		<div class=""text"">:shivdurf:</div>
		<img alt="""" src=""http://i.somethingawful.com/forumsystem/emoticons/emot-shivdurf.gif"" title=""Shivadas is king of byob."">
	<li class=""smilie"">
		<div class=""text"">:smith:</div>
		<img alt="""" src=""http://i.somethingawful.com/forumsystem/emoticons/emot-smith.gif"" title=""everyman smith"">
	<li class=""smilie"">
		<div class=""text"">:smithfrog:</div>
		<img alt="""" src=""http://i.somethingawful.com/forumsystem/emoticons/emot-smithfrog.png"" title=""A sad old frog"">
	<li class=""smilie"">
		<div class=""text"">:smithicide:</div>
		<img alt="""" src=""http://i.somethingawful.com/forumsystem/emoticons/emot-smithicide.gif"" title=""smith considering suicide"">
	<li class=""smilie"">
		<div class=""text"">:smithmouth:</div>
		<img alt="""" src=""http://fi.somethingawful.com/safs/smilies/9/7/smithmouth.001.gif"" title=""10/10/11 - never forgegg"">
	<li class=""smilie"">
		<div class=""text"">:smug:</div>
		<img alt="""" src=""http://i.somethingawful.com/forumsystem/emoticons/emot-smug.gif"" title=""Smug"">
	<li class=""smilie"">
		<div class=""text"">:smugbert:</div>
		<img alt="""" src=""http://i.somethingawful.com/forumsystem/emoticons/emot-smugbert.gif"" title=""Smug Colbert"">
	<li class=""smilie"">
		<div class=""text"">:smugdog:</div>
		<img alt="""" src=""http://i.somethingawful.com/forumsystem/emoticons/emot-smugdog.gif"" title=""a smug dog"">
	<li class=""smilie"">
		<div class=""text"">:smugissar:</div>
		<img alt="""" src=""http://i.somethingawful.com/forumsystem/emoticons/emot-smugissar.gif"" title=""die you smug sonofabitch"">
	<li class=""smilie"">
		<div class=""text"">:smugspike:</div>
		<img alt="""" src=""http://i.somethingawful.com/forumsystem/emoticons/emot-smugspike.png"" title=""Spike Witwicky being smug"">
	<li class=""smilie"">
		<div class=""text"">:staredog:</div>
		<img alt="""" src=""http://fi.somethingawful.com/safs/smilies/4/6/staredog.001.gif"" title=""staredog"">
	<li class=""smilie"">
		<div class=""text"">:stoat:</div>
		<img alt="""" src=""http://i.somethingawful.com/forumsystem/emoticons/emot-stoat.gif"" title=""Stoat Box's Emotion"">
	<li class=""smilie"">
		<div class=""text"">:suspense:</div>
		<img alt="""" src=""http://fi.somethingawful.com/safs/smilies/6/d/suspense.001.gif"" title=""Absolutely riveting."">
	<li class=""smilie"">
		<div class=""text"">:sweep:</div>
		<img alt="""" src=""http://i.somethingawful.com/forumsystem/emoticons/emot-sweep.gif"" title=""Spring Cleaning"">
	<li class=""smilie"">
		<div class=""text"">:synthy:</div>
		<img alt="""" src=""http://fi.somethingawful.com/images/smilies/synthy.gif"" title=""synthy's coffeebreak"">
	<li class=""smilie"">
		<div class=""text"">:thejoke:</div>
		<img alt="""" src=""http://fi.somethingawful.com/safs/smilies/e/e/thejoke.001.png"" title=""That's The Joke"">
	<li class=""smilie"">
		<div class=""text"">:thumbsup:</div>
		<img alt="""" src=""http://i.somethingawful.com/forumsystem/emoticons/emot-thumbsup.gif"" title=""hell yeah man"">
	<li class=""smilie"">
		<div class=""text"">:ughh:</div>
		<img alt="""" src=""http://i.somethingawful.com/forumsystem/emoticons/emot-ughh.gif"" title=""Picard Ughh"">
	<li class=""smilie"">
		<div class=""text"">:unsmigghh:</div>
		<img alt="""" src=""http://i.somethingawful.com/forumsystem/emoticons/emot-unsmigghh.gif"" title=""unsmigghh"">
	<li class=""smilie"">
		<div class=""text"">:unsmith:</div>
		<img alt="""" src=""http://i.somethingawful.com/forumsystem/emoticons/emot-unsmith.gif"" title=""keep hope alive"">
	<li class=""smilie"">
		<div class=""text"">:wotwot:</div>
		<img alt="""" src=""http://i.somethingawful.com/forumsystem/emoticons/emot-wotwot.gif"" title=""it is a duck emoticon"">
</ul>

<h3>Flags and other nationalist crap</h3>
<ul class=""smilie_group"">
	<li class=""smilie"">
		<div class=""text"">:911:</div>
		<img alt="""" src=""http://fi.somethingawful.com/images/smilies/emot-911.gif"" title=""NEVER FORGET!"">
	<li class=""smilie"">
		<div class=""text"">:anarchists:</div>
		<img alt="""" src=""http://fi.somethingawful.com/safs/smilies/2/d/anarchists.001.gif"" title=""Crying Kropotkin, anarchist flag"">
	<li class=""smilie"">
		<div class=""text"">:ancap:</div>
		<img alt="""" src=""http://fi.somethingawful.com/safs/smilies/5/4/ancap.001.gif"" title=""anarcho-capitalism"">
	<li class=""smilie"">
		<div class=""text"">:australia:</div>
		<img alt="""" src=""http://i.somethingawful.com/forumsystem/emoticons/emot-australia.gif"" title=""Australia"">
	<li class=""smilie"">
		<div class=""text"">:beck:</div>
		<img alt="""" src=""http://fi.somethingawful.com/safs/smilies/9/0/beck.001.gif"" title=""tinfoil-chalkboard-smug"">
	<li class=""smilie"">
		<div class=""text"">:belarus:</div>
		<img alt="""" src=""http://fi.somethingawful.com/images/smilies/emot-belarus.gif"" title=""I don't know what the fuck this is or why somebody would buy it but hey, that's just me"">
	<li class=""smilie"">
		<div class=""text"">:britain:</div>
		<img alt="""" src=""http://fi.somethingawful.com/images/smilies/emot-britain.gif"" title=""Britain"">
	<li class=""smilie"">
		<div class=""text"">:ca:</div>
		<img alt="""" src=""http://i.somethingawful.com/forumsystem/emoticons/emot-ca.gif"" title=""california :'("">
	<li class=""smilie"">
		<div class=""text"">:canada:</div>
		<img alt="""" src=""http://fi.somethingawful.com/images/smilies/emot-canada.gif"" title=""Canada"">
	<li class=""smilie"">
		<div class=""text"">:cheat:</div>
		<img alt="""" src=""http://fi.somethingawful.com/safs/smilies/5/e/cheat.001.gif"" title=""And also there's the Cheat!"">
	<li class=""smilie"">
		<div class=""text"">:china:</div>
		<img alt="""" src=""http://fi.somethingawful.com/images/smilies/emot-china.gif"" title=""China"">
	<li class=""smilie"">
		<div class=""text"">:denmark:</div>
		<img alt="""" src=""http://i.somethingawful.com/forumsystem/emoticons/emot-denmark.gif"" title=""Denmark"">
	<li class=""smilie"">
		<div class=""text"">:ese:</div>
		<img alt="""" src=""http://i.somethingawful.com/forumsystem/emoticons/emot-ese.gif"" title=""i cut you"">
	<li class=""smilie"">
		<div class=""text"">:eurovision:</div>
		<img alt="""" src=""http://i.somethingawful.com/forumsystem/emoticons/emot-eurovision.png"" title=""Eurovision"">
	<li class=""smilie"">
		<div class=""text"">:france:</div>
		<img alt="""" src=""http://fi.somethingawful.com/images/smilies/emot-france.gif"" title=""France"">
	<li class=""smilie"">
		<div class=""text"">:fsmug:</div>
		<img alt="""" src=""http://i.somethingawful.com/forumsystem/emoticons/emot-fsmug.gif"" title=""smug with flag"">
	<li class=""smilie"">
		<div class=""text"">:geert:</div>
		<img alt="""" src=""http://fi.somethingawful.com/safs/smilies/2/2/geert.001.gif"" title=""Geert doe er wat aan!"">
	<li class=""smilie"">
		<div class=""text"">:godwinning:</div>
		<img alt="""" src=""http://fi.somethingawful.com/safs/smilies/2/f/godwinning.001.gif"" title=""Everything's coming up F&Atilde;&frac14;hrer"">
	<li class=""smilie"">
		<div class=""text"">:helladid:</div>
		<img alt="""" src=""http://fi.somethingawful.com/safs/smilies/b/3/helladid.001.gif"" title=""CreteLP Smilie"">
	<li class=""smilie"">
		<div class=""text"">:hitler:</div>
		<img alt="""" src=""http://i.somethingawful.com/forumsystem/emoticons/emot-hitler.gif"" title=""Hitler"">
	<li class=""smilie"">
		<div class=""text"">:italy:</div>
		<img alt="""" src=""http://i.somethingawful.com/forumsystem/emoticons/emot-italy.gif"" title=""ital. flag with mussolini"">
	<li class=""smilie"">
		<div class=""text"">:japan:</div>
		<img alt="""" src=""http://fi.somethingawful.com/safs/smilies/9/e/japan.001.gif"" title=""Japan"">
	<li class=""smilie"">
		<div class=""text"">:mexico:</div>
		<img alt="""" src=""http://fi.somethingawful.com/images/smilies/emot-mexico.gif"" title=""Mexico"">
	<li class=""smilie"">
		<div class=""text"">:norway:</div>
		<img alt="""" src=""http://i.somethingawful.com/forumsystem/emoticons/emot-norway.gif"" title=""Norway/Norge/Noreg"">
	<li class=""smilie"">
		<div class=""text"">:patriot:</div>
		<img alt="""" src=""http://fi.somethingawful.com/images/smilies/emot-patriot.gif"" title=""Who the hell paid money for this stupid shit"">
	<li class=""smilie"">
		<div class=""text"">:poland:</div>
		<img alt="""" src=""http://fi.somethingawful.com/safs/smilies/9/8/poland.001.gif"" title=""polish joke"">
	<li class=""smilie"">
		<div class=""text"">:quebec:</div>
		<img alt="""" src=""http://fi.somethingawful.com/safs/smilies/3/d/quebec.001.gif"" title=""Francophone pride"">
	<li class=""smilie"">
		<div class=""text"">:scotland:</div>
		<img alt="""" src=""http://i.somethingawful.com/forumsystem/emoticons/emot-scotland.gif"" title=""Bonny Bonny Scotland"">
	<li class=""smilie"">
		<div class=""text"">:spain:</div>
		<img alt="""" src=""http://i.somethingawful.com/forumsystem/emoticons/emot-spain.gif"" title=""Bulls cry in Spain"">
	<li class=""smilie"">
		<div class=""text"">:sweden:</div>
		<img alt="""" src=""http://i.somethingawful.com/forumsystem/emoticons/emot-sweden.gif"" title=""Sweden"">
	<li class=""smilie"">
		<div class=""text"">:tf:</div>
		<img alt="""" src=""http://i.somethingawful.com/forumsystem/emoticons/emot-tf.gif"" title=""TF: 1/5/09: NEVER FORGET"">
	<li class=""smilie"">
		<div class=""text"">:tito:</div>
		<img alt="""" src=""http://i.somethingawful.com/forumsystem/emoticons/emot-tito.gif"" title=""tito"">
	<li class=""smilie"">
		<div class=""text"">:ussr:</div>
		<img alt="""" src=""http://fi.somethingawful.com/images/smilies/emot-ussr.gif"" title=""USSR"">
	<li class=""smilie"">
		<div class=""text"">:vuvu:</div>
		<img alt="""" src=""http://fi.somethingawful.com/safs/smilies/6/8/vuvu.001.gif"" title=""South Africa"">
	<li class=""smilie"">
		<div class=""text"">:woz:</div>
		<img alt="""" src=""http://fi.somethingawful.com/safs/smilies/8/b/woz.001.gif"" title=""the Woz rules"">
	<li class=""smilie"">
		<div class=""text"">:zpatriot:</div>
		<img alt="""" src=""http://fi.somethingawful.com/safs/smilies/5/d/zpatriot.001.gif"" title=""Zombie Patriot"">
</ul>

<h3>TV, Movies, Games, &amp; Comics</h3>
<ul class=""smilie_group"">
	<li class=""smilie"">
		<div class=""text"">:?:</div>
		<img alt="""" src=""http://fi.somethingawful.com/images/smilies/emot-question.gif"" title=""Question box"">
	<li class=""smilie"">
		<div class=""text"">:asoiaf:</div>
		<img alt="""" src=""http://fi.somethingawful.com/safs/smilies/9/7/asoiaf.001.gif"" title=""hbo's game of thrones"">
	<li class=""smilie"">
		<div class=""text"">:axe:</div>
		<img alt="""" src=""http://i.somethingawful.com/forumsystem/emoticons/emot-axe.gif"" title=""Axe Maniac"">
	<li class=""smilie"">
		<div class=""text"">:bsg:</div>
		<img alt="""" src=""http://i.somethingawful.com/forumsystem/emoticons/emot-bsg.gif"" title=""So say we all."">
	<li class=""smilie"">
		<div class=""text"">:bubblewoop:</div>
		<img alt="""" src=""http://i.somethingawful.com/forumsystem/emoticons/emot-bubblewoop.gif"" title=""Bubble Bobble"">
	<li class=""smilie"">
		<div class=""text"">:c:</div>
		<img alt="""" src=""http://i.somethingawful.com/forumsystem/emoticons/emot-c.png"" title=""poker club"">
	<li class=""smilie"">
		<div class=""text"">:d:</div>
		<img alt="""" src=""http://i.somethingawful.com/forumsystem/emoticons/emot-d.png"" title=""poker diamond"">
	<li class=""smilie"">
		<div class=""text"">:doink:</div>
		<img alt="""" src=""http://i.somethingawful.com/forumsystem/emoticons/emot-doink.gif"" title=""Doink"">
	<li class=""smilie"">
		<div class=""text"">:doom:</div>
		<img alt="""" src=""http://i.somethingawful.com/forumsystem/emoticons/emot-doom.gif"" title=""RRRRRICHARDS!"">
	<li class=""smilie"">
		<div class=""text"">:dota101:</div>
		<img alt="""" src=""http://i.somethingawful.com/forumsystem/emoticons/emot-dota101.gif"" title=""Playing DOTA 101"">
	<li class=""smilie"">
		<div class=""text"">:flashfact:</div>
		<img alt="""" src=""http://i.somethingawful.com/forumsystem/emoticons/emot-flashfact.gif"" title=""Flash fact"">
	<li class=""smilie"">
		<div class=""text"">:flashfap:</div>
		<img alt="""" src=""http://i.somethingawful.com/forumsystem/emoticons/emot-flashfap.gif"" title=""Flash loves the ladies"">
	<li class=""smilie"">
		<div class=""text"">:foxnews:</div>
		<img alt="""" src=""http://i.somethingawful.com/forumsystem/emoticons/emot-foxnews.gif"" title=""LOL Fox News LOL"">
	<li class=""smilie"">
		<div class=""text"">:fry:</div>
		<img alt="""" src=""http://i.somethingawful.com/forumsystem/emoticons/emot-fry.gif"" title=""Fry saying &quot;Oh Snap!&quot;"">
	<li class=""smilie"">
		<div class=""text"">:gaben:</div>
		<img alt="""" src=""http://fi.somethingawful.com/safs/smilies/6/9/gaben.001.gif"" title=""Look at the money you're saving."">
	<li class=""smilie"">
		<div class=""text"">:golgo:</div>
		<img alt="""" src=""http://i.somethingawful.com/forumsystem/emoticons/emot-golgo.gif"" title=""Duke Togo Sniper"">
	<li class=""smilie"">
		<div class=""text"">:h:</div>
		<img alt="""" src=""http://i.somethingawful.com/forumsystem/emoticons/emot-h.png"" title=""poker heart"">
	<li class=""smilie"">
		<div class=""text"">:itjb:</div>
		<img alt="""" src=""http://i.somethingawful.com/forumsystem/emoticons/emot-itjb.gif"" title=""I'm the juggernaut bitch"">
	<li class=""smilie"">
		<div class=""text"">:jp:</div>
		<img alt="""" src=""http://i.somethingawful.com/forumsystem/emoticons/emot-jp.gif"" title=""John Phillipe"">
	<li class=""smilie"">
		<div class=""text"">:kakashi:</div>
		<img alt="""" src=""http://i.somethingawful.com/forumsystem/emoticons/emot-kakashi.gif"" title=""kakashi"">
	<li class=""smilie"">
		<div class=""text"">:kratos:</div>
		<img alt="""" src=""http://i.somethingawful.com/forumsystem/emoticons/emot-kratos.gif"" title=""I AM THE GOD OF WAR"">
	<li class=""smilie"">
		<div class=""text"">:laugh:</div>
		<img alt="""" src=""http://i.somethingawful.com/forumsystem/emoticons/emot-laugh.gif"" title=""Laugh"">
	<li class=""smilie"">
		<div class=""text"">:legion:</div>
		<img alt="""" src=""http://fi.somethingawful.com/safs/smilies/e/a/legion.001.gif"" title=""Consensus: Death by Gunshot"">
	<li class=""smilie"">
		<div class=""text"">:liara:</div>
		<img alt="""" src=""http://fi.somethingawful.com/safs/smilies/9/9/liara.001.gif"" title=""This takes me back..."">
	<li class=""smilie"">
		<div class=""text"">:lost:</div>
		<img alt="""" src=""http://i.somethingawful.com/forumsystem/emoticons/emot-lost.gif"" title=""LOST"">
	<li class=""smilie"">
		<div class=""text"">:lovewcc:</div>
		<img alt="""" src=""http://i.somethingawful.com/forumsystem/emoticons/emot-lovewcc.gif"" title=""We love Companion Cubes"">
	<li class=""smilie"">
		<div class=""text"">:lron:</div>
		<img alt="""" src=""http://i.somethingawful.com/forumsystem/emoticons/emot-lron.gif"" title=""Pyarmid cult Hypno"">
	<li class=""smilie"">
		<div class=""text"">:mario:</div>
		<img alt="""" src=""http://fi.somethingawful.com/images/smilies/emot-mario.gif"" title=""Mario"">
	<li class=""smilie"">
		<div class=""text"">:mcnabb:</div>
		<img alt="""" src=""http://i.somethingawful.com/forumsystem/emoticons/emot-mcnabb.png"" title=""Happy Donovan"">
	<li class=""smilie"">
		<div class=""text"">:megaman:</div>
		<img alt="""" src=""http://fi.somethingawful.com/images/smilies/emot-megaman.gif"" title=""Megaman"">
	<li class=""smilie"">
		<div class=""text"">:nixon:</div>
		<img alt="""" src=""http://i.somethingawful.com/forumsystem/emoticons/emot-nixon.gif"" title=""Nixon's back!"">
	<li class=""smilie"">
		<div class=""text"">:nolan:</div>
		<img alt="""" src=""http://i.somethingawful.com/forumsystem/emoticons/emot-nolan.gif"" title=""Let's Talk Batman Guys"">
	<li class=""smilie"">
		<div class=""text"">:nyan:</div>
		<img alt="""" src=""http://fi.somethingawful.com/safs/smilies/0/e/nyan.001.gif"" title=""nyan cat"">
	<li class=""smilie"">
		<div class=""text"">:orks:</div>
		<img alt="""" src=""http://i.somethingawful.com/forumsystem/emoticons/emot-orks.gif"" title=""DAKKA DAKKA DAKKA"">
	<li class=""smilie"">
		<div class=""text"">:pcgaming1:</div>
		<img alt="""" src=""http://i.somethingawful.com/forumsystem/emoticons/emot-pcgaming1.gif"" title=""PC Gaming Filez Frog"">
	<li class=""smilie"">
		<div class=""text"">:pcgaming:</div>
		<img alt="""" src=""http://i.somethingawful.com/forumsystem/emoticons/emot-pcgaming.gif"" title=""HOLY SHIT PC GAMING!"">
	<li class=""smilie"">
		<div class=""text"">:psydwarf:</div>
		<img alt="""" src=""http://fi.somethingawful.com/safs/smilies/f/5/psydwarf.001.png"" title=""Dwarves are maddeningly stupid."">
	<li class=""smilie"">
		<div class=""text"">:punto:</div>
		<img alt="""" src=""http://i.somethingawful.com/forumsystem/emoticons/emot-punto.gif"" title=""buntbuntbunt"">
	<li class=""smilie"">
		<div class=""text"">:qfg:</div>
		<img alt="""" src=""http://i.somethingawful.com/forumsystem/emoticons/emot-qfg.gif"" title=""QFG Hero Dance"">
	<li class=""smilie"">
		<div class=""text"">:quagmire:</div>
		<img alt="""" src=""http://fi.somethingawful.com/images/smilies/emot-quagmire.gif"" title=""Quagmire"">
	<li class=""smilie"">
		<div class=""text"">:ramsay:</div>
		<img alt="""" src=""http://i.somethingawful.com/forumsystem/emoticons/emot-ramsay.gif"" title=""Gordon Ramsay"">
	<li class=""smilie"">
		<div class=""text"">:retrogames:</div>
		<img alt="""" src=""http://fi.somethingawful.com/safs/smilies/4/a/retrogames.001.gif"" title=""Retro Gooning (Spending Money)"">
	<li class=""smilie"">
		<div class=""text"">:riot:</div>
		<img alt="""" src=""http://fi.somethingawful.com/safs/smilies/f/d/riot.001.gif"" title=""Best online technical"">
	<li class=""smilie"">
		<div class=""text"">:rolldice:</div>
		<img alt="""" src=""http://fi.somethingawful.com/safs/smilies/5/1/rolldice.001.gif"" title=""totally having fun"">
	<li class=""smilie"">
		<div class=""text"">:s:</div>
		<img alt="""" src=""http://i.somethingawful.com/forumsystem/emoticons/emot-s.png"" title=""poker spade"">
	<li class=""smilie"">
		<div class=""text"">:sg:</div>
		<img alt="""" src=""http://i.somethingawful.com/forumsystem/emoticons/emot-sg.gif"" title=""Shyguy"">
	<li class=""smilie"">
		<div class=""text"">:shepface:</div>
		<img alt="""" src=""http://i.somethingawful.com/forumsystem/emoticons/emot-shepface.gif"" title=""Sexing aliens, you say?"">
	<li class=""smilie"">
		<div class=""text"">:shepicide:</div>
		<img alt="""" src=""http://fi.somethingawful.com/safs/smilies/8/2/shepicide.001.gif"" title=""I have no idea..."">
	<li class=""smilie"">
		<div class=""text"">:smaug:</div>
		<img alt="""" src=""http://fi.somethingawful.com/safs/smilies/a/9/smaug.001.gif"" title=""Smaug Smug"">
	<li class=""smilie"">
		<div class=""text"">:spidey:</div>
		<img alt="""" src=""http://i.somethingawful.com/forumsystem/emoticons/emot-spidey.gif"" title=""My Spidey Sense is tingling"">
	<li class=""smilie"">
		<div class=""text"">:stat:</div>
		<img alt="""" src=""http://i.somethingawful.com/forumsystem/emoticons/emot-stat.gif"" title=""Statler"">
	<li class=""smilie"">
		<div class=""text"">:steam:</div>
		<img alt="""" src=""http://fi.somethingawful.com/safs/smilies/1/e/steam.001.gif"" title=""Steam"">
	<li class=""smilie"">
		<div class=""text"">:tali:</div>
		<img alt="""" src=""http://fi.somethingawful.com/safs/smilies/f/1/tali.001.gif"" title=""Incoming sperg in 5...4..."">
	<li class=""smilie"">
		<div class=""text"">:todd:</div>
		<img alt="""" src=""http://i.somethingawful.com/forumsystem/emoticons/emot-todd.gif"" title=""Plagiarism ahoy!"">
	<li class=""smilie"">
		<div class=""text"">:turianass:</div>
		<img alt="""" src=""http://i.somethingawful.com/forumsystem/emoticons/emot-turianass.gif"" title=""Turian Airqoute"">
	<li class=""smilie"">
		<div class=""text"">:tviv:</div>
		<img alt="""" src=""http://i.somethingawful.com/forumsystem/emoticons/emot-tviv.gif"" title=""Shit just got real on TV"">
	<li class=""smilie"">
		<div class=""text"">:tvtropes:</div>
		<img alt="""" src=""http://fi.somethingawful.com/safs/smilies/4/d/tvtropes.001.gif"" title=""Unironic boob charts everyday"">
	<li class=""smilie"">
		<div class=""text"">:twentyfour:</div>
		<img alt="""" src=""http://i.somethingawful.com/forumsystem/emoticons/emot-twentyfour.gif"" title=""24 icon for TVIV"">
	<li class=""smilie"">
		<div class=""text"">:wal:</div>
		<img alt="""" src=""http://i.somethingawful.com/forumsystem/emoticons/emot-wal.gif"" title=""Waldorf"">
	<li class=""smilie"">
		<div class=""text"">:wcc:</div>
		<img alt="""" src=""http://i.somethingawful.com/forumsystem/emoticons/emot-wcc.gif"" title=""Weighted Compion Cube"">
	<li class=""smilie"">
		<div class=""text"">:wcw:</div>
		<img alt="""" src=""http://i.somethingawful.com/forumsystem/emoticons/emot-wcw.gif"" title=""Vince makes Sting cry"">
	<li class=""smilie"">
		<div class=""text"">:wookie:</div>
		<img alt="""" src=""http://fi.somethingawful.com/images/smilies/emot-wookie.gif"" title=""Chewbacca"">
	<li class=""smilie"">
		<div class=""text"">:xcom:</div>
		<img alt="""" src=""http://fi.somethingawful.com/safs/smilies/e/a/xcom.001.gif"" title=""baby"">
	<li class=""smilie"">
		<div class=""text"">:yoshi:</div>
		<img alt="""" src=""http://fi.somethingawful.com/images/smilies/emot-yoshi.gif"" title=""Yoshi"">
	<li class=""smilie"">
		<div class=""text"">:zaeed:</div>
		<img alt="""" src=""http://fi.somethingawful.com/safs/smilies/6/7/zaeed.001.gif"" title=""Guddamn terrorists I said."">
	<li class=""smilie"">
		<div class=""text"">:zoid:</div>
		<img alt="""" src=""http://fi.somethingawful.com/images/smilies/emot-zoid.gif"" title=""Zoidberg"">
</ul>

<h3>Horrible &amp; retarded shit we can't wait to delete</h3>
<ul class=""smilie_group"">
	<li class=""smilie"">
		<div class=""text"">:11tea:</div>
		<img alt="""" src=""http://i.somethingawful.com/forumsystem/emoticons/emot-11tea.gif"" title=""11:00 drink tea every day"">
	<li class=""smilie"">
		<div class=""text"">:a2m:</div>
		<img alt="""" src=""http://i.somethingawful.com/forumsystem/emoticons/emot-a2m.gif"" title=""Ass to Mouth"">
	<li class=""smilie"">
		<div class=""text"">:am:</div>
		<img alt="""" src=""http://i.somethingawful.com/forumsystem/emoticons/emot-am.gif"" title=""Atomic Monkey"">
	<li class=""smilie"">
		<div class=""text"">:awesomelon:</div>
		<img alt="""" src=""http://i.somethingawful.com/forumsystem/emoticons/emot-awesomelon.gif"" title=""Awesome Cylon"">
	<li class=""smilie"">
		<div class=""text"">:bahgawd:</div>
		<img alt="""" src=""http://i.somethingawful.com/forumsystem/emoticons/emot-bahgawd.gif"" title=""Bah Gawd King!"">
	<li class=""smilie"">
		<div class=""text"">:bandwagon:</div>
		<img alt="""" src=""http://i.somethingawful.com/forumsystem/emoticons/emot-bandwagon.gif"" title=""All Aboard the Bandwagon"">
	<li class=""smilie"">
		<div class=""text"">:bick:</div>
		<img alt="""" src=""http://i.somethingawful.com/forumsystem/emoticons/emot-bick.gif"" title=""aw shit its your boy bick"">
	<li class=""smilie"">
		<div class=""text"">:bigtran:</div>
		<img alt="""" src=""http://i.somethingawful.com/forumsystem/emoticons/emot-bigtran.gif"" title=""Bigtran!"">
	<li class=""smilie"">
		<div class=""text"">:biotruths:</div>
		<img alt="""" src=""http://fi.somethingawful.com/safs/smilies/2/0/biotruths.001.gif"" title=""because berries"">
	<li class=""smilie"">
		<div class=""text"">:btroll:</div>
		<img alt="""" src=""http://fi.somethingawful.com/images/smilies/emot-buttertroll.gif"" title=""Butter Troll"">
	<li class=""smilie"">
		<div class=""text"">:burger:</div>
		<img alt="""" src=""http://i.somethingawful.com/forumsystem/emoticons/emot-burger.gif"" title=""have a burger"">
	<li class=""smilie"">
		<div class=""text"">:bustem:</div>
		<img alt="""" src=""http://i.somethingawful.com/forumsystem/emoticons/emot-bustem.png"" title=""Chris Costa's Bust'em"">
	<li class=""smilie"">
		<div class=""text"">:byobear:</div>
		<img alt="""" src=""http://i.somethingawful.com/forumsystem/emoticons/emot-byobear.gif"" title=""Trashcanbear XP SP2"">
	<li class=""smilie"">
		<div class=""text"">:c00lbutt:</div>
		<img alt="""" src=""http://i.somethingawful.com/forumsystem/emoticons/emot-c00lbutt.gif"" title=""a star is born"">
	<li class=""smilie"">
		<div class=""text"">:camera6:</div>
		<img alt="""" src=""http://i.somethingawful.com/forumsystem/emoticons/emot-camera6.gif"" title=""Worst Case Scenario"">
	<li class=""smilie"">
		<div class=""text"">:ccb:</div>
		<img alt="""" src=""http://i.somethingawful.com/forumsystem/emoticons/emot-ccb.gif"" title=""clown balloon cock"">
	<li class=""smilie"">
		<div class=""text"">:cedric:</div>
		<img alt="""" src=""http://fi.somethingawful.com/safs/smilies/e/4/cedric.001.png"" title=""Graham, watch out!"">
	<li class=""smilie"">
		<div class=""text"">:cenobite:</div>
		<img alt="""" src=""http://fi.somethingawful.com/customtitles/emot-chatter.gif"" title=""We have eternity to know your flesh"">
	<li class=""smilie"">
		<div class=""text"">:chiefsay:</div>
		<img alt="""" src=""http://fi.somethingawful.com/safs/smilies/1/c/chiefsay.001.gif"" title=""Earned them Khaki's"">
	<li class=""smilie"">
		<div class=""text"">:chiyo:</div>
		<img alt="""" src=""http://fi.somethingawful.com/images/smilies/emot-chio.gif"" title=""Some creepy ADTRW thing"">
	<li class=""smilie"">
		<div class=""text"">:circlefap:</div>
		<img alt="""" src=""http://i.somethingawful.com/forumsystem/emoticons/emot-circlefap.gif"" title=""Circle Fap"">
	<li class=""smilie"">
		<div class=""text"">:coal:</div>
		<img alt="""" src=""http://i.somethingawful.com/forumsystem/emoticons/emot-coal.gif"" title=""coal"">
	<li class=""smilie"">
		<div class=""text"">:confuoot:</div>
		<img alt="""" src=""http://fi.somethingawful.com/safs/smilies/0/d/confuoot.001.gif"" title=""why am i tooting"">
	<li class=""smilie"">
		<div class=""text"">:coolfish:</div>
		<img alt="""" src=""http://i.somethingawful.com/forumsystem/emoticons/emot-coolfish.gif"" title=""coolfish"">
	<li class=""smilie"">
		<div class=""text"">:derp:</div>
		<img alt="""" src=""http://i.somethingawful.com/forumsystem/emoticons/emot-derp.gif"" title=""deepa derpa doo"">
	<li class=""smilie"">
		<div class=""text"">:derptiel:</div>
		<img alt="""" src=""http://fi.somethingawful.com/safs/smilies/0/b/derptiel.001.gif"" title=""aka downsparrot"">
	<li class=""smilie"">
		<div class=""text"">:dong:</div>
		<img alt="""" src=""http://i.somethingawful.com/forumsystem/emoticons/emot-dong.gif"" title=""Dongs"">
	<li class=""smilie"">
		<div class=""text"">:drum:</div>
		<img alt="""" src=""http://i.somethingawful.com/forumsystem/emoticons/emot-drum.gif"" title=""Get a move on"">
	<li class=""smilie"">
		<div class=""text"">:ducksiren:</div>
		<img alt="""" src=""http://fi.somethingawful.com/safs/smilies/b/3/ducksiren.001.gif"" title=""Half the duck, all the sass."">
	<li class=""smilie"">
		<div class=""text"">:edi:</div>
		<img alt="""" src=""http://fi.somethingawful.com/safs/smilies/1/b/edi.001.gif"" title=""That is a joke."">
	<li class=""smilie"">
		<div class=""text"">:emoticon:</div>
		<img alt="""" src=""http://i.somethingawful.com/forumsystem/emoticons/emot-emoticon.gif"" title=""Hey guys, adbot's cool!"">
	<li class=""smilie"">
		<div class=""text"">:evil:</div>
		<img alt="""" src=""http://fi.somethingawful.com/customtitles/evol-anim.gif"" title=""It's catching on!"">
	<li class=""smilie"">
		<div class=""text"">:fireman:</div>
		<img alt="""" src=""http://i.somethingawful.com/forumsystem/emoticons/emot-fireman.gif"" title=""Not worth dying for"">
	<li class=""smilie"">
		<div class=""text"">:flaccid:</div>
		<img alt="""" src=""http://i.somethingawful.com/forumsystem/emoticons/emot-flaccid.gif"" title=""This never happens to me"">
	<li class=""smilie"">
		<div class=""text"">:flag:</div>
		<img alt="""" src=""http://fi.somethingawful.com/images/smilies/emot-flag.gif"" title=""Penalty flag"">
	<li class=""smilie"">
		<div class=""text"">:fork:</div>
		<img alt="""" src=""http://fi.somethingawful.com/images/smilies/emot-fork.png"" title=""Fork"">
	<li class=""smilie"">
		<div class=""text"">:frogdowns:</div>
		<img alt="""" src=""http://i.somethingawful.com/forumsystem/emoticons/emot-frogdowns.png"" title=""Downs Frog"">
	<li class=""smilie"">
		<div class=""text"">:fsn:</div>
		<img alt="""" src=""http://i.somethingawful.com/forumsystem/emoticons/emot-fsn.gif"" title=""Tribute to LP"">
	<li class=""smilie"">
		<div class=""text"">:furcry:</div>
		<img alt="""" src=""http://i.somethingawful.com/forumsystem/emoticons/emot-furcry.gif"" title=""Fursecution is a myth"">
	<li class=""smilie"">
		<div class=""text"">:fut:</div>
		<img alt="""" src=""http://fi.somethingawful.com/safs/smilies/f/c/fut.001.gif"" title=""Fuck you TROLLS!"">
	<li class=""smilie"">
		<div class=""text"">:FYH:</div>
		<img alt="""" src=""http://i.somethingawful.com/forumsystem/emoticons/emot-FYH.gif"" title=""Fuck You Hannah"">
	<li class=""smilie"">
		<div class=""text"">:george:</div>
		<img alt="""" src=""http://i.somethingawful.com/forumsystem/emoticons/emot-george.gif"" title=""Gorgeous George"">
	<li class=""smilie"">
		<div class=""text"">:gizz:</div>
		<img alt="""" src=""http://i.somethingawful.com/forumsystem/emoticons/emot-gizz.gif"" title=""Gizz"">
	<li class=""smilie"">
		<div class=""text"">:goleft:</div>
		<img alt="""" src=""http://i.somethingawful.com/forumsystem/emoticons/emot-goleft.gif"" title=""this ones for microwave"">
	<li class=""smilie"">
		<div class=""text"">:gonchar:</div>
		<img alt="""" src=""http://i.somethingawful.com/forumsystem/emoticons/emot-gonchar.gif"" title=""he looks like a puffy cow"">
	<li class=""smilie"">
		<div class=""text"">:google:</div>
		<img alt="""" src=""http://fi.somethingawful.com/images/smilies/emot-google.gif"" title=""Google"">
	<li class=""smilie"">
		<div class=""text"">:goon:</div>
		<img alt="""" src=""http://fi.somethingawful.com/images/smilies/emot-goon.gif"" title=""This smilie is gay as hell but oh well"">
	<li class=""smilie"">
		<div class=""text"">:goonboot:</div>
		<img alt="""" src=""http://i.somethingawful.com/forumsystem/emoticons/emot-goonboot.gif"" title=""March of the GoonBoots"">
	<li class=""smilie"">
		<div class=""text"">:gooncamp:</div>
		<img alt="""" src=""http://i.somethingawful.com/forumsystem/emoticons/emot-gooncamp.gif"" title=""gooncamp"">
	<li class=""smilie"">
		<div class=""text"">:gtfoycs:</div>
		<img alt="""" src=""http://i.somethingawful.com/forumsystem/emoticons/emot-gtfoycs.gif"" title=""Get the fuck out of YCS"">
	<li class=""smilie"">
		<div class=""text"">:guitar:</div>
		<img alt="""" src=""http://i.somethingawful.com/forumsystem/emoticons/emot-guitar.gif"" title=""Jammin'"">
	<li class=""smilie"">
		<div class=""text"">:gurf:</div>
		<img alt="""" src=""http://i.somethingawful.com/forumsystem/emoticons/emot-gurf.gif"" title=""gurf"">
	<li class=""smilie"">
		<div class=""text"">:happyelf:</div>
		<img alt="""" src=""http://i.somethingawful.com/forumsystem/emoticons/emot-happyelf.gif"" title=""Warning: Israel-Palestine"">
	<li class=""smilie"">
		<div class=""text"">:havlat:</div>
		<img alt="""" src=""http://i.somethingawful.com/forumsystem/emoticons/emot-havlat.gif"" title=""Martin Havlat for Jesus"">
	<li class=""smilie"">
		<div class=""text"">:hb:</div>
		<img alt="""" src=""http://i.somethingawful.com/forumsystem/emoticons/emot-hb.gif"" title=""Henrich Von Bastard"">
	<li class=""smilie"">
		<div class=""text"">:hchatter:</div>
		<img alt="""" src=""http://i.somethingawful.com/forumsystem/emoticons/emot-hchatter.gif"" title=""Welcome to FYAD, we fucken loooooove to drink"">
	<li class=""smilie"">
		<div class=""text"">:hellyeah:</div>
		<img alt="""" src=""http://i.somethingawful.com/forumsystem/emoticons/emot-hellyeah.gif"" title=""hell yeah"">
	<li class=""smilie"">
		<div class=""text"">:holymoley:</div>
		<img alt="""" src=""http://i.somethingawful.com/forumsystem/emoticons/emot-holymoley.gif"" title=""Holy Moley!"">
	<li class=""smilie"">
		<div class=""text"">:horse:</div>
		<img alt="""" src=""http://i.somethingawful.com/forumsystem/emoticons/emot-horse.gif"" title=""horse gif A+ barbaro RIP"">
	<li class=""smilie"">
		<div class=""text"">:hr:</div>
		<img alt="""" src=""http://i.somethingawful.com/forumsystem/emoticons/emot-hr.gif"" title=""Haibane Renmei"">
	<li class=""smilie"">
		<div class=""text"">:iiaca:</div>
		<img alt="""" src=""http://i.somethingawful.com/forumsystem/emoticons/emot-iiaca.gif"" title=""It is a car analogy"">
	<li class=""smilie"">
		<div class=""text"">:ironicat:</div>
		<img alt="""" src=""http://i.somethingawful.com/forumsystem/emoticons/emot-ironicat.gif"" title=""It's an ironic cat"">
	<li class=""smilie"">
		<div class=""text"">:irony:</div>
		<img alt="""" src=""http://i.somethingawful.com/forumsystem/emoticons/emot-irony.gif"" title=""Irony Meter"">
	<li class=""smilie"">
		<div class=""text"">:iw:</div>
		<img alt="""" src=""http://fi.somethingawful.com/safs/smilies/5/d/iw.001.gif"" title=""Infinity Ward Robert Bowling"">
	<li class=""smilie"">
		<div class=""text"">:jeb:</div>
		<img alt="""" src=""http://fi.somethingawful.com/safs/smilies/a/b/jeb.001.gif"" title=""Jeb Kerman: Thrillmaster"">
	<li class=""smilie"">
		<div class=""text"">:joel:</div>
		<img alt="""" src=""http://i.somethingawful.com/forumsystem/emoticons/emot-joel.gif"" title=""It's Joel de Bunchastu"">
	<li class=""smilie"">
		<div class=""text"">:kamina:</div>
		<img alt="""" src=""http://i.somethingawful.com/forumsystem/emoticons/emot-kamina.gif"" title=""KYODAI GATTAI!"">
	<li class=""smilie"">
		<div class=""text"">:kiddo:</div>
		<img alt="""" src=""http://i.somethingawful.com/forumsystem/emoticons/emot-kiddo.gif"" title=""Innocent youth"">
	<li class=""smilie"">
		<div class=""text"">:killdozer:</div>
		<img alt="""" src=""http://i.somethingawful.com/forumsystem/emoticons/emot-killdozer.gif"" title=""legends never die"">
	<li class=""smilie"">
		<div class=""text"">:krad:</div>
		<img alt="""" src=""http://i.somethingawful.com/forumsystem/emoticons/emot-krad2.gif"" title=""Kickin' Rad (Oldschool)"">
	<li class=""smilie"">
		<div class=""text"">:krakken:</div>
		<img alt="""" src=""http://fi.somethingawful.com/images/smilies/emot-kraken.gif"" title=""The Krakken"">
	<li class=""smilie"">
		<div class=""text"">:love:</div>
		<img alt="""" src=""http://fi.somethingawful.com/images/smilies/emot-love.gif"" title=""Love heart"">
	<li class=""smilie"">
		<div class=""text"">:madmax:</div>
		<img alt="""" src=""http://i.somethingawful.com/forumsystem/emoticons/emot-madmax.gif"" title=""Mad Max"">
	<li class=""smilie"">
		<div class=""text"">:manning:</div>
		<img alt="""" src=""http://fi.somethingawful.com/safs/smilies/2/3/manning.001.gif"" title=""Santana Moss and Jabar Gaffney?"">
	<li class=""smilie"">
		<div class=""text"">:mason:</div>
		<img alt="""" src=""http://i.somethingawful.com/forumsystem/emoticons/emot-mason.gif"" title=""Masonic"">
	<li class=""smilie"">
		<div class=""text"">:milk:</div>
		<img alt="""" src=""http://i.somethingawful.com/forumsystem/emoticons/emot-milk.gif"" title=""YOU DUMBASS!"">
	<li class=""smilie"">
		<div class=""text"">:monar:</div>
		<img alt="""" src=""http://fi.somethingawful.com/images/smilies/emot-monar.gif"" title=""MONAR?!?!"">
	<li class=""smilie"">
		<div class=""text"">:moustache:</div>
		<img alt="""" src=""http://i.somethingawful.com/forumsystem/emoticons/emot-moustache.gif"" title=""It is a moustache"">
	<li class=""smilie"">
		<div class=""text"">:mufasa:</div>
		<img alt="""" src=""http://i.somethingawful.com/forumsystem/emoticons/emot-mufasa.png"" title=""Mufasa"">
	<li class=""smilie"">
		<div class=""text"">:negative:</div>
		<img alt="""" src=""http://fi.somethingawful.com/images/smilies/negativeman-55f.png"" title=""NegativeMan"">
	<li class=""smilie"">
		<div class=""text"">:notfunny:</div>
		<img alt="""" src=""http://i.somethingawful.com/forumsystem/emoticons/emot-notfunny.gif"" title=""DocEvil"">
	<li class=""smilie"">
		<div class=""text"">:nyoron:</div>
		<img alt="""" src=""http://i.somethingawful.com/forumsystem/emoticons/emot-nyoron.gif"" title=""smoked cheese"">
	<li class=""smilie"">
		<div class=""text"">:objection:</div>
		<img alt="""" src=""http://i.somethingawful.com/forumsystem/emoticons/emot-objection.gif"" title=""That was.. objectionable!"">
	<li class=""smilie"">
		<div class=""text"">:ovr:</div>
		<img alt="""" src=""http://fi.somethingawful.com/safs/smilies/c/e/ovr.001.gif"" title=""YOSPOS, BITCH"">
	<li class=""smilie"">
		<div class=""text"">:page3:</div>
		<img alt="""" src=""http://i.somethingawful.com/forumsystem/emoticons/emot-page3.gif"" title=""page 3 conspiracy"">
	<li class=""smilie"">
		<div class=""text"">:phone:</div>
		<img alt="""" src=""http://i.somethingawful.com/forumsystem/emoticons/emot-phone.gif"" title=""i wanna talk to my daddy"">
	<li class=""smilie"">
		<div class=""text"">:phoneb:</div>
		<img alt="""" src=""http://i.somethingawful.com/forumsystem/emoticons/emot-phoneb.gif"" title=""hello have a nice day"">
	<li class=""smilie"">
		<div class=""text"">:phoneline:</div>
		<img alt="""" src=""http://i.somethingawful.com/forumsystem/emoticons/emot-phoneline.gif"" title=""Reach out &amp; touch someone"">
	<li class=""smilie"">
		<div class=""text"">:pipe:</div>
		<img alt="""" src=""http://i.somethingawful.com/forumsystem/emoticons/emot-pipe.gif"" title=""Sophistication!"">
	<li class=""smilie"">
		<div class=""text"">:pluto:</div>
		<img alt="""" src=""http://i.somethingawful.com/forumsystem/emoticons/emot-pluto.gif"" title=""Still a planet to us"">
	<li class=""smilie"">
		<div class=""text"">:pranke:</div>
		<img alt="""" src=""http://i.somethingawful.com/forumsystem/emoticons/emot-pranke.gif"" title=""Prankeapple"">
	<li class=""smilie"">
		<div class=""text"">:psyberger:</div>
		<img alt="""" src=""http://i.somethingawful.com/forumsystem/emoticons/emot-psyberger.gif"" title=""AAAAAAAAAAGGGG"">
	<li class=""smilie"">
		<div class=""text"">:psyduck:</div>
		<img alt="""" src=""http://i.somethingawful.com/forumsystem/emoticons/emot-psyduck.gif"" title=""Psy-yi-yi"">
	<li class=""smilie"">
		<div class=""text"">:psylon:</div>
		<img alt="""" src=""http://i.somethingawful.com/forumsystem/emoticons/emot-psylon.gif"" title=""This fracking show!"">
	<li class=""smilie"">
		<div class=""text"">:psypop:</div>
		<img alt="""" src=""http://i.somethingawful.com/forumsystem/emoticons/emot-psypop.gif"" title=""PSY EXPLOSION"">
	<li class=""smilie"">
		<div class=""text"">:pt:</div>
		<img alt="""" src=""http://fi.somethingawful.com/images/smilies/emot-onlyoption.gif"" title=""Only option"">
	<li class=""smilie"">
		<div class=""text"">:q:</div>
		<img alt="""" src=""http://fi.somethingawful.com/images/smilies/emot-q.gif"" title=""Q"">
	<li class=""smilie"">
		<div class=""text"">:qirex:</div>
		<img alt="""" src=""http://fi.somethingawful.com/images/smilies/emot-qirex.gif"" title=""Qirex"">
	<li class=""smilie"">
		<div class=""text"">:ranbowdash:</div>
		<img alt="""" src=""http://fi.somethingawful.com/safs/smilies/7/e/ranbowdash.001.png"" title=""It's gonna be SO Awesome!"">
	<li class=""smilie"">
		<div class=""text"">:redhammer:</div>
		<img alt="""" src=""http://fi.somethingawful.com/images/smilies/emot-redhammer.gif"" title=""The Red Hammer (another waste of money)"">
	<li class=""smilie"">
		<div class=""text"">:rice:</div>
		<img alt="""" src=""http://fi.somethingawful.com/images/smilies/emot-rice.gif"" title=""Ricer"">
	<li class=""smilie"">
		<div class=""text"">:riker:</div>
		<img alt="""" src=""http://i.somethingawful.com/forumsystem/emoticons/emot-riker.gif"" title=""Riker leads the away team"">
	<li class=""smilie"">
		<div class=""text"">:rudebox:</div>
		<img alt="""" src=""http://i.somethingawful.com/forumsystem/emoticons/emot-rudebox.gif"" title=""Shake ya Rudebox!"">
	<li class=""smilie"">
		<div class=""text"">:russbus:</div>
		<img alt="""" src=""http://i.somethingawful.com/forumsystem/emoticons/emot-russbus.gif"" title=""the russ buss"">
	<li class=""smilie"">
		<div class=""text"">:sax:</div>
		<img alt="""" src=""http://fi.somethingawful.com/images/smilies/emot-sax.gif"" title=""Something so monumentally lame that I can't even comprehend it"">
	<li class=""smilie"">
		<div class=""text"">:sharpton:</div>
		<img alt="""" src=""http://fi.somethingawful.com/images/smilies/emot-sharpton.gif"" title=""Reverend Alfred 'Al' Sharpton"">
	<li class=""smilie"">
		<div class=""text"">:shibaz:</div>
		<img alt="""" src=""http://i.somethingawful.com/forumsystem/emoticons/emot-shibaz.png"" title=""shibaz 101"">
	<li class=""smilie"">
		<div class=""text"">:shopkeeper:</div>
		<img alt="""" src=""http://i.somethingawful.com/forumsystem/emoticons/emot-shopkeeper.gif"" title=""Hello THIEF!"">
	<li class=""smilie"">
		<div class=""text"">:signings:</div>
		<img alt="""" src=""http://i.somethingawful.com/forumsystem/emoticons/emot-signings.gif"" title=""Psynings"">
	<li class=""smilie"">
		<div class=""text"">:sissies:</div>
		<img alt="""" src=""http://i.somethingawful.com/forumsystem/emoticons/emot-sissies.gif"" title=""D&amp;D at it's best"">
	<li class=""smilie"">
		<div class=""text"">:slick:</div>
		<img alt="""" src=""http://i.somethingawful.com/forumsystem/emoticons/emot-slick.gif"" title=""You gotta"">
	<li class=""smilie"">
		<div class=""text"">:smugbird:</div>
		<img alt="""" src=""http://i.somethingawful.com/forumsystem/emoticons/emot-smugbird.gif"" title=""Smug Orioles Bird"">
	<li class=""smilie"">
		<div class=""text"">:smugdroid:</div>
		<img alt="""" src=""http://fi.somethingawful.com/safs/smilies/5/9/smugdroid.001.png"" title=""the definition of open"">
	<li class=""smilie"">
		<div class=""text"">:smugndar:</div>
		<img alt="""" src=""http://i.somethingawful.com/forumsystem/emoticons/emot-smugndar.gif"" title=""larasndar"">
	<li class=""smilie"">
		<div class=""text"">:smugteddie:</div>
		<img alt="""" src=""http://i.somethingawful.com/forumsystem/emoticons/emot-smugteddie.gif"" title=""Teddie from Persona 4"">
	<li class=""smilie"">
		<div class=""text"">:snoop:</div>
		<img alt="""" src=""http://i.somethingawful.com/forumsystem/emoticons/emot-snoop.gif"" title=""snoop.gif"">
	<li class=""smilie"">
		<div class=""text"">:solanadumb:</div>
		<img alt="""" src=""http://i.somethingawful.com/forumsystem/emoticons/emot-solanadumb.png"" title=""are u a bark bark"">
	<li class=""smilie"">
		<div class=""text"">:sonia:</div>
		<img alt="""" src=""http://i.somethingawful.com/forumsystem/emoticons/emot-sonia.gif"" title=""Sonia from DPPH"">
	<li class=""smilie"">
		<div class=""text"">:sotw:</div>
		<img alt="""" src=""http://i.somethingawful.com/forumsystem/emoticons/emot-sotw.gif"" title=""Smilie of the Week"">
	<li class=""smilie"">
		<div class=""text"">:spergin:</div>
		<img alt="""" src=""http://i.somethingawful.com/forumsystem/emoticons/emot-spergin.png"" title=""Asperger Syndrome"">
	<li class=""smilie"">
		<div class=""text"">:spooky:</div>
		<img alt="""" src=""http://fi.somethingawful.com/images/smilies/emot-spooky.gif"" title=""Spooky"">
	<li class=""smilie"">
		<div class=""text"">:stalker:</div>
		<img alt="""" src=""http://i.somethingawful.com/forumsystem/emoticons/emot-stalker.gif"" title=""creepy stalker thing"">
	<li class=""smilie"">
		<div class=""text"">:sugartits:</div>
		<img alt="""" src=""http://fi.somethingawful.com/safs/smilies/a/c/sugartits.001.png"" title=""Censored"">
	<li class=""smilie"">
		<div class=""text"">:synpa:</div>
		<img alt="""" src=""http://i.somethingawful.com/forumsystem/emoticons/emot-synpa.gif"" title=""first post on page 2!!!!"">
	<li class=""smilie"">
		<div class=""text"">:syoon:</div>
		<img alt="""" src=""http://fi.somethingawful.com/safs/smilies/d/2/syoon.001.gif"" title=""Syo Swooning"">
	<li class=""smilie"">
		<div class=""text"">:taco:</div>
		<img alt="""" src=""http://i.somethingawful.com/forumsystem/emoticons/emot-taco.gif"" title=""Taco"">
	<li class=""smilie"">
		<div class=""text"">:tastykake:</div>
		<img alt="""" src=""http://fi.somethingawful.com/safs/smilies/5/c/tastykake.001.gif"" title=""PHILLY WHAT"">
	<li class=""smilie"">
		<div class=""text"">:tbear:</div>
		<img alt="""" src=""http://fi.somethingawful.com/images/smilies/emot-trashbear.gif"" title=""Trashbear"">
	<li class=""smilie"">
		<div class=""text"">:techno:</div>
		<img alt="""" src=""http://i.somethingawful.com/forumsystem/emoticons/emot-techno.gif"" title=""technobabble"">
	<li class=""smilie"">
		<div class=""text"">:thurman:</div>
		<img alt="""" src=""http://i.somethingawful.com/forumsystem/emoticons/emot-thurman.gif"" title=""Thurman football dude"">
	<li class=""smilie"">
		<div class=""text"">:toughguy:</div>
		<img alt="""" src=""http://i.somethingawful.com/forumsystem/emoticons/emot-toughguy.gif"" title=""Internet Tough Guy"">
	<li class=""smilie"">
		<div class=""text"">:toxx:</div>
		<img alt="""" src=""http://i.somethingawful.com/forumsystem/emoticons/emot-toxx.gif"" title=""Toxx Clause"">
	<li class=""smilie"">
		<div class=""text"">:troll:</div>
		<img alt="""" src=""http://fi.somethingawful.com/safs/smilies/9/f/troll.001.png"" title=""Are you mad?"">
	<li class=""smilie"">
		<div class=""text"">:tubular:</div>
		<img alt="""" src=""http://i.somethingawful.com/forumsystem/emoticons/emot-tubular.gif"" title=""Tubular, Dude."">
	<li class=""smilie"">
		<div class=""text"">:uhaul:</div>
		<img alt="""" src=""http://i.somethingawful.com/forumsystem/emoticons/emot-uhaul.gif"" title=""Uhaul for leaving TFR"">
	<li class=""smilie"">
		<div class=""text"">:vick:</div>
		<img alt="""" src=""http://i.somethingawful.com/forumsystem/emoticons/emot-vick.gif"" title=""kicks a touchdown"">
	<li class=""smilie"">
		<div class=""text"">:viconia:</div>
		<img alt="""" src=""http://i.somethingawful.com/forumsystem/emoticons/emot-viconia.gif"" title=""bad moon rising"">
	<li class=""smilie"">
		<div class=""text"">:viggo:</div>
		<img alt="""" src=""http://i.somethingawful.com/forumsystem/emoticons/emot-viggo.gif"" title=""Smug scholar"">
	<li class=""smilie"">
		<div class=""text"">:whatup:</div>
		<img alt="""" src=""http://i.somethingawful.com/forumsystem/emoticons/emot-whatup.gif"" title=""sup"">
	<li class=""smilie"">
		<div class=""text"">:wink:</div>
		<img alt="""" src=""http://i.somethingawful.com/forumsystem/emoticons/emot-wink.gif"" title=""wink"">
	<li class=""smilie"">
		<div class=""text"">:wmwink:</div>
		<img alt="""" src=""http://i.somethingawful.com/forumsystem/emoticons/emot-wmwink.png"" title=""The mouth to wink"">
	<li class=""smilie"">
		<div class=""text"">:wom:</div>
		<img alt="""" src=""http://i.somethingawful.com/forumsystem/emoticons/emot-wom.gif"" title=""WOM WOM WOM WOM"">
	<li class=""smilie"">
		<div class=""text"">:woof:</div>
		<img alt="""" src=""http://i.somethingawful.com/forumsystem/emoticons/emot-woof.gif"" title=""God Woof! Woof! is a Fag"">
	<li class=""smilie"">
		<div class=""text"">:wooper:</div>
		<img alt="""" src=""http://i.somethingawful.com/forumsystem/emoticons/emot-wooper.gif"" title=""woopaaaah woopaaaaah"">
	<li class=""smilie"">
		<div class=""text"">:xie:</div>
		<img alt="""" src=""http://i.somethingawful.com/forumsystem/emoticons/emot-xie.gif"" title=""Yanks postseason troubles"">
	<li class=""smilie"">
		<div class=""text"">:yosbutt:</div>
		<img alt="""" src=""http://fi.somethingawful.com/safs/smilies/5/8/yosbutt.001.gif"" title=""i drop jorts+shake my neg ass @u"">
	<li class=""smilie"">
		<div class=""text"">:zerg:</div>
		<img alt="""" src=""http://fi.somethingawful.com/images/smilies/emot-zerg.gif"" title=""ZERG RUSH!!!"">
</ul>

<h3>Hey everybody I'm on drugs!</h3>
<ul class=""smilie_group"">
	<li class=""smilie"">
		<div class=""text"">:2bong:</div>
		<img alt="""" src=""http://i.somethingawful.com/forumsystem/emoticons/emot-2bong.png"" title=""TWO BONGS AT ONCE"">
	<li class=""smilie"">
		<div class=""text"">:350:</div>
		<img alt="""" src=""http://i.somethingawful.com/forumsystem/emoticons/emot-350.gif"" title=""shivadas"">
	<li class=""smilie"">
		<div class=""text"">:420:</div>
		<img alt="""" src=""http://fi.somethingawful.com/images/smilies/emot-weed.gif"" title=""Some horrible drug thing!"">
	<li class=""smilie"">
		<div class=""text"">:catdrugs:</div>
		<img alt="""" src=""http://i.somethingawful.com/forumsystem/emoticons/emot-catdrugs.gif"" title=""CAT DRUGS"">
	<li class=""smilie"">
		<div class=""text"">:chillpill:</div>
		<img alt="""" src=""http://fi.somethingawful.com/safs/smilies/3/2/chillpill.001.gif"" title=""Chill your pill dude"">
	<li class=""smilie"">
		<div class=""text"">:dominic:</div>
		<img alt="""" src=""http://i.somethingawful.com/forumsystem/emoticons/emot-dominic.gif"" title=""repurchase Dominic"">
	<li class=""smilie"">
		<div class=""text"">:drugnerd:</div>
		<img alt="""" src=""http://i.somethingawful.com/forumsystem/emoticons/emot-drugnerd.gif"" title=""Good nerds got the hookup"">
	<li class=""smilie"">
		<div class=""text"">:lsd:</div>
		<img alt="""" src=""http://i.somethingawful.com/forumsystem/emoticons/emot-lsd.gif"" title=""Ingestion of LSD"">
	<li class=""smilie"">
		<div class=""text"">:obama:</div>
		<img alt="""" src=""http://i.somethingawful.com/forumsystem/emoticons/emot-obama.gif"" title=""Obama is 44th"">
	<li class=""smilie"">
		<div class=""text"">:okpos:</div>
		<img alt="""" src=""http://fi.somethingawful.com/safs/smilies/1/b/okpos.001.gif"" title=""stare with a bong"">
	<li class=""smilie"">
		<div class=""text"">:rory:</div>
		<img alt="""" src=""http://fi.somethingawful.com/images/smilies/rainbow.gif"" title=""rainbow"">
	<li class=""smilie"">
		<div class=""text"">:shroom:</div>
		<img alt="""" src=""http://i.somethingawful.com/forumsystem/emoticons/emot-shroom.gif"" title=""Flashing Mushroom"">
	<li class=""smilie"">
		<div class=""text"">:tinsley:</div>
		<img alt="""" src=""http://fi.somethingawful.com/customtitles/eris/classic_fillmore.gif"" title=""Glug glug glug, time to write a strip"">
	<li class=""smilie"">
		<div class=""text"">:weed:</div>
		<img alt="""" src=""http://i.somethingawful.com/forumsystem/emoticons/emot-weed.gif"" title=""A ball of weed"">
</ul>

<h3>New / Uncategorized</h3>
<ul class=""smilie_group"">
	<li class=""smilie"">
		<div class=""text"">:agesilaus:</div>
		<img alt="""" src=""http://fi.somethingawful.com/safs/smilies/7/2/agesilaus.001.png"" title=""Smug about Sparta"">
	<li class=""smilie"">
		<div class=""text"">:anasta:</div>
		<img alt="""" src=""http://fi.somethingawful.com/safs/smilies/b/d/anasta.001.jpg"" title=""Braith Anasta's head"">
	<li class=""smilie"">
		<div class=""text"">:bape:</div>
		<img alt="""" src=""http://fi.somethingawful.com/safs/smilies/a/9/bape.001.png"" title=""good pic"">
	<li class=""smilie"">
		<div class=""text"">:bsdsnype:</div>
		<img alt="""" src=""http://fi.somethingawful.com/safs/smilies/6/d/bsdsnype.001.gif"" title=""set sail for snype with bsd boys"">
	<li class=""smilie"">
		<div class=""text"">:byob1:</div>
		<img alt="""" src=""http://fi.somethingawful.com/safs/smilies/b/c/byob1.001.png"" title=""posting pals 4 lyfe"">
	<li class=""smilie"">
		<div class=""text"">:cabot:</div>
		<img alt="""" src=""http://fi.somethingawful.com/safs/smilies/3/9/cabot.001.png"" title=""~*CU ON THE CROSSROADS*~"">
	<li class=""smilie"">
		<div class=""text"">:catbert:</div>
		<img alt="""" src=""http://fi.somethingawful.com/safs/smilies/2/3/catbert.001.gif"" title=""Catstare. Bert."">
	<li class=""smilie"">
		<div class=""text"">:ccp:</div>
		<img alt="""" src=""http://fi.somethingawful.com/safs/smilies/4/a/ccp.001.gif"" title=""LAG LAG LAG LAG LAG LAG LAG LAG"">
	<li class=""smilie"">
		<div class=""text"">:classiclol:</div>
		<img alt="""" src=""http://fi.somethingawful.com/safs/smilies/a/8/classiclol.001.gif"" title=""It just stares at you"">
	<li class=""smilie"">
		<div class=""text"">:corrupt:</div>
		<img alt="""" src=""http://fi.somethingawful.com/safs/smilies/9/e/corrupt.001.gif"" title=""what's wrong?"">
	<li class=""smilie"">
		<div class=""text"">:csgo:</div>
		<img alt="""" src=""http://fi.somethingawful.com/safs/smilies/8/6/csgo.001.gif"" title=""Rollin Headshots"">
	<li class=""smilie"">
		<div class=""text"">:cult:</div>
		<img alt="""" src=""http://fi.somethingawful.com/safs/smilies/5/2/cult.001.jpg"" title=""wearepedostate"">
	<li class=""smilie"">
		<div class=""text"">:effortless:</div>
		<img alt="""" src=""http://fi.somethingawful.com/safs/smilies/1/1/effortless.001.gif"" title=""For effortposts."">
	<li class=""smilie"">
		<div class=""text"">:fedora:</div>
		<img alt="""" src=""http://fi.somethingawful.com/safs/smilies/1/8/fedora.001.png"" title=""SA likes a dapper fedora."">
	<li class=""smilie"">
		<div class=""text"">:freep:</div>
		<img alt="""" src=""http://fi.somethingawful.com/safs/smilies/9/e/freep.001.gif"" title=""All the worst parts of the Right"">
	<li class=""smilie"">
		<div class=""text"">:gas:</div>
		<img alt="""" src=""http://fi.somethingawful.com/safs/smilies/9/b/gas.001.gif"" title=""A cloud of gas."">
	<li class=""smilie"">
		<div class=""text"">:gerty:</div>
		<img alt="""" src=""http://fi.somethingawful.com/safs/smilies/0/4/gerty.001.png"" title=""Helping you is what I do, Sam"">
	<li class=""smilie"">
		<div class=""text"">:ghitler:</div>
		<img alt="""" src=""http://fi.somethingawful.com/safs/smilies/e/b/ghitler.001.png"" title=""Patron saint of EU tank goons"">
	<li class=""smilie"">
		<div class=""text"">:gogtears:</div>
		<img alt="""" src=""http://fi.somethingawful.com/safs/smilies/d/a/gogtears.001.gif"" title=""Good Old Games Sales"">
	<li class=""smilie"">
		<div class=""text"">:gop:</div>
		<img alt="""" src=""http://fi.somethingawful.com/safs/smilies/d/2/gop.001.gif"" title=""GOP"">
	<li class=""smilie"">
		<div class=""text"">:gowron:</div>
		<img alt="""" src=""http://fi.somethingawful.com/safs/smilies/a/4/gowron.001.gif"" title=""gowron"">
	<li class=""smilie"">
		<div class=""text"">:guinness:</div>
		<img alt="""" src=""http://fi.somethingawful.com/safs/smilies/2/0/guinness.001.gif"" title=""Drink up!"">
	<li class=""smilie"">
		<div class=""text"">:hawksin:</div>
		<img alt="""" src=""http://fi.somethingawful.com/safs/smilies/d/3/hawksin.001.gif"" title=""go the seahawks bitch"">
	<li class=""smilie"">
		<div class=""text"">:hirez:</div>
		<img alt="""" src=""http://fi.somethingawful.com/safs/smilies/8/7/hirez.001.gif"" title=""hirez  game studios"">
	<li class=""smilie"">
		<div class=""text"">:histdowns:</div>
		<img alt="""" src=""http://fi.somethingawful.com/safs/smilies/e/9/histdowns.001.gif"" title=""A Shameful Display!"">
	<li class=""smilie"">
		<div class=""text"">:homebrew:</div>
		<img alt="""" src=""http://fi.somethingawful.com/safs/smilies/9/c/homebrew.001.gif"" title=""Throwing money in air"">
	<li class=""smilie"">
		<div class=""text"">:ins:</div>
		<img alt="""" src=""http://fi.somethingawful.com/safs/smilies/1/5/ins.001.gif"" title=""Insert"">
	<li class=""smilie"">
		<div class=""text"">:itwaspoo:</div>
		<img alt="""" src=""http://fi.somethingawful.com/safs/smilies/6/f/itwaspoo.001.gif"" title=""Fine Australian Journalism"">
	<li class=""smilie"">
		<div class=""text"">:jebstare:</div>
		<img alt="""" src=""http://fi.somethingawful.com/safs/smilies/2/1/jebstare.001.png"" title=""Something has gone wrong."">
	<li class=""smilie"">
		<div class=""text"">:kheldragar:</div>
		<img alt="""" src=""http://fi.somethingawful.com/safs/smilies/8/7/kheldragar.001.gif"" title=""This is how I always viewed it."">
	<li class=""smilie"">
		<div class=""text"">:krakentoot:</div>
		<img alt="""" src=""http://fi.somethingawful.com/safs/smilies/d/f/krakentoot.001.gif"" title=""Beat like a red headed stepchild"">
	<li class=""smilie"">
		<div class=""text"">:livintrope:</div>
		<img alt="""" src=""http://fi.somethingawful.com/safs/smilies/8/c/livintrope.001.gif"" title=""look at this mess!"">
	<li class=""smilie"">
		<div class=""text"">:lumpen:</div>
		<img alt="""" src=""http://fi.somethingawful.com/safs/smilies/3/0/lumpen.001.gif"" title=""There is no truth beyond magic"">
	<li class=""smilie"">
		<div class=""text"">:lurkmore:</div>
		<img alt="""" src=""http://fi.somethingawful.com/safs/smilies/2/d/lurkmore.001.gif"" title=""Lurk more before posting!"">
	<li class=""smilie"">
		<div class=""text"">:magical:</div>
		<img alt="""" src=""http://fi.somethingawful.com/safs/smilies/5/c/magical.001.png"" title=""This is just MAGICAL"">
	<li class=""smilie"">
		<div class=""text"">:marc:</div>
		<img alt="""" src=""http://fi.somethingawful.com/safs/smilies/c/a/marc.001.gif"" title=""it's a toot butt"">
	<li class=""smilie"">
		<div class=""text"">:mensch:</div>
		<img alt="""" src=""http://fi.somethingawful.com/safs/smilies/8/e/mensch.001.gif"" title=""Iraqi Information Minister"">
	<li class=""smilie"">
		<div class=""text"">:mil101:</div>
		<img alt="""" src=""http://fi.somethingawful.com/safs/smilies/5/9/mil101.001.gif"" title=""Goddam civilians don't know shit"">
	<li class=""smilie"">
		<div class=""text"">:moments:</div>
		<img alt="""" src=""http://fi.somethingawful.com/safs/smilies/5/3/moments.001.gif"" title=""Wake up, Thanny..."">
	<li class=""smilie"">
		<div class=""text"">:mrgw2:</div>
		<img alt="""" src=""http://fi.somethingawful.com/safs/smilies/e/1/mrgw2.001.png"" title=""Mr Green Water 2"">
	<li class=""smilie"">
		<div class=""text"">:mrgw:</div>
		<img alt="""" src=""http://fi.somethingawful.com/safs/smilies/3/6/mrgw.001.png"" title=""Mister Green Water"">
	<li class=""smilie"">
		<div class=""text"">:newt:</div>
		<img alt="""" src=""http://fi.somethingawful.com/images/smilies/emot-newt.png"" title=""Smug Newt (Gingrich)"">
	<li class=""smilie"">
		<div class=""text"">:nexus:</div>
		<img alt="""" src=""http://fi.somethingawful.com/safs/smilies/7/3/nexus.001.png"" title=""it is a bad phone"">
	<li class=""smilie"">
		<div class=""text"">:nignog:</div>
		<img alt="""" src=""http://fi.somethingawful.com/safs/smilies/3/9/nignog.001.gif"" title=""Hello I like anime videogames."">
	<li class=""smilie"">
		<div class=""text"">:nitecrew:</div>
		<img alt="""" src=""http://fi.somethingawful.com/safs/smilies/f/c/nitecrew.001.gif"" title=""Never. Stop. Posting."">
	<li class=""smilie"">
		<div class=""text"">:notch:</div>
		<img alt="""" src=""http://fi.somethingawful.com/safs/smilies/e/1/notch.001.png"" title=""Notch of Minecraft fame"">
	<li class=""smilie"">
		<div class=""text"">:nsa:</div>
		<img alt="""" src=""http://fi.somethingawful.com/safs/smilies/d/a/nsa.001.png"" title=""the govt is reading ur yosposts"">
	<li class=""smilie"">
		<div class=""text"">:ocelot:</div>
		<img alt="""" src=""http://i.somethingawful.com/forumsystem/emoticons/emot-ocelot.gif"" title=""You're pretty good!"">
	<li class=""smilie"">
		<div class=""text"">:omarcomin:</div>
		<img alt="""" src=""http://fi.somethingawful.com/safs/smilies/7/1/omarcomin.001.gif"" title=""It's all in the game"">
	<li class=""smilie"">
		<div class=""text"">:orks101:</div>
		<img alt="""" src=""http://fi.somethingawful.com/safs/smilies/d/e/orks101.001.gif"" title=""Green is best"">
	<li class=""smilie"">
		<div class=""text"">:ortiz:</div>
		<img alt="""" src=""http://fi.somethingawful.com/safs/smilies/0/b/ortiz.001.png"" title=""Good even ladies in gentlemens"">
	<li class=""smilie"">
		<div class=""text"">:patssay:</div>
		<img alt="""" src=""http://fi.somethingawful.com/safs/smilies/c/8/patssay.001.gif"" title=""Average Patriots fan"">
	<li class=""smilie"">
		<div class=""text"">:pgi:</div>
		<img alt="""" src=""http://fi.somethingawful.com/safs/smilies/a/2/pgi.001.gif"" title=""Cause PGI!"">
	<li class=""smilie"">
		<div class=""text"">:pilot:</div>
		<img alt="""" src=""http://fi.somethingawful.com/safs/smilies/e/1/pilot.001.gif"" title=""Pilot"">
	<li class=""smilie"">
		<div class=""text"">:radcat:</div>
		<img alt="""" src=""http://fi.somethingawful.com/safs/smilies/a/0/radcat.001.png"" title=""oh no oh no i am a rad cat"">
	<li class=""smilie"">
		<div class=""text"">:regd13:</div>
		<img alt="""" src=""http://fi.somethingawful.com/safs/smilies/0/9/regd13.001.gif"" title=""A small bart."">
	<li class=""smilie"">
		<div class=""text"">:rip:</div>
		<img alt="""" src=""http://fi.somethingawful.com/safs/smilies/b/2/rip.001.gif"" title=""rip"">
	<li class=""smilie"">
		<div class=""text"">:rms2:</div>
		<img alt="""" src=""http://fi.somethingawful.com/safs/smilies/2/2/rms2.001.png"" title=""Free as in Freedom"">
	<li class=""smilie"">
		<div class=""text"">:romo:</div>
		<img alt="""" src=""http://fi.somethingawful.com/safs/smilies/8/6/romo.001.png"" title=""Tony RomOWNED"">
	<li class=""smilie"">
		<div class=""text"">:russo:</div>
		<img alt="""" src=""http://fi.somethingawful.com/safs/smilies/2/e/russo.001.gif"" title=""Vince Russo"">
	<li class=""smilie"">
		<div class=""text"">:sadwave:</div>
		<img alt="""" src=""http://fi.somethingawful.com/safs/smilies/2/e/sadwave.001.gif"" title=""Yeah, I feel ya man"">
	<li class=""smilie"">
		<div class=""text"">:shepspends:</div>
		<img alt="""" src=""http://fi.somethingawful.com/safs/smilies/8/c/shepspends.001.gif"" title=""I just gotta have one!"">
	<li class=""smilie"">
		<div class=""text"">:shibewow:</div>
		<img alt="""" src=""http://fi.somethingawful.com/safs/smilies/a/5/shibewow.001.gif"" title=""so text"">
	<li class=""smilie"">
		<div class=""text"">:shrek:</div>
		<img alt="""" src=""http://fi.somethingawful.com/safs/smilies/2/0/shrek.001.gif"" title=""peanut butta nigga"">
	<li class=""smilie"">
		<div class=""text"">:smithcloud:</div>
		<img alt="""" src=""http://fi.somethingawful.com/safs/smilies/8/9/smithcloud.001.gif"" title=""iCloud icon with :smith:"">
	<li class=""smilie"">
		<div class=""text"">:smugjones:</div>
		<img alt="""" src=""http://fi.somethingawful.com/safs/smilies/a/b/smugjones.001.gif"" title=""[Tell] me about dinosaurs"">
	<li class=""smilie"">
		<div class=""text"">:smugwizard:</div>
		<img alt="""" src=""http://fi.somethingawful.com/safs/smilies/2/b/smugwizard.001.png"" title=""Smug Wizard"">
	<li class=""smilie"">
		<div class=""text"">:soe:</div>
		<img alt="""" src=""http://fi.somethingawful.com/safs/smilies/a/1/soe.001.gif"" title=""SOE"">
	<li class=""smilie"">
		<div class=""text"">:sparkles:</div>
		<img alt="""" src=""http://fi.somethingawful.com/safs/smilies/7/d/sparkles.001.gif"" title=""A V face sparkling like an idiot"">
	<li class=""smilie"">
		<div class=""text"">:sterv:</div>
		<img alt="""" src=""http://fi.somethingawful.com/safs/smilies/0/3/sterv.001.gif"" title=""Oblivion.gif"">
	<li class=""smilie"">
		<div class=""text"">:stonkhat:</div>
		<img alt="""" src=""http://fi.somethingawful.com/safs/smilies/0/9/stonkhat.001.gif"" title="":stonkhat:"">
	<li class=""smilie"">
		<div class=""text"">:stonklol:</div>
		<img alt="""" src=""http://fi.somethingawful.com/safs/smilies/3/7/stonklol.001.gif"" title=""Disturbamusing."">
	<li class=""smilie"">
		<div class=""text"">:temporary:</div>
		<img alt="""" src=""http://fi.somethingawful.com/safs/smilies/e/6/temporary.001.gif"" title=""created to be deleted"">
	<li class=""smilie"">
		<div class=""text"">:tfrxmas:</div>
		<img alt="""" src=""http://fi.somethingawful.com/safs/smilies/a/6/tfrxmas.001.gif"" title=""self explanatory"">
	<li class=""smilie"">
		<div class=""text"">:thx:</div>
		<img alt="""" src=""http://fi.somethingawful.com/safs/smilies/3/3/thx.001.gif"" title=""bwaaaaa-eeeeeerrrrrrrrrrrrrrr"">
	<li class=""smilie"">
		<div class=""text"">:tootzzz:</div>
		<img alt="""" src=""http://fi.somethingawful.com/safs/smilies/d/7/tootzzz.001.png"" title=""Sleepy time"">
	<li class=""smilie"">
		<div class=""text"">:torgue:</div>
		<img alt="""" src=""http://fi.somethingawful.com/safs/smilies/9/3/torgue.001.gif"" title=""Mr Torgue. EXPLOSIONS!"">
	<li class=""smilie"">
		<div class=""text"">:toxogond:</div>
		<img alt="""" src=""http://fi.somethingawful.com/safs/smilies/5/a/toxogond.001.gif"" title=""toxoplasmosis gondii"">
	<li class=""smilie"">
		<div class=""text"">:valvebeta:</div>
		<img alt="""" src=""http://fi.somethingawful.com/safs/smilies/6/3/valvebeta.001.png"" title=""Valve beta cards"">
	<li class=""smilie"">
		<div class=""text"">:wankah:</div>
		<img alt="""" src=""http://fi.somethingawful.com/safs/smilies/6/c/wankah.001.gif"" title=""Pukka bootstraps, guvnah."">
	<li class=""smilie"">
		<div class=""text"">:wave:</div>
		<img alt="""" src=""http://fi.somethingawful.com/safs/smilies/3/b/wave.001.gif"" title=""Hello there!"">
	<li class=""smilie"">
		<div class=""text"">:wiggle:</div>
		<img alt="""" src=""http://fi.somethingawful.com/safs/smilies/3/3/wiggle.001.gif"" title=""doin the wily"">
	<li class=""smilie"">
		<div class=""text"">:wow:</div>
		<img alt="""" src=""http://fi.somethingawful.com/safs/smilies/b/0/wow.001.gif"" title=""Wolf Blitzer"">
	<li class=""smilie"">
		<div class=""text"">:xbone:</div>
		<img alt="""" src=""http://fi.somethingawful.com/safs/smilies/f/0/xbone.001.gif"" title=""Xbone!"">
	<li class=""smilie"">
		<div class=""text"">:yayclod:</div>
		<img alt="""" src=""http://fi.somethingawful.com/safs/smilies/0/7/yayclod.001.png"" title=""Some kind of happy cloud thing"">
	<li class=""smilie"">
		<div class=""text"">:yaycloud:</div>
		<img alt="""" src=""http://fi.somethingawful.com/safs/smilies/a/4/yaycloud.001.gif"" title=""The cloud touches us everywhere"">
</ul>



	<br style=""clear:both;"">
	<br>
	If you want to disable smilies in a post that you make,
	you can select the 'Disable Smilies' option when posting.
	This is particularly useful if you are posting program code and you do not want <b>;)</b> converted to a smilie face!
	</div>
</div>

</div><!-- #content -->
	<ul class=""navigation"">
<li class=""first""><a href=""/index.php"">SA Forums</a></li>
<li>- <a href=""http://www.somethingawful.com/"">Something Awful</a></li>
<li>- <a href=""/f/search"">Search the Forums</a></li>
<li>- <a href=""/usercp.php"">User Control Panel</a></li>
<li>- <a href=""/private.php"">Private Messages</a></li>
<li>- <a href=""http://www.somethingawful.com/d/forum-rules/forum-rules.php"">Forum Rules</a></li>
<li>- <a href=""/dictionary.php"">SAclopedia</a></li>
<li>- <a href=""/stats.php"">Posting Gloryhole</a></li>
<li>- <a href=""/banlist.php"">Leper's Colony</a></li>
<li>- <a href=""/supportmail.php"">Support</a></li>
<li>- <a href=""/account.php?action=logout&amp;ma=10293618"">Log Out</a></li>

</ul>
	<div id=""copyright"">
		Powered by: vBulletin Version 2.2.9 (<a href=""/CHANGES"">SAVB-v2.1.17</a>)<br>
		Copyright &copy;2000, 2001, Jelsoft Enterprises Limited.<br>
		Copyright &copy;2012, Something Awful LLC<br>
	</div>

</div><!-- #container -->

<script type=""text/javascript"">
	// quantcast
	_qoptions = { qacct:""p-82vTvmw-enlng"" };

	try {
		if(document.location.hostname != 'forums.somethingawful.com')
			throw undefined;

		$(document).ready(function() {
			var qcUrl = 'http://edge.quantserve.com/quant.js';
			jQuery.getScript(qcUrl);

			var gaJsHost = ((""https:"" == document.location.protocol) ? ""https://ssl."" : ""http://www."");
			var gaUrl = gaJsHost + 'google-analytics.com/ga.js';
			jQuery.getScript(gaUrl, function() {
				var pageTracker = _gat._getTracker(""UA-3064978-2"");
				pageTracker._initData();
				pageTracker._trackPageview();
			});
		});
	} catch(e) {};

	// indie
	// try {
	// 	if(document.location.hostname != 'forums.somethingawful.com')
	// 		throw undefined;

	// 	$(document).ready(function() {
	// 		var ic_element = document.createElement('script');
	// 		ic_element.type = 'text/javascript';
	// 		ic_element.async = true;
	// 		ic_element.id = 'ic_annonymous_pixel';
	// 		ic_element.src = 'http://pixel.indieclick.com/annonymous/domain/somethingawful.com/reach/script_ic.js';
	// 		var ic_script = document.getElementsByTagName('script')[0];
	// 		ic_script.parentNode.insertBefore(ic_element, ic_script);
	// 	});
	// } catch(e) {};
</script>
<noscript><img src=""http://pixel.quantserve.com/pixel/p-82vTvmw-enlng.gif"" style=""display:none;"" border=""0"" height=""1"" width=""1"" alt=""Quantcast""></noscript>

<!-- PLEASE DO NOT REMOVE -->
<ol id=""debug"" style=""display:none""><li>&nbsp;</ol>

</body>
</html>";
        }
        public virtual string GenerateMockForumIndexHtml()
        {
            return @"<!DOCTYPE html>
<html lang=""en"">
<head>
	<title>GBS 1.4 - The Something Awful Forums</title>
	
	<meta name=""MSSmartTagsPreventParsing"" content=""TRUE"">
	<meta http-equiv=""X-UA-Compatible"" content=""chrome=1"">
	<!--[if lt IE 7]><link rel=""stylesheet"" type=""text/css"" href=""/css/ie.css?1348360344""><![endif]-->
	<!--[if lt IE 8]><link rel=""stylesheet"" type=""text/css"" href=""/css/ie7.css?1348360344""><![endif]-->
	<link rel=""apple-touch-icon"" href=""http://i.somethingawful.com/core/icon/iphone-touch/forums.png"">
	<link rel=""stylesheet"" type=""text/css"" href=""/css/main.css?1359594161"">
	<link rel=""stylesheet"" type=""text/css"" href=""/css/bbcode.css?1348360344"">
	<link rel=""stylesheet"" type=""text/css"" href=""http://www.somethingawful.com/globalcss/globalmenu.css"">

	

	<!-- <script src=""/__utm.js"" type=""text/javascript""></script> -->
	<!-- script src=""/js/dojo/dojo.js?1348360344"" type=""text/javascript""></script -->
	<script type=""text/javascript"" src=""//ajax.googleapis.com/ajax/libs/jquery/1.8.3/jquery.min.js""></script>
	<link rel=""stylesheet"" type=""text/css"" href=""//ajax.googleapis.com/ajax/libs/jqueryui/1.9.2/themes/redmond/jquery-ui.css"">
	<script type=""text/javascript"" src=""//ajax.googleapis.com/ajax/libs/jqueryui/1.9.2/jquery-ui.min.js""></script>

	<link rel=""stylesheet"" type=""text/css"" href=""http://www.somethingawful.com/css/forums.css?7"">

	

	<script type=""text/javascript"">
		
		
		
		
	</script>

	<script type=""text/javascript"" src=""/js/vb/forums.combined.js?1359653372""></script>

	

	<!-- ts-specific includes -->
	
	
	

	

	

	

	<style type=""text/css"">
		table#forum tbody tr.thread td.star { display:none; }
		table#forum thead tr th.star { display:none; }
	</style>

</head>
<body id=""something_awful"" class=""forumdisplay forum_1"" data-forum=""1"">

<div id=""globalmenu"">
	<ul>
		<li class=""first""><a href=""https://secure.somethingawful.com/"">Buy Forum Stuff</a></li>
		<li><a href=""http://www.somethingawful.com/"">Something Awful</a></li>
	</ul>
</div>



<div id=""container"">



	

	<ul id=""nav_purchase"">
		<li><b>Purchase:</b></li>
		<li><a href=""https://secure.somethingawful.com/products/register.php"">Account</a></li>
		<li>- <a href=""https://secure.somethingawful.com/products/platinum.php"">Platinum Upgrade</a></li>
		<li>- <a href=""https://secure.somethingawful.com/products/titlechange.php"">New Avatar</a></li>
		<li>- <a href=""https://secure.somethingawful.com/products/titlechange.php"">Other's Avatar</a></li>
		<li>- <a href=""https://secure.somethingawful.com/products/archives.php"">Archives</a></li>
		<li>- <a href=""https://secure.somethingawful.com/products/noads.php"">No-Ads</a></li>
		<li>- <a href=""https://secure.somethingawful.com/products/namechange.php"">New Username</a></li>
		<li>- <a href=""https://secure.somethingawful.com/products/ad-banner.php"">Banner Advertisement</a></li>
		<li>- <a href=""https://secure.somethingawful.com/products/smilie.php"">Smilie</a></li>
		<li>- <a href=""https://secure.somethingawful.com/products/sticky-thread.php"">Stick Thread</a></li>
		<li>- <a href=""https://secure.somethingawful.com/products/gift-certificate.php"">Gift Cert.</a></li>
	</ul>

	<ul id=""navigation"" class=""navigation"">
<li class=""first""><a href=""/index.php"">SA Forums</a></li>
<li>- <a href=""http://www.somethingawful.com/"">Something Awful</a></li>
<li>- <a href=""/f/search"">Search the Forums</a></li>
<li>- <a href=""/usercp.php"">User Control Panel</a></li>
<li>- <a href=""/private.php"">Private Messages</a></li>
<li>- <a href=""http://www.somethingawful.com/d/forum-rules/forum-rules.php"">Forum Rules</a></li>
<li>- <a href=""/dictionary.php"">SAclopedia</a></li>
<li>- <a href=""/stats.php"">Posting Gloryhole</a></li>
<li>- <a href=""/banlist.php"">Leper's Colony</a></li>
<li>- <a href=""/supportmail.php"">Support</a></li>
<li>- <a href=""/account.php?action=logout&amp;ma=10293618"">Log Out</a></li>

</ul>


<div class=""oma_pal"">
	<!--  Begin Rubicon Project Tag -->
<!--  Site: Something Awful LLC   Zone: Forum ATF Top Quality - Mobile, Pop, Web   Size: Leaderboard  -->
<!--  PLACEMENT: Above the Fold  -->
<script language=""JavaScript"" type=""text/javascript"">
rp_account   = '8539';
rp_site      = '13831';
rp_zonesize  = '80354-2';
rp_adtype    = 'iframe';
rp_width     = '728';
rp_height    = '90';
rp_smartfile = 'http://www.somethingawful.com/revv_smart_file.html';
</script>
<script type=""text/javascript"" src=""https://ads.rubiconproject.com/ad/8539.js""></script>
<!--  End Rubicon Project Tag -->
</div>





	<div id=""content"">

	



<div class=""pages top""><span class=""disabled"">&laquo;</span><span class=""disabled"">&lsaquo;</span><select data-url=""forumdisplay.php?forumid=1&amp;daysprune=15&amp;perpage=40&amp;posticon=0&amp;sortorder=desc&amp;sortfield=lastpost""><option value=""1"" selected=""selected"">1</option><option value=""2"">2</option><option value=""3"">3</option><option value=""4"">4</option><option value=""5"">5</option><option value=""6"">6</option><option value=""7"">7</option><option value=""8"">8</option><option value=""9"">9</option><option value=""10"">10</option><option value=""11"">11</option><option value=""12"">12</option><option value=""13"">13</option><option value=""14"">14</option><option value=""15"">15</option><option value=""16"">16</option><option value=""17"">17</option><option value=""18"">18</option><option value=""19"">19</option><option value=""20"">20</option><option value=""21"">21</option><option value=""22"">22</option><option value=""23"">23</option><option value=""24"">24</option><option value=""25"">25</option><option value=""26"">26</option><option value=""27"">27</option><option value=""28"">28</option><option value=""29"">29</option><option value=""30"">30</option><option value=""31"">31</option><option value=""32"">32</option><option value=""33"">33</option><option value=""34"">34</option><option value=""35"">35</option><option value=""36"">36</option><option value=""37"">37</option><option value=""38"">38</option><option value=""39"">39</option><option value=""40"">40</option><option value=""41"">41</option><option value=""42"">42</option><option value=""43"">43</option><option value=""44"">44</option><option value=""45"">45</option><option value=""46"">46</option><option value=""47"">47</option><option value=""48"">48</option><option value=""49"">49</option><option value=""50"">50</option><option value=""51"">51</option><option value=""52"">52</option><option value=""53"">53</option><option value=""54"">54</option><option value=""55"">55</option><option value=""56"">56</option><option value=""57"">57</option><option value=""58"">58</option><option value=""59"">59</option><option value=""60"">60</option><option value=""61"">61</option><option value=""62"">62</option><option value=""63"">63</option><option value=""64"">64</option><option value=""65"">65</option><option value=""66"">66</option><option value=""67"">67</option><option value=""68"">68</option><option value=""69"">69</option><option value=""70"">70</option><option value=""71"">71</option><option value=""72"">72</option><option value=""73"">73</option><option value=""74"">74</option><option value=""75"">75</option><option value=""76"">76</option><option value=""77"">77</option><option value=""78"">78</option><option value=""79"">79</option><option value=""80"">80</option><option value=""81"">81</option><option value=""82"">82</option><option value=""83"">83</option><option value=""84"">84</option><option value=""85"">85</option><option value=""86"">86</option><option value=""87"">87</option><option value=""88"">88</option><option value=""89"">89</option><option value=""90"">90</option><option value=""91"">91</option><option value=""92"">92</option><option value=""93"">93</option><option value=""94"">94</option><option value=""95"">95</option><option value=""96"">96</option><option value=""97"">97</option><option value=""98"">98</option><option value=""99"">99</option><option value=""100"">100</option><option value=""101"">101</option><option value=""102"">102</option><option value=""103"">103</option><option value=""104"">104</option><option value=""105"">105</option><option value=""106"">106</option><option value=""107"">107</option><option value=""108"">108</option><option value=""109"">109</option><option value=""110"">110</option><option value=""111"">111</option><option value=""112"">112</option><option value=""113"">113</option><option value=""114"">114</option><option value=""115"">115</option><option value=""116"">116</option><option value=""117"">117</option><option value=""118"">118</option><option value=""119"">119</option><option value=""120"">120</option><option value=""121"">121</option><option value=""122"">122</option><option value=""123"">123</option><option value=""124"">124</option><option value=""125"">125</option><option value=""126"">126</option><option value=""127"">127</option><option value=""128"">128</option><option value=""129"">129</option><option value=""130"">130</option><option value=""131"">131</option><option value=""132"">132</option><option value=""133"">133</option><option value=""134"">134</option><option value=""135"">135</option><option value=""136"">136</option><option value=""137"">137</option><option value=""138"">138</option><option value=""139"">139</option><option value=""140"">140</option><option value=""141"">141</option><option value=""142"">142</option><option value=""143"">143</option><option value=""144"">144</option><option value=""145"">145</option><option value=""146"">146</option><option value=""147"">147</option><option value=""148"">148</option><option value=""149"">149</option><option value=""150"">150</option><option value=""151"">151</option><option value=""152"">152</option><option value=""153"">153</option><option value=""154"">154</option><option value=""155"">155</option></select><a href=""forumdisplay.php?forumid=1&amp;daysprune=15&amp;perpage=40&amp;posticon=0&amp;sortorder=desc&amp;sortfield=lastpost&pagenumber=2"" title=""Next page"">&rsaquo;</a><a href=""forumdisplay.php?forumid=1&amp;daysprune=15&amp;perpage=40&amp;posticon=0&amp;sortorder=desc&amp;sortfield=lastpost&pagenumber=155"" title=""Last page"">155 &raquo;</a></div>
<div class=""breadcrumbs""><span class=""mainbodytextlarge""><b><a href=""/"">The Something Awful Forums</a> &gt; <a href=""forumdisplay.php?forumid=48"">Main</a> &gt; <a href=""forumdisplay.php?forumid=1"" class=""bclast"">GBS 1.4</a></b></span> <span class=""online_users"">(<a href=""/online.php?forumid=1"" title=""View members browsing this forum"">913 users browsing</a>)</span>
	<div id=""mp_bar"">
	<div id=""mods"">
	(Mods: <b><a href=""member.php?action=getinfo&amp;userid=43050"">Inspector_666</a></b>, <b><a href=""member.php?action=getinfo&amp;userid=45450"">priestofsyrinx2112</a></b>, <b><a href=""member.php?action=getinfo&amp;userid=49334"">Corn Thongs</a></b>, <b><a href=""member.php?action=getinfo&amp;userid=140500"">Pig Benis Disciple</a></b>)
	</div>
</div></div>

 <table id=""subforums"" summary=""Subforums"">
	 <caption>Subforums</caption>
	 <thead>
	 <tr>
		 <th>Title - Description</th>
		 <th>Topics</th>
		 <th>Posts</th>
	 </tr>
	 </thead>
	 <tbody>
		 <tr class=""subforum"">
<td class=""title""><dl><dt><a href=""forumdisplay.php?forumid=155"">SA's Front Page Discussion</a></dt><dd> - All front page-related comments should go in here.</dd></dl></td>
<td class=""topics"">63</td>
<td class=""posts"">5083</td>
</tr><tr class=""subforum"">
<td class=""title""><dl><dt><a href=""forumdisplay.php?forumid=214"">E/N Bullshit</a></dt><dd> - E/N, relationship issues, and other self-centered posts regarding your disastrous life go here.</dd></dl></td>
<td class=""topics"">188</td>
<td class=""posts"">120869</td>
</tr>
	 </tbody>
 </table>


<div id=""filter"">
<div class=""toggle_tags"">Filter Posts</div>
<div class=""thread_tags"">
	 <a class=""if"" href=""/forumdisplay.php?forumid=1&amp;posticon=420""><img src=""http://fi.somethingawful.com/forums/posticons/byob-slayer.gif"" width=""60"" height=""15"" alt="""" title=""Slayer""></a> <a class=""if"" href=""/forumdisplay.php?forumid=1&amp;posticon=655""><img src=""http://fi.somethingawful.com/forums/posticons/LF-2wqxulw.gif"" width=""60"" height=""15"" alt="""" title=""LF-2wqxulw.gif""></a> <a class=""if"" href=""/forumdisplay.php?forumid=1&amp;posticon=681""><img src=""http://fi.somethingawful.com/forums/posticons/icon-dear_richard.png"" width=""60"" height=""15"" alt="""" title=""DEAR RICHARD""></a> <a class=""if"" href=""/forumdisplay.php?forumid=1&amp;posticon=692""><img src=""http://fi.somethingawful.com/forums/posticons/dd-9-11.gif"" width=""60"" height=""15"" alt="""" title=""9/11""></a> <a class=""if"" href=""/forumdisplay.php?forumid=1&amp;posticon=757""><img src=""http://fi.somethingawful.com/forums/posticons/ddrd-scsa.gif"" width=""60"" height=""15"" alt="""" title=""Install the vent hood: because Stone Cold Said So""></a> <a class=""if"" href=""/forumdisplay.php?forumid=1&amp;posticon=125""><img src=""http://forumimages.somethingawful.com/forums/posticons/icon-60-pig.gif"" width=""60"" height=""15"" alt="""" title=""""></a> <a class=""if"" href=""/forumdisplay.php?forumid=1&amp;posticon=737""><img src=""http://fi.somethingawful.com/forums/posticons/chooch.gif"" width=""60"" height=""15"" alt="""" title=""Choochacacacacacacko""></a> <a class=""if"" href=""/forumdisplay.php?forumid=1&amp;posticon=124""><img src=""http://forumimages.somethingawful.com/forums/posticons/icon-59-lobster.gif"" width=""60"" height=""15"" alt="""" title=""LOBSTER!!!  OH YEAH!!!""></a> <a class=""if"" href=""/forumdisplay.php?forumid=1&amp;posticon=138""><img src=""http://fi.somethingawful.com/forums/posticons/icon-honk.gif"" width=""60"" height=""15"" alt="""" title=""HONK!""></a> <a class=""if"" href=""/forumdisplay.php?forumid=1&amp;posticon=60""><img src=""http://fi.somethingawful.com/forums/posticons/icons-08/en.png"" width=""60"" height=""15"" alt="""" title=""e/n bullshit""></a> <a class=""if"" href=""/forumdisplay.php?forumid=1&amp;posticon=61""><img src=""http://fi.somethingawful.com/forums/posticons/icons-08/unfunny.png"" width=""60"" height=""15"" alt="""" title=""NOT FUNNY AT ALL""></a> <a class=""if"" href=""/forumdisplay.php?forumid=1&amp;posticon=66""><img src=""http://fi.somethingawful.com/forums/posticons/icons-08/rant.png"" width=""60"" height=""15"" alt="""" title=""Rant""></a> <a class=""if"" href=""/forumdisplay.php?forumid=1&amp;posticon=77""><img src=""http://fi.somethingawful.com/forums/posticons/icons-08/stupid.png"" width=""60"" height=""15"" alt="""" title=""Something stupid""></a> <a class=""if"" href=""/forumdisplay.php?forumid=1&amp;posticon=79""><img src=""http://fi.somethingawful.com/forums/posticons/icons-08/weird.png"" width=""60"" height=""15"" alt="""" title=""Something weird""></a> <a class=""if"" href=""/forumdisplay.php?forumid=1&amp;posticon=81""><img src=""http://fi.somethingawful.com/forums/posticons/icons-08/fruity.png"" width=""60"" height=""15"" alt="""" title=""Fruity post""></a> <a class=""if"" href=""/forumdisplay.php?forumid=1&amp;posticon=86""><img src=""http://fi.somethingawful.com/forums/posticons/icons-08/gross.png"" width=""60"" height=""15"" alt="""" title=""Gross""></a> <a class=""if"" href=""/forumdisplay.php?forumid=1&amp;posticon=89""><img src=""http://fi.somethingawful.com/forums/posticons/icons-08/humor.png"" width=""60"" height=""15"" alt="""" title=""Humor""></a> <a class=""if"" href=""/forumdisplay.php?forumid=1&amp;posticon=95""><img src=""http://fi.somethingawful.com/forums/posticons/icons-08/whine.png"" width=""60"" height=""15"" alt="""" title=""Wahhhhhh whine whine whine""></a> <a class=""if"" href=""/forumdisplay.php?forumid=1&amp;posticon=115""><img src=""http://fi.somethingawful.com/forums/posticons/icons-08/serious.png"" width=""60"" height=""15"" alt="""" title=""This is a serious post""></a> <a class=""if"" href=""/forumdisplay.php?forumid=1&amp;posticon=64""><img src=""http://fi.somethingawful.com/forums/posticons/icons-08/question.png"" width=""60"" height=""15"" alt="""" title=""Question""></a> <a class=""if"" href=""/forumdisplay.php?forumid=1&amp;posticon=65""><img src=""http://fi.somethingawful.com/forums/posticons/icons-08/attention.png"" width=""60"" height=""15"" alt="""" title=""ATTENTION!""></a> <a class=""if"" href=""/forumdisplay.php?forumid=1&amp;posticon=67""><img src=""http://fi.somethingawful.com/forums/posticons/icons-08/newbie.png"" width=""60"" height=""15"" alt="""" title=""NEWBIE QUESTION""></a> <a class=""if"" href=""/forumdisplay.php?forumid=1&amp;posticon=68""><img src=""http://fi.somethingawful.com/forums/posticons/icons-08/poll.png"" width=""60"" height=""15"" alt="""" title=""Poll""></a> <a class=""if"" href=""/forumdisplay.php?forumid=1&amp;posticon=69""><img src=""http://fi.somethingawful.com/forums/posticons/icons-08/link.png"" width=""60"" height=""15"" alt="""" title=""URL Link""></a> <a class=""if"" href=""/forumdisplay.php?forumid=1&amp;posticon=74""><img src=""http://fi.somethingawful.com/forums/posticons/icons-08/request.png"" width=""60"" height=""15"" alt="""" title=""Request!""></a> <a class=""if"" href=""/forumdisplay.php?forumid=1&amp;posticon=78""><img src=""http://fi.somethingawful.com/forums/posticons/icons-08/help.png"" width=""60"" height=""15"" alt="""" title=""Help!""></a> <a class=""if"" href=""/forumdisplay.php?forumid=1&amp;posticon=104""><img src=""http://fi.somethingawful.com/forums/posticons/icons-08/event.png"" width=""60"" height=""15"" alt="""" title=""Event planned""></a> <a class=""if"" href=""/forumdisplay.php?forumid=1&amp;posticon=113""><img src=""http://fi.somethingawful.com/forums/posticons/icons-08/goonmeet.png"" width=""60"" height=""15"" alt="""" title=""Goon Meet""></a> <a class=""if"" href=""/forumdisplay.php?forumid=1&amp;posticon=120""><img src=""http://fi.somethingawful.com/forums/posticons/icons-08/repeat.png"" width=""60"" height=""15"" alt="""" title=""Repeated subject / link?""></a> <a class=""if"" href=""/forumdisplay.php?forumid=1&amp;posticon=71""><img src=""http://fi.somethingawful.com/forums/posticons/icons-08/games.png"" width=""60"" height=""15"" alt="""" title=""Games""></a> <a class=""if"" href=""/forumdisplay.php?forumid=1&amp;posticon=75""><img src=""http://fi.somethingawful.com/forums/posticons/icons-08/news.png"" width=""60"" height=""15"" alt="""" title=""News item""></a> <a class=""if"" href=""/forumdisplay.php?forumid=1&amp;posticon=80""><img src=""http://fi.somethingawful.com/forums/posticons/icons-08/music.png"" width=""60"" height=""15"" alt="""" title=""Music""></a> <a class=""if"" href=""/forumdisplay.php?forumid=1&amp;posticon=83""><img src=""http://fi.somethingawful.com/forums/posticons/icons-08/computers.png"" width=""60"" height=""15"" alt="""" title=""Computer issues""></a> <a class=""if"" href=""/forumdisplay.php?forumid=1&amp;posticon=85""><img src=""http://fi.somethingawful.com/forums/posticons/icons-08/politics.png"" width=""60"" height=""15"" alt="""" title=""Political debate""></a> <a class=""if"" href=""/forumdisplay.php?forumid=1&amp;posticon=88""><img src=""http://fi.somethingawful.com/forums/posticons/icons-08/school.png"" width=""60"" height=""15"" alt="""" title=""School""></a> <a class=""if"" href=""/forumdisplay.php?forumid=1&amp;posticon=92""><img src=""http://fi.somethingawful.com/forums/posticons/icons-08/sex.png"" width=""60"" height=""15"" alt="""" title=""Something about sex""></a> <a class=""if"" href=""/forumdisplay.php?forumid=1&amp;posticon=93""><img src=""http://fi.somethingawful.com/forums/posticons/icons-08/cars.png"" width=""60"" height=""15"" alt="""" title=""Cars""></a> <a class=""if"" href=""/forumdisplay.php?forumid=1&amp;posticon=101""><img src=""http://fi.somethingawful.com/forums/posticons/icons-08/guns.png"" width=""60"" height=""15"" alt="""" title=""Guns""></a> <a class=""if"" href=""/forumdisplay.php?forumid=1&amp;posticon=105""><img src=""http://fi.somethingawful.com/forums/posticons/icons-08/tech.png"" width=""60"" height=""15"" alt="""" title=""Technical question""></a> <a class=""if"" href=""/forumdisplay.php?forumid=1&amp;posticon=121""><img src=""http://fi.somethingawful.com/forums/posticons/icons-08/sports.png"" width=""60"" height=""15"" alt="""" title=""Sports""></a> <a class=""if"" href=""/forumdisplay.php?forumid=1&amp;posticon=122""><img src=""http://fi.somethingawful.com/forums/posticons/icons-08/drugs.png"" width=""60"" height=""15"" alt="""" title=""Drugs, maaaan""></a> <a class=""if"" href=""/forumdisplay.php?forumid=1&amp;posticon=123""><img src=""http://fi.somethingawful.com/forums/posticons/icons-08/science.png"" width=""60"" height=""15"" alt="""" title=""Science... and philosophy!""></a> <a class=""if"" href=""/forumdisplay.php?forumid=1&amp;posticon=128""><img src=""http://fi.somethingawful.com/forums/posticons/icons-08/food.png"" width=""60"" height=""15"" alt="""" title=""Food and Cooking""></a> <a class=""if"" href=""/forumdisplay.php?forumid=1&amp;posticon=309""><img src=""http://fi.somethingawful.com/forums/posticons/icons-08/video.png"" width=""60"" height=""15"" alt="""" title=""Another online video link thread""></a> <a class=""if"" href=""/forumdisplay.php?forumid=1&amp;posticon=63""><img src=""http://fi.somethingawful.com/forums/posticons/icons-08/audio.png"" width=""60"" height=""15"" alt="""" title=""Audio file""></a> <a class=""if"" href=""/forumdisplay.php?forumid=1&amp;posticon=72""><img src=""http://fi.somethingawful.com/forums/posticons/icons-08/movies.png"" width=""60"" height=""15"" alt="""" title=""Movie Discussion""></a> <a class=""if"" href=""/forumdisplay.php?forumid=1&amp;posticon=73""><img src=""http://fi.somethingawful.com/forums/posticons/icons-08/books.png"" width=""60"" height=""15"" alt="""" title=""Books and literature""></a> <a class=""if"" href=""/forumdisplay.php?forumid=1&amp;posticon=76""><img src=""http://fi.somethingawful.com/forums/posticons/icons-08/photoshop.png"" width=""60"" height=""15"" alt="""" title=""Photoshop entry""></a> <a class=""if"" href=""/forumdisplay.php?forumid=1&amp;posticon=94""><img src=""http://fi.somethingawful.com/forums/posticons/icons-08/tv.png"" width=""60"" height=""15"" alt="""" title=""Television""></a> <a class=""if"" href=""/forumdisplay.php?forumid=1&amp;posticon=114""><img src=""http://forumimages.somethingawful.com/forums/posticons/icons-08/art.png"" width=""60"" height=""15"" alt="""" title=""Art""></a> <a class=""if"" href=""/forumdisplay.php?forumid=1&amp;posticon=116""><img src=""http://fi.somethingawful.com/forums/posticons/icons-08/photos.png"" width=""60"" height=""15"" alt="""" title=""Photos / webcams / etc""></a> <a class=""if"" href=""/forumdisplay.php?forumid=1&amp;posticon=82""><img src=""http://forumimages.somethingawful.com/forums/posticons/icon23-banme.gif"" width=""60"" height=""15"" alt="""" title=""PLEASE BAN ME""></a> <a class=""if"" href=""/forumdisplay.php?forumid=1&amp;posticon=90""><img src=""http://forumimages.somethingawful.com/forums/posticons/icon-30-attnmod.gif"" width=""60"" height=""15"" alt="""" title=""MODS ONLY""></a> <a class=""if"" href=""/forumdisplay.php?forumid=1&amp;posticon=91""><img src=""http://forumimages.somethingawful.com/forums/posticons/icon-31-hotthread.gif"" width=""60"" height=""15"" alt="""" title=""MODS ONLY""></a> <a class=""if"" href=""/forumdisplay.php?forumid=1&amp;posticon=255""><img src=""http://fi.somethingawful.com/forums/posticons/fyad-falconry.gif"" width=""60"" height=""15"" alt="""" title=""Falconry discussion""></a> <a class=""if"" href=""/forumdisplay.php?forumid=1&amp;posticon=256""><img src=""http://fi.somethingawful.com/forums/posticons/fyad-trout.gif"" width=""60"" height=""15"" alt="""" title=""Trout Magick""></a> <a class=""if"" href=""/forumdisplay.php?forumid=1&amp;posticon=322""><img src=""http://fi.somethingawful.com/forums/posticons/fyad-blogs.gif"" width=""60"" height=""15"" alt="""" title=""BLOGS""></a>
	<div class=""remove_tag"">
		<a href=""/forumdisplay.php?forumid=1"">Remove filter</a>
	</div>
</div>
</div>


<table id=""forum"" summary=""Threads"" class=""threadlist "">
	<caption>Threads</caption>
	<thead>
	<tr>
		<th class=""star"">&nbsp;</th>
		<th class=""icon"">Icon</th>
		<th class=""title"">Title (Pages)</th>
		<th class=""author"">Author</th>
		<th class=""replies""><a href=""forumdisplay.php?forumid=1&amp;daysprune=15&amp;perpage=40&amp;posticon=0&amp;sortorder=desc&amp;sortfield=replycount""><abbr title=""Replies"">Re</abbr></a> </th>
		<th class=""views"">Views</th>
		<th class=""rate""><a href=""forumdisplay.php?forumid=1&amp;daysprune=15&amp;perpage=40&amp;posticon=0&amp;sortorder=desc&amp;sortfield=voteavg"">Rating</a> </th>
		<th class=""lastpost""><a href=""forumdisplay.php?forumid=1&amp;daysprune=15&amp;perpage=40&amp;posticon=0&amp;sortorder=desc&amp;sortfield=lastpost"">Killed By</a> <a href=""forumdisplay.php?forumid=1&amp;daysprune=15&amp;perpage=40&amp;posticon=0&amp;pagenumber=1&amp;sortorder=asc&amp;sortfield=lastpost""><img src=""http://fi.somethingawful.com/images/sortasc.gif"" title=""Reverse Sort Order""></a></th>
	</tr>
	</thead>
	<tbody>
		
		<tr class=""thread seen"" id=""thread3617936"">
	<td class=""star ""></td>
	<td class=""icon""><a href=""/forumdisplay.php?forumid=1&amp;posticon=82""><img src=""http://forumimages.somethingawful.com/forums/posticons/icon23-banme.gif#82"" alt=""""></a></td>
	<td class=""title title_sticky"">
		<div class=""title_inner"">
			<div class=""lastseen""><a href=""/showthread.php?action=resetseen&amp;threadid=3617936"" class=""x"" title=""Mark as unread"">X</a></div>
			<div class=""info"">
				<a href=""showthread.php?threadid=3617936"" class=""thread_title"">STOP POSTING NWS SHIT IN SPOILER TAGS YOU FUCKING RETARDS</a>
				
			</div>
		</div>
	</td>
	<td class=""author""><a href=""member.php?action=getinfo&amp;userid=61644"">Ralp</a></td>
	<td class=""replies"">1</td>
	<td class=""views"">6740</td>
	<td class=""rating"">&nbsp;</td>
	<td class=""lastpost""><div class=""date"">12:12 Mar 19, 2014</div><a class=""author"" href=""showthread.php?goto=lastpost&amp;threadid=3617936"">priestofsyrinx2112</a></td>
</tr><tr class=""thread seen"" id=""thread3617982"">
	<td class=""star ""></td>
	<td class=""icon""><a href=""/forumdisplay.php?forumid=1&amp;posticon=76""><img src=""http://fi.somethingawful.com/forums/posticons/icons-08/photoshop.png#76"" alt=""""></a></td>
	<td class=""title title_sticky"">
		<div class=""title_inner"">
			<div class=""lastseen""><a href=""/showthread.php?action=resetseen&amp;threadid=3617982"" class=""x"" title=""Mark as unread"">X</a><a title=""Jump to last read post"" href=""/showthread.php?threadid=3617982&amp;goto=newpost"" class=""count""><b>2</b></a></div>
			<div class=""info"">
				<a href=""showthread.php?threadid=3617982"" class=""thread_title"">Doug H. Nuts</a>
				<div class=""title_pages"">Pages: <a class=""pagenumber"" href=""showthread.php?threadid=3617982&amp;pagenumber=1"">1</a><a class=""pagenumber"" href=""showthread.php?threadid=3617982&amp;pagenumber=2"">2</a><a class=""pagenumber"" href=""showthread.php?threadid=3617982&amp;pagenumber=3"">3</a></div>
			</div>
		</div>
	</td>
	<td class=""author""><a href=""member.php?action=getinfo&amp;userid=181634"">djwetmouse</a></td>
	<td class=""replies"">105</td>
	<td class=""views"">12559</td>
	<td class=""rating""><img src=""http://fi.somethingawful.com/rate/default/5stars.gif"" alt="""" title=""132 votes - 4.69 average""></td>
	<td class=""lastpost""><div class=""date"">15:59 Mar 21, 2014</div><a class=""author"" href=""showthread.php?goto=lastpost&amp;threadid=3617982"">BloodWulfe</a></td>
</tr><tr class=""thread"" id=""thread3616673"">
	<td class=""star ""></td>
	<td class=""icon""><a href=""/forumdisplay.php?forumid=1&amp;posticon=128""><img src=""http://fi.somethingawful.com/forums/posticons/icons-08/food.png#128"" alt=""""></a></td>
	<td class=""title title_sticky"">
		<div class=""title_inner"">
			
			<div class=""info"">
				<a href=""showthread.php?threadid=3616673"" class=""thread_title"">What's this goon looking at?</a>
				<div class=""title_pages"">Pages: <a class=""pagenumber"" href=""showthread.php?threadid=3616673&amp;pagenumber=1"">1</a><a class=""pagenumber"" href=""showthread.php?threadid=3616673&amp;pagenumber=2"">2</a><a class=""pagenumber"" href=""showthread.php?threadid=3616673&amp;pagenumber=3"">3</a><a class=""pagenumber"" href=""showthread.php?threadid=3616673&amp;pagenumber=4"">4</a><a class=""pagenumber"" href=""showthread.php?threadid=3616673&amp;pagenumber=5"">5</a><a class=""pagenumber"" href=""showthread.php?threadid=3616673&amp;pagenumber=6"">6</a><a class=""pagenumber"" href=""showthread.php?threadid=3616673&amp;pagenumber=7"">7</a></div>
			</div>
		</div>
	</td>
	<td class=""author""><a href=""member.php?action=getinfo&amp;userid=140500"">Sephardic Homo</a></td>
	<td class=""replies"">261</td>
	<td class=""views"">34034</td>
	<td class=""rating""><img src=""http://fi.somethingawful.com/rate/default/5stars.gif"" alt="""" title=""245 votes - 4.89 average""></td>
	<td class=""lastpost""><div class=""date"">15:01 Mar 21, 2014</div><a class=""author"" href=""showthread.php?goto=lastpost&amp;threadid=3616673"">kid sinister</a></td>
</tr><tr class=""thread seen"" id=""thread3617439"">
	<td class=""star ""></td>
	<td class=""icon""><a href=""/forumdisplay.php?forumid=1&amp;posticon=76""><img src=""http://fi.somethingawful.com/forums/posticons/icons-08/photoshop.png#76"" alt=""""></a></td>
	<td class=""title title_sticky"">
		<div class=""title_inner"">
			<div class=""lastseen""><a href=""/showthread.php?action=resetseen&amp;threadid=3617439"" class=""x"" title=""Mark as unread"">X</a><a title=""Jump to last read post"" href=""/showthread.php?threadid=3617439&amp;goto=newpost"" class=""count""><b>33</b></a></div>
			<div class=""info"">
				<a href=""showthread.php?threadid=3617439"" class=""thread_title"">Make People Drunk</a>
				<div class=""title_pages"">Pages: <a class=""pagenumber"" href=""showthread.php?threadid=3617439&amp;pagenumber=1"">1</a><a class=""pagenumber"" href=""showthread.php?threadid=3617439&amp;pagenumber=2"">2</a></div>
			</div>
		</div>
	</td>
	<td class=""author""><a href=""member.php?action=getinfo&amp;userid=94483"">Tip</a></td>
	<td class=""replies"">56</td>
	<td class=""views"">11581</td>
	<td class=""rating""><img src=""http://fi.somethingawful.com/rate/default/3stars.gif"" alt="""" title=""33 votes - 3.41 average""></td>
	<td class=""lastpost""><div class=""date"">12:33 Mar 21, 2014</div><a class=""author"" href=""showthread.php?goto=lastpost&amp;threadid=3617439"">CannedMacabre</a></td>
</tr><tr class=""thread seen"" id=""thread3616248"">
	<td class=""star ""></td>
	<td class=""icon""><a href=""/forumdisplay.php?forumid=1&amp;posticon=76""><img src=""http://fi.somethingawful.com/forums/posticons/icons-08/photoshop.png#76"" alt=""""></a></td>
	<td class=""title title_sticky"">
		<div class=""title_inner"">
			<div class=""lastseen""><a href=""/showthread.php?action=resetseen&amp;threadid=3616248"" class=""x"" title=""Mark as unread"">X</a><a title=""Jump to last read post"" href=""/showthread.php?threadid=3616248&amp;goto=newpost"" class=""count""><b>46</b></a></div>
			<div class=""info"">
				<a href=""showthread.php?threadid=3616248"" class=""thread_title"">Creationists versus Reality vs. Goons</a>
				<div class=""title_pages"">Pages: <a class=""pagenumber"" href=""showthread.php?threadid=3616248&amp;pagenumber=1"">1</a><a class=""pagenumber"" href=""showthread.php?threadid=3616248&amp;pagenumber=2"">2</a><a class=""pagenumber"" href=""showthread.php?threadid=3616248&amp;pagenumber=3"">3</a><a class=""pagenumber"" href=""showthread.php?threadid=3616248&amp;pagenumber=4"">4</a><a class=""pagenumber"" href=""showthread.php?threadid=3616248&amp;pagenumber=5"">5</a><a class=""pagenumber"" href=""showthread.php?threadid=3616248&amp;pagenumber=6"">6</a><a class=""pagenumber"" href=""showthread.php?threadid=3616248&amp;pagenumber=7"">7</a>... <a class=""pagenumber"" href=""showthread.php?threadid=3616248&amp;goto=lastpost"">Last</a></div>
			</div>
		</div>
	</td>
	<td class=""author""><a href=""member.php?action=getinfo&amp;userid=202629"">Suicide Sam E.</a></td>
	<td class=""replies"">325</td>
	<td class=""views"">46052</td>
	<td class=""rating""><img src=""http://fi.somethingawful.com/rate/default/5stars.gif"" alt="""" title=""132 votes - 4.69 average""></td>
	<td class=""lastpost""><div class=""date"">10:36 Mar 21, 2014</div><a class=""author"" href=""showthread.php?goto=lastpost&amp;threadid=3616248"">Fishy Joe</a></td>
</tr><tr class=""thread seen"" id=""thread3600882"">
	<td class=""star ""></td>
	<td class=""icon""><a href=""/forumdisplay.php?forumid=1&amp;posticon=655""><img src=""http://fi.somethingawful.com/forums/posticons/LF-2wqxulw.gif#655"" alt=""""></a></td>
	<td class=""title title_sticky"">
		<div class=""title_inner"">
			<div class=""lastseen""><a href=""/showthread.php?action=resetseen&amp;threadid=3600882"" class=""x"" title=""Mark as unread"">X</a></div>
			<div class=""info"">
				<a href=""showthread.php?threadid=3600882"" class=""thread_title"">GBS 1.4</a>
				
			</div>
		</div>
	</td>
	<td class=""author""><a href=""member.php?action=getinfo&amp;userid=51697"">angerbeet</a></td>
	<td class=""replies"">0</td>
	<td class=""views"">73660</td>
	<td class=""rating"">&nbsp;</td>
	<td class=""lastpost""><div class=""date"">23:09 Feb 17, 2014</div><a class=""author"" href=""showthread.php?goto=lastpost&amp;threadid=3600882"">angerbeet</a></td>
</tr><tr class=""thread seen"" id=""thread3585136"">
	<td class=""star ""></td>
	<td class=""icon""><a href=""/forumdisplay.php?forumid=1&amp;posticon=91""><img src=""http://forumimages.somethingawful.com/forums/posticons/icon-31-hotthread.gif#91"" alt=""""></a></td>
	<td class=""title"">
		<div class=""title_inner"">
			<div class=""lastseen""><a href=""/showthread.php?action=resetseen&amp;threadid=3585136"" class=""x"" title=""Mark as unread"">X</a><a title=""Jump to last read post"" href=""/showthread.php?threadid=3585136&amp;goto=newpost"" class=""count""><b>17833</b></a></div>
			<div class=""info"">
				<a href=""showthread.php?threadid=3585136"" class=""thread_title"">Ladies' Chatting Thread: welcome to the butt farm, bitch</a>
				<div class=""title_pages"">Pages: <a class=""pagenumber"" href=""showthread.php?threadid=3585136&amp;pagenumber=1"">1</a><a class=""pagenumber"" href=""showthread.php?threadid=3585136&amp;pagenumber=2"">2</a><a class=""pagenumber"" href=""showthread.php?threadid=3585136&amp;pagenumber=3"">3</a><a class=""pagenumber"" href=""showthread.php?threadid=3585136&amp;pagenumber=4"">4</a><a class=""pagenumber"" href=""showthread.php?threadid=3585136&amp;pagenumber=5"">5</a><a class=""pagenumber"" href=""showthread.php?threadid=3585136&amp;pagenumber=6"">6</a><a class=""pagenumber"" href=""showthread.php?threadid=3585136&amp;pagenumber=7"">7</a>... <a class=""pagenumber"" href=""showthread.php?threadid=3585136&amp;goto=lastpost"">Last</a></div>
			</div>
		</div>
	</td>
	<td class=""author""><a href=""member.php?action=getinfo&amp;userid=153941"">Pick</a></td>
	<td class=""replies"">44712</td>
	<td class=""views"">603598</td>
	<td class=""rating""><img src=""http://fi.somethingawful.com/rate/default/4stars.gif"" alt="""" title=""109 votes - 3.97 average""></td>
	<td class=""lastpost""><div class=""date"">16:57 Mar 21, 2014</div><a class=""author"" href=""showthread.php?goto=lastpost&amp;threadid=3585136"">Pick</a></td>
</tr><tr class=""thread"" id=""thread3618516"">
	<td class=""star ""></td>
	<td class=""icon""><a href=""/forumdisplay.php?forumid=1&amp;posticon=81""><img src=""http://fi.somethingawful.com/forums/posticons/icons-08/fruity.png#81"" alt=""""></a></td>
	<td class=""title"">
		<div class=""title_inner"">
			
			<div class=""info"">
				<a href=""showthread.php?threadid=3618516"" class=""thread_title"">My style is ubiquitous, transcendental and intergalactic</a>
				
			</div>
		</div>
	</td>
	<td class=""author""><a href=""member.php?action=getinfo&amp;userid=179940"">Mugticket</a></td>
	<td class=""replies"">19</td>
	<td class=""views"">355</td>
	<td class=""rating"">&nbsp;</td>
	<td class=""lastpost""><div class=""date"">16:57 Mar 21, 2014</div><a class=""author"" href=""showthread.php?goto=lastpost&amp;threadid=3618516"">The Tao Jones</a></td>
</tr><tr class=""thread seen"" id=""thread3579076"">
	<td class=""star ""></td>
	<td class=""icon""><a href=""/forumdisplay.php?forumid=1&amp;posticon=114""><img src=""http://forumimages.somethingawful.com/forums/posticons/icons-08/art.png#114"" alt=""""></a></td>
	<td class=""title"">
		<div class=""title_inner"">
			<div class=""lastseen""><a href=""/showthread.php?action=resetseen&amp;threadid=3579076"" class=""x"" title=""Mark as unread"">X</a><a title=""Jump to last read post"" href=""/showthread.php?threadid=3579076&amp;goto=newpost"" class=""count""><b>196776</b></a></div>
			<div class=""info"">
				<a href=""showthread.php?threadid=3579076"" class=""thread_title"">Nite Crew - No Longer A Safehouse for The Goon Cosplay Homegroan IRC</a>
				<div class=""title_pages"">Pages: <a class=""pagenumber"" href=""showthread.php?threadid=3579076&amp;pagenumber=1"">1</a><a class=""pagenumber"" href=""showthread.php?threadid=3579076&amp;pagenumber=2"">2</a><a class=""pagenumber"" href=""showthread.php?threadid=3579076&amp;pagenumber=3"">3</a><a class=""pagenumber"" href=""showthread.php?threadid=3579076&amp;pagenumber=4"">4</a><a class=""pagenumber"" href=""showthread.php?threadid=3579076&amp;pagenumber=5"">5</a><a class=""pagenumber"" href=""showthread.php?threadid=3579076&amp;pagenumber=6"">6</a><a class=""pagenumber"" href=""showthread.php?threadid=3579076&amp;pagenumber=7"">7</a>... <a class=""pagenumber"" href=""showthread.php?threadid=3579076&amp;goto=lastpost"">Last</a></div>
			</div>
		</div>
	</td>
	<td class=""author""><a href=""member.php?action=getinfo&amp;userid=139386"">Daikatana Ritsu</a></td>
	<td class=""replies"">196815</td>
	<td class=""views"">1808378</td>
	<td class=""rating""><img src=""http://fi.somethingawful.com/rate/default/4stars.gif"" alt="""" title=""408 votes - 3.51 average""></td>
	<td class=""lastpost""><div class=""date"">16:56 Mar 21, 2014</div><a class=""author"" href=""showthread.php?goto=lastpost&amp;threadid=3579076"">Sorry Corals</a></td>
</tr><tr class=""thread"" id=""thread3618415"">
	<td class=""star ""></td>
	<td class=""icon""><a href=""/forumdisplay.php?forumid=1&amp;posticon=75""><img src=""http://fi.somethingawful.com/forums/posticons/icons-08/news.png#75"" alt=""""></a></td>
	<td class=""title"">
		<div class=""title_inner"">
			
			<div class=""info"">
				<a href=""showthread.php?threadid=3618415"" class=""thread_title"">MRAs are pretty much Muslims without the religion</a>
				<div class=""title_pages"">Pages: <a class=""pagenumber"" href=""showthread.php?threadid=3618415&amp;pagenumber=1"">1</a><a class=""pagenumber"" href=""showthread.php?threadid=3618415&amp;pagenumber=2"">2</a><a class=""pagenumber"" href=""showthread.php?threadid=3618415&amp;pagenumber=3"">3</a></div>
			</div>
		</div>
	</td>
	<td class=""author""><a href=""member.php?action=getinfo&amp;userid=204727"">McSpergin</a></td>
	<td class=""replies"">97</td>
	<td class=""views"">2646</td>
	<td class=""rating"">&nbsp;</td>
	<td class=""lastpost""><div class=""date"">16:56 Mar 21, 2014</div><a class=""author"" href=""showthread.php?goto=lastpost&amp;threadid=3618415"">GROVER CURES HOUSE</a></td>
</tr><tr class=""thread seen"" id=""thread3609285"">
	<td class=""star ""></td>
	<td class=""icon""><a href=""/forumdisplay.php?forumid=1&amp;posticon=115""><img src=""http://fi.somethingawful.com/forums/posticons/icons-08/serious.png#115"" alt=""""></a></td>
	<td class=""title"">
		<div class=""title_inner"">
			<div class=""lastseen""><a href=""/showthread.php?action=resetseen&amp;threadid=3609285"" class=""x"" title=""Mark as unread"">X</a><a title=""Jump to last read post"" href=""/showthread.php?threadid=3609285&amp;goto=newpost"" class=""count""><b>5658</b></a></div>
			<div class=""info"">
				<a href=""showthread.php?threadid=3609285"" class=""thread_title"">Fat is beautiful</a>
				<div class=""title_pages"">Pages: <a class=""pagenumber"" href=""showthread.php?threadid=3609285&amp;pagenumber=1"">1</a><a class=""pagenumber"" href=""showthread.php?threadid=3609285&amp;pagenumber=2"">2</a><a class=""pagenumber"" href=""showthread.php?threadid=3609285&amp;pagenumber=3"">3</a><a class=""pagenumber"" href=""showthread.php?threadid=3609285&amp;pagenumber=4"">4</a><a class=""pagenumber"" href=""showthread.php?threadid=3609285&amp;pagenumber=5"">5</a><a class=""pagenumber"" href=""showthread.php?threadid=3609285&amp;pagenumber=6"">6</a><a class=""pagenumber"" href=""showthread.php?threadid=3609285&amp;pagenumber=7"">7</a>... <a class=""pagenumber"" href=""showthread.php?threadid=3609285&amp;goto=lastpost"">Last</a></div>
			</div>
		</div>
	</td>
	<td class=""author""><a href=""member.php?action=getinfo&amp;userid=173051"">myshl0ng</a></td>
	<td class=""replies"">5697</td>
	<td class=""views"">192582</td>
	<td class=""rating""><img src=""http://fi.somethingawful.com/rate/default/3stars.gif"" alt="""" title=""103 votes - 3.37 average""></td>
	<td class=""lastpost""><div class=""date"">16:56 Mar 21, 2014</div><a class=""author"" href=""showthread.php?goto=lastpost&amp;threadid=3609285"">Twee as Fuck</a></td>
</tr><tr class=""thread seen"" id=""thread3617338"">
	<td class=""star ""></td>
	<td class=""icon""><a href=""/forumdisplay.php?forumid=1&amp;posticon=420""><img src=""http://fi.somethingawful.com/forums/posticons/byob-slayer.gif#420"" alt=""""></a></td>
	<td class=""title"">
		<div class=""title_inner"">
			<div class=""lastseen""><a href=""/showthread.php?action=resetseen&amp;threadid=3617338"" class=""x"" title=""Mark as unread"">X</a><a title=""Jump to last read post"" href=""/showthread.php?threadid=3617338&amp;goto=newpost"" class=""count""><b>259</b></a></div>
			<div class=""info"">
				<a href=""showthread.php?threadid=3617338"" class=""thread_title"">Sailor Moon Thread</a>
				<div class=""title_pages"">Pages: <a class=""pagenumber"" href=""showthread.php?threadid=3617338&amp;pagenumber=1"">1</a><a class=""pagenumber"" href=""showthread.php?threadid=3617338&amp;pagenumber=2"">2</a><a class=""pagenumber"" href=""showthread.php?threadid=3617338&amp;pagenumber=3"">3</a><a class=""pagenumber"" href=""showthread.php?threadid=3617338&amp;pagenumber=4"">4</a><a class=""pagenumber"" href=""showthread.php?threadid=3617338&amp;pagenumber=5"">5</a><a class=""pagenumber"" href=""showthread.php?threadid=3617338&amp;pagenumber=6"">6</a><a class=""pagenumber"" href=""showthread.php?threadid=3617338&amp;pagenumber=7"">7</a>... <a class=""pagenumber"" href=""showthread.php?threadid=3617338&amp;goto=lastpost"">Last</a></div>
			</div>
		</div>
	</td>
	<td class=""author""><a href=""member.php?action=getinfo&amp;userid=130075"">ladyboy pancake</a></td>
	<td class=""replies"">298</td>
	<td class=""views"">10517</td>
	<td class=""rating"">&nbsp;</td>
	<td class=""lastpost""><div class=""date"">16:56 Mar 21, 2014</div><a class=""author"" href=""showthread.php?goto=lastpost&amp;threadid=3617338"">Island3</a></td>
</tr><tr class=""thread"" id=""thread3618530"">
	<td class=""star ""></td>
	<td class=""icon""><a href=""/forumdisplay.php?forumid=1&amp;posticon=92""><img src=""http://fi.somethingawful.com/forums/posticons/icons-08/sex.png#92"" alt=""""></a></td>
	<td class=""title"">
		<div class=""title_inner"">
			
			<div class=""info"">
				<a href=""showthread.php?threadid=3618530"" class=""thread_title"">Home Movies was a really good show</a>
				
			</div>
		</div>
	</td>
	<td class=""author""><a href=""member.php?action=getinfo&amp;userid=184674"">NienNunb</a></td>
	<td class=""replies"">11</td>
	<td class=""views"">78</td>
	<td class=""rating"">&nbsp;</td>
	<td class=""lastpost""><div class=""date"">16:56 Mar 21, 2014</div><a class=""author"" href=""showthread.php?goto=lastpost&amp;threadid=3618530"">MONKET</a></td>
</tr><tr class=""thread seen"" id=""thread3602918"">
	<td class=""star ""></td>
	<td class=""icon""><a href=""/forumdisplay.php?forumid=1&amp;posticon=101""><img src=""http://fi.somethingawful.com/forums/posticons/icons-08/guns.png#101"" alt=""""></a></td>
	<td class=""title"">
		<div class=""title_inner"">
			<div class=""lastseen""><a href=""/showthread.php?action=resetseen&amp;threadid=3602918"" class=""x"" title=""Mark as unread"">X</a><a title=""Jump to last read post"" href=""/showthread.php?threadid=3602918&amp;goto=newpost"" class=""count""><b>10012</b></a></div>
			<div class=""info"">
				<a href=""showthread.php?threadid=3602918"" class=""thread_title"">lmao there's been a shooting every single day this week in the US</a>
				<div class=""title_pages"">Pages: <a class=""pagenumber"" href=""showthread.php?threadid=3602918&amp;pagenumber=1"">1</a><a class=""pagenumber"" href=""showthread.php?threadid=3602918&amp;pagenumber=2"">2</a><a class=""pagenumber"" href=""showthread.php?threadid=3602918&amp;pagenumber=3"">3</a><a class=""pagenumber"" href=""showthread.php?threadid=3602918&amp;pagenumber=4"">4</a><a class=""pagenumber"" href=""showthread.php?threadid=3602918&amp;pagenumber=5"">5</a><a class=""pagenumber"" href=""showthread.php?threadid=3602918&amp;pagenumber=6"">6</a><a class=""pagenumber"" href=""showthread.php?threadid=3602918&amp;pagenumber=7"">7</a>... <a class=""pagenumber"" href=""showthread.php?threadid=3602918&amp;goto=lastpost"">Last</a></div>
			</div>
		</div>
	</td>
	<td class=""author""><a href=""member.php?action=getinfo&amp;userid=150974"">Libelous Slander</a></td>
	<td class=""replies"">10131</td>
	<td class=""views"">128985</td>
	<td class=""rating""><img src=""http://fi.somethingawful.com/rate/default/2stars.gif"" alt="""" title=""260 votes - 1.79 average""></td>
	<td class=""lastpost""><div class=""date"">16:55 Mar 21, 2014</div><a class=""author"" href=""showthread.php?goto=lastpost&amp;threadid=3602918"">InterceptorV8</a></td>
</tr><tr class=""thread seen"" id=""thread3580504"">
	<td class=""star ""></td>
	<td class=""icon""><a href=""/forumdisplay.php?forumid=1&amp;posticon=0""><img src=""http://fi.somethingawful.com/images/shitpost.gif#0"" alt=""""></a></td>
	<td class=""title"">
		<div class=""title_inner"">
			<div class=""lastseen""><a href=""/showthread.php?action=resetseen&amp;threadid=3580504"" class=""x"" title=""Mark as unread"">X</a><a title=""Jump to last read post"" href=""/showthread.php?threadid=3580504&amp;goto=newpost"" class=""count""><b>7134</b></a></div>
			<div class=""info"">
				<a href=""showthread.php?threadid=3580504"" class=""thread_title"">Terrible Webcomics Megathread: Again With The Gay Centaurs</a>
				<div class=""title_pages"">Pages: <a class=""pagenumber"" href=""showthread.php?threadid=3580504&amp;pagenumber=1"">1</a><a class=""pagenumber"" href=""showthread.php?threadid=3580504&amp;pagenumber=2"">2</a><a class=""pagenumber"" href=""showthread.php?threadid=3580504&amp;pagenumber=3"">3</a><a class=""pagenumber"" href=""showthread.php?threadid=3580504&amp;pagenumber=4"">4</a><a class=""pagenumber"" href=""showthread.php?threadid=3580504&amp;pagenumber=5"">5</a><a class=""pagenumber"" href=""showthread.php?threadid=3580504&amp;pagenumber=6"">6</a><a class=""pagenumber"" href=""showthread.php?threadid=3580504&amp;pagenumber=7"">7</a>... <a class=""pagenumber"" href=""showthread.php?threadid=3580504&amp;goto=lastpost"">Last</a></div>
			</div>
		</div>
	</td>
	<td class=""author""><a href=""member.php?action=getinfo&amp;userid=182153"">Sawboss Jones</a></td>
	<td class=""replies"">27133</td>
	<td class=""views"">2274986</td>
	<td class=""rating""><img src=""http://fi.somethingawful.com/rate/default/4stars.gif"" alt="""" title=""223 votes - 3.72 average""></td>
	<td class=""lastpost""><div class=""date"">16:55 Mar 21, 2014</div><a class=""author"" href=""showthread.php?goto=lastpost&amp;threadid=3580504"">BloodWulfe</a></td>
</tr><tr class=""thread seen"" id=""thread3581054"">
	<td class=""star ""></td>
	<td class=""icon""><a href=""/forumdisplay.php?forumid=1&amp;posticon=120""><img src=""http://fi.somethingawful.com/forums/posticons/icons-08/repeat.png#120"" alt=""""></a></td>
	<td class=""title"">
		<div class=""title_inner"">
			<div class=""lastseen""><a href=""/showthread.php?action=resetseen&amp;threadid=3581054"" class=""x"" title=""Mark as unread"">X</a><a title=""Jump to last read post"" href=""/showthread.php?threadid=3581054&amp;goto=newpost"" class=""count""><b>34281</b></a></div>
			<div class=""info"">
				<a href=""showthread.php?threadid=3581054"" class=""thread_title"">Work Crew: Don't forget, you're here forever.</a>
				<div class=""title_pages"">Pages: <a class=""pagenumber"" href=""showthread.php?threadid=3581054&amp;pagenumber=1"">1</a><a class=""pagenumber"" href=""showthread.php?threadid=3581054&amp;pagenumber=2"">2</a><a class=""pagenumber"" href=""showthread.php?threadid=3581054&amp;pagenumber=3"">3</a><a class=""pagenumber"" href=""showthread.php?threadid=3581054&amp;pagenumber=4"">4</a><a class=""pagenumber"" href=""showthread.php?threadid=3581054&amp;pagenumber=5"">5</a><a class=""pagenumber"" href=""showthread.php?threadid=3581054&amp;pagenumber=6"">6</a><a class=""pagenumber"" href=""showthread.php?threadid=3581054&amp;pagenumber=7"">7</a>... <a class=""pagenumber"" href=""showthread.php?threadid=3581054&amp;goto=lastpost"">Last</a></div>
			</div>
		</div>
	</td>
	<td class=""author""><a href=""member.php?action=getinfo&amp;userid=131587"">inSTAALed</a></td>
	<td class=""replies"">34320</td>
	<td class=""views"">278420</td>
	<td class=""rating""><img src=""http://fi.somethingawful.com/rate/default/4stars.gif"" alt="""" title=""72 votes - 3.79 average""></td>
	<td class=""lastpost""><div class=""date"">16:54 Mar 21, 2014</div><a class=""author"" href=""showthread.php?goto=lastpost&amp;threadid=3581054"">100 HOGS AGREE</a></td>
</tr><tr class=""thread seen"" id=""thread3618324"">
	<td class=""star ""></td>
	<td class=""icon""><a href=""/forumdisplay.php?forumid=1&amp;posticon=68""><img src=""http://fi.somethingawful.com/forums/posticons/icons-08/poll.png#68"" alt=""""></a></td>
	<td class=""title"">
		<div class=""title_inner"">
			<div class=""lastseen""><a href=""/showthread.php?action=resetseen&amp;threadid=3618324"" class=""x"" title=""Mark as unread"">X</a><a title=""Jump to last read post"" href=""/showthread.php?threadid=3618324&amp;goto=newpost"" class=""count""><b>36</b></a></div>
			<div class=""info"">
				<a href=""showthread.php?threadid=3618324"" class=""thread_title"">Japan</a>
				<div class=""title_pages"">Pages: <a class=""pagenumber"" href=""showthread.php?threadid=3618324&amp;pagenumber=1"">1</a><a class=""pagenumber"" href=""showthread.php?threadid=3618324&amp;pagenumber=2"">2</a><a class=""pagenumber"" href=""showthread.php?threadid=3618324&amp;pagenumber=3"">3</a><a class=""pagenumber"" href=""showthread.php?threadid=3618324&amp;pagenumber=4"">4</a><a class=""pagenumber"" href=""showthread.php?threadid=3618324&amp;pagenumber=5"">5</a><a class=""pagenumber"" href=""showthread.php?threadid=3618324&amp;pagenumber=6"">6</a></div>
			</div>
		</div>
	</td>
	<td class=""author""><a href=""member.php?action=getinfo&amp;userid=204015"">Rob Ford</a></td>
	<td class=""replies"">209</td>
	<td class=""views"">6813</td>
	<td class=""rating"">&nbsp;</td>
	<td class=""lastpost""><div class=""date"">16:54 Mar 21, 2014</div><a class=""author"" href=""showthread.php?goto=lastpost&amp;threadid=3618324"">NurhacisUrn</a></td>
</tr><tr class=""thread"" id=""thread3618503"">
	<td class=""star ""></td>
	<td class=""icon""><a href=""/forumdisplay.php?forumid=1&amp;posticon=88""><img src=""http://fi.somethingawful.com/forums/posticons/icons-08/school.png#88"" alt=""""></a></td>
	<td class=""title"">
		<div class=""title_inner"">
			
			<div class=""info"">
				<a href=""showthread.php?threadid=3618503"" class=""thread_title"">The gender neutral term for &quot;shitlord&quot;</a>
				
			</div>
		</div>
	</td>
	<td class=""author""><a href=""member.php?action=getinfo&amp;userid=150375"">Cymbal Monkey</a></td>
	<td class=""replies"">15</td>
	<td class=""views"">512</td>
	<td class=""rating"">&nbsp;</td>
	<td class=""lastpost""><div class=""date"">16:53 Mar 21, 2014</div><a class=""author"" href=""showthread.php?goto=lastpost&amp;threadid=3618503"">satanic sex ritual</a></td>
</tr><tr class=""thread"" id=""thread3601343"">
	<td class=""star ""></td>
	<td class=""icon""><a href=""/forumdisplay.php?forumid=1&amp;posticon=104""><img src=""http://fi.somethingawful.com/forums/posticons/icons-08/event.png#104"" alt=""""></a></td>
	<td class=""title"">
		<div class=""title_inner"">
			
			<div class=""info"">
				<a href=""showthread.php?threadid=3601343"" class=""thread_title"">UK Goons</a>
				<div class=""title_pages"">Pages: <a class=""pagenumber"" href=""showthread.php?threadid=3601343&amp;pagenumber=1"">1</a><a class=""pagenumber"" href=""showthread.php?threadid=3601343&amp;pagenumber=2"">2</a><a class=""pagenumber"" href=""showthread.php?threadid=3601343&amp;pagenumber=3"">3</a><a class=""pagenumber"" href=""showthread.php?threadid=3601343&amp;pagenumber=4"">4</a><a class=""pagenumber"" href=""showthread.php?threadid=3601343&amp;pagenumber=5"">5</a><a class=""pagenumber"" href=""showthread.php?threadid=3601343&amp;pagenumber=6"">6</a><a class=""pagenumber"" href=""showthread.php?threadid=3601343&amp;pagenumber=7"">7</a>... <a class=""pagenumber"" href=""showthread.php?threadid=3601343&amp;goto=lastpost"">Last</a></div>
			</div>
		</div>
	</td>
	<td class=""author""><a href=""member.php?action=getinfo&amp;userid=165109"">NoneSuch</a></td>
	<td class=""replies"">2319</td>
	<td class=""views"">65587</td>
	<td class=""rating"">&nbsp;</td>
	<td class=""lastpost""><div class=""date"">16:53 Mar 21, 2014</div><a class=""author"" href=""showthread.php?goto=lastpost&amp;threadid=3601343"">Jakabite</a></td>
</tr><tr class=""thread"" id=""thread3618451"">
	<td class=""star ""></td>
	<td class=""icon""><a href=""/forumdisplay.php?forumid=1&amp;posticon=60""><img src=""http://fi.somethingawful.com/forums/posticons/icons-08/en.png#60"" alt=""""></a></td>
	<td class=""title"">
		<div class=""title_inner"">
			
			<div class=""info"">
				<a href=""showthread.php?threadid=3618451"" class=""thread_title"">billy corgan's batshit insane</a>
				<div class=""title_pages"">Pages: <a class=""pagenumber"" href=""showthread.php?threadid=3618451&amp;pagenumber=1"">1</a><a class=""pagenumber"" href=""showthread.php?threadid=3618451&amp;pagenumber=2"">2</a></div>
			</div>
		</div>
	</td>
	<td class=""author""><a href=""member.php?action=getinfo&amp;userid=153596"">JoeyJoJoJr Shabadoo</a></td>
	<td class=""replies"">56</td>
	<td class=""views"">2028</td>
	<td class=""rating"">&nbsp;</td>
	<td class=""lastpost""><div class=""date"">16:52 Mar 21, 2014</div><a class=""author"" href=""showthread.php?goto=lastpost&amp;threadid=3618451"">precision</a></td>
</tr><tr class=""thread seen"" id=""thread3610276"">
	<td class=""star ""></td>
	<td class=""icon""><a href=""/forumdisplay.php?forumid=1&amp;posticon=0""><img src=""http://fi.somethingawful.com/images/shitpost.gif#0"" alt=""""></a></td>
	<td class=""title"">
		<div class=""title_inner"">
			<div class=""lastseen""><a href=""/showthread.php?action=resetseen&amp;threadid=3610276"" class=""x"" title=""Mark as unread"">X</a><a title=""Jump to last read post"" href=""/showthread.php?threadid=3610276&amp;goto=newpost"" class=""count""><b>2226</b></a></div>
			<div class=""info"">
				<a href=""showthread.php?threadid=3610276"" class=""thread_title"">goon.jpg</a>
				<div class=""title_pages"">Pages: <a class=""pagenumber"" href=""showthread.php?threadid=3610276&amp;pagenumber=1"">1</a><a class=""pagenumber"" href=""showthread.php?threadid=3610276&amp;pagenumber=2"">2</a><a class=""pagenumber"" href=""showthread.php?threadid=3610276&amp;pagenumber=3"">3</a><a class=""pagenumber"" href=""showthread.php?threadid=3610276&amp;pagenumber=4"">4</a><a class=""pagenumber"" href=""showthread.php?threadid=3610276&amp;pagenumber=5"">5</a><a class=""pagenumber"" href=""showthread.php?threadid=3610276&amp;pagenumber=6"">6</a><a class=""pagenumber"" href=""showthread.php?threadid=3610276&amp;pagenumber=7"">7</a>... <a class=""pagenumber"" href=""showthread.php?threadid=3610276&amp;goto=lastpost"">Last</a></div>
			</div>
		</div>
	</td>
	<td class=""author""><a href=""member.php?action=getinfo&amp;userid=75674"">Slybo</a></td>
	<td class=""replies"">2305</td>
	<td class=""views"">305980</td>
	<td class=""rating""><img src=""http://fi.somethingawful.com/rate/default/5stars.gif"" alt="""" title=""233 votes - 4.88 average""></td>
	<td class=""lastpost""><div class=""date"">16:52 Mar 21, 2014</div><a class=""author"" href=""showthread.php?goto=lastpost&amp;threadid=3610276"">Twee as Fuck</a></td>
</tr><tr class=""thread seen"" id=""thread3618375"">
	<td class=""star ""></td>
	<td class=""icon""><a href=""/forumdisplay.php?forumid=1&amp;posticon=757""><img src=""http://fi.somethingawful.com/forums/posticons/ddrd-scsa.gif#757"" alt=""""></a></td>
	<td class=""title"">
		<div class=""title_inner"">
			<div class=""lastseen""><a href=""/showthread.php?action=resetseen&amp;threadid=3618375"" class=""x"" title=""Mark as unread"">X</a><a title=""Jump to last read post"" href=""/showthread.php?threadid=3618375&amp;goto=newpost"" class=""count""><b>166</b></a></div>
			<div class=""info"">
				<a href=""showthread.php?threadid=3618375"" class=""thread_title"">Mans chatting thread</a>
				<div class=""title_pages"">Pages: <a class=""pagenumber"" href=""showthread.php?threadid=3618375&amp;pagenumber=1"">1</a><a class=""pagenumber"" href=""showthread.php?threadid=3618375&amp;pagenumber=2"">2</a><a class=""pagenumber"" href=""showthread.php?threadid=3618375&amp;pagenumber=3"">3</a><a class=""pagenumber"" href=""showthread.php?threadid=3618375&amp;pagenumber=4"">4</a><a class=""pagenumber"" href=""showthread.php?threadid=3618375&amp;pagenumber=5"">5</a><a class=""pagenumber"" href=""showthread.php?threadid=3618375&amp;pagenumber=6"">6</a><a class=""pagenumber"" href=""showthread.php?threadid=3618375&amp;pagenumber=7"">7</a>... <a class=""pagenumber"" href=""showthread.php?threadid=3618375&amp;goto=lastpost"">Last</a></div>
			</div>
		</div>
	</td>
	<td class=""author""><a href=""member.php?action=getinfo&amp;userid=196165"">Strict Picnic</a></td>
	<td class=""replies"">325</td>
	<td class=""views"">3947</td>
	<td class=""rating"">&nbsp;</td>
	<td class=""lastpost""><div class=""date"">16:52 Mar 21, 2014</div><a class=""author"" href=""showthread.php?goto=lastpost&amp;threadid=3618375"">Savings Coupon</a></td>
</tr><tr class=""thread"" id=""thread3618159"">
	<td class=""star ""></td>
	<td class=""icon""><a href=""/forumdisplay.php?forumid=1&amp;posticon=692""><img src=""http://fi.somethingawful.com/forums/posticons/dd-9-11.gif#692"" alt=""""></a></td>
	<td class=""title"">
		<div class=""title_inner"">
			
			<div class=""info"">
				<a href=""showthread.php?threadid=3618159"" class=""thread_title"">post some cats</a>
				<div class=""title_pages"">Pages: <a class=""pagenumber"" href=""showthread.php?threadid=3618159&amp;pagenumber=1"">1</a><a class=""pagenumber"" href=""showthread.php?threadid=3618159&amp;pagenumber=2"">2</a><a class=""pagenumber"" href=""showthread.php?threadid=3618159&amp;pagenumber=3"">3</a></div>
			</div>
		</div>
	</td>
	<td class=""author""><a href=""member.php?action=getinfo&amp;userid=126878"">rhubarb creampie</a></td>
	<td class=""replies"">83</td>
	<td class=""views"">1812</td>
	<td class=""rating"">&nbsp;</td>
	<td class=""lastpost""><div class=""date"">16:51 Mar 21, 2014</div><a class=""author"" href=""showthread.php?goto=lastpost&amp;threadid=3618159"">Medium Cool</a></td>
</tr><tr class=""thread seen"" id=""thread3611139"">
	<td class=""star ""></td>
	<td class=""icon""><a href=""/forumdisplay.php?forumid=1&amp;posticon=81""><img src=""http://fi.somethingawful.com/forums/posticons/icons-08/fruity.png#81"" alt=""""></a></td>
	<td class=""title"">
		<div class=""title_inner"">
			<div class=""lastseen""><a href=""/showthread.php?action=resetseen&amp;threadid=3611139"" class=""x"" title=""Mark as unread"">X</a><a title=""Jump to last read post"" href=""/showthread.php?threadid=3611139&amp;goto=newpost"" class=""count""><b>3312</b></a></div>
			<div class=""info"">
				<a href=""showthread.php?threadid=3611139"" class=""thread_title"">okcupid</a>
				<div class=""title_pages"">Pages: <a class=""pagenumber"" href=""showthread.php?threadid=3611139&amp;pagenumber=1"">1</a><a class=""pagenumber"" href=""showthread.php?threadid=3611139&amp;pagenumber=2"">2</a><a class=""pagenumber"" href=""showthread.php?threadid=3611139&amp;pagenumber=3"">3</a><a class=""pagenumber"" href=""showthread.php?threadid=3611139&amp;pagenumber=4"">4</a><a class=""pagenumber"" href=""showthread.php?threadid=3611139&amp;pagenumber=5"">5</a><a class=""pagenumber"" href=""showthread.php?threadid=3611139&amp;pagenumber=6"">6</a><a class=""pagenumber"" href=""showthread.php?threadid=3611139&amp;pagenumber=7"">7</a>... <a class=""pagenumber"" href=""showthread.php?threadid=3611139&amp;goto=lastpost"">Last</a></div>
			</div>
		</div>
	</td>
	<td class=""author""><a href=""member.php?action=getinfo&amp;userid=187456"">macky2dope</a></td>
	<td class=""replies"">3551</td>
	<td class=""views"">198910</td>
	<td class=""rating""><img src=""http://fi.somethingawful.com/rate/default/4stars.gif"" alt="""" title=""69 votes - 4.11 average""></td>
	<td class=""lastpost""><div class=""date"">16:50 Mar 21, 2014</div><a class=""author"" href=""showthread.php?goto=lastpost&amp;threadid=3611139"">SaltLick</a></td>
</tr><tr class=""thread"" id=""thread3618413"">
	<td class=""star ""></td>
	<td class=""icon""><a href=""/forumdisplay.php?forumid=1&amp;posticon=105""><img src=""http://fi.somethingawful.com/forums/posticons/icons-08/tech.png#105"" alt=""""></a></td>
	<td class=""title"">
		<div class=""title_inner"">
			
			<div class=""info"">
				<a href=""showthread.php?threadid=3618413"" class=""thread_title"">ITT post the last text message you received from anyone</a>
				<div class=""title_pages"">Pages: <a class=""pagenumber"" href=""showthread.php?threadid=3618413&amp;pagenumber=1"">1</a><a class=""pagenumber"" href=""showthread.php?threadid=3618413&amp;pagenumber=2"">2</a><a class=""pagenumber"" href=""showthread.php?threadid=3618413&amp;pagenumber=3"">3</a></div>
			</div>
		</div>
	</td>
	<td class=""author""><a href=""member.php?action=getinfo&amp;userid=188833"">Gypsum Fantastic</a></td>
	<td class=""replies"">110</td>
	<td class=""views"">1878</td>
	<td class=""rating"">&nbsp;</td>
	<td class=""lastpost""><div class=""date"">16:49 Mar 21, 2014</div><a class=""author"" href=""showthread.php?goto=lastpost&amp;threadid=3618413"">AlphaNiner</a></td>
</tr><tr class=""thread seen"" id=""thread3617084"">
	<td class=""star ""></td>
	<td class=""icon""><a href=""/forumdisplay.php?forumid=1&amp;posticon=255""><img src=""http://fi.somethingawful.com/forums/posticons/fyad-falconry.gif#255"" alt=""""></a></td>
	<td class=""title"">
		<div class=""title_inner"">
			<div class=""lastseen""><a href=""/showthread.php?action=resetseen&amp;threadid=3617084"" class=""x"" title=""Mark as unread"">X</a><a title=""Jump to last read post"" href=""/showthread.php?threadid=3617084&amp;goto=newpost"" class=""count""><b>26</b></a></div>
			<div class=""info"">
				<a href=""showthread.php?threadid=3617084"" class=""thread_title"">Pit bull owners are the worst</a>
				<div class=""title_pages"">Pages: <a class=""pagenumber"" href=""showthread.php?threadid=3617084&amp;pagenumber=1"">1</a><a class=""pagenumber"" href=""showthread.php?threadid=3617084&amp;pagenumber=2"">2</a><a class=""pagenumber"" href=""showthread.php?threadid=3617084&amp;pagenumber=3"">3</a><a class=""pagenumber"" href=""showthread.php?threadid=3617084&amp;pagenumber=4"">4</a><a class=""pagenumber"" href=""showthread.php?threadid=3617084&amp;pagenumber=5"">5</a><a class=""pagenumber"" href=""showthread.php?threadid=3617084&amp;pagenumber=6"">6</a><a class=""pagenumber"" href=""showthread.php?threadid=3617084&amp;pagenumber=7"">7</a>... <a class=""pagenumber"" href=""showthread.php?threadid=3617084&amp;goto=lastpost"">Last</a></div>
			</div>
		</div>
	</td>
	<td class=""author""><a href=""member.php?action=getinfo&amp;userid=173051"">myshl0ng</a></td>
	<td class=""replies"">1145</td>
	<td class=""views"">32237</td>
	<td class=""rating"">&nbsp;</td>
	<td class=""lastpost""><div class=""date"">16:48 Mar 21, 2014</div><a class=""author"" href=""showthread.php?goto=lastpost&amp;threadid=3617084"">Kung Food</a></td>
</tr><tr class=""thread"" id=""thread3582735"">
	<td class=""star ""></td>
	<td class=""icon""><a href=""/forumdisplay.php?forumid=1&amp;posticon=81""><img src=""http://fi.somethingawful.com/forums/posticons/icons-08/fruity.png#81"" alt=""""></a></td>
	<td class=""title"">
		<div class=""title_inner"">
			
			<div class=""info"">
				<a href=""showthread.php?threadid=3582735"" class=""thread_title"">Let's have a nice time talking about Australian politics, generally</a>
				<div class=""title_pages"">Pages: <a class=""pagenumber"" href=""showthread.php?threadid=3582735&amp;pagenumber=1"">1</a><a class=""pagenumber"" href=""showthread.php?threadid=3582735&amp;pagenumber=2"">2</a><a class=""pagenumber"" href=""showthread.php?threadid=3582735&amp;pagenumber=3"">3</a><a class=""pagenumber"" href=""showthread.php?threadid=3582735&amp;pagenumber=4"">4</a><a class=""pagenumber"" href=""showthread.php?threadid=3582735&amp;pagenumber=5"">5</a><a class=""pagenumber"" href=""showthread.php?threadid=3582735&amp;pagenumber=6"">6</a><a class=""pagenumber"" href=""showthread.php?threadid=3582735&amp;pagenumber=7"">7</a>... <a class=""pagenumber"" href=""showthread.php?threadid=3582735&amp;goto=lastpost"">Last</a></div>
			</div>
		</div>
	</td>
	<td class=""author""><a href=""member.php?action=getinfo&amp;userid=173910"">LordPants</a></td>
	<td class=""replies"">16599</td>
	<td class=""views"">252038</td>
	<td class=""rating""><img src=""http://fi.somethingawful.com/rate/default/4stars.gif"" alt="""" title=""75 votes - 3.59 average""></td>
	<td class=""lastpost""><div class=""date"">16:48 Mar 21, 2014</div><a class=""author"" href=""showthread.php?goto=lastpost&amp;threadid=3582735"">XyloJW</a></td>
</tr><tr class=""thread seen"" id=""thread3618307"">
	<td class=""star ""></td>
	<td class=""icon""><a href=""/forumdisplay.php?forumid=1&amp;posticon=757""><img src=""http://fi.somethingawful.com/forums/posticons/ddrd-scsa.gif#757"" alt=""""></a></td>
	<td class=""title"">
		<div class=""title_inner"">
			<div class=""lastseen""><a href=""/showthread.php?action=resetseen&amp;threadid=3618307"" class=""x"" title=""Mark as unread"">X</a><a title=""Jump to last read post"" href=""/showthread.php?threadid=3618307&amp;goto=newpost"" class=""count""><b>4</b></a></div>
			<div class=""info"">
				<a href=""showthread.php?threadid=3618307"" class=""thread_title"">could someone post stone cold steve austin gif</a>
				
			</div>
		</div>
	</td>
	<td class=""author""><a href=""member.php?action=getinfo&amp;userid=117026"">ArtIsResistance</a></td>
	<td class=""replies"">24</td>
	<td class=""views"">608</td>
	<td class=""rating"">&nbsp;</td>
	<td class=""lastpost""><div class=""date"">16:48 Mar 21, 2014</div><a class=""author"" href=""showthread.php?goto=lastpost&amp;threadid=3618307"">Medium Cool</a></td>
</tr><tr class=""thread"" id=""thread3618529"">
	<td class=""star ""></td>
	<td class=""icon""><a href=""/forumdisplay.php?forumid=1&amp;posticon=67""><img src=""http://fi.somethingawful.com/forums/posticons/icons-08/newbie.png#67"" alt=""""></a></td>
	<td class=""title"">
		<div class=""title_inner"">
			
			<div class=""info"">
				<a href=""showthread.php?threadid=3618529"" class=""thread_title"">holy shit 'comedy bang bang' is awesome (NT)</a>
				
			</div>
		</div>
	</td>
	<td class=""author""><a href=""member.php?action=getinfo&amp;userid=67418"">Limastock</a></td>
	<td class=""replies"">4</td>
	<td class=""views"">89</td>
	<td class=""rating"">&nbsp;</td>
	<td class=""lastpost""><div class=""date"">16:48 Mar 21, 2014</div><a class=""author"" href=""showthread.php?goto=lastpost&amp;threadid=3618529"">Limastock</a></td>
</tr><tr class=""thread"" id=""thread3618522"">
	<td class=""star ""></td>
	<td class=""icon""><a href=""/forumdisplay.php?forumid=1&amp;posticon=92""><img src=""http://fi.somethingawful.com/forums/posticons/icons-08/sex.png#92"" alt=""""></a></td>
	<td class=""title"">
		<div class=""title_inner"">
			
			<div class=""info"">
				<a href=""showthread.php?threadid=3618522"" class=""thread_title"">Are you depressed?</a>
				
			</div>
		</div>
	</td>
	<td class=""author""><a href=""member.php?action=getinfo&amp;userid=141104"">open container</a></td>
	<td class=""replies"">19</td>
	<td class=""views"">349</td>
	<td class=""rating"">&nbsp;</td>
	<td class=""lastpost""><div class=""date"">16:48 Mar 21, 2014</div><a class=""author"" href=""showthread.php?goto=lastpost&amp;threadid=3618522"">mookface</a></td>
</tr><tr class=""thread seen"" id=""thread3543334"">
	<td class=""star ""></td>
	<td class=""icon""><a href=""/forumdisplay.php?forumid=1&amp;posticon=692""><img src=""http://fi.somethingawful.com/forums/posticons/dd-9-11.gif#692"" alt=""""></a></td>
	<td class=""title"">
		<div class=""title_inner"">
			<div class=""lastseen""><a href=""/showthread.php?action=resetseen&amp;threadid=3543334"" class=""x"" title=""Mark as unread"">X</a><a title=""Jump to last read post"" href=""/showthread.php?threadid=3543334&amp;goto=newpost"" class=""count""><b>18150</b></a></div>
			<div class=""info"">
				<a href=""showthread.php?threadid=3543334"" class=""thread_title"">Bitcoin - https://www.youtube.com/watch?v=B-DpRcxK_N8</a>
				<div class=""title_pages"">Pages: <a class=""pagenumber"" href=""showthread.php?threadid=3543334&amp;pagenumber=1"">1</a><a class=""pagenumber"" href=""showthread.php?threadid=3543334&amp;pagenumber=2"">2</a><a class=""pagenumber"" href=""showthread.php?threadid=3543334&amp;pagenumber=3"">3</a><a class=""pagenumber"" href=""showthread.php?threadid=3543334&amp;pagenumber=4"">4</a><a class=""pagenumber"" href=""showthread.php?threadid=3543334&amp;pagenumber=5"">5</a><a class=""pagenumber"" href=""showthread.php?threadid=3543334&amp;pagenumber=6"">6</a><a class=""pagenumber"" href=""showthread.php?threadid=3543334&amp;pagenumber=7"">7</a>... <a class=""pagenumber"" href=""showthread.php?threadid=3543334&amp;goto=lastpost"">Last</a></div>
			</div>
		</div>
	</td>
	<td class=""author""><a href=""member.php?action=getinfo&amp;userid=124712"">Talorat</a></td>
	<td class=""replies"">42949</td>
	<td class=""views"">4072639</td>
	<td class=""rating""><img src=""http://fi.somethingawful.com/rate/default/4stars.gif"" alt="""" title=""487 votes - 3.77 average""></td>
	<td class=""lastpost""><div class=""date"">16:46 Mar 21, 2014</div><a class=""author"" href=""showthread.php?goto=lastpost&amp;threadid=3543334"">Tipps</a></td>
</tr><tr class=""thread seen"" id=""thread3611001"">
	<td class=""star ""></td>
	<td class=""icon""><a href=""/forumdisplay.php?forumid=1&amp;posticon=692""><img src=""http://fi.somethingawful.com/forums/posticons/dd-9-11.gif#692"" alt=""""></a></td>
	<td class=""title"">
		<div class=""title_inner"">
			<div class=""lastseen""><a href=""/showthread.php?action=resetseen&amp;threadid=3611001"" class=""x"" title=""Mark as unread"">X</a><a title=""Jump to last read post"" href=""/showthread.php?threadid=3611001&amp;goto=newpost"" class=""count""><b>1580</b></a></div>
			<div class=""info"">
				<a href=""showthread.php?threadid=3611001"" class=""thread_title"">Doobies Dog House, Star Citizen and now DayZ Stand Alone</a>
				<div class=""title_pages"">Pages: <a class=""pagenumber"" href=""showthread.php?threadid=3611001&amp;pagenumber=1"">1</a><a class=""pagenumber"" href=""showthread.php?threadid=3611001&amp;pagenumber=2"">2</a><a class=""pagenumber"" href=""showthread.php?threadid=3611001&amp;pagenumber=3"">3</a><a class=""pagenumber"" href=""showthread.php?threadid=3611001&amp;pagenumber=4"">4</a><a class=""pagenumber"" href=""showthread.php?threadid=3611001&amp;pagenumber=5"">5</a><a class=""pagenumber"" href=""showthread.php?threadid=3611001&amp;pagenumber=6"">6</a><a class=""pagenumber"" href=""showthread.php?threadid=3611001&amp;pagenumber=7"">7</a>... <a class=""pagenumber"" href=""showthread.php?threadid=3611001&amp;goto=lastpost"">Last</a></div>
			</div>
		</div>
	</td>
	<td class=""author""><a href=""member.php?action=getinfo&amp;userid=202828"">Sanky Panky</a></td>
	<td class=""replies"">1659</td>
	<td class=""views"">75472</td>
	<td class=""rating""><img src=""http://fi.somethingawful.com/rate/default/4stars.gif"" alt="""" title=""61 votes - 4.35 average""></td>
	<td class=""lastpost""><div class=""date"">16:46 Mar 21, 2014</div><a class=""author"" href=""showthread.php?goto=lastpost&amp;threadid=3611001"">Limastock</a></td>
</tr><tr class=""thread seen"" id=""thread3618435"">
	<td class=""star ""></td>
	<td class=""icon""><a href=""/forumdisplay.php?forumid=1&amp;posticon=92""><img src=""http://fi.somethingawful.com/forums/posticons/icons-08/sex.png#92"" alt=""""></a></td>
	<td class=""title"">
		<div class=""title_inner"">
			<div class=""lastseen""><a href=""/showthread.php?action=resetseen&amp;threadid=3618435"" class=""x"" title=""Mark as unread"">X</a><a title=""Jump to last read post"" href=""/showthread.php?threadid=3618435&amp;goto=newpost"" class=""count""><b>21</b></a></div>
			<div class=""info"">
				<a href=""showthread.php?threadid=3618435"" class=""thread_title"">Having a female BFF seems like a bad idea, as a dude</a>
				<div class=""title_pages"">Pages: <a class=""pagenumber"" href=""showthread.php?threadid=3618435&amp;pagenumber=1"">1</a><a class=""pagenumber"" href=""showthread.php?threadid=3618435&amp;pagenumber=2"">2</a><a class=""pagenumber"" href=""showthread.php?threadid=3618435&amp;pagenumber=3"">3</a></div>
			</div>
		</div>
	</td>
	<td class=""author""><a href=""member.php?action=getinfo&amp;userid=119383"">Slime Bro Helpdesk</a></td>
	<td class=""replies"">100</td>
	<td class=""views"">3431</td>
	<td class=""rating"">&nbsp;</td>
	<td class=""lastpost""><div class=""date"">16:46 Mar 21, 2014</div><a class=""author"" href=""showthread.php?goto=lastpost&amp;threadid=3618435"">GROVER CURES HOUSE</a></td>
</tr><tr class=""thread seen"" id=""thread3618412"">
	<td class=""star ""></td>
	<td class=""icon""><a href=""/forumdisplay.php?forumid=1&amp;posticon=92""><img src=""http://fi.somethingawful.com/forums/posticons/icons-08/sex.png#92"" alt=""""></a></td>
	<td class=""title"">
		<div class=""title_inner"">
			<div class=""lastseen""><a href=""/showthread.php?action=resetseen&amp;threadid=3618412"" class=""x"" title=""Mark as unread"">X</a><a title=""Jump to last read post"" href=""/showthread.php?threadid=3618412&amp;goto=newpost"" class=""count""><b>142</b></a></div>
			<div class=""info"">
				<a href=""showthread.php?threadid=3618412"" class=""thread_title"">&quot;Archer sucks and isn't funny&quot;</a>
				<div class=""title_pages"">Pages: <a class=""pagenumber"" href=""showthread.php?threadid=3618412&amp;pagenumber=1"">1</a><a class=""pagenumber"" href=""showthread.php?threadid=3618412&amp;pagenumber=2"">2</a><a class=""pagenumber"" href=""showthread.php?threadid=3618412&amp;pagenumber=3"">3</a><a class=""pagenumber"" href=""showthread.php?threadid=3618412&amp;pagenumber=4"">4</a><a class=""pagenumber"" href=""showthread.php?threadid=3618412&amp;pagenumber=5"">5</a></div>
			</div>
		</div>
	</td>
	<td class=""author""><a href=""member.php?action=getinfo&amp;userid=120644"">quakster</a></td>
	<td class=""replies"">164</td>
	<td class=""views"">5940</td>
	<td class=""rating"">&nbsp;</td>
	<td class=""lastpost""><div class=""date"">16:43 Mar 21, 2014</div><a class=""author"" href=""showthread.php?goto=lastpost&amp;threadid=3618412"">Carver Crisis</a></td>
</tr><tr class=""thread"" id=""thread3612536"">
	<td class=""star ""></td>
	<td class=""icon""><a href=""/forumdisplay.php?forumid=1&amp;posticon=115""><img src=""http://fi.somethingawful.com/forums/posticons/icons-08/serious.png#115"" alt=""""></a></td>
	<td class=""title"">
		<div class=""title_inner"">
			
			<div class=""info"">
				<a href=""showthread.php?threadid=3612536"" class=""thread_title"">I am ready to fight and die in Ukraine. Are you?</a>
				<div class=""title_pages"">Pages: <a class=""pagenumber"" href=""showthread.php?threadid=3612536&amp;pagenumber=1"">1</a><a class=""pagenumber"" href=""showthread.php?threadid=3612536&amp;pagenumber=2"">2</a><a class=""pagenumber"" href=""showthread.php?threadid=3612536&amp;pagenumber=3"">3</a><a class=""pagenumber"" href=""showthread.php?threadid=3612536&amp;pagenumber=4"">4</a><a class=""pagenumber"" href=""showthread.php?threadid=3612536&amp;pagenumber=5"">5</a><a class=""pagenumber"" href=""showthread.php?threadid=3612536&amp;pagenumber=6"">6</a><a class=""pagenumber"" href=""showthread.php?threadid=3612536&amp;pagenumber=7"">7</a>... <a class=""pagenumber"" href=""showthread.php?threadid=3612536&amp;goto=lastpost"">Last</a></div>
			</div>
		</div>
	</td>
	<td class=""author""><a href=""member.php?action=getinfo&amp;userid=27860"">Mein Eyes!</a></td>
	<td class=""replies"">840</td>
	<td class=""views"">38847</td>
	<td class=""rating"">&nbsp;</td>
	<td class=""lastpost""><div class=""date"">16:39 Mar 21, 2014</div><a class=""author"" href=""showthread.php?goto=lastpost&amp;threadid=3612536"">Hogge Wild</a></td>
</tr><tr class=""thread seen"" id=""thread3617730"">
	<td class=""star ""></td>
	<td class=""icon""><a href=""/forumdisplay.php?forumid=1&amp;posticon=692""><img src=""http://fi.somethingawful.com/forums/posticons/dd-9-11.gif#692"" alt=""""></a></td>
	<td class=""title"">
		<div class=""title_inner"">
			<div class=""lastseen""><a href=""/showthread.php?action=resetseen&amp;threadid=3617730"" class=""x"" title=""Mark as unread"">X</a><a title=""Jump to last read post"" href=""/showthread.php?threadid=3617730&amp;goto=newpost"" class=""count""><b>245</b></a></div>
			<div class=""info"">
				<a href=""showthread.php?threadid=3617730"" class=""thread_title"">You just hate me 'cause I clop.</a>
				<div class=""title_pages"">Pages: <a class=""pagenumber"" href=""showthread.php?threadid=3617730&amp;pagenumber=1"">1</a><a class=""pagenumber"" href=""showthread.php?threadid=3617730&amp;pagenumber=2"">2</a><a class=""pagenumber"" href=""showthread.php?threadid=3617730&amp;pagenumber=3"">3</a><a class=""pagenumber"" href=""showthread.php?threadid=3617730&amp;pagenumber=4"">4</a><a class=""pagenumber"" href=""showthread.php?threadid=3617730&amp;pagenumber=5"">5</a><a class=""pagenumber"" href=""showthread.php?threadid=3617730&amp;pagenumber=6"">6</a><a class=""pagenumber"" href=""showthread.php?threadid=3617730&amp;pagenumber=7"">7</a>... <a class=""pagenumber"" href=""showthread.php?threadid=3617730&amp;goto=lastpost"">Last</a></div>
			</div>
		</div>
	</td>
	<td class=""author""><a href=""member.php?action=getinfo&amp;userid=177644"">Doctor Chaxtical</a></td>
	<td class=""replies"">364</td>
	<td class=""views"">13293</td>
	<td class=""rating"">&nbsp;</td>
	<td class=""lastpost""><div class=""date"">16:34 Mar 21, 2014</div><a class=""author"" href=""showthread.php?goto=lastpost&amp;threadid=3617730"">Entropia</a></td>
</tr><tr class=""thread"" id=""thread3614902"">
	<td class=""star ""></td>
	<td class=""icon""><a href=""/forumdisplay.php?forumid=1&amp;posticon=692""><img src=""http://fi.somethingawful.com/forums/posticons/dd-9-11.gif#692"" alt=""""></a></td>
	<td class=""title"">
		<div class=""title_inner"">
			
			<div class=""info"">
				<a href=""showthread.php?threadid=3614902"" class=""thread_title"">Another 777 crashed you probably knew someone on it</a>
				<div class=""title_pages"">Pages: <a class=""pagenumber"" href=""showthread.php?threadid=3614902&amp;pagenumber=1"">1</a><a class=""pagenumber"" href=""showthread.php?threadid=3614902&amp;pagenumber=2"">2</a><a class=""pagenumber"" href=""showthread.php?threadid=3614902&amp;pagenumber=3"">3</a><a class=""pagenumber"" href=""showthread.php?threadid=3614902&amp;pagenumber=4"">4</a><a class=""pagenumber"" href=""showthread.php?threadid=3614902&amp;pagenumber=5"">5</a><a class=""pagenumber"" href=""showthread.php?threadid=3614902&amp;pagenumber=6"">6</a><a class=""pagenumber"" href=""showthread.php?threadid=3614902&amp;pagenumber=7"">7</a>... <a class=""pagenumber"" href=""showthread.php?threadid=3614902&amp;goto=lastpost"">Last</a></div>
			</div>
		</div>
	</td>
	<td class=""author""><a href=""member.php?action=getinfo&amp;userid=77153"">Three Olives</a></td>
	<td class=""replies"">2479</td>
	<td class=""views"">175126</td>
	<td class=""rating""><img src=""http://fi.somethingawful.com/rate/default/3stars.gif"" alt="""" title=""27 votes - 2.93 average""></td>
	<td class=""lastpost""><div class=""date"">16:34 Mar 21, 2014</div><a class=""author"" href=""showthread.php?goto=lastpost&amp;threadid=3614902"">Zogo</a></td>
</tr><tr class=""thread"" id=""thread3618518"">
	<td class=""star ""></td>
	<td class=""icon""><a href=""/forumdisplay.php?forumid=1&amp;posticon=75""><img src=""http://fi.somethingawful.com/forums/posticons/icons-08/news.png#75"" alt=""""></a></td>
	<td class=""title"">
		<div class=""title_inner"">
			
			<div class=""info"">
				<a href=""showthread.php?threadid=3618518"" class=""thread_title"">The more money you make the more your bitches want from you and if you make</a>
				
			</div>
		</div>
	</td>
	<td class=""author""><a href=""member.php?action=getinfo&amp;userid=82291"">Jabbu</a></td>
	<td class=""replies"">13</td>
	<td class=""views"">246</td>
	<td class=""rating"">&nbsp;</td>
	<td class=""lastpost""><div class=""date"">16:29 Mar 21, 2014</div><a class=""author"" href=""showthread.php?goto=lastpost&amp;threadid=3618518"">naem</a></td>
</tr><tr class=""thread seen"" id=""thread3536751"">
	<td class=""star ""></td>
	<td class=""icon""><a href=""/forumdisplay.php?forumid=1&amp;posticon=114""><img src=""http://forumimages.somethingawful.com/forums/posticons/icons-08/art.png#114"" alt=""""></a></td>
	<td class=""title"">
		<div class=""title_inner"">
			<div class=""lastseen""><a href=""/showthread.php?action=resetseen&amp;threadid=3536751"" class=""x"" title=""Mark as unread"">X</a><a title=""Jump to last read post"" href=""/showthread.php?threadid=3536751&amp;goto=newpost"" class=""count""><b>2406</b></a></div>
			<div class=""info"">
				<a href=""showthread.php?threadid=3536751"" class=""thread_title"">Awful Kickstarters Vol II: Reach for Your Microwallets!</a>
				<div class=""title_pages"">Pages: <a class=""pagenumber"" href=""showthread.php?threadid=3536751&amp;pagenumber=1"">1</a><a class=""pagenumber"" href=""showthread.php?threadid=3536751&amp;pagenumber=2"">2</a><a class=""pagenumber"" href=""showthread.php?threadid=3536751&amp;pagenumber=3"">3</a><a class=""pagenumber"" href=""showthread.php?threadid=3536751&amp;pagenumber=4"">4</a><a class=""pagenumber"" href=""showthread.php?threadid=3536751&amp;pagenumber=5"">5</a><a class=""pagenumber"" href=""showthread.php?threadid=3536751&amp;pagenumber=6"">6</a><a class=""pagenumber"" href=""showthread.php?threadid=3536751&amp;pagenumber=7"">7</a>... <a class=""pagenumber"" href=""showthread.php?threadid=3536751&amp;goto=lastpost"">Last</a></div>
			</div>
		</div>
	</td>
	<td class=""author""><a href=""member.php?action=getinfo&amp;userid=178057"">wit</a></td>
	<td class=""replies"">7289</td>
	<td class=""views"">1009924</td>
	<td class=""rating""><img src=""http://fi.somethingawful.com/rate/default/4stars.gif"" alt="""" title=""91 votes - 3.85 average""></td>
	<td class=""lastpost""><div class=""date"">16:27 Mar 21, 2014</div><a class=""author"" href=""showthread.php?goto=lastpost&amp;threadid=3536751"">Regy Rusty</a></td>
</tr><tr class=""thread"" id=""thread3618400"">
	<td class=""star ""></td>
	<td class=""icon""><a href=""/forumdisplay.php?forumid=1&amp;posticon=128""><img src=""http://fi.somethingawful.com/forums/posticons/icons-08/food.png#128"" alt=""""></a></td>
	<td class=""title"">
		<div class=""title_inner"">
			
			<div class=""info"">
				<a href=""showthread.php?threadid=3618400"" class=""thread_title"">Sardine thread</a>
				<div class=""title_pages"">Pages: <a class=""pagenumber"" href=""showthread.php?threadid=3618400&amp;pagenumber=1"">1</a><a class=""pagenumber"" href=""showthread.php?threadid=3618400&amp;pagenumber=2"">2</a></div>
			</div>
		</div>
	</td>
	<td class=""author""><a href=""member.php?action=getinfo&amp;userid=164260"">FaradayCage</a></td>
	<td class=""replies"">55</td>
	<td class=""views"">1018</td>
	<td class=""rating"">&nbsp;</td>
	<td class=""lastpost""><div class=""date"">16:05 Mar 21, 2014</div><a class=""author"" href=""showthread.php?goto=lastpost&amp;threadid=3618400"">naem</a></td>
</tr>
	</tbody>
</table>
<div class=""forumbar"">
	<ul class=""postbuttons""><li><a href=""newthread.php?action=newthread&amp;forumid=1""><img src=""http://fi.somethingawful.com/images/forum-post.gif"" alt=""Post New Thread""></a></li></ul>
</div>



<script type=""text/javascript"">
try { add_whoposted_links(); } catch(e) {};
</script>

<div class=""pages bottom""><span class=""disabled"">&laquo;</span><span class=""disabled"">&lsaquo;</span><select data-url=""forumdisplay.php?forumid=1&amp;daysprune=15&amp;perpage=40&amp;posticon=0&amp;sortorder=desc&amp;sortfield=lastpost""><option value=""1"" selected=""selected"">1</option><option value=""2"">2</option><option value=""3"">3</option><option value=""4"">4</option><option value=""5"">5</option><option value=""6"">6</option><option value=""7"">7</option><option value=""8"">8</option><option value=""9"">9</option><option value=""10"">10</option><option value=""11"">11</option><option value=""12"">12</option><option value=""13"">13</option><option value=""14"">14</option><option value=""15"">15</option><option value=""16"">16</option><option value=""17"">17</option><option value=""18"">18</option><option value=""19"">19</option><option value=""20"">20</option><option value=""21"">21</option><option value=""22"">22</option><option value=""23"">23</option><option value=""24"">24</option><option value=""25"">25</option><option value=""26"">26</option><option value=""27"">27</option><option value=""28"">28</option><option value=""29"">29</option><option value=""30"">30</option><option value=""31"">31</option><option value=""32"">32</option><option value=""33"">33</option><option value=""34"">34</option><option value=""35"">35</option><option value=""36"">36</option><option value=""37"">37</option><option value=""38"">38</option><option value=""39"">39</option><option value=""40"">40</option><option value=""41"">41</option><option value=""42"">42</option><option value=""43"">43</option><option value=""44"">44</option><option value=""45"">45</option><option value=""46"">46</option><option value=""47"">47</option><option value=""48"">48</option><option value=""49"">49</option><option value=""50"">50</option><option value=""51"">51</option><option value=""52"">52</option><option value=""53"">53</option><option value=""54"">54</option><option value=""55"">55</option><option value=""56"">56</option><option value=""57"">57</option><option value=""58"">58</option><option value=""59"">59</option><option value=""60"">60</option><option value=""61"">61</option><option value=""62"">62</option><option value=""63"">63</option><option value=""64"">64</option><option value=""65"">65</option><option value=""66"">66</option><option value=""67"">67</option><option value=""68"">68</option><option value=""69"">69</option><option value=""70"">70</option><option value=""71"">71</option><option value=""72"">72</option><option value=""73"">73</option><option value=""74"">74</option><option value=""75"">75</option><option value=""76"">76</option><option value=""77"">77</option><option value=""78"">78</option><option value=""79"">79</option><option value=""80"">80</option><option value=""81"">81</option><option value=""82"">82</option><option value=""83"">83</option><option value=""84"">84</option><option value=""85"">85</option><option value=""86"">86</option><option value=""87"">87</option><option value=""88"">88</option><option value=""89"">89</option><option value=""90"">90</option><option value=""91"">91</option><option value=""92"">92</option><option value=""93"">93</option><option value=""94"">94</option><option value=""95"">95</option><option value=""96"">96</option><option value=""97"">97</option><option value=""98"">98</option><option value=""99"">99</option><option value=""100"">100</option><option value=""101"">101</option><option value=""102"">102</option><option value=""103"">103</option><option value=""104"">104</option><option value=""105"">105</option><option value=""106"">106</option><option value=""107"">107</option><option value=""108"">108</option><option value=""109"">109</option><option value=""110"">110</option><option value=""111"">111</option><option value=""112"">112</option><option value=""113"">113</option><option value=""114"">114</option><option value=""115"">115</option><option value=""116"">116</option><option value=""117"">117</option><option value=""118"">118</option><option value=""119"">119</option><option value=""120"">120</option><option value=""121"">121</option><option value=""122"">122</option><option value=""123"">123</option><option value=""124"">124</option><option value=""125"">125</option><option value=""126"">126</option><option value=""127"">127</option><option value=""128"">128</option><option value=""129"">129</option><option value=""130"">130</option><option value=""131"">131</option><option value=""132"">132</option><option value=""133"">133</option><option value=""134"">134</option><option value=""135"">135</option><option value=""136"">136</option><option value=""137"">137</option><option value=""138"">138</option><option value=""139"">139</option><option value=""140"">140</option><option value=""141"">141</option><option value=""142"">142</option><option value=""143"">143</option><option value=""144"">144</option><option value=""145"">145</option><option value=""146"">146</option><option value=""147"">147</option><option value=""148"">148</option><option value=""149"">149</option><option value=""150"">150</option><option value=""151"">151</option><option value=""152"">152</option><option value=""153"">153</option><option value=""154"">154</option><option value=""155"">155</option></select><a href=""forumdisplay.php?forumid=1&amp;daysprune=15&amp;perpage=40&amp;posticon=0&amp;sortorder=desc&amp;sortfield=lastpost&pagenumber=2"" title=""Next page"">&rsaquo;</a><a href=""forumdisplay.php?forumid=1&amp;daysprune=15&amp;perpage=40&amp;posticon=0&amp;sortorder=desc&amp;sortfield=lastpost&pagenumber=155"" title=""Last page"">155 &raquo;</a></div>
<div class=""breadcrumbs""><span class=""mainbodytextlarge""><b><a href=""/"">The Something Awful Forums</a> &gt; <a href=""forumdisplay.php?forumid=48"">Main</a> &gt; <a href=""forumdisplay.php?forumid=1"" class=""bclast"">GBS 1.4</a></b></span> <span class=""online_users"">(<a href=""/online.php?forumid=1"" title=""View members browsing this forum"">913 users browsing</a>)</span></div>

<div class=""bottom_forms"">
	
<form class=""forum_jump"" action=""forumdisplay.php"" method=""get"">
<input type=""hidden"" name=""s"" value="""">
<input type=""hidden"" name=""daysprune"" value="""">
<select name=""forumid"">
<option value=""-1"" selected>Jump to another forum:</option>
<option value=""-1"">--------------------</option>
<option value=""pm"" >Private Messages</option>
<option value=""cp"" >User Control Panel</option>
<option value=""search"" >Search Forums</option>
<option value=""home"" >Forums Home</option>
<option value=""lc"" >Leper's Colony</option>
<option value=""-1"">--------------------</option>
<option value=""48"" > Main</option><option value=""1"" >-- GBS 1.4</option><option value=""155"" >---- SA's Front Page Discussion</option><option value=""214"" >---- E/N Bullshit</option><option value=""26"" >-- FYAD: http://vimeo.com/86014703</option><option value=""154"" >---- A Beecock Forum.</option><option value=""268"" >-- BYOB 8.2</option><option value=""51"" > Discussion</option><option value=""44"" >-- Games</option><option value=""259"" >---- A Blizzard Subforum</option><option value=""146"" >------ WoW: Goon Squad</option><option value=""145"" >---- The MMO HMO</option><option value=""93"" >---- Private Game Servers</option><option value=""234"" >---- Dice &amp; Drama</option><option value=""103"" >------ The Goblin Ranch</option><option value=""191"" >---- Let's Play!</option><option value=""267"" >---- Dungeons &amp; Dreamcast Recreation Dome</option><option value=""192"" >-- Inspect Your Gadgets</option><option value=""158"" >-- Ask / Tell</option><option value=""162"" >---- Science, Academics and Languages</option><option value=""211"" >---- Tourism &amp; Travel</option><option value=""200"" >---- Business, Finance, and Careers</option><option value=""46"" >-- Debate Disco</option><option value=""22"" >-- Serious Hardware / Software Crap</option><option value=""170"" >---- Haus of Tech Support</option><option value=""202"" >---- The Cavern of COBOL</option><option value=""265"" >------ project.log</option><option value=""219"" >---- YOSPOS</option><option value=""122"" >-- Sports Argument Stadium* </option><option value=""181"" >---- The Football Funhouse</option><option value=""248"" >---- The Armchair Quarterback</option><option value=""175"" >---- The Ray Parlour</option><option value=""177"" >---- Punchsport Pagoda</option><option value=""179"" >-- You Look Like Shit</option><option value=""183"" >---- The Goon Doctor</option><option value=""244"" >---- The Fitness Log Cabin</option><option value=""242"" >-- Paranormal/Conspiracy Forum</option><option value=""161"" >-- Goons With Spoons</option><option value=""167"" >-- Post Your Favorite (or Request)</option><option value=""91"" >-- Automotive Insanity</option><option value=""236"" >---- Cycle Asylum</option><option value=""124"" >-- Pet Island</option><option value=""132"" >-- The Firing Range</option><option value=""90"" >-- The Crackhead Clubhouse</option><option value=""218"" >-- Goons in Platoons</option><option value=""152"" > The Finer Arts</option><option value=""31"" >-- Creative Convention</option><option value=""210"" >---- DIY &amp; Hobbies</option><option value=""247"" >---- The Dorkroom</option><option value=""151"" >-- Cinema Discusso</option><option value=""133"" >---- The Film Dump</option><option value=""182"" >-- The Book Barn</option><option value=""150"" >-- No Music Discussion</option><option value=""104"" >---- Musician's Lounge</option><option value=""130"" >-- The TV IV</option><option value=""144"" >-- Batman's Shameful Secret</option><option value=""27"" >-- ADTRW</option><option value=""215"" >-- Entertainment, Weakly</option><option value=""255"" >-- Rapidly Going Deaf</option><option value=""153"" > The Community</option><option value=""61"" >-- SA-Mart</option><option value=""77"" >---- Feedback &amp; Discussion</option><option value=""85"" >---- Coupons &amp; Deals</option><option value=""43"" >-- Goon Meets</option><option value=""241"" >-- LAN: Your City Sucks - Regional Discussion</option><option value=""188"" >-- Questions, Comments, Suggestions? - Read the stickies first!</option><option value=""49"" > Archives</option><option value=""21"" >-- Comedy Goldmine</option><option value=""264"" >---- Comedy Purgatory</option><option value=""115"" >---- FYAD: Criterion Collection</option><option value=""204"" >---- Helldump Success Stories</option><option value=""222"" >---- LF Goldmine</option><option value=""229"" >---- YCS Goldmine</option><option value=""25"" >-- Comedy Gas Chamber</option>
</select>
<input type=""submit"" value=""Go"">
</form>
	<form method=""POST"" action=""/forumdisplay.php?forumid=1"" id=""ac_timemachine"">
Archives: <select name=""ac_month"" disabled>
	<option value="""">&nbsp;</option>
	<option value=""1"">January</option>
	<option value=""2"">February</option>
	<option value=""3"">March</option>
	<option value=""4"">April</option>
	<option value=""5"">May</option>
	<option value=""6"">June</option>
	<option value=""7"">July</option>
	<option value=""8"">August</option>
	<option value=""9"">September</option>
	<option value=""10"">October</option>
	<option value=""11"">November</option>
	<option value=""12"">December</option>
</select>
<select name=""ac_day"" disabled>
	<option value="""">&nbsp;</option>
	<option>1</option>
	<option>2</option>
	<option>3</option>
	<option>4</option>
	<option>5</option>
	<option>6</option>
	<option>7</option>
	<option>8</option>
	<option>9</option>
	<option>10</option>
	<option>11</option>
	<option>12</option>
	<option>13</option>
	<option>14</option>
	<option>15</option>
	<option>16</option>
	<option>17</option>
	<option>18</option>
	<option>19</option>
	<option>20</option>
	<option>21</option>
	<option>22</option>
	<option>23</option>
	<option>24</option>
	<option>25</option>
	<option>26</option>
	<option>27</option>
	<option>28</option>
	<option>29</option>
	<option>30</option>
	<option>31</option>
</select>
<select name=""ac_year"" disabled>
	<option selected>2014</option>
	<option>2013</option>
	<option>2012</option>
	<option>2011</option>
	<option>2010</option>
	<option>2009</option>
	<option>2008</option>
	<option>2007</option>
	<option>2006</option>
	<option>2005</option>
	<option>2004</option>
	<option>2003</option>
	<option>2002</option>
	<option>2001</option>
</select>
<input type=""submit"" name=""set"" value=""GO"" disabled>
</form>

</div>


<center>

	<div id=""ad_banner_user"">
		<a href=""http://www.cheapshark.com/incoming?utm_source=something_awful&amp;utm_medium=banner&amp;utm_campaign=blue_banner&amp;t=5"" target=""_blank""><img src=""http://fi.somethingawful.com/safs/goonbas/c/5/5267.0001.png"" alt="""" width=""468"" height=""60""></a><br>
		<a href=""https://secure.somethingawful.com/products/ad-banner.php"" target=""_blank"" title=""Affordable rates, high exposure!"">Advertise here!</a> | <a href=""/adlist.php"" class=""all_ads"">Browse all ads</a>
	</div>
</center>


</div><!-- #content -->
	<ul class=""navigation"">
<li class=""first""><a href=""/index.php"">SA Forums</a></li>
<li>- <a href=""http://www.somethingawful.com/"">Something Awful</a></li>
<li>- <a href=""/f/search"">Search the Forums</a></li>
<li>- <a href=""/usercp.php"">User Control Panel</a></li>
<li>- <a href=""/private.php"">Private Messages</a></li>
<li>- <a href=""http://www.somethingawful.com/d/forum-rules/forum-rules.php"">Forum Rules</a></li>
<li>- <a href=""/dictionary.php"">SAclopedia</a></li>
<li>- <a href=""/stats.php"">Posting Gloryhole</a></li>
<li>- <a href=""/banlist.php"">Leper's Colony</a></li>
<li>- <a href=""/supportmail.php"">Support</a></li>
<li>- <a href=""/account.php?action=logout&amp;ma=10293618"">Log Out</a></li>

</ul>
	<div id=""copyright"">
		Powered by: vBulletin Version 2.2.9 (<a href=""/CHANGES"">SAVB-v2.1.17</a>)<br>
		Copyright &copy;2000, 2001, Jelsoft Enterprises Limited.<br>
		Copyright &copy;2012, Something Awful LLC<br>
	</div>

</div><!-- #container -->

<script type=""text/javascript"">
	// quantcast
	_qoptions = { qacct:""p-82vTvmw-enlng"" };

	try {
		if(document.location.hostname != 'forums.somethingawful.com')
			throw undefined;

		$(document).ready(function() {
			var qcUrl = 'http://edge.quantserve.com/quant.js';
			jQuery.getScript(qcUrl);

			var gaJsHost = ((""https:"" == document.location.protocol) ? ""https://ssl."" : ""http://www."");
			var gaUrl = gaJsHost + 'google-analytics.com/ga.js';
			jQuery.getScript(gaUrl, function() {
				var pageTracker = _gat._getTracker(""UA-3064978-2"");
				pageTracker._initData();
				pageTracker._trackPageview();
			});
		});
	} catch(e) {};

	// indie
	// try {
	// 	if(document.location.hostname != 'forums.somethingawful.com')
	// 		throw undefined;

	// 	$(document).ready(function() {
	// 		var ic_element = document.createElement('script');
	// 		ic_element.type = 'text/javascript';
	// 		ic_element.async = true;
	// 		ic_element.id = 'ic_annonymous_pixel';
	// 		ic_element.src = 'http://pixel.indieclick.com/annonymous/domain/somethingawful.com/reach/script_ic.js';
	// 		var ic_script = document.getElementsByTagName('script')[0];
	// 		ic_script.parentNode.insertBefore(ic_element, ic_script);
	// 	});
	// } catch(e) {};
</script>
<noscript><img src=""http://pixel.quantserve.com/pixel/p-82vTvmw-enlng.gif"" style=""display:none;"" border=""0"" height=""1"" width=""1"" alt=""Quantcast""></noscript>

<!-- PLEASE DO NOT REMOVE -->
<ol id=""debug"" style=""display:none""><li>&nbsp;</ol>
</body>
</html>";
        }
        public virtual string GenerateMockThreadReplyForm()
        {
            return @"<!DOCTYPE html>
<html>
<head>
	<title>The Something Awful Forums - New Reply</title>
	
	<meta name=""MSSmartTagsPreventParsing"" content=""TRUE"">
	<meta http-equiv=""X-UA-Compatible"" content=""chrome=1"">
	<!--[if lt IE 7]><link rel=""stylesheet"" type=""text/css"" href=""/css/ie.css?1348360344""><![endif]-->
	<!--[if lt IE 8]><link rel=""stylesheet"" type=""text/css"" href=""/css/ie7.css?1348360344""><![endif]-->
	<link rel=""apple-touch-icon"" href=""http://i.somethingawful.com/core/icon/iphone-touch/forums.png"">
	<link rel=""stylesheet"" type=""text/css"" href=""/css/main.css?1359594161"">
	<link rel=""stylesheet"" type=""text/css"" href=""/css/bbcode.css?1348360344"">
	<link rel=""stylesheet"" type=""text/css"" href=""http://www.somethingawful.com/globalcss/globalmenu.css"">

	

	<!-- <script src=""/__utm.js"" type=""text/javascript""></script> -->
	<!-- script src=""/js/dojo/dojo.js?1348360344"" type=""text/javascript""></script -->
	<script type=""text/javascript"" src=""//ajax.googleapis.com/ajax/libs/jquery/1.8.3/jquery.min.js""></script>
	<link rel=""stylesheet"" type=""text/css"" href=""//ajax.googleapis.com/ajax/libs/jqueryui/1.9.2/themes/redmond/jquery-ui.css"">
	<script type=""text/javascript"" src=""//ajax.googleapis.com/ajax/libs/jqueryui/1.9.2/jquery-ui.min.js""></script>

	<link rel=""stylesheet"" type=""text/css"" href=""http://www.somethingawful.com/css/forums.css?7"">

	

	<script type=""text/javascript"">
		
		
		
		
	</script>

	<script type=""text/javascript"" src=""/js/vb/forums.combined.js?1359653372""></script>

	

	<!-- ts-specific includes -->
	
	
	

	

	

	
</head>
<body id=""something_awful"" class=""newreply forum_27"">

<div id=""globalmenu"">
	<ul>
		<li class=""first""><a href=""https://secure.somethingawful.com/"">Buy Forum Stuff</a></li>
		<li><a href=""http://www.somethingawful.com/"">Something Awful</a></li>
	</ul>
</div>



<div id=""container"">



	

	<ul id=""nav_purchase"">
		<li><b>Purchase:</b></li>
		<li><a href=""https://secure.somethingawful.com/products/register.php"">Account</a></li>
		<li>- <a href=""https://secure.somethingawful.com/products/platinum.php"">Platinum Upgrade</a></li>
		<li>- <a href=""https://secure.somethingawful.com/products/titlechange.php"">New Avatar</a></li>
		<li>- <a href=""https://secure.somethingawful.com/products/titlechange.php"">Other's Avatar</a></li>
		<li>- <a href=""https://secure.somethingawful.com/products/archives.php"">Archives</a></li>
		<li>- <a href=""https://secure.somethingawful.com/products/noads.php"">No-Ads</a></li>
		<li>- <a href=""https://secure.somethingawful.com/products/namechange.php"">New Username</a></li>
		<li>- <a href=""https://secure.somethingawful.com/products/ad-banner.php"">Banner Advertisement</a></li>
		<li>- <a href=""https://secure.somethingawful.com/products/smilie.php"">Smilie</a></li>
		<li>- <a href=""https://secure.somethingawful.com/products/sticky-thread.php"">Stick Thread</a></li>
		<li>- <a href=""https://secure.somethingawful.com/products/gift-certificate.php"">Gift Cert.</a></li>
	</ul>

	<ul id=""navigation"" class=""navigation"">
<li class=""first""><a href=""/index.php"">SA Forums</a></li>
<li>- <a href=""http://www.somethingawful.com/"">Something Awful</a></li>
<li>- <a href=""/f/search"">Search the Forums</a></li>
<li>- <a href=""/usercp.php"">User Control Panel</a></li>
<li>- <a href=""/private.php"">Private Messages</a></li>
<li>- <a href=""http://www.somethingawful.com/d/forum-rules/forum-rules.php"">Forum Rules</a></li>
<li>- <a href=""/dictionary.php"">SAclopedia</a></li>
<li>- <a href=""/stats.php"">Posting Gloryhole</a></li>
<li>- <a href=""/banlist.php"">Leper's Colony</a></li>
<li>- <a href=""/supportmail.php"">Support</a></li>
<li>- <a href=""/account.php?action=logout&amp;ma=10293618"">Log Out</a></li>

</ul>


<div class=""oma_pal"">
	<!--  Begin Rubicon Project Tag -->
<!--  Site: Something Awful LLC   Zone: Forum ATF Top Quality - Mobile, Pop, Web   Size: Leaderboard  -->
<!--  PLACEMENT: Above the Fold  -->
<script language=""JavaScript"" type=""text/javascript"">
rp_account   = '8539';
rp_site      = '13831';
rp_zonesize  = '80354-2';
rp_adtype    = 'iframe';
rp_width     = '728';
rp_height    = '90';
rp_smartfile = 'http://www.somethingawful.com/revv_smart_file.html';
</script>
<script type=""text/javascript"" src=""https://ads.rubiconproject.com/ad/8539.js""></script>
<!--  End Rubicon Project Tag -->
</div>





	<div id=""content"">

	

<div class=""breadcrumbs""><span class=""mainbodytextlarge""><b><a href=""/"">The Something Awful Forums</a> &gt; <a href=""forumdisplay.php?forumid=152"">The Finer Arts</a> &gt; <a href=""forumdisplay.php?forumid=27"">ADTRW</a> &gt; <a href=""showthread.php?threadid=3570170"">KILL LA KILL</a></b></span></div>



<form enctype=""multipart/form-data"" action=""newreply.php"" name=""vbform"" method=""POST"" onsubmit=""return validate(this)"">
<input type=""hidden"" name=""action"" value=""postreply"">
<input type=""hidden"" name=""threadid"" value=""3570170"">
<input type=""hidden"" name=""formkey"" value=""255fa601c8ac17b5f04959ca7626933f"">
<input type=""hidden"" name=""form_cookie"" value=""805904c84dd0"">

<table class=""standard"" id=""main_full"">

<thead><tr><th colspan=""2"">Post Reply</th></tr></thead>



<tr>
	<td><b>Logged in user:</b></td>
	<td class=""user_loggedin"">bootleg robot <a href=""account.php?action=logout&amp;ma=10293618"">logout</a></td>
</tr>

<tr class=""altcolor2"">
	<td>
		<b>Message:</b><br>
		<br>
		<span class=""smalltext"">
		<b>DON'T USE THESE TAGS:</b><br>
		<img src=""http://forumimages.somethingawful.com/forums/posticons/icon-30-attnmod.gif"" alt=""""><br>
		<img src=""http://forumimages.somethingawful.com/forums/posticons/icon-31-hotthread.gif"" alt=""""><br>
		<img src=""http://forumimages.somethingawful.com/forums/posticons/icon23-banme.gif"" alt=""""><br>
		<a href=""http://www.somethingawful.com/d/forum-rules/forum-rules.php"" target=""_blank"">Read the goddamn forum rules before posting!!!</a>  If you break a forum rule, you WILL be banned.  Ignorance is NO excuse.
		<br>
		<br>
		
		You <b>may </b> post new threads<br>
		You <b>may </b> post replies<br>
		You <b>may </b> post attachments<br>
		You <b>may </b> edit your posts<br>
		HTML code is <b>off</b><br>
		<a href=""misc.php?action=bbcode"" target=""_blank"">BBcode</a> is <b>on</b><br>
		<a href=""misc.php?action=showsmilies"" target=""_blank"">Smilies</a> are <b>on</b><br>
		<a href=""misc.php?action=bbcode#imgcode"" target=""_blank"">[IMG]</a> code is <b>on</b>
		</span>
	</td>
	<td>
		<textarea name=""message"" rows=""20"" cols=""83"" tabindex=""2""></textarea><br>
		<a class=""check_msg_length"" href=""javascript:checklength(document.vbform, 50000);"">check message length</a>
		<a class=""show_smilies"" href=""/misc.php?action=showsmilies"" target=""_blank"">Smilies</a>
		<a class=""show_bbcode"" href=""/misc.php?action=bbcode"" target=""_blank"">BBcode</a>
	</td>
</tr>

<tr>
	<td><b>Options:</b></td>
	<td class=""smalltext"">
		<input type=""checkbox"" name=""parseurl"" value=""yes"" checked> <b>Automatically parse URLs:</b> automatically adds [url] and [/url] around internet addresses.<br>
		<input type=""checkbox"" name=""bookmark"" value=""yes"" checked> <b>Bookmark thread:</b> adds thread to your <a href='/bookmarkthreads.php?action=view'>thread bookmarks</a>.<br>
		<input type=""checkbox"" name=""disablesmilies"" value=""yes"" > <b>Disable Smilies in This Post</b><br>
		<input type=""checkbox"" name=""signature"" value=""yes""> <b>Show Signature:</b> include your profile signature.
</td>
</tr>

<tr class=""altcolor2"">
	<td valign=""top"">
		<b>Attach file:</b><br>
		<span class=""smalltext"">Maximum size: 1048576 bytes</span>
	</td>
	<td valign=""top"" class=""smalltext"">
		<input type=""hidden"" name=""MAX_FILE_SIZE"" value=""2097152"">
		<input type=""file"" class=""bginput"" name=""attachment""><br>
		Valid file extensions: gif jpg jpeg png
	</td>
</tr>

</table>

<br>

<div class=""postbuttons"">
	<input type=""submit"" class=""bginput"" name=""submit"" value=""Submit Reply"" tabindex=""3"" accesskey=""s"">
	<input type=""submit"" class=""bginput"" name=""preview"" value=""Preview Reply"" tabindex=""4"" accesskey=""p"">
</div>

<br>

<div id=""thread"">
<table class=""post "" id=""post427268694"" data-idx=""8862"">
<tr  class=""seen2"" id=""pti1"">
	<td class=""userinfo userid-138271"">
		<dl class=""userinfo"">
			<dt class=""author"" title="""">icantfindaname</dt>
			<dd class=""registered"">Jul  1, 2008</dd>
			<dd class=""title"">
				<div class=""bbc-center""><img src=""http://fi.somethingawful.com/customtitles/title-icantfindaname.jpg"" alt="""" class=""img"" border=""0""><br />
</div><br>
				<br class=""pb"">
			</dd>
		</dl>
	</td>
	<td class=""postbody"">
		<!-- BeginContentMarker -->
		<!-- google_ad_section_start -->
		<div class=""bbc-block""><h4><a class=""quote_link"" href=""/showthread.php?goto=post&postid=427265947#post427265947"" rel=""nofollow"">Pimpmust posted:</a></h4><blockquote>
Goddamnit Japan, stop trying to kill God. <br />
<br />
You'd think God molested you since birth or something.<br />
</blockquote></div>

<br />
this is Japan we're talking about here, don't discount the possibility.
		<!-- google_ad_section_end -->
		<!-- EndContentMarker -->


		<p class=""editedby"">
	</td>
</tr>
<tr class=""seen2"">
	<td class=""postdate"">
		<a class=""lastseen_icon"" href=""/showthread.php?action=setseen&amp;threadid=3570170&amp;index=8862"" title=""Mark all replies as read to this point""><img src=""http://fi.somethingawful.com/style/posticon-seen.gif"" alt="""" border=""0""></a>
		<a href=""#post427268694"" title=""Link to this post"">#</a>
		<a class=""user_jump"" title=""Show posts by this user"" href=""/showthread.php?threadid=3570170&amp;userid=138271"">?</a>
		Mar 21, 2014 15:46
	</td>
	<td class=""postlinks"">
		<ul class=""profilelinks"">
			<li><a href=""member.php?action=getinfo&amp;userid=138271"">Profile</a></li>
			<li><a href=""private.php?action=newmessage&amp;userid=138271"">Message</a></li>
			<li><a href=""search.php?action=do_search_posthistory&amp;userid=138271"">Post History</a></li>
		</ul>
		<ul class=""postbuttons"">

			
			<li class=""alertbutton""><a href=""modalert.php?postid=427268694&amp;username=icantfindaname""><img src=""http://forumimages.somethingawful.com/images/button-report.gif"" border=""0"" alt=""Alert Moderators""></a>&nbsp;&nbsp;</li>
			
			<li><a href=""newreply.php?action=newreply&amp;postid=427268694""><img src=""http://fi.somethingawful.com/images/sa-quote.gif"" alt=""Quote""  title=""""></a></li>


		</ul>
	</td>
</tr>
</table><table class=""post "" id=""post427266007"" data-idx=""8861"">
<tr  class=""seen1"" id=""pti2"">
	<td class=""userinfo userid-90457"">
		<dl class=""userinfo"">
			<dt class=""author"" title="""">Squallege</dt>
			<dd class=""registered"">Jan  7, 2006</dd>
			<dd class=""title"">
				<div class=""bbc-center""><img src=""http://fi.somethingawful.com/safs/titles/e6/15/00090457.0001.png"" alt="""" class=""img"" border=""0""><br />
No greater good, no just cause<br />
<br />
<img src=""http://fi.somethingawful.com/safs/titles/a9/71/00145955.0001.gif"" alt="""" class=""img"" border=""0""></div><br>
				<br class=""pb"">
			</dd>
		</dl>
	</td>
	<td class=""postbody"">
		<!-- BeginContentMarker -->
		<!-- google_ad_section_start -->
		<div class=""bbc-block""><h4><a class=""quote_link"" href=""/showthread.php?goto=post&postid=427265738#post427265738"" rel=""nofollow"">Lurking Haro posted:</a></h4><blockquote>
The OVA doesn't have to take place after the ending. It can be a sidestory taking place between events or even something completely else like Gurren Lagann Parallel Works.<br />
</blockquote></div>

<br />
I'd love a Kill la Kill Parallel Works.
		<!-- google_ad_section_end -->
		<!-- EndContentMarker -->


		<p class=""editedby"">
	</td>
</tr>
<tr class=""seen1"">
	<td class=""postdate"">
		<a class=""lastseen_icon"" href=""/showthread.php?action=setseen&amp;threadid=3570170&amp;index=8861"" title=""Mark all replies as read to this point""><img src=""http://fi.somethingawful.com/style/posticon-seen.gif"" alt="""" border=""0""></a>
		<a href=""#post427266007"" title=""Link to this post"">#</a>
		<a class=""user_jump"" title=""Show posts by this user"" href=""/showthread.php?threadid=3570170&amp;userid=90457"">?</a>
		Mar 21, 2014 14:39
	</td>
	<td class=""postlinks"">
		<ul class=""profilelinks"">
			<li><a href=""member.php?action=getinfo&amp;userid=90457"">Profile</a></li>
			<li><a href=""private.php?action=newmessage&amp;userid=90457"">Message</a></li>
			<li><a href=""search.php?action=do_search_posthistory&amp;userid=90457"">Post History</a></li>
		</ul>
		<ul class=""postbuttons"">

			
			<li class=""alertbutton""><a href=""modalert.php?postid=427266007&amp;username=Squallege""><img src=""http://forumimages.somethingawful.com/images/button-report.gif"" border=""0"" alt=""Alert Moderators""></a>&nbsp;&nbsp;</li>
			
			<li><a href=""newreply.php?action=newreply&amp;postid=427266007""><img src=""http://fi.somethingawful.com/images/sa-quote.gif"" alt=""Quote""  title=""""></a></li>


		</ul>
	</td>
</tr>
</table><table class=""post "" id=""post427265947"" data-idx=""8860"">
<tr  class=""seen2"" id=""pti3"">
	<td class=""userinfo userid-141655"">
		<dl class=""userinfo"">
			<dt class=""author"" title="""">Pimpmust</dt>
			<dd class=""registered"">Oct  1, 2008</dd>
			<dd class=""title"">
				<img src=""http://fi.somethingawful.com/customtitles/title-pimpmust.gif"" alt="""" class=""img"" border=""0""><br /><br>
				<br class=""pb"">
			</dd>
		</dl>
	</td>
	<td class=""postbody"">
		<!-- BeginContentMarker -->
		<!-- google_ad_section_start -->
		<div class=""bbc-block""><h4><a class=""quote_link"" href=""/showthread.php?goto=post&postid=427242821#post427242821"" rel=""nofollow"">Lamebot posted:</a></h4><blockquote>
ragyou was amaterasu all along. makes sense considering her constant radiance.<br />
</blockquote></div>

<br />
Goddamnit Japan, stop trying to kill God. <br />
<br />
You'd think God molested you since birth or something.
		<!-- google_ad_section_end -->
		<!-- EndContentMarker -->


		<p class=""editedby"">
	</td>
</tr>
<tr class=""seen2"">
	<td class=""postdate"">
		<a class=""lastseen_icon"" href=""/showthread.php?action=setseen&amp;threadid=3570170&amp;index=8860"" title=""Mark all replies as read to this point""><img src=""http://fi.somethingawful.com/style/posticon-seen.gif"" alt="""" border=""0""></a>
		<a href=""#post427265947"" title=""Link to this post"">#</a>
		<a class=""user_jump"" title=""Show posts by this user"" href=""/showthread.php?threadid=3570170&amp;userid=141655"">?</a>
		Mar 21, 2014 14:38
	</td>
	<td class=""postlinks"">
		<ul class=""profilelinks"">
			<li><a href=""member.php?action=getinfo&amp;userid=141655"">Profile</a></li>
			<li><a href=""private.php?action=newmessage&amp;userid=141655"">Message</a></li>
			<li><a href=""search.php?action=do_search_posthistory&amp;userid=141655"">Post History</a></li>
		</ul>
		<ul class=""postbuttons"">

			
			<li class=""alertbutton""><a href=""modalert.php?postid=427265947&amp;username=Pimpmust""><img src=""http://forumimages.somethingawful.com/images/button-report.gif"" border=""0"" alt=""Alert Moderators""></a>&nbsp;&nbsp;</li>
			
			<li><a href=""newreply.php?action=newreply&amp;postid=427265947""><img src=""http://fi.somethingawful.com/images/sa-quote.gif"" alt=""Quote""  title=""""></a></li>


		</ul>
	</td>
</tr>
</table><table class=""post "" id=""post427265847"" data-idx=""8859"">
<tr  class=""seen1"" id=""pti4"">
	<td class=""userinfo userid-171403"">
		<dl class=""userinfo"">
			<dt class=""author"" title="""">Level Slide</dt>
			<dd class=""registered"">Jan  3, 2011</dd>
			<dd class=""title"">
				<img src=""http://fi.somethingawful.com/safs/titles/1f/8b/00171403.0001.png"" alt="""" class=""img"" border=""0""><br />
It'll work out somehow.<br>
				<br class=""pb"">
			</dd>
		</dl>
	</td>
	<td class=""postbody"">
		<!-- BeginContentMarker -->
		<!-- google_ad_section_start -->
		It should be the tea sequences on the Naked Sun except actually fucking animated.
		<!-- google_ad_section_end -->
		<!-- EndContentMarker -->


		<p class=""editedby"">
	</td>
</tr>
<tr class=""seen1"">
	<td class=""postdate"">
		<a class=""lastseen_icon"" href=""/showthread.php?action=setseen&amp;threadid=3570170&amp;index=8859"" title=""Mark all replies as read to this point""><img src=""http://fi.somethingawful.com/style/posticon-seen.gif"" alt="""" border=""0""></a>
		<a href=""#post427265847"" title=""Link to this post"">#</a>
		<a class=""user_jump"" title=""Show posts by this user"" href=""/showthread.php?threadid=3570170&amp;userid=171403"">?</a>
		Mar 21, 2014 14:35
	</td>
	<td class=""postlinks"">
		<ul class=""profilelinks"">
			<li><a href=""member.php?action=getinfo&amp;userid=171403"">Profile</a></li>
			<li><a href=""private.php?action=newmessage&amp;userid=171403"">Message</a></li>
			<li><a href=""search.php?action=do_search_posthistory&amp;userid=171403"">Post History</a></li>
		</ul>
		<ul class=""postbuttons"">

			
			<li class=""alertbutton""><a href=""modalert.php?postid=427265847&amp;username=Level+Slide""><img src=""http://forumimages.somethingawful.com/images/button-report.gif"" border=""0"" alt=""Alert Moderators""></a>&nbsp;&nbsp;</li>
			
			<li><a href=""newreply.php?action=newreply&amp;postid=427265847""><img src=""http://fi.somethingawful.com/images/sa-quote.gif"" alt=""Quote""  title=""""></a></li>


		</ul>
	</td>
</tr>
</table><table class=""post "" id=""post427265738"" data-idx=""8858"">
<tr  class=""seen2"" id=""pti5"">
	<td class=""userinfo userid-156835"">
		<dl class=""userinfo"">
			<dt class=""author"" title="""">Lurking Haro</dt>
			<dd class=""registered"">Oct 27, 2009</dd>
			<dd class=""title"">
				<img src=""http://fi.somethingawful.com/customtitles/title-lurking_haro.gif"" alt="""" class=""img"" border=""0""><br /><br>
				<br class=""pb"">
			</dd>
		</dl>
	</td>
	<td class=""postbody"">
		<!-- BeginContentMarker -->
		<!-- google_ad_section_start -->
		<div class=""bbc-block""><h4><a class=""quote_link"" href=""/showthread.php?goto=post&postid=427264706#post427264706"" rel=""nofollow"">Zogundar posted:</a></h4><blockquote>
If there's an OVA episode due after the series finishes I don't see how there can be a downer ending without the entire followup being essentially unenjoyable no matter what craziness they pull.<br />
<br />
Hopefully the only person turning to dust/fading away will be Mako being Mako, as a joke, to make a tongue in cheek jab at the idea. ""Ha ha, you thought we would do something like that, but we aren't.""<br />
</blockquote></div>

<br />
The OVA doesn't have to take place after the ending. It can be a sidestory taking place between events or even something completely else like Gurren Lagann Parallel Works.
		<!-- google_ad_section_end -->
		<!-- EndContentMarker -->


		<p class=""editedby"">
	</td>
</tr>
<tr class=""seen2"">
	<td class=""postdate"">
		<a class=""lastseen_icon"" href=""/showthread.php?action=setseen&amp;threadid=3570170&amp;index=8858"" title=""Mark all replies as read to this point""><img src=""http://fi.somethingawful.com/style/posticon-seen.gif"" alt="""" border=""0""></a>
		<a href=""#post427265738"" title=""Link to this post"">#</a>
		<a class=""user_jump"" title=""Show posts by this user"" href=""/showthread.php?threadid=3570170&amp;userid=156835"">?</a>
		Mar 21, 2014 14:33
	</td>
	<td class=""postlinks"">
		<ul class=""profilelinks"">
			<li><a href=""member.php?action=getinfo&amp;userid=156835"">Profile</a></li>
			<li><a href=""private.php?action=newmessage&amp;userid=156835"">Message</a></li>
			<li><a href=""search.php?action=do_search_posthistory&amp;userid=156835"">Post History</a></li>
		</ul>
		<ul class=""postbuttons"">

			
			<li class=""alertbutton""><a href=""modalert.php?postid=427265738&amp;username=Lurking+Haro""><img src=""http://forumimages.somethingawful.com/images/button-report.gif"" border=""0"" alt=""Alert Moderators""></a>&nbsp;&nbsp;</li>
			
			<li><a href=""newreply.php?action=newreply&amp;postid=427265738""><img src=""http://fi.somethingawful.com/images/sa-quote.gif"" alt=""Quote""  title=""""></a></li>


		</ul>
	</td>
</tr>
</table><table class=""post "" id=""post427265407"" data-idx=""8857"">
<tr  class=""seen1"" id=""pti6"">
	<td class=""userinfo userid-190929"">
		<dl class=""userinfo"">
			<dt class=""author"" title="""">Dick Spacious CPA</dt>
			<dd class=""registered"">Oct 10, 2012</dd>
			<dd class=""title"">
				<div class=""bbc-center""><img src=""http://fi.somethingawful.com/safs/titles/bb/0d/00190929.0001.jpg"" alt="""" class=""img"" border=""0""><br />
</div><br>
				<br class=""pb"">
			</dd>
		</dl>
	</td>
	<td class=""postbody"">
		<!-- BeginContentMarker -->
		<!-- google_ad_section_start -->
		<div class=""bbc-block""><h4><a class=""quote_link"" href=""/showthread.php?goto=post&postid=427265216#post427265216"" rel=""nofollow"">Pimpmust posted:</a></h4><blockquote>
<br />
<br />
That and the scene with Ragyo <span class=""bbc-spoiler"">fucking fondling herself while looking high as a kite</span>, goddamn she must be doing all the cocaine. <i>All of it</i>. <br />
<br />
<br />
</blockquote></div>

<br />
haha someone should make a picture of ragyo as the main character of the scarface movie! that would be funny
		<!-- google_ad_section_end -->
		<!-- EndContentMarker -->


		<p class=""editedby"">
	</td>
</tr>
<tr class=""seen1"">
	<td class=""postdate"">
		<a class=""lastseen_icon"" href=""/showthread.php?action=setseen&amp;threadid=3570170&amp;index=8857"" title=""Mark all replies as read to this point""><img src=""http://fi.somethingawful.com/style/posticon-seen.gif"" alt="""" border=""0""></a>
		<a href=""#post427265407"" title=""Link to this post"">#</a>
		<a class=""user_jump"" title=""Show posts by this user"" href=""/showthread.php?threadid=3570170&amp;userid=190929"">?</a>
		Mar 21, 2014 14:25
	</td>
	<td class=""postlinks"">
		<ul class=""profilelinks"">
			<li><a href=""member.php?action=getinfo&amp;userid=190929"">Profile</a></li>
			<li><a href=""private.php?action=newmessage&amp;userid=190929"">Message</a></li>
			<li><a href=""search.php?action=do_search_posthistory&amp;userid=190929"">Post History</a></li>
		</ul>
		<ul class=""postbuttons"">

			
			<li class=""alertbutton""><a href=""modalert.php?postid=427265407&amp;username=Dick+Spacious+CPA""><img src=""http://forumimages.somethingawful.com/images/button-report.gif"" border=""0"" alt=""Alert Moderators""></a>&nbsp;&nbsp;</li>
			
			<li><a href=""newreply.php?action=newreply&amp;postid=427265407""><img src=""http://fi.somethingawful.com/images/sa-quote.gif"" alt=""Quote""  title=""""></a></li>


		</ul>
	</td>
</tr>
</table><table class=""post "" id=""post427265216"" data-idx=""8856"">
<tr  class=""seen2"" id=""pti7"">
	<td class=""userinfo userid-141655"">
		<dl class=""userinfo"">
			<dt class=""author"" title="""">Pimpmust</dt>
			<dd class=""registered"">Oct  1, 2008</dd>
			<dd class=""title"">
				<img src=""http://fi.somethingawful.com/customtitles/title-pimpmust.gif"" alt="""" class=""img"" border=""0""><br /><br>
				<br class=""pb"">
			</dd>
		</dl>
	</td>
	<td class=""postbody"">
		<!-- BeginContentMarker -->
		<!-- google_ad_section_start -->
		Possibly the best <img src=""http://i.somethingawful.com/forumsystem/emoticons/emot-getout.png"" border=""0"" alt="""" title="":getout:""> of the episode<br />
<span class=""bbc-spoiler""><img src=""http://i.imgur.com/mzuYvKZ.png"" alt="""" class=""img"" border=""0""></span><br />
<br />
<img src=""http://i.somethingawful.com/forumsystem/emoticons/emot-haw.gif"" border=""0"" alt="""" title="":haw:""><br />
<br />
That and the scene with Ragyo <span class=""bbc-spoiler"">fucking fondling herself while looking high as a kite</span>, goddamn she must be doing all the cocaine. <i>All of it</i>. <br />
<br />
As for the battle itself it started out pretty well but the <span class=""bbc-spoiler"">Good Guy Avalance</span> was sorta boring, hoping next fight will be better.
		<!-- google_ad_section_end -->
		<!-- EndContentMarker -->


		<p class=""editedby"">
	</td>
</tr>
<tr class=""seen2"">
	<td class=""postdate"">
		<a class=""lastseen_icon"" href=""/showthread.php?action=setseen&amp;threadid=3570170&amp;index=8856"" title=""Mark all replies as read to this point""><img src=""http://fi.somethingawful.com/style/posticon-seen.gif"" alt="""" border=""0""></a>
		<a href=""#post427265216"" title=""Link to this post"">#</a>
		<a class=""user_jump"" title=""Show posts by this user"" href=""/showthread.php?threadid=3570170&amp;userid=141655"">?</a>
		Mar 21, 2014 14:21
	</td>
	<td class=""postlinks"">
		<ul class=""profilelinks"">
			<li><a href=""member.php?action=getinfo&amp;userid=141655"">Profile</a></li>
			<li><a href=""private.php?action=newmessage&amp;userid=141655"">Message</a></li>
			<li><a href=""search.php?action=do_search_posthistory&amp;userid=141655"">Post History</a></li>
		</ul>
		<ul class=""postbuttons"">

			
			<li class=""alertbutton""><a href=""modalert.php?postid=427265216&amp;username=Pimpmust""><img src=""http://forumimages.somethingawful.com/images/button-report.gif"" border=""0"" alt=""Alert Moderators""></a>&nbsp;&nbsp;</li>
			
			<li><a href=""newreply.php?action=newreply&amp;postid=427265216""><img src=""http://fi.somethingawful.com/images/sa-quote.gif"" alt=""Quote""  title=""""></a></li>


		</ul>
	</td>
</tr>
</table><table class=""post "" id=""post427264706"" data-idx=""8855"">
<tr  class=""seen1"" id=""pti8"">
	<td class=""userinfo userid-128596"">
		<dl class=""userinfo"">
			<dt class=""author"" title="""">Zogundar</dt>
			<dd class=""registered"">Dec  5, 2007</dd>
			<dd class=""title"">
				<img src='http://fi.somethingawful.com/images/newbie.gif' border=0><br>
				<br class=""pb"">
			</dd>
		</dl>
	</td>
	<td class=""postbody"">
		<!-- BeginContentMarker -->
		<!-- google_ad_section_start -->
		If there's an OVA episode due after the series finishes I don't see how there can be a downer ending without the entire followup being essentially unenjoyable no matter what craziness they pull.<br />
<br />
Hopefully the only person turning to dust/fading away will be Mako being Mako, as a joke, to make a tongue in cheek jab at the idea. ""Ha ha, you thought we would do something like that, but we aren't.""<br />
<br />
On the topic of the latest episode:<br />
<br />
<span class=""bbc-spoiler"">So I managed to be completely wrong about another thing, turns out Kouketsu wasn't even a made up word, I could have literally gotten that by typing it out if I had just tried, but nooo, let's wild guess based on possible pronunciations instead! <img src=""http://i.somethingawful.com/forumsystem/emoticons/emot-downs.gif"" border=""0"" alt="""" title="":downs:""> (In my defense I think it was originally believed to be spelled ""Koketsu"" which would not have worked.)<br />
<br />
A dictionary defines it as ""style of tie-dying used during the Nara era."" I know nothing of the Nara era or what significance that could have, does anyone else? Might be interesting!</span>
		<!-- google_ad_section_end -->
		<!-- EndContentMarker -->


		<p class=""editedby"">
	</td>
</tr>
<tr class=""seen1"">
	<td class=""postdate"">
		<a class=""lastseen_icon"" href=""/showthread.php?action=setseen&amp;threadid=3570170&amp;index=8855"" title=""Mark all replies as read to this point""><img src=""http://fi.somethingawful.com/style/posticon-seen.gif"" alt="""" border=""0""></a>
		<a href=""#post427264706"" title=""Link to this post"">#</a>
		<a class=""user_jump"" title=""Show posts by this user"" href=""/showthread.php?threadid=3570170&amp;userid=128596"">?</a>
		Mar 21, 2014 14:09
	</td>
	<td class=""postlinks"">
		<ul class=""profilelinks"">
			<li><a href=""member.php?action=getinfo&amp;userid=128596"">Profile</a></li>
			<li><a href=""search.php?action=do_search_posthistory&amp;userid=128596"">Post History</a></li>
		</ul>
		<ul class=""postbuttons"">

			
			<li class=""alertbutton""><a href=""modalert.php?postid=427264706&amp;username=Zogundar""><img src=""http://forumimages.somethingawful.com/images/button-report.gif"" border=""0"" alt=""Alert Moderators""></a>&nbsp;&nbsp;</li>
			
			<li><a href=""newreply.php?action=newreply&amp;postid=427264706""><img src=""http://fi.somethingawful.com/images/sa-quote.gif"" alt=""Quote""  title=""""></a></li>


		</ul>
	</td>
</tr>
</table><table class=""post "" id=""post427263849"" data-idx=""8854"">
<tr  class=""seen2"" id=""pti9"">
	<td class=""userinfo userid-171403"">
		<dl class=""userinfo"">
			<dt class=""author"" title="""">Level Slide</dt>
			<dd class=""registered"">Jan  3, 2011</dd>
			<dd class=""title"">
				<img src=""http://fi.somethingawful.com/safs/titles/1f/8b/00171403.0001.png"" alt="""" class=""img"" border=""0""><br />
It'll work out somehow.<br>
				<br class=""pb"">
			</dd>
		</dl>
	</td>
	<td class=""postbody"">
		<!-- BeginContentMarker -->
		<!-- google_ad_section_start -->
		<div class=""bbc-block""><h4><a class=""quote_link"" href=""/showthread.php?goto=post&postid=427260010#post427260010"" rel=""nofollow"">drunk asian neighbor posted:</a></h4><blockquote>
I just looked up the fact that Ragyo's VA also does the voices of Edward in both Fullmetal Alchemist shows and Temari in Naruto and <img src=""http://i.somethingawful.com/forumsystem/emoticons/emot-psyduck.gif"" border=""0"" alt="""" title="":psyduck:""><br />
<br />
Now that I know it I can totally hear Edward in there, especially when she gets all worked up.<br />
</blockquote></div>

<br />
Also the voice of Loran Cehack, the main character from Turn A Gundam.<br />
<br />
Speaking of, Ragyo hasn't done shit with Shinra Kotetsu yet, but I get the feeling she could totally take the Turn A even if it's working at full capacity.
		<!-- google_ad_section_end -->
		<!-- EndContentMarker -->


		<p class=""editedby"">
	</td>
</tr>
<tr class=""seen2"">
	<td class=""postdate"">
		<a class=""lastseen_icon"" href=""/showthread.php?action=setseen&amp;threadid=3570170&amp;index=8854"" title=""Mark all replies as read to this point""><img src=""http://fi.somethingawful.com/style/posticon-seen.gif"" alt="""" border=""0""></a>
		<a href=""#post427263849"" title=""Link to this post"">#</a>
		<a class=""user_jump"" title=""Show posts by this user"" href=""/showthread.php?threadid=3570170&amp;userid=171403"">?</a>
		Mar 21, 2014 13:50
	</td>
	<td class=""postlinks"">
		<ul class=""profilelinks"">
			<li><a href=""member.php?action=getinfo&amp;userid=171403"">Profile</a></li>
			<li><a href=""private.php?action=newmessage&amp;userid=171403"">Message</a></li>
			<li><a href=""search.php?action=do_search_posthistory&amp;userid=171403"">Post History</a></li>
		</ul>
		<ul class=""postbuttons"">

			
			<li class=""alertbutton""><a href=""modalert.php?postid=427263849&amp;username=Level+Slide""><img src=""http://forumimages.somethingawful.com/images/button-report.gif"" border=""0"" alt=""Alert Moderators""></a>&nbsp;&nbsp;</li>
			
			<li><a href=""newreply.php?action=newreply&amp;postid=427263849""><img src=""http://fi.somethingawful.com/images/sa-quote.gif"" alt=""Quote""  title=""""></a></li>


		</ul>
	</td>
</tr>
</table><table class=""post "" id=""post427261701"" data-idx=""8853"">
<tr  class=""seen1"" id=""pti10"">
	<td class=""userinfo userid-56101"">
		<dl class=""userinfo"">
			<dt class=""author"" title="""">hoobajoo</dt>
			<dd class=""registered"">Jun  1, 2004</dd>
			<dd class=""title"">
				<img src=""http://fi.somethingawful.com/safs/titles/d8/74/00056101.0001.jpg"" alt="""" class=""img"" border=""0""><br /><br>
				<br class=""pb"">
			</dd>
		</dl>
	</td>
	<td class=""postbody"">
		<!-- BeginContentMarker -->
		<!-- google_ad_section_start -->
		<div class=""bbc-block""><h4><a class=""quote_link"" href=""/showthread.php?goto=post&postid=427260437#post427260437"" rel=""nofollow"">DrSunshine posted:</a></h4><blockquote>
I <a href=""http://forums.somethingawful.com/showthread.php?threadid=3615945"" target=""_blank"" rel=""nofollow"">made a thread</a> about this very thing!<br />

<br />

<br />
Why is it that, even as a person who doesn't speak Japanese at all, <i>all</i> of this dialogue sounds unmistakably like anime dialogue? Well <i>yes</i> because it <b>is</b> anime dialogue, of course, but for some reason anime dialogue always sounds completely different from the way real Japanese people talk.<br />
</blockquote></div>

<br />
One, because it's a voice and they'll generally exaggerate it to make it memorable like any cartoon.  And two, you might be picking up on the endings of sentences sounding different because anime characters are largely rude as shit and talking in an anime way means they're conjugating verbs differently a lot of the time.
		<!-- google_ad_section_end -->
		<!-- EndContentMarker -->


		<p class=""editedby"">
	</td>
</tr>
<tr class=""seen1"">
	<td class=""postdate"">
		<a class=""lastseen_icon"" href=""/showthread.php?action=setseen&amp;threadid=3570170&amp;index=8853"" title=""Mark all replies as read to this point""><img src=""http://fi.somethingawful.com/style/posticon-seen.gif"" alt="""" border=""0""></a>
		<a href=""#post427261701"" title=""Link to this post"">#</a>
		<a class=""user_jump"" title=""Show posts by this user"" href=""/showthread.php?threadid=3570170&amp;userid=56101"">?</a>
		Mar 21, 2014 12:55
	</td>
	<td class=""postlinks"">
		<ul class=""profilelinks"">
			<li><a href=""member.php?action=getinfo&amp;userid=56101"">Profile</a></li>
			<li><a href=""search.php?action=do_search_posthistory&amp;userid=56101"">Post History</a></li>
		</ul>
		<ul class=""postbuttons"">

			
			<li class=""alertbutton""><a href=""modalert.php?postid=427261701&amp;username=hoobajoo""><img src=""http://forumimages.somethingawful.com/images/button-report.gif"" border=""0"" alt=""Alert Moderators""></a>&nbsp;&nbsp;</li>
			
			<li><a href=""newreply.php?action=newreply&amp;postid=427261701""><img src=""http://fi.somethingawful.com/images/sa-quote.gif"" alt=""Quote""  title=""""></a></li>


		</ul>
	</td>
</tr>
</table><table class=""post "" id=""post427261263"" data-idx=""8852"">
<tr  class=""seen2"" id=""pti11"">
	<td class=""userinfo userid-108494"">
		<dl class=""userinfo"">
			<dt class=""author"" title="""">Slime</dt>
			<dd class=""registered"">Jan  3, 2007</dd>
			<dd class=""title"">
				<div class=""bbc-center""></div><br>
				<br class=""pb"">
			</dd>
		</dl>
	</td>
	<td class=""postbody"">
		<!-- BeginContentMarker -->
		<!-- google_ad_section_start -->
		<div class=""bbc-block""><h4><a class=""quote_link"" href=""/showthread.php?goto=post&postid=427260437#post427260437"" rel=""nofollow"">DrSunshine posted:</a></h4><blockquote>
I <a href=""http://forums.somethingawful.com/showthread.php?threadid=3615945"" target=""_blank"" rel=""nofollow"">made a thread</a> about this very thing!<br />
<br />
<br />
Why is it that, even as a person who doesn't speak Japanese at all, <i>all</i> of this dialogue sounds unmistakably like anime dialogue? Well <i>yes</i> because it <b>is</b> anime dialogue, of course, but for some reason anime dialogue always sounds completely different from the way real Japanese people talk.<br />
</blockquote></div>

<br />
Listen to a western cartoon (possibly in a foreign language) and you'll find the same thing applies there too.
		<!-- google_ad_section_end -->
		<!-- EndContentMarker -->


		<p class=""editedby"">
	</td>
</tr>
<tr class=""seen2"">
	<td class=""postdate"">
		<a class=""lastseen_icon"" href=""/showthread.php?action=setseen&amp;threadid=3570170&amp;index=8852"" title=""Mark all replies as read to this point""><img src=""http://fi.somethingawful.com/style/posticon-seen.gif"" alt="""" border=""0""></a>
		<a href=""#post427261263"" title=""Link to this post"">#</a>
		<a class=""user_jump"" title=""Show posts by this user"" href=""/showthread.php?threadid=3570170&amp;userid=108494"">?</a>
		Mar 21, 2014 12:45
	</td>
	<td class=""postlinks"">
		<ul class=""profilelinks"">
			<li><a href=""member.php?action=getinfo&amp;userid=108494"">Profile</a></li>
			<li><a href=""search.php?action=do_search_posthistory&amp;userid=108494"">Post History</a></li>
		</ul>
		<ul class=""postbuttons"">

			
			<li class=""alertbutton""><a href=""modalert.php?postid=427261263&amp;username=Slime""><img src=""http://forumimages.somethingawful.com/images/button-report.gif"" border=""0"" alt=""Alert Moderators""></a>&nbsp;&nbsp;</li>
			
			<li><a href=""newreply.php?action=newreply&amp;postid=427261263""><img src=""http://fi.somethingawful.com/images/sa-quote.gif"" alt=""Quote""  title=""""></a></li>


		</ul>
	</td>
</tr>
</table><table class=""post "" id=""post427260723"" data-idx=""8851"">
<tr  class=""seen1"" id=""pti12"">
	<td class=""userinfo userid-182274"">
		<dl class=""userinfo"">
			<dt class=""author"" title="""">KaneTW</dt>
			<dd class=""registered"">Dec  2, 2011</dd>
			<dd class=""title"">
				<div class=""bbc-center""><img src=""http://fi.somethingawful.com/safs/titles/f3/6f/00182274.0002.gif"" alt="""" class=""img"" border=""0""><br />
Jones killed Solaire! How could she.<br />
<br />
<img src=""http://fi.somethingawful.com/safs/titles/f3/6f/00182274.0001.gif"" alt="""" class=""img"" border=""0""></div><br>
				<br class=""pb"">
			</dd>
		</dl>
	</td>
	<td class=""postbody"">
		<!-- BeginContentMarker -->
		<!-- google_ad_section_start -->
		The way Ragyo went <span class=""bbc-spoiler"">Shinrrrrrrrrrrrrrrra Kouketsu</span> is absolutely fantastic. Can't stop rewatching that scene.<br />
<br />
E: <span class=""bbc-spoiler"">Shinra Kouketsu'd Ragyo is huge.</span>
		<!-- google_ad_section_end -->
		<!-- EndContentMarker -->


		<p class=""editedby""><span>KaneTW fucked around with this message at Mar 21, 2014 around 12:35</span>
	</td>
</tr>
<tr class=""seen1"">
	<td class=""postdate"">
		<a class=""lastseen_icon"" href=""/showthread.php?action=setseen&amp;threadid=3570170&amp;index=8851"" title=""Mark all replies as read to this point""><img src=""http://fi.somethingawful.com/style/posticon-seen.gif"" alt="""" border=""0""></a>
		<a href=""#post427260723"" title=""Link to this post"">#</a>
		<a class=""user_jump"" title=""Show posts by this user"" href=""/showthread.php?threadid=3570170&amp;userid=182274"">?</a>
		Mar 21, 2014 12:32
	</td>
	<td class=""postlinks"">
		<ul class=""profilelinks"">
			<li><a href=""member.php?action=getinfo&amp;userid=182274"">Profile</a></li>
			<li><a href=""private.php?action=newmessage&amp;userid=182274"">Message</a></li>
			<li><a href=""search.php?action=do_search_posthistory&amp;userid=182274"">Post History</a></li>
		</ul>
		<ul class=""postbuttons"">

			
			<li class=""alertbutton""><a href=""modalert.php?postid=427260723&amp;username=KaneTW""><img src=""http://forumimages.somethingawful.com/images/button-report.gif"" border=""0"" alt=""Alert Moderators""></a>&nbsp;&nbsp;</li>
			
			<li><a href=""newreply.php?action=newreply&amp;postid=427260723""><img src=""http://fi.somethingawful.com/images/sa-quote.gif"" alt=""Quote""  title=""""></a></li>


		</ul>
	</td>
</tr>
</table><table class=""post "" id=""post427260437"" data-idx=""8850"">
<tr  class=""seen2"" id=""pti13"">
	<td class=""userinfo userid-149105"">
		<dl class=""userinfo"">
			<dt class=""author"" title="""">DrSunshine</dt>
			<dd class=""registered"">Mar 23, 2009</dd>
			<dd class=""title"">
				<div class=""bbc-center""><img src=""http://fi.somethingawful.com/customtitles/title-drsunshine.png"" alt="""" class=""img"" border=""0""><br />
The Pink Warrior should just shut up!</div><br>
				<br class=""pb"">
			</dd>
		</dl>
	</td>
	<td class=""postbody"">
		<!-- BeginContentMarker -->
		<!-- google_ad_section_start -->
		<div class=""bbc-block""><h4><a class=""quote_link"" href=""/showthread.php?goto=post&postid=427260010#post427260010"" rel=""nofollow"">drunk asian neighbor posted:</a></h4><blockquote>
I just looked up the fact that Ragyo's VA also does the voices of Edward in both Fullmetal Alchemist shows and Temari in Naruto and <img src=""http://i.somethingawful.com/forumsystem/emoticons/emot-psyduck.gif"" border=""0"" alt="""" title="":psyduck:""><br />
<br />
Now that I know it I can totally hear Edward in there, especially when she gets all worked up.<br />
</blockquote></div>

<br />
I <a href=""http://forums.somethingawful.com/showthread.php?threadid=3615945"" target=""_blank"" rel=""nofollow"">made a thread</a> about this very thing!<br />
<br />
<div class=""bbc-block""><h4><a class=""quote_link"" href=""/showthread.php?goto=post&postid=427260317#post427260317"" rel=""nofollow"">Waffleman_ posted:</a></h4><blockquote>
It's always fun to compare two roles by the same voice actor that are radically different.<br />
<br />
The many voices of Ryuko Matoi for example.<br />
<br />
<iframe class=""youtube-player"" type=""text/html"" width=""640"" height=""360"" src=""http://www.youtube-nocookie.com/embed/R5pdK4PB9Z4?fs=1&amp;theme=dark"" frameborder=""0""></iframe><br />
</blockquote></div>

<br />
Why is it that, even as a person who doesn't speak Japanese at all, <i>all</i> of this dialogue sounds unmistakably like anime dialogue? Well <i>yes</i> because it <b>is</b> anime dialogue, of course, but for some reason anime dialogue always sounds completely different from the way real Japanese people talk.
		<!-- google_ad_section_end -->
		<!-- EndContentMarker -->


		<p class=""editedby""><span>DrSunshine fucked around with this message at Mar 21, 2014 around 12:29</span>
	</td>
</tr>
<tr class=""seen2"">
	<td class=""postdate"">
		<a class=""lastseen_icon"" href=""/showthread.php?action=setseen&amp;threadid=3570170&amp;index=8850"" title=""Mark all replies as read to this point""><img src=""http://fi.somethingawful.com/style/posticon-seen.gif"" alt="""" border=""0""></a>
		<a href=""#post427260437"" title=""Link to this post"">#</a>
		<a class=""user_jump"" title=""Show posts by this user"" href=""/showthread.php?threadid=3570170&amp;userid=149105"">?</a>
		Mar 21, 2014 12:26
	</td>
	<td class=""postlinks"">
		<ul class=""profilelinks"">
			<li><a href=""member.php?action=getinfo&amp;userid=149105"">Profile</a></li>
			<li><a href=""private.php?action=newmessage&amp;userid=149105"">Message</a></li>
			<li><a href=""search.php?action=do_search_posthistory&amp;userid=149105"">Post History</a></li>
		</ul>
		<ul class=""postbuttons"">

			
			<li class=""alertbutton""><a href=""modalert.php?postid=427260437&amp;username=DrSunshine""><img src=""http://forumimages.somethingawful.com/images/button-report.gif"" border=""0"" alt=""Alert Moderators""></a>&nbsp;&nbsp;</li>
			
			<li><a href=""newreply.php?action=newreply&amp;postid=427260437""><img src=""http://fi.somethingawful.com/images/sa-quote.gif"" alt=""Quote""  title=""""></a></li>


		</ul>
	</td>
</tr>
</table><table class=""post "" id=""post427260368"" data-idx=""8849"">
<tr  class=""seen1"" id=""pti14"">
	<td class=""userinfo userid-183578"">
		<dl class=""userinfo"">
			<dt class=""author"" title="""">AnonSpore</dt>
			<dd class=""registered"">Jan 18, 2012</dd>
			<dd class=""title"">
				<img src=""http://fi.somethingawful.com/safs/titles/30/c9/00183578.0001.jpg"" alt="""" class=""img"" border=""0""><br />
<img src=""http://i.somethingawful.com/forumsystem/emoticons/emot-shepface.gif"" border=""0"" alt="""" title="":shepface:""><b>God I fucking love Diablo 3 gold, it even paid for this shitty title</b><img src=""http://i.somethingawful.com/forumsystem/emoticons/emot-shepface.gif"" border=""0"" alt="""" title="":shepface:""><br>
				<br class=""pb"">
			</dd>
		</dl>
	</td>
	<td class=""postbody"">
		<!-- BeginContentMarker -->
		<!-- google_ad_section_start -->
		<div class=""bbc-block""><h4><a class=""quote_link"" href=""/showthread.php?goto=post&postid=427260010#post427260010"" rel=""nofollow"">drunk asian neighbor posted:</a></h4><blockquote>
I just looked up the fact that Ragyo's VA also does the voices of Edward in both Fullmetal Alchemist shows and Temari in Naruto and <img src=""http://i.somethingawful.com/forumsystem/emoticons/emot-psyduck.gif"" border=""0"" alt="""" title="":psyduck:""><br />
<br />
Now that I know it I can totally hear Edward in there, especially when she gets all worked up.<br />
</blockquote></div>

<br />
Even in the series itself, Mako's little bro and Hououmaru Rei are voiced by the same person.
		<!-- google_ad_section_end -->
		<!-- EndContentMarker -->


		<p class=""editedby"">
	</td>
</tr>
<tr class=""seen1"">
	<td class=""postdate"">
		<a class=""lastseen_icon"" href=""/showthread.php?action=setseen&amp;threadid=3570170&amp;index=8849"" title=""Mark all replies as read to this point""><img src=""http://fi.somethingawful.com/style/posticon-seen.gif"" alt="""" border=""0""></a>
		<a href=""#post427260368"" title=""Link to this post"">#</a>
		<a class=""user_jump"" title=""Show posts by this user"" href=""/showthread.php?threadid=3570170&amp;userid=183578"">?</a>
		Mar 21, 2014 12:25
	</td>
	<td class=""postlinks"">
		<ul class=""profilelinks"">
			<li><a href=""member.php?action=getinfo&amp;userid=183578"">Profile</a></li>
			<li><a href=""search.php?action=do_search_posthistory&amp;userid=183578"">Post History</a></li>
		</ul>
		<ul class=""postbuttons"">

			
			<li class=""alertbutton""><a href=""modalert.php?postid=427260368&amp;username=AnonSpore""><img src=""http://forumimages.somethingawful.com/images/button-report.gif"" border=""0"" alt=""Alert Moderators""></a>&nbsp;&nbsp;</li>
			
			<li><a href=""newreply.php?action=newreply&amp;postid=427260368""><img src=""http://fi.somethingawful.com/images/sa-quote.gif"" alt=""Quote""  title=""""></a></li>


		</ul>
	</td>
</tr>
</table><table class=""post "" id=""post427260317"" data-idx=""8848"">
<tr  class=""seen2"" id=""pti15"">
	<td class=""userinfo userid-171864"">
		<dl class=""userinfo"">
			<dt class=""author"" title="""">Waffleman_</dt>
			<dd class=""registered"">Jan 20, 2011</dd>
			<dd class=""title"">
				<div class=""bbc-center""><img src=""http://fi.somethingawful.com/safs/titles/be/22/00171864.0002.gif"" alt="""" class=""img"" border=""0""><br />
The 4.5 tatami room is a truly beautiful square.<br />
Is it not magnificent?</div><br>
				<br class=""pb"">
			</dd>
		</dl>
	</td>
	<td class=""postbody"">
		<!-- BeginContentMarker -->
		<!-- google_ad_section_start -->
		It's always fun to compare two roles by the same voice actor that are radically different.<br />
<br />
The many voices of Ryuko Matoi for example.<br />
<br />
<iframe class=""youtube-player"" type=""text/html"" width=""640"" height=""360"" src=""http://www.youtube-nocookie.com/embed/R5pdK4PB9Z4?fs=1&amp;theme=dark"" frameborder=""0""></iframe>
		<!-- google_ad_section_end -->
		<!-- EndContentMarker -->


		<p class=""editedby"">
	</td>
</tr>
<tr class=""seen2"">
	<td class=""postdate"">
		<a class=""lastseen_icon"" href=""/showthread.php?action=setseen&amp;threadid=3570170&amp;index=8848"" title=""Mark all replies as read to this point""><img src=""http://fi.somethingawful.com/style/posticon-seen.gif"" alt="""" border=""0""></a>
		<a href=""#post427260317"" title=""Link to this post"">#</a>
		<a class=""user_jump"" title=""Show posts by this user"" href=""/showthread.php?threadid=3570170&amp;userid=171864"">?</a>
		Mar 21, 2014 12:24
	</td>
	<td class=""postlinks"">
		<ul class=""profilelinks"">
			<li><a href=""member.php?action=getinfo&amp;userid=171864"">Profile</a></li>
			<li><a href=""search.php?action=do_search_posthistory&amp;userid=171864"">Post History</a></li>
		</ul>
		<ul class=""postbuttons"">

			
			<li class=""alertbutton""><a href=""modalert.php?postid=427260317&amp;username=Waffleman_""><img src=""http://forumimages.somethingawful.com/images/button-report.gif"" border=""0"" alt=""Alert Moderators""></a>&nbsp;&nbsp;</li>
			
			<li><a href=""newreply.php?action=newreply&amp;postid=427260317""><img src=""http://fi.somethingawful.com/images/sa-quote.gif"" alt=""Quote""  title=""""></a></li>


		</ul>
	</td>
</tr>
</table><table class=""post "" id=""post427260010"" data-idx=""8847"">
<tr  class=""seen1"" id=""pti16"">
	<td class=""userinfo userid-40042"">
		<dl class=""userinfo"">
			<dt class=""author"" title="""">drunk asian neighbor</dt>
			<dd class=""registered"">Jul 30, 2003</dd>
			<dd class=""title"">
				<img src=""http://fi.somethingawful.com/customtitles/title-pet_rock.jpg""><br>What Would Henry Rollins Do?<br>
				<br class=""pb"">
			</dd>
		</dl>
	</td>
	<td class=""postbody"">
		<!-- BeginContentMarker -->
		<!-- google_ad_section_start -->
		I just looked up the fact that Ragyo's VA also does the voices of Edward in both Fullmetal Alchemist shows and Temari in Naruto and <img src=""http://i.somethingawful.com/forumsystem/emoticons/emot-psyduck.gif"" border=""0"" alt="""" title="":psyduck:""><br />
<br />
Now that I know it I can totally hear Edward in there, especially when she gets all worked up.
		<!-- google_ad_section_end -->
		<!-- EndContentMarker -->


		<p class=""editedby"">
	</td>
</tr>
<tr class=""seen1"">
	<td class=""postdate"">
		<a class=""lastseen_icon"" href=""/showthread.php?action=setseen&amp;threadid=3570170&amp;index=8847"" title=""Mark all replies as read to this point""><img src=""http://fi.somethingawful.com/style/posticon-seen.gif"" alt="""" border=""0""></a>
		<a href=""#post427260010"" title=""Link to this post"">#</a>
		<a class=""user_jump"" title=""Show posts by this user"" href=""/showthread.php?threadid=3570170&amp;userid=40042"">?</a>
		Mar 21, 2014 12:18
	</td>
	<td class=""postlinks"">
		<ul class=""profilelinks"">
			<li><a href=""member.php?action=getinfo&amp;userid=40042"">Profile</a></li>
			<li><a href=""private.php?action=newmessage&amp;userid=40042"">Message</a></li>
			<li><a href=""search.php?action=do_search_posthistory&amp;userid=40042"">Post History</a></li>
		</ul>
		<ul class=""postbuttons"">

			
			<li class=""alertbutton""><a href=""modalert.php?postid=427260010&amp;username=drunk+asian+neighbor""><img src=""http://forumimages.somethingawful.com/images/button-report.gif"" border=""0"" alt=""Alert Moderators""></a>&nbsp;&nbsp;</li>
			
			<li><a href=""newreply.php?action=newreply&amp;postid=427260010""><img src=""http://fi.somethingawful.com/images/sa-quote.gif"" alt=""Quote""  title=""""></a></li>


		</ul>
	</td>
</tr>
</table><table class=""post "" id=""post427257418"" data-idx=""8846"">
<tr  class=""seen2"" id=""pti17"">
	<td class=""userinfo userid-166182"">
		<dl class=""userinfo"">
			<dt class=""author"" title="""">Chev</dt>
			<dd class=""registered"">Jul 19, 2010</dd>
			<dd class=""title"">
				<br>
				<br class=""pb"">
			</dd>
		</dl>
	</td>
	<td class=""postbody"">
		<!-- BeginContentMarker -->
		<!-- google_ad_section_start -->
		<div class=""bbc-block""><h4><a class=""quote_link"" href=""/showthread.php?goto=post&postid=427224451#post427224451"" rel=""nofollow"">The Brown Menace posted:</a></h4><blockquote>
<span class=""bbc-spoiler"">Oh well, it's what Inu said. And apparently the material Bakuzan is made from can be replicated, since whatever armor plating covers the left arm of Gamagoori's new 3-star uniform is made from the same material as Bakuzan, or so he claims.</span></blockquote></div>

C'mon, they said it in this episode, <span class=""bbc-spoiler"">Ragyo tells Satsuki the material is life fibers. Did everyone really miss that or did people just fixate on the two blades thing? The double blades are specifically what allows to cut the regeneration short, but beyond that the other amazing properties of the Bakuzan and scissor blade comes from the fact they're made of hardened life fibers. Thus how a very good goku uniform can match their strength.</span><br />
<br />
Episode was awesome
		<!-- google_ad_section_end -->
		<!-- EndContentMarker -->


		<p class=""editedby"">
	</td>
</tr>
<tr class=""seen2"">
	<td class=""postdate"">
		<a class=""lastseen_icon"" href=""/showthread.php?action=setseen&amp;threadid=3570170&amp;index=8846"" title=""Mark all replies as read to this point""><img src=""http://fi.somethingawful.com/style/posticon-seen.gif"" alt="""" border=""0""></a>
		<a href=""#post427257418"" title=""Link to this post"">#</a>
		<a class=""user_jump"" title=""Show posts by this user"" href=""/showthread.php?threadid=3570170&amp;userid=166182"">?</a>
		Mar 21, 2014 11:20
	</td>
	<td class=""postlinks"">
		<ul class=""profilelinks"">
			<li><a href=""member.php?action=getinfo&amp;userid=166182"">Profile</a></li>
			<li><a href=""private.php?action=newmessage&amp;userid=166182"">Message</a></li>
			<li><a href=""search.php?action=do_search_posthistory&amp;userid=166182"">Post History</a></li>
		</ul>
		<ul class=""postbuttons"">

			
			<li class=""alertbutton""><a href=""modalert.php?postid=427257418&amp;username=Chev""><img src=""http://forumimages.somethingawful.com/images/button-report.gif"" border=""0"" alt=""Alert Moderators""></a>&nbsp;&nbsp;</li>
			
			<li><a href=""newreply.php?action=newreply&amp;postid=427257418""><img src=""http://fi.somethingawful.com/images/sa-quote.gif"" alt=""Quote""  title=""""></a></li>


		</ul>
	</td>
</tr>
</table><table class=""post "" id=""post427257344"" data-idx=""8845"">
<tr  class=""seen1"" id=""pti18"">
	<td class=""userinfo userid-140153"">
		<dl class=""userinfo"">
			<dt class=""author"" title="""">PunkBoy</dt>
			<dd class=""registered"">Aug 21, 2008</dd>
			<dd class=""title"">
				<div class=""bbc-center""><img src=""http://fi.somethingawful.com/safs/titles/c9/eb/00140153.0001.jpg"" alt="""" class=""img"" border=""0""><br />
Do I have everybody's attention now?</div><br>
				<br class=""pb"">
			</dd>
		</dl>
	</td>
	<td class=""postbody"">
		<!-- BeginContentMarker -->
		<!-- google_ad_section_start -->
		<div class=""bbc-block""><h4><a class=""quote_link"" href=""/showthread.php?goto=post&postid=427238034#post427238034"" rel=""nofollow"">Justin_Brett posted:</a></h4><blockquote>
<span class=""bbc-spoiler"">Did Nui just do the Wyatt Family's entrance in the credits there?</span><br />
</blockquote></div>

<br />
A bit late, but I thought the exact same thing.<br />
<br />
<span class=""bbc-spoiler""> ""Honnouji Academy.  We're here."" <img src=""http://i.somethingawful.com/forumsystem/emoticons/emot-stare.gif"" border=""0"" alt="""" title="":stare:""> <i>Catching fibersss....</i></span>
		<!-- google_ad_section_end -->
		<!-- EndContentMarker -->


		<p class=""editedby""><span>PunkBoy fucked around with this message at Mar 21, 2014 around 11:20</span>
	</td>
</tr>
<tr class=""seen1"">
	<td class=""postdate"">
		<a class=""lastseen_icon"" href=""/showthread.php?action=setseen&amp;threadid=3570170&amp;index=8845"" title=""Mark all replies as read to this point""><img src=""http://fi.somethingawful.com/style/posticon-seen.gif"" alt="""" border=""0""></a>
		<a href=""#post427257344"" title=""Link to this post"">#</a>
		<a class=""user_jump"" title=""Show posts by this user"" href=""/showthread.php?threadid=3570170&amp;userid=140153"">?</a>
		Mar 21, 2014 11:17
	</td>
	<td class=""postlinks"">
		<ul class=""profilelinks"">
			<li><a href=""member.php?action=getinfo&amp;userid=140153"">Profile</a></li>
			<li><a href=""search.php?action=do_search_posthistory&amp;userid=140153"">Post History</a></li>
		</ul>
		<ul class=""postbuttons"">

			
			<li class=""alertbutton""><a href=""modalert.php?postid=427257344&amp;username=PunkBoy""><img src=""http://forumimages.somethingawful.com/images/button-report.gif"" border=""0"" alt=""Alert Moderators""></a>&nbsp;&nbsp;</li>
			
			<li><a href=""newreply.php?action=newreply&amp;postid=427257344""><img src=""http://fi.somethingawful.com/images/sa-quote.gif"" alt=""Quote""  title=""""></a></li>


		</ul>
	</td>
</tr>
</table><table class=""post "" id=""post427256725"" data-idx=""8844"">
<tr  class=""seen2"" id=""pti19"">
	<td class=""userinfo userid-183578"">
		<dl class=""userinfo"">
			<dt class=""author"" title="""">AnonSpore</dt>
			<dd class=""registered"">Jan 18, 2012</dd>
			<dd class=""title"">
				<img src=""http://fi.somethingawful.com/safs/titles/30/c9/00183578.0001.jpg"" alt="""" class=""img"" border=""0""><br />
<img src=""http://i.somethingawful.com/forumsystem/emoticons/emot-shepface.gif"" border=""0"" alt="""" title="":shepface:""><b>God I fucking love Diablo 3 gold, it even paid for this shitty title</b><img src=""http://i.somethingawful.com/forumsystem/emoticons/emot-shepface.gif"" border=""0"" alt="""" title="":shepface:""><br>
				<br class=""pb"">
			</dd>
		</dl>
	</td>
	<td class=""postbody"">
		<!-- BeginContentMarker -->
		<!-- google_ad_section_start -->
		<div class=""bbc-block""><h4><a class=""quote_link"" href=""/showthread.php?goto=post&postid=427256558#post427256558"" rel=""nofollow"">DrSunshine posted:</a></h4><blockquote>
I'm still waiting on the giant space irons to come down and flatten out all the wrinkles in the planet covered in cloth (and in peoples' brains)! <img src=""http://fi.somethingawful.com/images/smilies/emot-v.gif"" border=""0"" alt="""" title="":v:""><br />
</blockquote></div>

<br />
And that's how Medical Mechanica came to replace REVOCS as the largest conglomerate on the planet
		<!-- google_ad_section_end -->
		<!-- EndContentMarker -->


		<p class=""editedby"">
	</td>
</tr>
<tr class=""seen2"">
	<td class=""postdate"">
		<a class=""lastseen_icon"" href=""/showthread.php?action=setseen&amp;threadid=3570170&amp;index=8844"" title=""Mark all replies as read to this point""><img src=""http://fi.somethingawful.com/style/posticon-seen.gif"" alt="""" border=""0""></a>
		<a href=""#post427256725"" title=""Link to this post"">#</a>
		<a class=""user_jump"" title=""Show posts by this user"" href=""/showthread.php?threadid=3570170&amp;userid=183578"">?</a>
		Mar 21, 2014 11:03
	</td>
	<td class=""postlinks"">
		<ul class=""profilelinks"">
			<li><a href=""member.php?action=getinfo&amp;userid=183578"">Profile</a></li>
			<li><a href=""search.php?action=do_search_posthistory&amp;userid=183578"">Post History</a></li>
		</ul>
		<ul class=""postbuttons"">

			
			<li class=""alertbutton""><a href=""modalert.php?postid=427256725&amp;username=AnonSpore""><img src=""http://forumimages.somethingawful.com/images/button-report.gif"" border=""0"" alt=""Alert Moderators""></a>&nbsp;&nbsp;</li>
			
			<li><a href=""newreply.php?action=newreply&amp;postid=427256725""><img src=""http://fi.somethingawful.com/images/sa-quote.gif"" alt=""Quote""  title=""""></a></li>


		</ul>
	</td>
</tr>
</table><table class=""post "" id=""post427256619"" data-idx=""8843"">
<tr  class=""seen1"" id=""pti20"">
	<td class=""userinfo userid-180482"">
		<dl class=""userinfo"">
			<dt class=""author"" title="""">graybook</dt>
			<dd class=""registered"">Oct 10, 2011</dd>
			<dd class=""title"">
				<div class=""bbc-center""><img src=""http://fi.somethingawful.com/safs/titles/97/f7/00180482.0001.png"" alt="""" class=""img"" border=""0""><br />
<span style=""color:purple;"">The resolution on this ding dong is <b>SAAACK.</b></span><br />
<img src=""http://fi.somethingawful.com/safs/titles/7a/8c/00177214.0001.gif"" alt="""" class=""img"" border=""0""></div><br>
				<br class=""pb"">
			</dd>
		</dl>
	</td>
	<td class=""postbody"">
		<!-- BeginContentMarker -->
		<!-- google_ad_section_start -->
		<div class=""bbc-block""><h4><a class=""quote_link"" href=""/showthread.php?goto=post&postid=427243612#post427243612"" rel=""nofollow"">Ranzear posted:</a></h4><blockquote>
How did I type transmitter twice? I think I might have been contemplating if 'OLF' was descriptive enough, I think I blew the edit. <span class=""bbc-spoiler"">The ship got rammed into <i>something</i> anyway, but who would have predicted that to be Ryuuko's ass as well <img src=""http://fi.somethingawful.com/images/smilies/emot-v.gif"" border=""0"" alt="""" title="":v:""></span><br />
<br />
Have some freakin' pans:<br />
Just when you thought he couldn't get any bigger.<br />
</blockquote></div>

<br />
Wasn't <span class=""bbc-spoiler"">Gamagoori so big at one point in the episode that he squished a combat-spec COVERS with his hands, or was that a regular human-powered COVERS? I loved that.</span>
		<!-- google_ad_section_end -->
		<!-- EndContentMarker -->


		<p class=""editedby"">
	</td>
</tr>
<tr class=""seen1"">
	<td class=""postdate"">
		<a class=""lastseen_icon"" href=""/showthread.php?action=setseen&amp;threadid=3570170&amp;index=8843"" title=""Mark all replies as read to this point""><img src=""http://fi.somethingawful.com/style/posticon-seen.gif"" alt="""" border=""0""></a>
		<a href=""#post427256619"" title=""Link to this post"">#</a>
		<a class=""user_jump"" title=""Show posts by this user"" href=""/showthread.php?threadid=3570170&amp;userid=180482"">?</a>
		Mar 21, 2014 11:01
	</td>
	<td class=""postlinks"">
		<ul class=""profilelinks"">
			<li><a href=""member.php?action=getinfo&amp;userid=180482"">Profile</a></li>
			<li><a href=""private.php?action=newmessage&amp;userid=180482"">Message</a></li>
			<li><a href=""search.php?action=do_search_posthistory&amp;userid=180482"">Post History</a></li>
		</ul>
		<ul class=""postbuttons"">

			
			<li class=""alertbutton""><a href=""modalert.php?postid=427256619&amp;username=graybook""><img src=""http://forumimages.somethingawful.com/images/button-report.gif"" border=""0"" alt=""Alert Moderators""></a>&nbsp;&nbsp;</li>
			
			<li><a href=""newreply.php?action=newreply&amp;postid=427256619""><img src=""http://fi.somethingawful.com/images/sa-quote.gif"" alt=""Quote""  title=""""></a></li>


		</ul>
	</td>
</tr>
</table><table class=""post "" id=""post427256558"" data-idx=""8842"">
<tr  class=""seen2"" id=""pti21"">
	<td class=""userinfo userid-149105"">
		<dl class=""userinfo"">
			<dt class=""author"" title="""">DrSunshine</dt>
			<dd class=""registered"">Mar 23, 2009</dd>
			<dd class=""title"">
				<div class=""bbc-center""><img src=""http://fi.somethingawful.com/customtitles/title-drsunshine.png"" alt="""" class=""img"" border=""0""><br />
The Pink Warrior should just shut up!</div><br>
				<br class=""pb"">
			</dd>
		</dl>
	</td>
	<td class=""postbody"">
		<!-- BeginContentMarker -->
		<!-- google_ad_section_start -->
		I'm still waiting on the giant space irons to come down and flatten out all the wrinkles in the planet covered in cloth (and in peoples' brains)! <img src=""http://fi.somethingawful.com/images/smilies/emot-v.gif"" border=""0"" alt="""" title="":v:"">
		<!-- google_ad_section_end -->
		<!-- EndContentMarker -->


		<p class=""editedby"">
	</td>
</tr>
<tr class=""seen2"">
	<td class=""postdate"">
		<a class=""lastseen_icon"" href=""/showthread.php?action=setseen&amp;threadid=3570170&amp;index=8842"" title=""Mark all replies as read to this point""><img src=""http://fi.somethingawful.com/style/posticon-seen.gif"" alt="""" border=""0""></a>
		<a href=""#post427256558"" title=""Link to this post"">#</a>
		<a class=""user_jump"" title=""Show posts by this user"" href=""/showthread.php?threadid=3570170&amp;userid=149105"">?</a>
		Mar 21, 2014 11:00
	</td>
	<td class=""postlinks"">
		<ul class=""profilelinks"">
			<li><a href=""member.php?action=getinfo&amp;userid=149105"">Profile</a></li>
			<li><a href=""private.php?action=newmessage&amp;userid=149105"">Message</a></li>
			<li><a href=""search.php?action=do_search_posthistory&amp;userid=149105"">Post History</a></li>
		</ul>
		<ul class=""postbuttons"">

			
			<li class=""alertbutton""><a href=""modalert.php?postid=427256558&amp;username=DrSunshine""><img src=""http://forumimages.somethingawful.com/images/button-report.gif"" border=""0"" alt=""Alert Moderators""></a>&nbsp;&nbsp;</li>
			
			<li><a href=""newreply.php?action=newreply&amp;postid=427256558""><img src=""http://fi.somethingawful.com/images/sa-quote.gif"" alt=""Quote""  title=""""></a></li>


		</ul>
	</td>
</tr>
</table><table class=""post "" id=""post427256394"" data-idx=""8841"">
<tr  class=""seen1"" id=""pti22"">
	<td class=""userinfo userid-103827"">
		<dl class=""userinfo"">
			<dt class=""author"" title="""">tsob</dt>
			<dd class=""registered"">Sep 26, 2006</dd>
			<dd class=""title"">
				<div class=""bbc-center""><img src=""http://fi.somethingawful.com/customtitles/title-tsob.png"" alt="""" class=""img"" border=""0""><br />
<span style=""color:red;""><span class=""bbcf-large"">Chalalala~</span></span></div><br>
				<br class=""pb"">
			</dd>
		</dl>
	</td>
	<td class=""postbody"">
		<!-- BeginContentMarker -->
		<!-- google_ad_section_start -->
		Don't worry, next episode will start from her POV as she blinks, before zooming out to show a giant foot squashing her. It may or may not be wearing some kinky heels.
		<!-- google_ad_section_end -->
		<!-- EndContentMarker -->


		<p class=""editedby"">
	</td>
</tr>
<tr class=""seen1"">
	<td class=""postdate"">
		<a class=""lastseen_icon"" href=""/showthread.php?action=setseen&amp;threadid=3570170&amp;index=8841"" title=""Mark all replies as read to this point""><img src=""http://fi.somethingawful.com/style/posticon-seen.gif"" alt="""" border=""0""></a>
		<a href=""#post427256394"" title=""Link to this post"">#</a>
		<a class=""user_jump"" title=""Show posts by this user"" href=""/showthread.php?threadid=3570170&amp;userid=103827"">?</a>
		Mar 21, 2014 10:55
	</td>
	<td class=""postlinks"">
		<ul class=""profilelinks"">
			<li><a href=""member.php?action=getinfo&amp;userid=103827"">Profile</a></li>
			<li><a href=""private.php?action=newmessage&amp;userid=103827"">Message</a></li>
			<li><a href=""search.php?action=do_search_posthistory&amp;userid=103827"">Post History</a></li>
		</ul>
		<ul class=""postbuttons"">

			
			<li class=""alertbutton""><a href=""modalert.php?postid=427256394&amp;username=tsob""><img src=""http://forumimages.somethingawful.com/images/button-report.gif"" border=""0"" alt=""Alert Moderators""></a>&nbsp;&nbsp;</li>
			
			<li><a href=""newreply.php?action=newreply&amp;postid=427256394""><img src=""http://fi.somethingawful.com/images/sa-quote.gif"" alt=""Quote""  title=""""></a></li>


		</ul>
	</td>
</tr>
</table><table class=""post "" id=""post427256222"" data-idx=""8840"">
<tr  class=""seen2"" id=""pti23"">
	<td class=""userinfo userid-196323"">
		<dl class=""userinfo"">
			<dt class=""author"" title="""">Captain Quack</dt>
			<dd class=""registered"">Feb 17, 2013</dd>
			<dd class=""title"">
				<img src=""http://fi.somethingawful.com/images/newbie.gif"" alt="""" class=""img"" border=""0""><br>
				<br class=""pb"">
			</dd>
		</dl>
	</td>
	<td class=""postbody"">
		<!-- BeginContentMarker -->
		<!-- google_ad_section_start -->
		<div class=""bbc-block""><h4><a class=""quote_link"" href=""/showthread.php?goto=post&postid=427248359#post427248359"" rel=""nofollow"">Franz von Dada posted:</a></h4><blockquote>
<span class=""bbc-spoiler""><img src=""http://i.imgur.com/4lwcfQP.png"" alt="""" class=""timg"" border=""0""></span><br />
</blockquote></div>

<br />
This is blasphemous! No one should be bigger than Gamagori!
		<!-- google_ad_section_end -->
		<!-- EndContentMarker -->


		<p class=""editedby"">
	</td>
</tr>
<tr class=""seen2"">
	<td class=""postdate"">
		<a class=""lastseen_icon"" href=""/showthread.php?action=setseen&amp;threadid=3570170&amp;index=8840"" title=""Mark all replies as read to this point""><img src=""http://fi.somethingawful.com/style/posticon-seen.gif"" alt="""" border=""0""></a>
		<a href=""#post427256222"" title=""Link to this post"">#</a>
		<a class=""user_jump"" title=""Show posts by this user"" href=""/showthread.php?threadid=3570170&amp;userid=196323"">?</a>
		Mar 21, 2014 10:51
	</td>
	<td class=""postlinks"">
		<ul class=""profilelinks"">
			<li><a href=""member.php?action=getinfo&amp;userid=196323"">Profile</a></li>
			<li><a href=""search.php?action=do_search_posthistory&amp;userid=196323"">Post History</a></li>
		</ul>
		<ul class=""postbuttons"">

			
			<li class=""alertbutton""><a href=""modalert.php?postid=427256222&amp;username=Captain+Quack""><img src=""http://forumimages.somethingawful.com/images/button-report.gif"" border=""0"" alt=""Alert Moderators""></a>&nbsp;&nbsp;</li>
			
			<li><a href=""newreply.php?action=newreply&amp;postid=427256222""><img src=""http://fi.somethingawful.com/images/sa-quote.gif"" alt=""Quote""  title=""""></a></li>


		</ul>
	</td>
</tr>
</table><table class=""post "" id=""post427249914"" data-idx=""8839"">
<tr  class=""seen1"" id=""pti24"">
	<td class=""userinfo userid-149105"">
		<dl class=""userinfo"">
			<dt class=""author"" title="""">DrSunshine</dt>
			<dd class=""registered"">Mar 23, 2009</dd>
			<dd class=""title"">
				<div class=""bbc-center""><img src=""http://fi.somethingawful.com/customtitles/title-drsunshine.png"" alt="""" class=""img"" border=""0""><br />
The Pink Warrior should just shut up!</div><br>
				<br class=""pb"">
			</dd>
		</dl>
	</td>
	<td class=""postbody"">
		<!-- BeginContentMarker -->
		<!-- google_ad_section_start -->
		<div class=""bbc-block""><h4><a class=""quote_link"" href=""/showthread.php?goto=post&postid=427249035#post427249035"" rel=""nofollow"">IronicDongz posted:</a></h4><blockquote>
Kill la Kill is a serious anime.<br />
<img src=""http://i.somethingawful.com/forumsystem/emoticons/emot-supaburn.gif"" border=""0"" alt="""" title="":supaburn:""><br />
</blockquote></div>

<br />
I think that was my favorite part of the episode, I could barely stop laughing for like a minute! It was hilarious, and I'm glad that Trigger realized that they could still be funny while the characters were taking things seriously.
		<!-- google_ad_section_end -->
		<!-- EndContentMarker -->


		<p class=""editedby"">
	</td>
</tr>
<tr class=""seen1"">
	<td class=""postdate"">
		<a class=""lastseen_icon"" href=""/showthread.php?action=setseen&amp;threadid=3570170&amp;index=8839"" title=""Mark all replies as read to this point""><img src=""http://fi.somethingawful.com/style/posticon-seen.gif"" alt="""" border=""0""></a>
		<a href=""#post427249914"" title=""Link to this post"">#</a>
		<a class=""user_jump"" title=""Show posts by this user"" href=""/showthread.php?threadid=3570170&amp;userid=149105"">?</a>
		Mar 21, 2014 08:01
	</td>
	<td class=""postlinks"">
		<ul class=""profilelinks"">
			<li><a href=""member.php?action=getinfo&amp;userid=149105"">Profile</a></li>
			<li><a href=""private.php?action=newmessage&amp;userid=149105"">Message</a></li>
			<li><a href=""search.php?action=do_search_posthistory&amp;userid=149105"">Post History</a></li>
		</ul>
		<ul class=""postbuttons"">

			
			<li class=""alertbutton""><a href=""modalert.php?postid=427249914&amp;username=DrSunshine""><img src=""http://forumimages.somethingawful.com/images/button-report.gif"" border=""0"" alt=""Alert Moderators""></a>&nbsp;&nbsp;</li>
			
			<li><a href=""newreply.php?action=newreply&amp;postid=427249914""><img src=""http://fi.somethingawful.com/images/sa-quote.gif"" alt=""Quote""  title=""""></a></li>


		</ul>
	</td>
</tr>
</table><table class=""post "" id=""post427249613"" data-idx=""8838"">
<tr  class=""seen2"" id=""pti25"">
	<td class=""userinfo userid-184331"">
		<dl class=""userinfo"">
			<dt class=""author"" title="""">Darth Walrus</dt>
			<dd class=""registered"">Feb 13, 2012</dd>
			<dd class=""title"">
				<img src=""http://fi.somethingawful.com/images/newbie.gif"" alt="""" class=""img"" border=""0""><br>
				<br class=""pb"">
			</dd>
		</dl>
	</td>
	<td class=""postbody"">
		<!-- BeginContentMarker -->
		<!-- google_ad_section_start -->
		<div class=""bbc-block""><h4><a class=""quote_link"" href=""/showthread.php?goto=post&postid=427249035#post427249035"" rel=""nofollow"">IronicDongz posted:</a></h4><blockquote>
Kill la Kill is a serious anime.<br />
<br />
<img src=""http://i.somethingawful.com/forumsystem/emoticons/emot-supaburn.gif"" border=""0"" alt="""" title="":supaburn:""><br />
</blockquote></div>

<br />
Well, it's seriously anime, that's for sure.
		<!-- google_ad_section_end -->
		<!-- EndContentMarker -->


		<p class=""editedby"">
	</td>
</tr>
<tr class=""seen2"">
	<td class=""postdate"">
		<a class=""lastseen_icon"" href=""/showthread.php?action=setseen&amp;threadid=3570170&amp;index=8838"" title=""Mark all replies as read to this point""><img src=""http://fi.somethingawful.com/style/posticon-seen.gif"" alt="""" border=""0""></a>
		<a href=""#post427249613"" title=""Link to this post"">#</a>
		<a class=""user_jump"" title=""Show posts by this user"" href=""/showthread.php?threadid=3570170&amp;userid=184331"">?</a>
		Mar 21, 2014 07:51
	</td>
	<td class=""postlinks"">
		<ul class=""profilelinks"">
			<li><a href=""member.php?action=getinfo&amp;userid=184331"">Profile</a></li>
			<li><a href=""private.php?action=newmessage&amp;userid=184331"">Message</a></li>
			<li><a href=""search.php?action=do_search_posthistory&amp;userid=184331"">Post History</a></li>
		</ul>
		<ul class=""postbuttons"">

			
			<li class=""alertbutton""><a href=""modalert.php?postid=427249613&amp;username=Darth+Walrus""><img src=""http://forumimages.somethingawful.com/images/button-report.gif"" border=""0"" alt=""Alert Moderators""></a>&nbsp;&nbsp;</li>
			
			<li><a href=""newreply.php?action=newreply&amp;postid=427249613""><img src=""http://fi.somethingawful.com/images/sa-quote.gif"" alt=""Quote""  title=""""></a></li>


		</ul>
	</td>
</tr>
</table><table class=""post "" id=""post427249035"" data-idx=""8837"">
<tr  class=""seen1"" id=""pti26"">
	<td class=""userinfo userid-204232"">
		<dl class=""userinfo"">
			<dt class=""author"" title="""">IronicDongz</dt>
			<dd class=""registered"">Aug 18, 2013</dd>
			<dd class=""title"">
				<br>
				<br class=""pb"">
			</dd>
		</dl>
	</td>
	<td class=""postbody"">
		<!-- BeginContentMarker -->
		<!-- google_ad_section_start -->
		Kill la Kill is a serious anime.<br />
<span class=""bbc-spoiler""><img src=""http://i.gyazo.com/6abe5231088f2822464ad27dc9f0d1ce.gif"" alt="""" class=""img"" border=""0""></span><br />
<img src=""http://i.somethingawful.com/forumsystem/emoticons/emot-supaburn.gif"" border=""0"" alt="""" title="":supaburn:"">
		<!-- google_ad_section_end -->
		<!-- EndContentMarker -->


		<p class=""editedby"">
	</td>
</tr>
<tr class=""seen1"">
	<td class=""postdate"">
		<a class=""lastseen_icon"" href=""/showthread.php?action=setseen&amp;threadid=3570170&amp;index=8837"" title=""Mark all replies as read to this point""><img src=""http://fi.somethingawful.com/style/posticon-seen.gif"" alt="""" border=""0""></a>
		<a href=""#post427249035"" title=""Link to this post"">#</a>
		<a class=""user_jump"" title=""Show posts by this user"" href=""/showthread.php?threadid=3570170&amp;userid=204232"">?</a>
		Mar 21, 2014 07:29
	</td>
	<td class=""postlinks"">
		<ul class=""profilelinks"">
			<li><a href=""member.php?action=getinfo&amp;userid=204232"">Profile</a></li>
			<li><a href=""search.php?action=do_search_posthistory&amp;userid=204232"">Post History</a></li>
		</ul>
		<ul class=""postbuttons"">

			
			<li class=""alertbutton""><a href=""modalert.php?postid=427249035&amp;username=IronicDongz""><img src=""http://forumimages.somethingawful.com/images/button-report.gif"" border=""0"" alt=""Alert Moderators""></a>&nbsp;&nbsp;</li>
			
			<li><a href=""newreply.php?action=newreply&amp;postid=427249035""><img src=""http://fi.somethingawful.com/images/sa-quote.gif"" alt=""Quote""  title=""""></a></li>


		</ul>
	</td>
</tr>
</table><table class=""post "" id=""post427248873"" data-idx=""8836"">
<tr  class=""seen2"" id=""pti27"">
	<td class=""userinfo userid-103827"">
		<dl class=""userinfo"">
			<dt class=""author"" title="""">tsob</dt>
			<dd class=""registered"">Sep 26, 2006</dd>
			<dd class=""title"">
				<div class=""bbc-center""><img src=""http://fi.somethingawful.com/customtitles/title-tsob.png"" alt="""" class=""img"" border=""0""><br />
<span style=""color:red;""><span class=""bbcf-large"">Chalalala~</span></span></div><br>
				<br class=""pb"">
			</dd>
		</dl>
	</td>
	<td class=""postbody"">
		<!-- BeginContentMarker -->
		<!-- google_ad_section_start -->
		<div class=""bbc-block""><h4><a class=""quote_link"" href=""/showthread.php?goto=post&postid=427248488#post427248488"" rel=""nofollow"">DrSunshine posted:</a></h4><blockquote>
Huh! So apparently <span class=""bbc-spoiler"">Inumuta has no dick!</span> Good to know!<br />
</blockquote></div>

<br />
On the other hand he's rocking some Harry Ord shades, which is more important than anything else about him.
		<!-- google_ad_section_end -->
		<!-- EndContentMarker -->


		<p class=""editedby"">
	</td>
</tr>
<tr class=""seen2"">
	<td class=""postdate"">
		<a class=""lastseen_icon"" href=""/showthread.php?action=setseen&amp;threadid=3570170&amp;index=8836"" title=""Mark all replies as read to this point""><img src=""http://fi.somethingawful.com/style/posticon-seen.gif"" alt="""" border=""0""></a>
		<a href=""#post427248873"" title=""Link to this post"">#</a>
		<a class=""user_jump"" title=""Show posts by this user"" href=""/showthread.php?threadid=3570170&amp;userid=103827"">?</a>
		Mar 21, 2014 07:23
	</td>
	<td class=""postlinks"">
		<ul class=""profilelinks"">
			<li><a href=""member.php?action=getinfo&amp;userid=103827"">Profile</a></li>
			<li><a href=""private.php?action=newmessage&amp;userid=103827"">Message</a></li>
			<li><a href=""search.php?action=do_search_posthistory&amp;userid=103827"">Post History</a></li>
		</ul>
		<ul class=""postbuttons"">

			
			<li class=""alertbutton""><a href=""modalert.php?postid=427248873&amp;username=tsob""><img src=""http://forumimages.somethingawful.com/images/button-report.gif"" border=""0"" alt=""Alert Moderators""></a>&nbsp;&nbsp;</li>
			
			<li><a href=""newreply.php?action=newreply&amp;postid=427248873""><img src=""http://fi.somethingawful.com/images/sa-quote.gif"" alt=""Quote""  title=""""></a></li>


		</ul>
	</td>
</tr>
</table><table class=""post "" id=""post427248624"" data-idx=""8835"">
<tr  class=""seen1"" id=""pti28"">
	<td class=""userinfo userid-65603"">
		<dl class=""userinfo"">
			<dt class=""author"" title="""">doomisland</dt>
			<dd class=""registered"">Oct  5, 2004</dd>
			<dd class=""title"">
				<div class=""bbc-center""><img src=""http://fi.somethingawful.com/customtitles/title-doomisland-6.jpg"" alt="""" class=""img"" border=""0""><br />
</div><br>
				<br class=""pb"">
			</dd>
		</dl>
	</td>
	<td class=""postbody"">
		<!-- BeginContentMarker -->
		<!-- google_ad_section_start -->
		<div class=""bbc-block""><h4><a class=""quote_link"" href=""/showthread.php?goto=post&postid=427244214#post427244214"" rel=""nofollow"">Fellis posted:</a></h4><blockquote>
ep23 credits <span class=""bbc-spoiler"">Nui intruding on the end of the credit sequence literally sent a chill down my spine holy shit</span><br />
<br />
This episode was so freaking awesome, so many good bits<br />
</blockquote></div>

<br />
Literally
		<!-- google_ad_section_end -->
		<!-- EndContentMarker -->


		<p class=""editedby"">
	</td>
</tr>
<tr class=""seen1"">
	<td class=""postdate"">
		<a class=""lastseen_icon"" href=""/showthread.php?action=setseen&amp;threadid=3570170&amp;index=8835"" title=""Mark all replies as read to this point""><img src=""http://fi.somethingawful.com/style/posticon-seen.gif"" alt="""" border=""0""></a>
		<a href=""#post427248624"" title=""Link to this post"">#</a>
		<a class=""user_jump"" title=""Show posts by this user"" href=""/showthread.php?threadid=3570170&amp;userid=65603"">?</a>
		Mar 21, 2014 07:13
	</td>
	<td class=""postlinks"">
		<ul class=""profilelinks"">
			<li><a href=""member.php?action=getinfo&amp;userid=65603"">Profile</a></li>
			<li><a href=""private.php?action=newmessage&amp;userid=65603"">Message</a></li>
			<li><a href=""search.php?action=do_search_posthistory&amp;userid=65603"">Post History</a></li>
		</ul>
		<ul class=""postbuttons"">

			
			<li class=""alertbutton""><a href=""modalert.php?postid=427248624&amp;username=doomisland""><img src=""http://forumimages.somethingawful.com/images/button-report.gif"" border=""0"" alt=""Alert Moderators""></a>&nbsp;&nbsp;</li>
			
			<li><a href=""newreply.php?action=newreply&amp;postid=427248624""><img src=""http://fi.somethingawful.com/images/sa-quote.gif"" alt=""Quote""  title=""""></a></li>


		</ul>
	</td>
</tr>
</table><table class=""post "" id=""post427248578"" data-idx=""8834"">
<tr  class=""seen2"" id=""pti29"">
	<td class=""userinfo userid-190929"">
		<dl class=""userinfo"">
			<dt class=""author"" title="""">Dick Spacious CPA</dt>
			<dd class=""registered"">Oct 10, 2012</dd>
			<dd class=""title"">
				<div class=""bbc-center""><img src=""http://fi.somethingawful.com/safs/titles/bb/0d/00190929.0001.jpg"" alt="""" class=""img"" border=""0""><br />
</div><br>
				<br class=""pb"">
			</dd>
		</dl>
	</td>
	<td class=""postbody"">
		<!-- BeginContentMarker -->
		<!-- google_ad_section_start -->
		<div class=""bbc-block""><h4><a class=""quote_link"" href=""/showthread.php?goto=post&postid=427248488#post427248488"" rel=""nofollow"">DrSunshine posted:</a></h4><blockquote>
Huh! So apparently <span class=""bbc-spoiler"">Inumuta has no dick!</span> Good to know!<br />
</blockquote></div>

<br />
haha yea that is good to know! thanks.
		<!-- google_ad_section_end -->
		<!-- EndContentMarker -->


		<p class=""editedby"">
	</td>
</tr>
<tr class=""seen2"">
	<td class=""postdate"">
		<a class=""lastseen_icon"" href=""/showthread.php?action=setseen&amp;threadid=3570170&amp;index=8834"" title=""Mark all replies as read to this point""><img src=""http://fi.somethingawful.com/style/posticon-seen.gif"" alt="""" border=""0""></a>
		<a href=""#post427248578"" title=""Link to this post"">#</a>
		<a class=""user_jump"" title=""Show posts by this user"" href=""/showthread.php?threadid=3570170&amp;userid=190929"">?</a>
		Mar 21, 2014 07:11
	</td>
	<td class=""postlinks"">
		<ul class=""profilelinks"">
			<li><a href=""member.php?action=getinfo&amp;userid=190929"">Profile</a></li>
			<li><a href=""private.php?action=newmessage&amp;userid=190929"">Message</a></li>
			<li><a href=""search.php?action=do_search_posthistory&amp;userid=190929"">Post History</a></li>
		</ul>
		<ul class=""postbuttons"">

			
			<li class=""alertbutton""><a href=""modalert.php?postid=427248578&amp;username=Dick+Spacious+CPA""><img src=""http://forumimages.somethingawful.com/images/button-report.gif"" border=""0"" alt=""Alert Moderators""></a>&nbsp;&nbsp;</li>
			
			<li><a href=""newreply.php?action=newreply&amp;postid=427248578""><img src=""http://fi.somethingawful.com/images/sa-quote.gif"" alt=""Quote""  title=""""></a></li>


		</ul>
	</td>
</tr>
</table><table class=""post "" id=""post427248488"" data-idx=""8833"">
<tr  class=""seen1"" id=""pti30"">
	<td class=""userinfo userid-149105"">
		<dl class=""userinfo"">
			<dt class=""author"" title="""">DrSunshine</dt>
			<dd class=""registered"">Mar 23, 2009</dd>
			<dd class=""title"">
				<div class=""bbc-center""><img src=""http://fi.somethingawful.com/customtitles/title-drsunshine.png"" alt="""" class=""img"" border=""0""><br />
The Pink Warrior should just shut up!</div><br>
				<br class=""pb"">
			</dd>
		</dl>
	</td>
	<td class=""postbody"">
		<!-- BeginContentMarker -->
		<!-- google_ad_section_start -->
		<div class=""bbc-block""><h4><a class=""quote_link"" href=""/showthread.php?goto=post&postid=427243612#post427243612"" rel=""nofollow"">Ranzear posted:</a></h4><blockquote>
<br />
Have some freakin' pans:<br />
</blockquote></div>

<br />
Huh! So apparently <span class=""bbc-spoiler"">Inumuta has no dick!</span> Good to know!
		<!-- google_ad_section_end -->
		<!-- EndContentMarker -->


		<p class=""editedby"">
	</td>
</tr>
<tr class=""seen1"">
	<td class=""postdate"">
		<a class=""lastseen_icon"" href=""/showthread.php?action=setseen&amp;threadid=3570170&amp;index=8833"" title=""Mark all replies as read to this point""><img src=""http://fi.somethingawful.com/style/posticon-seen.gif"" alt="""" border=""0""></a>
		<a href=""#post427248488"" title=""Link to this post"">#</a>
		<a class=""user_jump"" title=""Show posts by this user"" href=""/showthread.php?threadid=3570170&amp;userid=149105"">?</a>
		Mar 21, 2014 07:07
	</td>
	<td class=""postlinks"">
		<ul class=""profilelinks"">
			<li><a href=""member.php?action=getinfo&amp;userid=149105"">Profile</a></li>
			<li><a href=""private.php?action=newmessage&amp;userid=149105"">Message</a></li>
			<li><a href=""search.php?action=do_search_posthistory&amp;userid=149105"">Post History</a></li>
		</ul>
		<ul class=""postbuttons"">

			
			<li class=""alertbutton""><a href=""modalert.php?postid=427248488&amp;username=DrSunshine""><img src=""http://forumimages.somethingawful.com/images/button-report.gif"" border=""0"" alt=""Alert Moderators""></a>&nbsp;&nbsp;</li>
			
			<li><a href=""newreply.php?action=newreply&amp;postid=427248488""><img src=""http://fi.somethingawful.com/images/sa-quote.gif"" alt=""Quote""  title=""""></a></li>


		</ul>
	</td>
</tr>
</table><table class=""post "" id=""post427248359"" data-idx=""8832"">
<tr  class=""seen2"" id=""pti31"">
	<td class=""userinfo userid-208335"">
		<dl class=""userinfo"">
			<dt class=""author"" title="""">Franz von Dada</dt>
			<dd class=""registered"">Feb 10, 2014</dd>
			<dd class=""title"">
				<img src=""http://fi.somethingawful.com/safs/titles/c4/e5/00208335.0001.png"" alt="""" class=""img"" border=""0""><br />
A Boy and His Parasite<br>
				<br class=""pb"">
			</dd>
		</dl>
	</td>
	<td class=""postbody"">
		<!-- BeginContentMarker -->
		<!-- google_ad_section_start -->
		<span class=""bbc-spoiler""><img src=""http://i.imgur.com/4lwcfQP.png"" alt="""" class=""img"" border=""0""></span>
		<!-- google_ad_section_end -->
		<!-- EndContentMarker -->


		<p class=""editedby"">
	</td>
</tr>
<tr class=""seen2"">
	<td class=""postdate"">
		<a class=""lastseen_icon"" href=""/showthread.php?action=setseen&amp;threadid=3570170&amp;index=8832"" title=""Mark all replies as read to this point""><img src=""http://fi.somethingawful.com/style/posticon-seen.gif"" alt="""" border=""0""></a>
		<a href=""#post427248359"" title=""Link to this post"">#</a>
		<a class=""user_jump"" title=""Show posts by this user"" href=""/showthread.php?threadid=3570170&amp;userid=208335"">?</a>
		Mar 21, 2014 07:02
	</td>
	<td class=""postlinks"">
		<ul class=""profilelinks"">
			<li><a href=""member.php?action=getinfo&amp;userid=208335"">Profile</a></li>
			<li><a href=""search.php?action=do_search_posthistory&amp;userid=208335"">Post History</a></li>
		</ul>
		<ul class=""postbuttons"">

			
			<li class=""alertbutton""><a href=""modalert.php?postid=427248359&amp;username=Franz+von+Dada""><img src=""http://forumimages.somethingawful.com/images/button-report.gif"" border=""0"" alt=""Alert Moderators""></a>&nbsp;&nbsp;</li>
			
			<li><a href=""newreply.php?action=newreply&amp;postid=427248359""><img src=""http://fi.somethingawful.com/images/sa-quote.gif"" alt=""Quote""  title=""""></a></li>


		</ul>
	</td>
</tr>
</table><table class=""post "" id=""post427247348"" data-idx=""8831"">
<tr  class=""seen1"" id=""pti32"">
	<td class=""userinfo userid-162230"">
		<dl class=""userinfo"">
			<dt class=""author"" title="""">Zeruel</dt>
			<dd class=""registered"">Mar 27, 2010</dd>
			<dd class=""title"">
				<div class=""bbc-center""><img src=""http://fi.somethingawful.com/safs/titles/60/d8/00162230.0003.gif"" alt="""" class=""img"" border=""0""><br />
now hang me up to dry<br />
you wrung me out<br />
too too too many times</div><br>
				<br class=""pb"">
			</dd>
		</dl>
	</td>
	<td class=""postbody"">
		<!-- BeginContentMarker -->
		<!-- google_ad_section_start -->
		Oh god I don't think I could deal with <span class=""bbc-spoiler"">Senketsu kicking the bucket. I don't want any of the main characters to die!!</span>
		<!-- google_ad_section_end -->
		<!-- EndContentMarker -->


		<p class=""editedby"">
	</td>
</tr>
<tr class=""seen1"">
	<td class=""postdate"">
		<a class=""lastseen_icon"" href=""/showthread.php?action=setseen&amp;threadid=3570170&amp;index=8831"" title=""Mark all replies as read to this point""><img src=""http://fi.somethingawful.com/style/posticon-seen.gif"" alt="""" border=""0""></a>
		<a href=""#post427247348"" title=""Link to this post"">#</a>
		<a class=""user_jump"" title=""Show posts by this user"" href=""/showthread.php?threadid=3570170&amp;userid=162230"">?</a>
		Mar 21, 2014 06:13
	</td>
	<td class=""postlinks"">
		<ul class=""profilelinks"">
			<li><a href=""member.php?action=getinfo&amp;userid=162230"">Profile</a></li>
			<li><a href=""private.php?action=newmessage&amp;userid=162230"">Message</a></li>
			<li><a href=""search.php?action=do_search_posthistory&amp;userid=162230"">Post History</a></li>
		</ul>
		<ul class=""postbuttons"">

			
			<li class=""alertbutton""><a href=""modalert.php?postid=427247348&amp;username=Zeruel""><img src=""http://forumimages.somethingawful.com/images/button-report.gif"" border=""0"" alt=""Alert Moderators""></a>&nbsp;&nbsp;</li>
			
			<li><a href=""newreply.php?action=newreply&amp;postid=427247348""><img src=""http://fi.somethingawful.com/images/sa-quote.gif"" alt=""Quote""  title=""""></a></li>


		</ul>
	</td>
</tr>
</table><table class=""post "" id=""post427247343"" data-idx=""8830"">
<tr  class=""seen2"" id=""pti33"">
	<td class=""userinfo userid-172842"">
		<dl class=""userinfo"">
			<dt class=""author"" title="""">YF-23</dt>
			<dd class=""registered"">Feb 17, 2011</dd>
			<dd class=""title"">
				<div class=""bbc-center""><img src=""http://fi.somethingawful.com/safs/titles/a2/1b/00172842.0001.gif"" alt="""" class=""img"" border=""0""><br />
The few witnesses would report seeing only a boy with amazing wings, gently falling from the day's sky. <br />
<br />
 No one ever saw him again.</div><br>
				<br class=""pb"">
			</dd>
		</dl>
	</td>
	<td class=""postbody"">
		<!-- BeginContentMarker -->
		<!-- google_ad_section_start -->
		<div class=""bbc-block""><h4><a class=""quote_link"" href=""/showthread.php?goto=post&postid=427246650#post427246650"" rel=""nofollow"">Kanos posted:</a></h4><blockquote>
People keep talking about <span class=""bbc-spoiler"">Ryuuko being the one to fade away in a Nia-type scenario, but everyone's forgetting that Senketsu is 100% life fibers while Ryuuko is part human. If anyone's going to poof it'll probably be him.</span><br />
</blockquote></div>

<br />
I'll contest that on account of <span class=""bbc-spoiler"">Senketsu being Ryuko's sunday best.</span>
		<!-- google_ad_section_end -->
		<!-- EndContentMarker -->


		<p class=""editedby"">
	</td>
</tr>
<tr class=""seen2"">
	<td class=""postdate"">
		<a class=""lastseen_icon"" href=""/showthread.php?action=setseen&amp;threadid=3570170&amp;index=8830"" title=""Mark all replies as read to this point""><img src=""http://fi.somethingawful.com/style/posticon-seen.gif"" alt="""" border=""0""></a>
		<a href=""#post427247343"" title=""Link to this post"">#</a>
		<a class=""user_jump"" title=""Show posts by this user"" href=""/showthread.php?threadid=3570170&amp;userid=172842"">?</a>
		Mar 21, 2014 06:13
	</td>
	<td class=""postlinks"">
		<ul class=""profilelinks"">
			<li><a href=""member.php?action=getinfo&amp;userid=172842"">Profile</a></li>
			<li><a href=""search.php?action=do_search_posthistory&amp;userid=172842"">Post History</a></li>
		</ul>
		<ul class=""postbuttons"">

			
			<li class=""alertbutton""><a href=""modalert.php?postid=427247343&amp;username=YF-23""><img src=""http://forumimages.somethingawful.com/images/button-report.gif"" border=""0"" alt=""Alert Moderators""></a>&nbsp;&nbsp;</li>
			
			<li><a href=""newreply.php?action=newreply&amp;postid=427247343""><img src=""http://fi.somethingawful.com/images/sa-quote.gif"" alt=""Quote""  title=""""></a></li>


		</ul>
	</td>
</tr>
</table><table class=""post "" id=""post427247098"" data-idx=""8829"">
<tr  class=""seen1"" id=""pti34"">
	<td class=""userinfo userid-116171"">
		<dl class=""userinfo"">
			<dt class=""author"" title="""">Aleksei Vasiliev</dt>
			<dd class=""registered"">May  7, 2007</dd>
			<dd class=""title"">
				<img src=""http://fi.somethingawful.com/safs/titles/da/88/00116171.0007.jpg"" alt="""" class=""img"" border=""0""><br />
Fuck the cowboys. Unf. Fuck em hard.<br>
				<br class=""pb"">
			</dd>
		</dl>
	</td>
	<td class=""postbody"">
		<!-- BeginContentMarker -->
		<!-- google_ad_section_start -->
		<div class=""bbc-block""><h4><a class=""quote_link"" href=""/showthread.php?goto=post&postid=427246650#post427246650"" rel=""nofollow"">Kanos posted:</a></h4><blockquote>
People keep talking about <span class=""bbc-spoiler"">Ryuuko being the one to fade away in a Nia-type scenario, but everyone's forgetting that Senketsu is 100% life fibers while Ryuuko is part human. If anyone's going to poof it'll probably be him.</span><br />
</blockquote></div>
 Yeah, <span class=""bbc-spoiler"">Ryuuko will obviously have a long drawn out dying scene, not just a poof-she's-gone.</span><br />
I hope none of the protagonists get killed.
		<!-- google_ad_section_end -->
		<!-- EndContentMarker -->


		<p class=""editedby"">
	</td>
</tr>
<tr class=""seen1"">
	<td class=""postdate"">
		<a class=""lastseen_icon"" href=""/showthread.php?action=setseen&amp;threadid=3570170&amp;index=8829"" title=""Mark all replies as read to this point""><img src=""http://fi.somethingawful.com/style/posticon-seen.gif"" alt="""" border=""0""></a>
		<a href=""#post427247098"" title=""Link to this post"">#</a>
		<a class=""user_jump"" title=""Show posts by this user"" href=""/showthread.php?threadid=3570170&amp;userid=116171"">?</a>
		Mar 21, 2014 06:00
	</td>
	<td class=""postlinks"">
		<ul class=""profilelinks"">
			<li><a href=""member.php?action=getinfo&amp;userid=116171"">Profile</a></li>
			<li><a href=""private.php?action=newmessage&amp;userid=116171"">Message</a></li>
			<li><a href=""search.php?action=do_search_posthistory&amp;userid=116171"">Post History</a></li>
		</ul>
		<ul class=""postbuttons"">

			
			<li class=""alertbutton""><a href=""modalert.php?postid=427247098&amp;username=Aleksei+Vasiliev""><img src=""http://forumimages.somethingawful.com/images/button-report.gif"" border=""0"" alt=""Alert Moderators""></a>&nbsp;&nbsp;</li>
			
			<li><a href=""newreply.php?action=newreply&amp;postid=427247098""><img src=""http://fi.somethingawful.com/images/sa-quote.gif"" alt=""Quote""  title=""""></a></li>


		</ul>
	</td>
</tr>
</table><table class=""post "" id=""post427247042"" data-idx=""8828"">
<tr  class=""seen2"" id=""pti35"">
	<td class=""userinfo userid-78387"">
		<dl class=""userinfo"">
			<dt class=""author"" title="""">AlternateNu</dt>
			<dd class=""registered"">May  4, 2005</dd>
			<dd class=""title"">
				<div class=""bbc-center""><img src=""http://fi.somethingawful.com/safs/titles/d1/30/00078387.0003.gif"" alt="""" class=""img"" border=""0""><br />
<b>The Many Masks of Master Motivator Mankanshoku Mako</b> <img src=""http://i.somethingawful.com/forumsystem/emoticons/emot-swoon.gif"" border=""0"" alt="""" title="":swoon:""></div><br>
				<br class=""pb"">
			</dd>
		</dl>
	</td>
	<td class=""postbody"">
		<!-- BeginContentMarker -->
		<!-- google_ad_section_start -->
		I flipped when the Elite 4 finally <span class=""bbc-spoiler"">called out their animal spirit counterparts for their combo attack</span>. They truly are the 4 Devas.
		<!-- google_ad_section_end -->
		<!-- EndContentMarker -->


		<p class=""editedby"">
	</td>
</tr>
<tr class=""seen2"">
	<td class=""postdate"">
		<a class=""lastseen_icon"" href=""/showthread.php?action=setseen&amp;threadid=3570170&amp;index=8828"" title=""Mark all replies as read to this point""><img src=""http://fi.somethingawful.com/style/posticon-seen.gif"" alt="""" border=""0""></a>
		<a href=""#post427247042"" title=""Link to this post"">#</a>
		<a class=""user_jump"" title=""Show posts by this user"" href=""/showthread.php?threadid=3570170&amp;userid=78387"">?</a>
		Mar 21, 2014 05:56
	</td>
	<td class=""postlinks"">
		<ul class=""profilelinks"">
			<li><a href=""member.php?action=getinfo&amp;userid=78387"">Profile</a></li>
			<li><a href=""private.php?action=newmessage&amp;userid=78387"">Message</a></li>
			<li><a href=""search.php?action=do_search_posthistory&amp;userid=78387"">Post History</a></li>
		</ul>
		<ul class=""postbuttons"">

			
			<li class=""alertbutton""><a href=""modalert.php?postid=427247042&amp;username=AlternateNu""><img src=""http://forumimages.somethingawful.com/images/button-report.gif"" border=""0"" alt=""Alert Moderators""></a>&nbsp;&nbsp;</li>
			
			<li><a href=""newreply.php?action=newreply&amp;postid=427247042""><img src=""http://fi.somethingawful.com/images/sa-quote.gif"" alt=""Quote""  title=""""></a></li>


		</ul>
	</td>
</tr>
</table><table class=""post "" id=""post427246730"" data-idx=""8827"">
<tr  class=""seen1"" id=""pti36"">
	<td class=""userinfo userid-143051"">
		<dl class=""userinfo"">
			<dt class=""author"" title="""">snucks</dt>
			<dd class=""registered"">Nov  2, 2008</dd>
			<dd class=""title"">
				<div class=""bbc-center""><img src=""http://fi.somethingawful.com/safs/titles/2b/3d/00143051.0001.gif"" alt="""" class=""img"" border=""0""><br />
Try again. Fail again. Fail better.</div><br>
				<br class=""pb"">
			</dd>
		</dl>
	</td>
	<td class=""postbody"">
		<!-- BeginContentMarker -->
		<!-- google_ad_section_start -->
		holy shit so many good moments. nonstop good moment train.<br />
<br />
<div class=""bbc-block""><h4><a class=""quote_link"" href=""/showthread.php?goto=post&postid=427243831#post427243831"" rel=""nofollow"">Kaiser Mazoku posted:</a></h4><blockquote>
Sanagayama <span class=""bbc-spoiler"">wasn't blind after all, huh.</span><br />
</blockquote></div>

<span class=""bbc-spoiler"">When Ragyo severed his life fiber, it ended up not being his uniform's banshi but the thread used to sew his eyes shut. Since no damage was ever actually done to his eyes, viola!</span>
		<!-- google_ad_section_end -->
		<!-- EndContentMarker -->


		<p class=""editedby""><span>snucks fucked around with this message at Mar 21, 2014 around 05:39</span>
	</td>
</tr>
<tr class=""seen1"">
	<td class=""postdate"">
		<a class=""lastseen_icon"" href=""/showthread.php?action=setseen&amp;threadid=3570170&amp;index=8827"" title=""Mark all replies as read to this point""><img src=""http://fi.somethingawful.com/style/posticon-seen.gif"" alt="""" border=""0""></a>
		<a href=""#post427246730"" title=""Link to this post"">#</a>
		<a class=""user_jump"" title=""Show posts by this user"" href=""/showthread.php?threadid=3570170&amp;userid=143051"">?</a>
		Mar 21, 2014 05:35
	</td>
	<td class=""postlinks"">
		<ul class=""profilelinks"">
			<li><a href=""member.php?action=getinfo&amp;userid=143051"">Profile</a></li>
			<li><a href=""private.php?action=newmessage&amp;userid=143051"">Message</a></li>
			<li><a href=""search.php?action=do_search_posthistory&amp;userid=143051"">Post History</a></li>
		</ul>
		<ul class=""postbuttons"">

			
			<li class=""alertbutton""><a href=""modalert.php?postid=427246730&amp;username=snucks""><img src=""http://forumimages.somethingawful.com/images/button-report.gif"" border=""0"" alt=""Alert Moderators""></a>&nbsp;&nbsp;</li>
			
			<li><a href=""newreply.php?action=newreply&amp;postid=427246730""><img src=""http://fi.somethingawful.com/images/sa-quote.gif"" alt=""Quote""  title=""""></a></li>


		</ul>
	</td>
</tr>
</table><table class=""post "" id=""post427246650"" data-idx=""8826"">
<tr  class=""seen2"" id=""pti37"">
	<td class=""userinfo userid-102865"">
		<dl class=""userinfo"">
			<dt class=""author"" title="""">Kanos</dt>
			<dd class=""registered"">Sep  5, 2006</dd>
			<dd class=""title"">
				<div class=""bbc-center""><img src=""http://fi.somethingawful.com/safs/titles/c4/75/00102865.0001.jpg"" alt="""" class=""img"" border=""0""><br />
Salarymen can protect the peace too!</div><br>
				<br class=""pb"">
			</dd>
		</dl>
	</td>
	<td class=""postbody"">
		<!-- BeginContentMarker -->
		<!-- google_ad_section_start -->
		People keep talking about <span class=""bbc-spoiler"">Ryuuko being the one to fade away in a Nia-type scenario, but everyone's forgetting that Senketsu is 100% life fibers while Ryuuko is part human. If anyone's going to poof it'll probably be him.</span>
		<!-- google_ad_section_end -->
		<!-- EndContentMarker -->


		<p class=""editedby"">
	</td>
</tr>
<tr class=""seen2"">
	<td class=""postdate"">
		<a class=""lastseen_icon"" href=""/showthread.php?action=setseen&amp;threadid=3570170&amp;index=8826"" title=""Mark all replies as read to this point""><img src=""http://fi.somethingawful.com/style/posticon-seen.gif"" alt="""" border=""0""></a>
		<a href=""#post427246650"" title=""Link to this post"">#</a>
		<a class=""user_jump"" title=""Show posts by this user"" href=""/showthread.php?threadid=3570170&amp;userid=102865"">?</a>
		Mar 21, 2014 05:29
	</td>
	<td class=""postlinks"">
		<ul class=""profilelinks"">
			<li><a href=""member.php?action=getinfo&amp;userid=102865"">Profile</a></li>
			<li><a href=""search.php?action=do_search_posthistory&amp;userid=102865"">Post History</a></li>
		</ul>
		<ul class=""postbuttons"">

			
			<li class=""alertbutton""><a href=""modalert.php?postid=427246650&amp;username=Kanos""><img src=""http://forumimages.somethingawful.com/images/button-report.gif"" border=""0"" alt=""Alert Moderators""></a>&nbsp;&nbsp;</li>
			
			<li><a href=""newreply.php?action=newreply&amp;postid=427246650""><img src=""http://fi.somethingawful.com/images/sa-quote.gif"" alt=""Quote""  title=""""></a></li>


		</ul>
	</td>
</tr>
</table><table class=""post "" id=""post427246070"" data-idx=""8825"">
<tr  class=""seen1"" id=""pti38"">
	<td class=""userinfo userid-185274"">
		<dl class=""userinfo"">
			<dt class=""author"" title="""">Hommando</dt>
			<dd class=""registered"">Mar  1, 2012</dd>
			<dd class=""title"">
				<br>
				<br class=""pb"">
			</dd>
		</dl>
	</td>
	<td class=""postbody"">
		<!-- BeginContentMarker -->
		<!-- google_ad_section_start -->
		<div class=""bbc-block""><h4><a class=""quote_link"" href=""/showthread.php?goto=post&postid=427245966#post427245966"" rel=""nofollow"">JosephWongKS posted:</a></h4><blockquote>
<span class=""bbc-spoiler"">""We do not go to our deaths.  We will return here alive and enjoy another cup of this tea.  Right, Soroi?""  <img src=""http://i.somethingawful.com/forumsystem/emoticons/emot-ohdear.png"" border=""0"" alt="""" title="":ohdear:""><br />
<br />
I guess Satsuki's the one to Nia out and give us the ""bittersweet ending"".  It's been good knowing you, Bright Light Eyebrows Lady.</span><br />
</blockquote></div>

<br />
<span class=""bbc-spoiler"">Yeah, she tripped some serious death flags by saying that.</span><br />
<br />
Next episode predictions: <span class=""bbc-spoiler"">All of the main cast, except for Mako and her family, kick it. Mako is put in charge of Honnouji Academy and becomes the new light bringing leader who motives through passionate speeches.</span><br />
<br />
Alternately: <span class=""bbc-spoiler"">With the defeat of the original life fiber, all other fibers die off / cease to exist and Ryuuko fades away with them. There's a couple lines in the second ED that imply Mako is lonely and misses someone. Maybe the ED takes place after the events of the final episode and is about Mako dreaming about her time spent with Ryuuko.</span>
		<!-- google_ad_section_end -->
		<!-- EndContentMarker -->


		<p class=""editedby""><span>Hommando fucked around with this message at Mar 21, 2014 around 05:11</span>
	</td>
</tr>
<tr class=""seen1"">
	<td class=""postdate"">
		<a class=""lastseen_icon"" href=""/showthread.php?action=setseen&amp;threadid=3570170&amp;index=8825"" title=""Mark all replies as read to this point""><img src=""http://fi.somethingawful.com/style/posticon-seen.gif"" alt="""" border=""0""></a>
		<a href=""#post427246070"" title=""Link to this post"">#</a>
		<a class=""user_jump"" title=""Show posts by this user"" href=""/showthread.php?threadid=3570170&amp;userid=185274"">?</a>
		Mar 21, 2014 04:39
	</td>
	<td class=""postlinks"">
		<ul class=""profilelinks"">
			<li><a href=""member.php?action=getinfo&amp;userid=185274"">Profile</a></li>
			<li><a href=""private.php?action=newmessage&amp;userid=185274"">Message</a></li>
			<li><a href=""search.php?action=do_search_posthistory&amp;userid=185274"">Post History</a></li>
		</ul>
		<ul class=""postbuttons"">

			
			<li class=""alertbutton""><a href=""modalert.php?postid=427246070&amp;username=Hommando""><img src=""http://forumimages.somethingawful.com/images/button-report.gif"" border=""0"" alt=""Alert Moderators""></a>&nbsp;&nbsp;</li>
			
			<li><a href=""newreply.php?action=newreply&amp;postid=427246070""><img src=""http://fi.somethingawful.com/images/sa-quote.gif"" alt=""Quote""  title=""""></a></li>


		</ul>
	</td>
</tr>
</table><table class=""post "" id=""post427245966"" data-idx=""8824"">
<tr  class=""seen2"" id=""pti39"">
	<td class=""userinfo userid-149567"">
		<dl class=""userinfo"">
			<dt class=""author"" title="""">JosephWongKS</dt>
			<dd class=""registered"">Apr  4, 2009</dd>
			<dd class=""title"">
				<img src=""http://fi.somethingawful.com/safs/titles/d2/fa/00149567.0003.png"" alt="""" class=""img"" border=""0""><br />
I hate this book and I hate Railrunner and I hate Thunderbark and I hate Black Magic and I hate everything they stand for.<br>
				<br class=""pb"">
			</dd>
		</dl>
	</td>
	<td class=""postbody"">
		<!-- BeginContentMarker -->
		<!-- google_ad_section_start -->
		<span class=""bbc-spoiler"">""We do not go to our deaths.  We will return here alive and enjoy another cup of this tea.  Right, Soroi?""  <img src=""http://i.somethingawful.com/forumsystem/emoticons/emot-ohdear.png"" border=""0"" alt="""" title="":ohdear:""><br />
<br />
I guess Satsuki's the one to Nia out and give us the ""bittersweet ending"".  It's been good knowing you, Bright Light Eyebrows Lady.</span>
		<!-- google_ad_section_end -->
		<!-- EndContentMarker -->


		<p class=""editedby""><span>JosephWongKS fucked around with this message at Mar 21, 2014 around 04:37</span>
	</td>
</tr>
<tr class=""seen2"">
	<td class=""postdate"">
		<a class=""lastseen_icon"" href=""/showthread.php?action=setseen&amp;threadid=3570170&amp;index=8824"" title=""Mark all replies as read to this point""><img src=""http://fi.somethingawful.com/style/posticon-seen.gif"" alt="""" border=""0""></a>
		<a href=""#post427245966"" title=""Link to this post"">#</a>
		<a class=""user_jump"" title=""Show posts by this user"" href=""/showthread.php?threadid=3570170&amp;userid=149567"">?</a>
		Mar 21, 2014 04:31
	</td>
	<td class=""postlinks"">
		<ul class=""profilelinks"">
			<li><a href=""member.php?action=getinfo&amp;userid=149567"">Profile</a></li>
			<li><a href=""private.php?action=newmessage&amp;userid=149567"">Message</a></li>
			<li><a href=""search.php?action=do_search_posthistory&amp;userid=149567"">Post History</a></li>
		</ul>
		<ul class=""postbuttons"">

			
			<li class=""alertbutton""><a href=""modalert.php?postid=427245966&amp;username=JosephWongKS""><img src=""http://forumimages.somethingawful.com/images/button-report.gif"" border=""0"" alt=""Alert Moderators""></a>&nbsp;&nbsp;</li>
			
			<li><a href=""newreply.php?action=newreply&amp;postid=427245966""><img src=""http://fi.somethingawful.com/images/sa-quote.gif"" alt=""Quote""  title=""""></a></li>


		</ul>
	</td>
</tr>
</table><table class=""post "" id=""post427245721"" data-idx=""8823"">
<tr  class=""seen1"" id=""pti40"">
	<td class=""userinfo userid-182274"" id=""lastpost"">
		<dl class=""userinfo"">
			<dt class=""author"" title="""">KaneTW</dt>
			<dd class=""registered"">Dec  2, 2011</dd>
			<dd class=""title"">
				<div class=""bbc-center""><img src=""http://fi.somethingawful.com/safs/titles/f3/6f/00182274.0002.gif"" alt="""" class=""img"" border=""0""><br />
Jones killed Solaire! How could she.<br />
<br />
<img src=""http://fi.somethingawful.com/safs/titles/f3/6f/00182274.0001.gif"" alt="""" class=""img"" border=""0""></div><br>
				<br class=""pb"">
			</dd>
		</dl>
	</td>
	<td class=""postbody"">
		<!-- BeginContentMarker -->
		<!-- google_ad_section_start -->
		24 with an OVA in the last BD release.
		<!-- google_ad_section_end -->
		<!-- EndContentMarker -->


		<p class=""editedby"">
	</td>
</tr>
<tr class=""seen1"">
	<td class=""postdate"">
		<a class=""lastseen_icon"" href=""/showthread.php?action=setseen&amp;threadid=3570170&amp;index=8823"" title=""Mark all replies as read to this point""><img src=""http://fi.somethingawful.com/style/posticon-seen.gif"" alt="""" border=""0""></a>
		<a href=""#post427245721"" title=""Link to this post"">#</a>
		<a class=""user_jump"" title=""Show posts by this user"" href=""/showthread.php?threadid=3570170&amp;userid=182274"">?</a>
		Mar 21, 2014 04:11
	</td>
	<td class=""postlinks"">
		<ul class=""profilelinks"">
			<li><a href=""member.php?action=getinfo&amp;userid=182274"">Profile</a></li>
			<li><a href=""private.php?action=newmessage&amp;userid=182274"">Message</a></li>
			<li><a href=""search.php?action=do_search_posthistory&amp;userid=182274"">Post History</a></li>
		</ul>
		<ul class=""postbuttons"">

			
			<li class=""alertbutton""><a href=""modalert.php?postid=427245721&amp;username=KaneTW""><img src=""http://forumimages.somethingawful.com/images/button-report.gif"" border=""0"" alt=""Alert Moderators""></a>&nbsp;&nbsp;</li>
			
			<li><a href=""newreply.php?action=newreply&amp;postid=427245721""><img src=""http://fi.somethingawful.com/images/sa-quote.gif"" alt=""Quote""  title=""""></a></li>


		</ul>
	</td>
</tr>
</table>
</div>

</form>

</div><!-- #content -->
	<ul class=""navigation"">
<li class=""first""><a href=""/index.php"">SA Forums</a></li>
<li>- <a href=""http://www.somethingawful.com/"">Something Awful</a></li>
<li>- <a href=""/f/search"">Search the Forums</a></li>
<li>- <a href=""/usercp.php"">User Control Panel</a></li>
<li>- <a href=""/private.php"">Private Messages</a></li>
<li>- <a href=""http://www.somethingawful.com/d/forum-rules/forum-rules.php"">Forum Rules</a></li>
<li>- <a href=""/dictionary.php"">SAclopedia</a></li>
<li>- <a href=""/stats.php"">Posting Gloryhole</a></li>
<li>- <a href=""/banlist.php"">Leper's Colony</a></li>
<li>- <a href=""/supportmail.php"">Support</a></li>
<li>- <a href=""/account.php?action=logout&amp;ma=10293618"">Log Out</a></li>

</ul>
	<div id=""copyright"">
		Powered by: vBulletin Version 2.2.9 (<a href=""/CHANGES"">SAVB-v2.1.17</a>)<br>
		Copyright &copy;2000, 2001, Jelsoft Enterprises Limited.<br>
		Copyright &copy;2012, Something Awful LLC<br>
	</div>

</div><!-- #container -->

<script type=""text/javascript"">
	// quantcast
	_qoptions = { qacct:""p-82vTvmw-enlng"" };

	try {
		if(document.location.hostname != 'forums.somethingawful.com')
			throw undefined;

		$(document).ready(function() {
			var qcUrl = 'http://edge.quantserve.com/quant.js';
			jQuery.getScript(qcUrl);

			var gaJsHost = ((""https:"" == document.location.protocol) ? ""https://ssl."" : ""http://www."");
			var gaUrl = gaJsHost + 'google-analytics.com/ga.js';
			jQuery.getScript(gaUrl, function() {
				var pageTracker = _gat._getTracker(""UA-3064978-2"");
				pageTracker._initData();
				pageTracker._trackPageview();
			});
		});
	} catch(e) {};

	// indie
	// try {
	// 	if(document.location.hostname != 'forums.somethingawful.com')
	// 		throw undefined;

	// 	$(document).ready(function() {
	// 		var ic_element = document.createElement('script');
	// 		ic_element.type = 'text/javascript';
	// 		ic_element.async = true;
	// 		ic_element.id = 'ic_annonymous_pixel';
	// 		ic_element.src = 'http://pixel.indieclick.com/annonymous/domain/somethingawful.com/reach/script_ic.js';
	// 		var ic_script = document.getElementsByTagName('script')[0];
	// 		ic_script.parentNode.insertBefore(ic_element, ic_script);
	// 	});
	// } catch(e) {};
</script>
<noscript><img src=""http://pixel.quantserve.com/pixel/p-82vTvmw-enlng.gif"" style=""display:none;"" border=""0"" height=""1"" width=""1"" alt=""Quantcast""></noscript>

<!-- PLEASE DO NOT REMOVE -->
<ol id=""debug"" style=""display:none""><li>&nbsp;</ol>

</body>
</html>";
        }
        public virtual string GenerateMockBookmarksHtml()
        {
            return @"<!DOCTYPE html>
<html>
<head>
	<title>Bookmarked threads - The Something Awful Forums</title>
	
	<meta name=""MSSmartTagsPreventParsing"" content=""TRUE"">
	<meta http-equiv=""X-UA-Compatible"" content=""chrome=1"">
	<!--[if lt IE 7]><link rel=""stylesheet"" type=""text/css"" href=""/css/ie.css?1348360344""><![endif]-->
	<!--[if lt IE 8]><link rel=""stylesheet"" type=""text/css"" href=""/css/ie7.css?1348360344""><![endif]-->
	<link rel=""apple-touch-icon"" href=""http://i.somethingawful.com/core/icon/iphone-touch/forums.png"">
	<link rel=""stylesheet"" type=""text/css"" href=""/css/main.css?1359594161"">
	<link rel=""stylesheet"" type=""text/css"" href=""/css/bbcode.css?1348360344"">
	<link rel=""stylesheet"" type=""text/css"" href=""http://www.somethingawful.com/globalcss/globalmenu.css"">

	

	<!-- <script src=""/__utm.js"" type=""text/javascript""></script> -->
	<!-- script src=""/js/dojo/dojo.js?1348360344"" type=""text/javascript""></script -->
	<script type=""text/javascript"" src=""//ajax.googleapis.com/ajax/libs/jquery/1.8.3/jquery.min.js""></script>
	<link rel=""stylesheet"" type=""text/css"" href=""//ajax.googleapis.com/ajax/libs/jqueryui/1.9.2/themes/redmond/jquery-ui.css"">
	<script type=""text/javascript"" src=""//ajax.googleapis.com/ajax/libs/jqueryui/1.9.2/jquery-ui.min.js""></script>

	<link rel=""stylesheet"" type=""text/css"" href=""http://www.somethingawful.com/css/forums.css?7"">

	

	<script type=""text/javascript"">
		
		
		
		
	</script>

	<script type=""text/javascript"" src=""/js/vb/forums.combined.js?1359653372""></script>

	

	<!-- ts-specific includes -->
	
	
	

	

	

	
	<style type=""text/css"">
		a.pagenumber { font-size:10px; }
		div.pages { display:block; margin:8px 0; }
		div.standard { margin-top:0; }
	</style>
	<script type=""text/javascript"">
		// dojo.addOnLoad( function() {
		// 	bm_stars.init();
		// 	bookmarks_mui.add_buttons_button();
		// } );
	</script>

	<style type=""text/css"">
		table#forum tbody tr.thread td.star { display:none; }
		table#forum thead tr th.star { display:none; }
	</style>

</head>
<body id=""something_awful"" class=""bookmark_threads"">

<div id=""globalmenu"">
	<ul>
		<li class=""first""><a href=""https://secure.somethingawful.com/"">Buy Forum Stuff</a></li>
		<li><a href=""http://www.somethingawful.com/"">Something Awful</a></li>
	</ul>
</div>



<div id=""container"">



	

	<ul id=""nav_purchase"">
		<li><b>Purchase:</b></li>
		<li><a href=""https://secure.somethingawful.com/products/register.php"">Account</a></li>
		<li>- <a href=""https://secure.somethingawful.com/products/platinum.php"">Platinum Upgrade</a></li>
		<li>- <a href=""https://secure.somethingawful.com/products/titlechange.php"">New Avatar</a></li>
		<li>- <a href=""https://secure.somethingawful.com/products/titlechange.php"">Other's Avatar</a></li>
		<li>- <a href=""https://secure.somethingawful.com/products/archives.php"">Archives</a></li>
		<li>- <a href=""https://secure.somethingawful.com/products/noads.php"">No-Ads</a></li>
		<li>- <a href=""https://secure.somethingawful.com/products/namechange.php"">New Username</a></li>
		<li>- <a href=""https://secure.somethingawful.com/products/ad-banner.php"">Banner Advertisement</a></li>
		<li>- <a href=""https://secure.somethingawful.com/products/smilie.php"">Smilie</a></li>
		<li>- <a href=""https://secure.somethingawful.com/products/sticky-thread.php"">Stick Thread</a></li>
		<li>- <a href=""https://secure.somethingawful.com/products/gift-certificate.php"">Gift Cert.</a></li>
	</ul>

	<ul id=""navigation"" class=""navigation"">
<li class=""first""><a href=""/index.php"">SA Forums</a></li>
<li>- <a href=""http://www.somethingawful.com/"">Something Awful</a></li>
<li>- <a href=""/f/search"">Search the Forums</a></li>
<li>- <a href=""/usercp.php"">User Control Panel</a></li>
<li>- <a href=""/private.php"">Private Messages</a></li>
<li>- <a href=""http://www.somethingawful.com/d/forum-rules/forum-rules.php"">Forum Rules</a></li>
<li>- <a href=""/dictionary.php"">SAclopedia</a></li>
<li>- <a href=""/stats.php"">Posting Gloryhole</a></li>
<li>- <a href=""/banlist.php"">Leper's Colony</a></li>
<li>- <a href=""/supportmail.php"">Support</a></li>
<li>- <a href=""/account.php?action=logout&amp;ma=10293618"">Log Out</a></li>

</ul>


<div class=""oma_pal"">
	<!--  Begin Rubicon Project Tag -->
<!--  Site: Something Awful LLC   Zone: Forum ATF Top Quality - Mobile, Pop, Web   Size: Leaderboard  -->
<!--  PLACEMENT: Above the Fold  -->
<script language=""JavaScript"" type=""text/javascript"">
rp_account   = '8539';
rp_site      = '13831';
rp_zonesize  = '80354-2';
rp_adtype    = 'iframe';
rp_width     = '728';
rp_height    = '90';
rp_smartfile = 'http://www.somethingawful.com/revv_smart_file.html';
</script>
<script type=""text/javascript"" src=""https://ads.rubiconproject.com/ad/8539.js""></script>
<!--  End Rubicon Project Tag -->
</div>





	<div id=""content"">

	

<div class=""breadcrumbs""><b><a href=""index.php"">The Something Awful Forums</a> &gt; Bookmarked Threads</b></div>


	<ul id=""usercpnav"">
		<li><a href=""usercp.php"">User CP Home</a></li>
		<li><a href=""member.php?action=accountfeatures"">Account Features</a></li>
		<li><a href=""private.php"">Private Messages</a></li>
		<li><a href=""bookmarkthreads.php"">Bookmarked Threads</a></li>
		<li><a href=""member.php?action=editprofile"">Edit Profile</a></li>
		<li><a href=""member.php?action=editoptions"">Edit Options</a></li>
		<li><a href=""account.php?action=editpassword"">Change Password</a></li>
		<li><a href=""member2.php?action=viewlist&amp;userlist=buddy"">Edit Buddy List</a></li>
		<li><a href=""member2.php?action=viewlist&amp;userlist=ignore"">Edit Ignore List</a></li>
	</ul>

<form method=""POST"" action=""/bookmarkthreads.php"" name=""bookmarks"">

<div class=""pages""></div>

<table id=""forum"" summary=""Threads"" class=""threadlist "">
	<caption>Threads</caption>
	<thead>
	<tr>
		<th class=""star"">&nbsp;</th>
		<th class=""icon"">Icon</th>
		<th class=""title"">Title (Pages)</th>
		<th class=""author"">Author</th>
		<th class=""replies""><abbr title=""Replies"">Re</abbr></th>
		<th class=""views"">Views</th>
		<th class=""rate"">Rating</th>
		<th class=""lastpost""><a href=""bookmarkthreads.php?pagenumber=1&amp;perpage=40&amp;sortorder=desc&amp;sortfield=lastpost"">Killed By</a> </th>
	</tr>
	</thead>
	<tbody>
		
		<tr class=""thread seen category0"" id=""thread3534323"">
	<td class=""star bm0""></td>
	<td class=""icon""><a href=""/forumdisplay.php?forumid=0&amp;posticon=123""><img src=""http://fi.somethingawful.com/forums/posticons/icons-08/science.png#123"" alt=""""></a></td>
	<td class=""title"">
		<div class=""title_inner"">
			<div class=""lastseen""><a href=""/showthread.php?action=resetseen&amp;threadid=3534323"" class=""x"" title=""Mark as unread"">X</a><a title=""Jump to last read post"" href=""/showthread.php?threadid=3534323&amp;goto=newpost"" class=""count""><b>42</b></a></div>
			<div class=""info"">
				<a href=""showthread.php?threadid=3534323"" class=""thread_title"">Wildstar</a>
				<div class=""title_pages"">Pages: <a class=""pagenumber"" href=""showthread.php?threadid=3534323&amp;pagenumber=1"">1</a><a class=""pagenumber"" href=""showthread.php?threadid=3534323&amp;pagenumber=2"">2</a><a class=""pagenumber"" href=""showthread.php?threadid=3534323&amp;pagenumber=3"">3</a><a class=""pagenumber"" href=""showthread.php?threadid=3534323&amp;pagenumber=4"">4</a><a class=""pagenumber"" href=""showthread.php?threadid=3534323&amp;pagenumber=5"">5</a><a class=""pagenumber"" href=""showthread.php?threadid=3534323&amp;pagenumber=6"">6</a><a class=""pagenumber"" href=""showthread.php?threadid=3534323&amp;pagenumber=7"">7</a>... <a class=""pagenumber"" href=""showthread.php?threadid=3534323&amp;goto=lastpost"">Last</a></div>
			</div>
		</div>
	</td>
	<td class=""author""><a href=""member.php?action=getinfo&amp;userid=147746"">Teerack</a></td>
	<td class=""replies"">9385</td>
	<td class=""views"">569297</td>
	<td class=""rating""><img src=""http://fi.somethingawful.com/rate/default/4stars.gif"" alt="""" title=""88 votes - 3.56 average""></td>
	<td class=""lastpost""><div class=""date"">16:39 Mar 21, 2014</div><a class=""author"" href=""showthread.php?goto=lastpost&amp;threadid=3534323"">MuffinMan</a></td>
</tr><tr class=""thread seen category0"" id=""thread3444891"">
	<td class=""star bm0""></td>
	<td class=""icon""><a href=""/forumdisplay.php?forumid=0&amp;posticon=624""><img src=""http://fi.somethingawful.com/forums/posticons/cps-android.gif#624"" alt=""""></a></td>
	<td class=""title"">
		<div class=""title_inner"">
			<div class=""lastseen""><a href=""/showthread.php?action=resetseen&amp;threadid=3444891"" class=""x"" title=""Mark as unread"">X</a><a title=""Jump to last read post"" href=""/showthread.php?threadid=3444891&amp;goto=newpost"" class=""count""><b>22</b></a></div>
			<div class=""info"">
				<a href=""showthread.php?threadid=3444891"" class=""thread_title"">Android App Thread: Grimbo revival thread</a>
				<div class=""title_pages"">Pages: <a class=""pagenumber"" href=""showthread.php?threadid=3444891&amp;pagenumber=1"">1</a><a class=""pagenumber"" href=""showthread.php?threadid=3444891&amp;pagenumber=2"">2</a><a class=""pagenumber"" href=""showthread.php?threadid=3444891&amp;pagenumber=3"">3</a><a class=""pagenumber"" href=""showthread.php?threadid=3444891&amp;pagenumber=4"">4</a><a class=""pagenumber"" href=""showthread.php?threadid=3444891&amp;pagenumber=5"">5</a><a class=""pagenumber"" href=""showthread.php?threadid=3444891&amp;pagenumber=6"">6</a><a class=""pagenumber"" href=""showthread.php?threadid=3444891&amp;pagenumber=7"">7</a>... <a class=""pagenumber"" href=""showthread.php?threadid=3444891&amp;goto=lastpost"">Last</a></div>
			</div>
		</div>
	</td>
	<td class=""author""><a href=""member.php?action=getinfo&amp;userid=144139"">sleepwalkers</a></td>
	<td class=""replies"">20395</td>
	<td class=""views"">1421951</td>
	<td class=""rating""><img src=""http://fi.somethingawful.com/rate/default/4stars.gif"" alt="""" title=""30 votes - 4.35 average""></td>
	<td class=""lastpost""><div class=""date"">16:22 Mar 21, 2014</div><a class=""author"" href=""showthread.php?goto=lastpost&amp;threadid=3444891"">f#a#</a></td>
</tr><tr class=""thread seen category0"" id=""thread3442155"">
	<td class=""star bm0""></td>
	<td class=""icon""><a href=""/forumdisplay.php?forumid=0&amp;posticon=692""><img src=""http://fi.somethingawful.com/forums/posticons/dd-9-11.gif#692"" alt=""""></a></td>
	<td class=""title"">
		<div class=""title_inner"">
			<div class=""lastseen""><a href=""/showthread.php?action=resetseen&amp;threadid=3442155"" class=""x"" title=""Mark as unread"">X</a><a title=""Jump to last read post"" href=""/showthread.php?threadid=3442155&amp;goto=newpost"" class=""count""><b>6025</b></a></div>
			<div class=""info"">
				<a href=""showthread.php?threadid=3442155"" class=""thread_title"">Netflix Streaming: Getting Your Seven Bucks Worth</a>
				<div class=""title_pages"">Pages: <a class=""pagenumber"" href=""showthread.php?threadid=3442155&amp;pagenumber=1"">1</a><a class=""pagenumber"" href=""showthread.php?threadid=3442155&amp;pagenumber=2"">2</a><a class=""pagenumber"" href=""showthread.php?threadid=3442155&amp;pagenumber=3"">3</a><a class=""pagenumber"" href=""showthread.php?threadid=3442155&amp;pagenumber=4"">4</a><a class=""pagenumber"" href=""showthread.php?threadid=3442155&amp;pagenumber=5"">5</a><a class=""pagenumber"" href=""showthread.php?threadid=3442155&amp;pagenumber=6"">6</a><a class=""pagenumber"" href=""showthread.php?threadid=3442155&amp;pagenumber=7"">7</a>... <a class=""pagenumber"" href=""showthread.php?threadid=3442155&amp;goto=lastpost"">Last</a></div>
			</div>
		</div>
	</td>
	<td class=""author""><a href=""member.php?action=getinfo&amp;userid=124304"">HUNDU THE BEAST GOD</a></td>
	<td class=""replies"">14985</td>
	<td class=""views"">1482397</td>
	<td class=""rating""><img src=""http://fi.somethingawful.com/rate/default/4stars.gif"" alt="""" title=""68 votes - 4.03 average""></td>
	<td class=""lastpost""><div class=""date"">16:19 Mar 21, 2014</div><a class=""author"" href=""showthread.php?goto=lastpost&amp;threadid=3442155"">The_Raven</a></td>
</tr><tr class=""thread seen category0"" id=""thread3570170"">
	<td class=""star bm0""></td>
	<td class=""icon""><a href=""/forumdisplay.php?forumid=0&amp;posticon=183""><img src=""http://fi.somethingawful.com/forums/posticons/guns-ohshi.gif#183"" alt=""""></a></td>
	<td class=""title"">
		<div class=""title_inner"">
			<div class=""lastseen""><a href=""/showthread.php?action=resetseen&amp;threadid=3570170"" class=""x"" title=""Mark as unread"">X</a></div>
			<div class=""info"">
				<a href=""showthread.php?threadid=3570170"" class=""thread_title"">KILL LA KILL</a>
				<div class=""title_pages"">Pages: <a class=""pagenumber"" href=""showthread.php?threadid=3570170&amp;pagenumber=1"">1</a><a class=""pagenumber"" href=""showthread.php?threadid=3570170&amp;pagenumber=2"">2</a><a class=""pagenumber"" href=""showthread.php?threadid=3570170&amp;pagenumber=3"">3</a><a class=""pagenumber"" href=""showthread.php?threadid=3570170&amp;pagenumber=4"">4</a><a class=""pagenumber"" href=""showthread.php?threadid=3570170&amp;pagenumber=5"">5</a><a class=""pagenumber"" href=""showthread.php?threadid=3570170&amp;pagenumber=6"">6</a><a class=""pagenumber"" href=""showthread.php?threadid=3570170&amp;pagenumber=7"">7</a>... <a class=""pagenumber"" href=""showthread.php?threadid=3570170&amp;goto=lastpost"">Last</a></div>
			</div>
		</div>
	</td>
	<td class=""author""><a href=""member.php?action=getinfo&amp;userid=87037"">Zorak</a></td>
	<td class=""replies"">8861</td>
	<td class=""views"">864679</td>
	<td class=""rating""><img src=""http://fi.somethingawful.com/rate/default/4stars.gif"" alt="""" title=""173 votes - 3.58 average""></td>
	<td class=""lastpost""><div class=""date"">15:46 Mar 21, 2014</div><a class=""author"" href=""showthread.php?goto=lastpost&amp;threadid=3570170"">icantfindaname</a></td>
</tr><tr class=""thread seen category0"" id=""thread3460814"">
	<td class=""star bm0""></td>
	<td class=""icon""><a href=""/forumdisplay.php?forumid=0&amp;posticon=142""><img src=""http://fi.somethingawful.com/forums/posticons/shsc-win.gif#142"" alt=""""></a></td>
	<td class=""title"">
		<div class=""title_inner"">
			<div class=""lastseen""><a href=""/showthread.php?action=resetseen&amp;threadid=3460814"" class=""x"" title=""Mark as unread"">X</a></div>
			<div class=""info"">
				<a href=""showthread.php?threadid=3460814"" class=""thread_title"">Awful Forum Reader for Windows Phone</a>
				<div class=""title_pages"">Pages: <a class=""pagenumber"" href=""showthread.php?threadid=3460814&amp;pagenumber=1"">1</a><a class=""pagenumber"" href=""showthread.php?threadid=3460814&amp;pagenumber=2"">2</a><a class=""pagenumber"" href=""showthread.php?threadid=3460814&amp;pagenumber=3"">3</a><a class=""pagenumber"" href=""showthread.php?threadid=3460814&amp;pagenumber=4"">4</a><a class=""pagenumber"" href=""showthread.php?threadid=3460814&amp;pagenumber=5"">5</a><a class=""pagenumber"" href=""showthread.php?threadid=3460814&amp;pagenumber=6"">6</a><a class=""pagenumber"" href=""showthread.php?threadid=3460814&amp;pagenumber=7"">7</a>... <a class=""pagenumber"" href=""showthread.php?threadid=3460814&amp;goto=lastpost"">Last</a></div>
			</div>
		</div>
	</td>
	<td class=""author""><a href=""member.php?action=getinfo&amp;userid=70611"">bootleg robot</a></td>
	<td class=""replies"">1193</td>
	<td class=""views"">72331</td>
	<td class=""rating"">&nbsp;</td>
	<td class=""lastpost""><div class=""date"">15:11 Mar 21, 2014</div><a class=""author"" href=""showthread.php?goto=lastpost&amp;threadid=3460814"">bootleg robot</a></td>
</tr><tr class=""thread seen category0"" id=""thread3514718"">
	<td class=""star bm0""></td>
	<td class=""icon""><a href=""/forumdisplay.php?forumid=0&amp;posticon=142""><img src=""http://fi.somethingawful.com/forums/posticons/shsc-win.gif#142"" alt=""""></a></td>
	<td class=""title"">
		<div class=""title_inner"">
			<div class=""lastseen""><a href=""/showthread.php?action=resetseen&amp;threadid=3514718"" class=""x"" title=""Mark as unread"">X</a></div>
			<div class=""info"">
				<a href=""showthread.php?threadid=3514718"" class=""thread_title"">The Windows Phone thread</a>
				<div class=""title_pages"">Pages: <a class=""pagenumber"" href=""showthread.php?threadid=3514718&amp;pagenumber=1"">1</a><a class=""pagenumber"" href=""showthread.php?threadid=3514718&amp;pagenumber=2"">2</a><a class=""pagenumber"" href=""showthread.php?threadid=3514718&amp;pagenumber=3"">3</a><a class=""pagenumber"" href=""showthread.php?threadid=3514718&amp;pagenumber=4"">4</a><a class=""pagenumber"" href=""showthread.php?threadid=3514718&amp;pagenumber=5"">5</a><a class=""pagenumber"" href=""showthread.php?threadid=3514718&amp;pagenumber=6"">6</a><a class=""pagenumber"" href=""showthread.php?threadid=3514718&amp;pagenumber=7"">7</a>... <a class=""pagenumber"" href=""showthread.php?threadid=3514718&amp;goto=lastpost"">Last</a></div>
			</div>
		</div>
	</td>
	<td class=""author""><a href=""member.php?action=getinfo&amp;userid=14546"">Maneki Neko</a></td>
	<td class=""replies"">4443</td>
	<td class=""views"">242064</td>
	<td class=""rating"">&nbsp;</td>
	<td class=""lastpost""><div class=""date"">11:57 Mar 21, 2014</div><a class=""author"" href=""showthread.php?goto=lastpost&amp;threadid=3514718"">Happy_Misanthrope</a></td>
</tr><tr class=""thread seen category0"" id=""thread3113983"">
	<td class=""star bm0""></td>
	<td class=""icon""><a href=""/forumdisplay.php?forumid=0&amp;posticon=167""><img src=""http://fi.somethingawful.com/forums/posticons/shsc-code.gif#167"" alt=""""></a></td>
	<td class=""title"">
		<div class=""title_inner"">
			<div class=""lastseen""><a href=""/showthread.php?action=resetseen&amp;threadid=3113983"" class=""x"" title=""Mark as unread"">X</a><a title=""Jump to last read post"" href=""/showthread.php?threadid=3113983&amp;goto=newpost"" class=""count""><b>2</b></a></div>
			<div class=""info"">
				<a href=""showthread.php?threadid=3113983"" class=""thread_title"">Version Control Questions Megathread (SVN / git / whatever else)</a>
				<div class=""title_pages"">Pages: <a class=""pagenumber"" href=""showthread.php?threadid=3113983&amp;pagenumber=1"">1</a><a class=""pagenumber"" href=""showthread.php?threadid=3113983&amp;pagenumber=2"">2</a><a class=""pagenumber"" href=""showthread.php?threadid=3113983&amp;pagenumber=3"">3</a><a class=""pagenumber"" href=""showthread.php?threadid=3113983&amp;pagenumber=4"">4</a><a class=""pagenumber"" href=""showthread.php?threadid=3113983&amp;pagenumber=5"">5</a><a class=""pagenumber"" href=""showthread.php?threadid=3113983&amp;pagenumber=6"">6</a><a class=""pagenumber"" href=""showthread.php?threadid=3113983&amp;pagenumber=7"">7</a>... <a class=""pagenumber"" href=""showthread.php?threadid=3113983&amp;goto=lastpost"">Last</a></div>
			</div>
		</div>
	</td>
	<td class=""author""><a href=""member.php?action=getinfo&amp;userid=46080"">sonic bed head</a></td>
	<td class=""replies"">2352</td>
	<td class=""views"">171193</td>
	<td class=""rating"">&nbsp;</td>
	<td class=""lastpost""><div class=""date"">10:44 Mar 21, 2014</div><a class=""author"" href=""showthread.php?goto=lastpost&amp;threadid=3113983"">ManoliIsFat</a></td>
</tr><tr class=""thread seen category2"" id=""thread2262300"">
	<td class=""star bm2""></td>
	<td class=""icon""><a href=""/forumdisplay.php?forumid=0&amp;posticon=142""><img src=""http://fi.somethingawful.com/forums/posticons/shsc-win.gif#142"" alt=""""></a></td>
	<td class=""title"">
		<div class=""title_inner"">
			<div class=""lastseen""><a href=""/showthread.php?action=resetseen&amp;threadid=2262300"" class=""x"" title=""Mark as unread"">X</a><a title=""Jump to last read post"" href=""/showthread.php?threadid=2262300&amp;goto=newpost"" class=""count""><b>904</b></a></div>
			<div class=""info"">
				<a href=""showthread.php?threadid=2262300"" class=""thread_title"">.Net Questions Megathread Part 2</a>
				<div class=""title_pages"">Pages: <a class=""pagenumber"" href=""showthread.php?threadid=2262300&amp;pagenumber=1"">1</a><a class=""pagenumber"" href=""showthread.php?threadid=2262300&amp;pagenumber=2"">2</a><a class=""pagenumber"" href=""showthread.php?threadid=2262300&amp;pagenumber=3"">3</a><a class=""pagenumber"" href=""showthread.php?threadid=2262300&amp;pagenumber=4"">4</a><a class=""pagenumber"" href=""showthread.php?threadid=2262300&amp;pagenumber=5"">5</a><a class=""pagenumber"" href=""showthread.php?threadid=2262300&amp;pagenumber=6"">6</a><a class=""pagenumber"" href=""showthread.php?threadid=2262300&amp;pagenumber=7"">7</a>... <a class=""pagenumber"" href=""showthread.php?threadid=2262300&amp;goto=lastpost"">Last</a></div>
			</div>
		</div>
	</td>
	<td class=""author""><a href=""member.php?action=getinfo&amp;userid=29146"">Fastbreak</a></td>
	<td class=""replies"">17023</td>
	<td class=""views"">677225</td>
	<td class=""rating""><img src=""http://fi.somethingawful.com/rate/default/5stars.gif"" alt="""" title=""35 votes - 4.67 average""></td>
	<td class=""lastpost""><div class=""date"">09:55 Mar 21, 2014</div><a class=""author"" href=""showthread.php?goto=lastpost&amp;threadid=2262300"">clayburn</a></td>
</tr><tr class=""thread seen category0"" id=""thread3565204"">
	<td class=""star bm0""></td>
	<td class=""icon""><a href=""/forumdisplay.php?forumid=0&amp;posticon=192""><img src=""http://fi.somethingawful.com/forums/posticons/tviv-cartoon.gif#192"" alt=""""></a></td>
	<td class=""title"">
		<div class=""title_inner"">
			<div class=""lastseen""><a href=""/showthread.php?action=resetseen&amp;threadid=3565204"" class=""x"" title=""Mark as unread"">X</a></div>
			<div class=""info"">
				<a href=""showthread.php?threadid=3565204"" class=""thread_title"">Adventure Time: Wanna Meet That Dad (Season 6 Starts in April)</a>
				<div class=""title_pages"">Pages: <a class=""pagenumber"" href=""showthread.php?threadid=3565204&amp;pagenumber=1"">1</a><a class=""pagenumber"" href=""showthread.php?threadid=3565204&amp;pagenumber=2"">2</a><a class=""pagenumber"" href=""showthread.php?threadid=3565204&amp;pagenumber=3"">3</a><a class=""pagenumber"" href=""showthread.php?threadid=3565204&amp;pagenumber=4"">4</a><a class=""pagenumber"" href=""showthread.php?threadid=3565204&amp;pagenumber=5"">5</a><a class=""pagenumber"" href=""showthread.php?threadid=3565204&amp;pagenumber=6"">6</a><a class=""pagenumber"" href=""showthread.php?threadid=3565204&amp;pagenumber=7"">7</a>... <a class=""pagenumber"" href=""showthread.php?threadid=3565204&amp;goto=lastpost"">Last</a></div>
			</div>
		</div>
	</td>
	<td class=""author""><a href=""member.php?action=getinfo&amp;userid=104642"">axleblaze</a></td>
	<td class=""replies"">5036</td>
	<td class=""views"">426052</td>
	<td class=""rating""><img src=""http://fi.somethingawful.com/rate/default/4stars.gif"" alt="""" title=""53 votes - 3.7 average""></td>
	<td class=""lastpost""><div class=""date"">06:11 Mar 21, 2014</div><a class=""author"" href=""showthread.php?goto=lastpost&amp;threadid=3565204"">Sudo Echo</a></td>
</tr><tr class=""thread seen category0"" id=""thread3577512"">
	<td class=""star bm0""></td>
	<td class=""icon""><a href=""/forumdisplay.php?forumid=0&amp;posticon=192""><img src=""http://fi.somethingawful.com/forums/posticons/tviv-cartoon.gif#192"" alt=""""></a></td>
	<td class=""title"">
		<div class=""title_inner"">
			<div class=""lastseen""><a href=""/showthread.php?action=resetseen&amp;threadid=3577512"" class=""x"" title=""Mark as unread"">X</a></div>
			<div class=""info"">
				<a href=""showthread.php?threadid=3577512"" class=""thread_title"">Steven Universe - Believe in Steven</a>
				<div class=""title_pages"">Pages: <a class=""pagenumber"" href=""showthread.php?threadid=3577512&amp;pagenumber=1"">1</a><a class=""pagenumber"" href=""showthread.php?threadid=3577512&amp;pagenumber=2"">2</a><a class=""pagenumber"" href=""showthread.php?threadid=3577512&amp;pagenumber=3"">3</a><a class=""pagenumber"" href=""showthread.php?threadid=3577512&amp;pagenumber=4"">4</a><a class=""pagenumber"" href=""showthread.php?threadid=3577512&amp;pagenumber=5"">5</a><a class=""pagenumber"" href=""showthread.php?threadid=3577512&amp;pagenumber=6"">6</a><a class=""pagenumber"" href=""showthread.php?threadid=3577512&amp;pagenumber=7"">7</a>... <a class=""pagenumber"" href=""showthread.php?threadid=3577512&amp;goto=lastpost"">Last</a></div>
			</div>
		</div>
	</td>
	<td class=""author""><a href=""member.php?action=getinfo&amp;userid=171864"">Waffleman_</a></td>
	<td class=""replies"">826</td>
	<td class=""views"">59803</td>
	<td class=""rating"">&nbsp;</td>
	<td class=""lastpost""><div class=""date"">01:36 Mar 21, 2014</div><a class=""author"" href=""showthread.php?goto=lastpost&amp;threadid=3577512"">KungFu Grip</a></td>
</tr><tr class=""thread seen category0"" id=""thread3256838"">
	<td class=""star bm0""></td>
	<td class=""icon""><a href=""/forumdisplay.php?forumid=0&amp;posticon=169""><img src=""http://fi.somethingawful.com/forums/posticons/cc-critique.png#169"" alt=""""></a></td>
	<td class=""title title_sticky"">
		<div class=""title_inner"">
			<div class=""lastseen""><a href=""/showthread.php?action=resetseen&amp;threadid=3256838"" class=""x"" title=""Mark as unread"">X</a><a title=""Jump to last read post"" href=""/showthread.php?threadid=3256838&amp;goto=newpost"" class=""count""><b>1255</b></a></div>
			<div class=""info"">
				<a href=""showthread.php?threadid=3256838"" class=""thread_title"">Newbie Personal Finance: Probably you should ask in the investing/retirement thread</a>
				<div class=""title_pages"">Pages: <a class=""pagenumber"" href=""showthread.php?threadid=3256838&amp;pagenumber=1"">1</a><a class=""pagenumber"" href=""showthread.php?threadid=3256838&amp;pagenumber=2"">2</a><a class=""pagenumber"" href=""showthread.php?threadid=3256838&amp;pagenumber=3"">3</a><a class=""pagenumber"" href=""showthread.php?threadid=3256838&amp;pagenumber=4"">4</a><a class=""pagenumber"" href=""showthread.php?threadid=3256838&amp;pagenumber=5"">5</a><a class=""pagenumber"" href=""showthread.php?threadid=3256838&amp;pagenumber=6"">6</a><a class=""pagenumber"" href=""showthread.php?threadid=3256838&amp;pagenumber=7"">7</a>... <a class=""pagenumber"" href=""showthread.php?threadid=3256838&amp;goto=lastpost"">Last</a></div>
			</div>
		</div>
	</td>
	<td class=""author""><a href=""member.php?action=getinfo&amp;userid=80237"">moana</a></td>
	<td class=""replies"">8095</td>
	<td class=""views"">539793</td>
	<td class=""rating"">&nbsp;</td>
	<td class=""lastpost""><div class=""date"">00:50 Mar 21, 2014</div><a class=""author"" href=""showthread.php?goto=lastpost&amp;threadid=3256838"">semicolonsrock</a></td>
</tr><tr class=""thread seen category0"" id=""thread3532200"">
	<td class=""star bm0""></td>
	<td class=""icon""><a href=""/forumdisplay.php?forumid=0&amp;posticon=434""><img src=""http://fi.somethingawful.com/forums/posticons/sadev-bugs.gif#434"" alt=""""></a></td>
	<td class=""title"">
		<div class=""title_inner"">
			<div class=""lastseen""><a href=""/showthread.php?action=resetseen&amp;threadid=3532200"" class=""x"" title=""Mark as unread"">X</a></div>
			<div class=""info"">
				<a href=""showthread.php?threadid=3532200"" class=""thread_title"">[TEST] The Post Test Thread</a>
				<div class=""title_pages"">Pages: <a class=""pagenumber"" href=""showthread.php?threadid=3532200&amp;pagenumber=1"">1</a><a class=""pagenumber"" href=""showthread.php?threadid=3532200&amp;pagenumber=2"">2</a><a class=""pagenumber"" href=""showthread.php?threadid=3532200&amp;pagenumber=3"">3</a><a class=""pagenumber"" href=""showthread.php?threadid=3532200&amp;pagenumber=4"">4</a><a class=""pagenumber"" href=""showthread.php?threadid=3532200&amp;pagenumber=5"">5</a><a class=""pagenumber"" href=""showthread.php?threadid=3532200&amp;pagenumber=6"">6</a></div>
			</div>
		</div>
	</td>
	<td class=""author""><a href=""member.php?action=getinfo&amp;userid=70611"">bootleg robot</a></td>
	<td class=""replies"">214</td>
	<td class=""views"">2344</td>
	<td class=""rating"">&nbsp;</td>
	<td class=""lastpost""><div class=""date"">09:47 Mar 20, 2014</div><a class=""author"" href=""showthread.php?goto=lastpost&amp;threadid=3532200"">Uncomfortable Gaze</a></td>
</tr><tr class=""thread seen category0"" id=""thread3570685"">
	<td class=""star bm0""></td>
	<td class=""icon""><a href=""/forumdisplay.php?forumid=0&amp;posticon=198""><img src=""http://fi.somethingawful.com/forums/posticons/bss-new.gif#198"" alt=""""></a></td>
	<td class=""title"">
		<div class=""title_inner"">
			<div class=""lastseen""><a href=""/showthread.php?action=resetseen&amp;threadid=3570685"" class=""x"" title=""Mark as unread"">X</a></div>
			<div class=""info"">
				<a href=""showthread.php?threadid=3570685"" class=""thread_title"">New Girl: &quot;Walk with dignity you giant toddler!&quot;</a>
				<div class=""title_pages"">Pages: <a class=""pagenumber"" href=""showthread.php?threadid=3570685&amp;pagenumber=1"">1</a><a class=""pagenumber"" href=""showthread.php?threadid=3570685&amp;pagenumber=2"">2</a><a class=""pagenumber"" href=""showthread.php?threadid=3570685&amp;pagenumber=3"">3</a><a class=""pagenumber"" href=""showthread.php?threadid=3570685&amp;pagenumber=4"">4</a><a class=""pagenumber"" href=""showthread.php?threadid=3570685&amp;pagenumber=5"">5</a><a class=""pagenumber"" href=""showthread.php?threadid=3570685&amp;pagenumber=6"">6</a><a class=""pagenumber"" href=""showthread.php?threadid=3570685&amp;pagenumber=7"">7</a>... <a class=""pagenumber"" href=""showthread.php?threadid=3570685&amp;goto=lastpost"">Last</a></div>
			</div>
		</div>
	</td>
	<td class=""author""><a href=""member.php?action=getinfo&amp;userid=152397"">Josh Lyman</a></td>
	<td class=""replies"">946</td>
	<td class=""views"">61180</td>
	<td class=""rating"">&nbsp;</td>
	<td class=""lastpost""><div class=""date"">15:28 Mar 19, 2014</div><a class=""author"" href=""showthread.php?goto=lastpost&amp;threadid=3570685"">Twee as Fuck</a></td>
</tr><tr class=""thread seen category0"" id=""thread3566624"">
	<td class=""star bm0""></td>
	<td class=""icon""><a href=""/forumdisplay.php?forumid=0&amp;posticon=349""><img src=""http://fi.somethingawful.com/forums/posticons/cd_action.gif#349"" alt=""""></a></td>
	<td class=""title"">
		<div class=""title_inner"">
			<div class=""lastseen""><a href=""/showthread.php?action=resetseen&amp;threadid=3566624"" class=""x"" title=""Mark as unread"">X</a></div>
			<div class=""info"">
				<a href=""showthread.php?threadid=3566624"" class=""thread_title"">UQ Holder: Akamatsu decides Negima is only kind of sort of over.</a>
				<div class=""title_pages"">Pages: <a class=""pagenumber"" href=""showthread.php?threadid=3566624&amp;pagenumber=1"">1</a><a class=""pagenumber"" href=""showthread.php?threadid=3566624&amp;pagenumber=2"">2</a><a class=""pagenumber"" href=""showthread.php?threadid=3566624&amp;pagenumber=3"">3</a><a class=""pagenumber"" href=""showthread.php?threadid=3566624&amp;pagenumber=4"">4</a><a class=""pagenumber"" href=""showthread.php?threadid=3566624&amp;pagenumber=5"">5</a><a class=""pagenumber"" href=""showthread.php?threadid=3566624&amp;pagenumber=6"">6</a><a class=""pagenumber"" href=""showthread.php?threadid=3566624&amp;pagenumber=7"">7</a>... <a class=""pagenumber"" href=""showthread.php?threadid=3566624&amp;goto=lastpost"">Last</a></div>
			</div>
		</div>
	</td>
	<td class=""author""><a href=""member.php?action=getinfo&amp;userid=194088"">PerrineClostermann</a></td>
	<td class=""replies"">595</td>
	<td class=""views"">44562</td>
	<td class=""rating"">&nbsp;</td>
	<td class=""lastpost""><div class=""date"">09:20 Mar 19, 2014</div><a class=""author"" href=""showthread.php?goto=lastpost&amp;threadid=3566624"">Serious Frolicking</a></td>
</tr><tr class=""thread seen category0"" id=""thread3509959"">
	<td class=""star bm0""></td>
	<td class=""icon""><a href=""/forumdisplay.php?forumid=0&amp;posticon=192""><img src=""http://fi.somethingawful.com/forums/posticons/tviv-cartoon.gif#192"" alt=""""></a></td>
	<td class=""title"">
		<div class=""title_inner"">
			<div class=""lastseen""><a href=""/showthread.php?action=resetseen&amp;threadid=3509959"" class=""x"" title=""Mark as unread"">X</a></div>
			<div class=""info"">
				<a href=""showthread.php?threadid=3509959"" class=""thread_title"">Teenage Mutant Ninja Turtles 2k12: Heroes in a Half Shell!</a>
				<div class=""title_pages"">Pages: <a class=""pagenumber"" href=""showthread.php?threadid=3509959&amp;pagenumber=1"">1</a><a class=""pagenumber"" href=""showthread.php?threadid=3509959&amp;pagenumber=2"">2</a><a class=""pagenumber"" href=""showthread.php?threadid=3509959&amp;pagenumber=3"">3</a><a class=""pagenumber"" href=""showthread.php?threadid=3509959&amp;pagenumber=4"">4</a><a class=""pagenumber"" href=""showthread.php?threadid=3509959&amp;pagenumber=5"">5</a><a class=""pagenumber"" href=""showthread.php?threadid=3509959&amp;pagenumber=6"">6</a><a class=""pagenumber"" href=""showthread.php?threadid=3509959&amp;pagenumber=7"">7</a>... <a class=""pagenumber"" href=""showthread.php?threadid=3509959&amp;goto=lastpost"">Last</a></div>
			</div>
		</div>
	</td>
	<td class=""author""><a href=""member.php?action=getinfo&amp;userid=117703"">appletonoutcast</a></td>
	<td class=""replies"">705</td>
	<td class=""views"">49704</td>
	<td class=""rating"">&nbsp;</td>
	<td class=""lastpost""><div class=""date"">14:59 Mar 18, 2014</div><a class=""author"" href=""showthread.php?goto=lastpost&amp;threadid=3509959"">MrBigglesworth</a></td>
</tr><tr class=""thread seen category0"" id=""thread3514014"">
	<td class=""star bm0""></td>
	<td class=""icon""><a href=""/forumdisplay.php?forumid=0&amp;posticon=142""><img src=""http://fi.somethingawful.com/forums/posticons/shsc-win.gif#142"" alt=""""></a></td>
	<td class=""title"">
		<div class=""title_inner"">
			<div class=""lastseen""><a href=""/showthread.php?action=resetseen&amp;threadid=3514014"" class=""x"" title=""Mark as unread"">X</a></div>
			<div class=""info"">
				<a href=""showthread.php?threadid=3514014"" class=""thread_title"">Windows 8 UI Style A-- Who are we kidding? Windows 8 Metro App Thread</a>
				<div class=""title_pages"">Pages: <a class=""pagenumber"" href=""showthread.php?threadid=3514014&amp;pagenumber=1"">1</a><a class=""pagenumber"" href=""showthread.php?threadid=3514014&amp;pagenumber=2"">2</a><a class=""pagenumber"" href=""showthread.php?threadid=3514014&amp;pagenumber=3"">3</a><a class=""pagenumber"" href=""showthread.php?threadid=3514014&amp;pagenumber=4"">4</a><a class=""pagenumber"" href=""showthread.php?threadid=3514014&amp;pagenumber=5"">5</a><a class=""pagenumber"" href=""showthread.php?threadid=3514014&amp;pagenumber=6"">6</a><a class=""pagenumber"" href=""showthread.php?threadid=3514014&amp;pagenumber=7"">7</a>... <a class=""pagenumber"" href=""showthread.php?threadid=3514014&amp;goto=lastpost"">Last</a></div>
			</div>
		</div>
	</td>
	<td class=""author""><a href=""member.php?action=getinfo&amp;userid=104800"">Kazy</a></td>
	<td class=""replies"">465</td>
	<td class=""views"">38551</td>
	<td class=""rating"">&nbsp;</td>
	<td class=""lastpost""><div class=""date"">01:43 Mar 17, 2014</div><a class=""author"" href=""showthread.php?goto=lastpost&amp;threadid=3514014"">Stick100</a></td>
</tr><tr class=""thread seen category1"" id=""thread3521620"">
	<td class=""star bm1""></td>
	<td class=""icon""><a href=""/forumdisplay.php?forumid=0&amp;posticon=92""><img src=""http://fi.somethingawful.com/forums/posticons/icons-08/sex.png#92"" alt=""""></a></td>
	<td class=""title"">
		<div class=""title_inner"">
			<div class=""lastseen""><a href=""/showthread.php?action=resetseen&amp;threadid=3521620"" class=""x"" title=""Mark as unread"">X</a></div>
			<div class=""info"">
				<a href=""showthread.php?threadid=3521620"" class=""thread_title"">Cartoon Hangover Thread - Ain't No Party Like a Butter Lettuce Party</a>
				<div class=""title_pages"">Pages: <a class=""pagenumber"" href=""showthread.php?threadid=3521620&amp;pagenumber=1"">1</a><a class=""pagenumber"" href=""showthread.php?threadid=3521620&amp;pagenumber=2"">2</a><a class=""pagenumber"" href=""showthread.php?threadid=3521620&amp;pagenumber=3"">3</a><a class=""pagenumber"" href=""showthread.php?threadid=3521620&amp;pagenumber=4"">4</a><a class=""pagenumber"" href=""showthread.php?threadid=3521620&amp;pagenumber=5"">5</a><a class=""pagenumber"" href=""showthread.php?threadid=3521620&amp;pagenumber=6"">6</a><a class=""pagenumber"" href=""showthread.php?threadid=3521620&amp;pagenumber=7"">7</a>... <a class=""pagenumber"" href=""showthread.php?threadid=3521620&amp;goto=lastpost"">Last</a></div>
			</div>
		</div>
	</td>
	<td class=""author""><a href=""member.php?action=getinfo&amp;userid=176004"">Lavender Philtrum</a></td>
	<td class=""replies"">289</td>
	<td class=""views"">25112</td>
	<td class=""rating"">&nbsp;</td>
	<td class=""lastpost""><div class=""date"">11:02 Mar 16, 2014</div><a class=""author"" href=""showthread.php?goto=lastpost&amp;threadid=3521620"">Evil Sagan</a></td>
</tr><tr class=""thread seen category0"" id=""thread3439197"">
	<td class=""star bm0""></td>
	<td class=""icon""><a href=""/forumdisplay.php?forumid=0&amp;posticon=142""><img src=""http://fi.somethingawful.com/forums/posticons/shsc-win.gif#142"" alt=""""></a></td>
	<td class=""title"">
		<div class=""title_inner"">
			<div class=""lastseen""><a href=""/showthread.php?action=resetseen&amp;threadid=3439197"" class=""x"" title=""Mark as unread"">X</a></div>
			<div class=""info"">
				<a href=""showthread.php?threadid=3439197"" class=""thread_title"">WINDOWS PHONE APP THRE: (yay metro)</a>
				<div class=""title_pages"">Pages: <a class=""pagenumber"" href=""showthread.php?threadid=3439197&amp;pagenumber=1"">1</a><a class=""pagenumber"" href=""showthread.php?threadid=3439197&amp;pagenumber=2"">2</a><a class=""pagenumber"" href=""showthread.php?threadid=3439197&amp;pagenumber=3"">3</a><a class=""pagenumber"" href=""showthread.php?threadid=3439197&amp;pagenumber=4"">4</a><a class=""pagenumber"" href=""showthread.php?threadid=3439197&amp;pagenumber=5"">5</a><a class=""pagenumber"" href=""showthread.php?threadid=3439197&amp;pagenumber=6"">6</a><a class=""pagenumber"" href=""showthread.php?threadid=3439197&amp;pagenumber=7"">7</a>... <a class=""pagenumber"" href=""showthread.php?threadid=3439197&amp;goto=lastpost"">Last</a></div>
			</div>
		</div>
	</td>
	<td class=""author""><a href=""member.php?action=getinfo&amp;userid=14546"">Maneki Neko</a></td>
	<td class=""replies"">838</td>
	<td class=""views"">76284</td>
	<td class=""rating"">&nbsp;</td>
	<td class=""lastpost""><div class=""date"">16:23 Mar  9, 2014</div><a class=""author"" href=""showthread.php?goto=lastpost&amp;threadid=3439197"">WattsvilleBlues</a></td>
</tr>
	</tbody>
</table>
<div class=""forumbar"">
	<ul class=""postbuttons""><li></li></ul>
</div>



<div class=""pages bottom"">

</div>

<div class=""pages""></div>

<!--
<input type=""hidden"" name=""action"" value=""massremove"">
<center><input type=""button"" value=""Unbookmark Checked Threads"" onclick=""document.bookmarks.submit()""></center>
</form>
-->

</div><!-- #content -->
	<ul class=""navigation"">
<li class=""first""><a href=""/index.php"">SA Forums</a></li>
<li>- <a href=""http://www.somethingawful.com/"">Something Awful</a></li>
<li>- <a href=""/f/search"">Search the Forums</a></li>
<li>- <a href=""/usercp.php"">User Control Panel</a></li>
<li>- <a href=""/private.php"">Private Messages</a></li>
<li>- <a href=""http://www.somethingawful.com/d/forum-rules/forum-rules.php"">Forum Rules</a></li>
<li>- <a href=""/dictionary.php"">SAclopedia</a></li>
<li>- <a href=""/stats.php"">Posting Gloryhole</a></li>
<li>- <a href=""/banlist.php"">Leper's Colony</a></li>
<li>- <a href=""/supportmail.php"">Support</a></li>
<li>- <a href=""/account.php?action=logout&amp;ma=10293618"">Log Out</a></li>

</ul>
	<div id=""copyright"">
		Powered by: vBulletin Version 2.2.9 (<a href=""/CHANGES"">SAVB-v2.1.17</a>)<br>
		Copyright &copy;2000, 2001, Jelsoft Enterprises Limited.<br>
		Copyright &copy;2012, Something Awful LLC<br>
	</div>

</div><!-- #container -->

<script type=""text/javascript"">
	// quantcast
	_qoptions = { qacct:""p-82vTvmw-enlng"" };

	try {
		if(document.location.hostname != 'forums.somethingawful.com')
			throw undefined;

		$(document).ready(function() {
			var qcUrl = 'http://edge.quantserve.com/quant.js';
			jQuery.getScript(qcUrl);

			var gaJsHost = ((""https:"" == document.location.protocol) ? ""https://ssl."" : ""http://www."");
			var gaUrl = gaJsHost + 'google-analytics.com/ga.js';
			jQuery.getScript(gaUrl, function() {
				var pageTracker = _gat._getTracker(""UA-3064978-2"");
				pageTracker._initData();
				pageTracker._trackPageview();
			});
		});
	} catch(e) {};

	// indie
	// try {
	// 	if(document.location.hostname != 'forums.somethingawful.com')
	// 		throw undefined;

	// 	$(document).ready(function() {
	// 		var ic_element = document.createElement('script');
	// 		ic_element.type = 'text/javascript';
	// 		ic_element.async = true;
	// 		ic_element.id = 'ic_annonymous_pixel';
	// 		ic_element.src = 'http://pixel.indieclick.com/annonymous/domain/somethingawful.com/reach/script_ic.js';
	// 		var ic_script = document.getElementsByTagName('script')[0];
	// 		ic_script.parentNode.insertBefore(ic_element, ic_script);
	// 	});
	// } catch(e) {};
</script>
<noscript><img src=""http://pixel.quantserve.com/pixel/p-82vTvmw-enlng.gif"" style=""display:none;"" border=""0"" height=""1"" width=""1"" alt=""Quantcast""></noscript>

<!-- PLEASE DO NOT REMOVE -->
<ol id=""debug"" style=""display:none""><li>&nbsp;</ol>

</body>
</html>";
        }
        public virtual string GenerateMockForumPageHtml()
        {
            return @"<!DOCTYPE html>
<html lang=""en"">
<head>
	<title>Debate Disco - The Something Awful Forums</title>
	
	<meta name=""MSSmartTagsPreventParsing"" content=""TRUE"">
	<meta http-equiv=""X-UA-Compatible"" content=""chrome=1"">
	<!--[if lt IE 7]><link rel=""stylesheet"" type=""text/css"" href=""/css/ie.css?1348360344""><![endif]-->
	<!--[if lt IE 8]><link rel=""stylesheet"" type=""text/css"" href=""/css/ie7.css?1348360344""><![endif]-->
	<link rel=""apple-touch-icon"" href=""http://i.somethingawful.com/core/icon/iphone-touch/forums.png"">
	<link rel=""stylesheet"" type=""text/css"" href=""/css/main.css?1359594161"">
	<link rel=""stylesheet"" type=""text/css"" href=""/css/bbcode.css?1348360344"">
	<link rel=""stylesheet"" type=""text/css"" href=""http://www.somethingawful.com/globalcss/globalmenu.css"">

	

	<!-- <script src=""/__utm.js"" type=""text/javascript""></script> -->
	<!-- script src=""/js/dojo/dojo.js?1348360344"" type=""text/javascript""></script -->
	<script type=""text/javascript"" src=""//ajax.googleapis.com/ajax/libs/jquery/1.8.3/jquery.min.js""></script>
	<link rel=""stylesheet"" type=""text/css"" href=""//ajax.googleapis.com/ajax/libs/jqueryui/1.9.2/themes/redmond/jquery-ui.css"">
	<script type=""text/javascript"" src=""//ajax.googleapis.com/ajax/libs/jqueryui/1.9.2/jquery-ui.min.js""></script>

	<link rel=""stylesheet"" type=""text/css"" href=""http://www.somethingawful.com/css/forums.css?7"">

	

	<script type=""text/javascript"">
		
		
		
		
	</script>

	<script type=""text/javascript"" src=""/js/vb/forums.combined.js?1359653372""></script>

	

	<!-- ts-specific includes -->
	
	
	

	

	

	

	<style type=""text/css"">
		table#forum tbody tr.thread td.star { display:none; }
		table#forum thead tr th.star { display:none; }
	</style>

</head>
<body id=""something_awful"" class=""forumdisplay forum_46"" data-forum=""46"">

<div id=""globalmenu"">
	<ul>
		<li class=""first""><a href=""https://secure.somethingawful.com/"">Buy Forum Stuff</a></li>
		<li><a href=""http://www.somethingawful.com/"">Something Awful</a></li>
	</ul>
</div>



<div id=""container"">



	

	<ul id=""nav_purchase"">
		<li><b>Purchase:</b></li>
		<li><a href=""https://secure.somethingawful.com/products/register.php"">Account</a></li>
		<li>- <a href=""https://secure.somethingawful.com/products/platinum.php"">Platinum Upgrade</a></li>
		<li>- <a href=""https://secure.somethingawful.com/products/titlechange.php"">New Avatar</a></li>
		<li>- <a href=""https://secure.somethingawful.com/products/titlechange.php"">Other's Avatar</a></li>
		<li>- <a href=""https://secure.somethingawful.com/products/archives.php"">Archives</a></li>
		<li>- <a href=""https://secure.somethingawful.com/products/noads.php"">No-Ads</a></li>
		<li>- <a href=""https://secure.somethingawful.com/products/namechange.php"">New Username</a></li>
		<li>- <a href=""https://secure.somethingawful.com/products/ad-banner.php"">Banner Advertisement</a></li>
		<li>- <a href=""https://secure.somethingawful.com/products/smilie.php"">Smilie</a></li>
		<li>- <a href=""https://secure.somethingawful.com/products/sticky-thread.php"">Stick Thread</a></li>
		<li>- <a href=""https://secure.somethingawful.com/products/gift-certificate.php"">Gift Cert.</a></li>
	</ul>

	<ul id=""navigation"" class=""navigation"">
<li class=""first""><a href=""/index.php"">SA Forums</a></li>
<li>- <a href=""http://www.somethingawful.com/"">Something Awful</a></li>
<li>- <a href=""/f/search"">Search the Forums</a></li>
<li>- <a href=""/usercp.php"">User Control Panel</a></li>
<li>- <a href=""/private.php"">Private Messages</a></li>
<li>- <a href=""http://www.somethingawful.com/d/forum-rules/forum-rules.php"">Forum Rules</a></li>
<li>- <a href=""/dictionary.php"">SAclopedia</a></li>
<li>- <a href=""/stats.php"">Posting Gloryhole</a></li>
<li>- <a href=""/banlist.php"">Leper's Colony</a></li>
<li>- <a href=""/supportmail.php"">Support</a></li>
<li>- <a href=""/account.php?action=logout&amp;ma=10293618"">Log Out</a></li>

</ul>


<div class=""oma_pal"">
	<!--  Begin Rubicon Project Tag -->
<!--  Site: Something Awful LLC   Zone: Forum ATF Top Quality - Mobile, Pop, Web   Size: Leaderboard  -->
<!--  PLACEMENT: Above the Fold  -->
<script language=""JavaScript"" type=""text/javascript"">
rp_account   = '8539';
rp_site      = '13831';
rp_zonesize  = '80354-2';
rp_adtype    = 'iframe';
rp_width     = '728';
rp_height    = '90';
rp_smartfile = 'http://www.somethingawful.com/revv_smart_file.html';
</script>
<script type=""text/javascript"" src=""https://ads.rubiconproject.com/ad/8539.js""></script>
<!--  End Rubicon Project Tag -->
</div>





	<div id=""content"">

	



<div class=""pages top""><span class=""disabled"">&laquo;</span><span class=""disabled"">&lsaquo;</span><select data-url=""forumdisplay.php?forumid=46&amp;daysprune=30&amp;perpage=40&amp;posticon=0&amp;sortorder=desc&amp;sortfield=lastpost""><option value=""1"" selected=""selected"">1</option><option value=""2"">2</option><option value=""3"">3</option><option value=""4"">4</option><option value=""5"">5</option></select><a href=""forumdisplay.php?forumid=46&amp;daysprune=30&amp;perpage=40&amp;posticon=0&amp;sortorder=desc&amp;sortfield=lastpost&pagenumber=2"" title=""Next page"">&rsaquo;</a><a href=""forumdisplay.php?forumid=46&amp;daysprune=30&amp;perpage=40&amp;posticon=0&amp;sortorder=desc&amp;sortfield=lastpost&pagenumber=5"" title=""Last page"">5 &raquo;</a></div>
<div class=""breadcrumbs""><span class=""mainbodytextlarge""><b><a href=""/"">The Something Awful Forums</a> &gt; <a href=""forumdisplay.php?forumid=51"">Discussion</a> &gt; <a href=""forumdisplay.php?forumid=46"" class=""bclast"">Debate Disco</a></b></span> <span class=""online_users"">(<a href=""/online.php?forumid=46"" title=""View members browsing this forum"">591 users browsing</a>)</span>
	<div id=""mp_bar"">
	<div id=""mods"">
	(Mods: <b><a href=""member.php?action=getinfo&amp;userid=27232"">Brown Moses</a></b>, <b><a href=""member.php?action=getinfo&amp;userid=28262"">Vilerat</a></b>, <b><a href=""member.php?action=getinfo&amp;userid=30107"">evilweasel</a></b>, <b><a href=""member.php?action=getinfo&amp;userid=92633"">Xandu</a></b>, <b><a href=""member.php?action=getinfo&amp;userid=121039"">XyloJW</a></b>)
	</div>
</div></div>




<div id=""filter"">
<div class=""toggle_tags"">Filter Posts</div>
<div class=""thread_tags"">
	 <a class=""if"" href=""/forumdisplay.php?forumid=46&amp;posticon=357""><img src=""http://fi.somethingawful.com/forums/posticons/dd-offmeds.jpg"" width=""60"" height=""15"" alt="""" title=""I'm Off My Meds and I Have Big Ideas""></a> <a class=""if"" href=""/forumdisplay.php?forumid=46&amp;posticon=358""><img src=""http://fi.somethingawful.com/forums/posticons/dd-environment.gif"" width=""60"" height=""15"" alt="""" title=""Environment: Fact or Fiction?""></a> <a class=""if"" href=""/forumdisplay.php?forumid=46&amp;posticon=359""><img src=""http://fi.somethingawful.com/forums/posticons/dd-war.gif"" width=""60"" height=""15"" alt="""" title=""War... War Never Changes.""></a> <a class=""if"" href=""/forumdisplay.php?forumid=46&amp;posticon=360""><img src=""http://fi.somethingawful.com/forums/posticons/dd-law.gif"" width=""60"" height=""15"" alt="""" title=""LAW""></a> <a class=""if"" href=""/forumdisplay.php?forumid=46&amp;posticon=361""><img src=""http://fi.somethingawful.com/forums/posticons/dd-europe.gif"" width=""60"" height=""15"" alt="""" title=""Europe""></a> <a class=""if"" href=""/forumdisplay.php?forumid=46&amp;posticon=362""><img src=""http://fi.somethingawful.com/forums/posticons/dd-asia.gif"" width=""60"" height=""15"" alt="""" title=""Asia""></a> <a class=""if"" href=""/forumdisplay.php?forumid=46&amp;posticon=363""><img src=""http://fi.somethingawful.com/forums/posticons/dd-africa.gif"" width=""60"" height=""15"" alt="""" title=""Africa""></a> <a class=""if"" href=""/forumdisplay.php?forumid=46&amp;posticon=420""><img src=""http://fi.somethingawful.com/forums/posticons/byob-slayer.gif"" width=""60"" height=""15"" alt="""" title=""Slayer""></a> <a class=""if"" href=""/forumdisplay.php?forumid=46&amp;posticon=503""><img src=""http://fi.somethingawful.com/forums/posticons/hell-boot.gif"" width=""60"" height=""15"" alt="""" title=""Bootstraps""></a> <a class=""if"" href=""/forumdisplay.php?forumid=46&amp;posticon=506""><img src=""http://fi.somethingawful.com/forums/posticons/hell-miso.gif"" width=""60"" height=""15"" alt="""" title=""Miso horny""></a> <a class=""if"" href=""/forumdisplay.php?forumid=46&amp;posticon=510""><img src=""http://fi.somethingawful.com/forums/posticons/lf-arecountry.gif"" width=""60"" height=""15"" alt="""" title=""Are Country""></a> <a class=""if"" href=""/forumdisplay.php?forumid=46&amp;posticon=512""><img src=""http://fi.somethingawful.com/forums/posticons/lf-choom.gif"" width=""60"" height=""15"" alt="""" title=""Choom""></a> <a class=""if"" href=""/forumdisplay.php?forumid=46&amp;posticon=516""><img src=""http://fi.somethingawful.com/forums/posticons/lf-laters.gif"" width=""60"" height=""15"" alt="""" title=""Laters""></a> <a class=""if"" href=""/forumdisplay.php?forumid=46&amp;posticon=520""><img src=""http://fi.somethingawful.com/forums/posticons/lf-whites.gif"" width=""60"" height=""15"" alt="""" title=""Whites""></a> <a class=""if"" href=""/forumdisplay.php?forumid=46&amp;posticon=522""><img src=""http://fi.somethingawful.com/forums/posticons/lf-marx.png"" width=""60"" height=""15"" alt="""" title=""Marxism""></a> <a class=""if"" href=""/forumdisplay.php?forumid=46&amp;posticon=526""><img src=""http://fi.somethingawful.com/forums/posticons/lf-9287.gif"" width=""60"" height=""15"" alt="""" title=""9287""></a> <a class=""if"" href=""/forumdisplay.php?forumid=46&amp;posticon=527""><img src=""http://fi.somethingawful.com/forums/posticons/lf-amerika.gif"" width=""60"" height=""15"" alt="""" title=""Amerika""></a> <a class=""if"" href=""/forumdisplay.php?forumid=46&amp;posticon=531""><img src=""http://fi.somethingawful.com/forums/posticons/lf-eu.gif"" width=""60"" height=""15"" alt="""" title=""EU""></a> <a class=""if"" href=""/forumdisplay.php?forumid=46&amp;posticon=534""><img src=""http://fi.somethingawful.com/forums/posticons/lf-gotmine.gif"" width=""60"" height=""15"" alt="""" title=""Got Mine""></a> <a class=""if"" href=""/forumdisplay.php?forumid=46&amp;posticon=538""><img src=""http://fi.somethingawful.com/forums/posticons/lf-migra.gif"" width=""60"" height=""15"" alt="""" title=""Migra""></a> <a class=""if"" href=""/forumdisplay.php?forumid=46&amp;posticon=554""><img src=""http://fi.somethingawful.com/forums/posticons/lf-dji.gif"" width=""60"" height=""15"" alt="""" title=""Dow Jones""></a> <a class=""if"" href=""/forumdisplay.php?forumid=46&amp;posticon=570""><img src=""http://fi.somethingawful.com/forums/posticons/lf-trains.gif"" width=""60"" height=""15"" alt="""" title=""Trains""></a> <a class=""if"" href=""/forumdisplay.php?forumid=46&amp;posticon=573""><img src=""http://fi.somethingawful.com/forums/posticons/lan-midwest.gif"" width=""60"" height=""15"" alt="""" title=""Midwest""></a> <a class=""if"" href=""/forumdisplay.php?forumid=46&amp;posticon=574""><img src=""http://fi.somethingawful.com/forums/posticons/lan-west.gif"" width=""60"" height=""15"" alt="""" title=""West""></a> <a class=""if"" href=""/forumdisplay.php?forumid=46&amp;posticon=576""><img src=""http://fi.somethingawful.com/forums/posticons/lan-canada.gif"" width=""60"" height=""15"" alt="""" title=""Canada""></a> <a class=""if"" href=""/forumdisplay.php?forumid=46&amp;posticon=579""><img src=""http://fi.somethingawful.com/forums/posticons/lan-south.gif"" width=""60"" height=""15"" alt="""" title=""South""></a> <a class=""if"" href=""/forumdisplay.php?forumid=46&amp;posticon=587""><img src=""http://fi.somethingawful.com/forums/posticons/hell-spergin.gif"" width=""60"" height=""15"" alt="""" title=""Spergin""></a> <a class=""if"" href=""/forumdisplay.php?forumid=46&amp;posticon=627""><img src=""http://fi.somethingawful.com/forums/posticons/LF-rungop.gif"" width=""60"" height=""15"" alt="""" title=""LF-rungop.gif""></a> <a class=""if"" href=""/forumdisplay.php?forumid=46&amp;posticon=629""><img src=""http://fi.somethingawful.com/forums/posticons/LF-purestrain2.gif"" width=""60"" height=""15"" alt="""" title=""LF-purestrain2.gif""></a> <a class=""if"" href=""/forumdisplay.php?forumid=46&amp;posticon=631""><img src=""http://fi.somethingawful.com/forums/posticons/LF-perspective_1.gif"" width=""60"" height=""15"" alt="""" title=""LF-perspective_1.gif""></a> <a class=""if"" href=""/forumdisplay.php?forumid=46&amp;posticon=632""><img src=""http://fi.somethingawful.com/forums/posticons/LF-pennybags.png"" width=""60"" height=""15"" alt="""" title=""LF-pennybags.png""></a> <a class=""if"" href=""/forumdisplay.php?forumid=46&amp;posticon=640""><img src=""http://fi.somethingawful.com/forums/posticons/LF-iraq.gif"" width=""60"" height=""15"" alt="""" title=""LF-iraq.gif""></a> <a class=""if"" href=""/forumdisplay.php?forumid=46&amp;posticon=645""><img src=""http://fi.somethingawful.com/forums/posticons/LF-gitrdun2.gif"" width=""60"" height=""15"" alt="""" title=""LF-gitrdun2.gif""></a> <a class=""if"" href=""/forumdisplay.php?forumid=46&amp;posticon=653""><img src=""http://fi.somethingawful.com/forums/posticons/LF-article.gif"" width=""60"" height=""15"" alt="""" title=""LF-article.gif""></a> <a class=""if"" href=""/forumdisplay.php?forumid=46&amp;posticon=655""><img src=""http://fi.somethingawful.com/forums/posticons/LF-2wqxulw.gif"" width=""60"" height=""15"" alt="""" title=""LF-2wqxulw.gif""></a> <a class=""if"" href=""/forumdisplay.php?forumid=46&amp;posticon=657""><img src=""http://fi.somethingawful.com/forums/posticons/LF-2mfbryu.gif"" width=""60"" height=""15"" alt="""" title=""LF-2mfbryu.gif""></a> <a class=""if"" href=""/forumdisplay.php?forumid=46&amp;posticon=659""><img src=""http://fi.somethingawful.com/forums/posticons/LF-29qdqgy.gif"" width=""60"" height=""15"" alt="""" title=""LF-29qdqgy.gif""></a> <a class=""if"" href=""/forumdisplay.php?forumid=46&amp;posticon=660""><img src=""http://fi.somethingawful.com/forums/posticons/LF-25tjf47.gif"" width=""60"" height=""15"" alt="""" title=""LF-25tjf47.gif""></a> <a class=""if"" href=""/forumdisplay.php?forumid=46&amp;posticon=681""><img src=""http://fi.somethingawful.com/forums/posticons/icon-dear_richard.png"" width=""60"" height=""15"" alt="""" title=""DEAR RICHARD""></a> <a class=""if"" href=""/forumdisplay.php?forumid=46&amp;posticon=687""><img src=""http://fi.somethingawful.com/forums/posticons/gip-money.gif"" width=""60"" height=""15"" alt="""" title=""Money""></a> <a class=""if"" href=""/forumdisplay.php?forumid=46&amp;posticon=692""><img src=""http://fi.somethingawful.com/forums/posticons/dd-9-11.gif"" width=""60"" height=""15"" alt="""" title=""9/11""></a> <a class=""if"" href=""/forumdisplay.php?forumid=46&amp;posticon=693""><img src=""http://fi.somethingawful.com/forums/posticons/dd-dems.gif"" width=""60"" height=""15"" alt="""" title=""Dems""></a> <a class=""if"" href=""/forumdisplay.php?forumid=46&amp;posticon=694""><img src=""http://fi.somethingawful.com/forums/posticons/dd-fox.gif"" width=""60"" height=""15"" alt="""" title=""Foxnews""></a> <a class=""if"" href=""/forumdisplay.php?forumid=46&amp;posticon=695""><img src=""http://fi.somethingawful.com/forums/posticons/dd-GOP.gif"" width=""60"" height=""15"" alt="""" title=""GOP""></a> <a class=""if"" href=""/forumdisplay.php?forumid=46&amp;posticon=696""><img src=""http://fi.somethingawful.com/forums/posticons/dd-notracist.gif"" width=""60"" height=""15"" alt="""" title=""NOT racist""></a> <a class=""if"" href=""/forumdisplay.php?forumid=46&amp;posticon=713""><img src=""http://fi.somethingawful.com/forums/posticons/dd-gotcha.png"" width=""60"" height=""15"" alt="""" title=""Gotcha!""></a> <a class=""if"" href=""/forumdisplay.php?forumid=46&amp;posticon=757""><img src=""http://fi.somethingawful.com/forums/posticons/ddrd-scsa.gif"" width=""60"" height=""15"" alt="""" title=""Install the vent hood: because Stone Cold Said So""></a> <a class=""if"" href=""/forumdisplay.php?forumid=46&amp;posticon=125""><img src=""http://forumimages.somethingawful.com/forums/posticons/icon-60-pig.gif"" width=""60"" height=""15"" alt="""" title=""""></a> <a class=""if"" href=""/forumdisplay.php?forumid=46&amp;posticon=737""><img src=""http://fi.somethingawful.com/forums/posticons/chooch.gif"" width=""60"" height=""15"" alt="""" title=""Choochacacacacacacko""></a> <a class=""if"" href=""/forumdisplay.php?forumid=46&amp;posticon=124""><img src=""http://forumimages.somethingawful.com/forums/posticons/icon-59-lobster.gif"" width=""60"" height=""15"" alt="""" title=""LOBSTER!!!  OH YEAH!!!""></a> <a class=""if"" href=""/forumdisplay.php?forumid=46&amp;posticon=60""><img src=""http://fi.somethingawful.com/forums/posticons/icons-08/en.png"" width=""60"" height=""15"" alt="""" title=""e/n bullshit""></a> <a class=""if"" href=""/forumdisplay.php?forumid=46&amp;posticon=61""><img src=""http://fi.somethingawful.com/forums/posticons/icons-08/unfunny.png"" width=""60"" height=""15"" alt="""" title=""NOT FUNNY AT ALL""></a> <a class=""if"" href=""/forumdisplay.php?forumid=46&amp;posticon=66""><img src=""http://fi.somethingawful.com/forums/posticons/icons-08/rant.png"" width=""60"" height=""15"" alt="""" title=""Rant""></a> <a class=""if"" href=""/forumdisplay.php?forumid=46&amp;posticon=70""><img src=""http://fi.somethingawful.com/forums/posticons/icons-08/flame.png"" width=""60"" height=""15"" alt="""" title=""FLAME!!!""></a> <a class=""if"" href=""/forumdisplay.php?forumid=46&amp;posticon=77""><img src=""http://fi.somethingawful.com/forums/posticons/icons-08/stupid.png"" width=""60"" height=""15"" alt="""" title=""Something stupid""></a> <a class=""if"" href=""/forumdisplay.php?forumid=46&amp;posticon=79""><img src=""http://fi.somethingawful.com/forums/posticons/icons-08/weird.png"" width=""60"" height=""15"" alt="""" title=""Something weird""></a> <a class=""if"" href=""/forumdisplay.php?forumid=46&amp;posticon=81""><img src=""http://fi.somethingawful.com/forums/posticons/icons-08/fruity.png"" width=""60"" height=""15"" alt="""" title=""Fruity post""></a> <a class=""if"" href=""/forumdisplay.php?forumid=46&amp;posticon=86""><img src=""http://fi.somethingawful.com/forums/posticons/icons-08/gross.png"" width=""60"" height=""15"" alt="""" title=""Gross""></a> <a class=""if"" href=""/forumdisplay.php?forumid=46&amp;posticon=89""><img src=""http://fi.somethingawful.com/forums/posticons/icons-08/humor.png"" width=""60"" height=""15"" alt="""" title=""Humor""></a> <a class=""if"" href=""/forumdisplay.php?forumid=46&amp;posticon=95""><img src=""http://fi.somethingawful.com/forums/posticons/icons-08/whine.png"" width=""60"" height=""15"" alt="""" title=""Wahhhhhh whine whine whine""></a> <a class=""if"" href=""/forumdisplay.php?forumid=46&amp;posticon=115""><img src=""http://fi.somethingawful.com/forums/posticons/icons-08/serious.png"" width=""60"" height=""15"" alt="""" title=""This is a serious post""></a> <a class=""if"" href=""/forumdisplay.php?forumid=46&amp;posticon=64""><img src=""http://fi.somethingawful.com/forums/posticons/icons-08/question.png"" width=""60"" height=""15"" alt="""" title=""Question""></a> <a class=""if"" href=""/forumdisplay.php?forumid=46&amp;posticon=65""><img src=""http://fi.somethingawful.com/forums/posticons/icons-08/attention.png"" width=""60"" height=""15"" alt="""" title=""ATTENTION!""></a> <a class=""if"" href=""/forumdisplay.php?forumid=46&amp;posticon=67""><img src=""http://fi.somethingawful.com/forums/posticons/icons-08/newbie.png"" width=""60"" height=""15"" alt="""" title=""NEWBIE QUESTION""></a> <a class=""if"" href=""/forumdisplay.php?forumid=46&amp;posticon=68""><img src=""http://fi.somethingawful.com/forums/posticons/icons-08/poll.png"" width=""60"" height=""15"" alt="""" title=""Poll""></a> <a class=""if"" href=""/forumdisplay.php?forumid=46&amp;posticon=69""><img src=""http://fi.somethingawful.com/forums/posticons/icons-08/link.png"" width=""60"" height=""15"" alt="""" title=""URL Link""></a> <a class=""if"" href=""/forumdisplay.php?forumid=46&amp;posticon=74""><img src=""http://fi.somethingawful.com/forums/posticons/icons-08/request.png"" width=""60"" height=""15"" alt="""" title=""Request!""></a> <a class=""if"" href=""/forumdisplay.php?forumid=46&amp;posticon=78""><img src=""http://fi.somethingawful.com/forums/posticons/icons-08/help.png"" width=""60"" height=""15"" alt="""" title=""Help!""></a> <a class=""if"" href=""/forumdisplay.php?forumid=46&amp;posticon=104""><img src=""http://fi.somethingawful.com/forums/posticons/icons-08/event.png"" width=""60"" height=""15"" alt="""" title=""Event planned""></a> <a class=""if"" href=""/forumdisplay.php?forumid=46&amp;posticon=113""><img src=""http://fi.somethingawful.com/forums/posticons/icons-08/goonmeet.png"" width=""60"" height=""15"" alt="""" title=""Goon Meet""></a> <a class=""if"" href=""/forumdisplay.php?forumid=46&amp;posticon=120""><img src=""http://fi.somethingawful.com/forums/posticons/icons-08/repeat.png"" width=""60"" height=""15"" alt="""" title=""Repeated subject / link?""></a> <a class=""if"" href=""/forumdisplay.php?forumid=46&amp;posticon=71""><img src=""http://fi.somethingawful.com/forums/posticons/icons-08/games.png"" width=""60"" height=""15"" alt="""" title=""Games""></a> <a class=""if"" href=""/forumdisplay.php?forumid=46&amp;posticon=75""><img src=""http://fi.somethingawful.com/forums/posticons/icons-08/news.png"" width=""60"" height=""15"" alt="""" title=""News item""></a> <a class=""if"" href=""/forumdisplay.php?forumid=46&amp;posticon=80""><img src=""http://fi.somethingawful.com/forums/posticons/icons-08/music.png"" width=""60"" height=""15"" alt="""" title=""Music""></a> <a class=""if"" href=""/forumdisplay.php?forumid=46&amp;posticon=83""><img src=""http://fi.somethingawful.com/forums/posticons/icons-08/computers.png"" width=""60"" height=""15"" alt="""" title=""Computer issues""></a> <a class=""if"" href=""/forumdisplay.php?forumid=46&amp;posticon=85""><img src=""http://fi.somethingawful.com/forums/posticons/icons-08/politics.png"" width=""60"" height=""15"" alt="""" title=""Political debate""></a> <a class=""if"" href=""/forumdisplay.php?forumid=46&amp;posticon=88""><img src=""http://fi.somethingawful.com/forums/posticons/icons-08/school.png"" width=""60"" height=""15"" alt="""" title=""School""></a> <a class=""if"" href=""/forumdisplay.php?forumid=46&amp;posticon=92""><img src=""http://fi.somethingawful.com/forums/posticons/icons-08/sex.png"" width=""60"" height=""15"" alt="""" title=""Something about sex""></a> <a class=""if"" href=""/forumdisplay.php?forumid=46&amp;posticon=93""><img src=""http://fi.somethingawful.com/forums/posticons/icons-08/cars.png"" width=""60"" height=""15"" alt="""" title=""Cars""></a> <a class=""if"" href=""/forumdisplay.php?forumid=46&amp;posticon=101""><img src=""http://fi.somethingawful.com/forums/posticons/icons-08/guns.png"" width=""60"" height=""15"" alt="""" title=""Guns""></a> <a class=""if"" href=""/forumdisplay.php?forumid=46&amp;posticon=105""><img src=""http://fi.somethingawful.com/forums/posticons/icons-08/tech.png"" width=""60"" height=""15"" alt="""" title=""Technical question""></a> <a class=""if"" href=""/forumdisplay.php?forumid=46&amp;posticon=121""><img src=""http://fi.somethingawful.com/forums/posticons/icons-08/sports.png"" width=""60"" height=""15"" alt="""" title=""Sports""></a> <a class=""if"" href=""/forumdisplay.php?forumid=46&amp;posticon=122""><img src=""http://fi.somethingawful.com/forums/posticons/icons-08/drugs.png"" width=""60"" height=""15"" alt="""" title=""Drugs, maaaan""></a> <a class=""if"" href=""/forumdisplay.php?forumid=46&amp;posticon=123""><img src=""http://fi.somethingawful.com/forums/posticons/icons-08/science.png"" width=""60"" height=""15"" alt="""" title=""Science... and philosophy!""></a> <a class=""if"" href=""/forumdisplay.php?forumid=46&amp;posticon=128""><img src=""http://fi.somethingawful.com/forums/posticons/icons-08/food.png"" width=""60"" height=""15"" alt="""" title=""Food and Cooking""></a> <a class=""if"" href=""/forumdisplay.php?forumid=46&amp;posticon=309""><img src=""http://fi.somethingawful.com/forums/posticons/icons-08/video.png"" width=""60"" height=""15"" alt="""" title=""Another online video link thread""></a> <a class=""if"" href=""/forumdisplay.php?forumid=46&amp;posticon=63""><img src=""http://fi.somethingawful.com/forums/posticons/icons-08/audio.png"" width=""60"" height=""15"" alt="""" title=""Audio file""></a> <a class=""if"" href=""/forumdisplay.php?forumid=46&amp;posticon=72""><img src=""http://fi.somethingawful.com/forums/posticons/icons-08/movies.png"" width=""60"" height=""15"" alt="""" title=""Movie Discussion""></a> <a class=""if"" href=""/forumdisplay.php?forumid=46&amp;posticon=73""><img src=""http://fi.somethingawful.com/forums/posticons/icons-08/books.png"" width=""60"" height=""15"" alt="""" title=""Books and literature""></a> <a class=""if"" href=""/forumdisplay.php?forumid=46&amp;posticon=76""><img src=""http://fi.somethingawful.com/forums/posticons/icons-08/photoshop.png"" width=""60"" height=""15"" alt="""" title=""Photoshop entry""></a> <a class=""if"" href=""/forumdisplay.php?forumid=46&amp;posticon=94""><img src=""http://fi.somethingawful.com/forums/posticons/icons-08/tv.png"" width=""60"" height=""15"" alt="""" title=""Television""></a> <a class=""if"" href=""/forumdisplay.php?forumid=46&amp;posticon=114""><img src=""http://forumimages.somethingawful.com/forums/posticons/icons-08/art.png"" width=""60"" height=""15"" alt="""" title=""Art""></a> <a class=""if"" href=""/forumdisplay.php?forumid=46&amp;posticon=116""><img src=""http://fi.somethingawful.com/forums/posticons/icons-08/photos.png"" width=""60"" height=""15"" alt="""" title=""Photos / webcams / etc""></a> <a class=""if"" href=""/forumdisplay.php?forumid=46&amp;posticon=82""><img src=""http://forumimages.somethingawful.com/forums/posticons/icon23-banme.gif"" width=""60"" height=""15"" alt="""" title=""PLEASE BAN ME""></a> <a class=""if"" href=""/forumdisplay.php?forumid=46&amp;posticon=90""><img src=""http://forumimages.somethingawful.com/forums/posticons/icon-30-attnmod.gif"" width=""60"" height=""15"" alt="""" title=""MODS ONLY""></a> <a class=""if"" href=""/forumdisplay.php?forumid=46&amp;posticon=91""><img src=""http://forumimages.somethingawful.com/forums/posticons/icon-31-hotthread.gif"" width=""60"" height=""15"" alt="""" title=""MODS ONLY""></a> <a class=""if"" href=""/forumdisplay.php?forumid=46&amp;posticon=274""><img src=""http://fi.somethingawful.com/forums/posticons/byob-excuse.gif"" width=""60"" height=""15"" alt="""" title=""Excuse Me""></a> <a class=""if"" href=""/forumdisplay.php?forumid=46&amp;posticon=299""><img src=""http://fi.somethingawful.com/forums/posticons/byob-secrets.gif"" width=""60"" height=""15"" alt="""" title=""Secrets""></a> <a class=""if"" href=""/forumdisplay.php?forumid=46&amp;posticon=256""><img src=""http://fi.somethingawful.com/forums/posticons/fyad-trout.gif"" width=""60"" height=""15"" alt="""" title=""Trout Magick""></a> <a class=""if"" href=""/forumdisplay.php?forumid=46&amp;posticon=322""><img src=""http://fi.somethingawful.com/forums/posticons/fyad-blogs.gif"" width=""60"" height=""15"" alt="""" title=""BLOGS""></a> <a class=""if"" href=""/forumdisplay.php?forumid=46&amp;posticon=212""><img src=""http://fi.somethingawful.com/forums/posticons/dd-economics.gif"" width=""60"" height=""15"" alt="""" title=""Economics""></a> <a class=""if"" href=""/forumdisplay.php?forumid=46&amp;posticon=193""><img src=""http://fi.somethingawful.com/forums/posticons/coupon-nonus.gif"" width=""60"" height=""15"" alt="""" title=""Non-US""></a> <a class=""if"" href=""/forumdisplay.php?forumid=46&amp;posticon=213""><img src=""http://fi.somethingawful.com/forums/posticons/dd-history.gif"" width=""60"" height=""15"" alt="""" title=""History""></a> <a class=""if"" href=""/forumdisplay.php?forumid=46&amp;posticon=214""><img src=""http://fi.somethingawful.com/forums/posticons/dd-philosophy.gif"" width=""60"" height=""15"" alt="""" title=""Philosophy""></a> <a class=""if"" href=""/forumdisplay.php?forumid=46&amp;posticon=215""><img src=""http://fi.somethingawful.com/forums/posticons/dd-religion.gif"" width=""60"" height=""15"" alt="""" title=""Religion""></a> <a class=""if"" href=""/forumdisplay.php?forumid=46&amp;posticon=183""><img src=""http://fi.somethingawful.com/forums/posticons/guns-ohshi.gif"" width=""60"" height=""15"" alt="""" title=""Oh shi...""></a> <a class=""if"" href=""/forumdisplay.php?forumid=46&amp;posticon=350""><img src=""http://fi.somethingawful.com/forums/posticons/cd_scifi.gif"" width=""60"" height=""15"" alt="""" title=""SciFi""></a> <a class=""if"" href=""/forumdisplay.php?forumid=46&amp;posticon=245""><img src=""http://fi.somethingawful.com/forums/posticons/tcc-weed.gif"" width=""60"" height=""15"" alt="""" title=""Weed""></a>
	<div class=""remove_tag"">
		<a href=""/forumdisplay.php?forumid=46"">Remove filter</a>
	</div>
</div>
</div>


<table id=""forum"" summary=""Threads"" class=""threadlist "">
	<caption>Threads</caption>
	<thead>
	<tr>
		<th class=""star"">&nbsp;</th>
		<th class=""icon"">Icon</th>
		<th class=""title"">Title (Pages)</th>
		<th class=""author"">Author</th>
		<th class=""replies""><a href=""forumdisplay.php?forumid=46&amp;daysprune=30&amp;perpage=40&amp;posticon=0&amp;sortorder=desc&amp;sortfield=replycount""><abbr title=""Replies"">Re</abbr></a> </th>
		<th class=""views"">Views</th>
		<th class=""rate""><a href=""forumdisplay.php?forumid=46&amp;daysprune=30&amp;perpage=40&amp;posticon=0&amp;sortorder=desc&amp;sortfield=voteavg"">Rating</a> </th>
		<th class=""lastpost""><a href=""forumdisplay.php?forumid=46&amp;daysprune=30&amp;perpage=40&amp;posticon=0&amp;sortorder=desc&amp;sortfield=lastpost"">Killed By</a> <a href=""forumdisplay.php?forumid=46&amp;daysprune=30&amp;perpage=40&amp;posticon=0&amp;pagenumber=1&amp;sortorder=asc&amp;sortfield=lastpost""><img src=""http://fi.somethingawful.com/images/sortasc.gif"" title=""Reverse Sort Order""></a></th>
	</tr>
	</thead>
	<tbody>
		
		<tr class=""thread seen"" id=""thread3604430"">
	<td class=""star ""></td>
	<td class=""icon""><a href=""/forumdisplay.php?forumid=46&amp;posticon=82""><img src=""http://forumimages.somethingawful.com/forums/posticons/icon23-banme.gif#82"" alt=""""></a></td>
	<td class=""title title_sticky"">
		<div class=""title_inner"">
			<div class=""lastseen""><a href=""/showthread.php?action=resetseen&amp;threadid=3604430"" class=""x"" title=""Mark as unread"">X</a></div>
			<div class=""info"">
				<a href=""showthread.php?threadid=3604430"" class=""thread_title"">Debate and Discussion: A Rules Thread</a>
				
			</div>
		</div>
	</td>
	<td class=""author""><a href=""member.php?action=getinfo&amp;userid=121039"">XyloJW</a></td>
	<td class=""replies"">0</td>
	<td class=""views"">4927</td>
	<td class=""rating"">&nbsp;</td>
	<td class=""lastpost""><div class=""date"">13:05 Jan 23, 2014</div><a class=""author"" href=""showthread.php?goto=lastpost&amp;threadid=3604430"">XyloJW</a></td>
</tr><tr class=""thread seen"" id=""thread3599044"">
	<td class=""star ""></td>
	<td class=""icon""><a href=""/forumdisplay.php?forumid=46&amp;posticon=114""><img src=""http://forumimages.somethingawful.com/forums/posticons/icons-08/art.png#114"" alt=""""></a></td>
	<td class=""title"">
		<div class=""title_inner"">
			<div class=""lastseen""><a href=""/showthread.php?action=resetseen&amp;threadid=3599044"" class=""x"" title=""Mark as unread"">X</a><a title=""Jump to last read post"" href=""/showthread.php?threadid=3599044&amp;goto=newpost"" class=""count""><b>14730</b></a></div>
			<div class=""info"">
				<a href=""showthread.php?threadid=3599044"" class=""thread_title"">Political Cartoons 2014: Ham Stoker's Dracallah</a>
				<div class=""title_pages"">Pages: <a class=""pagenumber"" href=""showthread.php?threadid=3599044&amp;pagenumber=1"">1</a><a class=""pagenumber"" href=""showthread.php?threadid=3599044&amp;pagenumber=2"">2</a><a class=""pagenumber"" href=""showthread.php?threadid=3599044&amp;pagenumber=3"">3</a><a class=""pagenumber"" href=""showthread.php?threadid=3599044&amp;pagenumber=4"">4</a><a class=""pagenumber"" href=""showthread.php?threadid=3599044&amp;pagenumber=5"">5</a><a class=""pagenumber"" href=""showthread.php?threadid=3599044&amp;pagenumber=6"">6</a><a class=""pagenumber"" href=""showthread.php?threadid=3599044&amp;pagenumber=7"">7</a>... <a class=""pagenumber"" href=""showthread.php?threadid=3599044&amp;goto=lastpost"">Last</a></div>
			</div>
		</div>
	</td>
	<td class=""author""><a href=""member.php?action=getinfo&amp;userid=181910"">Rorus Raz</a></td>
	<td class=""replies"">14769</td>
	<td class=""views"">1563357</td>
	<td class=""rating""><img src=""http://fi.somethingawful.com/rate/default/5stars.gif"" alt="""" title=""138 votes - 4.6 average""></td>
	<td class=""lastpost""><div class=""date"">16:59 Mar 21, 2014</div><a class=""author"" href=""showthread.php?goto=lastpost&amp;threadid=3599044"">Your Friend</a></td>
</tr><tr class=""thread"" id=""thread3612431"">
	<td class=""star ""></td>
	<td class=""icon""><a href=""/forumdisplay.php?forumid=46&amp;posticon=357""><img src=""http://fi.somethingawful.com/forums/posticons/dd-offmeds.jpg#357"" alt=""""></a></td>
	<td class=""title"">
		<div class=""title_inner"">
			
			<div class=""info"">
				<a href=""showthread.php?threadid=3612431"" class=""thread_title"">USA politics March: Mainly staring at the GOP in slack jawed horror</a>
				<div class=""title_pages"">Pages: <a class=""pagenumber"" href=""showthread.php?threadid=3612431&amp;pagenumber=1"">1</a><a class=""pagenumber"" href=""showthread.php?threadid=3612431&amp;pagenumber=2"">2</a><a class=""pagenumber"" href=""showthread.php?threadid=3612431&amp;pagenumber=3"">3</a><a class=""pagenumber"" href=""showthread.php?threadid=3612431&amp;pagenumber=4"">4</a><a class=""pagenumber"" href=""showthread.php?threadid=3612431&amp;pagenumber=5"">5</a><a class=""pagenumber"" href=""showthread.php?threadid=3612431&amp;pagenumber=6"">6</a><a class=""pagenumber"" href=""showthread.php?threadid=3612431&amp;pagenumber=7"">7</a>... <a class=""pagenumber"" href=""showthread.php?threadid=3612431&amp;goto=lastpost"">Last</a></div>
			</div>
		</div>
	</td>
	<td class=""author""><a href=""member.php?action=getinfo&amp;userid=171567"">Fried Chicken</a></td>
	<td class=""replies"">2901</td>
	<td class=""views"">254448</td>
	<td class=""rating""><img src=""http://fi.somethingawful.com/rate/default/3stars.gif"" alt="""" title=""43 votes - 3.18 average""></td>
	<td class=""lastpost""><div class=""date"">16:58 Mar 21, 2014</div><a class=""author"" href=""showthread.php?goto=lastpost&amp;threadid=3612431"">Rhesus Pieces</a></td>
</tr><tr class=""thread"" id=""thread3552101"">
	<td class=""star ""></td>
	<td class=""icon""><a href=""/forumdisplay.php?forumid=46&amp;posticon=576""><img src=""http://fi.somethingawful.com/forums/posticons/lan-canada.gif#576"" alt=""""></a></td>
	<td class=""title"">
		<div class=""title_inner"">
			
			<div class=""info"">
				<a href=""showthread.php?threadid=3552101"" class=""thread_title"">Canadian Politics Megathread: That is simply not Trudeau</a>
				<div class=""title_pages"">Pages: <a class=""pagenumber"" href=""showthread.php?threadid=3552101&amp;pagenumber=1"">1</a><a class=""pagenumber"" href=""showthread.php?threadid=3552101&amp;pagenumber=2"">2</a><a class=""pagenumber"" href=""showthread.php?threadid=3552101&amp;pagenumber=3"">3</a><a class=""pagenumber"" href=""showthread.php?threadid=3552101&amp;pagenumber=4"">4</a><a class=""pagenumber"" href=""showthread.php?threadid=3552101&amp;pagenumber=5"">5</a><a class=""pagenumber"" href=""showthread.php?threadid=3552101&amp;pagenumber=6"">6</a><a class=""pagenumber"" href=""showthread.php?threadid=3552101&amp;pagenumber=7"">7</a>... <a class=""pagenumber"" href=""showthread.php?threadid=3552101&amp;goto=lastpost"">Last</a></div>
			</div>
		</div>
	</td>
	<td class=""author""><a href=""member.php?action=getinfo&amp;userid=72506"">Kafka Esq.</a></td>
	<td class=""replies"">16226</td>
	<td class=""views"">822793</td>
	<td class=""rating""><img src=""http://fi.somethingawful.com/rate/default/3stars.gif"" alt="""" title=""95 votes - 3.35 average""></td>
	<td class=""lastpost""><div class=""date"">16:58 Mar 21, 2014</div><a class=""author"" href=""showthread.php?goto=lastpost&amp;threadid=3552101"">Dreylad</a></td>
</tr><tr class=""thread seen"" id=""thread3556746"">
	<td class=""star ""></td>
	<td class=""icon""><a href=""/forumdisplay.php?forumid=46&amp;posticon=123""><img src=""http://fi.somethingawful.com/forums/posticons/icons-08/science.png#123"" alt=""""></a></td>
	<td class=""title"">
		<div class=""title_inner"">
			<div class=""lastseen""><a href=""/showthread.php?action=resetseen&amp;threadid=3556746"" class=""x"" title=""Mark as unread"">X</a><a title=""Jump to last read post"" href=""/showthread.php?threadid=3556746&amp;goto=newpost"" class=""count""><b>1016</b></a></div>
			<div class=""info"">
				<a href=""showthread.php?threadid=3556746"" class=""thread_title"">The Devil Monsanto, or Combating Scientific Ignorance</a>
				<div class=""title_pages"">Pages: <a class=""pagenumber"" href=""showthread.php?threadid=3556746&amp;pagenumber=1"">1</a><a class=""pagenumber"" href=""showthread.php?threadid=3556746&amp;pagenumber=2"">2</a><a class=""pagenumber"" href=""showthread.php?threadid=3556746&amp;pagenumber=3"">3</a><a class=""pagenumber"" href=""showthread.php?threadid=3556746&amp;pagenumber=4"">4</a><a class=""pagenumber"" href=""showthread.php?threadid=3556746&amp;pagenumber=5"">5</a><a class=""pagenumber"" href=""showthread.php?threadid=3556746&amp;pagenumber=6"">6</a><a class=""pagenumber"" href=""showthread.php?threadid=3556746&amp;pagenumber=7"">7</a>... <a class=""pagenumber"" href=""showthread.php?threadid=3556746&amp;goto=lastpost"">Last</a></div>
			</div>
		</div>
	</td>
	<td class=""author""><a href=""member.php?action=getinfo&amp;userid=115907"">Slanderer</a></td>
	<td class=""replies"">1095</td>
	<td class=""views"">63081</td>
	<td class=""rating""><img src=""http://fi.somethingawful.com/rate/default/2stars.gif"" alt="""" title=""78 votes - 2.43 average""></td>
	<td class=""lastpost""><div class=""date"">16:56 Mar 21, 2014</div><a class=""author"" href=""showthread.php?goto=lastpost&amp;threadid=3556746"">Paper Mac</a></td>
</tr><tr class=""thread"" id=""thread3493762"">
	<td class=""star ""></td>
	<td class=""icon""><a href=""/forumdisplay.php?forumid=46&amp;posticon=526""><img src=""http://fi.somethingawful.com/forums/posticons/lf-9287.gif#526"" alt=""""></a></td>
	<td class=""title"">
		<div class=""title_inner"">
			
			<div class=""info"">
				<a href=""showthread.php?threadid=3493762"" class=""thread_title"">DnD Pictures Thread</a>
				<div class=""title_pages"">Pages: <a class=""pagenumber"" href=""showthread.php?threadid=3493762&amp;pagenumber=1"">1</a><a class=""pagenumber"" href=""showthread.php?threadid=3493762&amp;pagenumber=2"">2</a><a class=""pagenumber"" href=""showthread.php?threadid=3493762&amp;pagenumber=3"">3</a><a class=""pagenumber"" href=""showthread.php?threadid=3493762&amp;pagenumber=4"">4</a><a class=""pagenumber"" href=""showthread.php?threadid=3493762&amp;pagenumber=5"">5</a><a class=""pagenumber"" href=""showthread.php?threadid=3493762&amp;pagenumber=6"">6</a><a class=""pagenumber"" href=""showthread.php?threadid=3493762&amp;pagenumber=7"">7</a>... <a class=""pagenumber"" href=""showthread.php?threadid=3493762&amp;goto=lastpost"">Last</a></div>
			</div>
		</div>
	</td>
	<td class=""author""><a href=""member.php?action=getinfo&amp;userid=156838"">Landsknecht</a></td>
	<td class=""replies"">25176</td>
	<td class=""views"">7181749</td>
	<td class=""rating""><img src=""http://fi.somethingawful.com/rate/default/4stars.gif"" alt="""" title=""348 votes - 3.78 average""></td>
	<td class=""lastpost""><div class=""date"">16:53 Mar 21, 2014</div><a class=""author"" href=""showthread.php?goto=lastpost&amp;threadid=3493762"">The Dark One</a></td>
</tr><tr class=""thread"" id=""thread3618446"">
	<td class=""star ""></td>
	<td class=""icon""><a href=""/forumdisplay.php?forumid=46&amp;posticon=361""><img src=""http://fi.somethingawful.com/forums/posticons/dd-europe.gif#361"" alt=""""></a></td>
	<td class=""title"">
		<div class=""title_inner"">
			
			<div class=""info"">
				<a href=""showthread.php?threadid=3618446"" class=""thread_title"">Eastern Europe: Ukraine's EU Victory Dance vs Dugin's Russia Uber Alles</a>
				<div class=""title_pages"">Pages: <a class=""pagenumber"" href=""showthread.php?threadid=3618446&amp;pagenumber=1"">1</a><a class=""pagenumber"" href=""showthread.php?threadid=3618446&amp;pagenumber=2"">2</a><a class=""pagenumber"" href=""showthread.php?threadid=3618446&amp;pagenumber=3"">3</a><a class=""pagenumber"" href=""showthread.php?threadid=3618446&amp;pagenumber=4"">4</a><a class=""pagenumber"" href=""showthread.php?threadid=3618446&amp;pagenumber=5"">5</a></div>
			</div>
		</div>
	</td>
	<td class=""author""><a href=""member.php?action=getinfo&amp;userid=78116"">HUGE PUBES A PLUS</a></td>
	<td class=""replies"">181</td>
	<td class=""views"">7704</td>
	<td class=""rating"">&nbsp;</td>
	<td class=""lastpost""><div class=""date"">16:50 Mar 21, 2014</div><a class=""author"" href=""showthread.php?goto=lastpost&amp;threadid=3618446"">kalstrams</a></td>
</tr><tr class=""thread"" id=""thread3577206"">
	<td class=""star ""></td>
	<td class=""icon""><a href=""/forumdisplay.php?forumid=46&amp;posticon=213""><img src=""http://fi.somethingawful.com/forums/posticons/dd-history.gif#213"" alt=""""></a></td>
	<td class=""title"">
		<div class=""title_inner"">
			
			<div class=""info"">
				<a href=""showthread.php?threadid=3577206"" class=""thread_title"">General American History Thread - Finding new things to be ashamed about</a>
				<div class=""title_pages"">Pages: <a class=""pagenumber"" href=""showthread.php?threadid=3577206&amp;pagenumber=1"">1</a><a class=""pagenumber"" href=""showthread.php?threadid=3577206&amp;pagenumber=2"">2</a><a class=""pagenumber"" href=""showthread.php?threadid=3577206&amp;pagenumber=3"">3</a><a class=""pagenumber"" href=""showthread.php?threadid=3577206&amp;pagenumber=4"">4</a><a class=""pagenumber"" href=""showthread.php?threadid=3577206&amp;pagenumber=5"">5</a><a class=""pagenumber"" href=""showthread.php?threadid=3577206&amp;pagenumber=6"">6</a><a class=""pagenumber"" href=""showthread.php?threadid=3577206&amp;pagenumber=7"">7</a>... <a class=""pagenumber"" href=""showthread.php?threadid=3577206&amp;goto=lastpost"">Last</a></div>
			</div>
		</div>
	</td>
	<td class=""author""><a href=""member.php?action=getinfo&amp;userid=156562"">Volkerball</a></td>
	<td class=""replies"">1680</td>
	<td class=""views"">108012</td>
	<td class=""rating""><img src=""http://fi.somethingawful.com/rate/default/3stars.gif"" alt="""" title=""30 votes - 3.16 average""></td>
	<td class=""lastpost""><div class=""date"">16:44 Mar 21, 2014</div><a class=""author"" href=""showthread.php?goto=lastpost&amp;threadid=3577206"">Peanut President</a></td>
</tr><tr class=""thread seen"" id=""thread3467849"">
	<td class=""star ""></td>
	<td class=""icon""><a href=""/forumdisplay.php?forumid=46&amp;posticon=510""><img src=""http://fi.somethingawful.com/forums/posticons/lf-arecountry.gif#510"" alt=""""></a></td>
	<td class=""title"">
		<div class=""title_inner"">
			<div class=""lastseen""><a href=""/showthread.php?action=resetseen&amp;threadid=3467849"" class=""x"" title=""Mark as unread"">X</a><a title=""Jump to last read post"" href=""/showthread.php?threadid=3467849&amp;goto=newpost"" class=""count""><b>7382</b></a></div>
			<div class=""info"">
				<a href=""showthread.php?threadid=3467849"" class=""thread_title"">Marriage Equality  from sea to shining sea.</a>
				<div class=""title_pages"">Pages: <a class=""pagenumber"" href=""showthread.php?threadid=3467849&amp;pagenumber=1"">1</a><a class=""pagenumber"" href=""showthread.php?threadid=3467849&amp;pagenumber=2"">2</a><a class=""pagenumber"" href=""showthread.php?threadid=3467849&amp;pagenumber=3"">3</a><a class=""pagenumber"" href=""showthread.php?threadid=3467849&amp;pagenumber=4"">4</a><a class=""pagenumber"" href=""showthread.php?threadid=3467849&amp;pagenumber=5"">5</a><a class=""pagenumber"" href=""showthread.php?threadid=3467849&amp;pagenumber=6"">6</a><a class=""pagenumber"" href=""showthread.php?threadid=3467849&amp;pagenumber=7"">7</a>... <a class=""pagenumber"" href=""showthread.php?threadid=3467849&amp;goto=lastpost"">Last</a></div>
			</div>
		</div>
	</td>
	<td class=""author""><a href=""member.php?action=getinfo&amp;userid=180391"">UltimoDragonQuest</a></td>
	<td class=""replies"">7766</td>
	<td class=""views"">720741</td>
	<td class=""rating""><img src=""http://fi.somethingawful.com/rate/default/4stars.gif"" alt="""" title=""72 votes - 3.83 average""></td>
	<td class=""lastpost""><div class=""date"">16:37 Mar 21, 2014</div><a class=""author"" href=""showthread.php?goto=lastpost&amp;threadid=3467849"">Nostalgia4Infinity</a></td>
</tr><tr class=""thread seen"" id=""thread3599372"">
	<td class=""star ""></td>
	<td class=""icon""><a href=""/forumdisplay.php?forumid=46&amp;posticon=359""><img src=""http://fi.somethingawful.com/forums/posticons/dd-war.gif#359"" alt=""""></a></td>
	<td class=""title"">
		<div class=""title_inner"">
			<div class=""lastseen""><a href=""/showthread.php?action=resetseen&amp;threadid=3599372"" class=""x"" title=""Mark as unread"">X</a><a title=""Jump to last read post"" href=""/showthread.php?threadid=3599372&amp;goto=newpost"" class=""count""><b>230</b></a></div>
			<div class=""info"">
				<a href=""showthread.php?threadid=3599372"" class=""thread_title"">Freepers: The Barak Obama School for the Chooming Sodomizers</a>
				<div class=""title_pages"">Pages: <a class=""pagenumber"" href=""showthread.php?threadid=3599372&amp;pagenumber=1"">1</a><a class=""pagenumber"" href=""showthread.php?threadid=3599372&amp;pagenumber=2"">2</a><a class=""pagenumber"" href=""showthread.php?threadid=3599372&amp;pagenumber=3"">3</a><a class=""pagenumber"" href=""showthread.php?threadid=3599372&amp;pagenumber=4"">4</a><a class=""pagenumber"" href=""showthread.php?threadid=3599372&amp;pagenumber=5"">5</a><a class=""pagenumber"" href=""showthread.php?threadid=3599372&amp;pagenumber=6"">6</a><a class=""pagenumber"" href=""showthread.php?threadid=3599372&amp;pagenumber=7"">7</a>... <a class=""pagenumber"" href=""showthread.php?threadid=3599372&amp;goto=lastpost"">Last</a></div>
			</div>
		</div>
	</td>
	<td class=""author""><a href=""member.php?action=getinfo&amp;userid=121559"">DemeaninDemon</a></td>
	<td class=""replies"">3762</td>
	<td class=""views"">309029</td>
	<td class=""rating""><img src=""http://fi.somethingawful.com/rate/default/4stars.gif"" alt="""" title=""42 votes - 4.35 average""></td>
	<td class=""lastpost""><div class=""date"">16:36 Mar 21, 2014</div><a class=""author"" href=""showthread.php?goto=lastpost&amp;threadid=3599372"">Plinkey</a></td>
</tr><tr class=""thread seen"" id=""thread3186581"">
	<td class=""star ""></td>
	<td class=""icon""><a href=""/forumdisplay.php?forumid=46&amp;posticon=78""><img src=""http://fi.somethingawful.com/forums/posticons/icons-08/help.png#78"" alt=""""></a></td>
	<td class=""title"">
		<div class=""title_inner"">
			<div class=""lastseen""><a href=""/showthread.php?action=resetseen&amp;threadid=3186581"" class=""x"" title=""Mark as unread"">X</a><a title=""Jump to last read post"" href=""/showthread.php?threadid=3186581&amp;goto=newpost"" class=""count""><b>22630</b></a></div>
			<div class=""info"">
				<a href=""showthread.php?threadid=3186581"" class=""thread_title"">Got a crazy forwarded political email from your family? Post them here.</a>
				<div class=""title_pages"">Pages: <a class=""pagenumber"" href=""showthread.php?threadid=3186581&amp;pagenumber=1"">1</a><a class=""pagenumber"" href=""showthread.php?threadid=3186581&amp;pagenumber=2"">2</a><a class=""pagenumber"" href=""showthread.php?threadid=3186581&amp;pagenumber=3"">3</a><a class=""pagenumber"" href=""showthread.php?threadid=3186581&amp;pagenumber=4"">4</a><a class=""pagenumber"" href=""showthread.php?threadid=3186581&amp;pagenumber=5"">5</a><a class=""pagenumber"" href=""showthread.php?threadid=3186581&amp;pagenumber=6"">6</a><a class=""pagenumber"" href=""showthread.php?threadid=3186581&amp;pagenumber=7"">7</a>... <a class=""pagenumber"" href=""showthread.php?threadid=3186581&amp;goto=lastpost"">Last</a></div>
			</div>
		</div>
	</td>
	<td class=""author""><a href=""member.php?action=getinfo&amp;userid=28262"">Vilerat</a></td>
	<td class=""replies"">38589</td>
	<td class=""views"">3969063</td>
	<td class=""rating""><img src=""http://fi.somethingawful.com/rate/default/4stars.gif"" alt="""" title=""241 votes - 4.09 average""></td>
	<td class=""lastpost""><div class=""date"">16:33 Mar 21, 2014</div><a class=""author"" href=""showthread.php?goto=lastpost&amp;threadid=3186581"">Mo_Steel</a></td>
</tr><tr class=""thread"" id=""thread3611893"">
	<td class=""star ""></td>
	<td class=""icon""><a href=""/forumdisplay.php?forumid=46&amp;posticon=256""><img src=""http://fi.somethingawful.com/forums/posticons/fyad-trout.gif#256"" alt=""""></a></td>
	<td class=""title"">
		<div class=""title_inner"">
			
			<div class=""info"">
				<a href=""showthread.php?threadid=3611893"" class=""thread_title"">Tasmanian Politics March: Fuck the Mainland Edition</a>
				<div class=""title_pages"">Pages: <a class=""pagenumber"" href=""showthread.php?threadid=3611893&amp;pagenumber=1"">1</a><a class=""pagenumber"" href=""showthread.php?threadid=3611893&amp;pagenumber=2"">2</a><a class=""pagenumber"" href=""showthread.php?threadid=3611893&amp;pagenumber=3"">3</a><a class=""pagenumber"" href=""showthread.php?threadid=3611893&amp;pagenumber=4"">4</a><a class=""pagenumber"" href=""showthread.php?threadid=3611893&amp;pagenumber=5"">5</a><a class=""pagenumber"" href=""showthread.php?threadid=3611893&amp;pagenumber=6"">6</a><a class=""pagenumber"" href=""showthread.php?threadid=3611893&amp;pagenumber=7"">7</a>... <a class=""pagenumber"" href=""showthread.php?threadid=3611893&amp;goto=lastpost"">Last</a></div>
			</div>
		</div>
	</td>
	<td class=""author""><a href=""member.php?action=getinfo&amp;userid=105372"">Coq au Nandos</a></td>
	<td class=""replies"">2611</td>
	<td class=""views"">95578</td>
	<td class=""rating""><img src=""http://fi.somethingawful.com/rate/default/4stars.gif"" alt="""" title=""17 votes - 3.72 average""></td>
	<td class=""lastpost""><div class=""date"">16:20 Mar 21, 2014</div><a class=""author"" href=""showthread.php?goto=lastpost&amp;threadid=3611893"">HookShot</a></td>
</tr><tr class=""thread seen"" id=""thread3512233"">
	<td class=""star ""></td>
	<td class=""icon""><a href=""/forumdisplay.php?forumid=46&amp;posticon=510""><img src=""http://fi.somethingawful.com/forums/posticons/lf-arecountry.gif#510"" alt=""""></a></td>
	<td class=""title"">
		<div class=""title_inner"">
			<div class=""lastseen""><a href=""/showthread.php?action=resetseen&amp;threadid=3512233"" class=""x"" title=""Mark as unread"">X</a><a title=""Jump to last read post"" href=""/showthread.php?threadid=3512233&amp;goto=newpost"" class=""count""><b>16422</b></a></div>
			<div class=""info"">
				<a href=""showthread.php?threadid=3512233"" class=""thread_title"">Dittoheads, Great Americans, Fairness and Balance - Right Wing Media</a>
				<div class=""title_pages"">Pages: <a class=""pagenumber"" href=""showthread.php?threadid=3512233&amp;pagenumber=1"">1</a><a class=""pagenumber"" href=""showthread.php?threadid=3512233&amp;pagenumber=2"">2</a><a class=""pagenumber"" href=""showthread.php?threadid=3512233&amp;pagenumber=3"">3</a><a class=""pagenumber"" href=""showthread.php?threadid=3512233&amp;pagenumber=4"">4</a><a class=""pagenumber"" href=""showthread.php?threadid=3512233&amp;pagenumber=5"">5</a><a class=""pagenumber"" href=""showthread.php?threadid=3512233&amp;pagenumber=6"">6</a><a class=""pagenumber"" href=""showthread.php?threadid=3512233&amp;pagenumber=7"">7</a>... <a class=""pagenumber"" href=""showthread.php?threadid=3512233&amp;goto=lastpost"">Last</a></div>
			</div>
		</div>
	</td>
	<td class=""author""><a href=""member.php?action=getinfo&amp;userid=125208"">BiggerBoat</a></td>
	<td class=""replies"">17701</td>
	<td class=""views"">1916425</td>
	<td class=""rating""><img src=""http://fi.somethingawful.com/rate/default/4stars.gif"" alt="""" title=""169 votes - 3.64 average""></td>
	<td class=""lastpost""><div class=""date"">16:00 Mar 21, 2014</div><a class=""author"" href=""showthread.php?goto=lastpost&amp;threadid=3512233"">joeburz</a></td>
</tr><tr class=""thread seen"" id=""thread3531615"">
	<td class=""star ""></td>
	<td class=""icon""><a href=""/forumdisplay.php?forumid=46&amp;posticon=213""><img src=""http://fi.somethingawful.com/forums/posticons/dd-history.gif#213"" alt=""""></a></td>
	<td class=""title"">
		<div class=""title_inner"">
			<div class=""lastseen""><a href=""/showthread.php?action=resetseen&amp;threadid=3531615"" class=""x"" title=""Mark as unread"">X</a><a title=""Jump to last read post"" href=""/showthread.php?threadid=3531615&amp;goto=newpost"" class=""count""><b>8210</b></a></div>
			<div class=""info"">
				<a href=""showthread.php?threadid=3531615"" class=""thread_title"">politically-loaded maps</a>
				<div class=""title_pages"">Pages: <a class=""pagenumber"" href=""showthread.php?threadid=3531615&amp;pagenumber=1"">1</a><a class=""pagenumber"" href=""showthread.php?threadid=3531615&amp;pagenumber=2"">2</a><a class=""pagenumber"" href=""showthread.php?threadid=3531615&amp;pagenumber=3"">3</a><a class=""pagenumber"" href=""showthread.php?threadid=3531615&amp;pagenumber=4"">4</a><a class=""pagenumber"" href=""showthread.php?threadid=3531615&amp;pagenumber=5"">5</a><a class=""pagenumber"" href=""showthread.php?threadid=3531615&amp;pagenumber=6"">6</a><a class=""pagenumber"" href=""showthread.php?threadid=3531615&amp;pagenumber=7"">7</a>... <a class=""pagenumber"" href=""showthread.php?threadid=3531615&amp;goto=lastpost"">Last</a></div>
			</div>
		</div>
	</td>
	<td class=""author""><a href=""member.php?action=getinfo&amp;userid=171819"">TheImmigrant</a></td>
	<td class=""replies"">8249</td>
	<td class=""views"">1034749</td>
	<td class=""rating""><img src=""http://fi.somethingawful.com/rate/default/4stars.gif"" alt="""" title=""90 votes - 3.89 average""></td>
	<td class=""lastpost""><div class=""date"">16:00 Mar 21, 2014</div><a class=""author"" href=""showthread.php?goto=lastpost&amp;threadid=3531615"">Kennel</a></td>
</tr><tr class=""thread"" id=""thread3569772"">
	<td class=""star ""></td>
	<td class=""icon""><a href=""/forumdisplay.php?forumid=46&amp;posticon=357""><img src=""http://fi.somethingawful.com/forums/posticons/dd-offmeds.jpg#357"" alt=""""></a></td>
	<td class=""title"">
		<div class=""title_inner"">
			
			<div class=""info"">
				<a href=""showthread.php?threadid=3569772"" class=""thread_title"">9/11 Trutherism and what I just can't figure out about the conspiracy crowd</a>
				<div class=""title_pages"">Pages: <a class=""pagenumber"" href=""showthread.php?threadid=3569772&amp;pagenumber=1"">1</a><a class=""pagenumber"" href=""showthread.php?threadid=3569772&amp;pagenumber=2"">2</a><a class=""pagenumber"" href=""showthread.php?threadid=3569772&amp;pagenumber=3"">3</a><a class=""pagenumber"" href=""showthread.php?threadid=3569772&amp;pagenumber=4"">4</a><a class=""pagenumber"" href=""showthread.php?threadid=3569772&amp;pagenumber=5"">5</a><a class=""pagenumber"" href=""showthread.php?threadid=3569772&amp;pagenumber=6"">6</a><a class=""pagenumber"" href=""showthread.php?threadid=3569772&amp;pagenumber=7"">7</a>... <a class=""pagenumber"" href=""showthread.php?threadid=3569772&amp;goto=lastpost"">Last</a></div>
			</div>
		</div>
	</td>
	<td class=""author""><a href=""member.php?action=getinfo&amp;userid=97562"">Rencall</a></td>
	<td class=""replies"">1616</td>
	<td class=""views"">132701</td>
	<td class=""rating""><img src=""http://fi.somethingawful.com/rate/default/3stars.gif"" alt="""" title=""17 votes - 3 average""></td>
	<td class=""lastpost""><div class=""date"">15:37 Mar 21, 2014</div><a class=""author"" href=""showthread.php?goto=lastpost&amp;threadid=3569772"">Evil Fluffy</a></td>
</tr><tr class=""thread"" id=""thread3612242"">
	<td class=""star ""></td>
	<td class=""icon""><a href=""/forumdisplay.php?forumid=46&amp;posticon=522""><img src=""http://fi.somethingawful.com/forums/posticons/lf-marx.png#522"" alt=""""></a></td>
	<td class=""title"">
		<div class=""title_inner"">
			
			<div class=""info"">
				<a href=""showthread.php?threadid=3612242"" class=""thread_title"">UKMT:  March'14 - Bingo And Beer For All</a>
				<div class=""title_pages"">Pages: <a class=""pagenumber"" href=""showthread.php?threadid=3612242&amp;pagenumber=1"">1</a><a class=""pagenumber"" href=""showthread.php?threadid=3612242&amp;pagenumber=2"">2</a><a class=""pagenumber"" href=""showthread.php?threadid=3612242&amp;pagenumber=3"">3</a><a class=""pagenumber"" href=""showthread.php?threadid=3612242&amp;pagenumber=4"">4</a><a class=""pagenumber"" href=""showthread.php?threadid=3612242&amp;pagenumber=5"">5</a><a class=""pagenumber"" href=""showthread.php?threadid=3612242&amp;pagenumber=6"">6</a><a class=""pagenumber"" href=""showthread.php?threadid=3612242&amp;pagenumber=7"">7</a>... <a class=""pagenumber"" href=""showthread.php?threadid=3612242&amp;goto=lastpost"">Last</a></div>
			</div>
		</div>
	</td>
	<td class=""author""><a href=""member.php?action=getinfo&amp;userid=170126"">Ferrosol</a></td>
	<td class=""replies"">1604</td>
	<td class=""views"">91790</td>
	<td class=""rating"">&nbsp;</td>
	<td class=""lastpost""><div class=""date"">15:32 Mar 21, 2014</div><a class=""author"" href=""showthread.php?goto=lastpost&amp;threadid=3612242"">Not Operator</a></td>
</tr><tr class=""thread seen"" id=""thread3543938"">
	<td class=""star ""></td>
	<td class=""icon""><a href=""/forumdisplay.php?forumid=46&amp;posticon=522""><img src=""http://fi.somethingawful.com/forums/posticons/lf-marx.png#522"" alt=""""></a></td>
	<td class=""title"">
		<div class=""title_inner"">
			<div class=""lastseen""><a href=""/showthread.php?action=resetseen&amp;threadid=3543938"" class=""x"" title=""Mark as unread"">X</a><a title=""Jump to last read post"" href=""/showthread.php?threadid=3543938&amp;goto=newpost"" class=""count""><b>1964</b></a></div>
			<div class=""info"">
				<a href=""showthread.php?threadid=3543938"" class=""thread_title"">Marxism Megathread: commodity fetishism, everything to do with it</a>
				<div class=""title_pages"">Pages: <a class=""pagenumber"" href=""showthread.php?threadid=3543938&amp;pagenumber=1"">1</a><a class=""pagenumber"" href=""showthread.php?threadid=3543938&amp;pagenumber=2"">2</a><a class=""pagenumber"" href=""showthread.php?threadid=3543938&amp;pagenumber=3"">3</a><a class=""pagenumber"" href=""showthread.php?threadid=3543938&amp;pagenumber=4"">4</a><a class=""pagenumber"" href=""showthread.php?threadid=3543938&amp;pagenumber=5"">5</a><a class=""pagenumber"" href=""showthread.php?threadid=3543938&amp;pagenumber=6"">6</a><a class=""pagenumber"" href=""showthread.php?threadid=3543938&amp;pagenumber=7"">7</a>... <a class=""pagenumber"" href=""showthread.php?threadid=3543938&amp;goto=lastpost"">Last</a></div>
			</div>
		</div>
	</td>
	<td class=""author""><a href=""member.php?action=getinfo&amp;userid=190494"">Prism Mirror Lens</a></td>
	<td class=""replies"">3226</td>
	<td class=""views"">275451</td>
	<td class=""rating""><img src=""http://fi.somethingawful.com/rate/default/3stars.gif"" alt="""" title=""90 votes - 3.35 average""></td>
	<td class=""lastpost""><div class=""date"">15:22 Mar 21, 2014</div><a class=""author"" href=""showthread.php?goto=lastpost&amp;threadid=3543938"">rscott</a></td>
</tr><tr class=""thread"" id=""thread3598750"">
	<td class=""star ""></td>
	<td class=""icon""><a href=""/forumdisplay.php?forumid=46&amp;posticon=695""><img src=""http://fi.somethingawful.com/forums/posticons/dd-GOP.gif#695"" alt=""""></a></td>
	<td class=""title"">
		<div class=""title_inner"">
			
			<div class=""info"">
				<a href=""showthread.php?threadid=3598750"" class=""thread_title"">Let's talk about the ideology of Charles Koch and its repercussions</a>
				<div class=""title_pages"">Pages: <a class=""pagenumber"" href=""showthread.php?threadid=3598750&amp;pagenumber=1"">1</a><a class=""pagenumber"" href=""showthread.php?threadid=3598750&amp;pagenumber=2"">2</a><a class=""pagenumber"" href=""showthread.php?threadid=3598750&amp;pagenumber=3"">3</a><a class=""pagenumber"" href=""showthread.php?threadid=3598750&amp;pagenumber=4"">4</a><a class=""pagenumber"" href=""showthread.php?threadid=3598750&amp;pagenumber=5"">5</a><a class=""pagenumber"" href=""showthread.php?threadid=3598750&amp;pagenumber=6"">6</a></div>
			</div>
		</div>
	</td>
	<td class=""author""><a href=""member.php?action=getinfo&amp;userid=91236"">BrandorKP</a></td>
	<td class=""replies"">209</td>
	<td class=""views"">19734</td>
	<td class=""rating"">&nbsp;</td>
	<td class=""lastpost""><div class=""date"">15:18 Mar 21, 2014</div><a class=""author"" href=""showthread.php?goto=lastpost&amp;threadid=3598750"">OwlBot 2000</a></td>
</tr><tr class=""thread"" id=""thread3390388"">
	<td class=""star ""></td>
	<td class=""icon""><a href=""/forumdisplay.php?forumid=46&amp;posticon=359""><img src=""http://fi.somethingawful.com/forums/posticons/dd-war.gif#359"" alt=""""></a></td>
	<td class=""title"">
		<div class=""title_inner"">
			
			<div class=""info"">
				<a href=""showthread.php?threadid=3390388"" class=""thread_title"">The Middle East: Freedom Muffins</a>
				<div class=""title_pages"">Pages: <a class=""pagenumber"" href=""showthread.php?threadid=3390388&amp;pagenumber=1"">1</a><a class=""pagenumber"" href=""showthread.php?threadid=3390388&amp;pagenumber=2"">2</a><a class=""pagenumber"" href=""showthread.php?threadid=3390388&amp;pagenumber=3"">3</a><a class=""pagenumber"" href=""showthread.php?threadid=3390388&amp;pagenumber=4"">4</a><a class=""pagenumber"" href=""showthread.php?threadid=3390388&amp;pagenumber=5"">5</a><a class=""pagenumber"" href=""showthread.php?threadid=3390388&amp;pagenumber=6"">6</a><a class=""pagenumber"" href=""showthread.php?threadid=3390388&amp;pagenumber=7"">7</a>... <a class=""pagenumber"" href=""showthread.php?threadid=3390388&amp;goto=lastpost"">Last</a></div>
			</div>
		</div>
	</td>
	<td class=""author""><a href=""member.php?action=getinfo&amp;userid=135346"">Lascivious Sloth</a></td>
	<td class=""replies"">54911</td>
	<td class=""views"">4411192</td>
	<td class=""rating""><img src=""http://fi.somethingawful.com/rate/default/4stars.gif"" alt="""" title=""351 votes - 3.93 average""></td>
	<td class=""lastpost""><div class=""date"">15:11 Mar 21, 2014</div><a class=""author"" href=""showthread.php?goto=lastpost&amp;threadid=3390388"">The X-man cometh</a></td>
</tr><tr class=""thread"" id=""thread3574354"">
	<td class=""star ""></td>
	<td class=""icon""><a href=""/forumdisplay.php?forumid=46&amp;posticon=105""><img src=""http://fi.somethingawful.com/forums/posticons/icons-08/tech.png#105"" alt=""""></a></td>
	<td class=""title"">
		<div class=""title_inner"">
			
			<div class=""info"">
				<a href=""showthread.php?threadid=3574354"" class=""thread_title"">Surveillance in the 21st Century: Press CTRL-C to Copy the Internet (NSA Thread)</a>
				<div class=""title_pages"">Pages: <a class=""pagenumber"" href=""showthread.php?threadid=3574354&amp;pagenumber=1"">1</a><a class=""pagenumber"" href=""showthread.php?threadid=3574354&amp;pagenumber=2"">2</a><a class=""pagenumber"" href=""showthread.php?threadid=3574354&amp;pagenumber=3"">3</a><a class=""pagenumber"" href=""showthread.php?threadid=3574354&amp;pagenumber=4"">4</a><a class=""pagenumber"" href=""showthread.php?threadid=3574354&amp;pagenumber=5"">5</a><a class=""pagenumber"" href=""showthread.php?threadid=3574354&amp;pagenumber=6"">6</a><a class=""pagenumber"" href=""showthread.php?threadid=3574354&amp;pagenumber=7"">7</a>... <a class=""pagenumber"" href=""showthread.php?threadid=3574354&amp;goto=lastpost"">Last</a></div>
			</div>
		</div>
	</td>
	<td class=""author""><a href=""member.php?action=getinfo&amp;userid=174166"">Aurubin</a></td>
	<td class=""replies"">1330</td>
	<td class=""views"">116487</td>
	<td class=""rating""><img src=""http://fi.somethingawful.com/rate/default/4stars.gif"" alt="""" title=""28 votes - 3.83 average""></td>
	<td class=""lastpost""><div class=""date"">15:09 Mar 21, 2014</div><a class=""author"" href=""showthread.php?goto=lastpost&amp;threadid=3574354"">UberJew</a></td>
</tr><tr class=""thread"" id=""thread3618452"">
	<td class=""star ""></td>
	<td class=""icon""><a href=""/forumdisplay.php?forumid=46&amp;posticon=81""><img src=""http://fi.somethingawful.com/forums/posticons/icons-08/fruity.png#81"" alt=""""></a></td>
	<td class=""title"">
		<div class=""title_inner"">
			
			<div class=""info"">
				<a href=""showthread.php?threadid=3618452"" class=""thread_title"">God Hates Fred Phelps</a>
				
			</div>
		</div>
	</td>
	<td class=""author""><a href=""member.php?action=getinfo&amp;userid=33633"">teejayh</a></td>
	<td class=""replies"">36</td>
	<td class=""views"">1444</td>
	<td class=""rating"">&nbsp;</td>
	<td class=""lastpost""><div class=""date"">15:06 Mar 21, 2014</div><a class=""author"" href=""showthread.php?goto=lastpost&amp;threadid=3618452"">SedanChair</a></td>
</tr><tr class=""thread seen"" id=""thread3516197"">
	<td class=""star ""></td>
	<td class=""icon""><a href=""/forumdisplay.php?forumid=46&amp;posticon=629""><img src=""http://fi.somethingawful.com/forums/posticons/LF-purestrain2.gif#629"" alt=""""></a></td>
	<td class=""title"">
		<div class=""title_inner"">
			<div class=""lastseen""><a href=""/showthread.php?action=resetseen&amp;threadid=3516197"" class=""x"" title=""Mark as unread"">X</a><a title=""Jump to last read post"" href=""/showthread.php?threadid=3516197&amp;goto=newpost"" class=""count""><b>4538</b></a></div>
			<div class=""info"">
				<a href=""showthread.php?threadid=3516197"" class=""thread_title"">2016 Presidential Primaries: Senator Agua Bottle vs Senator Aqua Buddha</a>
				<div class=""title_pages"">Pages: <a class=""pagenumber"" href=""showthread.php?threadid=3516197&amp;pagenumber=1"">1</a><a class=""pagenumber"" href=""showthread.php?threadid=3516197&amp;pagenumber=2"">2</a><a class=""pagenumber"" href=""showthread.php?threadid=3516197&amp;pagenumber=3"">3</a><a class=""pagenumber"" href=""showthread.php?threadid=3516197&amp;pagenumber=4"">4</a><a class=""pagenumber"" href=""showthread.php?threadid=3516197&amp;pagenumber=5"">5</a><a class=""pagenumber"" href=""showthread.php?threadid=3516197&amp;pagenumber=6"">6</a><a class=""pagenumber"" href=""showthread.php?threadid=3516197&amp;pagenumber=7"">7</a>... <a class=""pagenumber"" href=""showthread.php?threadid=3516197&amp;goto=lastpost"">Last</a></div>
			</div>
		</div>
	</td>
	<td class=""author""><a href=""member.php?action=getinfo&amp;userid=55496"">Joementum</a></td>
	<td class=""replies"">6137</td>
	<td class=""views"">629355</td>
	<td class=""rating""><img src=""http://fi.somethingawful.com/rate/default/4stars.gif"" alt="""" title=""61 votes - 3.52 average""></td>
	<td class=""lastpost""><div class=""date"">14:15 Mar 21, 2014</div><a class=""author"" href=""showthread.php?goto=lastpost&amp;threadid=3516197"">The Warszawa</a></td>
</tr><tr class=""thread"" id=""thread3540057"">
	<td class=""star ""></td>
	<td class=""icon""><a href=""/forumdisplay.php?forumid=46&amp;posticon=510""><img src=""http://fi.somethingawful.com/forums/posticons/lf-arecountry.gif#510"" alt=""""></a></td>
	<td class=""title"">
		<div class=""title_inner"">
			
			<div class=""info"">
				<a href=""showthread.php?threadid=3540057"" class=""thread_title"">PPACA Discussion Thread: 2014 brings the Obamacolypse!</a>
				<div class=""title_pages"">Pages: <a class=""pagenumber"" href=""showthread.php?threadid=3540057&amp;pagenumber=1"">1</a><a class=""pagenumber"" href=""showthread.php?threadid=3540057&amp;pagenumber=2"">2</a><a class=""pagenumber"" href=""showthread.php?threadid=3540057&amp;pagenumber=3"">3</a><a class=""pagenumber"" href=""showthread.php?threadid=3540057&amp;pagenumber=4"">4</a><a class=""pagenumber"" href=""showthread.php?threadid=3540057&amp;pagenumber=5"">5</a><a class=""pagenumber"" href=""showthread.php?threadid=3540057&amp;pagenumber=6"">6</a><a class=""pagenumber"" href=""showthread.php?threadid=3540057&amp;pagenumber=7"">7</a>... <a class=""pagenumber"" href=""showthread.php?threadid=3540057&amp;goto=lastpost"">Last</a></div>
			</div>
		</div>
	</td>
	<td class=""author""><a href=""member.php?action=getinfo&amp;userid=46351"">Sarion</a></td>
	<td class=""replies"">4361</td>
	<td class=""views"">255032</td>
	<td class=""rating""><img src=""http://fi.somethingawful.com/rate/default/4stars.gif"" alt="""" title=""29 votes - 3.68 average""></td>
	<td class=""lastpost""><div class=""date"">13:43 Mar 21, 2014</div><a class=""author"" href=""showthread.php?goto=lastpost&amp;threadid=3540057"">Mr. Nice!</a></td>
</tr><tr class=""thread"" id=""thread3613532"">
	<td class=""star ""></td>
	<td class=""icon""><a href=""/forumdisplay.php?forumid=46&amp;posticon=576""><img src=""http://fi.somethingawful.com/forums/posticons/lan-canada.gif#576"" alt=""""></a></td>
	<td class=""title"">
		<div class=""title_inner"">
			
			<div class=""info"">
				<a href=""showthread.php?threadid=3613532"" class=""thread_title"">Quebec election 2014 - PQ majoritaire, pas l'temps d'niaiser</a>
				<div class=""title_pages"">Pages: <a class=""pagenumber"" href=""showthread.php?threadid=3613532&amp;pagenumber=1"">1</a><a class=""pagenumber"" href=""showthread.php?threadid=3613532&amp;pagenumber=2"">2</a><a class=""pagenumber"" href=""showthread.php?threadid=3613532&amp;pagenumber=3"">3</a><a class=""pagenumber"" href=""showthread.php?threadid=3613532&amp;pagenumber=4"">4</a></div>
			</div>
		</div>
	</td>
	<td class=""author""><a href=""member.php?action=getinfo&amp;userid=152820"">Pinterest Mom</a></td>
	<td class=""replies"">154</td>
	<td class=""views"">7298</td>
	<td class=""rating"">&nbsp;</td>
	<td class=""lastpost""><div class=""date"">13:38 Mar 21, 2014</div><a class=""author"" href=""showthread.php?goto=lastpost&amp;threadid=3613532"">Kurtofan</a></td>
</tr><tr class=""thread seen"" id=""thread3453503"">
	<td class=""star ""></td>
	<td class=""icon""><a href=""/forumdisplay.php?forumid=46&amp;posticon=358""><img src=""http://fi.somethingawful.com/forums/posticons/dd-environment.gif#358"" alt=""""></a></td>
	<td class=""title"">
		<div class=""title_inner"">
			<div class=""lastseen""><a href=""/showthread.php?action=resetseen&amp;threadid=3453503"" class=""x"" title=""Mark as unread"">X</a><a title=""Jump to last read post"" href=""/showthread.php?threadid=3453503&amp;goto=newpost"" class=""count""><b>2402</b></a></div>
			<div class=""info"">
				<a href=""showthread.php?threadid=3453503"" class=""thread_title"">Climate Change thread: tl; dr - We are so screwed</a>
				<div class=""title_pages"">Pages: <a class=""pagenumber"" href=""showthread.php?threadid=3453503&amp;pagenumber=1"">1</a><a class=""pagenumber"" href=""showthread.php?threadid=3453503&amp;pagenumber=2"">2</a><a class=""pagenumber"" href=""showthread.php?threadid=3453503&amp;pagenumber=3"">3</a><a class=""pagenumber"" href=""showthread.php?threadid=3453503&amp;pagenumber=4"">4</a><a class=""pagenumber"" href=""showthread.php?threadid=3453503&amp;pagenumber=5"">5</a><a class=""pagenumber"" href=""showthread.php?threadid=3453503&amp;pagenumber=6"">6</a><a class=""pagenumber"" href=""showthread.php?threadid=3453503&amp;pagenumber=7"">7</a>... <a class=""pagenumber"" href=""showthread.php?threadid=3453503&amp;goto=lastpost"">Last</a></div>
			</div>
		</div>
	</td>
	<td class=""author""><a href=""member.php?action=getinfo&amp;userid=171567"">Fried Chicken</a></td>
	<td class=""replies"">5350</td>
	<td class=""views"">523331</td>
	<td class=""rating""><img src=""http://fi.somethingawful.com/rate/default/3stars.gif"" alt="""" title=""126 votes - 3.19 average""></td>
	<td class=""lastpost""><div class=""date"">13:28 Mar 21, 2014</div><a class=""author"" href=""showthread.php?goto=lastpost&amp;threadid=3453503"">Dusz</a></td>
</tr><tr class=""thread seen"" id=""thread3534475"">
	<td class=""star ""></td>
	<td class=""icon""><a href=""/forumdisplay.php?forumid=46&amp;posticon=573""><img src=""http://fi.somethingawful.com/forums/posticons/lan-midwest.gif#573"" alt=""""></a></td>
	<td class=""title"">
		<div class=""title_inner"">
			<div class=""lastseen""><a href=""/showthread.php?action=resetseen&amp;threadid=3534475"" class=""x"" title=""Mark as unread"">X</a><a title=""Jump to last read post"" href=""/showthread.php?threadid=3534475&amp;goto=newpost"" class=""count""><b>4623</b></a></div>
			<div class=""info"">
				<a href=""showthread.php?threadid=3534475"" class=""thread_title"">2014 US Midterms: Apparently nobody's running for President. Weird.</a>
				<div class=""title_pages"">Pages: <a class=""pagenumber"" href=""showthread.php?threadid=3534475&amp;pagenumber=1"">1</a><a class=""pagenumber"" href=""showthread.php?threadid=3534475&amp;pagenumber=2"">2</a><a class=""pagenumber"" href=""showthread.php?threadid=3534475&amp;pagenumber=3"">3</a><a class=""pagenumber"" href=""showthread.php?threadid=3534475&amp;pagenumber=4"">4</a><a class=""pagenumber"" href=""showthread.php?threadid=3534475&amp;pagenumber=5"">5</a><a class=""pagenumber"" href=""showthread.php?threadid=3534475&amp;pagenumber=6"">6</a><a class=""pagenumber"" href=""showthread.php?threadid=3534475&amp;pagenumber=7"">7</a>... <a class=""pagenumber"" href=""showthread.php?threadid=3534475&amp;goto=lastpost"">Last</a></div>
			</div>
		</div>
	</td>
	<td class=""author""><a href=""member.php?action=getinfo&amp;userid=55496"">Joementum</a></td>
	<td class=""replies"">4736</td>
	<td class=""views"">398848</td>
	<td class=""rating""><img src=""http://fi.somethingawful.com/rate/default/3stars.gif"" alt="""" title=""48 votes - 3.41 average""></td>
	<td class=""lastpost""><div class=""date"">13:14 Mar 21, 2014</div><a class=""author"" href=""showthread.php?goto=lastpost&amp;threadid=3534475"">FAUXTON</a></td>
</tr><tr class=""thread"" id=""thread3607781"">
	<td class=""star ""></td>
	<td class=""icon""><a href=""/forumdisplay.php?forumid=46&amp;posticon=0""><img src=""http://fi.somethingawful.com/images/shitpost.gif#0"" alt=""""></a></td>
	<td class=""title"">
		<div class=""title_inner"">
			
			<div class=""info"">
				<a href=""showthread.php?threadid=3607781"" class=""thread_title"">Simulations and Mathematical universes</a>
				<div class=""title_pages"">Pages: <a class=""pagenumber"" href=""showthread.php?threadid=3607781&amp;pagenumber=1"">1</a><a class=""pagenumber"" href=""showthread.php?threadid=3607781&amp;pagenumber=2"">2</a><a class=""pagenumber"" href=""showthread.php?threadid=3607781&amp;pagenumber=3"">3</a></div>
			</div>
		</div>
	</td>
	<td class=""author""><a href=""member.php?action=getinfo&amp;userid=141252"">mrParkbench</a></td>
	<td class=""replies"">114</td>
	<td class=""views"">6949</td>
	<td class=""rating"">&nbsp;</td>
	<td class=""lastpost""><div class=""date"">13:08 Mar 21, 2014</div><a class=""author"" href=""showthread.php?goto=lastpost&amp;threadid=3607781"">mrParkbench</a></td>
</tr><tr class=""thread seen"" id=""thread3510719"">
	<td class=""star ""></td>
	<td class=""icon""><a href=""/forumdisplay.php?forumid=46&amp;posticon=183""><img src=""http://fi.somethingawful.com/forums/posticons/guns-ohshi.gif#183"" alt=""""></a></td>
	<td class=""title"">
		<div class=""title_inner"">
			<div class=""lastseen""><a href=""/showthread.php?action=resetseen&amp;threadid=3510719"" class=""x"" title=""Mark as unread"">X</a><a title=""Jump to last read post"" href=""/showthread.php?threadid=3510719&amp;goto=newpost"" class=""count""><b>2355</b></a></div>
			<div class=""info"">
				<a href=""showthread.php?threadid=3510719"" class=""thread_title"">Venezuelan elections - Dead Chavez Edition</a>
				<div class=""title_pages"">Pages: <a class=""pagenumber"" href=""showthread.php?threadid=3510719&amp;pagenumber=1"">1</a><a class=""pagenumber"" href=""showthread.php?threadid=3510719&amp;pagenumber=2"">2</a><a class=""pagenumber"" href=""showthread.php?threadid=3510719&amp;pagenumber=3"">3</a><a class=""pagenumber"" href=""showthread.php?threadid=3510719&amp;pagenumber=4"">4</a><a class=""pagenumber"" href=""showthread.php?threadid=3510719&amp;pagenumber=5"">5</a><a class=""pagenumber"" href=""showthread.php?threadid=3510719&amp;pagenumber=6"">6</a><a class=""pagenumber"" href=""showthread.php?threadid=3510719&amp;pagenumber=7"">7</a>... <a class=""pagenumber"" href=""showthread.php?threadid=3510719&amp;goto=lastpost"">Last</a></div>
			</div>
		</div>
	</td>
	<td class=""author""><a href=""member.php?action=getinfo&amp;userid=119098"">a bad enough dude</a></td>
	<td class=""replies"">3065</td>
	<td class=""views"">173889</td>
	<td class=""rating""><img src=""http://fi.somethingawful.com/rate/default/3stars.gif"" alt="""" title=""65 votes - 2.64 average""></td>
	<td class=""lastpost""><div class=""date"">12:30 Mar 21, 2014</div><a class=""author"" href=""showthread.php?goto=lastpost&amp;threadid=3510719"">Mans</a></td>
</tr><tr class=""thread"" id=""thread3522799"">
	<td class=""star ""></td>
	<td class=""icon""><a href=""/forumdisplay.php?forumid=46&amp;posticon=89""><img src=""http://fi.somethingawful.com/forums/posticons/icons-08/humor.png#89"" alt=""""></a></td>
	<td class=""title"">
		<div class=""title_inner"">
			
			<div class=""info"">
				<a href=""showthread.php?threadid=3522799"" class=""thread_title"">UK Political Cartoons Mega Thread Part 3</a>
				<div class=""title_pages"">Pages: <a class=""pagenumber"" href=""showthread.php?threadid=3522799&amp;pagenumber=1"">1</a><a class=""pagenumber"" href=""showthread.php?threadid=3522799&amp;pagenumber=2"">2</a><a class=""pagenumber"" href=""showthread.php?threadid=3522799&amp;pagenumber=3"">3</a><a class=""pagenumber"" href=""showthread.php?threadid=3522799&amp;pagenumber=4"">4</a><a class=""pagenumber"" href=""showthread.php?threadid=3522799&amp;pagenumber=5"">5</a><a class=""pagenumber"" href=""showthread.php?threadid=3522799&amp;pagenumber=6"">6</a><a class=""pagenumber"" href=""showthread.php?threadid=3522799&amp;pagenumber=7"">7</a>... <a class=""pagenumber"" href=""showthread.php?threadid=3522799&amp;goto=lastpost"">Last</a></div>
			</div>
		</div>
	</td>
	<td class=""author""><a href=""member.php?action=getinfo&amp;userid=117453"">Fluo</a></td>
	<td class=""replies"">3336</td>
	<td class=""views"">288604</td>
	<td class=""rating""><img src=""http://fi.somethingawful.com/rate/default/4stars.gif"" alt="""" title=""40 votes - 3.76 average""></td>
	<td class=""lastpost""><div class=""date"">11:31 Mar 21, 2014</div><a class=""author"" href=""showthread.php?goto=lastpost&amp;threadid=3522799"">baka kaba</a></td>
</tr><tr class=""thread"" id=""thread3461540"">
	<td class=""star ""></td>
	<td class=""icon""><a href=""/forumdisplay.php?forumid=46&amp;posticon=579""><img src=""http://fi.somethingawful.com/forums/posticons/lan-south.gif#579"" alt=""""></a></td>
	<td class=""title"">
		<div class=""title_inner"">
			
			<div class=""info"">
				<a href=""showthread.php?threadid=3461540"" class=""thread_title"">New Zealand Megathread - Electorate Rackets and Designer Jackets</a>
				<div class=""title_pages"">Pages: <a class=""pagenumber"" href=""showthread.php?threadid=3461540&amp;pagenumber=1"">1</a><a class=""pagenumber"" href=""showthread.php?threadid=3461540&amp;pagenumber=2"">2</a><a class=""pagenumber"" href=""showthread.php?threadid=3461540&amp;pagenumber=3"">3</a><a class=""pagenumber"" href=""showthread.php?threadid=3461540&amp;pagenumber=4"">4</a><a class=""pagenumber"" href=""showthread.php?threadid=3461540&amp;pagenumber=5"">5</a><a class=""pagenumber"" href=""showthread.php?threadid=3461540&amp;pagenumber=6"">6</a><a class=""pagenumber"" href=""showthread.php?threadid=3461540&amp;pagenumber=7"">7</a>... <a class=""pagenumber"" href=""showthread.php?threadid=3461540&amp;goto=lastpost"">Last</a></div>
			</div>
		</div>
	</td>
	<td class=""author""><a href=""member.php?action=getinfo&amp;userid=86747"">ClubmanGT</a></td>
	<td class=""replies"">8876</td>
	<td class=""views"">323826</td>
	<td class=""rating""><img src=""http://fi.somethingawful.com/rate/default/4stars.gif"" alt="""" title=""30 votes - 3.73 average""></td>
	<td class=""lastpost""><div class=""date"">11:22 Mar 21, 2014</div><a class=""author"" href=""showthread.php?goto=lastpost&amp;threadid=3461540"">Butt Wizard</a></td>
</tr><tr class=""thread"" id=""thread3617580"">
	<td class=""star ""></td>
	<td class=""icon""><a href=""/forumdisplay.php?forumid=46&amp;posticon=362""><img src=""http://fi.somethingawful.com/forums/posticons/dd-asia.gif#362"" alt=""""></a></td>
	<td class=""title"">
		<div class=""title_inner"">
			
			<div class=""info"">
				<a href=""showthread.php?threadid=3617580"" class=""thread_title"">China Economy Megathread</a>
				<div class=""title_pages"">Pages: <a class=""pagenumber"" href=""showthread.php?threadid=3617580&amp;pagenumber=1"">1</a><a class=""pagenumber"" href=""showthread.php?threadid=3617580&amp;pagenumber=2"">2</a></div>
			</div>
		</div>
	</td>
	<td class=""author""><a href=""member.php?action=getinfo&amp;userid=64202"">Cultural Imperial</a></td>
	<td class=""replies"">74</td>
	<td class=""views"">3909</td>
	<td class=""rating"">&nbsp;</td>
	<td class=""lastpost""><div class=""date"">11:19 Mar 21, 2014</div><a class=""author"" href=""showthread.php?goto=lastpost&amp;threadid=3617580"">Typo</a></td>
</tr><tr class=""thread"" id=""thread3511253"">
	<td class=""star ""></td>
	<td class=""icon""><a href=""/forumdisplay.php?forumid=46&amp;posticon=122""><img src=""http://fi.somethingawful.com/forums/posticons/icons-08/drugs.png#122"" alt=""""></a></td>
	<td class=""title"">
		<div class=""title_inner"">
			
			<div class=""info"">
				<a href=""showthread.php?threadid=3511253"" class=""thread_title"">Full marijuana legalization: what happens if Colorado passes it?</a>
				<div class=""title_pages"">Pages: <a class=""pagenumber"" href=""showthread.php?threadid=3511253&amp;pagenumber=1"">1</a><a class=""pagenumber"" href=""showthread.php?threadid=3511253&amp;pagenumber=2"">2</a><a class=""pagenumber"" href=""showthread.php?threadid=3511253&amp;pagenumber=3"">3</a><a class=""pagenumber"" href=""showthread.php?threadid=3511253&amp;pagenumber=4"">4</a><a class=""pagenumber"" href=""showthread.php?threadid=3511253&amp;pagenumber=5"">5</a><a class=""pagenumber"" href=""showthread.php?threadid=3511253&amp;pagenumber=6"">6</a><a class=""pagenumber"" href=""showthread.php?threadid=3511253&amp;pagenumber=7"">7</a>... <a class=""pagenumber"" href=""showthread.php?threadid=3511253&amp;goto=lastpost"">Last</a></div>
			</div>
		</div>
	</td>
	<td class=""author""><a href=""member.php?action=getinfo&amp;userid=137115"">showbiz_liz</a></td>
	<td class=""replies"">5679</td>
	<td class=""views"">466699</td>
	<td class=""rating""><img src=""http://fi.somethingawful.com/rate/default/3stars.gif"" alt="""" title=""64 votes - 3.31 average""></td>
	<td class=""lastpost""><div class=""date"">11:03 Mar 21, 2014</div><a class=""author"" href=""showthread.php?goto=lastpost&amp;threadid=3511253"">TACD</a></td>
</tr><tr class=""thread seen closed"" id=""thread3586795"">
	<td class=""star ""></td>
	<td class=""icon""><a href=""/forumdisplay.php?forumid=46&amp;posticon=183""><img src=""http://fi.somethingawful.com/forums/posticons/guns-ohshi.gif#183"" alt=""""></a></td>
	<td class=""title"">
		<div class=""title_inner"">
			<div class=""lastseen""><a href=""/showthread.php?action=resetseen&amp;threadid=3586795"" class=""x"" title=""Mark as unread"">X</a><a title=""Jump to last read post"" href=""/showthread.php?threadid=3586795&amp;goto=newpost"" class=""count""><b>15891</b></a></div>
			<div class=""info"">
				<a href=""showthread.php?threadid=3586795"" class=""thread_title"">Eastern Europe: Crimea River, Build Me A Bridge</a>
				<div class=""title_pages"">Pages: <a class=""pagenumber"" href=""showthread.php?threadid=3586795&amp;pagenumber=1"">1</a><a class=""pagenumber"" href=""showthread.php?threadid=3586795&amp;pagenumber=2"">2</a><a class=""pagenumber"" href=""showthread.php?threadid=3586795&amp;pagenumber=3"">3</a><a class=""pagenumber"" href=""showthread.php?threadid=3586795&amp;pagenumber=4"">4</a><a class=""pagenumber"" href=""showthread.php?threadid=3586795&amp;pagenumber=5"">5</a><a class=""pagenumber"" href=""showthread.php?threadid=3586795&amp;pagenumber=6"">6</a><a class=""pagenumber"" href=""showthread.php?threadid=3586795&amp;pagenumber=7"">7</a>... <a class=""pagenumber"" href=""showthread.php?threadid=3586795&amp;goto=lastpost"">Last</a></div>
			</div>
		</div>
	</td>
	<td class=""author""><a href=""member.php?action=getinfo&amp;userid=78116"">HUGE PUBES A PLUS</a></td>
	<td class=""replies"">16010</td>
	<td class=""views"">1180599</td>
	<td class=""rating""><img src=""http://fi.somethingawful.com/rate/default/3stars.gif"" alt="""" title=""110 votes - 3.24 average""></td>
	<td class=""lastpost""><div class=""date"">09:27 Mar 21, 2014</div><a class=""author"" href=""showthread.php?goto=lastpost&amp;threadid=3586795"">HUGE PUBES A PLUS</a></td>
</tr><tr class=""thread seen"" id=""thread3412241"">
	<td class=""star ""></td>
	<td class=""icon""><a href=""/forumdisplay.php?forumid=46&amp;posticon=695""><img src=""http://fi.somethingawful.com/forums/posticons/dd-GOP.gif#695"" alt=""""></a></td>
	<td class=""title"">
		<div class=""title_inner"">
			<div class=""lastseen""><a href=""/showthread.php?action=resetseen&amp;threadid=3412241"" class=""x"" title=""Mark as unread"">X</a><a title=""Jump to last read post"" href=""/showthread.php?threadid=3412241&amp;goto=newpost"" class=""count""><b>11106</b></a></div>
			<div class=""info"">
				<a href=""showthread.php?threadid=3412241"" class=""thread_title"">The Best (Worst) Of Conservapedia</a>
				<div class=""title_pages"">Pages: <a class=""pagenumber"" href=""showthread.php?threadid=3412241&amp;pagenumber=1"">1</a><a class=""pagenumber"" href=""showthread.php?threadid=3412241&amp;pagenumber=2"">2</a><a class=""pagenumber"" href=""showthread.php?threadid=3412241&amp;pagenumber=3"">3</a><a class=""pagenumber"" href=""showthread.php?threadid=3412241&amp;pagenumber=4"">4</a><a class=""pagenumber"" href=""showthread.php?threadid=3412241&amp;pagenumber=5"">5</a><a class=""pagenumber"" href=""showthread.php?threadid=3412241&amp;pagenumber=6"">6</a><a class=""pagenumber"" href=""showthread.php?threadid=3412241&amp;pagenumber=7"">7</a>... <a class=""pagenumber"" href=""showthread.php?threadid=3412241&amp;goto=lastpost"">Last</a></div>
			</div>
		</div>
	</td>
	<td class=""author""><a href=""member.php?action=getinfo&amp;userid=30166"">Fire</a></td>
	<td class=""replies"">11185</td>
	<td class=""views"">1322375</td>
	<td class=""rating""><img src=""http://fi.somethingawful.com/rate/default/4stars.gif"" alt="""" title=""113 votes - 3.7 average""></td>
	<td class=""lastpost""><div class=""date"">08:26 Mar 21, 2014</div><a class=""author"" href=""showthread.php?goto=lastpost&amp;threadid=3412241"">William Bear</a></td>
</tr><tr class=""thread seen"" id=""thread3533827"">
	<td class=""star ""></td>
	<td class=""icon""><a href=""/forumdisplay.php?forumid=46&amp;posticon=576""><img src=""http://fi.somethingawful.com/forums/posticons/lan-canada.gif#576"" alt=""""></a></td>
	<td class=""title"">
		<div class=""title_inner"">
			<div class=""lastseen""><a href=""/showthread.php?action=resetseen&amp;threadid=3533827"" class=""x"" title=""Mark as unread"">X</a><a title=""Jump to last read post"" href=""/showthread.php?threadid=3533827&amp;goto=newpost"" class=""count""><b>3335</b></a></div>
			<div class=""info"">
				<a href=""showthread.php?threadid=3533827"" class=""thread_title"">Canadian Housing Bubble Thread</a>
				<div class=""title_pages"">Pages: <a class=""pagenumber"" href=""showthread.php?threadid=3533827&amp;pagenumber=1"">1</a><a class=""pagenumber"" href=""showthread.php?threadid=3533827&amp;pagenumber=2"">2</a><a class=""pagenumber"" href=""showthread.php?threadid=3533827&amp;pagenumber=3"">3</a><a class=""pagenumber"" href=""showthread.php?threadid=3533827&amp;pagenumber=4"">4</a><a class=""pagenumber"" href=""showthread.php?threadid=3533827&amp;pagenumber=5"">5</a><a class=""pagenumber"" href=""showthread.php?threadid=3533827&amp;pagenumber=6"">6</a><a class=""pagenumber"" href=""showthread.php?threadid=3533827&amp;pagenumber=7"">7</a>... <a class=""pagenumber"" href=""showthread.php?threadid=3533827&amp;goto=lastpost"">Last</a></div>
			</div>
		</div>
	</td>
	<td class=""author""><a href=""member.php?action=getinfo&amp;userid=64202"">Cultural Imperial</a></td>
	<td class=""replies"">3374</td>
	<td class=""views"">173489</td>
	<td class=""rating""><img src=""http://fi.somethingawful.com/rate/default/4stars.gif"" alt="""" title=""17 votes - 3.78 average""></td>
	<td class=""lastpost""><div class=""date"">07:05 Mar 21, 2014</div><a class=""author"" href=""showthread.php?goto=lastpost&amp;threadid=3533827"">Lexicon</a></td>
</tr><tr class=""thread seen"" id=""thread3602962"">
	<td class=""star ""></td>
	<td class=""icon""><a href=""/forumdisplay.php?forumid=46&amp;posticon=75""><img src=""http://fi.somethingawful.com/forums/posticons/icons-08/news.png#75"" alt=""""></a></td>
	<td class=""title"">
		<div class=""title_inner"">
			<div class=""lastseen""><a href=""/showthread.php?action=resetseen&amp;threadid=3602962"" class=""x"" title=""Mark as unread"">X</a><a title=""Jump to last read post"" href=""/showthread.php?threadid=3602962&amp;goto=newpost"" class=""count""><b>414</b></a></div>
			<div class=""info"">
				<a href=""showthread.php?threadid=3602962"" class=""thread_title"">Fat and Furious</a>
				<div class=""title_pages"">Pages: <a class=""pagenumber"" href=""showthread.php?threadid=3602962&amp;pagenumber=1"">1</a><a class=""pagenumber"" href=""showthread.php?threadid=3602962&amp;pagenumber=2"">2</a><a class=""pagenumber"" href=""showthread.php?threadid=3602962&amp;pagenumber=3"">3</a><a class=""pagenumber"" href=""showthread.php?threadid=3602962&amp;pagenumber=4"">4</a><a class=""pagenumber"" href=""showthread.php?threadid=3602962&amp;pagenumber=5"">5</a><a class=""pagenumber"" href=""showthread.php?threadid=3602962&amp;pagenumber=6"">6</a><a class=""pagenumber"" href=""showthread.php?threadid=3602962&amp;pagenumber=7"">7</a>... <a class=""pagenumber"" href=""showthread.php?threadid=3602962&amp;goto=lastpost"">Last</a></div>
			</div>
		</div>
	</td>
	<td class=""author""><a href=""member.php?action=getinfo&amp;userid=33101"">pangstrom</a></td>
	<td class=""replies"">453</td>
	<td class=""views"">72329</td>
	<td class=""rating"">&nbsp;</td>
	<td class=""lastpost""><div class=""date"">06:43 Mar 21, 2014</div><a class=""author"" href=""showthread.php?goto=lastpost&amp;threadid=3602962"">FAUXTON</a></td>
</tr><tr class=""thread"" id=""thread3483456"">
	<td class=""star ""></td>
	<td class=""icon""><a href=""/forumdisplay.php?forumid=46&amp;posticon=570""><img src=""http://fi.somethingawful.com/forums/posticons/lf-trains.gif#570"" alt=""""></a></td>
	<td class=""title"">
		<div class=""title_inner"">
			
			<div class=""info"">
				<a href=""showthread.php?threadid=3483456"" class=""thread_title"">Trainchat - The failure of privatisation in the British Railway</a>
				<div class=""title_pages"">Pages: <a class=""pagenumber"" href=""showthread.php?threadid=3483456&amp;pagenumber=1"">1</a><a class=""pagenumber"" href=""showthread.php?threadid=3483456&amp;pagenumber=2"">2</a><a class=""pagenumber"" href=""showthread.php?threadid=3483456&amp;pagenumber=3"">3</a><a class=""pagenumber"" href=""showthread.php?threadid=3483456&amp;pagenumber=4"">4</a><a class=""pagenumber"" href=""showthread.php?threadid=3483456&amp;pagenumber=5"">5</a><a class=""pagenumber"" href=""showthread.php?threadid=3483456&amp;pagenumber=6"">6</a><a class=""pagenumber"" href=""showthread.php?threadid=3483456&amp;pagenumber=7"">7</a>... <a class=""pagenumber"" href=""showthread.php?threadid=3483456&amp;goto=lastpost"">Last</a></div>
			</div>
		</div>
	</td>
	<td class=""author""><a href=""member.php?action=getinfo&amp;userid=50679"">Bozza</a></td>
	<td class=""replies"">1167</td>
	<td class=""views"">115569</td>
	<td class=""rating""><img src=""http://fi.somethingawful.com/rate/default/5stars.gif"" alt="""" title=""22 votes - 4.83 average""></td>
	<td class=""lastpost""><div class=""date"">03:18 Mar 21, 2014</div><a class=""author"" href=""showthread.php?goto=lastpost&amp;threadid=3483456"">Seaside Loafer</a></td>
</tr><tr class=""thread"" id=""thread3443984"">
	<td class=""star ""></td>
	<td class=""icon""><a href=""/forumdisplay.php?forumid=46&amp;posticon=522""><img src=""http://fi.somethingawful.com/forums/posticons/lf-marx.png#522"" alt=""""></a></td>
	<td class=""title"">
		<div class=""title_inner"">
			
			<div class=""info"">
				<a href=""showthread.php?threadid=3443984"" class=""thread_title"">Let's pool our knowledge: D&amp;D helps D&amp;D Debate and Discuss</a>
				<div class=""title_pages"">Pages: <a class=""pagenumber"" href=""showthread.php?threadid=3443984&amp;pagenumber=1"">1</a><a class=""pagenumber"" href=""showthread.php?threadid=3443984&amp;pagenumber=2"">2</a><a class=""pagenumber"" href=""showthread.php?threadid=3443984&amp;pagenumber=3"">3</a><a class=""pagenumber"" href=""showthread.php?threadid=3443984&amp;pagenumber=4"">4</a><a class=""pagenumber"" href=""showthread.php?threadid=3443984&amp;pagenumber=5"">5</a><a class=""pagenumber"" href=""showthread.php?threadid=3443984&amp;pagenumber=6"">6</a><a class=""pagenumber"" href=""showthread.php?threadid=3443984&amp;pagenumber=7"">7</a>... <a class=""pagenumber"" href=""showthread.php?threadid=3443984&amp;goto=lastpost"">Last</a></div>
			</div>
		</div>
	</td>
	<td class=""author""><a href=""member.php?action=getinfo&amp;userid=141759"">Davish Krail</a></td>
	<td class=""replies"">2862</td>
	<td class=""views"">222286</td>
	<td class=""rating""><img src=""http://fi.somethingawful.com/rate/default/3stars.gif"" alt="""" title=""63 votes - 3.12 average""></td>
	<td class=""lastpost""><div class=""date"">19:57 Mar 20, 2014</div><a class=""author"" href=""showthread.php?goto=lastpost&amp;threadid=3443984"">computer parts</a></td>
</tr><tr class=""thread"" id=""thread3390024"">
	<td class=""star ""></td>
	<td class=""icon""><a href=""/forumdisplay.php?forumid=46&amp;posticon=361""><img src=""http://fi.somethingawful.com/forums/posticons/dd-europe.gif#361"" alt=""""></a></td>
	<td class=""title"">
		<div class=""title_inner"">
			
			<div class=""info"">
				<a href=""showthread.php?threadid=3390024"" class=""thread_title"">Finnish Politics Thread</a>
				<div class=""title_pages"">Pages: <a class=""pagenumber"" href=""showthread.php?threadid=3390024&amp;pagenumber=1"">1</a><a class=""pagenumber"" href=""showthread.php?threadid=3390024&amp;pagenumber=2"">2</a><a class=""pagenumber"" href=""showthread.php?threadid=3390024&amp;pagenumber=3"">3</a><a class=""pagenumber"" href=""showthread.php?threadid=3390024&amp;pagenumber=4"">4</a><a class=""pagenumber"" href=""showthread.php?threadid=3390024&amp;pagenumber=5"">5</a><a class=""pagenumber"" href=""showthread.php?threadid=3390024&amp;pagenumber=6"">6</a><a class=""pagenumber"" href=""showthread.php?threadid=3390024&amp;pagenumber=7"">7</a>... <a class=""pagenumber"" href=""showthread.php?threadid=3390024&amp;goto=lastpost"">Last</a></div>
			</div>
		</div>
	</td>
	<td class=""author""><a href=""member.php?action=getinfo&amp;userid=74366"">Stefu</a></td>
	<td class=""replies"">6108</td>
	<td class=""views"">310830</td>
	<td class=""rating""><img src=""http://fi.somethingawful.com/rate/default/3stars.gif"" alt="""" title=""55 votes - 2.68 average""></td>
	<td class=""lastpost""><div class=""date"">17:47 Mar 20, 2014</div><a class=""author"" href=""showthread.php?goto=lastpost&amp;threadid=3390024"">Hogge Wild</a></td>
</tr><tr class=""thread closed"" id=""thread3616139"">
	<td class=""star ""></td>
	<td class=""icon""><a href=""/forumdisplay.php?forumid=46&amp;posticon=587""><img src=""http://fi.somethingawful.com/forums/posticons/hell-spergin.gif#587"" alt=""""></a></td>
	<td class=""title"">
		<div class=""title_inner"">
			
			<div class=""info"">
				<a href=""showthread.php?threadid=3616139"" class=""thread_title"">Should the Pittsburgh Parmageddon be protected under trademark in the EU?</a>
				<div class=""title_pages"">Pages: <a class=""pagenumber"" href=""showthread.php?threadid=3616139&amp;pagenumber=1"">1</a><a class=""pagenumber"" href=""showthread.php?threadid=3616139&amp;pagenumber=2"">2</a><a class=""pagenumber"" href=""showthread.php?threadid=3616139&amp;pagenumber=3"">3</a><a class=""pagenumber"" href=""showthread.php?threadid=3616139&amp;pagenumber=4"">4</a><a class=""pagenumber"" href=""showthread.php?threadid=3616139&amp;pagenumber=5"">5</a><a class=""pagenumber"" href=""showthread.php?threadid=3616139&amp;pagenumber=6"">6</a><a class=""pagenumber"" href=""showthread.php?threadid=3616139&amp;pagenumber=7"">7</a>... <a class=""pagenumber"" href=""showthread.php?threadid=3616139&amp;goto=lastpost"">Last</a></div>
			</div>
		</div>
	</td>
	<td class=""author""><a href=""member.php?action=getinfo&amp;userid=154218"">snorch</a></td>
	<td class=""replies"">1292</td>
	<td class=""views"">37496</td>
	<td class=""rating""><img src=""http://fi.somethingawful.com/rate/default/2stars.gif"" alt="""" title=""19 votes - 2.45 average""></td>
	<td class=""lastpost""><div class=""date"">16:58 Mar 20, 2014</div><a class=""author"" href=""showthread.php?goto=lastpost&amp;threadid=3616139"">XyloJW</a></td>
</tr>
	</tbody>
</table>
<div class=""forumbar"">
	<ul class=""postbuttons""><li><a href=""newthread.php?action=newthread&amp;forumid=46""><img src=""http://fi.somethingawful.com/images/forum-post.gif"" alt=""Post New Thread""></a></li></ul>
</div>



<script type=""text/javascript"">
try { add_whoposted_links(); } catch(e) {};
</script>

<div class=""pages bottom""><span class=""disabled"">&laquo;</span><span class=""disabled"">&lsaquo;</span><select data-url=""forumdisplay.php?forumid=46&amp;daysprune=30&amp;perpage=40&amp;posticon=0&amp;sortorder=desc&amp;sortfield=lastpost""><option value=""1"" selected=""selected"">1</option><option value=""2"">2</option><option value=""3"">3</option><option value=""4"">4</option><option value=""5"">5</option></select><a href=""forumdisplay.php?forumid=46&amp;daysprune=30&amp;perpage=40&amp;posticon=0&amp;sortorder=desc&amp;sortfield=lastpost&pagenumber=2"" title=""Next page"">&rsaquo;</a><a href=""forumdisplay.php?forumid=46&amp;daysprune=30&amp;perpage=40&amp;posticon=0&amp;sortorder=desc&amp;sortfield=lastpost&pagenumber=5"" title=""Last page"">5 &raquo;</a></div>
<div class=""breadcrumbs""><span class=""mainbodytextlarge""><b><a href=""/"">The Something Awful Forums</a> &gt; <a href=""forumdisplay.php?forumid=51"">Discussion</a> &gt; <a href=""forumdisplay.php?forumid=46"" class=""bclast"">Debate Disco</a></b></span> <span class=""online_users"">(<a href=""/online.php?forumid=46"" title=""View members browsing this forum"">591 users browsing</a>)</span></div>

<div class=""bottom_forms"">
	
<form class=""forum_jump"" action=""forumdisplay.php"" method=""get"">
<input type=""hidden"" name=""s"" value="""">
<input type=""hidden"" name=""daysprune"" value="""">
<select name=""forumid"">
<option value=""-1"" selected>Jump to another forum:</option>
<option value=""-1"">--------------------</option>
<option value=""pm"" >Private Messages</option>
<option value=""cp"" >User Control Panel</option>
<option value=""search"" >Search Forums</option>
<option value=""home"" >Forums Home</option>
<option value=""lc"" >Leper's Colony</option>
<option value=""-1"">--------------------</option>
<option value=""48"" > Main</option><option value=""1"" >-- GBS 1.4</option><option value=""155"" >---- SA's Front Page Discussion</option><option value=""214"" >---- E/N Bullshit</option><option value=""26"" >-- FYAD: http://vimeo.com/86014703</option><option value=""154"" >---- A Beecock Forum.</option><option value=""268"" >-- BYOB 8.2</option><option value=""51"" > Discussion</option><option value=""44"" >-- Games</option><option value=""259"" >---- A Blizzard Subforum</option><option value=""146"" >------ WoW: Goon Squad</option><option value=""145"" >---- The MMO HMO</option><option value=""93"" >---- Private Game Servers</option><option value=""234"" >---- Dice &amp; Drama</option><option value=""103"" >------ The Goblin Ranch</option><option value=""191"" >---- Let's Play!</option><option value=""267"" >---- Dungeons &amp; Dreamcast Recreation Dome</option><option value=""192"" >-- Inspect Your Gadgets</option><option value=""158"" >-- Ask / Tell</option><option value=""162"" >---- Science, Academics and Languages</option><option value=""211"" >---- Tourism &amp; Travel</option><option value=""200"" >---- Business, Finance, and Careers</option><option value=""46"" >-- Debate Disco</option><option value=""22"" >-- Serious Hardware / Software Crap</option><option value=""170"" >---- Haus of Tech Support</option><option value=""202"" >---- The Cavern of COBOL</option><option value=""265"" >------ project.log</option><option value=""219"" >---- YOSPOS</option><option value=""122"" >-- Sports Argument Stadium* </option><option value=""181"" >---- The Football Funhouse</option><option value=""248"" >---- The Armchair Quarterback</option><option value=""175"" >---- The Ray Parlour</option><option value=""177"" >---- Punchsport Pagoda</option><option value=""179"" >-- You Look Like Shit</option><option value=""183"" >---- The Goon Doctor</option><option value=""244"" >---- The Fitness Log Cabin</option><option value=""242"" >-- Paranormal/Conspiracy Forum</option><option value=""161"" >-- Goons With Spoons</option><option value=""167"" >-- Post Your Favorite (or Request)</option><option value=""91"" >-- Automotive Insanity</option><option value=""236"" >---- Cycle Asylum</option><option value=""124"" >-- Pet Island</option><option value=""132"" >-- The Firing Range</option><option value=""90"" >-- The Crackhead Clubhouse</option><option value=""218"" >-- Goons in Platoons</option><option value=""152"" > The Finer Arts</option><option value=""31"" >-- Creative Convention</option><option value=""210"" >---- DIY &amp; Hobbies</option><option value=""247"" >---- The Dorkroom</option><option value=""151"" >-- Cinema Discusso</option><option value=""133"" >---- The Film Dump</option><option value=""182"" >-- The Book Barn</option><option value=""150"" >-- No Music Discussion</option><option value=""104"" >---- Musician's Lounge</option><option value=""130"" >-- The TV IV</option><option value=""144"" >-- Batman's Shameful Secret</option><option value=""27"" >-- ADTRW</option><option value=""215"" >-- Entertainment, Weakly</option><option value=""255"" >-- Rapidly Going Deaf</option><option value=""153"" > The Community</option><option value=""61"" >-- SA-Mart</option><option value=""77"" >---- Feedback &amp; Discussion</option><option value=""85"" >---- Coupons &amp; Deals</option><option value=""43"" >-- Goon Meets</option><option value=""241"" >-- LAN: Your City Sucks - Regional Discussion</option><option value=""188"" >-- Questions, Comments, Suggestions? - Read the stickies first!</option><option value=""49"" > Archives</option><option value=""21"" >-- Comedy Goldmine</option><option value=""264"" >---- Comedy Purgatory</option><option value=""115"" >---- FYAD: Criterion Collection</option><option value=""204"" >---- Helldump Success Stories</option><option value=""222"" >---- LF Goldmine</option><option value=""229"" >---- YCS Goldmine</option><option value=""25"" >-- Comedy Gas Chamber</option>
</select>
<input type=""submit"" value=""Go"">
</form>
	<form method=""POST"" action=""/forumdisplay.php?forumid=46"" id=""ac_timemachine"">
Archives: <select name=""ac_month"" disabled>
	<option value="""">&nbsp;</option>
	<option value=""1"">January</option>
	<option value=""2"">February</option>
	<option value=""3"">March</option>
	<option value=""4"">April</option>
	<option value=""5"">May</option>
	<option value=""6"">June</option>
	<option value=""7"">July</option>
	<option value=""8"">August</option>
	<option value=""9"">September</option>
	<option value=""10"">October</option>
	<option value=""11"">November</option>
	<option value=""12"">December</option>
</select>
<select name=""ac_day"" disabled>
	<option value="""">&nbsp;</option>
	<option>1</option>
	<option>2</option>
	<option>3</option>
	<option>4</option>
	<option>5</option>
	<option>6</option>
	<option>7</option>
	<option>8</option>
	<option>9</option>
	<option>10</option>
	<option>11</option>
	<option>12</option>
	<option>13</option>
	<option>14</option>
	<option>15</option>
	<option>16</option>
	<option>17</option>
	<option>18</option>
	<option>19</option>
	<option>20</option>
	<option>21</option>
	<option>22</option>
	<option>23</option>
	<option>24</option>
	<option>25</option>
	<option>26</option>
	<option>27</option>
	<option>28</option>
	<option>29</option>
	<option>30</option>
	<option>31</option>
</select>
<select name=""ac_year"" disabled>
	<option selected>2014</option>
	<option>2013</option>
	<option>2012</option>
	<option>2011</option>
	<option>2010</option>
	<option>2009</option>
	<option>2008</option>
	<option>2007</option>
	<option>2006</option>
	<option>2005</option>
	<option>2004</option>
	<option>2003</option>
	<option>2002</option>
	<option>2001</option>
</select>
<input type=""submit"" name=""set"" value=""GO"" disabled>
</form>

</div>


<center>

	<div id=""ad_banner_user"">
		<a href=""http://forums.somethingawful.com/showthread.php?threadid=3286519"" target=""_blank""><img src=""http://fi.somethingawful.com/safs/goonbas/7/0/6548.0002.gif"" alt="""" width=""468"" height=""60""></a><br>
		<a href=""https://secure.somethingawful.com/products/ad-banner.php"" target=""_blank"" title=""Affordable rates, high exposure!"">Advertise here!</a> | <a href=""/adlist.php"" class=""all_ads"">Browse all ads</a>
	</div>
</center>


</div><!-- #content -->
	<ul class=""navigation"">
<li class=""first""><a href=""/index.php"">SA Forums</a></li>
<li>- <a href=""http://www.somethingawful.com/"">Something Awful</a></li>
<li>- <a href=""/f/search"">Search the Forums</a></li>
<li>- <a href=""/usercp.php"">User Control Panel</a></li>
<li>- <a href=""/private.php"">Private Messages</a></li>
<li>- <a href=""http://www.somethingawful.com/d/forum-rules/forum-rules.php"">Forum Rules</a></li>
<li>- <a href=""/dictionary.php"">SAclopedia</a></li>
<li>- <a href=""/stats.php"">Posting Gloryhole</a></li>
<li>- <a href=""/banlist.php"">Leper's Colony</a></li>
<li>- <a href=""/supportmail.php"">Support</a></li>
<li>- <a href=""/account.php?action=logout&amp;ma=10293618"">Log Out</a></li>

</ul>
	<div id=""copyright"">
		Powered by: vBulletin Version 2.2.9 (<a href=""/CHANGES"">SAVB-v2.1.17</a>)<br>
		Copyright &copy;2000, 2001, Jelsoft Enterprises Limited.<br>
		Copyright &copy;2012, Something Awful LLC<br>
	</div>

</div><!-- #container -->

<script type=""text/javascript"">
	// quantcast
	_qoptions = { qacct:""p-82vTvmw-enlng"" };

	try {
		if(document.location.hostname != 'forums.somethingawful.com')
			throw undefined;

		$(document).ready(function() {
			var qcUrl = 'http://edge.quantserve.com/quant.js';
			jQuery.getScript(qcUrl);

			var gaJsHost = ((""https:"" == document.location.protocol) ? ""https://ssl."" : ""http://www."");
			var gaUrl = gaJsHost + 'google-analytics.com/ga.js';
			jQuery.getScript(gaUrl, function() {
				var pageTracker = _gat._getTracker(""UA-3064978-2"");
				pageTracker._initData();
				pageTracker._trackPageview();
			});
		});
	} catch(e) {};

	// indie
	// try {
	// 	if(document.location.hostname != 'forums.somethingawful.com')
	// 		throw undefined;

	// 	$(document).ready(function() {
	// 		var ic_element = document.createElement('script');
	// 		ic_element.type = 'text/javascript';
	// 		ic_element.async = true;
	// 		ic_element.id = 'ic_annonymous_pixel';
	// 		ic_element.src = 'http://pixel.indieclick.com/annonymous/domain/somethingawful.com/reach/script_ic.js';
	// 		var ic_script = document.getElementsByTagName('script')[0];
	// 		ic_script.parentNode.insertBefore(ic_element, ic_script);
	// 	});
	// } catch(e) {};
</script>
<noscript><img src=""http://pixel.quantserve.com/pixel/p-82vTvmw-enlng.gif"" style=""display:none;"" border=""0"" height=""1"" width=""1"" alt=""Quantcast""></noscript>

<!-- PLEASE DO NOT REMOVE -->
<ol id=""debug"" style=""display:none""><li>&nbsp;</ol>
</body>
</html>";
        }
        public virtual string GenerateMockThreadPageHtml()
        {
            return @"<!DOCTYPE html>
<html lang=""en"">
<head>
	<title>[TEST] The Post Test Thread - The Something Awful Forums</title>
	
	<meta name=""MSSmartTagsPreventParsing"" content=""TRUE"">
	<meta http-equiv=""X-UA-Compatible"" content=""chrome=1"">
	<!--[if lt IE 7]><link rel=""stylesheet"" type=""text/css"" href=""/css/ie.css?1348360344""><![endif]-->
	<!--[if lt IE 8]><link rel=""stylesheet"" type=""text/css"" href=""/css/ie7.css?1348360344""><![endif]-->
	<link rel=""apple-touch-icon"" href=""http://i.somethingawful.com/core/icon/iphone-touch/forums.png"">
	<link rel=""stylesheet"" type=""text/css"" href=""/css/main.css?1359594161"">
	<link rel=""stylesheet"" type=""text/css"" href=""/css/bbcode.css?1348360344"">
	<link rel=""stylesheet"" type=""text/css"" href=""http://www.somethingawful.com/globalcss/globalmenu.css"">

	

	<!-- <script src=""/__utm.js"" type=""text/javascript""></script> -->
	<!-- script src=""/js/dojo/dojo.js?1348360344"" type=""text/javascript""></script -->
	<script type=""text/javascript"" src=""//ajax.googleapis.com/ajax/libs/jquery/1.8.3/jquery.min.js""></script>
	<link rel=""stylesheet"" type=""text/css"" href=""//ajax.googleapis.com/ajax/libs/jqueryui/1.9.2/themes/redmond/jquery-ui.css"">
	<script type=""text/javascript"" src=""//ajax.googleapis.com/ajax/libs/jqueryui/1.9.2/jquery-ui.min.js""></script>

	<link rel=""stylesheet"" type=""text/css"" href=""http://www.somethingawful.com/css/forums.css?7"">

	

	<script type=""text/javascript"">
		
		
		
		
	</script>

	<script type=""text/javascript"" src=""/js/vb/forums.combined.js?1359653372""></script>

	

	<!-- ts-specific includes -->
	
	
	

	

	

	
	<meta name=""Description"" content=""[TEST] The Post Test Thread"">

	




</head>
<body id=""something_awful"" class=""showthread forum_261 thread_3532200"" data-forum=""261"" data-thread=""3532200"">

<div id=""top""></div>

<div id=""globalmenu"">
	<ul>
		<li class=""first""><a href=""https://secure.somethingawful.com/"">Buy Forum Stuff</a></li>
		<li><a href=""http://www.somethingawful.com/"">Something Awful</a></li>
	</ul>
</div>



<div id=""container"">



	

	<ul id=""nav_purchase"">
		<li><b>Purchase:</b></li>
		<li><a href=""https://secure.somethingawful.com/products/register.php"">Account</a></li>
		<li>- <a href=""https://secure.somethingawful.com/products/platinum.php"">Platinum Upgrade</a></li>
		<li>- <a href=""https://secure.somethingawful.com/products/titlechange.php"">New Avatar</a></li>
		<li>- <a href=""https://secure.somethingawful.com/products/titlechange.php"">Other's Avatar</a></li>
		<li>- <a href=""https://secure.somethingawful.com/products/archives.php"">Archives</a></li>
		<li>- <a href=""https://secure.somethingawful.com/products/noads.php"">No-Ads</a></li>
		<li>- <a href=""https://secure.somethingawful.com/products/namechange.php"">New Username</a></li>
		<li>- <a href=""https://secure.somethingawful.com/products/ad-banner.php"">Banner Advertisement</a></li>
		<li>- <a href=""https://secure.somethingawful.com/products/smilie.php"">Smilie</a></li>
		<li>- <a href=""https://secure.somethingawful.com/products/sticky-thread.php"">Stick Thread</a></li>
		<li>- <a href=""https://secure.somethingawful.com/products/gift-certificate.php"">Gift Cert.</a></li>
	</ul>

	<ul id=""navigation"" class=""navigation"">
<li class=""first""><a href=""/index.php"">SA Forums</a></li>
<li>- <a href=""http://www.somethingawful.com/"">Something Awful</a></li>
<li>- <a href=""/f/search"">Search the Forums</a></li>
<li>- <a href=""/usercp.php"">User Control Panel</a></li>
<li>- <a href=""/private.php"">Private Messages</a></li>
<li>- <a href=""http://www.somethingawful.com/d/forum-rules/forum-rules.php"">Forum Rules</a></li>
<li>- <a href=""/dictionary.php"">SAclopedia</a></li>
<li>- <a href=""/stats.php"">Posting Gloryhole</a></li>
<li>- <a href=""/banlist.php"">Leper's Colony</a></li>
<li>- <a href=""/supportmail.php"">Support</a></li>
<li>- <a href=""/account.php?action=logout&amp;ma=10293618"">Log Out</a></li>

</ul>


<div class=""oma_pal"">
	<!--  Begin Rubicon Project Tag -->
<!--  Site: Something Awful LLC   Zone: Forum ATF Top Quality - Mobile, Pop, Web   Size: Leaderboard  -->
<!--  PLACEMENT: Above the Fold  -->
<script language=""JavaScript"" type=""text/javascript"">
rp_account   = '8539';
rp_site      = '13831';
rp_zonesize  = '80354-2';
rp_adtype    = 'iframe';
rp_width     = '728';
rp_height    = '90';
rp_smartfile = 'http://www.somethingawful.com/revv_smart_file.html';
</script>
<script type=""text/javascript"" src=""https://ads.rubiconproject.com/ad/8539.js""></script>
<!--  End Rubicon Project Tag -->
</div>





	<div id=""content"">

	



<div class=""pages top""><span class=""disabled"">&laquo;</span><span class=""disabled"">&lsaquo;</span><select data-url=""showthread.php?threadid=3532200&amp;userid=0&amp;perpage=40""><option value=""1"" selected=""selected"">1</option><option value=""2"">2</option><option value=""3"">3</option><option value=""4"">4</option><option value=""5"">5</option><option value=""6"">6</option></select><a href=""showthread.php?threadid=3532200&amp;userid=0&amp;perpage=40&pagenumber=2"" title=""Next page"">&rsaquo;</a><a href=""showthread.php?threadid=3532200&amp;userid=0&amp;perpage=40&pagenumber=6"" title=""Last page"">6 &raquo;</a> </div>
<div class=""breadcrumbs""><span class=""mainbodytextlarge""><b><a href=""/"">The Something Awful Forums</a> &gt; <a href=""forumdisplay.php?forumid=153"">The Community</a> &gt; <a href=""forumdisplay.php?forumid=261"">Apps In Developmental States</a> &gt; <a href=""showthread.php?threadid=3532200"" class=""bclast"">[TEST] The Post Test Thread</a></b></span></div>

<div style=""clear:right;""></div>

<div class=""threadbar top"">
<form action=""search.php"" method=""post"" class=""threadsearch"">
<!--<div><label>Search thread: &nbsp;</label><input type=""text"" name=""keywords"" value="""" size=""25""> &nbsp; <input type=""submit"" class=""bginput"" name=""Submit"" value=""GO""><input type=""hidden"" name=""threadid"" value=""3532200""><input type=""hidden"" name=""action"" value=""do_search_simple""><input type=""hidden"" name=""searchthru"" value=""3""><input type=""hidden"" name=""show_previews"" value=""1""></div>-->
</form>
<ul class=""postbuttons"">

	
	<li><form method=""POST"" action=""/postings.php?action=openclosethread"" style=""display:inline;"">
<input type=""hidden"" name=""threadid"" value=""3532200"">
<input type=""image"" src=""http://fi.somethingawful.com/images/buttons/sa-close.gif"" alt=""Close thread"">
</form></li>
	



	
	<li><img src=""http://fi.somethingawful.com/images/buttons/button-unbookmark.png"" alt="""" class=""thread_bookmark unbookmark""></li>
	<li><a href=""newthread.php?action=newthread&amp;forumid=261""><img src=""http://fi.somethingawful.com/images/forum-post.gif"" alt=""Post"" title=""""></a></li>
<li><a href=""newreply.php?action=newreply&amp;threadid=3532200""><img src=""http://fi.somethingawful.com/images/forum-reply.gif"" alt=""Reply"" title=""""></a></li>


</ul>
<!--<div class=""clear""></div>-->
</div>
<div id=""thread"" class=""thread:3532200"">
<table class=""post "" id=""post412213208"" data-idx=""1"">
<tr  class=""seen2"" id=""pti1"">
	<td class=""userinfo userid-70611"">
		<dl class=""userinfo"">
			<dt class=""author op"" title="""">bootleg robot</dt>
			<dd class=""registered"">Dec  7, 2004</dd>
			<dd class=""title"">
				<img src=""http://fi.somethingawful.com/customtitles/title-bootleg_robot-2.gif"" alt="""" class=""img"" border=""0""><br />
<br>
				<br class=""pb"">
			</dd>
		</dl>
	</td>
	<td class=""postbody"">
		<!-- BeginContentMarker -->
		<!-- google_ad_section_start -->
		Testing Posts? Posting Tests? Do it here! <br />
<br />
--------------------<br />
<br />
Sneaky edit.<br />
<br />
Post-ironic tumblr put a bird on it, before they sold out cred stumptown dreamcatcher brunch williamsburg carles YOLO. Lomo butcher pinterest artisan, cardigan YOLO williamsburg messenger bag narwhal odd future. Ethical Austin small batch mcsweeney's, ugh tousled swag messenger bag leggings typewriter tonx trust fund single-origin coffee aesthetic. Beard organic forage fap neutra. Keytar cosby sweater fashion axe mumblecore umami hoodie, portland skateboard mustache narwhal terry richardson pour-over ethical tofu. Gentrify tattooed pinterest, biodiesel cliche fanny pack post-ironic truffaut sustainable trust fund you probably haven't heard of them squid. Truffaut fixie pour-over, whatever kale chips locavore letterpress mixtape selfies squid church-key carles keffiyeh.<br />
<br />
<span class=""bbc-spoiler"">Whatever bushwick stumptown, godard small batch pitchfork semiotics ethnic. Lomo jean shorts messenger bag scenester trust fund, meggings actually wes anderson lo-fi YOLO freegan. Irony ethical lomo, four loko put a bird on it VHS truffaut carles blue bottle locavore. Typewriter craft beer fap 90's, disrupt hella vegan small batch pour-over plaid street art actually. Pug tofu YOLO carles meggings gentrify narwhal master cleanse, 3 wolf moon banksy. Keytar raw denim fap, iphone neutra quinoa etsy ethical beard polaroid banksy cray. Leggings fap pour-over tumblr</span><br />
<br />
<ul class=""bbc-list"">
<li>PBR mixtape bushwick ethnic. Mlkshk readymade pop-up williamsburg fap. <br />
<li>+1 artisan direct trade, hashtag 3 wolf moon DIY retro godard. <br />
<li>Biodiesel terry richardson small batch, leggings fap artisan chambray retro tousled church-key farm-to-table pinterest vinyl 90's deep v. <br />
<li>Kogi DIY pork belly dreamcatcher wayfarers. Sustainable ugh photo booth flannel wolf, church-key aesthetic vinyl marfa leggings. <br />
<li>Retro iphone meggings deep v, carles authentic freegan plaid swag bushwick.<br />
</ul>
<br />
<img src=""http://fi.somethingawful.com/sideimages/l88/19.jpg"" alt="""" class=""img"" border=""0""><br />
<br />
<a href=""http://forums.somethingawful.com/showthread.php?threadid=3530913"" target=""_blank"" rel=""nofollow"">The README.TXT thread.</a><br />
<br />
<a href=""http://forums.somethingawful.com/showthread.php?threadid=3530913"" target=""_blank"" rel=""nofollow"">http://forums.somethingawful.com/sh...hreadid=3530913</a><br />
<br />
<b>Polaroid etsy skateboard art party.</b> <br />
<br />
<div class=""bbc-block""><h4>a hipster posted:</h4><blockquote>
Jean shorts bicycle rights +1 american apparel twee messenger bag. Tousled butcher kale chips iphone retro, squid tonx direct trade. Tonx aesthetic helvetica, tumblr vice meh brunch terry richardson kale chips. Leggings american apparel fashion axe food truck gluten-free meggings. Tumblr biodiesel high life, bushwick aesthetic gastropub kogi vegan polaroid ethical carles stumptown locavore sustainable. Tattooed scenester fixie, +1 deep v lomo bespoke thundercats chambray.<br />
</blockquote></div>

		<!-- google_ad_section_end -->
		<!-- EndContentMarker -->


		<p class=""editedby""><span>bootleg robot fucked around with this message at Feb 21, 2013 around 16:51</span>
	</td>
</tr>
<tr class=""seen2"">
	<td class=""postdate"">
		<a class=""lastseen_icon"" href=""/showthread.php?action=setseen&amp;threadid=3532200&amp;index=1"" title=""Mark all replies as read to this point""><img src=""http://fi.somethingawful.com/style/posticon-seen.gif"" alt="""" border=""0""></a>
		<a href=""#post412213208"" title=""Link to this post"">#</a>
		<a class=""user_jump"" title=""Show posts by this user"" href=""/showthread.php?threadid=3532200&amp;userid=70611"">?</a>
		Feb  4, 2013 11:59
	</td>
	<td class=""postlinks"">
		<ul class=""profilelinks"">
			<li><a href=""member.php?action=getinfo&amp;userid=70611"">Profile</a></li>
			<li><a href=""private.php?action=newmessage&amp;userid=70611"">Message</a></li>
			<li><a href=""search.php?action=do_search_posthistory&amp;userid=70611"">Post History</a></li>
		</ul>
		<ul class=""postbuttons"">

			
			<li class=""alertbutton""><a href=""modalert.php?postid=412213208&amp;username=bootleg+robot""><img src=""http://forumimages.somethingawful.com/images/button-report.gif"" border=""0"" alt=""Alert Moderators""></a>&nbsp;&nbsp;</li>
			
			<li><a href=""editpost.php?action=editpost&amp;postid=412213208""><img src=""http://fi.somethingawful.com/images/sa-edit.gif"" alt=""Edit"" title=""""></a></li>
			<li><a href=""newreply.php?action=newreply&amp;postid=412213208""><img src=""http://fi.somethingawful.com/images/sa-quote.gif"" alt=""Quote""  title=""""></a></li>


		</ul>
	</td>
</tr>
</table><table class=""post "" id=""post412213401"" data-idx=""2"">
<tr  class=""seen1"" id=""pti2"">
	<td class=""userinfo userid-70611"">
		<dl class=""userinfo"">
			<dt class=""author op"" title="""">bootleg robot</dt>
			<dd class=""registered"">Dec  7, 2004</dd>
			<dd class=""title"">
				<img src=""http://fi.somethingawful.com/customtitles/title-bootleg_robot-2.gif"" alt="""" class=""img"" border=""0""><br />
<br>
				<br class=""pb"">
			</dd>
		</dl>
	</td>
	<td class=""postbody"">
		<!-- BeginContentMarker -->
		<!-- google_ad_section_start -->
		<a href=""http://forums.somethingawful.com/showthread.php?threadid=3530917"" target=""_blank"" rel=""nofollow"">A link to the JSON thread.</a>
		<!-- google_ad_section_end -->
		<!-- EndContentMarker -->


		<p class=""editedby"">
	</td>
</tr>
<tr class=""seen1"">
	<td class=""postdate"">
		<a class=""lastseen_icon"" href=""/showthread.php?action=setseen&amp;threadid=3532200&amp;index=2"" title=""Mark all replies as read to this point""><img src=""http://fi.somethingawful.com/style/posticon-seen.gif"" alt="""" border=""0""></a>
		<a href=""#post412213401"" title=""Link to this post"">#</a>
		<a class=""user_jump"" title=""Show posts by this user"" href=""/showthread.php?threadid=3532200&amp;userid=70611"">?</a>
		Feb  4, 2013 12:07
	</td>
	<td class=""postlinks"">
		<ul class=""profilelinks"">
			<li><a href=""member.php?action=getinfo&amp;userid=70611"">Profile</a></li>
			<li><a href=""private.php?action=newmessage&amp;userid=70611"">Message</a></li>
			<li><a href=""search.php?action=do_search_posthistory&amp;userid=70611"">Post History</a></li>
		</ul>
		<ul class=""postbuttons"">

			
			<li class=""alertbutton""><a href=""modalert.php?postid=412213401&amp;username=bootleg+robot""><img src=""http://forumimages.somethingawful.com/images/button-report.gif"" border=""0"" alt=""Alert Moderators""></a>&nbsp;&nbsp;</li>
			
			<li><a href=""editpost.php?action=editpost&amp;postid=412213401""><img src=""http://fi.somethingawful.com/images/sa-edit.gif"" alt=""Edit"" title=""""></a></li>
			<li><a href=""newreply.php?action=newreply&amp;postid=412213401""><img src=""http://fi.somethingawful.com/images/sa-quote.gif"" alt=""Quote""  title=""""></a></li>


		</ul>
	</td>
</tr>
</table><table class=""post "" id=""post412218004"" data-idx=""3"">
<tr  class=""seen2"" id=""pti3"">
	<td class=""userinfo userid-70611"">
		<dl class=""userinfo"">
			<dt class=""author op"" title="""">bootleg robot</dt>
			<dd class=""registered"">Dec  7, 2004</dd>
			<dd class=""title"">
				<img src=""http://fi.somethingawful.com/customtitles/title-bootleg_robot-2.gif"" alt="""" class=""img"" border=""0""><br />
<br>
				<br class=""pb"">
			</dd>
		</dl>
	</td>
	<td class=""postbody"">
		<!-- BeginContentMarker -->
		<!-- google_ad_section_start -->
		Testing a post.<br />
<br />
Edit: Gonna edit dis post!
		<!-- google_ad_section_end -->
		<!-- EndContentMarker -->


		<p class=""editedby""><span>bootleg robot fucked around with this message at Mar  6, 2013 around 13:20</span>
	</td>
</tr>
<tr class=""seen2"">
	<td class=""postdate"">
		<a class=""lastseen_icon"" href=""/showthread.php?action=setseen&amp;threadid=3532200&amp;index=3"" title=""Mark all replies as read to this point""><img src=""http://fi.somethingawful.com/style/posticon-seen.gif"" alt="""" border=""0""></a>
		<a href=""#post412218004"" title=""Link to this post"">#</a>
		<a class=""user_jump"" title=""Show posts by this user"" href=""/showthread.php?threadid=3532200&amp;userid=70611"">?</a>
		Feb  4, 2013 14:50
	</td>
	<td class=""postlinks"">
		<ul class=""profilelinks"">
			<li><a href=""member.php?action=getinfo&amp;userid=70611"">Profile</a></li>
			<li><a href=""private.php?action=newmessage&amp;userid=70611"">Message</a></li>
			<li><a href=""search.php?action=do_search_posthistory&amp;userid=70611"">Post History</a></li>
		</ul>
		<ul class=""postbuttons"">

			
			<li class=""alertbutton""><a href=""modalert.php?postid=412218004&amp;username=bootleg+robot""><img src=""http://forumimages.somethingawful.com/images/button-report.gif"" border=""0"" alt=""Alert Moderators""></a>&nbsp;&nbsp;</li>
			
			<li><a href=""editpost.php?action=editpost&amp;postid=412218004""><img src=""http://fi.somethingawful.com/images/sa-edit.gif"" alt=""Edit"" title=""""></a></li>
			<li><a href=""newreply.php?action=newreply&amp;postid=412218004""><img src=""http://fi.somethingawful.com/images/sa-quote.gif"" alt=""Quote""  title=""""></a></li>


		</ul>
	</td>
</tr>
</table><table class=""post "" id=""post412417227"" data-idx=""4"">
<tr  class=""seen1"" id=""pti4"">
	<td class=""userinfo userid-106125"">
		<dl class=""userinfo"">
			<dt class=""author"" title="""">pokeyman</dt>
			<dd class=""registered"">Nov 26, 2006</dd>
			<dd class=""title"">
				<img src=""http://fi.somethingawful.com/customtitles/title-pokeyman.jpg""><br>What do you like to play?<br>
				<br class=""pb"">
			</dd>
		</dl>
	</td>
	<td class=""postbody"">
		<!-- BeginContentMarker -->
		<!-- google_ad_section_start -->
		Posting and hoping for failure!<br />
<br />
Again!
		<!-- google_ad_section_end -->
		<!-- EndContentMarker -->


		<p class=""editedby""><span>pokeyman fucked around with this message at Feb 10, 2013 around 23:20</span>
	</td>
</tr>
<tr class=""seen1"">
	<td class=""postdate"">
		<a class=""lastseen_icon"" href=""/showthread.php?action=setseen&amp;threadid=3532200&amp;index=4"" title=""Mark all replies as read to this point""><img src=""http://fi.somethingawful.com/style/posticon-seen.gif"" alt="""" border=""0""></a>
		<a href=""#post412417227"" title=""Link to this post"">#</a>
		<a class=""user_jump"" title=""Show posts by this user"" href=""/showthread.php?threadid=3532200&amp;userid=106125"">?</a>
		Feb 10, 2013 23:17
	</td>
	<td class=""postlinks"">
		<ul class=""profilelinks"">
			<li><a href=""member.php?action=getinfo&amp;userid=106125"">Profile</a></li>
			<li><a href=""private.php?action=newmessage&amp;userid=106125"">Message</a></li>
			<li><a href=""search.php?action=do_search_posthistory&amp;userid=106125"">Post History</a></li>
		</ul>
		<ul class=""postbuttons"">

			
			<li class=""alertbutton""><a href=""modalert.php?postid=412417227&amp;username=pokeyman""><img src=""http://forumimages.somethingawful.com/images/button-report.gif"" border=""0"" alt=""Alert Moderators""></a>&nbsp;&nbsp;</li>
			
			<li><a href=""newreply.php?action=newreply&amp;postid=412417227""><img src=""http://fi.somethingawful.com/images/sa-quote.gif"" alt=""Quote""  title=""""></a></li>


		</ul>
	</td>
</tr>
</table><table class=""post "" id=""post412418023"" data-idx=""5"">
<tr  class=""seen2"" id=""pti5"">
	<td class=""userinfo userid-106125"">
		<dl class=""userinfo"">
			<dt class=""author"" title="""">pokeyman</dt>
			<dd class=""registered"">Nov 26, 2006</dd>
			<dd class=""title"">
				<img src=""http://fi.somethingawful.com/customtitles/title-pokeyman.jpg""><br>What do you like to play?<br>
				<br class=""pb"">
			</dd>
		</dl>
	</td>
	<td class=""postbody"">
		<!-- BeginContentMarker -->
		<!-- google_ad_section_start -->
		More! More!
		<!-- google_ad_section_end -->
		<!-- EndContentMarker -->


		<p class=""editedby"">
	</td>
</tr>
<tr class=""seen2"">
	<td class=""postdate"">
		<a class=""lastseen_icon"" href=""/showthread.php?action=setseen&amp;threadid=3532200&amp;index=5"" title=""Mark all replies as read to this point""><img src=""http://fi.somethingawful.com/style/posticon-seen.gif"" alt="""" border=""0""></a>
		<a href=""#post412418023"" title=""Link to this post"">#</a>
		<a class=""user_jump"" title=""Show posts by this user"" href=""/showthread.php?threadid=3532200&amp;userid=106125"">?</a>
		Feb 10, 2013 23:56
	</td>
	<td class=""postlinks"">
		<ul class=""profilelinks"">
			<li><a href=""member.php?action=getinfo&amp;userid=106125"">Profile</a></li>
			<li><a href=""private.php?action=newmessage&amp;userid=106125"">Message</a></li>
			<li><a href=""search.php?action=do_search_posthistory&amp;userid=106125"">Post History</a></li>
		</ul>
		<ul class=""postbuttons"">

			
			<li class=""alertbutton""><a href=""modalert.php?postid=412418023&amp;username=pokeyman""><img src=""http://forumimages.somethingawful.com/images/button-report.gif"" border=""0"" alt=""Alert Moderators""></a>&nbsp;&nbsp;</li>
			
			<li><a href=""newreply.php?action=newreply&amp;postid=412418023""><img src=""http://fi.somethingawful.com/images/sa-quote.gif"" alt=""Quote""  title=""""></a></li>


		</ul>
	</td>
</tr>
</table><table class=""post "" id=""post412423096"" data-idx=""6"">
<tr  class=""seen1"" id=""pti6"">
	<td class=""userinfo userid-51070"">
		<dl class=""userinfo"">
			<dt class=""author"" title="""">hardstyle</dt>
			<dd class=""registered"">Mar 12, 2004</dd>
			<dd class=""title"">
				<img alt="""" border=""0"" src=""http://fi.somethingawful.com/customtitles/title-hardstyle.jpg"" /><br />&#34;...Neither seen nor heard&#34;
<br>
				<br class=""pb"">
			</dd>
		</dl>
	</td>
	<td class=""postbody"">
		<!-- BeginContentMarker -->
		<!-- google_ad_section_start -->
		Testing some shit.&lt;div&gt;&lt;br&gt;&lt;/div&gt;&lt;div&gt;New line here. &nbsp;<b>This should be bold</b>. &nbsp;<i>This should be italic</i>. &nbsp;<u>Underlined</u>. <s>Strike</s>. &nbsp;<span class=""bbc-spoiler"">Spoilers</span>. &nbsp;<sub>Subscript</sub>. &nbsp;[sup]Superscript[/sup]. &nbsp;<b><i>Bold italic</i></b>. &nbsp;<u><s>Underline strike</s></u>.&lt;/div&gt;&lt;div&gt;&lt;br&gt;&lt;/div&gt;&lt;div&gt;&lt;br&gt;&lt;/div&gt;&lt;div&gt;&lt;br&gt;&lt;/div&gt;&lt;div&gt;&lt;br&gt;&lt;/div&gt;
		<!-- google_ad_section_end -->
		<!-- EndContentMarker -->


		<p class=""editedby"">
	</td>
</tr>
<tr class=""seen1"">
	<td class=""postdate"">
		<a class=""lastseen_icon"" href=""/showthread.php?action=setseen&amp;threadid=3532200&amp;index=6"" title=""Mark all replies as read to this point""><img src=""http://fi.somethingawful.com/style/posticon-seen.gif"" alt="""" border=""0""></a>
		<a href=""#post412423096"" title=""Link to this post"">#</a>
		<a class=""user_jump"" title=""Show posts by this user"" href=""/showthread.php?threadid=3532200&amp;userid=51070"">?</a>
		Feb 11, 2013 08:01
	</td>
	<td class=""postlinks"">
		<ul class=""profilelinks"">
			<li><a href=""member.php?action=getinfo&amp;userid=51070"">Profile</a></li>
			<li><a href=""private.php?action=newmessage&amp;userid=51070"">Message</a></li>
			<li><a href=""search.php?action=do_search_posthistory&amp;userid=51070"">Post History</a></li>
		</ul>
		<ul class=""postbuttons"">

			
			<li class=""alertbutton""><a href=""modalert.php?postid=412423096&amp;username=hardstyle""><img src=""http://forumimages.somethingawful.com/images/button-report.gif"" border=""0"" alt=""Alert Moderators""></a>&nbsp;&nbsp;</li>
			
			<li><a href=""newreply.php?action=newreply&amp;postid=412423096""><img src=""http://fi.somethingawful.com/images/sa-quote.gif"" alt=""Quote""  title=""""></a></li>


		</ul>
	</td>
</tr>
</table><table class=""post "" id=""post412439399"" data-idx=""7"">
<tr  class=""seen2"" id=""pti7"">
	<td class=""userinfo userid-51070"">
		<dl class=""userinfo"">
			<dt class=""author"" title="""">hardstyle</dt>
			<dd class=""registered"">Mar 12, 2004</dd>
			<dd class=""title"">
				<img alt="""" border=""0"" src=""http://fi.somethingawful.com/customtitles/title-hardstyle.jpg"" /><br />&#34;...Neither seen nor heard&#34;
<br>
				<br class=""pb"">
			</dd>
		</dl>
	</td>
	<td class=""postbody"">
		<!-- BeginContentMarker -->
		<!-- google_ad_section_start -->
		Testing new linesNext line<br />
Blank line above me.<br />
<br />
2 blanks above me.<br />
&lt;img src=""/Users/me/Library/Application Support/iPhone Simulator/5.1/Applications/1CE2234B-B4A3-4F22-A275-59745CD63625/Library/Caches/Emoticons/emot-science.gif"" title=""title""&gt;
		<!-- google_ad_section_end -->
		<!-- EndContentMarker -->


		<p class=""editedby"">
	</td>
</tr>
<tr class=""seen2"">
	<td class=""postdate"">
		<a class=""lastseen_icon"" href=""/showthread.php?action=setseen&amp;threadid=3532200&amp;index=7"" title=""Mark all replies as read to this point""><img src=""http://fi.somethingawful.com/style/posticon-seen.gif"" alt="""" border=""0""></a>
		<a href=""#post412439399"" title=""Link to this post"">#</a>
		<a class=""user_jump"" title=""Show posts by this user"" href=""/showthread.php?threadid=3532200&amp;userid=51070"">?</a>
		Feb 11, 2013 18:02
	</td>
	<td class=""postlinks"">
		<ul class=""profilelinks"">
			<li><a href=""member.php?action=getinfo&amp;userid=51070"">Profile</a></li>
			<li><a href=""private.php?action=newmessage&amp;userid=51070"">Message</a></li>
			<li><a href=""search.php?action=do_search_posthistory&amp;userid=51070"">Post History</a></li>
		</ul>
		<ul class=""postbuttons"">

			
			<li class=""alertbutton""><a href=""modalert.php?postid=412439399&amp;username=hardstyle""><img src=""http://forumimages.somethingawful.com/images/button-report.gif"" border=""0"" alt=""Alert Moderators""></a>&nbsp;&nbsp;</li>
			
			<li><a href=""newreply.php?action=newreply&amp;postid=412439399""><img src=""http://fi.somethingawful.com/images/sa-quote.gif"" alt=""Quote""  title=""""></a></li>


		</ul>
	</td>
</tr>
</table><table class=""post "" id=""post412509595"" data-idx=""8"">
<tr  class=""seen1"" id=""pti8"">
	<td class=""userinfo userid-70611"">
		<dl class=""userinfo"">
			<dt class=""author op"" title="""">bootleg robot</dt>
			<dd class=""registered"">Dec  7, 2004</dd>
			<dd class=""title"">
				<img src=""http://fi.somethingawful.com/customtitles/title-bootleg_robot-2.gif"" alt="""" class=""img"" border=""0""><br />
<br>
				<br class=""pb"">
			</dd>
		</dl>
	</td>
	<td class=""postbody"">
		<!-- BeginContentMarker -->
		<!-- google_ad_section_start -->
		Yo, I made a post!!
		<!-- google_ad_section_end -->
		<!-- EndContentMarker -->


		<p class=""editedby""><span>bootleg robot fucked around with this message at Mar  5, 2013 around 09:52</span>
	</td>
</tr>
<tr class=""seen1"">
	<td class=""postdate"">
		<a class=""lastseen_icon"" href=""/showthread.php?action=setseen&amp;threadid=3532200&amp;index=8"" title=""Mark all replies as read to this point""><img src=""http://fi.somethingawful.com/style/posticon-seen.gif"" alt="""" border=""0""></a>
		<a href=""#post412509595"" title=""Link to this post"">#</a>
		<a class=""user_jump"" title=""Show posts by this user"" href=""/showthread.php?threadid=3532200&amp;userid=70611"">?</a>
		Feb 13, 2013 16:29
	</td>
	<td class=""postlinks"">
		<ul class=""profilelinks"">
			<li><a href=""member.php?action=getinfo&amp;userid=70611"">Profile</a></li>
			<li><a href=""private.php?action=newmessage&amp;userid=70611"">Message</a></li>
			<li><a href=""search.php?action=do_search_posthistory&amp;userid=70611"">Post History</a></li>
		</ul>
		<ul class=""postbuttons"">

			
			<li class=""alertbutton""><a href=""modalert.php?postid=412509595&amp;username=bootleg+robot""><img src=""http://forumimages.somethingawful.com/images/button-report.gif"" border=""0"" alt=""Alert Moderators""></a>&nbsp;&nbsp;</li>
			
			<li><a href=""editpost.php?action=editpost&amp;postid=412509595""><img src=""http://fi.somethingawful.com/images/sa-edit.gif"" alt=""Edit"" title=""""></a></li>
			<li><a href=""newreply.php?action=newreply&amp;postid=412509595""><img src=""http://fi.somethingawful.com/images/sa-quote.gif"" alt=""Quote""  title=""""></a></li>


		</ul>
	</td>
</tr>
</table><table class=""post "" id=""post412509663"" data-idx=""9"">
<tr  class=""seen2"" id=""pti9"">
	<td class=""userinfo userid-70611"">
		<dl class=""userinfo"">
			<dt class=""author op"" title="""">bootleg robot</dt>
			<dd class=""registered"">Dec  7, 2004</dd>
			<dd class=""title"">
				<img src=""http://fi.somethingawful.com/customtitles/title-bootleg_robot-2.gif"" alt="""" class=""img"" border=""0""><br />
<br>
				<br class=""pb"">
			</dd>
		</dl>
	</td>
	<td class=""postbody"">
		<!-- BeginContentMarker -->
		<!-- google_ad_section_start -->
		Making another post...
		<!-- google_ad_section_end -->
		<!-- EndContentMarker -->


		<p class=""editedby"">
	</td>
</tr>
<tr class=""seen2"">
	<td class=""postdate"">
		<a class=""lastseen_icon"" href=""/showthread.php?action=setseen&amp;threadid=3532200&amp;index=9"" title=""Mark all replies as read to this point""><img src=""http://fi.somethingawful.com/style/posticon-seen.gif"" alt="""" border=""0""></a>
		<a href=""#post412509663"" title=""Link to this post"">#</a>
		<a class=""user_jump"" title=""Show posts by this user"" href=""/showthread.php?threadid=3532200&amp;userid=70611"">?</a>
		Feb 13, 2013 16:31
	</td>
	<td class=""postlinks"">
		<ul class=""profilelinks"">
			<li><a href=""member.php?action=getinfo&amp;userid=70611"">Profile</a></li>
			<li><a href=""private.php?action=newmessage&amp;userid=70611"">Message</a></li>
			<li><a href=""search.php?action=do_search_posthistory&amp;userid=70611"">Post History</a></li>
		</ul>
		<ul class=""postbuttons"">

			
			<li class=""alertbutton""><a href=""modalert.php?postid=412509663&amp;username=bootleg+robot""><img src=""http://forumimages.somethingawful.com/images/button-report.gif"" border=""0"" alt=""Alert Moderators""></a>&nbsp;&nbsp;</li>
			
			<li><a href=""editpost.php?action=editpost&amp;postid=412509663""><img src=""http://fi.somethingawful.com/images/sa-edit.gif"" alt=""Edit"" title=""""></a></li>
			<li><a href=""newreply.php?action=newreply&amp;postid=412509663""><img src=""http://fi.somethingawful.com/images/sa-quote.gif"" alt=""Quote""  title=""""></a></li>


		</ul>
	</td>
</tr>
</table><table class=""post "" id=""post412509713"" data-idx=""10"">
<tr  class=""seen1"" id=""pti10"">
	<td class=""userinfo userid-70611"">
		<dl class=""userinfo"">
			<dt class=""author op"" title="""">bootleg robot</dt>
			<dd class=""registered"">Dec  7, 2004</dd>
			<dd class=""title"">
				<img src=""http://fi.somethingawful.com/customtitles/title-bootleg_robot-2.gif"" alt="""" class=""img"" border=""0""><br />
<br>
				<br class=""pb"">
			</dd>
		</dl>
	</td>
	<td class=""postbody"">
		<!-- BeginContentMarker -->
		<!-- google_ad_section_start -->
		Making another post...
		<!-- google_ad_section_end -->
		<!-- EndContentMarker -->


		<p class=""editedby"">
	</td>
</tr>
<tr class=""seen1"">
	<td class=""postdate"">
		<a class=""lastseen_icon"" href=""/showthread.php?action=setseen&amp;threadid=3532200&amp;index=10"" title=""Mark all replies as read to this point""><img src=""http://fi.somethingawful.com/style/posticon-seen.gif"" alt="""" border=""0""></a>
		<a href=""#post412509713"" title=""Link to this post"">#</a>
		<a class=""user_jump"" title=""Show posts by this user"" href=""/showthread.php?threadid=3532200&amp;userid=70611"">?</a>
		Feb 13, 2013 16:33
	</td>
	<td class=""postlinks"">
		<ul class=""profilelinks"">
			<li><a href=""member.php?action=getinfo&amp;userid=70611"">Profile</a></li>
			<li><a href=""private.php?action=newmessage&amp;userid=70611"">Message</a></li>
			<li><a href=""search.php?action=do_search_posthistory&amp;userid=70611"">Post History</a></li>
		</ul>
		<ul class=""postbuttons"">

			
			<li class=""alertbutton""><a href=""modalert.php?postid=412509713&amp;username=bootleg+robot""><img src=""http://forumimages.somethingawful.com/images/button-report.gif"" border=""0"" alt=""Alert Moderators""></a>&nbsp;&nbsp;</li>
			
			<li><a href=""editpost.php?action=editpost&amp;postid=412509713""><img src=""http://fi.somethingawful.com/images/sa-edit.gif"" alt=""Edit"" title=""""></a></li>
			<li><a href=""newreply.php?action=newreply&amp;postid=412509713""><img src=""http://fi.somethingawful.com/images/sa-quote.gif"" alt=""Quote""  title=""""></a></li>


		</ul>
	</td>
</tr>
</table><table class=""post "" id=""post412765511"" data-idx=""11"">
<tr  class=""seen2"" id=""pti11"">
	<td class=""userinfo userid-70611"">
		<dl class=""userinfo"">
			<dt class=""author op"" title="""">bootleg robot</dt>
			<dd class=""registered"">Dec  7, 2004</dd>
			<dd class=""title"">
				<img src=""http://fi.somethingawful.com/customtitles/title-bootleg_robot-2.gif"" alt="""" class=""img"" border=""0""><br />
<br>
				<br class=""pb"">
			</dd>
		</dl>
	</td>
	<td class=""postbody"">
		<!-- BeginContentMarker -->
		<!-- google_ad_section_start -->
		Post test.<br />
<br />
Edit: !!!
		<!-- google_ad_section_end -->
		<!-- EndContentMarker -->


		<p class=""editedby"">
	</td>
</tr>
<tr class=""seen2"">
	<td class=""postdate"">
		<a class=""lastseen_icon"" href=""/showthread.php?action=setseen&amp;threadid=3532200&amp;index=11"" title=""Mark all replies as read to this point""><img src=""http://fi.somethingawful.com/style/posticon-seen.gif"" alt="""" border=""0""></a>
		<a href=""#post412765511"" title=""Link to this post"">#</a>
		<a class=""user_jump"" title=""Show posts by this user"" href=""/showthread.php?threadid=3532200&amp;userid=70611"">?</a>
		Feb 21, 2013 15:38
	</td>
	<td class=""postlinks"">
		<ul class=""profilelinks"">
			<li><a href=""member.php?action=getinfo&amp;userid=70611"">Profile</a></li>
			<li><a href=""private.php?action=newmessage&amp;userid=70611"">Message</a></li>
			<li><a href=""search.php?action=do_search_posthistory&amp;userid=70611"">Post History</a></li>
		</ul>
		<ul class=""postbuttons"">

			
			<li class=""alertbutton""><a href=""modalert.php?postid=412765511&amp;username=bootleg+robot""><img src=""http://forumimages.somethingawful.com/images/button-report.gif"" border=""0"" alt=""Alert Moderators""></a>&nbsp;&nbsp;</li>
			
			<li><a href=""editpost.php?action=editpost&amp;postid=412765511""><img src=""http://fi.somethingawful.com/images/sa-edit.gif"" alt=""Edit"" title=""""></a></li>
			<li><a href=""newreply.php?action=newreply&amp;postid=412765511""><img src=""http://fi.somethingawful.com/images/sa-quote.gif"" alt=""Quote""  title=""""></a></li>


		</ul>
	</td>
</tr>
</table><table class=""post "" id=""post412767468"" data-idx=""12"">
<tr  class=""seen1"" id=""pti12"">
	<td class=""userinfo userid-70611"">
		<dl class=""userinfo"">
			<dt class=""author op"" title="""">bootleg robot</dt>
			<dd class=""registered"">Dec  7, 2004</dd>
			<dd class=""title"">
				<img src=""http://fi.somethingawful.com/customtitles/title-bootleg_robot-2.gif"" alt="""" class=""img"" border=""0""><br />
<br>
				<br class=""pb"">
			</dd>
		</dl>
	</td>
	<td class=""postbody"">
		<!-- BeginContentMarker -->
		<!-- google_ad_section_start -->
		Posting again!
		<!-- google_ad_section_end -->
		<!-- EndContentMarker -->


		<p class=""editedby"">
	</td>
</tr>
<tr class=""seen1"">
	<td class=""postdate"">
		<a class=""lastseen_icon"" href=""/showthread.php?action=setseen&amp;threadid=3532200&amp;index=12"" title=""Mark all replies as read to this point""><img src=""http://fi.somethingawful.com/style/posticon-seen.gif"" alt="""" border=""0""></a>
		<a href=""#post412767468"" title=""Link to this post"">#</a>
		<a class=""user_jump"" title=""Show posts by this user"" href=""/showthread.php?threadid=3532200&amp;userid=70611"">?</a>
		Feb 21, 2013 16:33
	</td>
	<td class=""postlinks"">
		<ul class=""profilelinks"">
			<li><a href=""member.php?action=getinfo&amp;userid=70611"">Profile</a></li>
			<li><a href=""private.php?action=newmessage&amp;userid=70611"">Message</a></li>
			<li><a href=""search.php?action=do_search_posthistory&amp;userid=70611"">Post History</a></li>
		</ul>
		<ul class=""postbuttons"">

			
			<li class=""alertbutton""><a href=""modalert.php?postid=412767468&amp;username=bootleg+robot""><img src=""http://forumimages.somethingawful.com/images/button-report.gif"" border=""0"" alt=""Alert Moderators""></a>&nbsp;&nbsp;</li>
			
			<li><a href=""editpost.php?action=editpost&amp;postid=412767468""><img src=""http://fi.somethingawful.com/images/sa-edit.gif"" alt=""Edit"" title=""""></a></li>
			<li><a href=""newreply.php?action=newreply&amp;postid=412767468""><img src=""http://fi.somethingawful.com/images/sa-quote.gif"" alt=""Quote""  title=""""></a></li>


		</ul>
	</td>
</tr>
</table><table class=""post "" id=""post412832246"" data-idx=""13"">
<tr  class=""seen2"" id=""pti13"">
	<td class=""userinfo userid-106125"">
		<dl class=""userinfo"">
			<dt class=""author"" title="""">pokeyman</dt>
			<dd class=""registered"">Nov 26, 2006</dd>
			<dd class=""title"">
				<img src=""http://fi.somethingawful.com/customtitles/title-pokeyman.jpg""><br>What do you like to play?<br>
				<br class=""pb"">
			</dd>
		</dl>
	</td>
	<td class=""postbody"">
		<!-- BeginContentMarker -->
		<!-- google_ad_section_start -->
		Wooooooooooo
		<!-- google_ad_section_end -->
		<!-- EndContentMarker -->


		<p class=""editedby"">
	</td>
</tr>
<tr class=""seen2"">
	<td class=""postdate"">
		<a class=""lastseen_icon"" href=""/showthread.php?action=setseen&amp;threadid=3532200&amp;index=13"" title=""Mark all replies as read to this point""><img src=""http://fi.somethingawful.com/style/posticon-seen.gif"" alt="""" border=""0""></a>
		<a href=""#post412832246"" title=""Link to this post"">#</a>
		<a class=""user_jump"" title=""Show posts by this user"" href=""/showthread.php?threadid=3532200&amp;userid=106125"">?</a>
		Feb 23, 2013 20:15
	</td>
	<td class=""postlinks"">
		<ul class=""profilelinks"">
			<li><a href=""member.php?action=getinfo&amp;userid=106125"">Profile</a></li>
			<li><a href=""private.php?action=newmessage&amp;userid=106125"">Message</a></li>
			<li><a href=""search.php?action=do_search_posthistory&amp;userid=106125"">Post History</a></li>
		</ul>
		<ul class=""postbuttons"">

			
			<li class=""alertbutton""><a href=""modalert.php?postid=412832246&amp;username=pokeyman""><img src=""http://forumimages.somethingawful.com/images/button-report.gif"" border=""0"" alt=""Alert Moderators""></a>&nbsp;&nbsp;</li>
			
			<li><a href=""newreply.php?action=newreply&amp;postid=412832246""><img src=""http://fi.somethingawful.com/images/sa-quote.gif"" alt=""Quote""  title=""""></a></li>


		</ul>
	</td>
</tr>
</table><table class=""post "" id=""post412832267"" data-idx=""14"">
<tr  class=""seen1"" id=""pti14"">
	<td class=""userinfo userid-106125"">
		<dl class=""userinfo"">
			<dt class=""author"" title="""">pokeyman</dt>
			<dd class=""registered"">Nov 26, 2006</dd>
			<dd class=""title"">
				<img src=""http://fi.somethingawful.com/customtitles/title-pokeyman.jpg""><br>What do you like to play?<br>
				<br class=""pb"">
			</dd>
		</dl>
	</td>
	<td class=""postbody"">
		<!-- BeginContentMarker -->
		<!-- google_ad_section_start -->
		Yeaaaaaaaaaaaaaaaaah
		<!-- google_ad_section_end -->
		<!-- EndContentMarker -->


		<p class=""editedby"">
	</td>
</tr>
<tr class=""seen1"">
	<td class=""postdate"">
		<a class=""lastseen_icon"" href=""/showthread.php?action=setseen&amp;threadid=3532200&amp;index=14"" title=""Mark all replies as read to this point""><img src=""http://fi.somethingawful.com/style/posticon-seen.gif"" alt="""" border=""0""></a>
		<a href=""#post412832267"" title=""Link to this post"">#</a>
		<a class=""user_jump"" title=""Show posts by this user"" href=""/showthread.php?threadid=3532200&amp;userid=106125"">?</a>
		Feb 23, 2013 20:16
	</td>
	<td class=""postlinks"">
		<ul class=""profilelinks"">
			<li><a href=""member.php?action=getinfo&amp;userid=106125"">Profile</a></li>
			<li><a href=""private.php?action=newmessage&amp;userid=106125"">Message</a></li>
			<li><a href=""search.php?action=do_search_posthistory&amp;userid=106125"">Post History</a></li>
		</ul>
		<ul class=""postbuttons"">

			
			<li class=""alertbutton""><a href=""modalert.php?postid=412832267&amp;username=pokeyman""><img src=""http://forumimages.somethingawful.com/images/button-report.gif"" border=""0"" alt=""Alert Moderators""></a>&nbsp;&nbsp;</li>
			
			<li><a href=""newreply.php?action=newreply&amp;postid=412832267""><img src=""http://fi.somethingawful.com/images/sa-quote.gif"" alt=""Quote""  title=""""></a></li>


		</ul>
	</td>
</tr>
</table><table class=""post "" id=""post412941817"" data-idx=""15"">
<tr  class=""seen2"" id=""pti15"">
	<td class=""userinfo userid-70611"">
		<dl class=""userinfo"">
			<dt class=""author op"" title="""">bootleg robot</dt>
			<dd class=""registered"">Dec  7, 2004</dd>
			<dd class=""title"">
				<img src=""http://fi.somethingawful.com/customtitles/title-bootleg_robot-2.gif"" alt="""" class=""img"" border=""0""><br />
<br>
				<br class=""pb"">
			</dd>
		</dl>
	</td>
	<td class=""postbody"">
		<!-- BeginContentMarker -->
		<!-- google_ad_section_start -->
		Testing...
		<!-- google_ad_section_end -->
		<!-- EndContentMarker -->


		<p class=""editedby"">
	</td>
</tr>
<tr class=""seen2"">
	<td class=""postdate"">
		<a class=""lastseen_icon"" href=""/showthread.php?action=setseen&amp;threadid=3532200&amp;index=15"" title=""Mark all replies as read to this point""><img src=""http://fi.somethingawful.com/style/posticon-seen.gif"" alt="""" border=""0""></a>
		<a href=""#post412941817"" title=""Link to this post"">#</a>
		<a class=""user_jump"" title=""Show posts by this user"" href=""/showthread.php?threadid=3532200&amp;userid=70611"">?</a>
		Feb 27, 2013 07:38
	</td>
	<td class=""postlinks"">
		<ul class=""profilelinks"">
			<li><a href=""member.php?action=getinfo&amp;userid=70611"">Profile</a></li>
			<li><a href=""private.php?action=newmessage&amp;userid=70611"">Message</a></li>
			<li><a href=""search.php?action=do_search_posthistory&amp;userid=70611"">Post History</a></li>
		</ul>
		<ul class=""postbuttons"">

			
			<li class=""alertbutton""><a href=""modalert.php?postid=412941817&amp;username=bootleg+robot""><img src=""http://forumimages.somethingawful.com/images/button-report.gif"" border=""0"" alt=""Alert Moderators""></a>&nbsp;&nbsp;</li>
			
			<li><a href=""editpost.php?action=editpost&amp;postid=412941817""><img src=""http://fi.somethingawful.com/images/sa-edit.gif"" alt=""Edit"" title=""""></a></li>
			<li><a href=""newreply.php?action=newreply&amp;postid=412941817""><img src=""http://fi.somethingawful.com/images/sa-quote.gif"" alt=""Quote""  title=""""></a></li>


		</ul>
	</td>
</tr>
</table><table class=""post "" id=""post412941939"" data-idx=""16"">
<tr  class=""seen1"" id=""pti16"">
	<td class=""userinfo userid-70611"">
		<dl class=""userinfo"">
			<dt class=""author op"" title="""">bootleg robot</dt>
			<dd class=""registered"">Dec  7, 2004</dd>
			<dd class=""title"">
				<img src=""http://fi.somethingawful.com/customtitles/title-bootleg_robot-2.gif"" alt="""" class=""img"" border=""0""><br />
<br>
				<br class=""pb"">
			</dd>
		</dl>
	</td>
	<td class=""postbody"">
		<!-- BeginContentMarker -->
		<!-- google_ad_section_start -->
		Making a post...
		<!-- google_ad_section_end -->
		<!-- EndContentMarker -->


		<p class=""editedby"">
	</td>
</tr>
<tr class=""seen1"">
	<td class=""postdate"">
		<a class=""lastseen_icon"" href=""/showthread.php?action=setseen&amp;threadid=3532200&amp;index=16"" title=""Mark all replies as read to this point""><img src=""http://fi.somethingawful.com/style/posticon-seen.gif"" alt="""" border=""0""></a>
		<a href=""#post412941939"" title=""Link to this post"">#</a>
		<a class=""user_jump"" title=""Show posts by this user"" href=""/showthread.php?threadid=3532200&amp;userid=70611"">?</a>
		Feb 27, 2013 07:46
	</td>
	<td class=""postlinks"">
		<ul class=""profilelinks"">
			<li><a href=""member.php?action=getinfo&amp;userid=70611"">Profile</a></li>
			<li><a href=""private.php?action=newmessage&amp;userid=70611"">Message</a></li>
			<li><a href=""search.php?action=do_search_posthistory&amp;userid=70611"">Post History</a></li>
		</ul>
		<ul class=""postbuttons"">

			
			<li class=""alertbutton""><a href=""modalert.php?postid=412941939&amp;username=bootleg+robot""><img src=""http://forumimages.somethingawful.com/images/button-report.gif"" border=""0"" alt=""Alert Moderators""></a>&nbsp;&nbsp;</li>
			
			<li><a href=""editpost.php?action=editpost&amp;postid=412941939""><img src=""http://fi.somethingawful.com/images/sa-edit.gif"" alt=""Edit"" title=""""></a></li>
			<li><a href=""newreply.php?action=newreply&amp;postid=412941939""><img src=""http://fi.somethingawful.com/images/sa-quote.gif"" alt=""Quote""  title=""""></a></li>


		</ul>
	</td>
</tr>
</table><table class=""post "" id=""post413051824"" data-idx=""17"">
<tr  class=""seen2"" id=""pti17"">
	<td class=""userinfo userid-70611"">
		<dl class=""userinfo"">
			<dt class=""author op"" title="""">bootleg robot</dt>
			<dd class=""registered"">Dec  7, 2004</dd>
			<dd class=""title"">
				<img src=""http://fi.somethingawful.com/customtitles/title-bootleg_robot-2.gif"" alt="""" class=""img"" border=""0""><br />
<br>
				<br class=""pb"">
			</dd>
		</dl>
	</td>
	<td class=""postbody"">
		<!-- BeginContentMarker -->
		<!-- google_ad_section_start -->
		Postin...
		<!-- google_ad_section_end -->
		<!-- EndContentMarker -->


		<p class=""editedby"">
	</td>
</tr>
<tr class=""seen2"">
	<td class=""postdate"">
		<a class=""lastseen_icon"" href=""/showthread.php?action=setseen&amp;threadid=3532200&amp;index=17"" title=""Mark all replies as read to this point""><img src=""http://fi.somethingawful.com/style/posticon-seen.gif"" alt="""" border=""0""></a>
		<a href=""#post413051824"" title=""Link to this post"">#</a>
		<a class=""user_jump"" title=""Show posts by this user"" href=""/showthread.php?threadid=3532200&amp;userid=70611"">?</a>
		Mar  2, 2013 17:39
	</td>
	<td class=""postlinks"">
		<ul class=""profilelinks"">
			<li><a href=""member.php?action=getinfo&amp;userid=70611"">Profile</a></li>
			<li><a href=""private.php?action=newmessage&amp;userid=70611"">Message</a></li>
			<li><a href=""search.php?action=do_search_posthistory&amp;userid=70611"">Post History</a></li>
		</ul>
		<ul class=""postbuttons"">

			
			<li class=""alertbutton""><a href=""modalert.php?postid=413051824&amp;username=bootleg+robot""><img src=""http://forumimages.somethingawful.com/images/button-report.gif"" border=""0"" alt=""Alert Moderators""></a>&nbsp;&nbsp;</li>
			
			<li><a href=""editpost.php?action=editpost&amp;postid=413051824""><img src=""http://fi.somethingawful.com/images/sa-edit.gif"" alt=""Edit"" title=""""></a></li>
			<li><a href=""newreply.php?action=newreply&amp;postid=413051824""><img src=""http://fi.somethingawful.com/images/sa-quote.gif"" alt=""Quote""  title=""""></a></li>


		</ul>
	</td>
</tr>
</table><table class=""post "" id=""post413052163"" data-idx=""18"">
<tr  class=""seen1"" id=""pti18"">
	<td class=""userinfo userid-70611"">
		<dl class=""userinfo"">
			<dt class=""author op"" title="""">bootleg robot</dt>
			<dd class=""registered"">Dec  7, 2004</dd>
			<dd class=""title"">
				<img src=""http://fi.somethingawful.com/customtitles/title-bootleg_robot-2.gif"" alt="""" class=""img"" border=""0""><br />
<br>
				<br class=""pb"">
			</dd>
		</dl>
	</td>
	<td class=""postbody"">
		<!-- BeginContentMarker -->
		<!-- google_ad_section_start -->
		Toast
		<!-- google_ad_section_end -->
		<!-- EndContentMarker -->


		<p class=""editedby""><span>bootleg robot fucked around with this message at Mar  2, 2013 around 18:14</span>
	</td>
</tr>
<tr class=""seen1"">
	<td class=""postdate"">
		<a class=""lastseen_icon"" href=""/showthread.php?action=setseen&amp;threadid=3532200&amp;index=18"" title=""Mark all replies as read to this point""><img src=""http://fi.somethingawful.com/style/posticon-seen.gif"" alt="""" border=""0""></a>
		<a href=""#post413052163"" title=""Link to this post"">#</a>
		<a class=""user_jump"" title=""Show posts by this user"" href=""/showthread.php?threadid=3532200&amp;userid=70611"">?</a>
		Mar  2, 2013 17:55
	</td>
	<td class=""postlinks"">
		<ul class=""profilelinks"">
			<li><a href=""member.php?action=getinfo&amp;userid=70611"">Profile</a></li>
			<li><a href=""private.php?action=newmessage&amp;userid=70611"">Message</a></li>
			<li><a href=""search.php?action=do_search_posthistory&amp;userid=70611"">Post History</a></li>
		</ul>
		<ul class=""postbuttons"">

			
			<li class=""alertbutton""><a href=""modalert.php?postid=413052163&amp;username=bootleg+robot""><img src=""http://forumimages.somethingawful.com/images/button-report.gif"" border=""0"" alt=""Alert Moderators""></a>&nbsp;&nbsp;</li>
			
			<li><a href=""editpost.php?action=editpost&amp;postid=413052163""><img src=""http://fi.somethingawful.com/images/sa-edit.gif"" alt=""Edit"" title=""""></a></li>
			<li><a href=""newreply.php?action=newreply&amp;postid=413052163""><img src=""http://fi.somethingawful.com/images/sa-quote.gif"" alt=""Quote""  title=""""></a></li>


		</ul>
	</td>
</tr>
</table><table class=""post "" id=""post413094478"" data-idx=""19"">
<tr  class=""seen2"" id=""pti19"">
	<td class=""userinfo userid-70611"">
		<dl class=""userinfo"">
			<dt class=""author op"" title="""">bootleg robot</dt>
			<dd class=""registered"">Dec  7, 2004</dd>
			<dd class=""title"">
				<img src=""http://fi.somethingawful.com/customtitles/title-bootleg_robot-2.gif"" alt="""" class=""img"" border=""0""><br />
<br>
				<br class=""pb"">
			</dd>
		</dl>
	</td>
	<td class=""postbody"">
		<!-- BeginContentMarker -->
		<!-- google_ad_section_start -->
		P-P-P-That's all post!
		<!-- google_ad_section_end -->
		<!-- EndContentMarker -->


		<p class=""editedby"">
	</td>
</tr>
<tr class=""seen2"">
	<td class=""postdate"">
		<a class=""lastseen_icon"" href=""/showthread.php?action=setseen&amp;threadid=3532200&amp;index=19"" title=""Mark all replies as read to this point""><img src=""http://fi.somethingawful.com/style/posticon-seen.gif"" alt="""" border=""0""></a>
		<a href=""#post413094478"" title=""Link to this post"">#</a>
		<a class=""user_jump"" title=""Show posts by this user"" href=""/showthread.php?threadid=3532200&amp;userid=70611"">?</a>
		Mar  4, 2013 07:02
	</td>
	<td class=""postlinks"">
		<ul class=""profilelinks"">
			<li><a href=""member.php?action=getinfo&amp;userid=70611"">Profile</a></li>
			<li><a href=""private.php?action=newmessage&amp;userid=70611"">Message</a></li>
			<li><a href=""search.php?action=do_search_posthistory&amp;userid=70611"">Post History</a></li>
		</ul>
		<ul class=""postbuttons"">

			
			<li class=""alertbutton""><a href=""modalert.php?postid=413094478&amp;username=bootleg+robot""><img src=""http://forumimages.somethingawful.com/images/button-report.gif"" border=""0"" alt=""Alert Moderators""></a>&nbsp;&nbsp;</li>
			
			<li><a href=""editpost.php?action=editpost&amp;postid=413094478""><img src=""http://fi.somethingawful.com/images/sa-edit.gif"" alt=""Edit"" title=""""></a></li>
			<li><a href=""newreply.php?action=newreply&amp;postid=413094478""><img src=""http://fi.somethingawful.com/images/sa-quote.gif"" alt=""Quote""  title=""""></a></li>


		</ul>
	</td>
</tr>
</table><table class=""post "" id=""post413101732"" data-idx=""20"">
<tr  class=""seen1"" id=""pti20"">
	<td class=""userinfo userid-70611"">
		<dl class=""userinfo"">
			<dt class=""author op"" title="""">bootleg robot</dt>
			<dd class=""registered"">Dec  7, 2004</dd>
			<dd class=""title"">
				<img src=""http://fi.somethingawful.com/customtitles/title-bootleg_robot-2.gif"" alt="""" class=""img"" border=""0""><br />
<br>
				<br class=""pb"">
			</dd>
		</dl>
	</td>
	<td class=""postbody"">
		<!-- BeginContentMarker -->
		<!-- google_ad_section_start -->
		Test post.
		<!-- google_ad_section_end -->
		<!-- EndContentMarker -->


		<p class=""editedby"">
	</td>
</tr>
<tr class=""seen1"">
	<td class=""postdate"">
		<a class=""lastseen_icon"" href=""/showthread.php?action=setseen&amp;threadid=3532200&amp;index=20"" title=""Mark all replies as read to this point""><img src=""http://fi.somethingawful.com/style/posticon-seen.gif"" alt="""" border=""0""></a>
		<a href=""#post413101732"" title=""Link to this post"">#</a>
		<a class=""user_jump"" title=""Show posts by this user"" href=""/showthread.php?threadid=3532200&amp;userid=70611"">?</a>
		Mar  4, 2013 12:28
	</td>
	<td class=""postlinks"">
		<ul class=""profilelinks"">
			<li><a href=""member.php?action=getinfo&amp;userid=70611"">Profile</a></li>
			<li><a href=""private.php?action=newmessage&amp;userid=70611"">Message</a></li>
			<li><a href=""search.php?action=do_search_posthistory&amp;userid=70611"">Post History</a></li>
		</ul>
		<ul class=""postbuttons"">

			
			<li class=""alertbutton""><a href=""modalert.php?postid=413101732&amp;username=bootleg+robot""><img src=""http://forumimages.somethingawful.com/images/button-report.gif"" border=""0"" alt=""Alert Moderators""></a>&nbsp;&nbsp;</li>
			
			<li><a href=""editpost.php?action=editpost&amp;postid=413101732""><img src=""http://fi.somethingawful.com/images/sa-edit.gif"" alt=""Edit"" title=""""></a></li>
			<li><a href=""newreply.php?action=newreply&amp;postid=413101732""><img src=""http://fi.somethingawful.com/images/sa-quote.gif"" alt=""Quote""  title=""""></a></li>


		</ul>
	</td>
</tr>
</table><table class=""post "" id=""post413101883"" data-idx=""21"">
<tr  class=""seen2"" id=""pti21"">
	<td class=""userinfo userid-70611"">
		<dl class=""userinfo"">
			<dt class=""author op"" title="""">bootleg robot</dt>
			<dd class=""registered"">Dec  7, 2004</dd>
			<dd class=""title"">
				<img src=""http://fi.somethingawful.com/customtitles/title-bootleg_robot-2.gif"" alt="""" class=""img"" border=""0""><br />
<br>
				<br class=""pb"">
			</dd>
		</dl>
	</td>
	<td class=""postbody"">
		<!-- BeginContentMarker -->
		<!-- google_ad_section_start -->
		Another post.
		<!-- google_ad_section_end -->
		<!-- EndContentMarker -->


		<p class=""editedby"">
	</td>
</tr>
<tr class=""seen2"">
	<td class=""postdate"">
		<a class=""lastseen_icon"" href=""/showthread.php?action=setseen&amp;threadid=3532200&amp;index=21"" title=""Mark all replies as read to this point""><img src=""http://fi.somethingawful.com/style/posticon-seen.gif"" alt="""" border=""0""></a>
		<a href=""#post413101883"" title=""Link to this post"">#</a>
		<a class=""user_jump"" title=""Show posts by this user"" href=""/showthread.php?threadid=3532200&amp;userid=70611"">?</a>
		Mar  4, 2013 12:32
	</td>
	<td class=""postlinks"">
		<ul class=""profilelinks"">
			<li><a href=""member.php?action=getinfo&amp;userid=70611"">Profile</a></li>
			<li><a href=""private.php?action=newmessage&amp;userid=70611"">Message</a></li>
			<li><a href=""search.php?action=do_search_posthistory&amp;userid=70611"">Post History</a></li>
		</ul>
		<ul class=""postbuttons"">

			
			<li class=""alertbutton""><a href=""modalert.php?postid=413101883&amp;username=bootleg+robot""><img src=""http://forumimages.somethingawful.com/images/button-report.gif"" border=""0"" alt=""Alert Moderators""></a>&nbsp;&nbsp;</li>
			
			<li><a href=""editpost.php?action=editpost&amp;postid=413101883""><img src=""http://fi.somethingawful.com/images/sa-edit.gif"" alt=""Edit"" title=""""></a></li>
			<li><a href=""newreply.php?action=newreply&amp;postid=413101883""><img src=""http://fi.somethingawful.com/images/sa-quote.gif"" alt=""Quote""  title=""""></a></li>


		</ul>
	</td>
</tr>
</table><table class=""post "" id=""post413102068"" data-idx=""22"">
<tr  class=""seen1"" id=""pti22"">
	<td class=""userinfo userid-70611"">
		<dl class=""userinfo"">
			<dt class=""author op"" title="""">bootleg robot</dt>
			<dd class=""registered"">Dec  7, 2004</dd>
			<dd class=""title"">
				<img src=""http://fi.somethingawful.com/customtitles/title-bootleg_robot-2.gif"" alt="""" class=""img"" border=""0""><br />
<br>
				<br class=""pb"">
			</dd>
		</dl>
	</td>
	<td class=""postbody"">
		<!-- BeginContentMarker -->
		<!-- google_ad_section_start -->
		And another, which I just edited.
		<!-- google_ad_section_end -->
		<!-- EndContentMarker -->


		<p class=""editedby""><span>bootleg robot fucked around with this message at Mar  4, 2013 around 12:41</span>
	</td>
</tr>
<tr class=""seen1"">
	<td class=""postdate"">
		<a class=""lastseen_icon"" href=""/showthread.php?action=setseen&amp;threadid=3532200&amp;index=22"" title=""Mark all replies as read to this point""><img src=""http://fi.somethingawful.com/style/posticon-seen.gif"" alt="""" border=""0""></a>
		<a href=""#post413102068"" title=""Link to this post"">#</a>
		<a class=""user_jump"" title=""Show posts by this user"" href=""/showthread.php?threadid=3532200&amp;userid=70611"">?</a>
		Mar  4, 2013 12:37
	</td>
	<td class=""postlinks"">
		<ul class=""profilelinks"">
			<li><a href=""member.php?action=getinfo&amp;userid=70611"">Profile</a></li>
			<li><a href=""private.php?action=newmessage&amp;userid=70611"">Message</a></li>
			<li><a href=""search.php?action=do_search_posthistory&amp;userid=70611"">Post History</a></li>
		</ul>
		<ul class=""postbuttons"">

			
			<li class=""alertbutton""><a href=""modalert.php?postid=413102068&amp;username=bootleg+robot""><img src=""http://forumimages.somethingawful.com/images/button-report.gif"" border=""0"" alt=""Alert Moderators""></a>&nbsp;&nbsp;</li>
			
			<li><a href=""editpost.php?action=editpost&amp;postid=413102068""><img src=""http://fi.somethingawful.com/images/sa-edit.gif"" alt=""Edit"" title=""""></a></li>
			<li><a href=""newreply.php?action=newreply&amp;postid=413102068""><img src=""http://fi.somethingawful.com/images/sa-quote.gif"" alt=""Quote""  title=""""></a></li>


		</ul>
	</td>
</tr>
</table><table class=""post "" id=""post413103552"" data-idx=""23"">
<tr  class=""seen2"" id=""pti23"">
	<td class=""userinfo userid-70611"">
		<dl class=""userinfo"">
			<dt class=""author op"" title="""">bootleg robot</dt>
			<dd class=""registered"">Dec  7, 2004</dd>
			<dd class=""title"">
				<img src=""http://fi.somethingawful.com/customtitles/title-bootleg_robot-2.gif"" alt="""" class=""img"" border=""0""><br />
<br>
				<br class=""pb"">
			</dd>
		</dl>
	</td>
	<td class=""postbody"">
		<!-- BeginContentMarker -->
		<!-- google_ad_section_start -->
		Post test.
		<!-- google_ad_section_end -->
		<!-- EndContentMarker -->


		<p class=""editedby"">
	</td>
</tr>
<tr class=""seen2"">
	<td class=""postdate"">
		<a class=""lastseen_icon"" href=""/showthread.php?action=setseen&amp;threadid=3532200&amp;index=23"" title=""Mark all replies as read to this point""><img src=""http://fi.somethingawful.com/style/posticon-seen.gif"" alt="""" border=""0""></a>
		<a href=""#post413103552"" title=""Link to this post"">#</a>
		<a class=""user_jump"" title=""Show posts by this user"" href=""/showthread.php?threadid=3532200&amp;userid=70611"">?</a>
		Mar  4, 2013 13:20
	</td>
	<td class=""postlinks"">
		<ul class=""profilelinks"">
			<li><a href=""member.php?action=getinfo&amp;userid=70611"">Profile</a></li>
			<li><a href=""private.php?action=newmessage&amp;userid=70611"">Message</a></li>
			<li><a href=""search.php?action=do_search_posthistory&amp;userid=70611"">Post History</a></li>
		</ul>
		<ul class=""postbuttons"">

			
			<li class=""alertbutton""><a href=""modalert.php?postid=413103552&amp;username=bootleg+robot""><img src=""http://forumimages.somethingawful.com/images/button-report.gif"" border=""0"" alt=""Alert Moderators""></a>&nbsp;&nbsp;</li>
			
			<li><a href=""editpost.php?action=editpost&amp;postid=413103552""><img src=""http://fi.somethingawful.com/images/sa-edit.gif"" alt=""Edit"" title=""""></a></li>
			<li><a href=""newreply.php?action=newreply&amp;postid=413103552""><img src=""http://fi.somethingawful.com/images/sa-quote.gif"" alt=""Quote""  title=""""></a></li>


		</ul>
	</td>
</tr>
</table><table class=""post "" id=""post413103621"" data-idx=""24"">
<tr  class=""seen1"" id=""pti24"">
	<td class=""userinfo userid-70611"">
		<dl class=""userinfo"">
			<dt class=""author op"" title="""">bootleg robot</dt>
			<dd class=""registered"">Dec  7, 2004</dd>
			<dd class=""title"">
				<img src=""http://fi.somethingawful.com/customtitles/title-bootleg_robot-2.gif"" alt="""" class=""img"" border=""0""><br />
<br>
				<br class=""pb"">
			</dd>
		</dl>
	</td>
	<td class=""postbody"">
		<!-- BeginContentMarker -->
		<!-- google_ad_section_start -->
		Post test for redirect....
		<!-- google_ad_section_end -->
		<!-- EndContentMarker -->


		<p class=""editedby""><span>bootleg robot fucked around with this message at Mar  4, 2013 around 14:38</span>
	</td>
</tr>
<tr class=""seen1"">
	<td class=""postdate"">
		<a class=""lastseen_icon"" href=""/showthread.php?action=setseen&amp;threadid=3532200&amp;index=24"" title=""Mark all replies as read to this point""><img src=""http://fi.somethingawful.com/style/posticon-seen.gif"" alt="""" border=""0""></a>
		<a href=""#post413103621"" title=""Link to this post"">#</a>
		<a class=""user_jump"" title=""Show posts by this user"" href=""/showthread.php?threadid=3532200&amp;userid=70611"">?</a>
		Mar  4, 2013 13:22
	</td>
	<td class=""postlinks"">
		<ul class=""profilelinks"">
			<li><a href=""member.php?action=getinfo&amp;userid=70611"">Profile</a></li>
			<li><a href=""private.php?action=newmessage&amp;userid=70611"">Message</a></li>
			<li><a href=""search.php?action=do_search_posthistory&amp;userid=70611"">Post History</a></li>
		</ul>
		<ul class=""postbuttons"">

			
			<li class=""alertbutton""><a href=""modalert.php?postid=413103621&amp;username=bootleg+robot""><img src=""http://forumimages.somethingawful.com/images/button-report.gif"" border=""0"" alt=""Alert Moderators""></a>&nbsp;&nbsp;</li>
			
			<li><a href=""editpost.php?action=editpost&amp;postid=413103621""><img src=""http://fi.somethingawful.com/images/sa-edit.gif"" alt=""Edit"" title=""""></a></li>
			<li><a href=""newreply.php?action=newreply&amp;postid=413103621""><img src=""http://fi.somethingawful.com/images/sa-quote.gif"" alt=""Quote""  title=""""></a></li>


		</ul>
	</td>
</tr>
</table><table class=""post "" id=""post413103844"" data-idx=""25"">
<tr  class=""seen2"" id=""pti25"">
	<td class=""userinfo userid-70611"">
		<dl class=""userinfo"">
			<dt class=""author op"" title="""">bootleg robot</dt>
			<dd class=""registered"">Dec  7, 2004</dd>
			<dd class=""title"">
				<img src=""http://fi.somethingawful.com/customtitles/title-bootleg_robot-2.gif"" alt="""" class=""img"" border=""0""><br />
<br>
				<br class=""pb"">
			</dd>
		</dl>
	</td>
	<td class=""postbody"">
		<!-- BeginContentMarker -->
		<!-- google_ad_section_start -->
		Do it again!
		<!-- google_ad_section_end -->
		<!-- EndContentMarker -->


		<p class=""editedby"">
	</td>
</tr>
<tr class=""seen2"">
	<td class=""postdate"">
		<a class=""lastseen_icon"" href=""/showthread.php?action=setseen&amp;threadid=3532200&amp;index=25"" title=""Mark all replies as read to this point""><img src=""http://fi.somethingawful.com/style/posticon-seen.gif"" alt="""" border=""0""></a>
		<a href=""#post413103844"" title=""Link to this post"">#</a>
		<a class=""user_jump"" title=""Show posts by this user"" href=""/showthread.php?threadid=3532200&amp;userid=70611"">?</a>
		Mar  4, 2013 13:30
	</td>
	<td class=""postlinks"">
		<ul class=""profilelinks"">
			<li><a href=""member.php?action=getinfo&amp;userid=70611"">Profile</a></li>
			<li><a href=""private.php?action=newmessage&amp;userid=70611"">Message</a></li>
			<li><a href=""search.php?action=do_search_posthistory&amp;userid=70611"">Post History</a></li>
		</ul>
		<ul class=""postbuttons"">

			
			<li class=""alertbutton""><a href=""modalert.php?postid=413103844&amp;username=bootleg+robot""><img src=""http://forumimages.somethingawful.com/images/button-report.gif"" border=""0"" alt=""Alert Moderators""></a>&nbsp;&nbsp;</li>
			
			<li><a href=""editpost.php?action=editpost&amp;postid=413103844""><img src=""http://fi.somethingawful.com/images/sa-edit.gif"" alt=""Edit"" title=""""></a></li>
			<li><a href=""newreply.php?action=newreply&amp;postid=413103844""><img src=""http://fi.somethingawful.com/images/sa-quote.gif"" alt=""Quote""  title=""""></a></li>


		</ul>
	</td>
</tr>
</table><table class=""post "" id=""post413103928"" data-idx=""26"">
<tr  class=""seen1"" id=""pti26"">
	<td class=""userinfo userid-70611"">
		<dl class=""userinfo"">
			<dt class=""author op"" title="""">bootleg robot</dt>
			<dd class=""registered"">Dec  7, 2004</dd>
			<dd class=""title"">
				<img src=""http://fi.somethingawful.com/customtitles/title-bootleg_robot-2.gif"" alt="""" class=""img"" border=""0""><br />
<br>
				<br class=""pb"">
			</dd>
		</dl>
	</td>
	<td class=""postbody"">
		<!-- BeginContentMarker -->
		<!-- google_ad_section_start -->
		And again!
		<!-- google_ad_section_end -->
		<!-- EndContentMarker -->


		<p class=""editedby"">
	</td>
</tr>
<tr class=""seen1"">
	<td class=""postdate"">
		<a class=""lastseen_icon"" href=""/showthread.php?action=setseen&amp;threadid=3532200&amp;index=26"" title=""Mark all replies as read to this point""><img src=""http://fi.somethingawful.com/style/posticon-seen.gif"" alt="""" border=""0""></a>
		<a href=""#post413103928"" title=""Link to this post"">#</a>
		<a class=""user_jump"" title=""Show posts by this user"" href=""/showthread.php?threadid=3532200&amp;userid=70611"">?</a>
		Mar  4, 2013 13:32
	</td>
	<td class=""postlinks"">
		<ul class=""profilelinks"">
			<li><a href=""member.php?action=getinfo&amp;userid=70611"">Profile</a></li>
			<li><a href=""private.php?action=newmessage&amp;userid=70611"">Message</a></li>
			<li><a href=""search.php?action=do_search_posthistory&amp;userid=70611"">Post History</a></li>
		</ul>
		<ul class=""postbuttons"">

			
			<li class=""alertbutton""><a href=""modalert.php?postid=413103928&amp;username=bootleg+robot""><img src=""http://forumimages.somethingawful.com/images/button-report.gif"" border=""0"" alt=""Alert Moderators""></a>&nbsp;&nbsp;</li>
			
			<li><a href=""editpost.php?action=editpost&amp;postid=413103928""><img src=""http://fi.somethingawful.com/images/sa-edit.gif"" alt=""Edit"" title=""""></a></li>
			<li><a href=""newreply.php?action=newreply&amp;postid=413103928""><img src=""http://fi.somethingawful.com/images/sa-quote.gif"" alt=""Quote""  title=""""></a></li>


		</ul>
	</td>
</tr>
</table><table class=""post "" id=""post413104038"" data-idx=""27"">
<tr  class=""seen2"" id=""pti27"">
	<td class=""userinfo userid-70611"">
		<dl class=""userinfo"">
			<dt class=""author op"" title="""">bootleg robot</dt>
			<dd class=""registered"">Dec  7, 2004</dd>
			<dd class=""title"">
				<img src=""http://fi.somethingawful.com/customtitles/title-bootleg_robot-2.gif"" alt="""" class=""img"" border=""0""><br />
<br>
				<br class=""pb"">
			</dd>
		</dl>
	</td>
	<td class=""postbody"">
		<!-- BeginContentMarker -->
		<!-- google_ad_section_start -->
		One more time...JSON can't come too soon...
		<!-- google_ad_section_end -->
		<!-- EndContentMarker -->


		<p class=""editedby""><span>bootleg robot fucked around with this message at Mar  4, 2013 around 13:39</span>
	</td>
</tr>
<tr class=""seen2"">
	<td class=""postdate"">
		<a class=""lastseen_icon"" href=""/showthread.php?action=setseen&amp;threadid=3532200&amp;index=27"" title=""Mark all replies as read to this point""><img src=""http://fi.somethingawful.com/style/posticon-seen.gif"" alt="""" border=""0""></a>
		<a href=""#post413104038"" title=""Link to this post"">#</a>
		<a class=""user_jump"" title=""Show posts by this user"" href=""/showthread.php?threadid=3532200&amp;userid=70611"">?</a>
		Mar  4, 2013 13:35
	</td>
	<td class=""postlinks"">
		<ul class=""profilelinks"">
			<li><a href=""member.php?action=getinfo&amp;userid=70611"">Profile</a></li>
			<li><a href=""private.php?action=newmessage&amp;userid=70611"">Message</a></li>
			<li><a href=""search.php?action=do_search_posthistory&amp;userid=70611"">Post History</a></li>
		</ul>
		<ul class=""postbuttons"">

			
			<li class=""alertbutton""><a href=""modalert.php?postid=413104038&amp;username=bootleg+robot""><img src=""http://forumimages.somethingawful.com/images/button-report.gif"" border=""0"" alt=""Alert Moderators""></a>&nbsp;&nbsp;</li>
			
			<li><a href=""editpost.php?action=editpost&amp;postid=413104038""><img src=""http://fi.somethingawful.com/images/sa-edit.gif"" alt=""Edit"" title=""""></a></li>
			<li><a href=""newreply.php?action=newreply&amp;postid=413104038""><img src=""http://fi.somethingawful.com/images/sa-quote.gif"" alt=""Quote""  title=""""></a></li>


		</ul>
	</td>
</tr>
</table><table class=""post "" id=""post413104112"" data-idx=""28"">
<tr  class=""seen1"" id=""pti28"">
	<td class=""userinfo userid-70611"">
		<dl class=""userinfo"">
			<dt class=""author op"" title="""">bootleg robot</dt>
			<dd class=""registered"">Dec  7, 2004</dd>
			<dd class=""title"">
				<img src=""http://fi.somethingawful.com/customtitles/title-bootleg_robot-2.gif"" alt="""" class=""img"" border=""0""><br />
<br>
				<br class=""pb"">
			</dd>
		</dl>
	</td>
	<td class=""postbody"">
		<!-- BeginContentMarker -->
		<!-- google_ad_section_start -->
		Guess I lied.
		<!-- google_ad_section_end -->
		<!-- EndContentMarker -->


		<p class=""editedby""><span>bootleg robot fucked around with this message at Mar  4, 2013 around 13:42</span>
	</td>
</tr>
<tr class=""seen1"">
	<td class=""postdate"">
		<a class=""lastseen_icon"" href=""/showthread.php?action=setseen&amp;threadid=3532200&amp;index=28"" title=""Mark all replies as read to this point""><img src=""http://fi.somethingawful.com/style/posticon-seen.gif"" alt="""" border=""0""></a>
		<a href=""#post413104112"" title=""Link to this post"">#</a>
		<a class=""user_jump"" title=""Show posts by this user"" href=""/showthread.php?threadid=3532200&amp;userid=70611"">?</a>
		Mar  4, 2013 13:38
	</td>
	<td class=""postlinks"">
		<ul class=""profilelinks"">
			<li><a href=""member.php?action=getinfo&amp;userid=70611"">Profile</a></li>
			<li><a href=""private.php?action=newmessage&amp;userid=70611"">Message</a></li>
			<li><a href=""search.php?action=do_search_posthistory&amp;userid=70611"">Post History</a></li>
		</ul>
		<ul class=""postbuttons"">

			
			<li class=""alertbutton""><a href=""modalert.php?postid=413104112&amp;username=bootleg+robot""><img src=""http://forumimages.somethingawful.com/images/button-report.gif"" border=""0"" alt=""Alert Moderators""></a>&nbsp;&nbsp;</li>
			
			<li><a href=""editpost.php?action=editpost&amp;postid=413104112""><img src=""http://fi.somethingawful.com/images/sa-edit.gif"" alt=""Edit"" title=""""></a></li>
			<li><a href=""newreply.php?action=newreply&amp;postid=413104112""><img src=""http://fi.somethingawful.com/images/sa-quote.gif"" alt=""Quote""  title=""""></a></li>


		</ul>
	</td>
</tr>
</table><table class=""post "" id=""post413172932"" data-idx=""29"">
<tr  class=""seen2"" id=""pti29"">
	<td class=""userinfo userid-70611"">
		<dl class=""userinfo"">
			<dt class=""author op"" title="""">bootleg robot</dt>
			<dd class=""registered"">Dec  7, 2004</dd>
			<dd class=""title"">
				<img src=""http://fi.somethingawful.com/customtitles/title-bootleg_robot-2.gif"" alt="""" class=""img"" border=""0""><br />
<br>
				<br class=""pb"">
			</dd>
		</dl>
	</td>
	<td class=""postbody"">
		<!-- BeginContentMarker -->
		<!-- google_ad_section_start -->
		Post test
		<!-- google_ad_section_end -->
		<!-- EndContentMarker -->


		<p class=""editedby"">
	</td>
</tr>
<tr class=""seen2"">
	<td class=""postdate"">
		<a class=""lastseen_icon"" href=""/showthread.php?action=setseen&amp;threadid=3532200&amp;index=29"" title=""Mark all replies as read to this point""><img src=""http://fi.somethingawful.com/style/posticon-seen.gif"" alt="""" border=""0""></a>
		<a href=""#post413172932"" title=""Link to this post"">#</a>
		<a class=""user_jump"" title=""Show posts by this user"" href=""/showthread.php?threadid=3532200&amp;userid=70611"">?</a>
		Mar  6, 2013 12:39
	</td>
	<td class=""postlinks"">
		<ul class=""profilelinks"">
			<li><a href=""member.php?action=getinfo&amp;userid=70611"">Profile</a></li>
			<li><a href=""private.php?action=newmessage&amp;userid=70611"">Message</a></li>
			<li><a href=""search.php?action=do_search_posthistory&amp;userid=70611"">Post History</a></li>
		</ul>
		<ul class=""postbuttons"">

			
			<li class=""alertbutton""><a href=""modalert.php?postid=413172932&amp;username=bootleg+robot""><img src=""http://forumimages.somethingawful.com/images/button-report.gif"" border=""0"" alt=""Alert Moderators""></a>&nbsp;&nbsp;</li>
			
			<li><a href=""editpost.php?action=editpost&amp;postid=413172932""><img src=""http://fi.somethingawful.com/images/sa-edit.gif"" alt=""Edit"" title=""""></a></li>
			<li><a href=""newreply.php?action=newreply&amp;postid=413172932""><img src=""http://fi.somethingawful.com/images/sa-quote.gif"" alt=""Quote""  title=""""></a></li>


		</ul>
	</td>
</tr>
</table><table class=""post "" id=""post413173020"" data-idx=""30"">
<tr  class=""seen1"" id=""pti30"">
	<td class=""userinfo userid-70611"">
		<dl class=""userinfo"">
			<dt class=""author op"" title="""">bootleg robot</dt>
			<dd class=""registered"">Dec  7, 2004</dd>
			<dd class=""title"">
				<img src=""http://fi.somethingawful.com/customtitles/title-bootleg_robot-2.gif"" alt="""" class=""img"" border=""0""><br />
<br>
				<br class=""pb"">
			</dd>
		</dl>
	</td>
	<td class=""postbody"">
		<!-- BeginContentMarker -->
		<!-- google_ad_section_start -->
		Post Test #2
		<!-- google_ad_section_end -->
		<!-- EndContentMarker -->


		<p class=""editedby"">
	</td>
</tr>
<tr class=""seen1"">
	<td class=""postdate"">
		<a class=""lastseen_icon"" href=""/showthread.php?action=setseen&amp;threadid=3532200&amp;index=30"" title=""Mark all replies as read to this point""><img src=""http://fi.somethingawful.com/style/posticon-seen.gif"" alt="""" border=""0""></a>
		<a href=""#post413173020"" title=""Link to this post"">#</a>
		<a class=""user_jump"" title=""Show posts by this user"" href=""/showthread.php?threadid=3532200&amp;userid=70611"">?</a>
		Mar  6, 2013 12:41
	</td>
	<td class=""postlinks"">
		<ul class=""profilelinks"">
			<li><a href=""member.php?action=getinfo&amp;userid=70611"">Profile</a></li>
			<li><a href=""private.php?action=newmessage&amp;userid=70611"">Message</a></li>
			<li><a href=""search.php?action=do_search_posthistory&amp;userid=70611"">Post History</a></li>
		</ul>
		<ul class=""postbuttons"">

			
			<li class=""alertbutton""><a href=""modalert.php?postid=413173020&amp;username=bootleg+robot""><img src=""http://forumimages.somethingawful.com/images/button-report.gif"" border=""0"" alt=""Alert Moderators""></a>&nbsp;&nbsp;</li>
			
			<li><a href=""editpost.php?action=editpost&amp;postid=413173020""><img src=""http://fi.somethingawful.com/images/sa-edit.gif"" alt=""Edit"" title=""""></a></li>
			<li><a href=""newreply.php?action=newreply&amp;postid=413173020""><img src=""http://fi.somethingawful.com/images/sa-quote.gif"" alt=""Quote""  title=""""></a></li>


		</ul>
	</td>
</tr>
</table><table class=""post "" id=""post413173587"" data-idx=""31"">
<tr  class=""seen2"" id=""pti31"">
	<td class=""userinfo userid-70611"">
		<dl class=""userinfo"">
			<dt class=""author op"" title="""">bootleg robot</dt>
			<dd class=""registered"">Dec  7, 2004</dd>
			<dd class=""title"">
				<img src=""http://fi.somethingawful.com/customtitles/title-bootleg_robot-2.gif"" alt="""" class=""img"" border=""0""><br />
<br>
				<br class=""pb"">
			</dd>
		</dl>
	</td>
	<td class=""postbody"">
		<!-- BeginContentMarker -->
		<!-- google_ad_section_start -->
		Post #3
		<!-- google_ad_section_end -->
		<!-- EndContentMarker -->


		<p class=""editedby"">
	</td>
</tr>
<tr class=""seen2"">
	<td class=""postdate"">
		<a class=""lastseen_icon"" href=""/showthread.php?action=setseen&amp;threadid=3532200&amp;index=31"" title=""Mark all replies as read to this point""><img src=""http://fi.somethingawful.com/style/posticon-seen.gif"" alt="""" border=""0""></a>
		<a href=""#post413173587"" title=""Link to this post"">#</a>
		<a class=""user_jump"" title=""Show posts by this user"" href=""/showthread.php?threadid=3532200&amp;userid=70611"">?</a>
		Mar  6, 2013 13:00
	</td>
	<td class=""postlinks"">
		<ul class=""profilelinks"">
			<li><a href=""member.php?action=getinfo&amp;userid=70611"">Profile</a></li>
			<li><a href=""private.php?action=newmessage&amp;userid=70611"">Message</a></li>
			<li><a href=""search.php?action=do_search_posthistory&amp;userid=70611"">Post History</a></li>
		</ul>
		<ul class=""postbuttons"">

			
			<li class=""alertbutton""><a href=""modalert.php?postid=413173587&amp;username=bootleg+robot""><img src=""http://forumimages.somethingawful.com/images/button-report.gif"" border=""0"" alt=""Alert Moderators""></a>&nbsp;&nbsp;</li>
			
			<li><a href=""editpost.php?action=editpost&amp;postid=413173587""><img src=""http://fi.somethingawful.com/images/sa-edit.gif"" alt=""Edit"" title=""""></a></li>
			<li><a href=""newreply.php?action=newreply&amp;postid=413173587""><img src=""http://fi.somethingawful.com/images/sa-quote.gif"" alt=""Quote""  title=""""></a></li>


		</ul>
	</td>
</tr>
</table><table class=""post "" id=""post413173612"" data-idx=""32"">
<tr  class=""seen1"" id=""pti32"">
	<td class=""userinfo userid-70611"">
		<dl class=""userinfo"">
			<dt class=""author op"" title="""">bootleg robot</dt>
			<dd class=""registered"">Dec  7, 2004</dd>
			<dd class=""title"">
				<img src=""http://fi.somethingawful.com/customtitles/title-bootleg_robot-2.gif"" alt="""" class=""img"" border=""0""><br />
<br>
				<br class=""pb"">
			</dd>
		</dl>
	</td>
	<td class=""postbody"">
		<!-- BeginContentMarker -->
		<!-- google_ad_section_start -->
		Post#4
		<!-- google_ad_section_end -->
		<!-- EndContentMarker -->


		<p class=""editedby"">
	</td>
</tr>
<tr class=""seen1"">
	<td class=""postdate"">
		<a class=""lastseen_icon"" href=""/showthread.php?action=setseen&amp;threadid=3532200&amp;index=32"" title=""Mark all replies as read to this point""><img src=""http://fi.somethingawful.com/style/posticon-seen.gif"" alt="""" border=""0""></a>
		<a href=""#post413173612"" title=""Link to this post"">#</a>
		<a class=""user_jump"" title=""Show posts by this user"" href=""/showthread.php?threadid=3532200&amp;userid=70611"">?</a>
		Mar  6, 2013 13:01
	</td>
	<td class=""postlinks"">
		<ul class=""profilelinks"">
			<li><a href=""member.php?action=getinfo&amp;userid=70611"">Profile</a></li>
			<li><a href=""private.php?action=newmessage&amp;userid=70611"">Message</a></li>
			<li><a href=""search.php?action=do_search_posthistory&amp;userid=70611"">Post History</a></li>
		</ul>
		<ul class=""postbuttons"">

			
			<li class=""alertbutton""><a href=""modalert.php?postid=413173612&amp;username=bootleg+robot""><img src=""http://forumimages.somethingawful.com/images/button-report.gif"" border=""0"" alt=""Alert Moderators""></a>&nbsp;&nbsp;</li>
			
			<li><a href=""editpost.php?action=editpost&amp;postid=413173612""><img src=""http://fi.somethingawful.com/images/sa-edit.gif"" alt=""Edit"" title=""""></a></li>
			<li><a href=""newreply.php?action=newreply&amp;postid=413173612""><img src=""http://fi.somethingawful.com/images/sa-quote.gif"" alt=""Quote""  title=""""></a></li>


		</ul>
	</td>
</tr>
</table><table class=""post "" id=""post413173861"" data-idx=""33"">
<tr  class=""seen2"" id=""pti33"">
	<td class=""userinfo userid-70611"">
		<dl class=""userinfo"">
			<dt class=""author op"" title="""">bootleg robot</dt>
			<dd class=""registered"">Dec  7, 2004</dd>
			<dd class=""title"">
				<img src=""http://fi.somethingawful.com/customtitles/title-bootleg_robot-2.gif"" alt="""" class=""img"" border=""0""><br />
<br>
				<br class=""pb"">
			</dd>
		</dl>
	</td>
	<td class=""postbody"">
		<!-- BeginContentMarker -->
		<!-- google_ad_section_start -->
		post test test edit.
		<!-- google_ad_section_end -->
		<!-- EndContentMarker -->


		<p class=""editedby"">
	</td>
</tr>
<tr class=""seen2"">
	<td class=""postdate"">
		<a class=""lastseen_icon"" href=""/showthread.php?action=setseen&amp;threadid=3532200&amp;index=33"" title=""Mark all replies as read to this point""><img src=""http://fi.somethingawful.com/style/posticon-seen.gif"" alt="""" border=""0""></a>
		<a href=""#post413173861"" title=""Link to this post"">#</a>
		<a class=""user_jump"" title=""Show posts by this user"" href=""/showthread.php?threadid=3532200&amp;userid=70611"">?</a>
		Mar  6, 2013 13:09
	</td>
	<td class=""postlinks"">
		<ul class=""profilelinks"">
			<li><a href=""member.php?action=getinfo&amp;userid=70611"">Profile</a></li>
			<li><a href=""private.php?action=newmessage&amp;userid=70611"">Message</a></li>
			<li><a href=""search.php?action=do_search_posthistory&amp;userid=70611"">Post History</a></li>
		</ul>
		<ul class=""postbuttons"">

			
			<li class=""alertbutton""><a href=""modalert.php?postid=413173861&amp;username=bootleg+robot""><img src=""http://forumimages.somethingawful.com/images/button-report.gif"" border=""0"" alt=""Alert Moderators""></a>&nbsp;&nbsp;</li>
			
			<li><a href=""editpost.php?action=editpost&amp;postid=413173861""><img src=""http://fi.somethingawful.com/images/sa-edit.gif"" alt=""Edit"" title=""""></a></li>
			<li><a href=""newreply.php?action=newreply&amp;postid=413173861""><img src=""http://fi.somethingawful.com/images/sa-quote.gif"" alt=""Quote""  title=""""></a></li>


		</ul>
	</td>
</tr>
</table><table class=""post "" id=""post413178949"" data-idx=""34"">
<tr  class=""seen1"" id=""pti34"">
	<td class=""userinfo userid-70611"">
		<dl class=""userinfo"">
			<dt class=""author op"" title="""">bootleg robot</dt>
			<dd class=""registered"">Dec  7, 2004</dd>
			<dd class=""title"">
				<img src=""http://fi.somethingawful.com/customtitles/title-bootleg_robot-2.gif"" alt="""" class=""img"" border=""0""><br />
<br>
				<br class=""pb"">
			</dd>
		</dl>
	</td>
	<td class=""postbody"">
		<!-- BeginContentMarker -->
		<!-- google_ad_section_start -->
		Posting with emojis because I'm curious. ðŸš•ðŸš—ðŸš‰ðŸšŒðŸš‘ðŸš„ðŸš…<br />
ðŸ˜ðŸ˜ŽðŸ˜’ðŸ˜ˆ
		<!-- google_ad_section_end -->
		<!-- EndContentMarker -->


		<p class=""editedby"">
	</td>
</tr>
<tr class=""seen1"">
	<td class=""postdate"">
		<a class=""lastseen_icon"" href=""/showthread.php?action=setseen&amp;threadid=3532200&amp;index=34"" title=""Mark all replies as read to this point""><img src=""http://fi.somethingawful.com/style/posticon-seen.gif"" alt="""" border=""0""></a>
		<a href=""#post413178949"" title=""Link to this post"">#</a>
		<a class=""user_jump"" title=""Show posts by this user"" href=""/showthread.php?threadid=3532200&amp;userid=70611"">?</a>
		Mar  6, 2013 15:45
	</td>
	<td class=""postlinks"">
		<ul class=""profilelinks"">
			<li><a href=""member.php?action=getinfo&amp;userid=70611"">Profile</a></li>
			<li><a href=""private.php?action=newmessage&amp;userid=70611"">Message</a></li>
			<li><a href=""search.php?action=do_search_posthistory&amp;userid=70611"">Post History</a></li>
		</ul>
		<ul class=""postbuttons"">

			
			<li class=""alertbutton""><a href=""modalert.php?postid=413178949&amp;username=bootleg+robot""><img src=""http://forumimages.somethingawful.com/images/button-report.gif"" border=""0"" alt=""Alert Moderators""></a>&nbsp;&nbsp;</li>
			
			<li><a href=""editpost.php?action=editpost&amp;postid=413178949""><img src=""http://fi.somethingawful.com/images/sa-edit.gif"" alt=""Edit"" title=""""></a></li>
			<li><a href=""newreply.php?action=newreply&amp;postid=413178949""><img src=""http://fi.somethingawful.com/images/sa-quote.gif"" alt=""Quote""  title=""""></a></li>


		</ul>
	</td>
</tr>
</table><table class=""post "" id=""post413220917"" data-idx=""35"">
<tr  class=""seen2"" id=""pti35"">
	<td class=""userinfo userid-70611"">
		<dl class=""userinfo"">
			<dt class=""author op"" title="""">bootleg robot</dt>
			<dd class=""registered"">Dec  7, 2004</dd>
			<dd class=""title"">
				<img src=""http://fi.somethingawful.com/customtitles/title-bootleg_robot-2.gif"" alt="""" class=""img"" border=""0""><br />
<br>
				<br class=""pb"">
			</dd>
		</dl>
	</td>
	<td class=""postbody"">
		<!-- BeginContentMarker -->
		<!-- google_ad_section_start -->
		Post!
		<!-- google_ad_section_end -->
		<!-- EndContentMarker -->


		<p class=""editedby"">
	</td>
</tr>
<tr class=""seen2"">
	<td class=""postdate"">
		<a class=""lastseen_icon"" href=""/showthread.php?action=setseen&amp;threadid=3532200&amp;index=35"" title=""Mark all replies as read to this point""><img src=""http://fi.somethingawful.com/style/posticon-seen.gif"" alt="""" border=""0""></a>
		<a href=""#post413220917"" title=""Link to this post"">#</a>
		<a class=""user_jump"" title=""Show posts by this user"" href=""/showthread.php?threadid=3532200&amp;userid=70611"">?</a>
		Mar  7, 2013 19:21
	</td>
	<td class=""postlinks"">
		<ul class=""profilelinks"">
			<li><a href=""member.php?action=getinfo&amp;userid=70611"">Profile</a></li>
			<li><a href=""private.php?action=newmessage&amp;userid=70611"">Message</a></li>
			<li><a href=""search.php?action=do_search_posthistory&amp;userid=70611"">Post History</a></li>
		</ul>
		<ul class=""postbuttons"">

			
			<li class=""alertbutton""><a href=""modalert.php?postid=413220917&amp;username=bootleg+robot""><img src=""http://forumimages.somethingawful.com/images/button-report.gif"" border=""0"" alt=""Alert Moderators""></a>&nbsp;&nbsp;</li>
			
			<li><a href=""editpost.php?action=editpost&amp;postid=413220917""><img src=""http://fi.somethingawful.com/images/sa-edit.gif"" alt=""Edit"" title=""""></a></li>
			<li><a href=""newreply.php?action=newreply&amp;postid=413220917""><img src=""http://fi.somethingawful.com/images/sa-quote.gif"" alt=""Quote""  title=""""></a></li>


		</ul>
	</td>
</tr>
</table><table class=""post "" id=""post413240808"" data-idx=""36"">
<tr  class=""seen1"" id=""pti36"">
	<td class=""userinfo userid-70611"">
		<dl class=""userinfo"">
			<dt class=""author op"" title="""">bootleg robot</dt>
			<dd class=""registered"">Dec  7, 2004</dd>
			<dd class=""title"">
				<img src=""http://fi.somethingawful.com/customtitles/title-bootleg_robot-2.gif"" alt="""" class=""img"" border=""0""><br />
<br>
				<br class=""pb"">
			</dd>
		</dl>
	</td>
	<td class=""postbody"">
		<!-- BeginContentMarker -->
		<!-- google_ad_section_start -->
		Posty!!
		<!-- google_ad_section_end -->
		<!-- EndContentMarker -->


		<p class=""editedby""><span>bootleg robot fucked around with this message at Mar  8, 2013 around 11:57</span>
	</td>
</tr>
<tr class=""seen1"">
	<td class=""postdate"">
		<a class=""lastseen_icon"" href=""/showthread.php?action=setseen&amp;threadid=3532200&amp;index=36"" title=""Mark all replies as read to this point""><img src=""http://fi.somethingawful.com/style/posticon-seen.gif"" alt="""" border=""0""></a>
		<a href=""#post413240808"" title=""Link to this post"">#</a>
		<a class=""user_jump"" title=""Show posts by this user"" href=""/showthread.php?threadid=3532200&amp;userid=70611"">?</a>
		Mar  8, 2013 11:53
	</td>
	<td class=""postlinks"">
		<ul class=""profilelinks"">
			<li><a href=""member.php?action=getinfo&amp;userid=70611"">Profile</a></li>
			<li><a href=""private.php?action=newmessage&amp;userid=70611"">Message</a></li>
			<li><a href=""search.php?action=do_search_posthistory&amp;userid=70611"">Post History</a></li>
		</ul>
		<ul class=""postbuttons"">

			
			<li class=""alertbutton""><a href=""modalert.php?postid=413240808&amp;username=bootleg+robot""><img src=""http://forumimages.somethingawful.com/images/button-report.gif"" border=""0"" alt=""Alert Moderators""></a>&nbsp;&nbsp;</li>
			
			<li><a href=""editpost.php?action=editpost&amp;postid=413240808""><img src=""http://fi.somethingawful.com/images/sa-edit.gif"" alt=""Edit"" title=""""></a></li>
			<li><a href=""newreply.php?action=newreply&amp;postid=413240808""><img src=""http://fi.somethingawful.com/images/sa-quote.gif"" alt=""Quote""  title=""""></a></li>


		</ul>
	</td>
</tr>
</table><table class=""post "" id=""post413262201"" data-idx=""37"">
<tr  class=""seen2"" id=""pti37"">
	<td class=""userinfo userid-106125"">
		<dl class=""userinfo"">
			<dt class=""author"" title="""">pokeyman</dt>
			<dd class=""registered"">Nov 26, 2006</dd>
			<dd class=""title"">
				<img src=""http://fi.somethingawful.com/customtitles/title-pokeyman.jpg""><br>What do you like to play?<br>
				<br class=""pb"">
			</dd>
		</dl>
	</td>
	<td class=""postbody"">
		<!-- BeginContentMarker -->
		<!-- google_ad_section_start -->
		&amp;&amp;
		<!-- google_ad_section_end -->
		<!-- EndContentMarker -->


		<p class=""editedby"">
	</td>
</tr>
<tr class=""seen2"">
	<td class=""postdate"">
		<a class=""lastseen_icon"" href=""/showthread.php?action=setseen&amp;threadid=3532200&amp;index=37"" title=""Mark all replies as read to this point""><img src=""http://fi.somethingawful.com/style/posticon-seen.gif"" alt="""" border=""0""></a>
		<a href=""#post413262201"" title=""Link to this post"">#</a>
		<a class=""user_jump"" title=""Show posts by this user"" href=""/showthread.php?threadid=3532200&amp;userid=106125"">?</a>
		Mar  9, 2013 01:49
	</td>
	<td class=""postlinks"">
		<ul class=""profilelinks"">
			<li><a href=""member.php?action=getinfo&amp;userid=106125"">Profile</a></li>
			<li><a href=""private.php?action=newmessage&amp;userid=106125"">Message</a></li>
			<li><a href=""search.php?action=do_search_posthistory&amp;userid=106125"">Post History</a></li>
		</ul>
		<ul class=""postbuttons"">

			
			<li class=""alertbutton""><a href=""modalert.php?postid=413262201&amp;username=pokeyman""><img src=""http://forumimages.somethingawful.com/images/button-report.gif"" border=""0"" alt=""Alert Moderators""></a>&nbsp;&nbsp;</li>
			
			<li><a href=""newreply.php?action=newreply&amp;postid=413262201""><img src=""http://fi.somethingawful.com/images/sa-quote.gif"" alt=""Quote""  title=""""></a></li>


		</ul>
	</td>
</tr>
</table><table class=""post "" id=""post413362346"" data-idx=""38"">
<tr  class=""seen1"" id=""pti38"">
	<td class=""userinfo userid-106125"">
		<dl class=""userinfo"">
			<dt class=""author"" title="""">pokeyman</dt>
			<dd class=""registered"">Nov 26, 2006</dd>
			<dd class=""title"">
				<img src=""http://fi.somethingawful.com/customtitles/title-pokeyman.jpg""><br>What do you like to play?<br>
				<br class=""pb"">
			</dd>
		</dl>
	</td>
	<td class=""postbody"">
		<!-- BeginContentMarker -->
		<!-- google_ad_section_start -->
		<span class=""bbc-spoiler""><br />
<ul class=""bbc-list"">
<li>Spoiled list with an<br />
<li><img src=""http://fi.somethingawful.com/sideimages/l88/19.jpg"" alt="""" class=""timg"" border=""0""> image<br />
<li>and a <a href=""http://example.com"" target=""_blank"" rel=""nofollow"">pointless link</a>.<br />
</ul>
</span>
		<!-- google_ad_section_end -->
		<!-- EndContentMarker -->


		<p class=""editedby""><span>pokeyman fucked around with this message at Mar 13, 2013 around 15:33</span>
	</td>
</tr>
<tr class=""seen1"">
	<td class=""postdate"">
		<a class=""lastseen_icon"" href=""/showthread.php?action=setseen&amp;threadid=3532200&amp;index=38"" title=""Mark all replies as read to this point""><img src=""http://fi.somethingawful.com/style/posticon-seen.gif"" alt="""" border=""0""></a>
		<a href=""#post413362346"" title=""Link to this post"">#</a>
		<a class=""user_jump"" title=""Show posts by this user"" href=""/showthread.php?threadid=3532200&amp;userid=106125"">?</a>
		Mar 12, 2013 14:15
	</td>
	<td class=""postlinks"">
		<ul class=""profilelinks"">
			<li><a href=""member.php?action=getinfo&amp;userid=106125"">Profile</a></li>
			<li><a href=""private.php?action=newmessage&amp;userid=106125"">Message</a></li>
			<li><a href=""search.php?action=do_search_posthistory&amp;userid=106125"">Post History</a></li>
		</ul>
		<ul class=""postbuttons"">

			
			<li class=""alertbutton""><a href=""modalert.php?postid=413362346&amp;username=pokeyman""><img src=""http://forumimages.somethingawful.com/images/button-report.gif"" border=""0"" alt=""Alert Moderators""></a>&nbsp;&nbsp;</li>
			
			<li><a href=""newreply.php?action=newreply&amp;postid=413362346""><img src=""http://fi.somethingawful.com/images/sa-quote.gif"" alt=""Quote""  title=""""></a></li>


		</ul>
	</td>
</tr>
</table><table class=""post "" id=""post413368478"" data-idx=""39"">
<tr  class=""seen2"" id=""pti39"">
	<td class=""userinfo userid-70611"">
		<dl class=""userinfo"">
			<dt class=""author op"" title="""">bootleg robot</dt>
			<dd class=""registered"">Dec  7, 2004</dd>
			<dd class=""title"">
				<img src=""http://fi.somethingawful.com/customtitles/title-bootleg_robot-2.gif"" alt="""" class=""img"" border=""0""><br />
<br>
				<br class=""pb"">
			</dd>
		</dl>
	</td>
	<td class=""postbody"">
		<!-- BeginContentMarker -->
		<!-- google_ad_section_start -->
		<div class=""bbc-block""><h4><a class=""quote_link"" href=""/showthread.php?goto=post&postid=413362346#post413362346"" rel=""nofollow"">pokeyman posted:</a></h4><blockquote>
<span class=""bbc-spoiler""><br />
<ul class=""bbc-list"">
<li>Spoiled list with an<br />
<li><img src=""http://fi.somethingawful.com/sideimages/l88/19.jpg"" alt="""" class=""timg"" border=""0""> image<br />
</ul>
</span><br />
</blockquote></div>

<br />
The image combined with the spoiler made me laugh out loud.
		<!-- google_ad_section_end -->
		<!-- EndContentMarker -->


		<p class=""editedby"">
	</td>
</tr>
<tr class=""seen2"">
	<td class=""postdate"">
		<a class=""lastseen_icon"" href=""/showthread.php?action=setseen&amp;threadid=3532200&amp;index=39"" title=""Mark all replies as read to this point""><img src=""http://fi.somethingawful.com/style/posticon-seen.gif"" alt="""" border=""0""></a>
		<a href=""#post413368478"" title=""Link to this post"">#</a>
		<a class=""user_jump"" title=""Show posts by this user"" href=""/showthread.php?threadid=3532200&amp;userid=70611"">?</a>
		Mar 12, 2013 17:00
	</td>
	<td class=""postlinks"">
		<ul class=""profilelinks"">
			<li><a href=""member.php?action=getinfo&amp;userid=70611"">Profile</a></li>
			<li><a href=""private.php?action=newmessage&amp;userid=70611"">Message</a></li>
			<li><a href=""search.php?action=do_search_posthistory&amp;userid=70611"">Post History</a></li>
		</ul>
		<ul class=""postbuttons"">

			
			<li class=""alertbutton""><a href=""modalert.php?postid=413368478&amp;username=bootleg+robot""><img src=""http://forumimages.somethingawful.com/images/button-report.gif"" border=""0"" alt=""Alert Moderators""></a>&nbsp;&nbsp;</li>
			
			<li><a href=""editpost.php?action=editpost&amp;postid=413368478""><img src=""http://fi.somethingawful.com/images/sa-edit.gif"" alt=""Edit"" title=""""></a></li>
			<li><a href=""newreply.php?action=newreply&amp;postid=413368478""><img src=""http://fi.somethingawful.com/images/sa-quote.gif"" alt=""Quote""  title=""""></a></li>


		</ul>
	</td>
</tr>
</table><table class=""post "" id=""post413368993"" data-idx=""40"">
<tr  class=""seen1"" id=""pti40"">
	<td class=""userinfo userid-106125"" id=""lastpost"">
		<dl class=""userinfo"">
			<dt class=""author"" title="""">pokeyman</dt>
			<dd class=""registered"">Nov 26, 2006</dd>
			<dd class=""title"">
				<img src=""http://fi.somethingawful.com/customtitles/title-pokeyman.jpg""><br>What do you like to play?<br>
				<br class=""pb"">
			</dd>
		</dl>
	</td>
	<td class=""postbody"">
		<!-- BeginContentMarker -->
		<!-- google_ad_section_start -->
		You posted it... <img src=""http://fi.somethingawful.com/images/smilies/smile.gif"" border=""0"" alt="""" title="":)""><br />
<br />
edit: I only just realized you said ""with the spoiler"". Now I get it.
		<!-- google_ad_section_end -->
		<!-- EndContentMarker -->


		<p class=""editedby""><span>pokeyman fucked around with this message at Mar 13, 2013 around 15:33</span>
	</td>
</tr>
<tr class=""seen1"">
	<td class=""postdate"">
		<a class=""lastseen_icon"" href=""/showthread.php?action=setseen&amp;threadid=3532200&amp;index=40"" title=""Mark all replies as read to this point""><img src=""http://fi.somethingawful.com/style/posticon-seen.gif"" alt="""" border=""0""></a>
		<a href=""#post413368993"" title=""Link to this post"">#</a>
		<a class=""user_jump"" title=""Show posts by this user"" href=""/showthread.php?threadid=3532200&amp;userid=106125"">?</a>
		Mar 12, 2013 17:16
	</td>
	<td class=""postlinks"">
		<ul class=""profilelinks"">
			<li><a href=""member.php?action=getinfo&amp;userid=106125"">Profile</a></li>
			<li><a href=""private.php?action=newmessage&amp;userid=106125"">Message</a></li>
			<li><a href=""search.php?action=do_search_posthistory&amp;userid=106125"">Post History</a></li>
		</ul>
		<ul class=""postbuttons"">

			
			<li class=""alertbutton""><a href=""modalert.php?postid=413368993&amp;username=pokeyman""><img src=""http://forumimages.somethingawful.com/images/button-report.gif"" border=""0"" alt=""Alert Moderators""></a>&nbsp;&nbsp;</li>
			
			<li><a href=""newreply.php?action=newreply&amp;postid=413368993""><img src=""http://fi.somethingawful.com/images/sa-quote.gif"" alt=""Quote""  title=""""></a></li>


		</ul>
	</td>
</tr>
</table>
</div>
<div class=""threadbar bottom"">

	<img src=""http://fi.somethingawful.com/images/buttons/button-unbookmark.png"" alt="""" class=""thread_bookmark unbookmark"">
	<div lang=""X851MRWVLwphuSioKXldwH9N."" class=""threadrate"">
		<ul class=""rating_buttons""><li>1</li><li>2</li><li>3</li><li>4</li><li>5</li></ul>

<!-- 		<form name=""rateform"" method=""POST"" action=""threadrate.php"" id=""rateform"">
			<select name=""vote"">
				<option>1</option>
				<option>2</option>
				<option>3</option>
				<option>4</option>
				<option>5</option>
			</select>
			<input type=""hidden"" name=""threadid"" value=""3532200"">
			<input type=""hidden"" name=""digg_url"" value=""http://digg.com/submit?phase=2&amp;url=http%3A%2F%2Fforums.somethingawful.com%2Fshowthread.php%3Fthreadid%3D3532200&amp;title=%5BTEST%5D+The+Post+Test+Thread"">
			<input type=""hidden"" name=""digg_title"" value=""%5BTEST%5D+The+Post+Test+Thread"">
			<input type=""submit"" value=""Vote!"">
		</form>
 -->
	</div>

	<ul class=""postbuttons"">

		<li><a href=""newthread.php?action=newthread&amp;forumid=261""><img src=""http://fi.somethingawful.com/images/forum-post.gif"" alt=""Post"" title=""""></a></li>
<li><a href=""newreply.php?action=newreply&amp;threadid=3532200""><img src=""http://fi.somethingawful.com/images/forum-reply.gif"" alt=""Reply"" title=""""></a></li>


	</ul>
	<div class=""clear""></div>
</div>

<div class=""pages bottom""><span class=""disabled"">&laquo;</span><span class=""disabled"">&lsaquo;</span><select data-url=""showthread.php?threadid=3532200&amp;userid=0&amp;perpage=40""><option value=""1"" selected=""selected"">1</option><option value=""2"">2</option><option value=""3"">3</option><option value=""4"">4</option><option value=""5"">5</option><option value=""6"">6</option></select><a href=""showthread.php?threadid=3532200&amp;userid=0&amp;perpage=40&pagenumber=2"" title=""Next page"">&rsaquo;</a><a href=""showthread.php?threadid=3532200&amp;userid=0&amp;perpage=40&pagenumber=6"" title=""Last page"">6 &raquo;</a></div>
<div class=""breadcrumbs""><span class=""mainbodytextlarge""><b><a href=""/"">The Something Awful Forums</a> &gt; <a href=""forumdisplay.php?forumid=153"">The Community</a> &gt; <a href=""forumdisplay.php?forumid=261"">Apps In Developmental States</a> &gt; <a href=""showthread.php?threadid=3532200"" class=""bclast"">[TEST] The Post Test Thread</a></b></span></div>

<div class=""bottom_forms"">
	
<form class=""forum_jump"" action=""forumdisplay.php"" method=""get"">
<input type=""hidden"" name=""s"" value="""">
<input type=""hidden"" name=""daysprune"" value="""">
<select name=""forumid"">
<option value=""-1"" selected>Jump to another forum:</option>
<option value=""-1"">--------------------</option>
<option value=""pm"" >Private Messages</option>
<option value=""cp"" >User Control Panel</option>
<option value=""search"" >Search Forums</option>
<option value=""home"" >Forums Home</option>
<option value=""lc"" >Leper's Colony</option>
<option value=""-1"">--------------------</option>
<option value=""48"" > Main</option><option value=""1"" >-- GBS 1.4</option><option value=""155"" >---- SA's Front Page Discussion</option><option value=""214"" >---- E/N Bullshit</option><option value=""26"" >-- FYAD: http://vimeo.com/86014703</option><option value=""154"" >---- A Beecock Forum.</option><option value=""268"" >-- BYOB 8.2</option><option value=""51"" > Discussion</option><option value=""44"" >-- Games</option><option value=""259"" >---- A Blizzard Subforum</option><option value=""146"" >------ WoW: Goon Squad</option><option value=""145"" >---- The MMO HMO</option><option value=""93"" >---- Private Game Servers</option><option value=""234"" >---- Dice &amp; Drama</option><option value=""103"" >------ The Goblin Ranch</option><option value=""191"" >---- Let's Play!</option><option value=""267"" >---- Dungeons &amp; Dreamcast Recreation Dome</option><option value=""192"" >-- Inspect Your Gadgets</option><option value=""158"" >-- Ask / Tell</option><option value=""162"" >---- Science, Academics and Languages</option><option value=""211"" >---- Tourism &amp; Travel</option><option value=""200"" >---- Business, Finance, and Careers</option><option value=""46"" >-- Debate Disco</option><option value=""22"" >-- Serious Hardware / Software Crap</option><option value=""170"" >---- Haus of Tech Support</option><option value=""202"" >---- The Cavern of COBOL</option><option value=""265"" >------ project.log</option><option value=""219"" >---- YOSPOS</option><option value=""122"" >-- Sports Argument Stadium* </option><option value=""181"" >---- The Football Funhouse</option><option value=""248"" >---- The Armchair Quarterback</option><option value=""175"" >---- The Ray Parlour</option><option value=""177"" >---- Punchsport Pagoda</option><option value=""179"" >-- You Look Like Shit</option><option value=""183"" >---- The Goon Doctor</option><option value=""244"" >---- The Fitness Log Cabin</option><option value=""242"" >-- Paranormal/Conspiracy Forum</option><option value=""161"" >-- Goons With Spoons</option><option value=""167"" >-- Post Your Favorite (or Request)</option><option value=""91"" >-- Automotive Insanity</option><option value=""236"" >---- Cycle Asylum</option><option value=""124"" >-- Pet Island</option><option value=""132"" >-- The Firing Range</option><option value=""90"" >-- The Crackhead Clubhouse</option><option value=""218"" >-- Goons in Platoons</option><option value=""152"" > The Finer Arts</option><option value=""31"" >-- Creative Convention</option><option value=""210"" >---- DIY &amp; Hobbies</option><option value=""247"" >---- The Dorkroom</option><option value=""151"" >-- Cinema Discusso</option><option value=""133"" >---- The Film Dump</option><option value=""182"" >-- The Book Barn</option><option value=""150"" >-- No Music Discussion</option><option value=""104"" >---- Musician's Lounge</option><option value=""130"" >-- The TV IV</option><option value=""144"" >-- Batman's Shameful Secret</option><option value=""27"" >-- ADTRW</option><option value=""215"" >-- Entertainment, Weakly</option><option value=""255"" >-- Rapidly Going Deaf</option><option value=""153"" > The Community</option><option value=""61"" >-- SA-Mart</option><option value=""77"" >---- Feedback &amp; Discussion</option><option value=""85"" >---- Coupons &amp; Deals</option><option value=""43"" >-- Goon Meets</option><option value=""241"" >-- LAN: Your City Sucks - Regional Discussion</option><option value=""188"" >-- Questions, Comments, Suggestions? - Read the stickies first!</option><option value=""49"" > Archives</option><option value=""21"" >-- Comedy Goldmine</option><option value=""264"" >---- Comedy Purgatory</option><option value=""115"" >---- FYAD: Criterion Collection</option><option value=""204"" >---- Helldump Success Stories</option><option value=""222"" >---- LF Goldmine</option><option value=""229"" >---- YCS Goldmine</option><option value=""25"" >-- Comedy Gas Chamber</option>
</select>
<input type=""submit"" value=""Go"">
</form>
</div>

<div class=""subscribe"" id=""bookmark_link""><a>Bookmark this thread</a></div>




<center>

	<div id=""ad_banner_user"">
		<a href=""http://tinyurl.com/macoe46"" target=""_blank""><img src=""http://fi.somethingawful.com/safs/goonbas/b/3/9132.0001.jpg"" alt="""" width=""468"" height=""60""></a><br>
		<a href=""https://secure.somethingawful.com/products/ad-banner.php"" target=""_blank"" title=""Affordable rates, high exposure!"">Advertise here!</a> | <a href=""/adlist.php"" class=""all_ads"">Browse all ads</a>
	</div>
</center>


</div><!-- #content -->
	<ul class=""navigation"">
<li class=""first""><a href=""/index.php"">SA Forums</a></li>
<li>- <a href=""http://www.somethingawful.com/"">Something Awful</a></li>
<li>- <a href=""/f/search"">Search the Forums</a></li>
<li>- <a href=""/usercp.php"">User Control Panel</a></li>
<li>- <a href=""/private.php"">Private Messages</a></li>
<li>- <a href=""http://www.somethingawful.com/d/forum-rules/forum-rules.php"">Forum Rules</a></li>
<li>- <a href=""/dictionary.php"">SAclopedia</a></li>
<li>- <a href=""/stats.php"">Posting Gloryhole</a></li>
<li>- <a href=""/banlist.php"">Leper's Colony</a></li>
<li>- <a href=""/supportmail.php"">Support</a></li>
<li>- <a href=""/account.php?action=logout&amp;ma=10293618"">Log Out</a></li>

</ul>
	<div id=""copyright"">
		Powered by: vBulletin Version 2.2.9 (<a href=""/CHANGES"">SAVB-v2.1.17</a>)<br>
		Copyright &copy;2000, 2001, Jelsoft Enterprises Limited.<br>
		Copyright &copy;2012, Something Awful LLC<br>
	</div>

</div><!-- #container -->

<script type=""text/javascript"">
	// quantcast
	_qoptions = { qacct:""p-82vTvmw-enlng"" };

	try {
		if(document.location.hostname != 'forums.somethingawful.com')
			throw undefined;

		$(document).ready(function() {
			var qcUrl = 'http://edge.quantserve.com/quant.js';
			jQuery.getScript(qcUrl);

			var gaJsHost = ((""https:"" == document.location.protocol) ? ""https://ssl."" : ""http://www."");
			var gaUrl = gaJsHost + 'google-analytics.com/ga.js';
			jQuery.getScript(gaUrl, function() {
				var pageTracker = _gat._getTracker(""UA-3064978-2"");
				pageTracker._initData();
				pageTracker._trackPageview();
			});
		});
	} catch(e) {};

	// indie
	// try {
	// 	if(document.location.hostname != 'forums.somethingawful.com')
	// 		throw undefined;

	// 	$(document).ready(function() {
	// 		var ic_element = document.createElement('script');
	// 		ic_element.type = 'text/javascript';
	// 		ic_element.async = true;
	// 		ic_element.id = 'ic_annonymous_pixel';
	// 		ic_element.src = 'http://pixel.indieclick.com/annonymous/domain/somethingawful.com/reach/script_ic.js';
	// 		var ic_script = document.getElementsByTagName('script')[0];
	// 		ic_script.parentNode.insertBefore(ic_element, ic_script);
	// 	});
	// } catch(e) {};
</script>
<noscript><img src=""http://pixel.quantserve.com/pixel/p-82vTvmw-enlng.gif"" style=""display:none;"" border=""0"" height=""1"" width=""1"" alt=""Quantcast""></noscript>

<!-- PLEASE DO NOT REMOVE -->
<ol id=""debug"" style=""display:none""><li>&nbsp;</ol>

</body>
</html>";
        }
        public virtual string GenerateMockPrivateMessageHtml()
        {
            return @"<!DOCTYPE html>
<html>
<head>
	<title>The Something Awful Forums - Private Messages - </title>
	
	<meta name=""MSSmartTagsPreventParsing"" content=""TRUE"">
	<meta http-equiv=""X-UA-Compatible"" content=""chrome=1"">
	<!--[if lt IE 7]><link rel=""stylesheet"" type=""text/css"" href=""/css/ie.css?1348360344""><![endif]-->
	<!--[if lt IE 8]><link rel=""stylesheet"" type=""text/css"" href=""/css/ie7.css?1348360344""><![endif]-->
	<link rel=""apple-touch-icon"" href=""http://i.somethingawful.com/core/icon/iphone-touch/forums.png"">
	<link rel=""stylesheet"" type=""text/css"" href=""/css/main.css?1359594161"">
	<link rel=""stylesheet"" type=""text/css"" href=""/css/bbcode.css?1348360344"">
	<link rel=""stylesheet"" type=""text/css"" href=""http://www.somethingawful.com/globalcss/globalmenu.css"">

	

	<!-- <script src=""/__utm.js"" type=""text/javascript""></script> -->
	<!-- script src=""/js/dojo/dojo.js?1348360344"" type=""text/javascript""></script -->
	<script type=""text/javascript"" src=""//ajax.googleapis.com/ajax/libs/jquery/1.8.3/jquery.min.js""></script>
	<link rel=""stylesheet"" type=""text/css"" href=""//ajax.googleapis.com/ajax/libs/jqueryui/1.9.2/themes/redmond/jquery-ui.css"">
	<script type=""text/javascript"" src=""//ajax.googleapis.com/ajax/libs/jqueryui/1.9.2/jquery-ui.min.js""></script>

	<link rel=""stylesheet"" type=""text/css"" href=""http://www.somethingawful.com/css/forums.css?7"">

	

	<script type=""text/javascript"">
		
		
		
		
	</script>

	<script type=""text/javascript"" src=""/js/vb/forums.combined.js?1359653372""></script>

	

	<!-- ts-specific includes -->
	
	
	

	

	

	
	<script type=""text/javascript"">
		<!--
		function aimwindow(aimid) {
		window.open(""member.php?action=aimmessage&amp;aim=""+aimid,""_blank"",""toolbar=no,location=no,menubar=no,scrollbars=no,width=175,height=275,resizeable=yes,status=no"")
		}
		// -->
	</script>
	<style type=""text/css"">
		.buttons { text-align:center; margin:1em; }
		.buttons a { border:0; }
	</style>
</head>
<body id=""something_awful"" class=""privmsg"">

<div id=""globalmenu"">
	<ul>
		<li class=""first""><a href=""https://secure.somethingawful.com/"">Buy Forum Stuff</a></li>
		<li><a href=""http://www.somethingawful.com/"">Something Awful</a></li>
	</ul>
</div>



<div id=""container"">



	

	<ul id=""nav_purchase"">
		<li><b>Purchase:</b></li>
		<li><a href=""https://secure.somethingawful.com/products/register.php"">Account</a></li>
		<li>- <a href=""https://secure.somethingawful.com/products/platinum.php"">Platinum Upgrade</a></li>
		<li>- <a href=""https://secure.somethingawful.com/products/titlechange.php"">New Avatar</a></li>
		<li>- <a href=""https://secure.somethingawful.com/products/titlechange.php"">Other's Avatar</a></li>
		<li>- <a href=""https://secure.somethingawful.com/products/archives.php"">Archives</a></li>
		<li>- <a href=""https://secure.somethingawful.com/products/noads.php"">No-Ads</a></li>
		<li>- <a href=""https://secure.somethingawful.com/products/namechange.php"">New Username</a></li>
		<li>- <a href=""https://secure.somethingawful.com/products/ad-banner.php"">Banner Advertisement</a></li>
		<li>- <a href=""https://secure.somethingawful.com/products/smilie.php"">Smilie</a></li>
		<li>- <a href=""https://secure.somethingawful.com/products/sticky-thread.php"">Stick Thread</a></li>
		<li>- <a href=""https://secure.somethingawful.com/products/gift-certificate.php"">Gift Cert.</a></li>
	</ul>

	<ul id=""navigation"" class=""navigation"">
<li class=""first""><a href=""/index.php"">SA Forums</a></li>
<li>- <a href=""http://www.somethingawful.com/"">Something Awful</a></li>
<li>- <a href=""/f/search"">Search the Forums</a></li>
<li>- <a href=""/usercp.php"">User Control Panel</a></li>
<li>- <a href=""/private.php"">Private Messages</a></li>
<li>- <a href=""http://www.somethingawful.com/d/forum-rules/forum-rules.php"">Forum Rules</a></li>
<li>- <a href=""/dictionary.php"">SAclopedia</a></li>
<li>- <a href=""/stats.php"">Posting Gloryhole</a></li>
<li>- <a href=""/banlist.php"">Leper's Colony</a></li>
<li>- <a href=""/supportmail.php"">Support</a></li>
<li>- <a href=""/account.php?action=logout&amp;ma=10293618"">Log Out</a></li>

</ul>


<div class=""oma_pal"">
	<!--  Begin Rubicon Project Tag -->
<!--  Site: Something Awful LLC   Zone: Forum ATF Top Quality - Mobile, Pop, Web   Size: Leaderboard  -->
<!--  PLACEMENT: Above the Fold  -->
<script language=""JavaScript"" type=""text/javascript"">
rp_account   = '8539';
rp_site      = '13831';
rp_zonesize  = '80354-2';
rp_adtype    = 'iframe';
rp_width     = '728';
rp_height    = '90';
rp_smartfile = 'http://www.somethingawful.com/revv_smart_file.html';
</script>
<script type=""text/javascript"" src=""https://ads.rubiconproject.com/ad/8539.js""></script>
<!--  End Rubicon Project Tag -->
</div>





	<div id=""content"">

	

<div class=""breadcrumbs""><span class=""mainbodytextlarge""><b><a href=""/"">The Something Awful Forums</a> &gt; <a href=""private.php?"">Private Messages</a> &gt; <a href=""private.php?folderid=0""></a>Re: awful beta</b></span></div>


	<ul id=""usercpnav"">
		<li><a href=""usercp.php"">User CP Home</a></li>
		<li><a href=""member.php?action=accountfeatures"">Account Features</a></li>
		<li><a href=""private.php"">Private Messages</a></li>
		<li><a href=""bookmarkthreads.php"">Bookmarked Threads</a></li>
		<li><a href=""member.php?action=editprofile"">Edit Profile</a></li>
		<li><a href=""member.php?action=editoptions"">Edit Options</a></li>
		<li><a href=""account.php?action=editpassword"">Change Password</a></li>
		<li><a href=""member2.php?action=viewlist&amp;userlist=buddy"">Edit Buddy List</a></li>
		<li><a href=""member2.php?action=viewlist&amp;userlist=ignore"">Edit Ignore List</a></li>
	</ul>

<br>

<form action=""private.php"" method=""post"">
<input type=""hidden"" name=""action"" value=""dodelete"">
<input type=""hidden"" name=""privatemessageid"" value=""5284033"">
<b>Delete?</b> <input type=""checkbox"" name=""delete"" value=""yes"" >
<input type=""submit"" class=""bginput"" value=""Delete"">
</form>

<form action=""private.php"" method=""post"">
<b>Jump to folder:</b>
<select name=""folderid"" onchange=""window.location=('private.php?folderid='+this.options[this.selectedIndex].value)"">
<option value=""0"" selected>Inbox</option>
<option value=""-1"" >Sent Items</option>
<option value=""4"" >awful! -- testing</option>

</select><input type=""submit"" value=""Go"">
</form>

<br>

<div id=""thread"" class=""pm"">
<table class=""post"" id=""post"">
<tr>
	<td class=""userinfo"">
		<dl class=""userinfo userid-77570"">
			<dt class=""author"" title="""">Cybernetic Vermin</dt>
			<dd class=""registered"">Apr 18, 2005</dd>
			
			<dd class=""title"">
			<br>
			
			
			</dd>
			
		</dl>
	</td>
	<td class=""postbody"">
		Good old international unlocked 920.<br />
<br />
Thanks!<br />
<br />
<div class=""bbc-block""><h4>quote:</h4><blockquote>
bootleg robot wrote on Feb 25, 2014 17:50:<br />
Added! What type of phone are you testing with?<br />
<br />
<br />
<div class=""bbc-block""><h4>quote:</h4><blockquote>
Cybernetic Vermin wrote on Feb 25, 2014 09:11:<br />
<div class=""bbc-block""><h4>quote:</h4><blockquote>
bootleg robot wrote on Apr 10, 2013 00:24:<br />
[quote]<br />
Cybernetic Vermin wrote on Apr  9, 2013 12:32:<br />
Hey hey,<br />
<br />
Well, seeing how Microsoft appears to be jerks about approving the app, I figure I'll just ask nicely to be let into the beta instead. <a href=""mailto:martin.berglund@live.com"">martin.berglund@live.com</a>. Pleeeease <img src=""http://fi.somethingawful.com/images/smilies/smile.gif"" border=""0"" alt="""" title="":)""><br />
</blockquote></div>

<br />
Sure thing! I'll update the thread when I submit the next beta round.<br />
</blockquote></div>

<br />
Hey hey, I guess this is a new round of beta access then? Would like to get in on this fancy new 3.0 action as well. Thanks in advance <img src=""http://fi.somethingawful.com/images/smilies/smile.gif"" border=""0"" alt="""" title="":)""><br />
</blockquote></div>

[/quote]
		<p class=""attachment""></p>

	</td>
<tr class=""postbar"">
	<td class=""postdate""><img src=""http://fi.somethingawful.com/images/posticon.gif"" border=""0"" alt=""""> Feb 25, 2014 10:51</td>
	<td class=""postlinks"">
		<ul class=""profilelinks"">
			<li><a href=""member.php?action=getinfo&amp;userid=77570"">Profile</a></li>
			<li><a href=""private.php?action=newmessage&amp;userid=77570"">Message</a></li>
			<li><a href=""search.php?action=do_search_posthistory&amp;userid=77570"">Post History</a></li>
		</ul>
		
	</td>
</tr>
</table>
</div>

<div class=""messages_nextprev"">
	<a href=""private.php?action=show&amp;privatemessageid=5283835"">&lt; Last Message</a>&nbsp; 
</div>

<div class=""buttons"">
	<a href=""private.php?action=newmessage&amp;privatemessageid=5284033""><img src=""http://fi.somethingawful.com/images/pm/reply.gif"" alt=""Reply to this message""></a>
	<a href=""private.php?action=newmessage&amp;forward=true&amp;privatemessageid=5284033""><img src=""http://fi.somethingawful.com/images/pm/forward.gif"" alt=""Forward this message to another member""></a>
	
	<a href=""private.php?action=newmessage""><img src=""http://fi.somethingawful.com/images/pm/newmessage.gif"" alt=""Send a new private message""></a>
</div>


<form class=""forum_jump"" action=""forumdisplay.php"" method=""get"">
<input type=""hidden"" name=""s"" value="""">
<input type=""hidden"" name=""daysprune"" value="""">
<select name=""forumid"">
<option value=""-1"" selected>Jump to another forum:</option>
<option value=""-1"">--------------------</option>
<option value=""pm"" >Private Messages</option>
<option value=""cp"" >User Control Panel</option>
<option value=""search"" >Search Forums</option>
<option value=""home"" >Forums Home</option>
<option value=""lc"" >Leper's Colony</option>
<option value=""-1"">--------------------</option>
<option value=""48"" > Main</option><option value=""1"" >-- GBS 1.4</option><option value=""155"" >---- SA's Front Page Discussion</option><option value=""214"" >---- E/N Bullshit</option><option value=""26"" >-- FYAD: http://vimeo.com/86014703</option><option value=""154"" >---- A Beecock Forum.</option><option value=""268"" >-- BYOB 8.2</option><option value=""51"" > Discussion</option><option value=""44"" >-- Games</option><option value=""259"" >---- A Blizzard Subforum</option><option value=""146"" >------ WoW: Goon Squad</option><option value=""145"" >---- The MMO HMO</option><option value=""93"" >---- Private Game Servers</option><option value=""234"" >---- Dice &amp; Drama</option><option value=""103"" >------ The Goblin Ranch</option><option value=""191"" >---- Let's Play!</option><option value=""267"" >---- Dungeons &amp; Dreamcast Recreation Dome</option><option value=""192"" >-- Inspect Your Gadgets</option><option value=""158"" >-- Ask / Tell</option><option value=""162"" >---- Science, Academics and Languages</option><option value=""211"" >---- Tourism &amp; Travel</option><option value=""200"" >---- Business, Finance, and Careers</option><option value=""46"" >-- Debate Disco</option><option value=""22"" >-- Serious Hardware / Software Crap</option><option value=""170"" >---- Haus of Tech Support</option><option value=""202"" >---- The Cavern of COBOL</option><option value=""265"" >------ project.log</option><option value=""219"" >---- YOSPOS</option><option value=""122"" >-- Sports Argument Stadium* </option><option value=""181"" >---- The Football Funhouse</option><option value=""248"" >---- The Armchair Quarterback</option><option value=""175"" >---- The Ray Parlour</option><option value=""177"" >---- Punchsport Pagoda</option><option value=""179"" >-- You Look Like Shit</option><option value=""183"" >---- The Goon Doctor</option><option value=""244"" >---- The Fitness Log Cabin</option><option value=""242"" >-- Paranormal/Conspiracy Forum</option><option value=""161"" >-- Goons With Spoons</option><option value=""167"" >-- Post Your Favorite (or Request)</option><option value=""91"" >-- Automotive Insanity</option><option value=""236"" >---- Cycle Asylum</option><option value=""124"" >-- Pet Island</option><option value=""132"" >-- The Firing Range</option><option value=""90"" >-- The Crackhead Clubhouse</option><option value=""218"" >-- Goons in Platoons</option><option value=""152"" > The Finer Arts</option><option value=""31"" >-- Creative Convention</option><option value=""210"" >---- DIY &amp; Hobbies</option><option value=""247"" >---- The Dorkroom</option><option value=""151"" >-- Cinema Discusso</option><option value=""133"" >---- The Film Dump</option><option value=""182"" >-- The Book Barn</option><option value=""150"" >-- No Music Discussion</option><option value=""104"" >---- Musician's Lounge</option><option value=""130"" >-- The TV IV</option><option value=""144"" >-- Batman's Shameful Secret</option><option value=""27"" >-- ADTRW</option><option value=""215"" >-- Entertainment, Weakly</option><option value=""255"" >-- Rapidly Going Deaf</option><option value=""153"" > The Community</option><option value=""61"" >-- SA-Mart</option><option value=""77"" >---- Feedback &amp; Discussion</option><option value=""85"" >---- Coupons &amp; Deals</option><option value=""43"" >-- Goon Meets</option><option value=""241"" >-- LAN: Your City Sucks - Regional Discussion</option><option value=""188"" >-- Questions, Comments, Suggestions? - Read the stickies first!</option><option value=""49"" > Archives</option><option value=""21"" >-- Comedy Goldmine</option><option value=""264"" >---- Comedy Purgatory</option><option value=""115"" >---- FYAD: Criterion Collection</option><option value=""204"" >---- Helldump Success Stories</option><option value=""222"" >---- LF Goldmine</option><option value=""229"" >---- YCS Goldmine</option><option value=""25"" >-- Comedy Gas Chamber</option>
</select>
<input type=""submit"" value=""Go"">
</form>

</div><!-- #content -->
	<ul class=""navigation"">
<li class=""first""><a href=""/index.php"">SA Forums</a></li>
<li>- <a href=""http://www.somethingawful.com/"">Something Awful</a></li>
<li>- <a href=""/f/search"">Search the Forums</a></li>
<li>- <a href=""/usercp.php"">User Control Panel</a></li>
<li>- <a href=""/private.php"">Private Messages</a></li>
<li>- <a href=""http://www.somethingawful.com/d/forum-rules/forum-rules.php"">Forum Rules</a></li>
<li>- <a href=""/dictionary.php"">SAclopedia</a></li>
<li>- <a href=""/stats.php"">Posting Gloryhole</a></li>
<li>- <a href=""/banlist.php"">Leper's Colony</a></li>
<li>- <a href=""/supportmail.php"">Support</a></li>
<li>- <a href=""/account.php?action=logout&amp;ma=10293618"">Log Out</a></li>

</ul>
	<div id=""copyright"">
		Powered by: vBulletin Version 2.2.9 (<a href=""/CHANGES"">SAVB-v2.1.17</a>)<br>
		Copyright &copy;2000, 2001, Jelsoft Enterprises Limited.<br>
		Copyright &copy;2012, Something Awful LLC<br>
	</div>

</div><!-- #container -->

<script type=""text/javascript"">
	// quantcast
	_qoptions = { qacct:""p-82vTvmw-enlng"" };

	try {
		if(document.location.hostname != 'forums.somethingawful.com')
			throw undefined;

		$(document).ready(function() {
			var qcUrl = 'http://edge.quantserve.com/quant.js';
			jQuery.getScript(qcUrl);

			var gaJsHost = ((""https:"" == document.location.protocol) ? ""https://ssl."" : ""http://www."");
			var gaUrl = gaJsHost + 'google-analytics.com/ga.js';
			jQuery.getScript(gaUrl, function() {
				var pageTracker = _gat._getTracker(""UA-3064978-2"");
				pageTracker._initData();
				pageTracker._trackPageview();
			});
		});
	} catch(e) {};

	// indie
	// try {
	// 	if(document.location.hostname != 'forums.somethingawful.com')
	// 		throw undefined;

	// 	$(document).ready(function() {
	// 		var ic_element = document.createElement('script');
	// 		ic_element.type = 'text/javascript';
	// 		ic_element.async = true;
	// 		ic_element.id = 'ic_annonymous_pixel';
	// 		ic_element.src = 'http://pixel.indieclick.com/annonymous/domain/somethingawful.com/reach/script_ic.js';
	// 		var ic_script = document.getElementsByTagName('script')[0];
	// 		ic_script.parentNode.insertBefore(ic_element, ic_script);
	// 	});
	// } catch(e) {};
</script>
<noscript><img src=""http://pixel.quantserve.com/pixel/p-82vTvmw-enlng.gif"" style=""display:none;"" border=""0"" height=""1"" width=""1"" alt=""Quantcast""></noscript>

<!-- PLEASE DO NOT REMOVE -->
<ol id=""debug"" style=""display:none""><li>&nbsp;</ol>

</body>
</html>";
        }
        public virtual string GenerateMockPrivateMessageFolderHtml()
        {
            return @"<!DOCTYPE html>
<html>
<head>
	<title>The Something Awful Forums - Private Messaging: bootleg robot</title>
	
	<meta name=""MSSmartTagsPreventParsing"" content=""TRUE"">
	<meta http-equiv=""X-UA-Compatible"" content=""chrome=1"">
	<!--[if lt IE 7]><link rel=""stylesheet"" type=""text/css"" href=""/css/ie.css?1348360344""><![endif]-->
	<!--[if lt IE 8]><link rel=""stylesheet"" type=""text/css"" href=""/css/ie7.css?1348360344""><![endif]-->
	<link rel=""apple-touch-icon"" href=""http://i.somethingawful.com/core/icon/iphone-touch/forums.png"">
	<link rel=""stylesheet"" type=""text/css"" href=""/css/main.css?1359594161"">
	<link rel=""stylesheet"" type=""text/css"" href=""/css/bbcode.css?1348360344"">
	<link rel=""stylesheet"" type=""text/css"" href=""http://www.somethingawful.com/globalcss/globalmenu.css"">

	

	<!-- <script src=""/__utm.js"" type=""text/javascript""></script> -->
	<!-- script src=""/js/dojo/dojo.js?1348360344"" type=""text/javascript""></script -->
	<script type=""text/javascript"" src=""//ajax.googleapis.com/ajax/libs/jquery/1.8.3/jquery.min.js""></script>
	<link rel=""stylesheet"" type=""text/css"" href=""//ajax.googleapis.com/ajax/libs/jqueryui/1.9.2/themes/redmond/jquery-ui.css"">
	<script type=""text/javascript"" src=""//ajax.googleapis.com/ajax/libs/jqueryui/1.9.2/jquery-ui.min.js""></script>

	<link rel=""stylesheet"" type=""text/css"" href=""http://www.somethingawful.com/css/forums.css?7"">

	

	<script type=""text/javascript"">
		
		
		
		
	</script>

	<script type=""text/javascript"" src=""/js/vb/forums.combined.js?1359653372""></script>

	

	<!-- ts-specific includes -->
	
	
	

	

	

	
	<script type=""text/javascript"">
	<!--
	function CheckAll() {
		for (var i=0;i<document.form.elements.length;i++) {
			var e = document.form.elements[i];
			if ((e.name != 'allbox') && (e.type=='checkbox')) {
				e.checked = document.form.allbox.checked;
			}
		}
	}
	function CheckCheckAll() {
		var TotalBoxes = 0;
		var TotalOn = 0;
		for (var i=0;i<document.form.elements.length;i++) {
			var e = document.form.elements[i];
			if ((e.name != 'allbox') && (e.type=='checkbox')) {
				TotalBoxes++;
				if (e.checked) {
					TotalOn++;
				}
			}
		}
		if (TotalBoxes==TotalOn) {
			document.form.allbox.checked=true;
		} else {
			document.form.allbox.checked=false;
		}
	}
	//-->
	</script>
	<style type=""text/css"">
		.pmwarn { margin:1em; color:red; font-weight:bold; padding-left:18px; background: url('http://fi.somethingawful.com/images/warning.gif') left no-repeat; }
		.msgbuttons { text-align:center; }
		.msgbuttons img { border:0; }
	</style>
</head>
<body id=""something_awful"" class=""privfolder"">
<div id=""globalmenu"">
	<ul>
		<li class=""first""><a href=""https://secure.somethingawful.com/"">Buy Forum Stuff</a></li>
		<li><a href=""http://www.somethingawful.com/"">Something Awful</a></li>
	</ul>
</div>



<div id=""container"">



	

	<ul id=""nav_purchase"">
		<li><b>Purchase:</b></li>
		<li><a href=""https://secure.somethingawful.com/products/register.php"">Account</a></li>
		<li>- <a href=""https://secure.somethingawful.com/products/platinum.php"">Platinum Upgrade</a></li>
		<li>- <a href=""https://secure.somethingawful.com/products/titlechange.php"">New Avatar</a></li>
		<li>- <a href=""https://secure.somethingawful.com/products/titlechange.php"">Other's Avatar</a></li>
		<li>- <a href=""https://secure.somethingawful.com/products/archives.php"">Archives</a></li>
		<li>- <a href=""https://secure.somethingawful.com/products/noads.php"">No-Ads</a></li>
		<li>- <a href=""https://secure.somethingawful.com/products/namechange.php"">New Username</a></li>
		<li>- <a href=""https://secure.somethingawful.com/products/ad-banner.php"">Banner Advertisement</a></li>
		<li>- <a href=""https://secure.somethingawful.com/products/smilie.php"">Smilie</a></li>
		<li>- <a href=""https://secure.somethingawful.com/products/sticky-thread.php"">Stick Thread</a></li>
		<li>- <a href=""https://secure.somethingawful.com/products/gift-certificate.php"">Gift Cert.</a></li>
	</ul>

	<ul id=""navigation"" class=""navigation"">
<li class=""first""><a href=""/index.php"">SA Forums</a></li>
<li>- <a href=""http://www.somethingawful.com/"">Something Awful</a></li>
<li>- <a href=""/f/search"">Search the Forums</a></li>
<li>- <a href=""/usercp.php"">User Control Panel</a></li>
<li>- <a href=""/private.php"">Private Messages</a></li>
<li>- <a href=""http://www.somethingawful.com/d/forum-rules/forum-rules.php"">Forum Rules</a></li>
<li>- <a href=""/dictionary.php"">SAclopedia</a></li>
<li>- <a href=""/stats.php"">Posting Gloryhole</a></li>
<li>- <a href=""/banlist.php"">Leper's Colony</a></li>
<li>- <a href=""/supportmail.php"">Support</a></li>
<li>- <a href=""/account.php?action=logout&amp;ma=10293618"">Log Out</a></li>

</ul>


<div class=""oma_pal"">
	<!--  Begin Rubicon Project Tag -->
<!--  Site: Something Awful LLC   Zone: Forum ATF Top Quality - Mobile, Pop, Web   Size: Leaderboard  -->
<!--  PLACEMENT: Above the Fold  -->
<script language=""JavaScript"" type=""text/javascript"">
rp_account   = '8539';
rp_site      = '13831';
rp_zonesize  = '80354-2';
rp_adtype    = 'iframe';
rp_width     = '728';
rp_height    = '90';
rp_smartfile = 'http://www.somethingawful.com/revv_smart_file.html';
</script>
<script type=""text/javascript"" src=""https://ads.rubiconproject.com/ad/8539.js""></script>
<!--  End Rubicon Project Tag -->
</div>





	<div id=""content"">

	

<div class=""breadcrumbs""><a href=""index.php"">The Something Awful Forums</a> &gt; <a href=""usercp.php"">User Control Panel For bootleg robot</a> &gt; <a href=""private.php"">Private Messages</a> &gt; Inbox</div>


	<ul id=""usercpnav"">
		<li><a href=""usercp.php"">User CP Home</a></li>
		<li><a href=""member.php?action=accountfeatures"">Account Features</a></li>
		<li><a href=""private.php"">Private Messages</a></li>
		<li><a href=""bookmarkthreads.php"">Bookmarked Threads</a></li>
		<li><a href=""member.php?action=editprofile"">Edit Profile</a></li>
		<li><a href=""member.php?action=editoptions"">Edit Options</a></li>
		<li><a href=""account.php?action=editpassword"">Change Password</a></li>
		<li><a href=""member2.php?action=viewlist&amp;userlist=buddy"">Edit Buddy List</a></li>
		<li><a href=""member2.php?action=viewlist&amp;userlist=ignore"">Edit Ignore List</a></li>
	</ul>


<form class=""date_select"" action=""private.php"" method=""post"">
<input type=""hidden"" name=""folderid"" value="""">
<b>Show Messages From:</b> <select name=""daysprune"" onchange=""window.location=('private.php?folderid=&amp;daysprune=' + this.options[this.selectedIndex].value)"">
	<option value=""1"" >last day</option>
	<option value=""2"" >last 2 days</option>
	<option value=""5"" >last 5 days</option>
	<option value=""10"" >last 10 days</option>
	<option value=""20"" >last 20 days</option>
	<option value=""30"" >last 30 days</option>
	<option value=""45"" >last 45 days</option>
	<option value=""60"" >last 60 days</option>
	<option value=""75"" >last 75 days</option>
	<option value=""100"" >last 100 days</option>
	<option value=""365"" >the last year</option>
	<option value=""9999"" selected>the beginning</option>
</select><input type=""submit"" value=""Go"">
</form>

<form class=""folder"" action=""private.php"" method=""post"">
	<b>Jump to folder:</b>
	<select name=""folderid"" onchange=""window.location=('private.php?folderid=' + this.options[this.selectedIndex].value + '&amp;daysprune=9999')"">
	<option value=""0"" selected>Inbox</option>
	<option value=""-1"" >Sent Items</option>
	<option value=""4"" >awful! -- testing</option>
	
	</select><input type=""submit"" value=""Go"">
</form>


	<div class=""pmwarn"">NOTICE: Only showing the last fifty messages to keep things fast, <a href=""?folderid=0&amp;daysprune=9999&amp;showall=1"">click here</a> to list them all!</div>


<form class=""action"" action=""private.php"" method=""post"" name=""form"">
	<table class=""standard full"">
		<thead>
        <tr>
            <th class=""title"" colspan=""3"">Message Title</th>
            <th class=""sender"">Sender</th>
            <th class=""date"">Date / Time Sent</th>
            <th class=""check""><input name=""allbox"" type=""checkbox"" value=""Check All"" title=""Select/Deselect All"" onClick=""CheckAll();""></th>
        </tr>
        </thead>

        <tbody>
        
		<tr>
			<td class=""status""><img src=""http://fi.somethingawful.com/images/pm.gif"" alt=""""></td>
			<td class=""icon"">&nbsp;</td>
			<td class=""title""><a href=""private.php?action=show&amp;privatemessageid=5284033"">Re: awful beta</a>
			</td>
			<td class=""sender"">Cybernetic Vermin</td>
			<td class=""date"">Feb 25, 2014 at 10:51</td>
			<td class=""check""><input type=""checkbox"" name=""privatemessage[5284033]"" value=""yes""></td>
		</tr>
		<tr>
			<td class=""status""><img src=""http://fi.somethingawful.com/images/pmreplied.gif"" alt=""""></td>
			<td class=""icon"">&nbsp;</td>
			<td class=""title""><a href=""private.php?action=show&amp;privatemessageid=5283835"">Re: awful beta</a>
			</td>
			<td class=""sender"">Cybernetic Vermin</td>
			<td class=""date"">Feb 25, 2014 at 09:11</td>
			<td class=""check""><input type=""checkbox"" name=""privatemessage[5283835]"" value=""yes""></td>
		</tr>
		<tr>
			<td class=""status""><img src=""http://fi.somethingawful.com/images/pmreplied.gif"" alt=""""></td>
			<td class=""icon""><img src=""http://fi.somethingawful.com/forums/posticons/icons-08/drugs.png"" alt=""Drugs, maaaan"" border=""0""></td>
			<td class=""title""><a href=""private.php?action=show&amp;privatemessageid=5191281"">WP8 awful app beta</a>
			</td>
			<td class=""sender"">Mecca-Benghazi</td>
			<td class=""date"">Dec 17, 2013 at 18:55</td>
			<td class=""check""><input type=""checkbox"" name=""privatemessage[5191281]"" value=""yes""></td>
		</tr>
		<tr>
			<td class=""status""><img src=""http://fi.somethingawful.com/images/pmreplied.gif"" alt=""""></td>
			<td class=""icon"">&nbsp;</td>
			<td class=""title""><a href=""private.php?action=show&amp;privatemessageid=5115595"">New Live ID for use in Awful beta</a>
			</td>
			<td class=""sender"">loquacius</td>
			<td class=""date"">Nov  1, 2013 at 10:04</td>
			<td class=""check""><input type=""checkbox"" name=""privatemessage[5115595]"" value=""yes""></td>
		</tr>
		<tr>
			<td class=""status""><img src=""http://fi.somethingawful.com/images/pm.gif"" alt=""""></td>
			<td class=""icon""><img src=""http://fi.somethingawful.com/forums/posticons/icons-08/repeat.png"" alt=""Repeated subject / link?"" border=""0""></td>
			<td class=""title""><a href=""private.php?action=show&amp;privatemessageid=5064952"">test message</a>
			</td>
			<td class=""sender"">bootleg robot</td>
			<td class=""date"">Oct  1, 2013 at 00:58</td>
			<td class=""check""><input type=""checkbox"" name=""privatemessage[5064952]"" value=""yes""></td>
		</tr>
		<tr>
			<td class=""status""><img src=""http://fi.somethingawful.com/images/pm.gif"" alt=""""></td>
			<td class=""icon"">&nbsp;</td>
			<td class=""title""><a href=""private.php?action=show&amp;privatemessageid=5022492"">Re: Awful thread tags are in their own repository</a>
			</td>
			<td class=""sender"">pokeyman</td>
			<td class=""date"">Sep  3, 2013 at 14:46</td>
			<td class=""check""><input type=""checkbox"" name=""privatemessage[5022492]"" value=""yes""></td>
		</tr>
		<tr>
			<td class=""status""><img src=""http://fi.somethingawful.com/images/pmreplied.gif"" alt=""""></td>
			<td class=""icon""><img src=""http://fi.somethingawful.com/forums/posticons/icons-08/link.png"" alt=""URL Link"" border=""0""></td>
			<td class=""title""><a href=""private.php?action=show&amp;privatemessageid=5020312"">Awful thread tags are in their own repository</a>
			</td>
			<td class=""sender"">pokeyman</td>
			<td class=""date"">Sep  2, 2013 at 05:20</td>
			<td class=""check""><input type=""checkbox"" name=""privatemessage[5020312]"" value=""yes""></td>
		</tr>
		<tr>
			<td class=""status""><img src=""http://fi.somethingawful.com/images/pm.gif"" alt=""""></td>
			<td class=""icon"">&nbsp;</td>
			<td class=""title""><a href=""private.php?action=show&amp;privatemessageid=4975760"">Re: One more order!</a>
			</td>
			<td class=""sender"">Night141</td>
			<td class=""date"">Aug  1, 2013 at 13:01</td>
			<td class=""check""><input type=""checkbox"" name=""privatemessage[4975760]"" value=""yes""></td>
		</tr>
		<tr>
			<td class=""status""><img src=""http://fi.somethingawful.com/images/pm.gif"" alt=""""></td>
			<td class=""icon"">&nbsp;</td>
			<td class=""title""><a href=""private.php?action=show&amp;privatemessageid=4966740"">Shipping info Nexus 7</a>
			</td>
			<td class=""sender"">Night141</td>
			<td class=""date"">Jul 26, 2013 at 13:59</td>
			<td class=""check""><input type=""checkbox"" name=""privatemessage[4966740]"" value=""yes""></td>
		</tr>
		<tr>
			<td class=""status""><img src=""http://fi.somethingawful.com/images/pm.gif"" alt=""""></td>
			<td class=""icon"">&nbsp;</td>
			<td class=""title""><a href=""private.php?action=show&amp;privatemessageid=4966720"">Nexus 7</a>
			</td>
			<td class=""sender"">Night141</td>
			<td class=""date"">Jul 26, 2013 at 13:41</td>
			<td class=""check""><input type=""checkbox"" name=""privatemessage[4966720]"" value=""yes""></td>
		</tr>
		<tr>
			<td class=""status""><img src=""http://fi.somethingawful.com/images/pmreplied.gif"" alt=""""></td>
			<td class=""icon"">&nbsp;</td>
			<td class=""title""><a href=""private.php?action=show&amp;privatemessageid=4964145"">Re: Nexus 7</a>
			</td>
			<td class=""sender"">Night141</td>
			<td class=""date"">Jul 24, 2013 at 14:44</td>
			<td class=""check""><input type=""checkbox"" name=""privatemessage[4964145]"" value=""yes""></td>
		</tr>
		<tr>
			<td class=""status""><img src=""http://fi.somethingawful.com/images/pm.gif"" alt=""""></td>
			<td class=""icon"">&nbsp;</td>
			<td class=""title""><a href=""private.php?action=show&amp;privatemessageid=4956423"">Re: Awful Reader Beta</a>
			</td>
			<td class=""sender"">bootleg robot</td>
			<td class=""date"">Jul 18, 2013 at 16:08</td>
			<td class=""check""><input type=""checkbox"" name=""privatemessage[4956423]"" value=""yes""></td>
		</tr>
		<tr>
			<td class=""status""><img src=""http://fi.somethingawful.com/images/pmreplied.gif"" alt=""""></td>
			<td class=""icon"">&nbsp;</td>
			<td class=""title""><a href=""private.php?action=show&amp;privatemessageid=4925821"">Awful Reader Beta</a>
			</td>
			<td class=""sender"">rufius</td>
			<td class=""date"">Jun 27, 2013 at 17:10</td>
			<td class=""check""><input type=""checkbox"" name=""privatemessage[4925821]"" value=""yes""></td>
		</tr>
		<tr>
			<td class=""status""><img src=""http://fi.somethingawful.com/images/pm.gif"" alt=""""></td>
			<td class=""icon""><img src=""http://fi.somethingawful.com/forums/posticons/icons-08/drugs.png"" alt=""Drugs, maaaan"" border=""0""></td>
			<td class=""title""><a href=""private.php?action=show&amp;privatemessageid=4925637"">Hey, maybe you should update the OP or something.</a>
			</td>
			<td class=""sender"">bootleg robot</td>
			<td class=""date"">Jun 27, 2013 at 15:16</td>
			<td class=""check""><input type=""checkbox"" name=""privatemessage[4925637]"" value=""yes""></td>
		</tr>
		<tr>
			<td class=""status""><img src=""http://fi.somethingawful.com/images/pm.gif"" alt=""""></td>
			<td class=""icon"">&nbsp;</td>
			<td class=""title""><a href=""private.php?action=show&amp;privatemessageid=4897741"">Re: Repository of selectors for parsing SA HTML?</a>
			</td>
			<td class=""sender"">pokeyman</td>
			<td class=""date"">Jun 11, 2013 at 12:10</td>
			<td class=""check""><input type=""checkbox"" name=""privatemessage[4897741]"" value=""yes""></td>
		</tr>
		<tr>
			<td class=""status""><img src=""http://fi.somethingawful.com/images/pm.gif"" alt=""""></td>
			<td class=""icon"">&nbsp;</td>
			<td class=""title""><a href=""private.php?action=show&amp;privatemessageid=4897540"">Re: Repository of selectors for parsing SA HTML?</a>
			</td>
			<td class=""sender"">pokeyman</td>
			<td class=""date"">Jun 11, 2013 at 10:43</td>
			<td class=""check""><input type=""checkbox"" name=""privatemessage[4897540]"" value=""yes""></td>
		</tr>
		<tr>
			<td class=""status""><img src=""http://fi.somethingawful.com/images/pmreplied.gif"" alt=""""></td>
			<td class=""icon"">&nbsp;</td>
			<td class=""title""><a href=""private.php?action=show&amp;privatemessageid=4895648"">Re: Repository of selectors for parsing SA HTML?</a>
			</td>
			<td class=""sender"">pokeyman</td>
			<td class=""date"">Jun 10, 2013 at 10:23</td>
			<td class=""check""><input type=""checkbox"" name=""privatemessage[4895648]"" value=""yes""></td>
		</tr>
		<tr>
			<td class=""status""><img src=""http://fi.somethingawful.com/images/pmreplied.gif"" alt=""""></td>
			<td class=""icon""><img src=""http://fi.somethingawful.com/forums/posticons/icons-08/school.png"" alt=""School"" border=""0""></td>
			<td class=""title""><a href=""private.php?action=show&amp;privatemessageid=4894884"">Repository of selectors for parsing SA HTML?</a>
			</td>
			<td class=""sender"">pokeyman</td>
			<td class=""date"">Jun  9, 2013 at 19:57</td>
			<td class=""check""><input type=""checkbox"" name=""privatemessage[4894884]"" value=""yes""></td>
		</tr>
		<tr>
			<td class=""status""><img src=""http://fi.somethingawful.com/images/pm.gif"" alt=""""></td>
			<td class=""icon"">&nbsp;</td>
			<td class=""title""><a href=""private.php?action=show&amp;privatemessageid=4872565"">Re: How do you POST a new thread?</a>
			</td>
			<td class=""sender"">pokeyman</td>
			<td class=""date"">May 25, 2013 at 21:14</td>
			<td class=""check""><input type=""checkbox"" name=""privatemessage[4872565]"" value=""yes""></td>
		</tr>
		<tr>
			<td class=""status""><img src=""http://fi.somethingawful.com/images/pmreplied.gif"" alt=""""></td>
			<td class=""icon"">&nbsp;</td>
			<td class=""title""><a href=""private.php?action=show&amp;privatemessageid=4871868"">Re: How do you POST a new thread?</a>
			</td>
			<td class=""sender"">pokeyman</td>
			<td class=""date"">May 25, 2013 at 09:07</td>
			<td class=""check""><input type=""checkbox"" name=""privatemessage[4871868]"" value=""yes""></td>
		</tr>
		<tr>
			<td class=""status""><img src=""http://fi.somethingawful.com/images/pm.gif"" alt=""""></td>
			<td class=""icon"">&nbsp;</td>
			<td class=""title""><a href=""private.php?action=show&amp;privatemessageid=4863725"">Re: How do you POST a new thread?</a>
			</td>
			<td class=""sender"">pokeyman</td>
			<td class=""date"">May 20, 2013 at 12:53</td>
			<td class=""check""><input type=""checkbox"" name=""privatemessage[4863725]"" value=""yes""></td>
		</tr>
		<tr>
			<td class=""status""><img src=""http://fi.somethingawful.com/images/pmreplied.gif"" alt=""""></td>
			<td class=""icon"">&nbsp;</td>
			<td class=""title""><a href=""private.php?action=show&amp;privatemessageid=4863671"">How do you POST a new thread?</a>
			</td>
			<td class=""sender"">pokeyman</td>
			<td class=""date"">May 20, 2013 at 12:13</td>
			<td class=""check""><input type=""checkbox"" name=""privatemessage[4863671]"" value=""yes""></td>
		</tr>
		<tr>
			<td class=""status""><img src=""http://fi.somethingawful.com/images/pm.gif"" alt=""""></td>
			<td class=""icon"">&nbsp;</td>
			<td class=""title""><a href=""private.php?action=show&amp;privatemessageid=4856950"">Re: Awful Forums App</a>
			</td>
			<td class=""sender"">The Lord Bude</td>
			<td class=""date"">May 15, 2013 at 15:03</td>
			<td class=""check""><input type=""checkbox"" name=""privatemessage[4856950]"" value=""yes""></td>
		</tr>
		<tr>
			<td class=""status""><img src=""http://fi.somethingawful.com/images/pmreplied.gif"" alt=""""></td>
			<td class=""icon"">&nbsp;</td>
			<td class=""title""><a href=""private.php?action=show&amp;privatemessageid=4849472"">Awful Forums App</a>
			</td>
			<td class=""sender"">The Lord Bude</td>
			<td class=""date"">May 10, 2013 at 09:33</td>
			<td class=""check""><input type=""checkbox"" name=""privatemessage[4849472]"" value=""yes""></td>
		</tr>
		<tr>
			<td class=""status""><img src=""http://fi.somethingawful.com/images/pmreplied.gif"" alt=""""></td>
			<td class=""icon"">&nbsp;</td>
			<td class=""title""><a href=""private.php?action=show&amp;privatemessageid=4835468"">Re: Awful!! HD</a>
			</td>
			<td class=""sender"">pocket pool</td>
			<td class=""date"">Apr 29, 2013 at 20:49</td>
			<td class=""check""><input type=""checkbox"" name=""privatemessage[4835468]"" value=""yes""></td>
		</tr>
		<tr>
			<td class=""status""><img src=""http://fi.somethingawful.com/images/pm.gif"" alt=""""></td>
			<td class=""icon"">&nbsp;</td>
			<td class=""title""><a href=""private.php?action=show&amp;privatemessageid=4834961"">Re: test message</a>
			</td>
			<td class=""sender"">bootleg robot</td>
			<td class=""date"">Apr 29, 2013 at 14:18</td>
			<td class=""check""><input type=""checkbox"" name=""privatemessage[4834961]"" value=""yes""></td>
		</tr>
		<tr>
			<td class=""status""><img src=""http://fi.somethingawful.com/images/pm.gif"" alt=""""></td>
			<td class=""icon""><img src=""http://fi.somethingawful.com/forums/posticons/icons-08/newbie.png"" alt=""NEWBIE QUESTION"" border=""0""></td>
			<td class=""title""><a href=""private.php?action=show&amp;privatemessageid=4834904"">test message</a>
			</td>
			<td class=""sender"">bootleg robot</td>
			<td class=""date"">Apr 29, 2013 at 13:39</td>
			<td class=""check""><input type=""checkbox"" name=""privatemessage[4834904]"" value=""yes""></td>
		</tr>
		<tr>
			<td class=""status""><img src=""http://fi.somethingawful.com/images/pmreplied.gif"" alt=""""></td>
			<td class=""icon"">&nbsp;</td>
			<td class=""title""><a href=""private.php?action=show&amp;privatemessageid=4834604"">Re: Awful!! HD</a>
			</td>
			<td class=""sender"">pocket pool</td>
			<td class=""date"">Apr 29, 2013 at 09:21</td>
			<td class=""check""><input type=""checkbox"" name=""privatemessage[4834604]"" value=""yes""></td>
		</tr>
		<tr>
			<td class=""status""><img src=""http://fi.somethingawful.com/images/pm.gif"" alt=""""></td>
			<td class=""icon"">&nbsp;</td>
			<td class=""title""><a href=""private.php?action=show&amp;privatemessageid=4832030"">Re: Awful -- Squishing this bug</a>
			</td>
			<td class=""sender"">The Lord Bude</td>
			<td class=""date"">Apr 26, 2013 at 23:33</td>
			<td class=""check""><input type=""checkbox"" name=""privatemessage[4832030]"" value=""yes""></td>
		</tr>
		<tr>
			<td class=""status""><img src=""http://fi.somethingawful.com/images/pm.gif"" alt=""""></td>
			<td class=""icon"">&nbsp;</td>
			<td class=""title""><a href=""private.php?action=show&amp;privatemessageid=4831910"">Re: Awful -- Squishing this bug</a>
			</td>
			<td class=""sender"">The Lord Bude</td>
			<td class=""date"">Apr 26, 2013 at 21:36</td>
			<td class=""check""><input type=""checkbox"" name=""privatemessage[4831910]"" value=""yes""></td>
		</tr>
		<tr>
			<td class=""status""><img src=""http://fi.somethingawful.com/images/pm.gif"" alt=""""></td>
			<td class=""icon"">&nbsp;</td>
			<td class=""title""><a href=""private.php?action=show&amp;privatemessageid=4831850"">Re: Awful -- Squishing this bug</a>
			</td>
			<td class=""sender"">The Lord Bude</td>
			<td class=""date"">Apr 26, 2013 at 20:29</td>
			<td class=""check""><input type=""checkbox"" name=""privatemessage[4831850]"" value=""yes""></td>
		</tr>
		<tr>
			<td class=""status""><img src=""http://fi.somethingawful.com/images/pmreplied.gif"" alt=""""></td>
			<td class=""icon"">&nbsp;</td>
			<td class=""title""><a href=""private.php?action=show&amp;privatemessageid=4823295"">Re: Awful!! HD</a>
			</td>
			<td class=""sender"">pocket pool</td>
			<td class=""date"">Apr 21, 2013 at 11:00</td>
			<td class=""check""><input type=""checkbox"" name=""privatemessage[4823295]"" value=""yes""></td>
		</tr>
		<tr>
			<td class=""status""><img src=""http://fi.somethingawful.com/images/pm.gif"" alt=""""></td>
			<td class=""icon"">&nbsp;</td>
			<td class=""title""><a href=""private.php?action=show&amp;privatemessageid=4822384"">Re: Awful!! HD</a>
			</td>
			<td class=""sender"">pocket pool</td>
			<td class=""date"">Apr 20, 2013 at 14:58</td>
			<td class=""check""><input type=""checkbox"" name=""privatemessage[4822384]"" value=""yes""></td>
		</tr>
		<tr>
			<td class=""status""><img src=""http://fi.somethingawful.com/images/pmreplied.gif"" alt=""""></td>
			<td class=""icon"">&nbsp;</td>
			<td class=""title""><a href=""private.php?action=show&amp;privatemessageid=4822077"">Awful!! HD</a>
			</td>
			<td class=""sender"">pocket pool</td>
			<td class=""date"">Apr 20, 2013 at 11:44</td>
			<td class=""check""><input type=""checkbox"" name=""privatemessage[4822077]"" value=""yes""></td>
		</tr>
		<tr>
			<td class=""status""><img src=""http://fi.somethingawful.com/images/pm.gif"" alt=""""></td>
			<td class=""icon"">&nbsp;</td>
			<td class=""title""><a href=""private.php?action=show&amp;privatemessageid=4821600"">Re: Forum app beta expired</a>
			</td>
			<td class=""sender"">The Lord Bude</td>
			<td class=""date"">Apr 19, 2013 at 22:25</td>
			<td class=""check""><input type=""checkbox"" name=""privatemessage[4821600]"" value=""yes""></td>
		</tr>
		<tr>
			<td class=""status""><img src=""http://fi.somethingawful.com/images/pmreplied.gif"" alt=""""></td>
			<td class=""icon"">&nbsp;</td>
			<td class=""title""><a href=""private.php?action=show&amp;privatemessageid=4805674"">awful beta</a>
			</td>
			<td class=""sender"">Cybernetic Vermin</td>
			<td class=""date"">Apr  9, 2013 at 12:32</td>
			<td class=""check""><input type=""checkbox"" name=""privatemessage[4805674]"" value=""yes""></td>
		</tr>
		<tr>
			<td class=""status""><img src=""http://fi.somethingawful.com/images/pm.gif"" alt=""""></td>
			<td class=""icon""><img src=""http://fi.somethingawful.com/forums/posticons/icons-08/computers.png"" alt=""Computer issues"" border=""0""></td>
			<td class=""title""><a href=""private.php?action=show&amp;privatemessageid=4799784"">Awful beta</a>
			</td>
			<td class=""sender"">Bender</td>
			<td class=""date"">Apr  4, 2013 at 20:36</td>
			<td class=""check""><input type=""checkbox"" name=""privatemessage[4799784]"" value=""yes""></td>
		</tr>
		<tr>
			<td class=""status""><img src=""http://fi.somethingawful.com/images/pm.gif"" alt=""""></td>
			<td class=""icon"">&nbsp;</td>
			<td class=""title""><a href=""private.php?action=show&amp;privatemessageid=4798111"">Forum app beta expired</a>
			</td>
			<td class=""sender"">The Lord Bude</td>
			<td class=""date"">Apr  3, 2013 at 20:15</td>
			<td class=""check""><input type=""checkbox"" name=""privatemessage[4798111]"" value=""yes""></td>
		</tr>
		<tr>
			<td class=""status""><img src=""http://fi.somethingawful.com/images/pm.gif"" alt=""""></td>
			<td class=""icon"">&nbsp;</td>
			<td class=""title""><a href=""private.php?action=show&amp;privatemessageid=4786258"">Awful!! Beta for Windows Phone invite</a>
			</td>
			<td class=""sender"">NFX</td>
			<td class=""date"">Mar 26, 2013 at 14:52</td>
			<td class=""check""><input type=""checkbox"" name=""privatemessage[4786258]"" value=""yes""></td>
		</tr>
		<tr>
			<td class=""status""><img src=""http://fi.somethingawful.com/images/pm.gif"" alt=""""></td>
			<td class=""icon"">&nbsp;</td>
			<td class=""title""><a href=""private.php?action=show&amp;privatemessageid=4778908"">Re: Awful Reader Beta Access</a>
			</td>
			<td class=""sender"">H2SO4</td>
			<td class=""date"">Mar 20, 2013 at 21:50</td>
			<td class=""check""><input type=""checkbox"" name=""privatemessage[4778908]"" value=""yes""></td>
		</tr>
		<tr>
			<td class=""status""><img src=""http://fi.somethingawful.com/images/pmreplied.gif"" alt=""""></td>
			<td class=""icon"">&nbsp;</td>
			<td class=""title""><a href=""private.php?action=show&amp;privatemessageid=4776809"">Re: Awful Reader Beta Access</a>
			</td>
			<td class=""sender"">H2SO4</td>
			<td class=""date"">Mar 19, 2013 at 14:44</td>
			<td class=""check""><input type=""checkbox"" name=""privatemessage[4776809]"" value=""yes""></td>
		</tr>
		<tr>
			<td class=""status""><img src=""http://fi.somethingawful.com/images/pmreplied.gif"" alt=""""></td>
			<td class=""icon""><img src=""http://fi.somethingawful.com/forums/posticons/icons-08/request.png"" alt=""Request!"" border=""0""></td>
			<td class=""title""><a href=""private.php?action=show&amp;privatemessageid=4776540"">Awful Reader Beta Access</a>
			</td>
			<td class=""sender"">H2SO4</td>
			<td class=""date"">Mar 19, 2013 at 11:43</td>
			<td class=""check""><input type=""checkbox"" name=""privatemessage[4776540]"" value=""yes""></td>
		</tr>
		<tr>
			<td class=""status""><img src=""http://fi.somethingawful.com/images/pmreplied.gif"" alt=""""></td>
			<td class=""icon"">&nbsp;</td>
			<td class=""title""><a href=""private.php?action=show&amp;privatemessageid=4759493"">Screenshots of my stack trace</a>
			</td>
			<td class=""sender"">loquacius</td>
			<td class=""date"">Mar  7, 2013 at 18:43</td>
			<td class=""check""><input type=""checkbox"" name=""privatemessage[4759493]"" value=""yes""></td>
		</tr>
		<tr>
			<td class=""status""><img src=""http://fi.somethingawful.com/images/pm.gif"" alt=""""></td>
			<td class=""icon"">&nbsp;</td>
			<td class=""title""><a href=""private.php?action=show&amp;privatemessageid=4723172"">Re: Lumia 920</a>
			</td>
			<td class=""sender"">Carl Winslow</td>
			<td class=""date"">Feb 12, 2013 at 14:52</td>
			<td class=""check""><input type=""checkbox"" name=""privatemessage[4723172]"" value=""yes""></td>
		</tr>
		<tr>
			<td class=""status""><img src=""http://fi.somethingawful.com/images/pmreplied.gif"" alt=""""></td>
			<td class=""icon"">&nbsp;</td>
			<td class=""title""><a href=""private.php?action=show&amp;privatemessageid=4721932"">Re: Lumia 920</a>
			</td>
			<td class=""sender"">Carl Winslow</td>
			<td class=""date"">Feb 11, 2013 at 18:53</td>
			<td class=""check""><input type=""checkbox"" name=""privatemessage[4721932]"" value=""yes""></td>
		</tr>
		<tr>
			<td class=""status""><img src=""http://fi.somethingawful.com/images/pm.gif"" alt=""""></td>
			<td class=""icon"">&nbsp;</td>
			<td class=""title""><a href=""private.php?action=show&amp;privatemessageid=4721312"">Re: Lumia 920</a>
			</td>
			<td class=""sender"">Carl Winslow</td>
			<td class=""date"">Feb 11, 2013 at 12:11</td>
			<td class=""check""><input type=""checkbox"" name=""privatemessage[4721312]"" value=""yes""></td>
		</tr>
		<tr>
			<td class=""status""><img src=""http://fi.somethingawful.com/images/pm.gif"" alt=""""></td>
			<td class=""icon"">&nbsp;</td>
			<td class=""title""><a href=""private.php?action=show&amp;privatemessageid=4715805"">Re: Lumia 920</a>
			</td>
			<td class=""sender"">Carl Winslow</td>
			<td class=""date"">Feb  7, 2013 at 13:30</td>
			<td class=""check""><input type=""checkbox"" name=""privatemessage[4715805]"" value=""yes""></td>
		</tr>
		<tr>
			<td class=""status""><img src=""http://fi.somethingawful.com/images/pmreplied.gif"" alt=""""></td>
			<td class=""icon"">&nbsp;</td>
			<td class=""title""><a href=""private.php?action=show&amp;privatemessageid=4713084"">Re: Lumia 920</a>
			</td>
			<td class=""sender"">Carl Winslow</td>
			<td class=""date"">Feb  5, 2013 at 17:09</td>
			<td class=""check""><input type=""checkbox"" name=""privatemessage[4713084]"" value=""yes""></td>
		</tr>
		<tr>
			<td class=""status""><img src=""http://fi.somethingawful.com/images/pm.gif"" alt=""""></td>
			<td class=""icon"">&nbsp;</td>
			<td class=""title""><a href=""private.php?action=show&amp;privatemessageid=4708839"">Re: Lumia 920</a>
			</td>
			<td class=""sender"">Carl Winslow</td>
			<td class=""date"">Feb  2, 2013 at 13:17</td>
			<td class=""check""><input type=""checkbox"" name=""privatemessage[4708839]"" value=""yes""></td>
		</tr>
		<tr>
			<td class=""status""><img src=""http://fi.somethingawful.com/images/pmreplied.gif"" alt=""""></td>
			<td class=""icon"">&nbsp;</td>
			<td class=""title""><a href=""private.php?action=show&amp;privatemessageid=4705681"">Re: Lumia 920</a>
			</td>
			<td class=""sender"">Carl Winslow</td>
			<td class=""date"">Jan 31, 2013 at 11:47</td>
			<td class=""check""><input type=""checkbox"" name=""privatemessage[4705681]"" value=""yes""></td>
		</tr>
        </tbody>
		<tfoot>
			<tr>
				<td align=""right"" colspan=""7""><b>
					<input type=""hidden"" name=""action"" value=""dostuff"">
					<input type=""hidden"" name=""thisfolder"" value=""0"">
					Selected messages: <select name=""folderid""><option value=""0"">Inbox</option><option value=""4"" >awful! -- testing</option></select>
					<input type=""submit"" class=""bginput"" name=""move"" value=""Move"">
					
					<input type=""submit"" class=""bginput"" name=""delete"" value=""Delete"">
					</b>
				</td>
			</tr>
		</tfoot>
	</table>
</form>

<br>

<!-- message buttons -->
<div class=""msgbuttons"">
	<a href=""private.php?action=newmessage""><img src=""http://fi.somethingawful.com/images/pm/newmessage.gif"" alt=""Send a new private message""></a>
	
	
	<a href=""private.php?action=editfolders""><img src=""http://fi.somethingawful.com/images/pm/folders.gif"" alt=""Organize your private message folders""></a>
</div>

<br>


<form class=""forum_jump"" action=""forumdisplay.php"" method=""get"">
<input type=""hidden"" name=""s"" value="""">
<input type=""hidden"" name=""daysprune"" value="""">
<select name=""forumid"">
<option value=""-1"" selected>Jump to another forum:</option>
<option value=""-1"">--------------------</option>
<option value=""pm"" >Private Messages</option>
<option value=""cp"" >User Control Panel</option>
<option value=""search"" >Search Forums</option>
<option value=""home"" >Forums Home</option>
<option value=""lc"" >Leper's Colony</option>
<option value=""-1"">--------------------</option>
<option value=""48"" > Main</option><option value=""1"" >-- GBS 1.4</option><option value=""155"" >---- SA's Front Page Discussion</option><option value=""214"" >---- E/N Bullshit</option><option value=""26"" >-- FYAD: http://vimeo.com/86014703</option><option value=""154"" >---- A Beecock Forum.</option><option value=""268"" >-- BYOB 8.2</option><option value=""51"" > Discussion</option><option value=""44"" >-- Games</option><option value=""259"" >---- A Blizzard Subforum</option><option value=""146"" >------ WoW: Goon Squad</option><option value=""145"" >---- The MMO HMO</option><option value=""93"" >---- Private Game Servers</option><option value=""234"" >---- Dice &amp; Drama</option><option value=""103"" >------ The Goblin Ranch</option><option value=""191"" >---- Let's Play!</option><option value=""267"" >---- Dungeons &amp; Dreamcast Recreation Dome</option><option value=""192"" >-- Inspect Your Gadgets</option><option value=""158"" >-- Ask / Tell</option><option value=""162"" >---- Science, Academics and Languages</option><option value=""211"" >---- Tourism &amp; Travel</option><option value=""200"" >---- Business, Finance, and Careers</option><option value=""46"" >-- Debate Disco</option><option value=""22"" >-- Serious Hardware / Software Crap</option><option value=""170"" >---- Haus of Tech Support</option><option value=""202"" >---- The Cavern of COBOL</option><option value=""265"" >------ project.log</option><option value=""219"" >---- YOSPOS</option><option value=""122"" >-- Sports Argument Stadium* </option><option value=""181"" >---- The Football Funhouse</option><option value=""248"" >---- The Armchair Quarterback</option><option value=""175"" >---- The Ray Parlour</option><option value=""177"" >---- Punchsport Pagoda</option><option value=""179"" >-- You Look Like Shit</option><option value=""183"" >---- The Goon Doctor</option><option value=""244"" >---- The Fitness Log Cabin</option><option value=""242"" >-- Paranormal/Conspiracy Forum</option><option value=""161"" >-- Goons With Spoons</option><option value=""167"" >-- Post Your Favorite (or Request)</option><option value=""91"" >-- Automotive Insanity</option><option value=""236"" >---- Cycle Asylum</option><option value=""124"" >-- Pet Island</option><option value=""132"" >-- The Firing Range</option><option value=""90"" >-- The Crackhead Clubhouse</option><option value=""218"" >-- Goons in Platoons</option><option value=""152"" > The Finer Arts</option><option value=""31"" >-- Creative Convention</option><option value=""210"" >---- DIY &amp; Hobbies</option><option value=""247"" >---- The Dorkroom</option><option value=""151"" >-- Cinema Discusso</option><option value=""133"" >---- The Film Dump</option><option value=""182"" >-- The Book Barn</option><option value=""150"" >-- No Music Discussion</option><option value=""104"" >---- Musician's Lounge</option><option value=""130"" >-- The TV IV</option><option value=""144"" >-- Batman's Shameful Secret</option><option value=""27"" >-- ADTRW</option><option value=""215"" >-- Entertainment, Weakly</option><option value=""255"" >-- Rapidly Going Deaf</option><option value=""153"" > The Community</option><option value=""61"" >-- SA-Mart</option><option value=""77"" >---- Feedback &amp; Discussion</option><option value=""85"" >---- Coupons &amp; Deals</option><option value=""43"" >-- Goon Meets</option><option value=""241"" >-- LAN: Your City Sucks - Regional Discussion</option><option value=""188"" >-- Questions, Comments, Suggestions? - Read the stickies first!</option><option value=""49"" > Archives</option><option value=""21"" >-- Comedy Goldmine</option><option value=""264"" >---- Comedy Purgatory</option><option value=""115"" >---- FYAD: Criterion Collection</option><option value=""204"" >---- Helldump Success Stories</option><option value=""222"" >---- LF Goldmine</option><option value=""229"" >---- YCS Goldmine</option><option value=""25"" >-- Comedy Gas Chamber</option>
</select>
<input type=""submit"" value=""Go"">
</form>

<br>

<!-- icon key -->
<table>
<tr>
	<td rowspan=""3"" width=""50%"">&nbsp;</td>
	<td colspan=""6"" align=""center"">
		<b>Message quota for all folders: 500</b>
	</td>
	<td rowspan=""3"" width=""50%"">&nbsp;</td></tr>
</tr>
<tr>
	<td nowrap><img src=""http://fi.somethingawful.com/images/newpm.gif"" alt=""Unread Message""></td>
	<td nowrap><b>Unread Message</b></td>
	<td nowrap><img src=""http://fi.somethingawful.com/images/pm.gif"" border=0 alt=""Message""></td>
	<td nowrap><b>Message</b></td>
	<td nowrap><img src=""http://fi.somethingawful.com/images/trashcan.gif"" alt=""Cancelled Message""></td>
	<td nowrap><b>Cancelled Message</b></td>
<tr>
	<td nowrap><img src=""http://fi.somethingawful.com/images/pmreplied.gif"" alt=""Replied to Message""></td>
	<td nowrap><b>Replied to Message</b></td>
	<td nowrap><img src=""http://fi.somethingawful.com/images/pmforwarded.gif"" alt=""Forwarded Message""></td>
	<td nowrap colspan=""3""><b>Forwarded Message</b></td>
</tr>
</table>
<!-- icon key -->

</div><!-- #content -->
	<ul class=""navigation"">
<li class=""first""><a href=""/index.php"">SA Forums</a></li>
<li>- <a href=""http://www.somethingawful.com/"">Something Awful</a></li>
<li>- <a href=""/f/search"">Search the Forums</a></li>
<li>- <a href=""/usercp.php"">User Control Panel</a></li>
<li>- <a href=""/private.php"">Private Messages</a></li>
<li>- <a href=""http://www.somethingawful.com/d/forum-rules/forum-rules.php"">Forum Rules</a></li>
<li>- <a href=""/dictionary.php"">SAclopedia</a></li>
<li>- <a href=""/stats.php"">Posting Gloryhole</a></li>
<li>- <a href=""/banlist.php"">Leper's Colony</a></li>
<li>- <a href=""/supportmail.php"">Support</a></li>
<li>- <a href=""/account.php?action=logout&amp;ma=10293618"">Log Out</a></li>

</ul>
	<div id=""copyright"">
		Powered by: vBulletin Version 2.2.9 (<a href=""/CHANGES"">SAVB-v2.1.17</a>)<br>
		Copyright &copy;2000, 2001, Jelsoft Enterprises Limited.<br>
		Copyright &copy;2012, Something Awful LLC<br>
	</div>

</div><!-- #container -->

<script type=""text/javascript"">
	// quantcast
	_qoptions = { qacct:""p-82vTvmw-enlng"" };

	try {
		if(document.location.hostname != 'forums.somethingawful.com')
			throw undefined;

		$(document).ready(function() {
			var qcUrl = 'http://edge.quantserve.com/quant.js';
			jQuery.getScript(qcUrl);

			var gaJsHost = ((""https:"" == document.location.protocol) ? ""https://ssl."" : ""http://www."");
			var gaUrl = gaJsHost + 'google-analytics.com/ga.js';
			jQuery.getScript(gaUrl, function() {
				var pageTracker = _gat._getTracker(""UA-3064978-2"");
				pageTracker._initData();
				pageTracker._trackPageview();
			});
		});
	} catch(e) {};

	// indie
	// try {
	// 	if(document.location.hostname != 'forums.somethingawful.com')
	// 		throw undefined;

	// 	$(document).ready(function() {
	// 		var ic_element = document.createElement('script');
	// 		ic_element.type = 'text/javascript';
	// 		ic_element.async = true;
	// 		ic_element.id = 'ic_annonymous_pixel';
	// 		ic_element.src = 'http://pixel.indieclick.com/annonymous/domain/somethingawful.com/reach/script_ic.js';
	// 		var ic_script = document.getElementsByTagName('script')[0];
	// 		ic_script.parentNode.insertBefore(ic_element, ic_script);
	// 	});
	// } catch(e) {};
</script>
<noscript><img src=""http://pixel.quantserve.com/pixel/p-82vTvmw-enlng.gif"" style=""display:none;"" border=""0"" height=""1"" width=""1"" alt=""Quantcast""></noscript>

<!-- PLEASE DO NOT REMOVE -->
<ol id=""debug"" style=""display:none""><li>&nbsp;</ol>

</body>
</html>";
        }

        #endregion
    }
}
