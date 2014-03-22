var WebViewJS;
(function() {
    "use strict";

    // our root view model
    var webViewModel = {
        value: ko.observable("fart"),
        displayArticle: ko.observable(false),
        displayThread: ko.observable(false),

        displayMessage: ko.observable(false),
        displayPlaceholder : ko.observable(true),
        article: ko.observable(''),

        thread: ko.observable(''),
        message: ko.observable(''),
        showSeparators: ko.observable(false),

        theme: ko.observable(''),
        accent: ko.observable(''),
        onMessageRendered: onMessageRendered,

        isLoading: ko.observable(false)
    };

    // our public interface
    WebViewJS = {
        viewModel: webViewModel,
        setValue: setValue,
        viewArticle: viewArticle,

        disableScroll: disableScrolling,
        enableScroll: enableScrolling,
        viewMessage: viewMessage,

        viewThreadPage: viewThreadPage,
        threadScrollToTop: scrollToTopPost,
        threadScrollToBottom: scrollToBottomPost,

        threadScrollToUnread: scrollToFirstUnreadPost,
        threadScrollToPost: scrollToPost,
        showLoadingRing: showLoadingRing,

        hideLoadingRing: hideLoadingRing,
        startSammyJS: sammyJSInit,
        echo: sendEcho,

        isPhoneModeEnabled: false,
        loadUrl: loadUrl,
        onReady: onReady
    };

    // Creates a thread post view model.
    function ThreadPost(post, thread) {
        var self = this;

        // Statics
        self.postId = post.PostID;                             // post id
        self.threadId = post.ThreadID;                         // post thread id
        self.author = post.Author;                             // post author

        self.date = ko.observable(post.PostDate);              // post data
        self.pageIndex = post.PageIndex;                       // index relative to other posts on page
        self.threadIndex = post.ThreadIndex;                   // index relative to other posts in thread. used for bookmarking posts.

        self.isEditable = post.IsEditable;                     // flags the post as editable (meaning this is the current user's post).
        self.content = ko.observable(post.PostBody);           // post content; contains unsanitized html.
        self.avatar = ko.observable(post.PostIconUri);
        self.thread = thread;
        self.isIgnored = ko.observable(post.IsIgnored);

        // post options
        self.options = ko.observableArray([
            {
                caption: 'quote',
                icon: 'img/quote.png',
                href: '#/quote/' + self.postId,
            },
            {
                caption: 'mark',
                icon: 'img/mark.png',
                href: '#/mark/' + self.threadId + '/' + self.threadIndex
            }
        ]);

        self.isNew = ko.observable(post.IsNew);                 // flags the post as unread if true.
        self.formattedDate = ko.computed(function () {
            return formatDate(self.date());
        });
        self.pageIndexLabel = ko.computed(function () {
            return "#" + self.pageIndex;
        });
        self.id = ko.computed(function () {
            var value = "post" + self.postId;
            return value;
        });
        self.showAvatar = ko.computed(function () {
            if (self.avatar() == null)
                return false;

            return true && thread.showPostAvatars();
        });
        self.status = ko.computed(function () {
            var value = self.isNew();
            return value == true ? "" : "read";
        });

        // Operations

        self.addOptions = function () {
            if (self.isEditable)
                self.options.push({
                    caption: 'edit',
                    icon: 'img/edit.png',
                    href: '#/edit/' + self.postId
                });
        };

        self.addOptions();
    }

    // Creates a thread page view model.
    function ThreadPage(thread) {
        var self = this;

        self.title = ko.observable(thread.ThreadTitle);
        self.currentPage = ko.observable(thread.PageNumber);
        self.lastPage = ko.observable(thread.LastPage);

        self.forum = ko.observable(thread.ParentForum);
        self.posts = ko.observableArray([]);
        self.threadId = ko.observable(thread.ThreadID);

        self.footer = ko.observable('');
        self.postAddCount = 0;
        self.totalPosts = thread.Posts.length;

        self.showPostAvatars = ko.observable(true);

        self.throttledPosts = ko.computed(function () {
            return self.posts();
        }).extend({ throttle: 10 });

        self.description = ko.computed(function () {
            return self.forum();
        });
        
        self.subtitle = ko.computed(function () {
            var length = self.posts().length;
            var postText = "";
            if (length > 0) {
                postText = length == 1 ? " post" : " posts";
                postText = length + postText;
            }
            var pageValue = self.currentPage() == 0 ? "?" : self.currentPage();
            var pageText = "page " + pageValue;
            return pageText + ", " + postText;
        }).extend({ throttle: 100 });

        self.isLastPage = ko.computed(function () {
            return self.currentPage() == self.lastPage();
        });

        self.isFirstPage = ko.computed(function () {
            return self.currentPage() == 1;
        });

        // Invoked after a post element is added to the DOM.
        self.onPostAdd = function (element) {
            // mobilize our markup, basically.
            attachSpoilerEvent(element);
            fixLongLinks(element);
            quoteLinkFix(element);
            youTubeFix(element);
            attachImageEvents(element);

            self.postAddCount++;

            // when all posts are added...
            if (self.postAddCount == self.totalPosts) {
                // ...attach event handling for ignored posts.
                attachIgnoredPostEvent();
                // ...remap anchor navigation.
                mapNavigation();
                // ...and scroll to first unread post (the delay is here to ensure everything has been rendered)
                var delay = setTimeout(function () {
                    scrollToFirstUnreadPost();
                    clearTimeout(delay);
                }, 50);
            }
        };

        thread.Posts.forEach(function (item) {
            var post = new ThreadPost(item, self);
            self.posts.push(post);
        });

        if (self.isLastPage()) { self.footer("end of thread."); }
        else { self.footer("continue to next page"); }
    }

    // Invoked when DOM element for private message is rendered.
    function onMessageRendered(element) {
        attachSpoilerEvent(element);
        fixLongLinks(element);
        youTubeFix(element);
        attachImageEvents(element);
    }

    // Called when webview is ready for display
    function onReady() {
        sammyJSInit();
        //WebViewJS.echo("knockout loaded.");
        //WebViewJS.viewModel.value("knockout loaded.");
    }

    // Formats a JavaScript date object, with padded zeros where applicable.
    function formatDate(value) {
        var MyDate = new Date(value);
        var MyDateString;

        MyDateString = ('0' + (MyDate.getMonth() + 1)).slice(-2) + '/'
                        + ('0' + MyDate.getDate()).slice(-2) + '/'
                        + MyDate.getFullYear() + ' '
                        + ('0' + MyDate.getHours()).slice(-2) + ":"
                        + ('0' + MyDate.getMinutes()).slice(-2);

        return MyDateString;
    }

    function showLoadingRing() {
        window.external.notify("showLoading");
        return "OK";
    }

    function hideLoadingRing() {
        window.external.notify("hideLoading");
        return "OK";
    }

    function sendEcho(message) {
        nativeExec("echo", { value: message });
    }

    function nativeExec(endpoint, json) {
        var args = {};
        args.endpoint = endpoint;
        args.json = json;
        window.external.notify(JSON.stringify(args));
    }

    function onThreadPageLinked(href) {
        var endpoint = "thread";
        var json = { args: 2, type: "url", url: href };
        nativeExec(endpoint, json);
    }

    function loadThreadWithThreadId(id) {
        var endpoint = "thread";
        var json = { args: 1, threadId: id };
        nativeExec(endpoint, json);
    }

    function loadThreadFirstPage(id) {
        var endpoint = "thread";
        var json = { args: 2, threadId: id, type: "first" };
        nativeExec(endpoint, json);
    }

    function loadThreadLastPage(id) {
        var endpoint = "thread";
        var json = { args: 2, threadId: id, type: "last" };
        nativeExec(endpoint, json);
    }

    function loadThreadPage(id, pageNum) {
        var endpoint = "thread";
        var json = { args: 3, threadId: id, type: "page", page: pageNum };
        nativeExec(endpoint, json);
    }

    function loadThreadPageIndex(id, pageNum, postIndex) {
        var endpoint = "thread";
        var json = { args: 4, threadId: id, type: "page", page: pageNum, index: postIndex };
        nativeExec(endpoint, json);
    }

    function markPageAsRead(id, threadIndex) {
        var endpoint = "mark";
        var json = { threadId: id, postThreadIndex: threadIndex };
        nativeExec(endpoint, json);
    }

    function quotePost(id) {
        //sendEcho("quoting a post...");
        var endpoint = "quote";
        var json = { postId: id };
        nativeExec(endpoint, json);
    }

    function editPost(id) {
        var endpoint = "edit";
        var json = { postId: id };
        nativeExec(endpoint, json);
    }

    function sammyJSInit() {
        // Use Sammy.js for client-side routing
        Sammy(function () {
            // url state after rest request completes; do nothing.
            this.get('#/ready', function () { });

            // scroll to post with id, or load new page with post id
            this.get('#/anchor/:id', function () {
                var paramid = this.params.id;
                var success = scrollToPost(paramid);
                if (success == false) {
                    //sendEcho("post id not found on current page.");
                    // find link with target id
                    $("a.quote_link").each(function () {
                        if ($(this).data("info").id == paramid) {
                            // notify app with request
                            //sendEcho("target search found. sending url to app...");
                            var url = $(this).data("info").url;
                            onThreadPageLinked(url);
                        }
                    });
                }
                window.location.hash = '/ready';
            });

            // load the thread with thread id, page with the newest post (if any)
            this.get('#/thread/:threadid', function () {
                var query = this.params;
                loadThreadWithThreadId(query.threadid);
                window.location.hash = '/ready';
            });

            // load the first page of thread with thread id, first unread post (if any)
            this.get('#/thread/:threadid/first', function () {
                var query = this.params;
                loadThreadFirstPage(query.threadid);
                window.location.hash = '/ready';
            });

            // load the last page of thread with thread id, first unread post (if any)
            this.get('#/thread/:threadid/last', function () {
                var query = this.params;
                loadThreadLastPage(query.threadid);
                window.location.hash = '/ready';
            });

            // load the thread with thread id, specified page number, first unread post (if any)
            this.get('#/thread/:threadid/:page', function () {
                var query = this.params;
                loadThreadPage(query.threadid, query.page);
                window.location.hash = '/ready';
            });

            // load the thread with thread id, specified page number, specified post index
            this.get('#/thread/:threadid/:page/:index', function () {
                var query = this.params;
                loadThreadPageIndex(query.threadid, query.page, query.index);
                window.location.hash = '/ready';
            });

            // mark a post as read
            this.get('#/mark/:threadid/:postThreadIndex', function (context) {
                markPageAsRead(this.params.threadid,
                    this.params.postThreadIndex);

                window.location.hash = '/ready';
            });

            // quote a post
            this.get('#/quote/:postid', function () {
                quotePost(this.params.postid);
                window.location.hash = '/ready';
            });

            // edit a post
            this.get('#/edit/:postid', function () {
                editPost(this.params.postid);
                window.location.hash = '/ready';
            });

            // catch any unknown routes
            this.get(/.*/, function () {
                //sendEcho("unknown route: " + location.href + " path: " + location.pathname);
                console.log("unknown route: " + location.href);
                console.log("pathname: " + location.pathname);
            });
        }).run();
    }

    function request(hash) {
            //sendEcho("hash: " + hash + ", current: " + window.location.toString());
            window.location.hash = hash.substr(1);
            //window.location.replace("/webview/webview.html" + hash);
        
            //var href = location.protocol + '//' + location.pathname + '#' + hash;
            //window.location.replace(href);
    }

    // Generates a random number up to max, inclusive.
    function randomNumber(max) {
        Math.floor(Math.random() * (max + 1));
    }

    function mapNavigation() {
        // grab all links on page
        $("a").on("click", function (event) {

            //sendEcho("mapping navigation...");

            // disable normal behavior
            event.preventDefault();

            // grab href
            var href = $(this).attr("href");
            console.log("link clicked: '" + href + "'");

            // all internal hrefs begin with #.
            if (href.indexOf("#") == 0) {
                request(href);
            }

            // link of unknown orgin; open a webbrowser task
            else {
                loadUrl(href);
            }
        });
    }

    function loadUrl(href) {
        //sendEcho(href);

        // all links to thread pages come from showthread.php
        if (href.indexOf("showthread.php") != -1) {
            onThreadPageLinked(href);
        }
        else {
            nativeExec("url", { url: href });
        }
    }

    function unignorePost(postid, href) {
        //sendEcho("requesting ignored post: #" + postid);
        nativeExec("unignore", { id: postid, url: href });
    }

    function scrollToFirstUnreadPost(then) {
        var id = $("#threadView article").not(".seen").first().attr("id");
        if (scrollToPost(id, then, 0)) {
            console.log("unread post found.");
        }
        else {
            console.log("all posts...read? scrolling to top.");
            scrollToBottomPost(then, 0);
        }
    }

    function scrollToTopPost(then, duration, offset) {
        var first = $('#threadView article').first();
        var id = first.attr('id');
        scrollToPost(id, then, duration, offset);
    }

    function scrollToBottomPost(then, duration, offset) {
        var last = $('#threadView article').last();
        var id = last.attr('id');
        scrollToPost(id, then, duration, offset);
    }

    function scrollToIndex(index, then, duration) {
        // if then predicate is not supplied, supply a function that does nothing.
        var func = arguments.length > 1 ? then : function () { };
        var animationduration = arguments.length == 3 ? duration : 400;

        if (WebViewJS.isPhoneModeEnabled) {
            var current = $('html').scrollTop();
            $('html, body').animate({ scrollTop: index }, animationduration, func);
        }
        else {
            var anchor = $('#anchor');
            var current = anchor.scrollTop();
            anchor.scrollTo(0, duration, { axis: "y" });
        }
    }

    function scrollToPost(postid, then, duration, offsetValue) {
        if (postid == null)
            return false;

        var func = arguments.length > 1 ? then : function () { };
        var animationDuration = arguments.length > 2 ? duration : 400;
        var localOffset = offsetValue ? offsetValue : -48;
        
        var element = document.getElementById(postid);
        if (element != null) {
            console.log("scrolling to " + postid + "...");
            
            if (WebViewJS.isPhoneModeEnabled) {
                var before = $("html").scrollTop();
                var offset = $('#' + postid).offset().top;
                //sendEcho(JSON.stringify({ before: before, postoffset: offset }));
                $("html, body").animate({ scrollTop: offset + localOffset }, animationDuration);
            }
            else {
                var anchor = $('#anchor');
                var currentPosition = anchor.scrollTop();
                var elementPosition = $('#' + postid).offset().top;
                // add a bit of padding
                var position = currentPosition + elementPosition + localOffset;

                try {
                    console.log("uncomment the items below for debugging.");
                    //sendEcho("argument length: " + arguments.length);
                    //sendEcho("localOffset: " + localOffset);
                    //sendEcho(JSON.stringify({ cp: currentPosition, ep: elementPosition, p: position }));
                }
                catch (err) { sendEcho(err); }

                anchor.scrollTo(position, animationDuration, { axis: "y" });
            }

            if (undefined != then) { then(); }
            return true;
        }

        sendEcho("scroll to post failed.");
        console.log("scroll to post failed.");
        if (undefined != then) { then(); }
        return false;
    }

    function attachPostOptionsEvent(element) {
        $("a.postoption", element).each(function () {
            $(this).on("click", function (event) {
                console.log("activating post option...");
                event.preventDefault();
                var href = $(this).attr("href");
                request(href);
            });
        });
    }

    function attachSpoilerEvent(element) {
        $(".bbc-spoiler", element).each(function () {
            console.log("spoiler found.");
            var spoiler = $(this).html();
            $(this).html("<a class='bbc-spoiler accent' href='#/ready'>[spoiler]</a>");
            $(this).on("click", function (e) {
                console.log("You clicked a spoiler!");
                $(this).off('click');
                $(this).html(spoiler);
            });
        });
    }

    function attachIgnoredPostEvent() {
        var invoke = function (element) {
            $(element)
                .find("a:first")                        // find the first anchor within the element
                .one("click", function (event) {        // attach 'onclick' event that fires once
                    event.preventDefault();             // prevent normal hyperlink click behavior
                    event.stopImmediatePropagation();   // prevent other handlers from firing
                    var post = ko.dataFor(this);        // grab the context binded to this anchor
                    var href = $(this).attr('href');    // grab the anchor's href
                    unignorePost(post.postId, href);    // send post's id and the href to app for processing
                    
                });
        }

        $('article').each(function () {                     // for each article in the DOM
            if ($(this).hasClass("ignored")) {              // invoke the above function for those with class 'ignored'
                invoke(this);
            }
        });   
    }

    // Adds the accent class to elements in the DOM. Used for css styling.
    function addAccentClass(element) {
        var style = "style: { color: 'green' }";

        // add data-binding to anchors
        $('a', element).each(function () {
            $(this)[0].setAttribute("style", "color: 'green'");
        });
    }

    function fixLongLinks(element) {
        $("a:contains('...')", element).each(function () {
            console.log("long link found. wrapping...");
            var link = $(this).html();
            $(this).html("<div class='long-link'>" + link + "</div>");
        });
    }

    function youTubeFix(element) {
        $("iframe.youtube-player", element).each(function () {
            $(this).removeAttr("height");
            $(this).removeAttr("width");
        });
    }

    function quoteLinkFix(element) {
        $("a.quote_link", element).each(function () {
            var href = $(this).attr("href");
            var postid = href.split("#")[1];
            $(this).attr("href", "#/anchor/" + postid);
            $(this).data("info", { id: postid, url: href });
            console.log($(this).data("info"));
        });
    }

    function notifyImageClick(image) {
        var src = image.attr("src");
        if (src.indexOf("img/image-loading.png") !== -1) {
            image.trigger("unveil");
        } else {
            nativeExec("image", { source: src });
        }
    }

    function fixPrefixAndAddLink(image) {
        var src = image.attr("src");
        if (src.indexOf("attachment.php?") !== -1 &&
            src.indexOf("http://forums.somethingawful.com") === 1) {
            src = "http://forums.somethingawful.com/" + src;
            image.attr("src", src);
        }

        image.after("<div class='long-link'><a href='" +
            src + "'>" + src + "</a></div");
    }

    function lazyLoadImage(image) {
        try {
            image.addClass("unveil-img");
            var src = image.attr("src");
            image.attr("data-src", src);
            image.attr("src", "img/image-loading.png");
        } catch (err) { sendEcho(err); }
    }

    function attachImageEvents(element) {
        $(".article-content img", element).each(function () {
            var src = $(this).attr("src");
            if ((src.indexOf("smilies") != -1) || (src.indexOf("emoticons") != -1)) { 
                //sendEcho("smiley detected, skipping...");
                $(this).addClass("smiley");

            } else {
                $(this).attr("onerror", "imageError(this)");
                //sendEcho("attaching image click...");
                $(this).on("click", function () { notifyImageClick($(this)); });
                //sendEcho("attaching prefix fix...");
                fixPrefixAndAddLink($(this));
                //sendEcho("attaching lazy load image...");
                if (WebViewJS.isPhoneModeEnabled)
                    lazyLoadImage($(this));
            }
        });
    }

    function attachUnveilPlugin() {
        $(".unveil-img").unveil(200, function () {
            $(this).load(function () {
                console.log("unveiling image.");
                this.style.opacity = 1;
            });
        });
    }

    function disableScrolling() {
        $("body").bind("touchmove", function (e) { e.preventDefault(); });
    }

    function enableScrolling() {
        $("body").unbind("touchmove");
    }

    // prevent default events
    function preventDefault(e) {
        e = e || window.event;
        if (e.preventDefault)
            e.preventDefault();
        e.returnValue = false;
    }

    // error handler for images that fail to display.
    function imageError(image) {
        image.onerror = "";
        image.src = "img/image-loading.png";
    }

    function setValue(val) {
        webViewModel.value(val);
    }

    function viewArticle(json) {
        // clear display
        hideView();

        var article = JSON.parse(json);
        var model = {
            title: article.Title,
            subtitle: article.Subtitle,
            description: article.Description,
            content: article.Content
        };

        webViewModel.article(model);
        webViewModel.displayArticle(true);
        webViewModel.value("article loaded.");
        scrollToIndex(0, function () { }, 0);
        return "OK: " + JSON.stringify(model);
    }

    function viewMessage(json) {
        // clear display
        hideView();

        var message = JSON.parse(json);
        var model = {
            title: message.Subject,
            subtitle: message.PostDate,
            description: message.From,
            content: message.RawHtml
        };

        webViewModel.message(model);
        webViewModel.displayMessage(true);
        attachUnveilPlugin();
        webViewModel.value("message loaded.");
        scrollToIndex(0, function () { }, 0);
        return "OK: " + JSON.stringify(model);
    }

    function viewThreadPage(json) {
        hideView();

        var page = JSON.parse(json);
        var model = new ThreadPage(page);
        webViewModel.thread(model);
        hideLoadingRing();
        webViewModel.displayThread(true);
        attachUnveilPlugin();
        return "OK";
    }

    function hideView() {
        webViewModel.displayArticle(false);
        webViewModel.displayThread(false);
        webViewModel.displayMessage(false);
        webViewModel.displayPlaceholder(false);
        return "OK";
    }
})();