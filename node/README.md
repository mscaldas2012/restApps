This is a simple implementation of the bookmark services on Node.JS using restify.

Once you clone this project, you can set it up as follows:

<H2>Requirements</h2>
<ul>
<li>You need to have Node.JS installed on your machine.</li>
<li>Optional: If you want to build the docker image, make sure you have Docker installed as well</li>
</ul>

<h2>Running the app</h2>
In order to run the app, first run <code>npm install</code>.
This will install the dependencies on package.json and get the app ready to run.
Then just run <code>npm start</npm> to start the application.

<h2>Docker Image</h2>
If you want to run this as a docker image, build it first:
<code>docker build -t &lt;yourtagname&gt;:&lt;version&gt; .</code>
Then run it:
<code>docker run -p 8080:8080 &lt;yourtagname&gt;:&lt;version&gt;</code>


