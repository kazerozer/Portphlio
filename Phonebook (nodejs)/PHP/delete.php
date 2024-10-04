<?php
   header("Access-Control-Allow-Origin: *");
   header("Content-Type: application/json;");
   header("Access-Control-Allow-Methods: DELETE");
   header("Access-Control-Max-Age: 3600");
   header("Access-Control-Allow-Headers: Content-Type, 
   Access-Control-Allow-Headers, Authorization, X-Requested-With");
      	  
include_once 'config/database.php';

$data = json_decode(file_get_contents("php://input"),true);
$arr = array_shift($data);
  
$query="DELETE FROM contacts WHERE id=".$arr["id"]."";
$statement = $connect->prepare($query);
$statement->execute();

?>