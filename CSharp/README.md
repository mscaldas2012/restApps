
Here's the first limitation on C#. I tried creating my Person object with an integer for ID, and here's what I got:

InvalidOperationException: Operation 'GetAPerson' in contract 'IPersonServices' has a path variable named 'id' which does not have type 'string'.  Variables for UriTemplate path segments must have type 'string'.]
so I guess, I'll have to change that to use a string - I don't see any other way around it.
I left the id attribute as integer on the model, but changed it to string at the service layer.

