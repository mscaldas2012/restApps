<h2>Configuration</h2>
<ul>
<li>Java 1.8 -- Using lambda expressions for filtering accounts list (other than that, could've been 1.7 or lower)</li>
<li>Maven 3.0</li>
<li>Jersey</li>
<li>tomcat 7.0</li>
<li>IntelliJ IDEA 14</li>


<h2>Implementation</h2>
This is a Java implementation of the RESTFul services.


For this project, I used java JDK 1.7.
I used Maven to jump start the project with a maven archetype to create the keleton files of the project.
(Eventually, all code was removed and I was left with the structure and configuration files - pom.xml, web.xml, etc)

The maven archetype I used is as follows:

<code>mvn archetype:generate -DarchetypeArtifactId=jersey-quickstart-webapp -DarchetypeGroupId=org.glassfish.jersey.archetypes -DinteractiveMode=false -DgroupId=&lt;myGroup&gt; -DartifactId=&lt;myArtifact&gt; -Dpackage=&lt;com.mypackage&gt; -DarchetypeVersion=2.17</code>

if running on terminal, it seems, you need a basic pom.xml file like the one below:
<br>

<pre>
&lt;?xml version="1.0" encoding="UTF-8"?&gt;
&lt;project xmlns="http://maven.apache.org/POM/4.0.0"              
     xmlns:xsi="http://www.w3.org/2001/XMLSchema-instance" 
     xsi:schemaLocation="http://maven.apache.org/POM/4.0.0 http://maven.apache.org/xsd/maven-4.0.0.xsd"&gt;
  &lt;modelVersion&gt;4.0.0&lt;/modelVersion&gt;
  &lt;groupId&gt;restExample&lt;/groupId&gt;
  &lt;artifactId&gt;restjaxRs&lt;/artifactId&gt;
  &lt;version&gt;1.0-SNAPSHOT&lt;/version&gt;
  &lt;packaging&gt;pom&lt;/packaging&gt;
&lt;/project&gt;</pre>
