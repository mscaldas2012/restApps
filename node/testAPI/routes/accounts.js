
var allAccounts = [];
var idCounter= 1;


exports.findAllAccounts = function(req, res, next) {
    res.setHeader('Access-Control-Allow-Origin', '*');
    if (req.params.name) {
        var accts  = allAccounts.filter(function(item) {
            return (item.name == req.params.name);
        });
        res.send(200, accts) ;

    } else {}
        res.send(200, allAccounts);
}

exports.createNewAccount = function (req, res, next) {
    if (!req.body.name) {
        var error = { };
        error.message = "Content is Missing property name";
        error.code = "REQ_FIELD_NAME";

        res.send(400, error);
    }
    var bacct = req.body;
    bacct.id = idCounter++;

    allAccounts.push(bacct);

    res.setHeader('Access-Control-Allow-Origin', '*');
    res.send(201, bacct);
}



exports.findAccount = function (req, res, next) {
  var acct = findAccount(req.params.id);
  res.setHeader('Access-Control-Allow-Origin', '*');
  if (acct) {
     res.send(200, acct[0]);
  } else {
     res.send(404);
  }
}


exports.updateAccount = function (req, res, next) {
  var acct  = findAccount(req.params.id)
  if (acct) {
      acct.name = req.body.name;
      acct.age = req.body.age;

      res.setHeader('Access-Control-Allow-Origin', '*');
      res.send(200, acct);
  } else {
     res.send(404);
  }
}

exports.deleteAccount = function (req, res, next) {
    var initialSize = allAccounts.length;
    allAccounts  = allAccounts.filter(function(item) {
        return (item.id != req.params.id);
    });
    if (allAccounts.length == initialSize-1) {
        res.setHeader('Access-Control-Allow-Origin', '*');
        res.send(200);
    } else {
         res.send(404);
    }
}

exports.findAllBookmarks = function (req, res, next) {
    var acct = findAccount(req.params.userId);
    res.setHeader('Access-Control-Allow-Origin', '*');
    if (acct) {
         res.send(200, acct.bookmarks);
    } else {
         res.send(404);
    }
}

exports.findABookmark = function (req, res, next) {
    var bm= findBookmark(req.params.userId, req.params.bookmarkId);
    res.setHeader('Access-Control-Allow-Origin', '*');
    if (bm) {
        res.send(200, bm);
    } else {
        res.send(404);
    }

}

exports.createNewBookmark = function(req, res, next) {
    var acct= findAccount(req.params.userId);
    if (acct) {
       var newBm = req.body;
        newBm.id = Date.now();
        if (!acct.bookmarks) {
            acct.bookmarks = [];
        }
        acct.bookmarks.push(newBm);
        res.send(201, newBm);
    } else {
        res.send(404);
    }
}

exports.updateBookmark = function(req, res, next) {
   var bookmark = findBookmark(req.params.userId, req.params.bookmarkId);
   if (bookmark) {
     bookmark.url = req.body.url;
     bookmark.description = req.body.description;
     res.send(200, bookmark);
   } else {
        res.send(404);
   }
}

exports.deleteBookmark = function(req, res, next) {
   var acct = findAccount(req.params.userId);
   var initialSize = 0;
   var allBookmarks = [];
   if (acct.bookmarks) {
        initialSize = acct.bookmarks.length;
        allBookmarks  = acct.bookmarks.filter(function(item) {
           return (item.id != req.params.bookmarkId);
        });
   }
   if ((initialSize > 0) || (allBookmarks.length == initialSize-1)) {
       acct.bookmarks = allBookmarks;
       res.setHeader('Access-Control-Allow-Origin', '*');
       res.send(200);
   } else {
        res.send(404);
   }
}

function findBookmark(userId, bId) {
    var acct= findAccount(userId);
    if (acct && acct.bookmarks) {
        var bookmark = acct.bookmarks.filter(function(item) {
            return (item.id == bId);
        })
        return bookmark[0];
    }
}

function findAccount(id) {
    var acct  = allAccounts.filter(function(item) {
        return (item.id == id);
    });
    return acct[0] ;
}