<?php
    header("Access-Control-Allow-Origin: *");
    header("Access-Control-Allow-Headers: X-Requested-With,
     Content-Type, Origin, Cache-Control, Pragma, Authorization, 
     Accept, Accept-Encoding");
    header("Content-Type: application/json;");
    
        
include_once 'config/database.php';
$userArr = array();

$query="select * from contacts order by fio";
$statement = $connect->prepare($query);
$statement->execute();
while($row = $statement->fetch(PDO::FETCH_ASSOC))
{
	$data[] =$row;
}
echo json_encode($data);
  

?>