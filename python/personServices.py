#!/usr/bin/python
__author__ = 'marcelo'

from flask import Flask, jsonify, abort, make_response
from flask.ext.restful import Api, Resource, reqparse, fields, marshal, request

app = Flask(__name__, static_url_path="")
app.config['APPLICATION_ROOT'] = "/testAPI"

api = Api(app)

accounts = []


def getAccount(id):
    acct = [acct for acct in accounts if acct['id'] == id]
    if len(acct) == 0:
        abort(404)
    return acct[0]


bookmark_fields = {
    'url': fields.String,
    'description': fields.String
}
person_fields = {
    'id':fields.Integer,
    'name': fields.String,
    'age': fields.Integer,
    'bookmarks': fields.List(fields.Nested(bookmark_fields))
}


class AccountListAPI(Resource):
    def __init__(self):
        self.reqparse = reqparse.RequestParser()
        self.reqparse.add_argument('name', type=str, required=True, help='No Name provided', location='json')
        self.reqparse.add_argument('age', type=int, default="", location='json')
        self.reqparse.add_argument('bookmarks', type=list, location='json')
        super(AccountListAPI, self).__init__()

    def get(self):
        name = request.args.get('name')
        if name is not None:
            return {'accounts': [marshal(acct, person_fields) for acct in accounts if acct['name'].find(name) >= 0]}
        return {'accounts': [marshal(acct, person_fields) for acct in accounts]}


    def post(self):
        args = self.reqparse.parse_args()
        print args
        id = len(accounts)
        acct = {
            'id': id + 1,
            'name': args['name'],
            'age': args['age']
        }
        accounts.append(acct)
        return {'account': marshal(acct, person_fields)}, 201


class AccountAPI(Resource):
    def __init__(self):
        self.reqparse = reqparse.RequestParser()
        self.reqparse.add_argument('name', type=str, location='json')
        self.reqparse.add_argument('age', type=int, location='json')
        self.reqparse.add_argument('bookmarks', type=bookmark_fields, location='json')
        super(AccountAPI, self).__init__()

    def get(self, id):
        acct = getAccount(id)
        return {'account': marshal(acct, person_fields)}

    def put(self, id):
        acct = getAccount(id)
        args = self.reqparse.parse_args()
        for k, v in args.items():
            if v is not None:
                acct[k] = v
        return {'account': marshal(acct, person_fields)}

    def delete(self, id):
        acct = getAccount(id)
        accounts.remove(acct)
        return {'result': True}


class BookmarkPI(Resource):

    def __init__(self):
        self.reqparse = reqparse.RequestParser()
        self.reqparse.add_argument('url', type=str, required=True, location='json')
        self.reqparse.add_argument('description', type=int, location='json')
        super(BookmarkPI, self).__init__()

    def get(self, id):
        acct = getAccount(id)
        # acct = [acct for acct in accounts if acct['id'] == id]
        if len(acct) == 0 or not acct.has_key('bookmarks'):
            abort(404)
        return {'bookmark': marshal(acct['bookmarks'], bookmark_fields)}

    def post(self, id):
        acct = getAccount(id)
        args = self.reqparse.parse_args()
        bm = {
            'url': args['url'],
            'description': args['description']
        }
        if acct.has_key('bookmarks'):
            acct['bookmarks'].append(bm)
        else:
            acct['bookmarks'] = [bm]

        return {'bookmark': marshal(acct, person_fields)}, 201

    def put(self, id):
        acct = getAccount(id)
        args = self.reqparse.parse_args()
        for k, v in args.items():
            if v is not None:
                acct['bookmarks'][k] = v
        return {'account': marshal(acct, person_fields)}

    def delete(self, id):
        acct = getAccount(id)
        accounts.remove(acct)
        return {'result': True}

api.add_resource(AccountListAPI, '/account', endpoint='accounts')
api.add_resource(AccountAPI, '/account/<int:id>', endpoint='account')
api.add_resource(BookmarkPI, '/account/<int:id>/bookmark', endpoint='bookmark')


if __name__ == '__main__':
    # app.run(host='127.0.0.1', port=8080, debug=True)

    # Relevant documents:
    # http://werkzeug.pocoo.org/docs/middlewares/
    # http://flask.pocoo.org/docs/patterns/appdispatch/
    from werkzeug.serving import run_simple
    from werkzeug.wsgi import DispatcherMiddleware
    app.config['DEBUG'] = True
    # Load a dummy app at the root URL to give 404 errors.
    # Serve app at APPLICATION_ROOT for localhost development.
    application = DispatcherMiddleware(Flask('dummy_app'), {
        app.config['APPLICATION_ROOT']: app,
    })

    run_simple('localhost', 8080, application, use_reloader=True)


