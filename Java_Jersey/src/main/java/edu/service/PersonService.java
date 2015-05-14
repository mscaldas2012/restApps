package edu.service;

import edu.model.Bookmark;
import edu.model.Person;

import javax.inject.Singleton;
import javax.servlet.http.HttpServletResponse;
import javax.ws.rs.*;
import javax.ws.rs.core.*;
import java.util.ArrayList;
import java.util.List;
import java.util.stream.Collectors;

/**
 * Created by Marcelo Caldas on 4/3/2015.
 */
@Path("/account")
@Singleton
public class PersonService {
    @Context
    UriInfo uriInfo;
    @Context
    Request request;
    @Context  //injected response proxy supporting multiple threads
    private HttpServletResponse response;

    List<Person> allPeople = new ArrayList<Person>();

    @GET
    @Produces({ MediaType.APPLICATION_JSON })
    //Use this for mandatory query parameters: @QueryParam("name")String name  //set as method parameter.
    public List<Person> getAllPeople() {
        //Use this for optional parameters:
        String name = uriInfo.getQueryParameters().getFirst("name");
        if (allPeople != null && name != null && name.trim().length() > 0) {
            return allPeople.stream().filter(p -> p.getName().contains(name)).collect(Collectors.toList());
        } else {
            return allPeople;
        }
    }

    @GET
    @Path("{id}")
    @Produces(MediaType.APPLICATION_JSON)
    public Person getAPerson(@PathParam("id")int id) {
        try {
            return allPeople.get(id);
        } catch (IndexOutOfBoundsException e) {
            throw new NotFoundException("User " + id + " not found!");
       }
    }

    @POST
    @Consumes(MediaType.APPLICATION_JSON)
    @Produces(MediaType.APPLICATION_JSON)
    public Person createPerson(Person newPerson) {
        newPerson.setId(allPeople.size());
        allPeople.add(newPerson);
        response.setStatus(Response.Status.CREATED.getStatusCode());
        return newPerson;
    }

    @PUT
    @Path("{id}")
    @Consumes(MediaType.APPLICATION_JSON)
    @Produces(MediaType.APPLICATION_JSON)
    public Person updatePerson(@PathParam("id")int id, Person updatedPerson) {
        try {
            updatedPerson.setId(id);
            allPeople.set(id, updatedPerson);
            return allPeople.get(id);
        } catch (IndexOutOfBoundsException e) {
            throw new NotFoundException("User " + id + " not found!");
        }
    }

    @DELETE
    @Path("{id}")
    @Produces(MediaType.TEXT_PLAIN) //Returns a regular 200 if successful or 404 if invalid ID passed.
    public Response deletePerson(@PathParam("id")int id) {
        try {
            allPeople.remove(id);
            return Response.ok().entity(id).status(Response.Status.OK).build();
        } catch (IndexOutOfBoundsException e) {
            throw new NotFoundException("User " + id + " not found!");
        }
    }

    //bookmarks management:
    @GET
    @Path("{id}/bookmark")
    @Produces(MediaType.APPLICATION_JSON)
    public List<Bookmark> getBookmarksForUser(@PathParam("id")int userId) {
        Person p = getAPerson(userId);
        return p.getBookmarks();
    }

    @POST
    @Path("{id}/bookmark")
    @Consumes(MediaType.APPLICATION_JSON)
    @Produces(MediaType.APPLICATION_JSON)
    public Bookmark addBookmark(@PathParam("id")int userId, Bookmark newBookmark) {
        Person p = getAPerson(userId);
        if (p.getBookmarks() == null) {
            p.setBookmarks(new ArrayList<Bookmark>());
        }
        p.getBookmarks().add(newBookmark);
        response.setStatus(Response.Status.CREATED.getStatusCode());
        return newBookmark;
    }

    @PUT
    @Path("{userId}/bookmark/{id}")
    @Consumes(MediaType.APPLICATION_JSON)
    @Produces(MediaType.APPLICATION_JSON)
    public Bookmark updateBookmark(@PathParam("userId")int userId, @PathParam("id")long bmId, Bookmark updatedBookmark) {
        Person p = getAPerson(userId);
        Bookmark b = getBookmark(p.getBookmarks(), bmId);
        b.setDescription(updatedBookmark.getDescription());
        b.setUrl(updatedBookmark.getUrl());
        return b;
    }

    @DELETE
    @Path("{userId}/bookmark/{id}")
    @Produces(MediaType.TEXT_PLAIN)
    public Response deleteBookmark(@PathParam("userId")int userId, @PathParam("id")long bmId) {
        Person p = getAPerson(userId);
        for (Bookmark b: p.getBookmarks()) {
            if (bmId == b.getId()) {
                p.getBookmarks().remove(b);
                return Response.ok().entity("bookmark has been removed!").status(Response.Status.OK).build();
            }
        }
        throw new NotFoundException("Bookmark not found for user  BM id " + bmId);
    }


    private Bookmark getBookmark(List<Bookmark> allBM, long bmId) {
        for (Bookmark b: allBM) {
            if (bmId == b.getId()) {
                return b;
            }
        } //If didn't find bookmark, throw 404
        throw new NotFoundException("Bookmark not found for user  BM id " + bmId);
    }
}
