//info about restify: http://mcavage.me/node-restify/#creating-a-server
var restify = require('restify');

var accounts = require('./routes/accounts');

var ip_addr = 'localhost';
var port = 8080;


var server = restify.createServer({
  name: "testing API in Node JS"
});

server.use(restify.queryParser());
server.use(restify.bodyParser());
server.use(restify.CORS());

var ROOT = '/testAPI';
var VERSION = '1.0.0';

server.get(  {path: ROOT + '/account',     version: VERSION}, accounts.findAllAccounts);
server.get(  {path: ROOT + '/account/:id', version: VERSION}, accounts.findAccount);
server.post( {path: ROOT + '/account',     version: VERSION}, accounts.createNewAccount);
server.put(  {path: ROOT + '/account/:id', version: VERSION}, accounts.updateAccount);
server.del(  {path: ROOT + '/account/:id', version: VERSION}, accounts.deleteAccount);

server.get(  {path: ROOT + '/account/:userId/bookmark',             version: VERSION}, accounts.findAllBookmarks)
server.get(  {path: ROOT + '/account/:userId/bookmark/:bookmarkId', version: VERSION}, accounts.findABookmark);
server.post( {path: ROOT + '/account/:userId/bookmark',             version: VERSION}, accounts.createNewBookmark);
server.put(  {path: ROOT + '/account/:userId/bookmark/:bookmarkId', version: VERSION}, accounts.updateBookmark);
server.del(  {path: ROOT + '/account/:userId/bookmark/:bookmarkId', version: VERSION}, accounts.deleteBookmark);

server.listen(port, ip_addr, function() {
	console.log('%s listening at %s', server.name, server.url);
});

