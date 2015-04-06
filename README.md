# restApps

<h2>Status: (last updated 4/6/2015)</h2>
<ul>
<li><B>Java:</B>Phase 1 complete</li>
<li><B>C#:</B> Phase 1 - under development</li>
<li><B>Python:</B> Phase 2 - under development</li>
<li><B>Ruby:</B> Not started</li>
<li><B>Node JS:</B> Not started</li>
</ul>


Quick demonstration of how to create restful applications in several languages. 

the idea for this project is to compare how each language/platform deals with a specific use case: Creating restful
services and use JSON as the standard for transporting data.

I'll pursue to create the same restful services on each platform and try to draw some conclusios as to how easy or 
hard the implementation is, how much specifics to each platform one need to use, how big/convoluted the code is or how
clean it is, etc.

each folder here is a project on its own. You need to checkout only that specific project if you're interested in checking 
out a specific platform.

Here at the root, you'll find the conclusions I was able to draw and common stuff for all projects, like a raml file 
describing the services that are implemented and soap UI project for testing those services.

<h2>Objectives</h2>
Services are becoming more and more common and RESTful services are gaining popularity like never before. I do believe
microservices is a great way of designing and architecting solutions and REST services fits the bill very well.

My main focus is to study various platforms and how much of a learning curve they require if I would like to incorporate
microservices on my solutions. Most of my needs is to be able to expose services to be reused accross different 
platforms - desktop, mobile, etc - and be able to ramp up previous services that already provide some of the functionality
that was implemented previously. 

Therefore, I see those RESTful services as a mechanism for some app we're developing use services previously developed.
With that in mind, I'll be concentrating heavily in JSON instead of XML, because I believe JSON is more n sync with the
objectives I'm trying to achieve. XML is a great feature, and very important for those B2B scenarios that different 
entities are communicating with eachother and require i higher degree of communication.
Here, I'm just making my own applications talk to my own services, but still levraging reusability within the organization.
 

<h2>The Application</h2>
I'm planning on building a simple application that will allow to maintain a list of URLs (bookmarks) for a specif user 
(account).

With that, I'll be able to demonstrate how each platform supports the mapping of objects to JSON, including a dependency
between those objects. In this case, an account has 0 or more bookmarks.

You can see full detailed documentation of the services itself with the raml file. (also, some HTML generated documentation
is available)

At this point, I am not interested in anything but the restful layer itself. So for brevity and clarity of the code, there 
will be no trully persistence of the information being gathered. I'll try to always implement a in-memory scenario for
the data, whether saving it on a hashtable, or list in memory will suffice. I'm sure each platform has its own way of
mapping objects to databases, but this is not the scope for this project. 
(Maybe at a later stage, I'll incorporate some no-sql type of persistence mechanism just to see how it works).


The summary of the services are as follow:

GET  /account - retrieves all accounts available (remember, at each startup, there will be no accounts)
POST /account - creates a new account.
GET  /account/{id} - retrieves a specific account or 404 if the account id is invalid.
PUT  /account/{id} - updates the specific account provided by id.
DELETE /account/{id} - deletes the specific account.

GET  /account/{userId}/bookmark - retrieves all bookmarks associated with account {userId}
POST /account/{userId}/bookmark - creates a new bookmark for account {userId}
GET  /account/{userId}/bookmark/{id} - retrieves the specific bookmark (by ID) for account userId.
PUT  /account/{userId}/bookmark/{id} - updates the specific bookmark.
DELETE /account/{userId}/bookmark/{id} - deletes the specific bookmark.

<h2>Scope</h2>
The primary focus of each project is to concentrate on how the restful implementation is handled. How to map URL to 
resources, how to manage the serialization and deserialization of objects to and from JSON. XML is not my priority at
this point. Nor is security. (although I don plan to tackle that in future iterations).
As mentioned above, persistence is also not of concern right now. All information will be hosted in memory and will be gone 
when the server shuts down.

Here are the languages I'm planning on implementing those services:
<ul>
<li>Java - Using jersey, maven</li>
<li>C#</li>
<li>Python - using Flask</li>
<li>Ruby</li>
<li>Node JS</li>
</ul>

the initial frameworks used are listed above. I'll continue studying other frameworks and if they offfer meaningful differences
or a different approach to the problem, I might create another project for that specific framework.
Or, if anyone is willing to provide such project, I'll gladly incorporate it. 
My only requirement is that it should abide by the same RAML posted here and the same schema for the JSON objects.
If the implementation needs to deviate from those, they should be documented and explained so I can add that to the project.

<h2>Phases</h2>
As of now, I'm planning on phasing different fucntionalities into each project. but the idea is to have all projects go 
through all phases.

here's a definition of some phases I'm planning on creating. (and making each phase available for checkout, so that if
you're not interested in certain features, you can always get the previous phase)
<ol>
<li>Phase 1: Basic implementation of RESTful services</li>
<li>Phase 2: Use authentication (basic, oauth, ? don't know</li>
<li>


