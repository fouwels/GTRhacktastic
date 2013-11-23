<?php

require("lib/Toro.php");
require("services.php")

// /
class RootHandler{
    function get() {

        echo(
        "GTR API v0.1.1<br/>".
        "Available endpoints:<br/>".
        "- /<br/>".

        "\n\nCurrent time: ".time()."<br/>");       
    }
}

// /find/
class FindHandler{
    function get(){

    }
}


// /test/
class TestHandler {
    function get() {
        echo "TestHandler | ".time();      
    }
}

Toro::serve(array(
    "/" => "RootHandler",

    "/find/" => "FindHander",

    "/test/" => "TestHandler",
    "/test/mysql/" => "TestSqlHandler"
));

?>