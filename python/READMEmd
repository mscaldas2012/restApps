<h2>Python implementation.</h2>

<h2>Configuration</h2>
Python 2.7
Mac OS X (10.10.2)
IntelliJ IDEA 14
Flask (with rest extension)

<h2>Setup</h2>
I'm using Flask (http://flask.pocoo.org) with the rest extension.

Some of the pros is that JSON feels very native to python; a single file provides me with all the functionality and very simple to implement.

I installed flask with: <code>pip install Flask</code> 
then the rest extension: <code>pip install flask-restful</code>
//You might need to use sudo for these commands


<h2>Implementation</h2>
I'm very novice n python, so there are probably many ways of doing this better.
But even though not being an expert on the language, I was able to pull this out in a day or so.

I was hoping for a more straight forward implementation like java or c#, where I can annotate the methods with my routes.
On this example, I had to use specific method names - get, post, etc - and I had to create multiple classes for the same service - AccountAPI and AccountListAPI because of the different routing - one has an {id}, the other doesn't.
Also, having to map the JSON properties for parsing was a little more than I expected.

The results are also a litle different from the Java implementation. The way is configured now, t's adding a master container - "accounts": {...} to the JSON response. I have not found a way of removing this. At the same time, not sure if is important, since I'm planning or working some metadata for sorting and pagination in future iterations.

