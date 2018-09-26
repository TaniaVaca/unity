/*
 * To change this license header, choose License Headers in Project Properties.
 * To change this template file, choose Tools | Templates
 * and open the template in the editor.
 */
package com.co.restjsoncube.rest;

import com.co.restjsoncube.rest.dto.Color;
import java.util.ArrayList;
import java.util.Date;
import java.util.List;

import javax.ws.rs.Consumes;
import javax.ws.rs.GET;
import javax.ws.rs.POST;
import javax.ws.rs.Path;
import javax.ws.rs.Produces;
import javax.ws.rs.core.MediaType;

/**
 *
 * @author taticamumu
 */
@Path("/colorcube")
public class ServiceRESTJson {
 @GET
 @Path("/list")
 @Consumes({MediaType.APPLICATION_JSON})
 @Produces(MediaType.APPLICATION_JSON)
 public String getCoutries(){
     int red = (int)(Math.random()*256);
     int green = (int)(Math.random()*256);
     int blue = (int)(Math.random()*256);
     
      System.out.println("{\n" +
"  \"red\": "+red+",\n"+
"  \"green\": "+green+",\n"+
"  \"blue\": "+blue+"\n"+
"}");
  return "{\n" +
"  \"red\": "+red+",\n"+
"  \"green\": "+green+",\n"+
"  \"blue\": "+blue+"\n"+
"}";
 }
    
    @POST
    @Consumes({MediaType.APPLICATION_JSON})
    @Produces({MediaType.TEXT_PLAIN})
    @Path("/post")
    public String postMessage(Color color) throws Exception{
        
        System.out.println("Rojo = "+color.getR());
        System.out.println("Verde  = "+color.getG());
        System.out.println("Azul  = "+color.getB());
        
        return "ok" + "Color "+color.getR();
    } 
}
